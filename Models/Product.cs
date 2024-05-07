namespace Models
{
    //dziedziczymy po klasie Entity
    public class Product : Entity
    {

        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime ExpirationDate { get; set; }

        //nadpisujemy metodę ToString z klasy Object w celu zwrócenia własnej reprezentacji obiektu jako string
        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Price}\t{ExpirationDate}";
        }
    }
}