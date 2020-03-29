namespace csharpcore
{
    public class AgedBrieController : ItemController
    {
        public AgedBrieController(Item item)
        {
            Item = item;
        }

        protected override void CalculateQuality()
        {
            if (Item.Quality >= 50)
            {
                return;
            }

            Item.Quality++;

            if (Item.SellIn <= 0)
            {
                Item.Quality++;
            }
        }
    }
}