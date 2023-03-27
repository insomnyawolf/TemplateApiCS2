using Microsoft.AspNetCore.Mvc;
using webapi.Database;
using webapi.Database.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public partial class CompanyController : CrudController<CompanyController, Company>
{
    public CompanyController(ILogger<CompanyController> Logger, DatabaseContext DatabaseContext) : base(Logger, DatabaseContext)
    {

    }
}
