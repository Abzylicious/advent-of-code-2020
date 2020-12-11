using System.Linq;

namespace AdventOfCode.Day02
{
    public class CharacterOccurrencePasswordPolicyValidator : IPasswordPolicyValidator
    {
        public bool IsValid(string password, PasswordPolicyToken passwordPolicyToken)
        {
            if (string.IsNullOrWhiteSpace(password) || passwordPolicyToken is null)
                return false;

            var occurrences = password.Count(character => character == passwordPolicyToken.RequiredCharacter);
            return InRange(occurrences, passwordPolicyToken.First, passwordPolicyToken.Second);
        }

        private static bool InRange(int value, int min, int max) => value >= min && value <= max;
    }
}
