using FluentAssertions;

namespace UnitTesting
{
    public class RecentlyUsedListTests
    {
        [Fact]
        public void Should_Throw_Exception_When_Creating_With_Negative_Capacity()
        {
            Action action = () => new RecentlyUsedList(-1);
            action.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void Should_Throw_Exception_When_Adding_Null_Or_Empty_String()
        {
            var list = new RecentlyUsedList(3);

            Action addNull = () => list.Add(null);
            addNull.Should().ThrowExactly<ArgumentException>();

            Action addEmpty = () => list.Add(string.Empty);
            addEmpty.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void Should_Be_Initially_Empty()
        {
            var list = new RecentlyUsedList(3);
            list.Count.Should().Be(0);
        }

        [Fact]
        public void Should_Have_Most_Recently_Added_Item_First_And_Least_Recently_Added_Item_Last()
        {
            var list = new RecentlyUsedList(3);

            list.Add("item1");
            list.Add("item2");
            list.Add("item3");

            list.Count.Should().Be(3);
            list.Get(0).Should().Be("item3"); // Most recently added item
            list.Get(1).Should().Be("item2");
            list.Get(2).Should().Be("item1"); // Least recently added item
        }

        [Fact]
        public void Should_Move_Duplicate_Insertions_Rather_Than_Adding()
        {
            var list = new RecentlyUsedList(3);

            list.Add("item1");
            list.Add("item2");
            list.Add("item3");

            list.Count.Should().Be(3);
            list.Get(0).Should().Be("item3");
            list.Get(1).Should().Be("item2");
            list.Get(2).Should().Be("item1");

            list.Add("item2");

            list.Count.Should().Be(3);
            list.Get(0).Should().Be("item2");
            list.Get(1).Should().Be("item3");
            list.Get(2).Should().Be("item1");
        }

        [Fact]
        public void Should_Throw_Exception_When_Index_Is_Out_Of_Bounds()
        {
            var list = new RecentlyUsedList(3);

            list.Add("item1");
            list.Add("item2");
            list.Add("item3");

            Action getItemAtNegativeIndex = () => list.Get(-1);
            getItemAtNegativeIndex.Should().ThrowExactly<ArgumentOutOfRangeException>();

            Action getItemAtOutOfBoundsIndex = () => list.Get(3);
            getItemAtOutOfBoundsIndex.Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Throw_Exception_When_Index_Is_Negative()
        {
            var list = new RecentlyUsedList(3);

            list.Add("item1");
            list.Add("item2");
            list.Add("item3");

            Action getItemAtNegativeIndex = () => list.Get(-1);
            getItemAtNegativeIndex.Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Have_Default_Capacity_Of_Five()
        {
            var list = new RecentlyUsedList();

            list.Add("item1");
            list.Add("item2");
            list.Add("item3");
            list.Add("item4");
            list.Add("item5");
            list.Add("item6");

            list.Count.Should().Be(5); // Default capacity is 5
            list.Get(0).Should().Be("item6"); // Most recently added item
            list.Get(4).Should().Be("item2"); // Least recently added item within capacity
        }
    }
}
