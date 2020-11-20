using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CSharp9
{

    // TODO: Immutable reference types 

    // 1. What is Immutable types => Not allow to be changed
    // 2. Why use Immutable type
    // 3. How to create Immutable type
    //   3.1 Prior C#6
    //   3.2 C# 6
    //   3.3 Init only
    //   3.4 Record
    //   3.5 positional records
    public class RecordTypes
    {
        // positional records
        public record Person(string FirstName, string LastName);

        //inheritance
        public record Teacher : Person
        {
            public string Subject { get; }

            public Teacher(string first, string last, string sub)
                : base(first, last) => Subject = sub;
        }

        //Add Method
        public record Person2(string FirstName, string LastName)
        {
            public void SayHello() => Console.WriteLine("Hello");
        }


        public void Test()
        {
            //ToString
            var person = new Person("Carl", "Zimmer");
            Console.WriteLine(person.ToString());
            //"Student { LastName = Wagner, FirstName = Bill, Level = 11 }"

            // clone
            var personA = new Person("Nathan", "Risto");
            var personB = personA;


            // Equity
            Console.WriteLine($"personB==personA: {personB == personA}");
            Console.WriteLine($"object.ReferenceEquals(personA, personB): {object.ReferenceEquals(personA, personB)}");


            // With
            var brother = personA with { FirstName = "Nathan" };
            Console.WriteLine(brother.ToString());
            Console.WriteLine($"personB==personA: {brother == personA}");
            Console.WriteLine($"object.ReferenceEquals(personA, brother): {object.ReferenceEquals(personA, brother)}");
            // brother.FirstName = "abc";


            // Deconstruct 
            var (first, last) = brother;
            Console.WriteLine($"First:{first}, Last:{last}");
        }


    }


}
