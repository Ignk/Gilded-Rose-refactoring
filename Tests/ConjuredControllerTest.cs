using Xunit;

namespace csharpcore
{
    public class ConjuredControllerTest
    {
        [Theory]
        [InlineData(4, 3, 5, 3)]
        [InlineData(3, 2, 3, 1)]
        [InlineData(1, 0, 1, 0)]
        [InlineData(-1, -2, 5, 1)]
        [InlineData(-1, -2, 3, 0)]
        [InlineData(-2, -3, 1, 0)]
        [InlineData(-2, -3, 2, 0)]
        [InlineData(-2, -3, 0, 0)]
        public void ShouldProcessItem(int sellIn, int expSellIn, int quality, int expQuality)
        {
            var item = new Item
            {
                Quality = quality,
                SellIn = sellIn
            };

            new ConjuredController(item).ProcessItem();

            Assert.Equal(expQuality, item.Quality);
            Assert.Equal(expSellIn, item.SellIn);
        }
    }
}