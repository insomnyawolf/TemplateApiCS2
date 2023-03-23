using Microsoft.AspNetCore.Mvc;
using webapi.Database;
using webapi.Database.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectDealTypeEnumController : BaseController<ProjectDealTypeEnumController>
{
    public DatabaseContext DatabaseContext { get; }

    public ProjectDealTypeEnumController(ILogger<ProjectDealTypeEnumController> Logger, DatabaseContext DatabaseContext) : base(Logger)
    {
        this.DatabaseContext = DatabaseContext;
    }

    [HttpGet]
    public IEnumerable<ProjectDealTypeEnum> Get(int? id)
    {
        IQueryable<ProjectDealTypeEnum> query = DatabaseContext.ProjectDealTypeEnums;

        if (id is not null)
        {
            query = query.Where(x => x.Id == id);
        }

        return query;
    }
}
