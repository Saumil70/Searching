using Microsoft.EntityFrameworkCore;
using Searching.Models;
using System.Linq.Expressions;



namespace Searching.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbEntites _db;
        
        internal DbSet<T> dbSet;

        public Repository(DbEntites db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            
            var products = _db.Products.Include(u => u.Categories).ToList();

            foreach (var product in products)
            {
                _db.Entry(product)
                    .Collection(s => s.ProductVariantMappings)
                    .Query().Include(sh => sh.Variants).Load();
            }

            _db.ProductVariantMappings.Include(u => u.Products).Include(u => u.Variants);

        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;

            if (tracked)
            {

                query = dbSet;

            }
            else
            {
                query = dbSet.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
