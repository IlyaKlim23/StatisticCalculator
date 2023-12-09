namespace StatisticCalculator.Response;

public class BaseResponse
{
    protected BaseResponse(object data)
    {
        Data = data;
    }
    
    public object? Data { get; set; }
}