using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace CSharpCore.Test
{
    public class GildedRoseTest
    {
        [Fact]
        public void ShouldHaveItemWithExpectedName()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Items[0].Name.Should().Be("foo");
        }

    }
}