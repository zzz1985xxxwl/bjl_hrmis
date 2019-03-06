using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SEP.HRMIS.Bll.AutoRemindServer;
using SEP.HRMIS.Facade;

namespace FacadeTest
{
    [TestFixture]
    public class TestAutoRemindServerFacade
    {
        [Test]
        public void Test1()
        {
            var facade = new AutoRemindServerFacade();
            facade.AutoCreateVacation(DateTime.Now.Date, 12, 6, 15, 4, 6, 21);
        }

        [Test]
        public void Test2()
        {

            var facade = new AutoAssess(Convert.ToDateTime("2014-12-04"));
            facade.Excute();
        }

        [Test]
        public void TestAutoCreateVacation()
        {
            var facade = new AutoRemindServerFacade();
            facade.AutoCreateVacation(Convert.ToDateTime("2018-12-20"), 12, 6, 15, 4, 12, 20);
        }

        [Test]
        public void Test3()
        {
            //Xg+rY5F9vI6TzXAyGoS+XQ==
            Console.WriteLine(Framework.Common.Encrypt.SecurityUtil.SymmetricDecrypt("kThbc6IxyGRhn1/CwpqoeA==", "luantianlin"));
            //Log("");
            var _LastRunTime = GetLastDateTime();
            var _RunDate = _LastRunTime.AddDays(1).Date;
            DateTime _Today = DateTime.Now;
            while (_RunDate <= _Today.Date)
            {
                Console.WriteLine(_RunDate);
                _RunDate = _RunDate.AddDays(1).Date;
            }
            Log("");
        }


        private static DateTime GetLastDateTime()
        {
            var filepath = Environment.CurrentDirectory + "\\log\\time.log";
            if (File.Exists(filepath))
            {
                StreamReader sr = new StreamReader(filepath, Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    return Convert.ToDateTime(line);
                }
            }
            return DateTime.Now.AddDays(-1);
        }

        private static void Log(string message)
        {
            string logFilePath = Environment.CurrentDirectory + "\\log";
            if (!Directory.Exists(logFilePath))
            {
                Directory.CreateDirectory(logFilePath);
            }
            WriteFile(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Path.Combine(logFilePath, "time.log"), false);

            // 将错误记录到日志中
            WriteFile(message, Path.Combine(logFilePath, DateTime.Now.ToString("yyyyMMdd") + ".log"));
        }

        private static void WriteFile(string message, string file, bool append = true)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(file, append);
                writer.WriteLine(message);
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
}
