using Newtonsoft.Json;

namespace Test_WebAPI.ObjectsForJsonConversion
{
    /// <summary>
    /// Класс для сериализации/десериализации всего объекта "Data", содержащий полную информацию.
    /// </summary>
    public class LogJsonData
    {
        /// <summary>
        /// Объект <see cref="ObjectsForJsonConversion.Scan"/>.
        /// </summary>
        [JsonProperty(PropertyName = "scan")]
        public Scan Scan { get; set; }
        /// <summary>
        /// Объект <see cref="ObjectsForJsonConversion.Files"/>.
        /// </summary>
        [JsonProperty(PropertyName = "files")]
        public ObjectsForJsonConversion.File[] Files { get; set; }
    }
}