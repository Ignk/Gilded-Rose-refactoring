using Xunit;

namespace csharpcore
{
    public class LegendaryControllerTest
    {
        [Theory]
        [InlineData(5, 5, 4, 4)]
        [InlineData(3, 3, 5, 5)]
        [InlineData(1, 1, 1, 1)]
        [InlineData(-2, -2, 1, 1)]
        [InlineData(-2, -2, -2, -2)]
        public void ShouldProcessItem(int sellIn, int expSellIn, int quality, int expQuality)
        {
            var item = new Item
            {
                Quality = quality,
                SellIn = sellIn
            };

            new LegendaryController(item).ProcessItem();

            Assert.Equal(expQuality, item.Quality);
            Assert.Equal(expSellIn, item.SellIn);
        }
    }
}