using System;
using System.Linq;

namespace AdventOfCode.Day02
{
    public class PasswordPolicyToken
    {
        public int First { get; }
        public int Second { get; }
        public char RequiredCharacter { get; }

        public PasswordPolicyToken(string passwordPolicy) =>
            (First, Second, RequiredCharacter) = ParseToken(passwordPolicy);

        private static (int first, int second, char requiredCharacter) ParseToken(string passwordPolicyToken)
        {
            try
            {
                var policyParts = passwordPolicyToken?.Split(" ");
                var (numberPattern, character) = (policyParts[0], policyParts[1]);

                var numbers = numberPattern.Split("-").ToList().ConvertAll(Convert.ToInt32);
                return (numbers[0], numbers[1], character[0]);
            }
            catch
            {
                return (default, default, default);
            }
        }
    }
}
