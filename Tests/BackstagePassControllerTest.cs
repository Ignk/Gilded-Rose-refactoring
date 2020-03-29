using Xunit;

namespace csharpcore
{
    public class BackstagePassControllerTest
    {
        [Theory]
        [InlineData(15, 14, 20, 21)]
        [InlineData(9, 8, 10, 12)]
        [InlineData(4, 3, 10, 13)]
        [InlineData(-1, -2, 6, 0)]
        [InlineData(-2, -3, 2, 0)]
        public void ShouldProcessItem(int sellIn, int expSellIn, int quality, int expQuality)
        {
            var item = new Item
            {
                Quality = quality,
                SellIn = sellIn
            };

            new BackstagePassController(item).ProcessItem();

            Assert.Equal(expQuality, item.Quality);
            Assert.Equal(expSellIn, item.SellIn);
        }
    }
}