namespace Thayen.WebPlanner.API;

public record class ApiResponse(string Message)
{
    public ApiResponse() : this(string.Empty)
    {
    }

    public static ApiResponse Empty => new();

    public ApiValueResponse<TValue> WithValue<TValue>(TValue value)
    {
        return new ApiValueResponse<TValue>(value, Message);
    }

    public static ApiValueResponse<TValue> Create<TValue>(TValue v)
    {
        return new ApiValueResponse<TValue>(v);
    }

    public static ApiValueResponse<TValue> Create<TValue>(TValue v, string message)
    {
        return new ApiValueResponse<TValue>(v, message);
    }

    public static ApiResponse WithMessage(string message)
    {
        return new ApiResponse(message);
    }
}