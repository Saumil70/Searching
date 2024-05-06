
using Microsoft.AspNetCore.Identity;
using Searching.Models;
using Searching.Repository;
using Searching.Repository.IRepository;





namespace User_UserApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbEntites _db;
        public IProductRepository ProductRepository { get; private set; }

        public IProductVariantRepository ProductVariantRepository { get; private set; } 


        public UnitOfWork(DbEntites db)
        {
            _db = db;
            ProductRepository = new ProductRepository(_db);
            ProductVariantRepository = new ProductVariantRepository(_db);   
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
