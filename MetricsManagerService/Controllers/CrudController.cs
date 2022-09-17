using MetricsManagerService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MetricsManagerService.Controllers
{
    [Route("api/crud")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private ValuesHolder _holder;

        public CrudController(ValuesHolder holder)
        {
            _holder = holder;

        }

        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(_holder.Get());
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] TimeSpan newValueTime, [FromQuery] int newValueTemp)
        {
            _holder.Add(newValueTime, newValueTemp);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] TimeSpan stringsToUpdate,
        [FromQuery] int newValue)
        {
            for (int i = 0; i < _holder.ValuesTemp.Count; i++)
            {
                if (_holder.ValuesTime[i] == stringsToUpdate)
                    _holder.ValuesTemp[i] = newValue;
            }
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] TimeSpan minValueToDelete, [FromQuery] TimeSpan maxValueToDelete)
        {
            _holder.ValuesTime = _holder.ValuesTime.Where(w => w < minValueToDelete || w > maxValueToDelete).ToList();
            return Ok();
        }
    }
}
