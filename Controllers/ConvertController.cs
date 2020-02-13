using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreVueStarter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : Controller
    {
        private readonly ILogger<ConvertController> _logger;

        public ConvertController(ILogger<ConvertController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string Post([FromBody] string inputText)
        {
            List<string> lines = Regex.Split(inputText, "\r\n|\r|\n").ToList();

            string res = "";
            bool listLock = false;

            foreach (var line in lines)
            {
                if (line.TrimStart().StartsWith("#"))
                {
                    if (listLock)
                    {
                        listLock = false;

                        res += $"</ul>\r\n";
                    }

                    res += String.Format("<h1>{0}</h1>\r\n", line.Remove(0, 1).Trim());
                }
                else if (line.TrimStart().StartsWith("*"))
                {
                    if (!listLock)
                    {
                        listLock = true;

                        res += $"<ul>\r\n";
                    }

                    res += String.Format("<li>{0}</li>\r\n", line.Remove(0, 1).Trim());
                }
                else if (line.Trim() != "")
                {
                    if (listLock)
                    {
                        listLock = false;

                        res += $"</ul>\r\n";
                    }

                    res += String.Format("<p>{0}</p>\r\n", line);
                }
                else
                {
                    if (listLock)
                    {
                        listLock = false;

                        res += $"</ul>\r\n";
                    }
                }
            }

            if (listLock)
            {
                listLock = false;

                res += $"</ul>\r\n";
            }

            return res;
        }
    }
}
