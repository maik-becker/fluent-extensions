using System;
using static FluentExtensions.FluentConditionals.FluentConditionals;

namespace FluentExtensions.Samples
{
    class IfStyleSample
    {
        private readonly IceCreamService _iceCreamService = new IceCreamService();

        void IfSyntax()
        {
            var thereIsAnyLeft = _iceCreamService.IsThereAnyLeft();

            if (thereIsAnyLeft)
                Console.WriteLine("There is ice cream left \\o/");
            else
                _iceCreamService.ScheduleIceCreamOrder();
        }

        void FluentIfSyntax()
        {
            If(_iceCreamService.IsThereAnyLeft())
                .Then(() => Console.WriteLine("There is ice cream left \\o/"))
                .Else(() => _iceCreamService.ScheduleIceCreamOrder());
        }
    }
}