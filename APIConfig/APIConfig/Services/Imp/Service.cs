using APIConfig.Models;
using APIConfig.Repository;
using APIConfig.UnitOfWork;
using APIDataBases.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIConfig.Services
{

    public class Service<T> : IService<T> where T : class
    {
        protected readonly IRepository<T> _repository;
        protected readonly IUnitOfWork _unitOfWork;
 
        public Service(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = _repository.Get(id);
            _repository.Delete(entity);
            await _unitOfWork.SaveAsync();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }
       

        public IQueryable<GetAllDatabasesResult> GetAllDatabases()
        {
            return _repository.GetAllDatabases();

        }

        public virtual async Task<T> GetAsync(int id)
        {
            var entity = _repository.Get(id);
            return entity;
        }

        public virtual async Task<T> UpdateAsync(int id, T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.SaveAsync();
            return entity;
        }
    }
}
