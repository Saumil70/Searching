using Microsoft.EntityFrameworkCore;
using Searching.Models;
using Searching.Repository;
using Searching.Repository.IRepository;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;




namespace Searching.Repository
{
    public class ProductRepository : Repository<Products>, IProductRepository
    {
        private DbEntites _db;
        public ProductRepository(DbEntites db) : base(db)
        {
            _db = db;
        }


        public void Update(Products obj)
        {
            Update(obj);
        }


    }
}
