namespace Test_Practice_CSharp.DTO
{
    /// <summary>
    /// DTO-объект, который содержит результат проверки файлов, у которых свойство filename начинается с «query_».
    /// </summary>
    public class QueryDto
    {
        /// <summary>
        /// Суммарное количество файлов, начинающихся на “query_”.
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// Суммарное кол-во файлов, у которых свойство result = true (без ошибок).
        /// </summary>
        public int Correct { get; set; }
        /// <summary>
        /// Суммарное кол-во файлов, у которых свойство result = false (с ошибками).
        /// </summary>
        public int Errors { get; set; }
        /// <summary>
        /// Имена файлов, в которых были найдены ошибки. 
        /// </summary>
        public string[] Filenames { get; set; }
    }
}