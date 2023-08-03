namespace API.Errors;

public class ApiValidationErrorResponse : ApiResponse
{
    public ApiValidationErrorResponse() : base(statusCode: 400, message: null)
    {
    }

    public IEnumerable<string>? Errors { get; set; }
}