using System;

namespace CSharpIntermediate.ObjectInitializers
{
    public class Person
    {
        // PROPERTIES
        // Prop - shortcut
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; private set; }

        public Person()
        {
            
        }
        public Person(DateTime birthdate)
        {
            this.Birthdate = birthdate;
        }

        public int Age
        {
            get
            {
                var timeSpan = DateTime.Today - Birthdate;
                var years = timeSpan.Days / 365;
                return years;
            }
        }

        public void Introduce(string toWho)
        {
            Console.WriteLine("Hi {0}, I am {1}",toWho,FirstName);
        }
        public static Person Parse(string name)
        {
            var person = new Person();
            person.FirstName = name;

            return person;
        }

        // private DateTime _birthdate;

        //public void SetBirthDate(DateTime birthdate)
        //{
        //    _birthdate = birthdate;
        //}

        //public DateTime GetBirthDate()
        //{
        //    return _birthdate;
        //}

    }
}