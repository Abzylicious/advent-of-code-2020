using AdventOfCode.Day02;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Test.Day02
{
    [TestFixture]
    public class PartTwoTests
    {
        private readonly IPasswordPolicyValidator validator = new CharacterIndexPasswordPolicyValidator();

        /// <summary>
        /// "1-3 a: abcde" is valid: position 1 contains a and position 3 does not.
        /// </summary>
        [Test]
        public void ExampleOne()
        {
            var password = new TobogganCorporatePassword("1-3 a: abcde");
            var actual = PasswordValidator.IsValid(password, validator);
            actual.Should().BeTrue();
        }

        /// <summary>
        /// "1-3 b: cdefg" is invalid: neither position 1 nor position 3 contains b.
        /// </summary>
        [Test]
        public void ExampleTwo()
        {
            var password = new TobogganCorporatePassword("1-3 b: cdefg");
            var actual = PasswordValidator.IsValid(password, validator);
            actual.Should().BeFalse();
        }

        /// <summary>
        /// "2-9 c: ccccccccc" is invalid: both position 2 and position 9 contain c.
        /// </summary>
        [Test]
        public void ExampleThree()
        {
            var password = new TobogganCorporatePassword("2-9 c: ccccccccc");
            var actual = PasswordValidator.IsValid(password, validator);
            actual.Should().BeFalse();
        }

        [Test]
        public void ExampleFour()
        {
            var passwordEntries = new List<string>
            {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            };

            var actual = PasswordDatabase.GetValidPasswordCount(passwordEntries, validator);
            actual.Should().Be(1);
        }
    }
}
