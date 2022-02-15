using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace Clalit.Insulin
{
    public class AuthorizeUsersAttribute : ActionFilterAttribute
    {

        public AuthorizeUsersAttribute()
        {
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var config = context.HttpContext.RequestServices.GetService<IConfiguration>();
            var userName = context?.HttpContext?.User?.Identity?.Name.ToLower();
            var allowedUsers = config["AuthorizeUsers"].Split(';').Select(x => x.ToLower());

            if (!allowedUsers.Any(user=> user == userName))
                context.Result = new ObjectResult($"User {userName} is not registered for this service")
                {
                    StatusCode = (int)HttpStatusCode.Forbidden
                };
               
            return base.OnActionExecutionAsync(context, next);
        }     
    }

}
