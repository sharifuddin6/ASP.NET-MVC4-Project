using Project.Domain.Repositories;

namespace Project.Infrastructure.Repositories
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public float Value { get; set; }
    }
}
