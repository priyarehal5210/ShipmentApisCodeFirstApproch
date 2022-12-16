using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShipingApisWithCodeFirstApprochEF6.Interfaces.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _con;
        internal DbSet<T> _dbset;
        public GenericRepository(ApplicationDbContext conn)
        {
            _con = conn;
            _dbset = _con.Set<T>();
        }
        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public T Get(int id)
        {
            return _dbset.Find(id);
        }

        public ICollection<T> GetAll(string IncludeProperties = null)
        {
            IQueryable<T> query = _dbset;
            if (IncludeProperties != null)
            {
                foreach (var includeprop in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }
        public int Save()
        {
            return _con.SaveChanges();
        }

   
    }
}
