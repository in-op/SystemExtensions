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
The `SystemExtensions.Copying`
namespace was created to facilitate
the implementation of creating
deep copies of your custom types.
Deep copying is the creation of
an instance whose fields contain
the exact same values as some
original instance, but the two
instances share no mutable state.
This can be useful
in a number of situations, including
multithreaded applications. However,
implementing deep copy methods can
be confusing and painful, depending
on the complexity of the objects
you copy. Deep copying is easy
when the state is perfectly immutable,
but tricky when you have objects
within objects and both have mutable state.

The `Copying` namespace supports
`DeepCopy()` extension methods for the
following types:
* T[]
* Dictionary<TKey, TValue>
* HashSet\<T\>
* List\<T\>

It also defines an interface
for producing deep copies
for your custom types:

```c#
public interface ICopyable<T>
{
    T DeepCopy()
}
```

You can implement it like this:

```c#
class Point : ICopyable<Point>
{
    public int x, y;
    public Point(int x, int y) { this.x = x; this.y = y; }
    public Point DeepCopy() { return new Point(x, y); }
}
```

Custom types that implement the `ICopyable`
interface can interop with any of the supported
types' `DeepCopy()` extension methods.
If the supported type's generic type is
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
interface you are safe to deep copy any of
the supported generic types
which use your type as generic type parameters.

It is important to recognize where your
types are mutable and immutable,
and deep copy appropriately.  All the
built-in value types (`bool`, `int`, etc.) are safe to simply
assign directly to the copy.
If you have objects with other objects in their fields,
simply define deep copy methods for the inner objects.
Then when defining `DeepCopy()` for the containing type,
simply assign the copy's field to: `originalObject.DeepCopy()`.
This makes deep copying as simple
as walking through the fields of your object
and assigning data either directly from the original,
when the type is immutable, or directly 
from a `DeepCopy()` invocation, when the type is mutable.

All supported types can also
contain other supported types
as generic type parameters. For example, instances of type
`List<HashSet<Point[]>>` will execute `DeepCopy()`
correctly (please never define anything as that type).

If, however, you make a
`List<MyTypeThatDoesntImplementDeepCopy>` and call the extention method `DeepCopy()` on it,
it will throw a NotImplementedException
at runtime and warn you that your type does not
implement `ICopyable`.


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
* T[]
* Dictionary<TKey, TValue>
* HashSet\<T\>
* List\<T\>
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
