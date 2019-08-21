using System;

namespace ObligOppgave
{
    class Person
    {
        public string firstName;
        public string lastName;
        public int yearBorn;
        public int deathYear;
        public int id;
        public Person father;
        public Person mother;

        public Person(string _firstName, string _lastName, int _yearBorn, int _id, int _deathYear = default, Person _father = null,
            Person _mother = null)
        {
            firstName = _firstName;
            lastName = _lastName;
            yearBorn = _yearBorn;
            deathYear = _deathYear;
            id = _id;
            father = _father;
            mother = _mother;
        }



        public void Print()
        {
            Console.WriteLine("Navn: " + firstName);
            Console.WriteLine("Etternavn: " + lastName);
            Console.WriteLine("Fødselsår: " + yearBorn);
            if (deathYear != default) Console.WriteLine("Dødsår: " + deathYear);
            Console.WriteLine("Id: " + id);
            Console.WriteLine();
            if (father != null)
            {
                Console.WriteLine("Far: " + father.firstName + " ID: " + father.id);
            }
            if (mother != null)
            {
                Console.WriteLine("Mor: " + mother.firstName + " ID: " + mother.id);
            }
            Console.WriteLine();
        }
    }
}