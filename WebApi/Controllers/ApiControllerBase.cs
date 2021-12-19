using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [ApiController]
    [TypeFilter(typeof(TodoAppExceptionFilter))]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
