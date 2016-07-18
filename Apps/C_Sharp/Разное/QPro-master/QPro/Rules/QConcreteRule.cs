namespace QPro.Rules {
    public class QConcreteRule : QRule {
        public QConcreteRule(string pattern) : base(pattern) {}

        public override bool IsAccept(string url) {
            return url == Pattern;
        }

        public override string Redirect(string url) {
            if (Behavior != QBehavior.Redirect) {
                return url;
            }
            return RedirectPattern;
        }
    }
}