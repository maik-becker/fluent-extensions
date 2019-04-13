# FluentExtensions

Proof-of-concept library for a more fluent-like programming style, mostly by defining extension methods.
It is still work-in-progress, and therefore not published on NuGet (yet).

Examples used in this readme are included in the FluentExtensions.Samples folder, alternative you can look at the included UnitTests.

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


## Enumerables

### .ForEach

.ForEach behaves like a conventional `foreach` loop, but is more concise in most cases.

```csharp
new List<String> {"  First ", " Second  "}
    .Select(s => s.Trim())
    .ForEach(Console.WriteLine);
```

### .Peek

.Peek allows you to do something for every element, like .ForEach, but returns the Enumerable itself, meaning you can just insert it anywhere within your LINQ-chain. 
Typical usecases for this are debug or logging output.  

```csharp
var first = new List<String> {"  First ", " Second  "}
    .Peek(Console.WriteLine)
    .Select(s => s.Trim())
    .First();
```

## Strings

### .IsContainedBy

```csharp
string containing = "Hello";
string substring = "ell";
var isContainedBy = substring.IsContainedBy(containing); // true
```


```csharp
string containing = "Hello";
string substring = "ELL";
var isContainedBy = substring.IsContainedBy(containg, StringComparison.CurrentCultureIgnoreCase); // true
```

### .IsNullOrEmpty

```csharp
string it = null;
var isNullOrEmpty = it.IsNullOrEmpty(); // true
```

```csharp
string it = "";
var isNullOrEmpty = it.IsNullOrEmpty(); // true
```

### .IsNullOrWhitespace

```csharp
string it = null;
var isNullOrWhitespace = it.IsNullOrWhitespace(); // true
```

```csharp
string it = "";
var isNullOrWhitespace = it.IsNullOrWhitespace(); // true
```


```csharp
string it = " ";
var isNullOrWhitespace = it.IsNullOrWhitespace(); // true
```

## Numbers

### Abs

```csharp
var abs = (-3.4).Abs(); // 3.4
```

### Clamp

```csharp
var clamped = 8.Clamp(11, 20); // 11
var clamped = 11.Clamp(0, 10); // 10
var clamped = 6.Clamp(0, 10); // 6
```

### IsApproximately

```csharp
var isApproximately = 4.1.IsApproximately(4.1000001); // true
```

### Floor/Ceil/Round

```csharp
int floor = 3.54.Floor(); // 3
int ceil = 3.01.Ceil(); // 4
int round = 3.5.Round(); // 4
```