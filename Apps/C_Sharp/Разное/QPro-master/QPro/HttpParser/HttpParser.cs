/*
 * Пример к статье «Разработка прокси-сервера»
 * http://kbyte.ru/ru/Programming/Articles.aspx?id=66&mode=art
 * Автор: Алексей Немиро
 * http://aleksey.nemiro.ru
 * Специально для Kbyte.Ru
 * http://kbyte.ru
 * Copyright © Aleksey S Nemiro, 2011
 */
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;

namespace QPro.HttpParser {
    public class Parser {
        public enum MethodsList {
            /// <summary>
            ///     Запрос методом GET
            /// </summary>
            GET,

            /// <summary>
            ///     Запрос методом POST
            /// </summary>
            POST,

            /// <summary>
            ///     Для защищенных соединений
            /// </summary>
            CONNECT
            // список можно продолжить
        }

        private readonly int headersTail = -1;

        private readonly string httpVersion = "1.1";
        private readonly ItemCollection items;
        private readonly MethodsList method = MethodsList.GET;
        private readonly string path = String.Empty;

        private readonly int statusCode;
        private readonly string statusMessage = string.Empty;
        private byte[] source;

        public Parser(byte[] source) {
            if (source == null || source.Length <= 0) {
                return;
            }
            this.source = source;

            items = new ItemCollection();
            // преобразуем данные в текст
            string sourceString = GetSourceAsString();

            // при запросе
            // первая строка содержит метод запроса, путь и версию HTTP протокола
            string httpInfo = sourceString.Substring(0, sourceString.IndexOf("\r\n"));
            var myReg = new Regex(@"(?<method>.+)\s+(?<path>.+)\s+HTTP/(?<version>[\d\.]+)", RegexOptions.Multiline);
            if (myReg.IsMatch(httpInfo)) {
                Match m = myReg.Match(httpInfo);
                if (m.Groups["method"].Value.ToUpper() == "POST") {
                    method = MethodsList.POST;
                } else if (m.Groups["method"].Value.ToUpper() == "CONNECT") {
                    method = MethodsList.CONNECT;
                } else {
                    method = MethodsList.GET;
                }
                // или можно определить метод вот так
                // _Method = (MethodsList)Enum.Parse(typeof(MethodsList), m.Groups["method"].Value.ToUpper());
                // но надежней всеже использовать условие

                path = m.Groups["path"].Value;
                httpVersion = m.Groups["version"].Value;
            } else {
                // при ответе
                // первая строка содержит код состояния
                myReg = new Regex(@"HTTP/(?<version>[\d\.]+)\s+(?<status>\d+)\s*(?<msg>.*)", RegexOptions.Multiline);
                Match m = myReg.Match(httpInfo);
                int.TryParse(m.Groups["status"].Value, out statusCode);
                statusMessage = m.Groups["msg"].Value;
                httpVersion = m.Groups["version"].Value;
            }

            // выделяем заголовки (до первых двух переводов строк)
            headersTail = sourceString.IndexOf("\r\n\r\n");
            if (headersTail != -1) {
                // хвост найден, отделяем заголовки
                sourceString = sourceString.Substring(sourceString.IndexOf("\r\n") + 2, headersTail - sourceString.IndexOf("\r\n") - 2);
            }

            // парсим заголовки и заносим их в коллекцию
            myReg = new Regex(@"^(?<key>[^\x3A]+)\:\s{1}(?<value>.+)$", RegexOptions.Multiline);
            MatchCollection mc = myReg.Matches(sourceString);
            foreach (Match mm in mc) {
                string key = mm.Groups["key"].Value;
                if (!items.ContainsKey(key)) {
                    // если указанного заголовка нет в коллекции, добавляем его
                    items.AddItem(key, mm.Groups["value"].Value.Trim("\r\n ".ToCharArray()));
                }
            }
        }

        /// <summary>
        ///     Тип запроса (при запросе)
        /// </summary>
        public MethodsList Method {
            get {
                return method;
            }
        }

        /// <summary>
        ///     Путь (при запросе)
        /// </summary>
        public string Path {
            get {
                return path;
            }
        }

        /// <summary>
        ///     Заголовки
        /// </summary>
        public ItemCollection Items {
            get {
                return items;
            }
        }

        /// <summary>
        ///     Источник данных
        /// </summary>
        public byte[] Source {
            get {
                return source;
            }
        }

        /// <summary>
        ///     Хост (домен, ip) - при запросе
        /// </summary>
        public string Host {
            get {
                if (!items.ContainsKey("Host")) {
                    return String.Empty;
                }
                return ((ItemHost)items["Host"]).Host;
            }
        }

        /// <summary>
        ///     Номер порта, по умолчанию 80 - при запросе
        /// </summary>
        public int Port {
            get {
                if (!items.ContainsKey("Host")) {
                    return 80;
                }
                return ((ItemHost)items["Host"]).Port;
            }
        }

