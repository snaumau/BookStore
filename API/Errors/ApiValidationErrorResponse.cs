namespace API.Errors;

/// <summary>
/// Class for validation error response
/// </summary>
public class ApiValidationErrorResponse : ApiResponse
{
    public ApiValidationErrorResponse() : base(statusCode: 400)
    {
    }

    public IEnumerable<string>? Errors { get; set; }
}