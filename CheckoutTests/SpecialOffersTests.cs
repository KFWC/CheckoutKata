using CheckoutKata;

namespace CheckoutTests
{
    [TestFixture]
    public class SpecialOfferTests
    {
        private SpecialOffers offers;

        [SetUp]
        public void Setup()
        {
            offers = new SpecialOffers();
        }

        [Test]
        public void AddSpecialOffer_ListShouldContainOneItem()
        {
            offers.AddSpecialOffer(new SpecialOffer { Sku = "A", Amount = 1, Price = 100 });

            Assert.That(offers.Offers.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddTwoSpecialOffers_ListShouldContainOfTwoItems()
        {
            offers.AddSpecialOffer(new SpecialOffer { Sku = "A", Amount = 1, Price = 100 });
            offers.AddSpecialOffer(new SpecialOffer { Sku = "B", Amount = 5, Price = 500 });

            Assert.That(offers.Offers.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddThreeSpecialOffers_ListShouldContainOfThreeItems()
        {
            offers.AddSpecialOffer(new SpecialOffer {Sku = "A", Amount = 1, Price = 100 });
            offers.AddSpecialOffer(new SpecialOffer {Sku = "B", Amount = 5, Price = 500 });
            offers.AddSpecialOffer(new SpecialOffer {Sku = "C", Amount = 10, Price = 1000 });

            Assert.That(offers.Offers.Count, Is.EqualTo(3));
        }

        [Test]
        public void AddSpecialOffersForTheSameSku_ShouldOverwriteTheDuplicateOfferWithLastest()
        {
            offers.AddSpecialOffer(new SpecialOffer {Sku = "A", Amount = 1, Price = 100 });
            offers.AddSpecialOffer(new SpecialOffer {Sku = "B", Amount = 5, Price = 500 });
            offers.AddSpecialOffer(new SpecialOffer {Sku = "B", Amount = 10, Price = 1000 });

            var offer = offers.Offers.FirstOrDefault(s => s.Sku == "B");

            Assert.That(offers.Offers.Count, Is.EqualTo(2));
            Assert.That(offer, Is.Not.Null);
            Assert.That(offer.Amount, Is.EqualTo(10));
        }
    }
}