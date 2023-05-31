using assignment.data.Models.Domain;
namespace assignment.data.Repository
{
    public interface IProductRepository
    {
        Task<bool> AddAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<Product?> GetByIdAsync(int id);

        Task<IEnumerable<Product>> GetAllAsync();
    }
}