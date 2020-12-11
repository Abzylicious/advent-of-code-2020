using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day02
{
    public static class PasswordDatabase
    {
        public static int GetValidPasswordCount(IEnumerable<string> passwordEntries, IPasswordPolicyValidator validator) =>
            passwordEntries.Count(entry => PasswordValidator.IsValid(new TobogganCorporatePassword(entry), validator));
    }
}
