using webapi.Database;

namespace webapi.Controllers
{
    public abstract class BaseController<TController> where TController : BaseController<TController>
    {
        protected readonly ILogger<TController> Logger;
        public DatabaseContext DatabaseContext { get; }

        public BaseController(ILogger<TController> Logger)
        {
            this.Logger = Logger;
            this.DatabaseContext = DatabaseContext;
        }
    }
}
