namespace Thayen.WebPlanner.API;

public record class ApiValueResponse<TValue> : ApiResponse
{
    public ApiValueResponse(TValue value, string message) : base(message)
    {
        Value = value;
    }

    public ApiValueResponse(TValue value) : this(value, string.Empty)
    {
    }

    public TValue Value { get; set; }

    public static ApiValueResponse<TValue> Create(TValue v)
    {
        return new ApiValueResponse<TValue>(v);
    }

    public static ApiValueResponse<TValue> Create(TValue v, string message)
    {
        return new ApiValueResponse<TValue>(v, message);
    }
}