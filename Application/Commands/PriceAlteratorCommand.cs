using Domain.Entities;
namespace Application.Commands
{
    public class PriceAlteratorCommand : Command<decimal>
    {
        private PriceAlterator PriceAlterator { get; set; }
        private decimal Price { get; set; }
        public PriceAlteratorCommand(PriceAlterator PriceAlterator, decimal Price)
        {
            this.PriceAlterator = PriceAlterator;
            this.Price = Price;
        }
        public override decimal Execute()
        {
            if(PriceAlterator.IsDiscount)
            {
                return Price -= (Price * PriceAlterator.Percentage / 100);
            }
            return Price += (Price * PriceAlterator.Percentage / 100);
        }
    }
}
