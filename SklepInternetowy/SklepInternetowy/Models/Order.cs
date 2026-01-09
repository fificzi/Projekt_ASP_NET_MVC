namespace SklepInternetowy.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public required string UserId { get; set; }

        public decimal TotalPrice { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
