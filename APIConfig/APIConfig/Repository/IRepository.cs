using APIDataBases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConfig.Repository
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        Task AddAsync(T entity);
        void Delete(T entity);
        T Get(int id);
        IQueryable<T> GetAll();
        Task<T> GetAsync(int id);
        void Update(T entity);


        IQueryable<GetAllDatabasesResult> GetAllDatabases();

        
    }
}
