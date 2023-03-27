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
    public abstract partial class CrudController<TController, TEntity> : BaseController<TController>
        where TEntity : BaseModel<TEntity>
        where TController : BaseController<TController>
    {
        public DatabaseContext DatabaseContext { get; }

        public CrudController(ILogger<TController> Logger, DatabaseContext DatabaseContext) : base(Logger)
        {
            this.DatabaseContext = DatabaseContext;
        }

        //[HttpGet(nameof(GetExact))]
        //public virtual async Task<IEnumerable<TEntity>> GetExact([FromQuery] TEntity item)
        //{
        //    IQueryable<TEntity> dbSet = DatabaseContext.Set<TEntity>();

        //    var paramType = Expression.Parameter(typeof(TEntity), nameof(TEntity));

        //    var props = item.GetRelevantPropertyInfos();

        //    for (int index = 0; index < props.Length; index++)
        //    {
        //        var prop = props[index];

        //        var value = prop.GetValue(item);

        //        if (value is null)
        //        {
        //            continue;
        //        }
        //        else if (value is string)
        //        {
        //            // Edge Cases...
        //        }
        //        else
        //        {
        //            if ((dynamic)value == 0)
        //            {
        //                continue;
        //            }
        //        }

        //        var filterValue = Expression.Constant(value);

        //        var propValue = Expression.Property(paramType, prop);

        //        var equalityExpression = Expression.Equal(filterValue, propValue);

        //        var expr = Expression.Lambda<Func<TEntity, bool>>(equalityExpression, paramType);

        //        dbSet = dbSet.Where(expr);
        //    }

        //    return dbSet;
        //}

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
