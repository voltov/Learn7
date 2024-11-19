using FluentAssertions;
using Xunit;

namespace UnitTesting
{
    public class StringSumUtilityTests
    {
        [Fact]
        public void Should_Return_Zero_When_Input_Is_Empty_String()
        {
            var utility = new StringSumUtility();

            string result = utility.Sum("", "10");
            result.Should().Be("10");

            result = utility.Sum("10", "");
            result.Should().Be("10");

            result = utility.Sum("", "");
            result.Should().Be("0");
        }

        [Fact]
        public void Should_Return_Sum_When_Both_Inputs_Are_Valid_Numbers()
        {
            var utility = new StringSumUtility();

            string result = utility.Sum("15", "25");
            result.Should().Be("40");

            result = utility.Sum("0", "0");
            result.Should().Be("0");

            result = utility.Sum("123", "456");
            result.Should().Be("579");
        }

        [Fact]
        public void Should_Return_Zero_When_Input_Is_Non_Natural_Number()
        {
            var utility = new StringSumUtility();

            string result = utility.Sum("abc", "10");
            result.Should().Be("10");

            result = utility.Sum("10", "xyz");
            result.Should().Be("10");

            result = utility.Sum("abc", "xyz");
            result.Should().Be("0");
        }

        [Fact]
        public void Should_Return_Zero_When_Input_Is_Negative_Number()
        {
            var utility = new StringSumUtility();

            string result = utility.Sum("-5", "10");
            result.Should().Be("10");

            result = utility.Sum("10", "-5");
            result.Should().Be("10");

            result = utility.Sum("-5", "-10");
            result.Should().Be("0");
        }
    }
}
