using FluentAssertions;
using Xunit;

namespace UnitTesting
{
    public class LeapYearCheckerTests
    {
        [Fact]
        public void Should_Return_True_For_Leap_Year_Divisible_By_4_But_Not_100()
        {
            var checker = new LeapYearChecker();
            bool result = checker.IsLeapYear(1996);
            result.Should().BeTrue();
        }

        [Fact]
        public void Should_Return_False_For_Common_Year_Not_Divisible_By_4()
        {
            var checker = new LeapYearChecker();
            bool result = checker.IsLeapYear(2001);
            result.Should().BeFalse();
        }

        [Fact]
        public void Should_Return_False_For_Common_Year_Divisible_By_100_But_Not_400()
        {
            var checker = new LeapYearChecker();
            bool result = checker.IsLeapYear(1900);
            result.Should().BeFalse();
        }

        [Fact]
        public void Should_Return_True_For_Leap_Year_Divisible_By_400()
        {
            var checker = new LeapYearChecker();
            bool result = checker.IsLeapYear(2000);
            result.Should().BeTrue();
        }
    }
}

