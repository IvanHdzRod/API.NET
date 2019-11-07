using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConfig.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        void Save();
        Task SaveAsync();

    }
}
