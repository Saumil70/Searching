using Microsoft.EntityFrameworkCore;
using Searching.Models;
using Searching.Repository;
using Searching.Repository.IRepository;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;




namespace Searching.Repository
{
    public class ProductVariantRepository : Repository<ProductVariantMappings>, IProductVariantRepository
    {
        private DbEntites _db;
        public ProductVariantRepository(DbEntites db) : base(db)
        {
            _db = db;
        }


        public void Update(ProductVariantMappings obj)
        {
            Update(obj);
        }


    }
}
