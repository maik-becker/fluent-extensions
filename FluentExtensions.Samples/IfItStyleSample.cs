using FluentExtensions.FluentConditionals;

namespace FluentExtensions.Samples
{
    class IfItStyleSample
    {
        private readonly IceCreamService _iceCreamService = new IceCreamService();


        void IfItSyntaxBefore()
        {
            var order = _iceCreamService.QueryNextCustomer();
            IceCreamTopping? topping = order.Topping;

            if (topping.HasValue)
                _iceCreamService.AddTopping(topping.Value);
        }

        void IfItFluentSyntax()
        {
            var order = _iceCreamService.QueryNextCustomer();
            order.Topping.If(it => it.HasValue).Then(it => _iceCreamService.AddTopping(it.Value));
        }
    }
}