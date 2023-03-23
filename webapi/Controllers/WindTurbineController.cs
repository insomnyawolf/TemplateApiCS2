using Microsoft.AspNetCore.Mvc;
using webapi.Database;
using webapi.Database.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class WindTurbineController : CrudController<WindTurbineController, WindTurbine>
{
    public WindTurbineController(ILogger<WindTurbineController> Logger, DatabaseContext DatabaseContext) : base(Logger, DatabaseContext)
    {
        
    }
}
