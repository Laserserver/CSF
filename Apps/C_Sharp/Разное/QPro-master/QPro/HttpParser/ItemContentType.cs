using System;
using System.Text.RegularExpressions;

namespace QPro.HttpParser {
    public class ItemContentType : ItemBase {
        private readonly string charset = "utf8";
        private readonly string value = "text/plain";

        public ItemContentType(string source)
            : base(source) {
            if (String.IsNullOrEmpty(source)) {
                return;
            }
            // ищем в источнике первое вхождение точки с запятой
            int typeTail = source.IndexOf(";");
            if (typeTail == -1) {
                // все содержимое источника является информацией о типа
                value = source.Trim().ToLower();
                return; // других параметров нет, выходим
            }
            value = source.Substring(0, typeTail).Trim().ToLower();
            // парсим параметры
            string p = source.Substring(typeTail + 1, source.Length - typeTail - 1);
            var myReg = new Regex(@"(?<key>.+?)=((""(?<value>.+?)"")|((?<value>[^\;]+)))[\;]{0,1}", RegexOptions.Singleline);
            MatchCollection mc = myReg.Matches(p);
            foreach (Match m in mc) {
                if (m.Groups["key"].Value.Trim().ToLower() == "charset") {
                    charset = m.Groups["value"].Value;
                    // можно добавить обработку и других параметров, если таковые будут, что маловероятно
                }
            }
        }

        /// <summary>
        ///     Тип содержимого
        /// </summary>
        public string Value {
            get {
                return value;
            }
        }

        /// <summary>
        ///     Кодировка
        /// </summary>
        public string Charset {
            get {
                return charset;
            }
        }
    }
}