using Microsoft.AspNetCore.Mvc.Filters;

namespace Bosch.eCommerce.Mvc.UI.Filters
{
    public class BoschControllerAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"I am Controller Filter - OnActionExecuting");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"I am Controller Filter - OnActionExecuted");
        }
    }
}
