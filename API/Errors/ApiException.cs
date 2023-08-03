namespace API.Errors;

public class ApiException : ApiResponse
{
    public ApiException(int statusCode, string? message, string? details) : base(statusCode, message)
    {
        Details = details ?? string.Empty;
    }

    public string Details { get; set; }
}