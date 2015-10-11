using Project.Domain.Repositories;

namespace Project.Infrastructure.Repositories
{
    public class Order : IOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public float Value { get; set; }
        public float Total { get; set; }
    }
}
