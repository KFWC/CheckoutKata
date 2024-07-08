using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Item
    {
        public string Sku { get; set; }
        public int Amount {  get; set; }
    }

    public class Items
    {
        public IList<Item> ItemList { get; set; }

        public Items()
        {
            ItemList = new List<Item>();
        }

        public void AddItem(Item item)
        {
            var existingItem = ItemList.FirstOrDefault(i => i.Sku == item.Sku);

            if (existingItem == null)
            {
                ItemList.Add(item);
            }
            else
            {
                existingItem.Amount += item.Amount;
            }
        }
    }
}
