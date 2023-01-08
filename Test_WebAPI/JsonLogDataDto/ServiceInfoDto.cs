using System.Reflection;
using Newtonsoft.Json;

namespace Test_Practice_CSharp.DTO
{
    public class ServiceInfoDto
    {
        public string AppName { get; } = Assembly.GetExecutingAssembly().GetName().Name;
        public string Version { get; } = Assembly.GetExecutingAssembly().ImageRuntimeVersion;
        public DateTime DateUtc { get; } = DateTime.UtcNow;
    }
}