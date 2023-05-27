using Microsoft.AspNetCore.Mvc;

namespace Shared.CustomControllerBase
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,

            };
        }
    }
}
