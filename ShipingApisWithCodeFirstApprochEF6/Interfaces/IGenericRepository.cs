using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShipingApisWithCodeFirstApprochEF6.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
    
        void Add(T entity);     //add
        void Remove(T entity);  //delete
        void Update(T entity);  //update
        T Get(int id);   //find
        ICollection<T> GetAll(             //display
        string IncludeProperties = null
        );
        int Save();   //save
    }
}
