using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        private readonly IList<Item> _testItemsList;

        public GildedRoseTest()
        {
            _testItemsList =  new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                }
            };
        }

        [Fact]
        public void UpdateQualityTestForExistingFunctionalityAfterFirstDay()
        {
            var app = new GildedRose(_testItemsList);

            app.UpdateQuality();

            AssertItem(_testItemsList[0], "+5 Dexterity Vest", 9, 19);
            AssertItem(_testItemsList[1], "Aged Brie", 1, 1);
            AssertItem(_testItemsList[2], "Elixir of the Mongoose", 4, 6);
            AssertItem(_testItemsList[3], "Sulfuras, Hand of Ragnaros", 0, 80);
            AssertItem(_testItemsList[4], "Sulfuras, Hand of Ragnaros", -1, 80);
            AssertItem(_testItemsList[5], "Backstage passes to a TAFKAL80ETC concert", 14, 21);
            AssertItem(_testItemsList[6], "Backstage passes to a TAFKAL80ETC concert", 9, 50);
            AssertItem(_testItemsList[7], "Backstage passes to a TAFKAL80ETC concert", 4, 50);
        }

        [Fact]
        public void UpdateQualityTestForExistingFunctionalityAfter30Days()
        {
            var app = new GildedRose(_testItemsList);

            for (var i = 0; i < 30; i++)
            {
                app.UpdateQuality();
            }

            AssertItem(_testItemsList[0], "+5 Dexterity Vest", -20, 0);
            AssertItem(_testItemsList[1], "Aged Brie", -28, 50);
            AssertItem(_testItemsList[2], "Elixir of the Mongoose", -25, 0);
            AssertItem(_testItemsList[3], "Sulfuras, Hand of Ragnaros", 0, 80);
            AssertItem(_testItemsList[4], "Sulfuras, Hand of Ragnaros", -1, 80);
            AssertItem(_testItemsList[5], "Backstage passes to a TAFKAL80ETC concert", -15, 0);
            AssertItem(_testItemsList[6], "Backstage passes to a TAFKAL80ETC concert", -20, 0);
            AssertItem(_testItemsList[7], "Backstage passes to a TAFKAL80ETC concert", -25, 0);
        }

        private void AssertItem(Item item, string name, int sellIn, int quality)
        {
            Assert.Equal(name, item.Name);
            Assert.Equal(sellIn, item.SellIn);
            Assert.Equal(quality, item.Quality);
        }
    }
}