using System;

namespace QPro.HttpParser {
    public class ItemBase {
        private readonly string source = String.Empty;

        public ItemBase(string source) {
            this.source = source;
        }

        public string Source {
            get {
                return source;
            }
        }
    }
}