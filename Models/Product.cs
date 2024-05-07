namespace Models
{
    public class Product : Entity
    {

        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime ExpirationDate { get; set; }

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Price}\t{ExpirationDate}";
        }
    }
}