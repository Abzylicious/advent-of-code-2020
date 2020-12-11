namespace AdventOfCode.Day02
{
    public interface IPasswordPolicyValidator
    {
        bool IsValid(string password, PasswordPolicyToken passwordPolicyToken);
    }
}
