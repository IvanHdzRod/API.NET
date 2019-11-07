using APIConfig.Models;
using APIDataBases.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConfig.Repository.Imp
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ConfigContext _db;
        protected readonly DbSet<T> dbSet;
        public Repository(ConfigContext db)
        {
            this._db = db;
            dbSet = db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public IQueryable<GetAllDatabasesResult> GetAllDatabases()
        {
            return _db.Query<APIDataBases.Models.GetAllDatabasesResult>().FromSql("EXEC GetDatabases");
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
