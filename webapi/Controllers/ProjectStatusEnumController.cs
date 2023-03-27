using Microsoft.AspNetCore.Mvc;
using webapi.Database;
using webapi.Database.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public partial class ProjectStatusEnumController : BaseController<ProjectStatusEnumController>
{
    public DatabaseContext DatabaseContext { get; }

    public ProjectStatusEnumController(ILogger<ProjectStatusEnumController> Logger, DatabaseContext DatabaseContext) : base(Logger)
    {
        this.DatabaseContext = DatabaseContext;
    }

    [HttpGet]
    public IEnumerable<ProjectStatusEnum> Get(int? id)
    {
        IQueryable<ProjectStatusEnum> query = DatabaseContext.ProjectStatusEnums;

        if (id is not null)
        {
            query = query.Where(x => x.Id == id);
        }

        return query;
    }
}
