using System;
using System.Collections.Generic;
using System.Text;
using static System.String;

namespace CSharp9
{
    //TODO: Target Typing
    public class NewExpression
    {
        List<int> _ids = new();

        public void Func()
        {
            //var person = new Person();
            Person person = new();

            //var person2 = new Person("MyName", 10);
            Person person2 = new ("MyName", 30);

            // As parameter
            SetName(new ());
        }


        public void SetName(Person person) => person.Name = "";

        public class Person
        {
            public Person()
            {

            }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Name { get; set; } = Empty;

            public int Age { get; set; }
        }
    }
}
