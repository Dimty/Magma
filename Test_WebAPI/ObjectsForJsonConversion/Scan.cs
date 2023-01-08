using Newtonsoft.Json;

namespace Test_WebAPI.ObjectsForJsonConversion
{
    /// <summary>
    /// Класс для сериализации/десериализации объекта "Scan", содержащий информацию о сканировании.
    /// </summary>
    public class Scan
    {
        /// <summary>
        /// Время сканирование.
        /// </summary>
        [JsonProperty(PropertyName = "scanTime")]
        public DateTime ScanTime { get; set; }

        /// <summary>
        /// Наименование бд.
        /// </summary>
        [JsonProperty(PropertyName = "db")] 
        public string Db { get; set; }

        /// <summary>
        /// Сервер.
        /// </summary>
        [JsonProperty(PropertyName = "server")]
        public string Server { get; set; }

        /// <summary>
        /// Количество файлов, содержащих ошибку.
        /// </summary>
        [JsonProperty(PropertyName = "errorCount")]
        public int ErrorCount { get; set; }
    }
}