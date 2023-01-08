namespace Test_Practice_CSharp.DTO
{
    /// <summary>
    /// DTO-объект содержащий информацию об файлах с ошибкой.
    /// </summary>
    public class ErrorDTO
    {
        /// <summary>
        /// Наименование файла.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Выявленные ошибки у файла.
        /// </summary>
        public string[] Errors { get; set; }
    }
}