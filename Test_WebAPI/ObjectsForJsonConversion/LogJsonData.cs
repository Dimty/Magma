using Newtonsoft.Json;

namespace Test_WebAPI.ObjectsForJsonConversion
{
    public class LogJsonData
    {
        [JsonProperty(PropertyName = "scan")]
        public Scan Scan { get; set; }
        
        [JsonProperty(PropertyName = "files")]
        public ObjectsForJsonConversion.File[] Files { get; set; }
    }
}