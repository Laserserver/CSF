using System;
using System.Text.RegularExpressions;

namespace QPro.HttpParser {
    public class ItemHost : ItemBase {
        private readonly string host = String.Empty;
        private readonly int port = 80;

        public ItemHost(string source)
            : base(source) {
            // пасим данные
            var myReg = new Regex(@"^(((?<host>.+?):(?<port>\d+?))|(?<host>.+?))$");
            Match m = myReg.Match(source);
            host = m.Groups["host"].Value;
            if (!int.TryParse(m.Groups["port"].Value, out port)) {
                // не удалось преобразовать порт в число, значит порт не указан, ставим значение по умолчанию
                port = 80;
            }
        }

        /// <summary>
        ///     Адрес хоста (домен)
        /// </summary>
        public string Host {
            get {
                return host;
            }
        }

        /// <summary>
        ///     Номер порта, по умолчанию - 80
        /// </summary>
        public int Port {
            get {
                return port;
            }
        }
    }
}