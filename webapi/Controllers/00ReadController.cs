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
    public abstract partial class ReadController<TController, TEntity> : BaseController<TController>
        where TEntity : BaseModel<TEntity>
        where TController : BaseController<TController>
    {
        public DatabaseContext DatabaseContext { get; }

        public ReadController(ILogger<TController> Logger, DatabaseContext DatabaseContext) : base(Logger)
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
    }
}
