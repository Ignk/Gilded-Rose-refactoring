using Xunit;

namespace csharpcore
{
    public class ItemControllerTest
    {
        [Theory]
        [InlineData(5,4,5,4)]
        [InlineData(3,2,3,2)]
        [InlineData(1,0,1,0)]
        [InlineData(-2,-3,1,0)]
        [InlineData(-2,-3,2,0)]
        [InlineData(-2,-3,0,0)]
        public void ShouldProcessItem(int sellIn, int expSellIn, int quality, int expQuality)
        {
            var item = new Item
            {
                Quality = quality,
                SellIn = sellIn
            };

            new ItemController(item).ProcessItem();

            Assert.Equal(expQuality, item.Quality);
            Assert.Equal(expSellIn, item.SellIn);
        }
    }
}