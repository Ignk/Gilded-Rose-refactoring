namespace csharpcore
{
    public class BackstagePassController : ItemController
    {
        public BackstagePassController(Item item)
        {
            Item = item;
        }

        protected override void CalculateQuality()
        {
            if (Item.SellIn < 0)
            {
                Item.Quality = 0;
            }
            else
            {
                Item.Quality++;
                if (Item.SellIn < 11)
                {
                    if (Item.Quality < 50)
                    {
                        Item.Quality++;
                    }
                }

                if (Item.SellIn < 6 && Item.Quality < 50)
                {
                    Item.Quality++;
                };
            }

        }
    }
}