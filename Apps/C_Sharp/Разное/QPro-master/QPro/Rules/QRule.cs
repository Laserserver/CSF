using System;

namespace QPro.Rules {
    public enum QBehavior {
        Skip,
        Redirect,
        Block
    }

    public abstract class QRule {
        protected QRule(string pattern) {
            Guid = Guid.NewGuid();
            Pattern = pattern;
        }

        public Guid Guid { get; set; }

        public QBehavior Behavior { get; set; }

        public string Pattern { get; private set; }

        public string RedirectPattern { get; set; }

        public string Exceptions { get; set; }

        public bool IsStoreResponse { get; set; }

        public bool IsAllStoreResponse { get; set; }

        public abstract bool IsAccept(string url);

        public abstract string Redirect(string url);
    }
}