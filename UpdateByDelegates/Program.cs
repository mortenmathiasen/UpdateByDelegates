using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleLINQ
{
    public class Person
    {
        public Person(string name, int score, int age)
        {
            Name = name;
            Score = score;
            Age = age;
            Accepted = false;
        }
        public string Name { get; set; }
        public int Score { get; private set; }
        public int Age { get; private set; }
        public bool Accepted { get; set; }

        public override string ToString()
        {
            return $"Name={Name}, Score={Score}, Age={Age}, Accepted={Accepted}";
        }
    }

    public static class Extension
    {
        public static void UpdatePeople(this List<Person> list, Predicate<Person> predicate, Action<Person> action)
        {
            foreach (Person p in list)
                if (predicate(p))
                    action(p);
        }
    }

    class Program
    {
        private static void Main()
        {
            List<Person> people = GetPeople();

            Console.WriteLine("Initial people list:");
            print(people);

            people.UpdatePeople(p => p.Score >= 6 && p.Age <= 40, (p) => { p.Accepted = true; });

            Console.WriteLine("Updated people list:");
            print(people);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void print(List<Person> peoplelist)
        {
            foreach (Person p in peoplelist)
                Console.WriteLine(p);
        }

        private static List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person("Morten", 9, 20));
            people.Add(new Person("Ib", 2, 35));
            people.Add(new Person("Pia", 11, 88));
            people.Add(new Person("Per", 13, 32));
            return people;
        }
    }
}
