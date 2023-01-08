namespace Test_WebAPI.LogLoader
{
    public class LogJsonFileLoader:ILogFileLoader
    {
        public ObjectsForJsonConversion.LogJsonData LogData { get; set; }

        public LogJsonFileLoader(string path)
        {
            if (!File.Exists(path))
            {
                LogData = new();
            }
            else
            {
                var json = File.ReadAllText(path);
                LogData = Newtonsoft.Json.JsonConvert.DeserializeObject<ObjectsForJsonConversion.LogJsonData>(json) ?? new();
            }
            
        }
    }
}