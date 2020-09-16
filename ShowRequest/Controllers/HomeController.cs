using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ShowRequest.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{*path}")]
        public IActionResult Get(string path)
        {
            var header = Request.Headers.ToDictionary(m => m.Key, m => m.Value.ToString());
            if (string.Equals(Request.ContentType, "application/json", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(Request.ContentType, "application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase))
            {
                var sr = new StreamReader(Request.Body);
                return Ok(new
                {
                    Url = Request.GetDisplayUrl(),
                    Headers = header,
                    Body = sr.ReadToEnd()
                });
            }
            else
            {
                return Ok(new
                {
                    Url = Request.GetDisplayUrl(),
                    Headers = header,
                });
            }
        }
    }
}