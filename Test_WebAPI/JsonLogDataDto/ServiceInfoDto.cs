using System.Reflection;
using Newtonsoft.Json;

namespace Test_Practice_CSharp.DTO
{
    /// <summary>
    /// DTO-объект, в котором содержится техническую информация. 
    /// </summary>
    public class ServiceInfoDto
    {
        /// <summary>
        /// Имя сервера.
        /// </summary>
        public string AppName { get; } = Assembly.GetExecutingAssembly().GetName().Name;
        /// <summary>
        /// Версия сервера.
        /// </summary>
        public string Version { get; } = Assembly.GetExecutingAssembly().ImageRuntimeVersion;
        /// <summary>
        /// Текущая дата на сервере.
        /// </summary>
        public DateTime DateUtc { get; } = DateTime.UtcNow;
    }
}