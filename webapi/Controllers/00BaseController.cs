using webapi.Database;

namespace webapi.Controllers
{
    public abstract class BaseController<TController> where TController : BaseController<TController>
    {
        protected readonly ILogger<TController> Logger;

        public BaseController(ILogger<TController> Logger)
        {
            this.Logger = Logger;
        }
    }
}
