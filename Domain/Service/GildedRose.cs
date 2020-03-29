using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                ProcessItem(item);
            }
        }

        private static void ProcessItem(Item item)
        {
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    new LegendaryController(item).ProcessItem();
                    break;
                case "Aged Brie":
                    new AgedBrieController(item).ProcessItem();
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    new BackstagePassController(item).ProcessItem();
                    break;
                case "Conjured Mana Cake":
                    new ConjuredController(item).ProcessItem();
                    break;
                default:
                    new ItemController(item).ProcessItem();
                    break;
            }
        }

    }

}
