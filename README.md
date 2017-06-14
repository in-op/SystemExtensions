# Summary
A class library of interfaces and 
extension-methods that round out
the basic System libraries to fill
unnecessary holes

# API
### Jagged Array
The `JaggedArray` class provides
static methods for initializing
arrays of one to five dimensions with initial items.
Arrays can be initialized
with either a given value type instance, 
a new instances of a class,
or the return value of a `Func<T>`.
Examples are given with
2D arrays, but be aware they
are overloaded to support arrays
of one to five dimensions.
```c#
JaggedArray.Create<T>(int x, int y)
```
Returns a 2D array where the outer
array is of length x, and each inner
array is of length y.
Each element is initialized to T's
default value.
```c#
JaggedArray.Create<T>(int x, int y, T val)
```
Returns a 2D array where the outer
array is of length x, and each inner
array is of length y.
If T is a value type, each element
is initialized to the input val (all value types should be immutable!). 
If T is a reference type, each element
is initialized to a new instance
of T using the types default constructor.
```c#
JaggedArray.Create<T>(int x, int y, Func<T> func)
```
Returns a 2D array where the outer
array is of length x, and each inner
array is of length y.
Each element is initialized by
invoking the `func` delegate
and assigning it to the return value.

### Copying
Deep copying is the creation of
a completely new copy of any one instance,
which shares no mutable state with
the original. This can be useful
in a number of situations, including
multithreaded applications.

The `Copying` namespace defines
`DeepCopy()` extension methods for the
following collections:
* T[]
* Dictionary<TKey, TValue>
* HashSet<T>
* List<T>

It also defines an interface
for producing deep copies
for your own types:

```c#
public interface ICopyable<T>
{
    T DeepCopy()
}
```

Make sure when your types implement
`ICopyable<T>` that the generic type `T`
is set to the type itself (like
`IEquatable<T>`). For example:

```c#
class Point : ICopyable<Point>
{
    public int x, y;
    public Point(int x, int y) { this.x = x; this.y = y; }
    public Point DeepCopy() { return new Point(x, y); }
}
```

Custom types that implement the `ICopyable`
interface can interop with the 
collections' `DeepCopy()` methods.
If the collection's generic type is
your custom type, it will safely execute
`DeepCopy()`. For example:

```c#
static void main(string[] args)
{
    List<Point> list = new List<Point>(3)
    {
        new Point(1, 2),
        new Point(10, 42),
        new Point(-3, 6)
    }
    
    List<Point> copy = list.DeepCopy();
}
```
This code compiles and does not throw any errors.
As long as your type implements the `ICopyable<T>`
interface you are safe to deep copy collections
which use your type as generic type parameters.
This copy shares no state with the original,
and each can be read from and written to independently.

All supported collections can also
contain other supported collections
as generic type parameters. For example, instances of type
`List<List<int[]>>` will execute `DeepCopy()`
correctly.

If however you make a
`List<MyTypeThatDoesntImplementDeepCopy>` and call the extention method `DeepCopy()` on it,
it will throw a NotImplementedException
and warn you that your type does not
include a definition for `DeepCopy`.

You do not technically need to implement `ICopyable<T>`
to safely interop with the collections' `DeepCopy()` extension methods.
All they require is that your class definition supply a parameterless
instance method `DeepCopy()` that
returns an instance of the same type.
However, you are encouraged to implement
the interface for clarity and for
interop with other, stricter code which
may require the interface implementation.
This laxity is an artefact of the library design,
which empowers the collections' extension
methods to call eachother.

### Random
The `Random` namespace provides
extension methods for retrieving
random items out of collections,
for creating a random Int64 long
value from a Random instance, and
generating thread-safe Random
instances.
```c#
T RandomItem<T>(this List<T> list, System.Random rng)
```
The principle method for retrieving
a random item from the collection.
All collections supporting
this extension method:
* Array
* Dictionary
* HashSet
* List<T>
```c#
long NextInt64(this System.Random rng)
```
Returns a random Int64 long value
from the calling Random instance.
```c#
Random ThreadLocalRandom.NewRandom()
```
Returns a new Random instance whos
seed is derived from a locked, global
Random instance, rather than time. 
This us useful when you need to generate
thread-local Random instances, and are
running into the problem where
they all have similar seed values.
