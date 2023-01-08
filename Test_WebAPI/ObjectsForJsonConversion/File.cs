using Newtonsoft.Json;

namespace Test_WebAPI.ObjectsForJsonConversion
{
    public class File
    {
        [JsonProperty(PropertyName = "filename")]
        public string FileName { get; set; }

        [JsonProperty(PropertyName = "result")]
        public bool Result { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public Error[] Errors { get; set; }

        [JsonProperty(PropertyName = "scantime")]

        public DateTime ScanTime { get; set; }
    }
}