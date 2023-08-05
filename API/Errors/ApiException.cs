namespace API.Errors;

/// <summary>
/// Class for management api exceptions
/// </summary>
public class ApiException : ApiResponse
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="message"></param>
    /// <param name="details"></param>
    public ApiException(int statusCode, string? message = null, string? details = null) : base(statusCode, message)
    {
        Details = details;
    }

    public string? Details { get; set; }
}