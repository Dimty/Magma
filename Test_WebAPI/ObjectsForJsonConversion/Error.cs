using Newtonsoft.Json;

namespace Test_WebAPI.ObjectsForJsonConversion
{
    public class Error
    {
        [JsonProperty(PropertyName = "module")]
        public string Module { get; set; }
        
        [JsonProperty(PropertyName = "ecode")]
        public int Ecode { get; set; }
        
        [JsonProperty(PropertyName = "error")]
        public string ErrorMessage { get; set; }
    }
}