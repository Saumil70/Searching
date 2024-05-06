

namespace Searching.Repository.IRepository
{
    public interface IUnitOfWork
    {


         IProductRepository ProductRepository { get; }

        IProductVariantRepository ProductVariantRepository { get; }

        void Save();
    }
}
