using System;

namespace Application
{
    public abstract class Discount
    {
        public DiscountBasedOn DiscountType { get; set; } 

    }
    public abstract class FixedPriceDiscount: Discount
    {
        public decimal Price { get; set; }
    }
    public abstract class PercentualDiscount : Discount
    {
        public decimal Percentage { get; set; }
    }
}
