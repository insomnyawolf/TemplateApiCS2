using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using webapi.Database;

namespace webapi.Controllers
{
    /// <summary>
    /// Yes, CUD controller instead of crud because i didn't find a way to automate the query (yet)
    /// 
    /// Nevermind it does already provide a base crud for any database entity that extends from the BaseModel
    /// </summary>
    public abstract partial class CrudController<TController, TEntity> : ReadController<TController, TEntity>
        where TEntity : BaseModel<TEntity>
        where TController : BaseController<TController>
    {
        public CrudController(ILogger<TController> Logger, DatabaseContext DatabaseContext) : base(Logger, DatabaseContext)
        {
        }

        [HttpPost]
        public virtual async Task<long> Post(TEntity item)
        {
            // Prevent Id Tampering
            item.Id = 0;

            var dbSet = DatabaseContext.Set<TEntity>();

            var entity = await dbSet.AddAsync(item);

            await DatabaseContext.SaveChangesAsync();

            return entity.Entity.Id;
        }

        [HttpPut]
        public virtual async Task<long> Put(TEntity item)
        {
            var dbSet = DatabaseContext.Set<TEntity>();

            var entity = await dbSet.FindAsync(item.Id);

            entity.UpdateValuesFrom(item);

            await DatabaseContext.SaveChangesAsync();

            return entity.Id;
        }

        [HttpDelete]
        public virtual async Task<TEntity> Delete(long itemId)
        {
            var dbSet = DatabaseContext.Set<TEntity>();

            var entity = await dbSet.FindAsync(itemId);

            dbSet.Remove(entity);

            await DatabaseContext.SaveChangesAsync();

            return entity;
        }
    }
}
