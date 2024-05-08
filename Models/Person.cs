using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Models
{
    public class Person : Entity
    {
        public Person() { }

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        [XmlIgnore]
        [JsonIgnore]
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
