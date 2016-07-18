using System.Text.RegularExpressions;

namespace QPro.Rules {
    public class QRegexRule : QRule {
        private readonly Regex regex;

        public QRegexRule(string pattern)
            : base(pattern) {
            regex = new Regex(Pattern);
        }

        public override bool IsAccept(string url) {
            var regex = new Regex(Pattern);
            var matches = regex.Matches(url);
            return matches.Count > 0;
        }

        public override string Redirect(string url) {
            if (Behavior != QBehavior.Redirect) {
                return url;
            }
            return regex.Replace(url, RedirectPattern);
        }
    }
}