using System;
using System.Configuration;
using System.IO;
using NUnit.Framework;
using TransferDatas;

namespace TransferDatasTest
{
    [TestFixture]
    public class TransferConfigTest
    {
        private string _TestTempDirectory;

        [SetUp]
        public void SetUp()
        {
            //构建临时数据文件夹
            _TestTempDirectory = ConfigurationManager.AppSettings["TestTempDirectory"];
            Assert.IsNotNull(_TestTempDirectory);
            _TestTempDirectory = DiskOperations.CorrectDirectory(_TestTempDirectory);
            DiskOperations.CheckAndCreateDirectory(_TestTempDirectory);

            StaticConfigTable.BackUpDirectory = DiskOperations.CorrectDirectory(_TestTempDirectory) + "TestTransferConfig";
            StaticConfigTable.DownloadFilesDirectory = DiskOperations.CorrectDirectory(_TestTempDirectory) + "TestDownLoadFiles";
            StaticConfigTable.TempDirectory = DiskOperations.CorrectDirectory(_TestTempDirectory) + "Temps"; 
            DiskOperations.PrepareForBackUp();
            DiskOperations.PrepareForRestore();
        }

        [TearDown]
        public void TearDown()
        {
            StaticConfigTable.BackUpDirectory = null;
            StaticConfigTable.DownloadFilesDirectory = null;
            StaticConfigTable.TempDirectory = null;
        }

        [Test,Description("测试配置文件的写入与读取,时间参数为空")]
        public void Test1()
        {
            //写配置
            TransferRule tr = ApplicationFilterTest.MakeTransferRule();
            TransferConfig.WriteConfig(tr, null, null);

            //模拟用户的下载上传操作
            CommandRunner.CopyToFile(DiskOperations.DataTemp_ForBackUpDirectory + "config.txt", DiskOperations.DataTemp_ForRestoreDirectory + "config.txt");

            //读配置
            DateTime? startTime;
            DateTime? endTime;
            string theRuleString;
            string theRuleName = TransferConfig.ReadConfig(DiskOperations.DataTemp_ForRestoreDirectory,out theRuleString, out startTime, out endTime);

            //验证配置
            Console.WriteLine(theRuleName);
            Assert.AreEqual("新建数据迁移策略", theRuleName);
            Assert.IsTrue(!startTime.HasValue);
            Assert.IsTrue(!endTime.HasValue);
            Console.WriteLine(theRuleString);
            Assert.AreEqual(tr.MakeString(), theRuleString);

            //清理
            CommandRunner.CleanUpDirectory(DiskOperations.DataTemp_ForBackUpDirectory);
            CommandRunner.CleanUpDirectory(DiskOperations.DataTemp_ForRestoreDirectory);
        }

        [Test, Description("测试配置文件的写入与读取,时间参数不为空")]
        public void Test2()
        {
            //写配置
            TransferRule tr = ApplicationFilterTest.MakeTransferRule();
            TransferConfig.WriteConfig(tr, new DateTime(1999, 1, 1), new DateTime(2099, 12, 11));

            //模拟用户的下载上传操作
            CommandRunner.CopyToFile(DiskOperations.DataTemp_ForBackUpDirectory + "config.txt", DiskOperations.DataTemp_ForRestoreDirectory + "config.txt");

            //读配置
            DateTime? startTime;
            DateTime? endTime;
            string theRuleString;
            string theRuleName = TransferConfig.ReadConfig(DiskOperations.DataTemp_ForBackUpDirectory, out theRuleString, out startTime, out endTime);

            //验证配置
            Console.WriteLine(theRuleName);
            Assert.AreEqual("新建数据迁移策略", theRuleName);
            Assert.AreEqual(startTime, new DateTime(1999, 1, 1));
            Assert.AreEqual(endTime, new DateTime(2099, 12, 11));
            Console.WriteLine(theRuleString);
            Assert.AreEqual(tr.MakeString(), theRuleString);

            //清理
            CommandRunner.CleanUpDirectory(DiskOperations.DataTemp_ForBackUpDirectory);
            CommandRunner.CleanUpDirectory(DiskOperations.DataTemp_ForRestoreDirectory);
        }

        [Test,Description("测试根据配置文件读取迁移规则")]
        public void Test3()
        {
            string rarFile = Environment.CurrentDirectory + @"\..\..\TestResources\Config_ForTest.rar";

            //解析并验证
            DateTime? startTime;
            DateTime? endTime;
            TransferRule tr = TransferConfig.AnalyseRarData(rarFile,out startTime,out endTime, _TestTempDirectory, true,true);
            Assert.AreEqual(new DateTime(2008,11,1) ,startTime);
            Assert.AreEqual(new DateTime(2009, 1, 1), endTime);
            Assert.AreEqual(tr.RuleName, "指定月份的考勤数据");
            Assert.AreEqual("BackUpAs:[TApplication(TApplicationFilter)]",tr.MakeString());
            Assert.IsTrue(!File.Exists(_TestTempDirectory + "\\config.txt"));

            ////保留文件的解析
            TransferRule tr2 = TransferConfig.AnalyseRarData(rarFile, out startTime, out endTime, _TestTempDirectory, false, true);
            Assert.AreEqual(tr.MakeString(), tr2.MakeString());
            Assert.IsTrue(File.Exists(_TestTempDirectory + "\\config.txt"));

            //清理
            CommandRunner.CleanUpDirectory(_TestTempDirectory);
        }
    }
}