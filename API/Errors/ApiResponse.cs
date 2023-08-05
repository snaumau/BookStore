namespace API.Errors;

/// <summary>
/// Class for management api responses
/// </summary>
public class ApiResponse
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="message"></param>
    public ApiResponse(int statusCode, string? message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }

    public int StatusCode { get; set; }

    public string Message { get; set; }

    /// <summary>
    /// Get default message by status code
    /// </summary>
    /// <param name="statusCode"></param>
    /// <returns>Return default message</returns>
    private static string GetDefaultMessageForStatusCode(int statusCode) => statusCode switch
    {
        400 => "A bad request, you have made",
        401 => "Unauthorized",
        404 => "Resource wasn't found",
        500 => "Errors are the path to the dark side",
        _ => null
    } ?? string.Empty;
}