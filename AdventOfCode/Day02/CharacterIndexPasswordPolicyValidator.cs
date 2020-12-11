namespace AdventOfCode.Day02
{
    public class CharacterIndexPasswordPolicyValidator : IPasswordPolicyValidator
    {
        public bool IsValid(string password, PasswordPolicyToken passwordPolicyToken)
        {
            if (string.IsNullOrWhiteSpace(password) || passwordPolicyToken is null)
                return false;

            var characterIsAtFirstPosition = IsCharacterAtPosition(password, passwordPolicyToken.First, passwordPolicyToken.RequiredCharacter);
            var characterIsAtSecondPosition = IsCharacterAtPosition(password, passwordPolicyToken.Second, passwordPolicyToken.RequiredCharacter);

            return characterIsAtFirstPosition ^ characterIsAtSecondPosition;
        }

        private static bool IsCharacterAtPosition(string value, int position, char character) =>
            value[ToIndex(position)] == character;
        
        private static int ToIndex(int position) => (position - 1) < 0 ? 0 : --position;
    }
}
