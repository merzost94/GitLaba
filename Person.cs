using System;

namespace FullTeamWork1
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public Person() : this("Неизвестно", "Неизвестно", DateTime.MinValue)
        {
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, Родился: {BirthDate.ToShortDateString()}";
        }

        public virtual string ToShortString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