        /// <summary>
        ///     Код состояния (при ответе)
        /// </summary>
        public int StatusCode {
            get {
                return statusCode;
            }
        }

        /// <summary>
        ///     Сообщение сервера (при ответе)
        /// </summary>
        public string StatusMessage {
            get {
                return statusMessage;
            }
        }

        /// <summary>
        ///     Возвращает оригинальные данные в виде строки
        /// </summary>
        public string GetSourceAsString() {
            Encoding e = Encoding.UTF8;
            // если есть тип содержимого, то может есть и кодировка
            if (items != null && items.ContainsKey("Content-Type") && !String.IsNullOrEmpty(((ItemContentType)items["Content-Type"]).Charset)) {
                // кодировка есть, используем её при декодировании данных
                try {
                    e = Encoding.GetEncoding(((ItemContentType)items["Content-Type"]).Charset);
                }
                catch {}
            }
            return e.GetString(source);
        }

        /// <summary>
        ///     Возвращает заголовки в виде строки
        /// </summary>
        /// <returns></returns>
        public string GetHeadersAsString() {
            if (items == null) {
                return String.Empty;
            }
            return items.ToString();
        }

        /// <summary>
        ///     Фукнция возвразает содержимое в виде масссива байт
        /// </summary>
        public byte[] GetBody() {
            // хвоста нет, значит тела тоже нет
            if (headersTail == -1) {
                return null;
            }
            // выделяем тело, начиная с конца хвоста
            var result = new byte[source.Length - headersTail - 4];
            Buffer.BlockCopy(source, headersTail + 4, result, 0, result.Length);
            // тело может быть сжато, проверяем так это или нет
            if (items != null && items.ContainsKey("Content-Encoding") && items["Content-Encoding"].Source.ToLower() == "gzip") {
                // если данные сжаты, то разархивируем их
                var myGzip = new GZipStream(new MemoryStream(result), CompressionMode.Decompress);
                using (var m = new MemoryStream()) {
                    var buffer = new byte[512];
                    int len;
                    while ((len = myGzip.Read(buffer, 0, buffer.Length)) > 0) {
                        m.Write(buffer, 0, len);
                    }
                    result = m.ToArray();
                }
            }
            // возвращаем результат
            return result;
        }

        /// <summary>
        ///     Функция возвращает содержимое в виде строки
        /// </summary>
        public string GetBodyAsString() {
            Encoding e = Encoding.UTF8;
            // если есть тип содержимого, то может есть и кодировка
            if (items != null && items.ContainsKey("Content-Type") && !String.IsNullOrEmpty(((ItemContentType)items["Content-Type"]).Charset)) {
                // кодировка есть, используем её при декодировании содержимого
                try {
                    e = Encoding.GetEncoding(((ItemContentType)items["Content-Type"]).Charset);
                }
                catch {}
            }
            return e.GetString(GetBody());
        }

        /// <summary>
        ///     Вставляет текстовое содержимое, изменяет Content-Length
        /// </summary>
        /// <param name="newBody">Новое содержимое, которое нужно вставить</param>
        public void SetStringBody(string newBody) {
            // формируем заголовки
            if (statusCode <= 0) {
                // такого быть не должно
                throw new Exception("Можно изменять только содержимое, полученное в ответ от удаленного сервера.");
            }
            Encoding e = Encoding.UTF8;
            string result = String.Format("HTTP/{0} {1} {2}", httpVersion, statusCode, statusMessage);
            foreach (string k in items.Keys) {
                ItemBase itm = items[k];
                if (!String.IsNullOrEmpty(result)) {
                    result += "\r\n";
                }
                if (k.ToLower() == "content-length") {
                    // информация о размере содержимого, меняем
                    result += String.Format("{0}: {1}", k, newBody.Length);
                } else if (k.ToLower() == "content-encoding" && itm.Source.ToLower() == "gzip") {
                    // если оригинальное содержимое сжато, то пропускаем этот заголовок, т.к. у нас обратного сжатия нет (но можно сделать, если нужно)
                } else {
                    // другие заголовки оставляем без изменений
                    result += String.Format("{0}: {1}", k, itm.Source);
                    // если это тип содержимого, то смотрим, может есть информация о кодировке
                    if (k.ToLower() == "content-type" && !String.IsNullOrEmpty(((ItemContentType)items["Content-Type"]).Charset)) {
                        // кодировка есть, используем её при кодировании содержимого
                        try {
                            e = Encoding.GetEncoding(((ItemContentType)items["Content-Type"]).Charset);
                        }
                        catch {}
                    }
                }
            }
            // разделитель между телом и заголовками
            result += "\r\n\r\n";
            // добавляем тело
            result += newBody;
            // переносим в источник
            source = e.GetBytes(result);
        }
    }
}