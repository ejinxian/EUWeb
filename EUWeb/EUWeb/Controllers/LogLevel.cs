using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace EUWeb.Controllers
{
    public enum LogLevel
    {
        Trace = 0,
        Debug = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
        Critical = 5,
        None = 6
    }
    public class LogClass {
        //ILogger logger = new ServiceCollection()
        //    .AddLogging()
        //    .BuildServiceProvider()
        //    .GetService<ILoggerFactory>()
        //    .AddConsole(LogLevel.Warning)
        //    .AddDebug(LogLevel.Warning)
        //    .CreateLogger("App");
    }
}
