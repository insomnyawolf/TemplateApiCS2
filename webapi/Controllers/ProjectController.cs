using Microsoft.AspNetCore.Mvc;
using webapi.Database;
using webapi.Database.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public partial class ProjectController : CrudController<ProjectController, Project>
{
    public ProjectController(ILogger<ProjectController> Logger, DatabaseContext DatabaseContext) : base(Logger, DatabaseContext)
    {
        
    }
}
