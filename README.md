# Summary
A class library of interfaces and 
extension-methods that round out
the basic System libraries to fill
unnecessary holes

# API
### Jagged Array
The `JaggedArray` class provides
static methods for initializing
1D-5D arrays with initial items.
Arrays can be initialized
with a given value type instance, 
new instances of a class,
or the return value of a `Func<T>`.
The examples given below are for
2D arrays, but be aware they
are overloaded for anywhere
from 1-5 dimensions.
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
If T is an object type, each element
is initialized to a new instance
of T using the default constructor.
```c#
JaggedArray.Create<T>(int x, int y, Func<T> func)
```
Returns a 2D array where the outer
array is of length x, and each inner
array is of length y.
Each element is initialized by
invoking the `func`.

### Copying
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
`ICopyable` that the generic type T
is set to the type itself (like
`IEquatable`).

Custom types that implement the `ICopyable`
interface can interop with the 
collections' `DeepCopy()` methods.
If the collection's generic type is
your custom type, it will safely execute
`DeepCopy()`. If however you make a
`List<MyTypeThatDoesntImplementDeepCopy>`,
it will throw a NotImplementedException
and warn you that your type does not
include a definition for `DeepCopy`.

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
