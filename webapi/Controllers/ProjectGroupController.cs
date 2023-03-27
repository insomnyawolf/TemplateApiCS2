using Microsoft.AspNetCore.Mvc;
using webapi.Database;
using webapi.Database.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public partial class ProjectGroupController : CrudController<ProjectGroupController, ProjectGroup>
{
    public ProjectGroupController(ILogger<ProjectGroupController> Logger, DatabaseContext DatabaseContext) : base(Logger, DatabaseContext)
    {
        
    }
}
