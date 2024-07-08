using System;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public SpecialOffers Offers {  get; set; }
        public PriceList Prices { get; set; }
        public Items Items { get; set; }

        public Checkout()
        {
            Offers = new SpecialOffers();
            Prices = new PriceList();
            Items = new Items();
        }

        public int GetTotalPrice()
        {
            var totalPrice = 0;

            foreach(var item in Items.ItemList)
            {
                var specialOffer = Offers.Offers.FirstOrDefault(s => s.Sku == item.Sku);
                if (specialOffer != null)
                {
                    totalPrice += (specialOffer.Price * (item.Amount / specialOffer.Amount));
                    item.Amount -= (specialOffer.Amount * (item.Amount / specialOffer.Amount));
                }

                if (item.Amount > 0)
                {
                    var price = Prices.Prices.FirstOrDefault(p => p.Sku == item.Sku);
                    if (price != null)
                    {
                        totalPrice += (price.UnitPrice * item.Amount);
                    }
                }
            }
            return totalPrice;
        }

        public void Scan(string item)
        {
            var commaIndex = item.IndexOf(',');
            if (commaIndex > 0)
            {
                var scannedItem = new Item();
                scannedItem.Sku = item.Substring(0, commaIndex).Trim();
                scannedItem.Amount = int.Parse(item.Substring(commaIndex + 1, item.Length - (commaIndex + 1)).Trim()); 
            
                Items.AddItem(scannedItem);
            }
        }
    }
}
