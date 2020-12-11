namespace AdventOfCode.Day02
{
    public static class PasswordValidator
    {
        public static bool IsValid(TobogganCorporatePassword password, IPasswordPolicyValidator validator)
        {
            return password is not null && validator is not null &&
                validator.IsValid(password.Value, password.PasswordPolicyToken);
        }
    }
}
