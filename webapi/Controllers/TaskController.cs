using Microsoft.AspNetCore.Mvc;
using webapi.Database;
using webapi.Database.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public partial class TaskController : CrudAsdController<TaskController, TasksItem>, ISample
{
    public TaskController(ILogger<TaskController> Logger, DatabaseContext DatabaseContext) : base(Logger, DatabaseContext)
    {

    }
}


public interface ISample
{

}