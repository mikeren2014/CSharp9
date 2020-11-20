using System;

namespace CSharp9
{
    //TODO: Target Typing
    public class ConditionalExpression
    {
        public void Demo()
        {
            var condition = true;

            var student = new Student();

            var cusomer = new Customer();

            //Person result = condition ? cusomer : student;

            //Person test = student ?? cusomer;

            //int? test2 = condition ? 12 : null;
        }

        public class Person
        { 
        
        }

        public class Customer : Person
        { 
        
        }

        public class Student : Person { }
    }
}
