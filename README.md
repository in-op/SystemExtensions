# Summary
A class library of interfaces and 
extension-methods that round out
the basic System libraries to fill
unnecessary holes

# API
### Jagged Array
The `JaggedArray` class was created to easily
initialize jagged arrays (arrays of arrays) of multiple
dimensions (not to be confused with multidimensional arrays).
Jagged arrays are generally faster to access
than multidimensional arrays, but initializing jagged arrays
is a cumbersome process in the normal language compared
with multidimensional arrays.

This class contains one overloaded method,
`JaggedArray.Create`.
All overloads allow you to generate
jagged arrays with specified lengths
for arrays at each dimension.

```c#
T[][][] JaggedArray.Create<T>(
    int length1D,
    int length2D,
    int length3D)
```

Generating
arrays like this initializes each element
to the default value.
An initial value can also
be specified explicitly, either directly as an argument
(only if it's a value type):

```c#
T[][][] JaggedArray.Create<T>(
    int length1D,
    int length2D,
    int length3D
    T val)
    where T : struct
```

or indirectly as the
return value of a func argument:

```c#
T[][][] JaggedArray.Create<T>(
    int length1D,
    int length2D,
    int length3D
    Func<T> func)
```

This allows the
flexibility to construct objects, set random
numbers, or do whatever you'd like in your array
elements during initialization.
Jagged arrays between
one and five dimensions, T[] to T[][][][][],
are currently supported. Note
that all arrays in each dimension
must be the same length. This means
you can't have a jagged array like this:

```c#
int[][] array = new int[3][] 
{
    new int[1] { 42 },
    new int[3] { 100, 101, 102 },
    new int[2] { 56, -15 }
}
```

where the lengths of inner arrays differ.
Sometimes this is useful, such as when storing
large amounts of data. Support is given for specifying
individual lengths for whatever is the final dimension
of the array:

```c#
T[][][] JaggedArray.Create<T>(
    int length1D,
    int length2D,
    int[] lengths3D)
```

If you require jagged arrays with varying lengths
in multiple dimensions, the content is probably
complex enough to warrant manual initialization.

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
