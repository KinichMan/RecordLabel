

using System;

namespace RecordLabel.src.Shared.Infrastructure.Persistence.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
    }
}
