using System;
using System.IO;
using System.Text;

namespace Movie.Framework
{
    public class LogUtils
    {
        public static void Add(string message, Exception ex)
        {
            var logFile = "";
            var logPath = System.IO.Path.Combine(Environment.CurrentDirectory, "LOG", DateTime.Now.ToString("yyyyMMdd"));
            var exception = ex?.ToString();
            try
            {
                logFile = Path.Combine(logPath, Guid.NewGuid() + ".txt");
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("=============================================");
                stringBuilder.AppendLine("=============================================");
                stringBuilder.AppendLine(string.Format("Data: {0}", DateTime.UtcNow));
                stringBuilder.AppendLine("Message: " + message ?? string.Empty);
                stringBuilder.AppendLine("Exception: " + exception);
                stringBuilder.AppendLine("=============================================");
                stringBuilder.AppendLine("=============================================");

                using (var myStreamWriter = new StreamWriter(logFile, true))
                {
                    myStreamWriter.WriteLine(stringBuilder);
                    myStreamWriter.Close();
                }
            }
            catch 
            {
                System.Diagnostics.Debug.Write($"ERROR! We couldn't save the Log File on disk {logFile}. Exception: {exception}.");
            }
        }
    }
}