using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/// <summary>
/// Base API Controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
}