using CheckoutKata;

namespace CheckoutKataTests
{
    public class ItemsTests
    {
        private Items items;

        [SetUp]
        public void Setup()
        {
            items = new Items();
        }

        [Test]
        public void AddOneItem_ListShouldContainOneItem()
        {
            items.AddItem(new Item { Sku = "A", Amount = 10 });

            Assert.That(items.ItemList.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddTwoItems_ListShouldContainTwoItems()
        {
            items.AddItem(new Item { Sku = "A", Amount = 10 });
            items.AddItem(new Item { Sku = "B", Amount = 10 });

            Assert.That(items.ItemList.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddThreeItems_ListShouldContainThreeItems()
        {
            items.AddItem(new Item { Sku = "A", Amount = 10 });
            items.AddItem(new Item { Sku = "B", Amount = 10 });
            items.AddItem(new Item { Sku = "C", Amount = 30 });

            Assert.That(items.ItemList.Count, Is.EqualTo(3));
        }

        [Test]
        public void AddItemWithSameSku_ListShouldAddAmountForTheseItems()
        {
            items.AddItem(new Item { Sku = "A", Amount = 10 });
            items.AddItem(new Item { Sku = "B", Amount = 10 });
            items.AddItem(new Item { Sku = "B", Amount = 30 });

            var item = items.ItemList.FirstOrDefault(i => i.Sku == "B");

            Assert.That(items.ItemList.Count, Is.EqualTo(2));
            Assert.That(item, Is.Not.Null);
            Assert.That(item.Amount, Is.EqualTo(40));
        }

        [Test]
        public void AddMultipleItemsWithSameSku_ListShouldAddAmountForAllTheseItems()
        {
            items.AddItem(new Item { Sku = "A", Amount = 10 });
            items.AddItem(new Item { Sku = "A", Amount = 10 });
            items.AddItem(new Item { Sku = "A", Amount = 30 });

            var item = items.ItemList.FirstOrDefault(i => i.Sku == "A");

            Assert.That(items.ItemList.Count, Is.EqualTo(1));
            Assert.That(item, Is.Not.Null);
            Assert.That(item.Amount, Is.EqualTo(50));
        }
    }
}
