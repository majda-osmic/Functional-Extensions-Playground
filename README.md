## Synopsis
Custom implementation of the Option type in C#.
The basic idea is that code should not "promise" to return data if it is not always able to do so. By using this particular implementation of the Option type, 
the user first has to provide a way to deal with the possibility that there might be no data, after which it can access the actual data (if any). 
Option type is an alternative to returning null, and prevents possible NullReferenceExceptions. 
## Examples
Returning an Option of a string from a method: 
```
IOption<string> AccessData(int key)
{
  if (_data.TryGetValue(key, out var result))
  {
  	return Some<string>.Create(result);
  }
  
  return None<string>.Create();
}
```
Consuming an Option: 
```
string data = AccessData(1).WhenNone("No valid mapping found!").GetValue();

```
or:

```
 AccessData(1).IgnoreNone().OnValidResult(data => Console.WriteLine($"Got some data: {data}"));
```

More detailed samples with further execution paths can be found in the solution itself:
TraditionalDataAccess.cs in the "Examples" project provides a sample with tradional C# data access methods.
OptionDataAccess.cs provides the same logic implemented using Option<T> type. 

## Motivation
This implementation of Option was inspired by Zoran Horvat's [Advanced Defensive Programming Techniques](https://app.pluralsight.com/library/courses/advanced-defensive-programming-techniques/table-of-contents). 
While the Option Type implementation shown in the course relies on the Map / Reduce syntax, this custom 
implementation uses (what I consider to be) a more dev-friendly syntax, and provides a few more execution paths designed based on a large real-life C# project.
