namespace TestIEEE754Compatibility.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long TestLong { get; set; }
        public List<Order> Orders { get; set; }
    }
}
