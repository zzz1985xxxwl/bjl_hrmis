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
            //������ʱ�����ļ���
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

        [Test,Description("���������ļ���д�����ȡ,ʱ�����Ϊ��")]
        public void Test1()
        {
            //д����
            TransferRule tr = ApplicationFilterTest.MakeTransferRule();
            TransferConfig.WriteConfig(tr, null, null);

            //ģ���û��������ϴ�����
            CommandRunner.CopyToFile(DiskOperations.DataTemp_ForBackUpDirectory + "config.txt", DiskOperations.DataTemp_ForRestoreDirectory + "config.txt");

            //������
            DateTime? startTime;
            DateTime? endTime;
            string theRuleString;
            string theRuleName = TransferConfig.ReadConfig(DiskOperations.DataTemp_ForRestoreDirectory,out theRuleString, out startTime, out endTime);

            //��֤����
            Console.WriteLine(theRuleName);
            Assert.AreEqual("�½�����Ǩ�Ʋ���", theRuleName);
            Assert.IsTrue(!startTime.HasValue);
            Assert.IsTrue(!endTime.HasValue);
            Console.WriteLine(theRuleString);
            Assert.AreEqual(tr.MakeString(), theRuleString);

            //����
            CommandRunner.CleanUpDirectory(DiskOperations.DataTemp_ForBackUpDirectory);
            CommandRunner.CleanUpDirectory(DiskOperations.DataTemp_ForRestoreDirectory);
        }

        [Test, Description("���������ļ���д�����ȡ,ʱ�������Ϊ��")]
        public void Test2()
        {
            //д����
            TransferRule tr = ApplicationFilterTest.MakeTransferRule();
            TransferConfig.WriteConfig(tr, new DateTime(1999, 1, 1), new DateTime(2099, 12, 11));

            //ģ���û��������ϴ�����
            CommandRunner.CopyToFile(DiskOperations.DataTemp_ForBackUpDirectory + "config.txt", DiskOperations.DataTemp_ForRestoreDirectory + "config.txt");

            //������
            DateTime? startTime;
            DateTime? endTime;
            string theRuleString;
            string theRuleName = TransferConfig.ReadConfig(DiskOperations.DataTemp_ForBackUpDirectory, out theRuleString, out startTime, out endTime);

            //��֤����
            Console.WriteLine(theRuleName);
            Assert.AreEqual("�½�����Ǩ�Ʋ���", theRuleName);
            Assert.AreEqual(startTime, new DateTime(1999, 1, 1));
            Assert.AreEqual(endTime, new DateTime(2099, 12, 11));
            Console.WriteLine(theRuleString);
            Assert.AreEqual(tr.MakeString(), theRuleString);

            //����
            CommandRunner.CleanUpDirectory(DiskOperations.DataTemp_ForBackUpDirectory);
            CommandRunner.CleanUpDirectory(DiskOperations.DataTemp_ForRestoreDirectory);
        }

        [Test,Description("���Ը��������ļ���ȡǨ�ƹ���")]
        public void Test3()
        {
            string rarFile = Environment.CurrentDirectory + @"\..\..\TestResources\Config_ForTest.rar";

            //��������֤
            DateTime? startTime;
            DateTime? endTime;
            TransferRule tr = TransferConfig.AnalyseRarData(rarFile,out startTime,out endTime, _TestTempDirectory, true,true);
            Assert.AreEqual(new DateTime(2008,11,1) ,startTime);
            Assert.AreEqual(new DateTime(2009, 1, 1), endTime);
            Assert.AreEqual(tr.RuleName, "ָ���·ݵĿ�������");
            Assert.AreEqual("BackUpAs:[TApplication(TApplicationFilter)]",tr.MakeString());
            Assert.IsTrue(!File.Exists(_TestTempDirectory + "\\config.txt"));

            ////�����ļ��Ľ���
            TransferRule tr2 = TransferConfig.AnalyseRarData(rarFile, out startTime, out endTime, _TestTempDirectory, false, true);
            Assert.AreEqual(tr.MakeString(), tr2.MakeString());
            Assert.IsTrue(File.Exists(_TestTempDirectory + "\\config.txt"));

            //����
            CommandRunner.CleanUpDirectory(_TestTempDirectory);
        }
    }
}