using System;
using System.Diagnostics.CodeAnalysis;

namespace CSharp9
{
    public class ModernStyle
    {


        //Use the property pattern to replace IsNullorEmpty
        public static void Test1()
        {
            string? hello = "hello world";
            hello = null;

            // Old approach
            if (!string.IsNullOrEmpty(hello))
            {
                Console.WriteLine($"{hello} has {hello.Length} letters.");
            }

            // New approach, with a property pattern
            if (hello is { Length: > 0 })
            {
                Console.WriteLine($"{hello} has {hello.Length} letters.");
            }
        }

        // For arrays
        public static void Func2()
        {
            // Array Nullable
            string?[]? greetings = new string[2];
            greetings[0] = "Hello world";
            greetings = null;

            // Old approach
            if (greetings != null && !string.IsNullOrEmpty(greetings[0]))
            {
                Console.WriteLine($"{greetings[0]} has {greetings[0]!.Length} letters.");
            }

            // New approach
            if (greetings?[0] is { Length: > 0 } hi)
            {
                Console.WriteLine($"{hi} has {hi.Length} letters.");
            }
        }

        //Simplify checks to multiple constant values
        public static void Func3()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            // Old approach
            if (userInput.KeyChar == 'Y' || userInput.KeyChar == 'y')
            {
                Console.WriteLine("Do something.");
            }

            // New approach with a logical pattern
            if (userInput.KeyChar is 'Y' or 'y')
            {
                Console.WriteLine("Do something.");
            }
        }

    }
}
