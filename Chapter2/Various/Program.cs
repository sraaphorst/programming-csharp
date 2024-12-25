// Run with:
// dotnet run --project Chapter2/Various

using Various;

Console.WriteLine("Beginning...");
VariousFuncs.TimeItWithOutput(VariousFuncs.DoSomeWork);
Console.WriteLine("Done!");

// A string is a sequence of values of type char, which does not represent characters due to some being made from
// multiple unicode code points: UTF16 can only represent 65,535 code points, and Unicode 3.1 defines 94,205,
// so anything above 65,535 must occur as a surrogate pair. Thus, approach with caution manipulating char.
// Instead, string offers EnumerateRunes that combines surrogate pairs into Rune.
const string myString = "私はカナダ人です！";
Console.WriteLine($"MyString: {myString}");

// Reversing strings is extremely inconvenient using LINQ.
// var reversed = new string(myString.Reverse().ToArray());
// Console.WriteLine($"MyString reversed: {myString.ReverseString()}");
