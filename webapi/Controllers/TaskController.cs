using Microsoft.AspNetCore.Mvc;
using webapi.Database;
using webapi.Database.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public partial class TaskController : CrudController<TaskController, TasksItem>
{
    public TaskController(ILogger<TaskController> Logger, DatabaseContext DatabaseContext) : base(Logger, DatabaseContext)
    {

    }
}