



using Searching.Models;

namespace Searching.Repository.IRepository
{
    public interface IProductVariantRepository : IRepository<ProductVariantMappings>
    {
       void Update(ProductVariantMappings obj);

    }
}
