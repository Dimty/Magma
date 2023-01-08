using Newtonsoft.Json;

namespace Test_WebAPI.ObjectsForJsonConversion
{
    /// <summary>
    /// Класс для сериализации/десериализации объекта "Errors", содержащий информацию об ошибках выявленных во время сканирования.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Модуль обнаруживший ошибку.
        /// </summary>
        [JsonProperty(PropertyName = "module")]
        public string Module { get; set; }
        /// <summary>
        /// Внутренний код ошибки.
        /// </summary>
        [JsonProperty(PropertyName = "ecode")]
        public int Ecode { get; set; }
        /// <summary>
        /// Описание ошибки.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string ErrorMessage { get; set; }
    }
}