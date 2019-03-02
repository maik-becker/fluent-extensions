# FluentExtensions

Proof-of-concept library for a more fluent-like programming style, mostly by defining extension methods.
It is still work-in-progress, and therefore not published on NuGet (yet).

All examples used in this readme are included in the FluentExtensions.Samples folder.

## Fluent Conditionals

Fluent Conditionals allow you to make concise if-else or ternaries. These just result into expresssion, giving you for instance the ability to stomp simple methods consisting of one if-(else-)block into one or two lines using [expression-bodies](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members).

### "If"-style

This basically it the most classic approach. Since this is not an extension method, you need to (statically) import `FluentConditionals.If` or use the proxy `If._(bool)`

```csharp
using static FluentExtensions.FluentConditionals.FluentConditionals;
```

```csharp
If(_iceCreamService.IsThereAnyLeft())
    .Then(() => Console.WriteLine("There is ice cream left \\o/"))
    .Else(() => _iceCreamService.ScheduleIceCreamOrder());
```

...is equivalent to...

```csharp
var thereIsAnyLeft = _iceCreamService.IsThereAnyLeft();

if (thereIsAnyLeft)
    Console.WriteLine("There is ice cream left \\o/");
else
    _iceCreamService.ScheduleIceCreamOrder();
```

### "If it"-style

With the "if it"-style, you can access the value you use to make your condition in the `Then` and `Else` action. This enables you to avoid having to put that value in a variable, and instead collapsing acquisition and the following if-(else-(block into one expression.
If is an extension method on `object` and therefore is available on every value.

```csharp
_iceCreamService.QueryNextCustomer().Topping
    .If(it => it.HasValue).Then(it => _iceCreamService.AddTopping(it.Value));
```

...is equivalent to...

```csharp
IceCreamTopping? topping = _iceCreamService.QueryNextCustomer().Topping;
if (topping.HasValue)
    _iceCreamService.AddTopping(topping.Value);
```

### Fluent ternaries

Since ternary expressions are already just one expression, this might not shrink your code, but might add to readability. Moreover, fluent ternaries have a consistent look with the other two fluent conditionals. 

```csharp
var order = _iceCreamService.QueryNextCustomer();
return order.Flavor.If(it => it == "Cookie Dough").Then(Discount.Of(10)).Else(Discount.None);
```

...is equivalent to...

```csharp
var order = _iceCreamService.QueryNextCustomer();
return order.Flavor == "Cookie Dough" ? Discount.Of(10) : Discount.None;
```