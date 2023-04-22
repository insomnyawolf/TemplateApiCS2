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
    public abstract partial class CrudAsdController<TController, TEntity> : CrudController<TController, TEntity>
        where TEntity : BaseModel<TEntity>
        where TController : BaseController<TController>
    {
        public CrudAsdController(ILogger<TController> Logger, DatabaseContext DatabaseContext) : base(Logger, DatabaseContext)
        {
        }
    }
}
