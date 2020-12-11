using System.Linq;

namespace AdventOfCode.Day02
{
    public class TobogganCorporatePassword
    {
        public PasswordPolicyToken PasswordPolicyToken { get; }
        public string Value { get; }

        public TobogganCorporatePassword(string tobogganCorporatePassword)
        {
            var passwordParts = tobogganCorporatePassword?.Split(":").Take(2);

            (PasswordPolicyToken, Value) = passwordParts.Count() != 2
                ? (default, default)
                : (new PasswordPolicyToken(passwordParts.First()), passwordParts.Last().Trim());
        }
    }
}
