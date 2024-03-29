using CMS.Api;

namespace CMS
{
    public class Program
    {
        static string LogXML => @"<?xml version=""1.0"" encoding=""utf-8""?>
<log4net>
  <appender name=""rollingLogFile"" type=""log4net.Appender.RollingFileAppender"">
    <file value=""FILEPATH"" />
    <appendToFile value=""true"" />
    <rollingStyle value=""Size"" />
    <maxSizeRollBackups value=""FILECOUNT"" />
    <maximumFileSize value=""FILESIZE"" />
    <staticLogFileName value=""true"" />
    <layout type=""log4net.Layout.PatternLayout"">
      <conversionPattern value=""CONVERSIONPATTERN"" />
    </layout>
  </appender>
  <root name=""APPNAME"">
    <level value=""LEVEL"" />
    <appender-ref ref=""rollingLogFile"" />
  </root>
</log4net>
        ";

        public static string GetLogXMLConfig(string appName, IConfiguration config) => LogXML
            .Replace("APPNAME", appName)
            .Replace("FILEPATH", config.GetSection("Logging")["FilePath"])
            .Replace("FILECOUNT", config.GetSection("Logging")["FileCount"])
            .Replace("FILESIZE", config.GetSection("Logging")["FileSize"])
            .Replace("LEVEL", config.GetSection("Logging")["Level"])
            .Replace("CONVERSIONPATTERN", config.GetSection("Logging")["ConversionPattern"]);

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // configure DI for stack
            builder.Services.AddModelBuildProviders(builder.Configuration);
            builder.Services.AddSession();
            builder.Services.AddAuthInfo();
            builder.Services.AddCMS("Api/CMS");
            builder.Services.AddAspNetCore();
            builder.Services.AddMetadata();

            builder.Services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromMinutes(60);
            });

            builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
            
            builder.Logging.ClearProviders();
            builder.Logging.AddSimpleConsole();
            var tempPath = Path.GetTempFileName();
            File.WriteAllText(tempPath, GetLogXMLConfig("Web", builder.Configuration));
            builder.Logging.AddLog4Net(tempPath);

            var app = builder.Build();
            app.UseSession();
            app.UseCMS();
            app.UseTheFramework();
            app.Run();
        }
    }
}