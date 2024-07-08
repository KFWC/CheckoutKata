using CheckoutKata;

namespace CheckoutKataTests
{
    [TestFixture]
    public class CheckoutTests
    {
        private Checkout checkout;

        [SetUp]
        public void Setup()
        {
            checkout = new Checkout();

            checkout.Offers = new SpecialOffers { Offers = { new SpecialOffer { Sku = "A", Amount = 3, Price = 130 }, new SpecialOffer { Sku = "B", Amount = 2, Price = 45 } } };
            checkout.Prices = new PriceList { Prices = { new Price { Sku = "A", UnitPrice = 50 }, new Price { Sku = "B", UnitPrice = 30 }, new Price { Sku = "C", UnitPrice = 20 }, new Price { Sku = "D", UnitPrice = 15 } } };
        }

        [Test]
        public void ScanOneItem_ShouldAddOneItemToTheItemList()
        {
            checkout.Scan("B, 100");

            var item = checkout.Items.ItemList.FirstOrDefault(i => i.Sku == "B");

            Assert.That(checkout.Items.ItemList.Count, Is.EqualTo(1));
            Assert.That(item, Is.Not.Null);
            Assert.That(item.Amount, Is.EqualTo(100));
        }

        [Test]
        public void ScanTwoItems_ShouldAddTwoItemsToTheItemList()
        {
            checkout.Scan("A,300");
            checkout.Scan("B,500");

            var item = checkout.Items.ItemList.FirstOrDefault(i => i.Sku == "B");

            Assert.That(checkout.Items.ItemList.Count, Is.EqualTo(2));
            Assert.That(item, Is.Not.Null);
            Assert.That(item.Amount, Is.EqualTo(500));
        }

        [Test]
        public void ScanOneItemWithExtraSpacing_ShouldAddOneItemToTheItemList()
        {
            checkout.Scan("A        ,            150");

            var item = checkout.Items.ItemList.FirstOrDefault(i => i.Sku == "A");

            Assert.That(checkout.Items.ItemList.Count, Is.EqualTo(1));
            Assert.That(item, Is.Not.Null);
            Assert.That(item.Amount, Is.EqualTo(150));
        }

        [Test]
        public void ScanSpecialPriceItemA_ShouldCalculateTotalPrice()
        {
            checkout.Scan("A, 6");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(260));
        }

        [Test]
        public void ScanMixtureItemA_ShouldCalculateTotalPrice()
        {
            checkout.Scan("A, 8");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(360));
        }

        [Test]
        public void ScanSpecialPriceItemB_ShouldCalculateTotalPrice()
        {
            checkout.Scan("B, 6");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(135));
        }

        [Test]
        public void ScanMixtureItemB_ShouldCalculateTotalPrice()
        {
            checkout.Scan("B, 11");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(255));
        }

        [Test]
        public void ScanItemC_ShouldCalculateTotalPrice()
        {
            checkout.Scan("C, 5");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(100));
        }

        [Test]
        public void ScanItemD_ShouldCalculateTotalPrice()
        {
            checkout.Scan("D, 7");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(105));
        }

        [Test]
        public void ScanMultipleItems_ShouldCalculateTotalPrice()
        {
            checkout.Scan("A, 4");
            checkout.Scan("B, 5");
            checkout.Scan("C, 2");
            checkout.Scan("D, 3");

            Assert.That(checkout.GetTotalPrice(), Is.EqualTo(385));
        }
    }
}
