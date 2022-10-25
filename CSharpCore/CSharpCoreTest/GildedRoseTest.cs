using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using ApprovalTests.Reporters;
using ApprovalTests;
using Newtonsoft.Json;

namespace CSharpCore.Test
{
    public class GildedRoseTest
    {
        [Fact]
        [UseReporter(typeof(VisualStudioReporter))]
        public void ShouldHaveItemWithExpectedName()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo2", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            //Items[0].Name.Should().Be("foo");
            Approvals.Verify(Items[0].ToString());
        }

        [Fact]
        [UseReporter(typeof(VisualStudioReporter))]
        public void ShouldHaveItemWithExpectedName_JsonConvert()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Approvals.Verify(JsonConvert.SerializeObject(Items[0]));
        }

        [Fact]
        [UseReporter(typeof(VisualStudioReporter))]
        public void ShouldHaveItemWithExpectedName_VerifyJson()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Approvals.VerifyJson(JsonConvert.SerializeObject(Items[0]));
        }
    }
}