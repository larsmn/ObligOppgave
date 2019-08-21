using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObligOppgave
{
    class Program
    {
        static void Main(string[] args)
        {

            Person kongen = new Person(_firstName: "Harald", _lastName: "N/A", _yearBorn: 1937, _id: 2, _deathYear: 0000);
            Person ingrid = new Person("Ingrid Alexandra", "N/A", 2004, 7, 0000);
            Person olav = new Person("Olav", "N/A", 1903, 1, 1991);
            Person mette = new Person("Mette Marit", "Høiby", 1973, 5, 0000);
            Person marius = new Person("Marius", "Borg Høiby", 1997, 6, 0000);
            Person sverre = new Person("Sverre Magnus", "N/A", 2005, 8, 0000);
            Person sonja = new Person("Sonja", "Haraldsen", 1937, 3, 0000);
            Person haakon = new Person("Haakon Magnus", "N/A", 1973, 4, 0000);

            sverre.father = haakon;
            sverre.mother = mette;
            ingrid.father = haakon;
            ingrid.mother = mette;
            marius.mother = mette;
            haakon.father = kongen;
            haakon.mother = sonja;
            kongen.father = olav;

            var kongefamilien = Kongefamilien(olav, kongen, sonja, haakon, mette, marius, ingrid, sverre);

            Show();
            start:
            Console.WriteLine();
            var answer = Console.ReadLine().ToUpper();
            Console.WriteLine();
            if (answer == "HJELP")
            {
                Console.WriteLine("Liste => Lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert.");
                Console.WriteLine("Id => Viser en bestemt person med mor, far og barn. Eksempel id 5");
            }
            if (answer == "LISTE")
            {
                foreach (var a in kongefamilien)
                {
                    a.Print();
                }
            }
            else if (answer.Contains("ID "))
            {
                var answerId = answer.Substring(3);
                var id = Int32.Parse(answerId);
                var person = FindPerson(id,kongefamilien);
                person.Print();
                foreach (var a in kongefamilien)
                {
                    if (a.father == person || a.mother == person) a.Print();
                }
            }
            goto start;
        }

        private static Person FindPerson(int id, List<Person> kongefamilien)
        {
            for (var i = 0; i < kongefamilien.ToArray().Length; i++)
            {
                var person = kongefamilien[i];
                if (person.id.Equals(id))
                {
                    return person;
                }
            }
            return null;
        }

        private static List<Person> Kongefamilien(Person olav, Person kongen, Person sonja, Person haakon, Person mette, Person marius,
            Person ingrid, Person sverre)
        {
            List<Person> kongefamilien = new List<Person>(8)
            { 
                olav,
                kongen,
                sonja,
                haakon,
                mette,
                marius,
                ingrid,
                sverre
            };
            return kongefamilien;
        }

        private static void Show()
        {
            Console.WriteLine("Velkommen til det kongelige slektstreet!");
            Console.WriteLine("Dette er kommandoene du kan skrive:");
            Console.WriteLine("Hjelp");
            Console.WriteLine("Liste");
            Console.WriteLine("Vis ID");
        }
    }
}
