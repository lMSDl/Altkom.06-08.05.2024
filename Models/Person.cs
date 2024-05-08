using System.Diagnostics;
using System.Xml.Linq;

namespace Models
{
    public class Person : Entity
    {
        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public int? Age => DateTime.Now.Year - BirthDate?.Year;

        public string Bio()
        {
            return $"Imię i nazwisko: {FirstName} {LastName}, wiek: {GetAge()} lat";
        }

        private int GetAge()
        {
            //if (!BirthDate.HasValue)
            if (BirthDate == null)
                    return 0;

            DateTime now = DateTime.Now;
            return now.Year - BirthDate.Value.Year;
        }

        public override string ToString() => $"{Id}\t{FirstName}\t{LastName}\t{GetAge()}"; 
    }
}
