using AdventOfCode.Day02;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Test.Day02
{
    [TestFixture]
    public class PartOneTests
    {
        private readonly IPasswordPolicyValidator validator = new CharacterOccurrencePasswordPolicyValidator();

        [Test]
        public void ExampleOne()
        {
            var password = new TobogganCorporatePassword("1-3 a: abcde");
            var actual = PasswordValidator.IsValid(password, validator);
            actual.Should().BeTrue();
        }

        [Test]
        public void ExampleTwo()
        {
            var password = new TobogganCorporatePassword("1-3 b: cdefg");
            var actual = PasswordValidator.IsValid(password, validator);
            actual.Should().BeFalse();
        }

        [Test]
        public void ExampleThree()
        {
            var password = new TobogganCorporatePassword("2-9 c: ccccccccc");
            var actual = PasswordValidator.IsValid(password, validator);
            actual.Should().BeTrue();
        }

        /// <summary>
        /// 2 passwords are valid. The middle password, cdefg, is not; it contains no instances of b, but needs at least 1.
        /// The first and third passwords are valid: they contain one a or nine c, both within the limits of their respective policies.
        /// </summary>
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
            actual.Should().Be(2);
        }
    }
}
