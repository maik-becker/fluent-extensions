using FluentExtensions.FluentConditionals;

namespace FluentExtensions.Samples
{
    public class TernarySample
    {
        private readonly IceCreamService _iceCreamService = new IceCreamService();

        Discount TernaryBefore()
        {
            var order = _iceCreamService.QueryNextCustomer();
            return order.Flavor == "Cookie Dough" ? Discount.Of(10) : Discount.None;
        }

        Discount FluentTernary()
        {
            var order = _iceCreamService.QueryNextCustomer();
            return order.Flavor.If(it => it == "Cookie Dough").Then(Discount.Of(10)).Else(Discount.None);
        }
    }
}