namespace csharpcore
{
    public class ConjuredController : ItemController
    {
        public ConjuredController(Item item)
        {
            Item = item;
        }

        protected override void CalculateQuality()
        {
            if (Item.Quality <= 0)
            {
                return;
            };

            Item.Quality -= 2;

            if (Item.SellIn < 0)
            {
                Item.Quality -= 2;
            }

            if (Item.Quality < 0)
            {
                Item.Quality = 0;
            }
        }
    }
}