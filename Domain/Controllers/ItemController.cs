namespace csharpcore
{
    public class ItemController 
    {
        public Item Item { get; set; }

        public ItemController()
        {
        }

        public ItemController(Item item)
        {
            Item = item;
        }

        public virtual void ProcessItem()
        {
            CalculateQuality();
            CalculateSellIn();
        }

        protected virtual void CalculateQuality()
        {
            if (Item.Quality <= 0)
            {
                return;
            };

            Item.Quality--;

            if (Item.SellIn < 0 && Item.Quality > 0)
            {
                Item.Quality--;
            }
        }

        protected virtual void CalculateSellIn()
        {
            Item.SellIn--;
        }
    }
}