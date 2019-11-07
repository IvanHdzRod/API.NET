using APIDataBases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConfig.Services
{
    public interface IService<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        IQueryable<T> GetAll();
        Task<T> GetAsync(int id);
        Task<T> UpdateAsync(int id, T entity);
        
        //StoredProcedure
        IQueryable<GetAllDatabasesResult> GetAllDatabases();

        //Metodo Creado
        //IQueryable<GetAllDatabasesResult> GetAllD(string DatabaseName);
       
    }
}
