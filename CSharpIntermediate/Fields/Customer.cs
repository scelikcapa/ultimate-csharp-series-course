using System.Collections.Generic;

namespace CSharpIntermediate.Fields
{
    public class Customer
    {
        public int Id;
        public string Name;
        // INITIALIZING PLACE AND READONLY MODIFIER
        // Some programmers says that if you don't get params from outside of the class
        // you should not initialize the fields in the Contructors.
        // therefore, initialize List directly in class
        public readonly List<Order> Orders=new List<Order>();
        

        public Customer()
        {
            // Some fields has to be initializing while the class is created.
            // That's why Constructor important
            // If class has a list of object, make sure that list is always initialized.

            Id = 0;
            Name = "";
            // Orders = new List<Order>();
        }

        public Customer(int id)
            : this()
        {
            this.Id = id;
        }

        public Customer(int id, string name)
            : this(id)
        {
            this.Name = name;
        }

        public void Promote()
        {
            // READONLY FIELDS CAN NOT BE RE-INITIALIZE
            // Orders = new List<Order>();
        }
    }
}