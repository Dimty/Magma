using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test_Practice_CSharp.DTO;
using Test_WebAPI.LogLoader;
using Test_WebAPI.ObjectsForJsonConversion;

namespace Test_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly ILogFileLoader _fileLog;
        private readonly IMapper _mapper;


        public ApiController(ILogger<ApiController> logger,
            ILogFileLoader fileLog,
            IMapper mapper)
        {
            _logger = logger;
            _fileLog = fileLog;
            _mapper = mapper;
        }

        [HttpGet("allData")]
        public IActionResult GetAllData() => Ok(_fileLog.LogData);

        [HttpGet("scan")]
        public IActionResult GetScan() => Ok(_fileLog.LogData.Scan);

        [HttpGet("filename")]
        public IActionResult GetFileNameCorrect([FromQuery] bool? correct)
        {
            if (correct is null)
                return BadRequest(correct);

            var list = _fileLog.LogData.Files.Where(x => x.Result == correct);
            return Ok(list);
        }

        [HttpGet("errors")]
        public IActionResult GetAllError()
        {
            ObjectsForJsonConversion.File[] list = _fileLog.LogData.Files.Where(x => !x.Result).ToArray();

            var res = list.Select(x => _mapper.Map<ErrorDTO>(x)).ToArray();
            return Ok(res);
        }

        [HttpGet("errors/count")]
        public IActionResult GetErrorCount() => Ok(_fileLog.LogData.Scan.ErrorCount);

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

        [HttpGet("ServiceInfo")]
        //TODO serviceinfodto
        public IActionResult GetServiceInfo() => new JsonResult(new ServiceInfoDto());

        [HttpGet("query/check")]
        public IActionResult GetQuery()
        {
            ObjectsForJsonConversion.File[] list = _fileLog.LogData.Files
                .Where(x => x.FileName.ToLower().StartsWith("query_")).ToArray();

            int correctRes = list.Count(x => x.Result);

            QueryDto dto = new()
            {
                Total = list.Length,
                Correct = correctRes,
                Errors = list.Length - correctRes,
                Filenames = list.Where(x => x.Result == false).Select(x => x.FileName).ToArray()
            };
            return Ok(dto);
        }


        [HttpPost("newErrors")]
        public async Task<IActionResult> PostNewError([FromBody] LogJsonData data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var des = Newtonsoft.Json.JsonConvert.SerializeObject(data,Formatting.Indented);
                //TODO
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