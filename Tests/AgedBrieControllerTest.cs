using Xunit;

namespace csharpcore
{
    public class AgedBrieControllerTest
    {
        [Theory]
        [InlineData(5, 4, 4, 5)]
        [InlineData(3, 2, 5, 6)]
        [InlineData(1, 0, 1, 2)]
        [InlineData(-2, -3, 1, 3)]
        [InlineData(-2, -3, 2, 4)]
        public void ShouldProcessItem(int sellIn, int expSellIn, int quality, int expQuality)
        {
            var item = new Item
            {
                Quality = quality,
                SellIn = sellIn
            };

            new AgedBrieController(item).ProcessItem();

            Assert.Equal(expQuality, item.Quality);
            Assert.Equal(expSellIn, item.SellIn);
        }
    }
}