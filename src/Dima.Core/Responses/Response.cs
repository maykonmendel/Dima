using System.Text.Json.Serialization;

namespace Dima.Core.Responses;
public class Response<TData>
{
    private const int DefaultStatusCode = 200;
    private readonly int _statusCode;

    [JsonConstructor]
    public Response()
        => _statusCode = DefaultStatusCode;


    public Response(TData? data, int statusCode = DefaultStatusCode, string? message = null)
    {
        Data = data;        
        _statusCode = statusCode;
        Message = message;
    }

    public TData? Data { get; set; }
    public string? Message { get; set; } = string.Empty;

    [JsonIgnore]
    public bool IsSuccess 
        => _statusCode >= 200 && _statusCode <= 299;
}
