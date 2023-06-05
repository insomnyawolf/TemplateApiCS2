using Microsoft.AspNetCore.Mvc;
using webapi.Database;
using webapi.Database.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public partial class TaskStateEnumController : ReadController<TaskStateEnumController, TaskStateEnum>
{
    public TaskStateEnumController(ILogger<TaskStateEnumController> Logger, DatabaseContext DatabaseContext) : base(Logger, DatabaseContext)
    {

    }
}