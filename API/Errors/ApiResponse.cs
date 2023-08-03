namespace API.Errors;

public class ApiResponse
{
    public ApiResponse(int statusCode, string? message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }

    public int StatusCode { get; set; }

    public string Message { get; set; }

    private static string GetDefaultMessageForStatusCode(int statusCode) => statusCode switch
    {
        400 => "A bad request, you have made",
        401 => "Unauthorized",
        404 => "Resource wasn't found",
        500 => "Errors are the path to the dark side",
        _ => null
    } ?? string.Empty;
}