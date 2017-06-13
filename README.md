# Summary
A class library of interfaces and 
extension-methods that round out
the basic System libraries to fill
unnecessary holes

# API
### Jagged Array
The `JaggedArray` class provides
static methods for initializing
1D-5D arrays with various
initial items. Arrays can be initialized
with a given value type instance, 
new instances of a class,
or the return value of a `Func<T>`.
Principle examples are given below.
2D arrays are used in the examples
for simplicity, but know that they
are principally the same for an 
array of any supported dimensional size.
```c#
JaggedArray.Create<T>(int x, int y)
```
Returns a 2D array of lengths x, y.
Each element is initialized to T's
default value.
```c#
JaggedArray.Create<T>(int x, int y, T val)
```
Returns a 2D array of lengths x, y.
If T is a value type, each element
is initialized to the input val. 
If T is an object type, each element
is initialized to a new instance
of T using the default constructor.
```c#
JaggedArray.Create<T>(int x, int y, Func<T> func)
```
Returns a 2D array of lengths x, y.
Each element is initialized to
the return value of `func`.

### Copying
The `Copying` namespace defines
extension methods for copying
collections items, and an interface
for producing deep copies.
```c#
public interface ICopyable<T>
{
    T DeepCopy()
}
```
Interface for making deep copies
of an instance. Each supported
collection defines an extension
method with the same name and
signature. Supported collections:
* Array
* Dictionary
* HashSet
* List<T>

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
