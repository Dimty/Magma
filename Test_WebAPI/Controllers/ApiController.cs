using System.Globalization;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test_Practice_CSharp.DTO;
using Test_WebAPI.LogLoader;
using Test_WebAPI.ObjectsForJsonConversion;

namespace Test_WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        //По-хорошему, конечно, лучше через интерфейс, но в этот раз решил ограничиться таким способом.
        private readonly LogJsonFileLoader _fileLog;
        private readonly IMapper _mapper;


        public ApiController(ILogger<ApiController> logger,
            LogJsonFileLoader fileLog,
            IMapper mapper)
        {
            _logger = logger;
            _fileLog = fileLog;
            _mapper = mapper;
        }

        /// <returns>Все данные прочитанные из файла.</returns>
        [HttpGet("allData")]
        public IActionResult GetAllData() => Ok(_fileLog.LogData);

        /// <returns>Содержание объекта <see cref="ObjectsForJsonConversion.Scan"/>.</returns>
        [HttpGet("scan")]
        public IActionResult GetScan() => Ok(_fileLog.LogData.Scan);

        /// <param name="correct">Значение результата сканирования.</param>
        /// <returns>В зависимости от значения параметра выдает список файлов со схожим значением результата сканирования.</returns>
        [HttpGet("filename")]
        public IActionResult GetFileNameCorrect([FromQuery] bool? correct)
        {
            if (correct == null)
                return BadRequest(correct);

            var list = _fileLog.LogData.Files.Where(x => x.Result == correct);
            return Ok(list);
        }

        /// <returns>Список файлов с выявленными ошибками во время сканирования.</returns>
        [HttpGet("errors")]
        public IActionResult GetAllError()
        {
            ObjectsForJsonConversion.File[] list = _fileLog.LogData.Files.Where(x => !x.Result).ToArray();

            var res = list.Select(x => _mapper.Map<ErrorDTO>(x)).ToArray();
            return Ok(res);
        }

        /// <returns>Количество файлов с ошибками.</returns>
        [HttpGet("errors/count")]
        public IActionResult GetErrorCount() => Ok(_fileLog.LogData.Scan.ErrorCount);

        /// <param name="index">Индекс интересующего файла с ошибкой.</param>
        /// <returns>Файл с ошибкой по индексу.</returns>
        [HttpGet("errors/{index:int}")]
        public IActionResult GetErrorByIndex(int index)
        {
            ObjectsForJsonConversion.File[] list = _fileLog.LogData.Files.Where(x => !x.Result).ToArray();
            if (index < 0 || index > list.Length)
            {
                return BadRequest("Index out of range");
            }

            var res = _mapper.Map<ErrorDTO>(list[index]);
            return Ok(res);
        }

        /// <returns>Наименование сборки, номер версии и время на сервере.</returns>
        [HttpGet("ServiceInfo")]
        //TODO serviceinfodto
        public IActionResult GetServiceInfo() => new JsonResult(new ServiceInfoDto());

        [HttpGet("query/check")]
        public IActionResult GetQuery()
        {
            ObjectsForJsonConversion.File[] list = _fileLog.LogData.Files
                .Where(x => x.FileName.ToLower().StartsWith("query_")).ToArray();

            int correctRes = list.Count(x => x.Result);
            //можно через маппер
            QueryDto dto = new()
            {
                Total = list.Length,
                Correct = correctRes,
                Errors = list.Length - correctRes,
                Filenames = list.Where(x => x.Result == false).Select(x => x.FileName).ToArray()
            };
            return Ok(dto);
        }

        /// <summary>
        /// Десериализует полученные данные и в случае успехи записывает их в созданный файл в формате ".json".
        /// </summary>
        /// <param name="data">Данные для десериализации.</param>
        /// <returns>Код статуса выполнения операции.</returns>
        [HttpPost("newErrors")]
        public async Task<IActionResult> PostNewError([FromBody] LogJsonData data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var des = Newtonsoft.Json.JsonConvert.SerializeObject(data, Formatting.Indented);
                //TODO мб стоит убрать регулярку(или изменить -_-)
                var fileName = Regex.Replace(data.Scan.ScanTime.ToString(CultureInfo.InvariantCulture), "[/\\|:.]", "-")
                    .Replace(' ', '_') + ".json";

                if (System.IO.File.Exists(fileName))
                {
                    return Problem("The file already exist.");
                }

                await using var sw = new StreamWriter(fileName);
                await sw.WriteLineAsync(des);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message + " " + e.StackTrace);

                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}