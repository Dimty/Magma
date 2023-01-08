using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Test_WebAPI.Configuration;

namespace Test_WebAPI.LogLoader
{
    /// <summary>
    /// Загружает файл с логами.
    /// </summary>
    public class LogJsonFileLoader
    {
        /// <summary>
        /// Хранит путь до файла с логами.
        /// </summary>
        private readonly LogFilePathOption _option;
        /// <summary>
        /// Объект содержащий десериализованные данные из файла.
        /// </summary>
        public ObjectsForJsonConversion.LogJsonData LogData { get; set; }

        public LogJsonFileLoader(IOptions<LogFilePathOption> options)
        {
            _option = options.Value;

            try
            {
                if (!File.Exists(_option.Path))
                {
                    throw new FileNotFoundException();
                }
                
                var json = File.ReadAllText(_option.Path);
                LogData = Newtonsoft.Json.JsonConvert.DeserializeObject<ObjectsForJsonConversion.LogJsonData>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
                
        }
    }
}