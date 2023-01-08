namespace Test_WebAPI.Configuration
{
    /// <summary>
    /// Шаблон параметра пути до файла.
    /// </summary>
    public class LogFilePathOption
    {
        /// <summary>
        /// Наименование позиции.
        /// </summary>
        public const string Position = "FilePath";
        /// <summary>
        /// Ключ.
        /// </summary>
        public string Path { get; set; }
    }
}