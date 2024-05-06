namespace ConsoleApp.Models
{
    internal class Person
    {
        public Person() { }

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //read-only = brak settera - można ustawić w kostruktorze, ale pożniej nie można zmienić
        public DateTime? BirthDate { get; }

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
    }
}
