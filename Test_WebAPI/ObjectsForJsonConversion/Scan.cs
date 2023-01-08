using Newtonsoft.Json;

namespace Test_WebAPI.ObjectsForJsonConversion
{
    public class Scan
    {
        [JsonProperty(PropertyName = "scanTime")]
        public DateTime ScanTime { get; set; }

        [JsonProperty(PropertyName = "db")] 
        public string Db { get; set; }

        [JsonProperty(PropertyName = "server")]
        public string Server { get; set; }

        [JsonProperty(PropertyName = "errorCount")]
        public int ErrorCount { get; set; }
    }
}