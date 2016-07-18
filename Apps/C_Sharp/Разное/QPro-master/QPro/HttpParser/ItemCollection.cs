using System;
using System.Collections.Generic;

namespace QPro.HttpParser {
    public class ItemCollection : Dictionary<string, ItemBase> {
        public ItemCollection() : base(StringComparer.CurrentCultureIgnoreCase) {}

        public void AddItem(string key, string source) {
            switch (key.Trim().ToLower()) {
                case "host":
                    // добавляем хост
                    Add(key, new ItemHost(source));
                    break;

                case "content-type":
                    // тип содержимого
                    Add(key, new ItemContentType(source));
                    break;

                default:
                    // значения других ключей добавляем в виде строки
                    Add(key, new ItemBase(source));
                    break;
            }
        }

        public override string ToString() {
            string result = "";
            foreach (string k in Keys) {
                ItemBase itm = this[k];
                if (!String.IsNullOrEmpty(result)) {
                    result += "\r\n";
                }
                result += String.Format("{0}: {1}", k, itm.Source);
            }
            return result;
        }
    }
}