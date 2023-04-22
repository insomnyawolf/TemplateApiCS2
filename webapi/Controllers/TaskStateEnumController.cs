using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using webapi.Database;
using webapi.Database.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public partial class TaskStateEnumController : ReadController<TaskController, TaskStateEnum>
{
    public TaskStateEnumController(ILogger<TaskController> Logger, DatabaseContext DatabaseContext) : base(Logger, DatabaseContext)
    {

    }
}