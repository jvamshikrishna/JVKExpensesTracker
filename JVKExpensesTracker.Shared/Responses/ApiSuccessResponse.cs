namespace JVKExpensesTracker.Shared.Responses;

public class ApiSuccessResponse<T> : ApiResponse
{
    public ApiSuccessResponse()
    {
        IsSuccess = true;
        ResponseDate = DateTime.UtcNow;
    }

    public ApiSuccessResponse(IEnumerable<T>? records) : this()
    {
        Records = records;
    }

    public ApiSuccessResponse(string message, IEnumerable<T>? records) : this()
    {
        Message = message;
        Records = records;
    }

    public ApiSuccessResponse(string message) : this()
    {
        Message = message;
    }

    public IEnumerable<T>? Records { get; set; }
}
