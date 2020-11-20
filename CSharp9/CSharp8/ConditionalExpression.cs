using System;

namespace CSharp8
{
    public class ConditionalExpression
    {
        public void Demo()
        {
            var flag = true;

            var student = new Student();

            var cusomer = new Customer();

            //var result = flag ? cusomer : student;

            //var test = student ?? cusomer;

            //var test2 = flag ? 0 : null;
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
