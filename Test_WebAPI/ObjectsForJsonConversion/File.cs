using Newtonsoft.Json;

namespace Test_WebAPI.ObjectsForJsonConversion
{
    /// <summary>
    /// Класс для сериализации/десериализации объекта "Files", содержащий информацию о файлах прошедших сканирование.
    /// </summary>
    public class File
    {
        /// <summary>
        /// Наименование файла.
        /// </summary>
        [JsonProperty(PropertyName = "filename")]
        public string FileName { get; set; }

        /// <summary>
        /// Результ сканирование.
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public bool Result { get; set; }

        /// <summary>
        /// Ошибки выявленные во время сканирования.
        /// </summary>
        [JsonProperty(PropertyName = "errors")]
        public Error[] Errors { get; set; }

        /// <summary>
        /// Время сканирования файла.
        /// </summary>
        [JsonProperty(PropertyName = "scantime")]

        public DateTime ScanTime { get; set; }
    }
}