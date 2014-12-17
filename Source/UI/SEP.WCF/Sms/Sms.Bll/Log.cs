using System;
using System.IO;
using System.Text;

namespace Sms.Bll
{
    public class Log
    {
        public static void Write(string ex)
        {
            // 获得前一个异常的实例
            if (ex != null)
            {
                var sbError = new StringBuilder();
                sbError.Append("错误时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + Environment.NewLine);
                sbError.Append("错误：" + ex + Environment.NewLine);
                sbError.Append("==============================================================");
                // 将错误记录到日志中
                string logFile = Path.Combine(GetLogFilePath(), DateTime.Now.ToString("yyyyMMdd") + ".log");
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter(logFile, true);
                    writer.WriteLine(sbError.ToString());
                }
                catch
                {
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                        writer.Dispose();
                    }
                }
            }
        }

        public static void Write(Exception ex)
        {
            // 获得前一个异常的实例
            if (ex != null)
            {
                var sbError = new StringBuilder();
                sbError.Append("错误时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + Environment.NewLine);
                sbError.Append("错误文件：" + ex.Source + Environment.NewLine);
                sbError.Append("错误信息：" + ex.Message + Environment.NewLine);
                sbError.Append("错误堆栈：" + ex.StackTrace + Environment.NewLine);
                sbError.Append("引发错误的方法：" + ex.TargetSite + Environment.NewLine);
                sbError.Append("==============================================================");
                // 将错误记录到日志中
                string logFile = Path.Combine(GetLogFilePath(), DateTime.Now.ToString("yyyyMMdd") + ".log");
                StreamWriter writer = null;
                try
                {
                    writer = new StreamWriter(logFile, true);
                    writer.WriteLine(sbError.ToString());
                }
                catch
                {
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                        writer.Dispose();
                    }
                }
            }
        }

        /// <summary>
        ///     获取日志文件的文件夹
        /// </summary>
        /// <returns></returns>
        private static string GetLogFilePath()
        {
            string logFilePath = Environment.CurrentDirectory + "/Log";
            if (!Directory.Exists(logFilePath))
            {
                Directory.CreateDirectory(logFilePath);
            }
            return logFilePath;
        }
    }
}