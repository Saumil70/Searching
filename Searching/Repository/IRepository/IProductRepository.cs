



using Searching.Models;

namespace Searching.Repository.IRepository
{
    public interface IProductRepository : IRepository<Products>
    {
       void Update(Products obj);

    }
}
