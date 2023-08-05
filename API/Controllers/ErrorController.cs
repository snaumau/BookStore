using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/// <summary>
/// Error controller
/// </summary>
[Route("errors/{code:int}")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : BaseApiController
{
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ApiResponse(code));
    }
}