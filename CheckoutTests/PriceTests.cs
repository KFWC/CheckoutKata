using CheckoutKata;

namespace CheckoutKataTests
{
    [TestFixture]
    public class PriceTests
    {
        private PriceList prices;

        [SetUp]
        public void Setup()
        {
            prices = new PriceList();
        }

        [Test]
        public void AddPriceItem_ListShouldContainOneItem()
        {
            prices.AddPrice(new Price { Sku = "A", UnitPrice = 100 });

            Assert.That(prices.Prices.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddTwoPriceItems_ListShouldContainTwoItems()
        {
            prices.AddPrice(new Price { Sku = "A", UnitPrice = 100 });
            prices.AddPrice(new Price { Sku = "B", UnitPrice = 200 });

            Assert.That(prices.Prices.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddThreePriceItems_ListShouldContainThreeItems()
        {
            prices.AddPrice(new Price {Sku = "A", UnitPrice = 100 });
            prices.AddPrice(new Price {Sku = "B", UnitPrice = 200 });
            prices.AddPrice(new Price {Sku = "C", UnitPrice = 300 });

            Assert.That(prices.Prices.Count, Is.EqualTo(3));
        }

        [Test]
        public void AddItemWithTheSameSku_ShouldOverwriteTheExistingItem()
        {
            prices.AddPrice(new Price {Sku = "A", UnitPrice = 100 });
            prices.AddPrice(new Price {Sku = "B", UnitPrice = 200 });
            prices.AddPrice(new Price {Sku = "B", UnitPrice = 300 });

            var price = prices.Prices.FirstOrDefault(p => p.Sku == "B");

            Assert.That(prices.Prices.Count, Is.EqualTo(2));
            Assert.That(price, Is.Not.Null);
            Assert.That(price.UnitPrice, Is.EqualTo(300));
        }
    }
}
