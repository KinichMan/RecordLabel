using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecordLabel.src.Shared.Infrastructure.Persistence.Context;

namespace RecordLabel.src.Shared.Infrastructure.Persistence.Repository
{
    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ELearningContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly IServiceScopeFactory ScopeFactory;

        public EntityFrameworkRepository(ELearningContext context, IServiceScopeFactory scopeFactory)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
            ScopeFactory = scopeFactory;
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            //Db.Dispose();
            //GC.SuppressFinalize(this);
        }

        public virtual void Save(TEntity obj)
        {
            using (var scope = ScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ELearningContext>();
                dbContext.Add(obj);
                dbContext.SaveChanges();
            }
        }
    }
}
