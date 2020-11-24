using static System.Console;
using System.Linq;
using System;
using static Newtonsoft.Json.JsonConvert;
using AutoMapper;

namespace CSharp9
{
    public record PersonRecord(string Name, int Age);

    public class PersonClass
    {
        public string Name { get; init; }

        public int Age { get; init; }

        public PersonClass(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class RecordTester
    {
        const string name = "Mike";
        const int age = 20;

        public void Demo()
        {
            PersonRecord personRecord1 = new(name, age);
            var personRecord2 = new PersonRecord(name, age);
            PersonClass personClass1 = new(name, age);
            var personClass2 = new PersonClass(name, age);

            Object.ReferenceEquals(personRecord1, personRecord2);

            WriteLine($"Test record equality -- personRecord1 == personRecord2 : {personRecord1 == personRecord2}");
            WriteLine($"Test record equality -- personClass1 == personClass2 : {personClass1 == personClass2}");
            WriteLine();

            WriteLine($"Object.ReferenceEquals(personRecord1, personRecord2) : {Object.ReferenceEquals(personRecord1, personRecord2)}");
            WriteLine($"Object.ReferenceEquals(personClass1, personClass2) : {Object.ReferenceEquals(personClass1, personClass2)}");
            WriteLine();

            WriteLine($"Print personRecord1 hash code -- personRecord1.GetHashCode(): {personRecord1.GetHashCode()}");
            WriteLine($"Print personRecord2 hash code -- personRecord2.GetHashCode(): {personRecord2.GetHashCode()}");
            WriteLine();

            WriteLine($"Print personClass1 hash code -- personClass1.GetHashCode(): {personClass1.GetHashCode()}");
            WriteLine($"Print personClass2 hash code -- personClass2.GetHashCode(): {personClass2.GetHashCode()}");
            WriteLine();

            WriteLine($"{nameof(PersonRecord)} implements IEquatable<T>: {personRecord1 is IEquatable<PersonRecord>} ");
            WriteLine($"{nameof(PersonClass)}  implements IEquatable<T>: {personClass1 is IEquatable<PersonClass>}");
            WriteLine();

            WriteLine($"Print {nameof(PersonRecord)}.ToString -- personRecord1.ToString(): {personRecord1.ToString()}");
            WriteLine($"Print {nameof(PersonClass)}.ToString  -- personClass1.ToString(): {personClass1.ToString()}");
            WriteLine();
        }

        public void Demo_With()
        {
            PersonRecord personRecord1 = new(name, age);
            var personRecord2 = personRecord1 with { Name = "Nate" };

            WriteLine($"Print {nameof(PersonRecord)}.ToString -- personRecord1.ToString(): {personRecord1.ToString()}");
            WriteLine($"Print {nameof(PersonRecord)}.ToString -- personRecord1.ToString(): {personRecord2.ToString()}");
            WriteLine($"Test record equality -- personRecord1 == personRecord2 : {personRecord1 == personRecord2}");
            WriteLine($"Object.ReferenceEquals(personRecord1, personRecord2) : {Object.ReferenceEquals(personRecord1, personRecord2)}");
        }

        public void Demo_Deconstruct()
        {
            PersonRecord personRecord1 = new(name, age);
            var (name1, age1) = personRecord1;
            WriteLine($"Name: {name1} Age: {age1}");
        }

        public void Demo_WorkWith_Newtonsoft()
        {
            PersonRecord personRecord1 = new(name, age);

            var personRecordJson = SerializeObject(personRecord1);
            var personRecordObj = DeserializeObject<PersonRecord>(personRecordJson);
            var personClassObj = DeserializeObject<PersonClass>(personRecordJson);

            WriteLine($"SerializeObject(personRecord1): {personRecordJson}");
            WriteLine($"DeserializeObject<PersonRecord>(personJson): {personRecordObj}");
            WriteLine($"DeserializeObject<PersonRecord>(personJson): {personClassObj}");

        }

        public void Demo_Workwith_AutoMapper()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<PersonRecord, PersonClass>().ReverseMap());

            configuration.AssertConfigurationIsValid();

            var mapper = configuration.CreateMapper();

            PersonRecord personRecord1 = new(name, age);

            var dest = mapper.Map<PersonClass>(personRecord1);
            var dest2 = mapper.Map<PersonRecord>(dest);

            WriteLine(dest2);

        }
    }

}