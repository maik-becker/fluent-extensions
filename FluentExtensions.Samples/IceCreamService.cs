using System;
using System.Threading;

namespace FluentExtensions.Samples
{
    internal class IceCreamService
    {
        public bool IsThereAnyLeft()
        {
            return false;
        }

        public void ScheduleIceCreamOrder()
        {
            Console.WriteLine("Ordering new ice cream...");
            Thread.Sleep(TimeSpan.FromSeconds(.25));
            Console.WriteLine("New ice cream ordered!");
        }

        public CustomerOrder QueryNextCustomer()
        {
            return new CustomerOrder(IceCreamTopping.ChocolateFlakes, "Hazelnut");
        }

        public void AddTopping(IceCreamTopping topping)
        {
            Console.WriteLine($"Topping {topping} added!");
        }
    }

    internal enum IceCreamTopping
    {
        ChocolateFlakes,
        VanillaSauce
    }

    internal class CustomerOrder
    {
        private readonly String _flavor;
        private readonly IceCreamTopping? _topping;

        public CustomerOrder(IceCreamTopping? topping, string flavor)
        {
            _topping = topping;
            _flavor = flavor;
        }

        public IceCreamTopping? Topping => _topping;
        public String Flavor => _flavor;
    }

    internal class Discount
    {
        public static Discount Of(int percentage) => new Discount(percentage);
        public static Discount None = new Discount(0);

        private Discount(int percentage)
        {
        }
    }
}