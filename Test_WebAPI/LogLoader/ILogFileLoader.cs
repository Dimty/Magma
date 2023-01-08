namespace Test_WebAPI.LogLoader
{
    public interface ILogFileLoader
    {
        ObjectsForJsonConversion.LogJsonData LogData { get; set; }
    }
}