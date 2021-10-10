
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace KokaarCis.Utility.Options
{
    public class LoggingOptions
    {
        public const string ConfigSectionName = "LoggingOptions";
        public string LogFileName { get; set; }
    }
}
