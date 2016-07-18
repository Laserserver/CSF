using System;
using System.Collections.Generic;
using System.Linq;
using QPro.Rules;

namespace QPro {
    public class QProxy : BaseProxy {
        public readonly List<QRule> BlackList;
        public readonly List<QRule> Rules;
        private readonly QCache cache;

        public QProxy() {
            cache = new QCache();

            Rules = new List<QRule>();
            BlackList = new List<QRule>();
        }

        public void AddRule(QRule rule) {
            switch (rule.Behavior) {
                case QBehavior.Skip:
                    Rules.Add(rule);
                    break;
                case QBehavior.Redirect:
                    Rules.Add(rule);
                    break;
                case QBehavior.Block:
                    BlackList.Add(rule);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void RemoveRule(QRule rule) {
            switch (rule.Behavior) {
                case QBehavior.Skip:
                    Rules.Remove(rule);
                    break;
                case QBehavior.Redirect:
                    Rules.Remove(rule);
                    break;
                case QBehavior.Block:
                    BlackList.Remove(rule);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void AddBlackItem() {}

        public void RemoveBlackItem() {}

        public List<QItemCache> GetItemsFromCacheByRule(QRule rule) {
            return cache.GetItems(rule.Guid);
        }

        public List<QItemCache> GetItemsFromCacheByUrl(string url) {
            return cache.GetItems(url);
        }

        public void RemoveItemFromCache(string key) {
            cache.Remove(key);
        }

        protected override void OnReceiveRequest(TransferItem item) {
            if (CheckOnBlackList(item) == false) {
                return;
            }
            CheckOnRules(item);
        }

        private bool CheckOnBlackList(TransferItem item) {
            // In BlackList must be rule with QBehavior = Block
            if (BlackList.Any(rule => rule.IsAccept(item.HttpRequestLine.URI))) {
                item.State.NextStep = null;
                return false;
            }
            return true;
        }

        private void CheckOnRules(TransferItem item) {
            foreach (var rule in Rules) {
                if (rule.IsAccept(item.HttpRequestLine.URL)) {
                    if (rule.IsStoreResponse) {
                        cache.Add(rule.Guid, item, rule.IsAllStoreResponse);
                    }
                    item.HttpRequestLine.URL = rule.Redirect(item.HttpRequestLine.URL);
                    break;
                }
            }
        }

        protected override void OnReceiveResponse(TransferItem item) {
            if (Rules.Where(rule => rule.IsAccept(item.HttpRequestLine.URL)).Any(rule => rule.IsStoreResponse)) {
                cache.SetValue(item.BrowserSocket.guid, item.Response, item.ResponseStatusLine.StatusCode);
            }
        }
    }
}