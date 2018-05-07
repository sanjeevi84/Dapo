using Dapo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapo
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository GenericRepository { get; }
        void Commit();
    }
}
