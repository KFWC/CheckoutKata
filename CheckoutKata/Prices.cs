using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Price
    {
        public string Sku {  get; set; }
        public int UnitPrice { get; set; }
    }

    public class PriceList : List<Price> 
    {
        public IList<Price> Prices {  get; set; }

        public PriceList()
        {
            Prices = new List<Price>();
        }

        public void AddPrice(Price price)
        {
            var existingPrice = Prices.FirstOrDefault(p => p.Sku == price.Sku);

            if (existingPrice == null)
            {
                Prices.Add(price);
            }
            else
            {
                existingPrice.UnitPrice = price.UnitPrice;
            }
        }
    }
}
