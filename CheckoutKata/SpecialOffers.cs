using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class SpecialOffer
    {
        public string Sku { get; set; }
        public int Amount {  get; set; }
        public int Price {  get; set; }
    }

    public class SpecialOffers
    {
        public IList<SpecialOffer> Offers { get; set; }

        public SpecialOffers()
        {
            Offers = new List<SpecialOffer>();
        }

        public void AddSpecialOffer(SpecialOffer specialOffer)
        {
            var existingSpecialOffer = Offers.FirstOrDefault(s => s.Sku == specialOffer.Sku);

            if (existingSpecialOffer == null)
            {
                Offers.Add(specialOffer);
            }
            else
            {
                existingSpecialOffer.Amount = specialOffer.Amount;
                existingSpecialOffer.Price = specialOffer.Price;
            }
        }
    }
}
