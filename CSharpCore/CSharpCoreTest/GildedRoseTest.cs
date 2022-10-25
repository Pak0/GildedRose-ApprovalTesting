using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using ApprovalTests.Reporters;
using ApprovalTests;
using Newtonsoft.Json;
using ApprovalTests.Combinations;

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
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Approvals.VerifyJson(JsonConvert.SerializeObject(Items[0]));
        }

        [Fact]
        [UseReporter(typeof(VisualStudioReporter))]
        public void ShouldHaveItemWithAllCombinations()
        {
            IList<string> Items = new List<string> { "Aged Brie", 
                                                     "Sulfuras, Hand of Ragnaros", 
                                                     "Backstage passes to a TAFKAL80ETC concert", 
                                                     "foo" };
            IList<int> SellIns = new List<int> { -1, 0, 5, 6, 10, 11 };
            IList<int> Qualities = new List<int> { 0, 49, 50, 51 };

            CombinationApprovals.VerifyAllCombinations(doItemCheck, Items, SellIns, Qualities);
        }

        private string doItemCheck(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            return JsonConvert.SerializeObject(Items[0]);
        }
    }
}