namespace ResponseFormat;

public class Result
{
    public int Code { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}