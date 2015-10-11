namespace Project.Domain.Repositories
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        string Code { get; set; }
        float Value { get; set; }
    }
}
