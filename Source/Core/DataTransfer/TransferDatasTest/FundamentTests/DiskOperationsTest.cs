using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using NUnit.Framework;
using TApplicationFilter;
using TransferDatas;

namespace TransferDatasTest
{
    [TestFixture]
    public class DiskOperationsTest
    {
        private string _TestTempDirectory;

        [SetUp]
        public void SetUp()
        {
            StaticConfigTable.BackUpDirectory = @"C:\ShiXinTechDbBackUp";
            StaticConfigTable.DownloadFilesDirectory = @"C:\ShiXinTech\DownLoadFiles\";
            StaticConfigTable.TempDirectory = @"C:\DataTemp";

            //构建临时数据文件夹
            _TestTempDirectory = ConfigurationManager.AppSettings["TestTempDirectory"];
            Assert.IsNotNull(_TestTempDirectory);
            _TestTempDirectory = DiskOperations.CorrectDirectory(_TestTempDirectory);
            DiskOperations.CheckAndCreateDirectory(_TestTempDirectory);
        }

        [TearDown]
        public void TearDown()
        {
            StaticConfigTable.BackUpDirectory = null;
            StaticConfigTable.DownloadFilesDirectory = null;
            StaticConfigTable.TempDirectory = null;
        }

        [Test, Description("测试备份时候的文件夹创建的正确性")]
        public void Test1()
        {
            DiskOperations.PrepareForBackUp();

            Assert.AreEqual(@"C:\DataTemp\ForBackUp\", DiskOperations.DataTemp_ForBackUpDirectory);
            Assert.AreEqual(@"C:\ShiXinTechDbBackUp\ForBackUp\", DiskOperations.DbBackUp_ForBackUpDirectory);
            Assert.AreEqual(@"C:\ShiXinTech\DownLoadFiles\", DiskOperations.DownLoadDirectory);
            Assert.AreEqual(@"C:\DataTemp\", DiskOperations.TempDirectory);

            Assert.IsTrue(Directory.Exists(@"C:\DataTemp\"));
            Assert.IsTrue(Directory.Exists(@"C:\DataTemp\ForBackUp\"));
            Assert.IsTrue(Directory.Exists(@"C:\ShiXinTechDbBackUp\ForBackUp\"));
            Assert.IsTrue(Directory.Exists(@"C:\ShiXinTech\DownLoadFiles\"));
        }

        [Test, Description("测试数据恢复时候的文件夹创建的正确性")]
        public void Test2()
        {
            DiskOperations.PrepareForRestore();

            Assert.AreEqual(@"C:\DataTemp\ForRestore\", DiskOperations.DataTemp_ForRestoreDirectory);
            Assert.AreEqual(@"C:\ShiXinTechDbBackUp\ForRestore\", DiskOperations.DbBackUp_ForRestoreDirectory);
            Assert.AreEqual(@"C:\DataTemp\", DiskOperations.TempDirectory);

            Assert.IsTrue(Directory.Exists(@"C:\DataTemp\"));
            Assert.IsTrue(Directory.Exists(@"C:\DataTemp\ForRestore"));
            Assert.IsTrue(Directory.Exists(@"C:\ShiXinTechDbBackUp\ForRestore"));
        }


        [Test, Description("测试有问题的目录配置")]
        public void Test3()
        {
            //测试DownLoadFiles文件夹的配置
            StaticConfigTable.DownloadFilesDirectory = @"C:\DataTemp\DownLoadFiles\";
            try
            {
                DiskOperations.PrepareForBackUp();
                Assert.Fail();
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("当前数据迁移的配置文件中以下配置有问题，因为TempDirectory文件夹会被程序清空造成重要数据丢失,无法在TempDirectory文件夹下配置BackUpDirectory或者DownloadFilesDirectory", ae.Message);
            }

            //测试BackUp文件夹的配置
            StaticConfigTable.DownloadFilesDirectory = @"C:\ShiXinTech\DownLoadFiles\";
            StaticConfigTable.BackUpDirectory = @"C:\DataTemp\DataBackUp";
            try
            {
                DiskOperations.PrepareForBackUp();
                Assert.Fail();
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("当前数据迁移的配置文件中以下配置有问题，因为TempDirectory文件夹会被程序清空造成重要数据丢失,无法在TempDirectory文件夹下配置BackUpDirectory或者DownloadFilesDirectory", ae.Message);
            }
            try
            {
                DiskOperations.PrepareForRestore();
                Assert.Fail();
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("当前数据迁移的配置文件中以下配置有问题，因为TempDirectory文件夹会被程序清空造成重要数据丢失,无法在TempDirectory文件夹下配置BackUpDirectory或者DownloadFilesDirectory", ae.Message);
            }

            //正常的设置
            StaticConfigTable.BackUpDirectory = @"C:\ShiXinTechDbBackUp";
            DiskOperations.PrepareForBackUp();
            DiskOperations.PrepareForRestore();
        }

        [Test,Description("测试Assembly的读取与相关对象的创建")]
        public void Test4()
        {
            ITableFilter theObj = DiskOperations.CreateTableFilterObj("TApplicationFilter.dll");
            Assert.IsNotNull(theObj);
            Assert.IsTrue(theObj is TApplicationFilter.TApplicationFilter);
        }

        [Test,Description("测试配置文件的写入与读取")]
        public void Test5()
        {
            string targetConfigName = string.Format("{0}Config.txt", _TestTempDirectory);
            //写入
            List<string> theConfigs = new List<string>();
            theConfigs.Add("RuleName =It's a ruleName Test");
            theConfigs.Add("Parameter = (1999,1,1)-(2008,1,1)");
            DiskOperations.WriteLinesToFile(targetConfigName, theConfigs);
            Assert.IsTrue(File.Exists(targetConfigName));
            //读取
            List<string> theReadConfigs = DiskOperations.ReadLinesFromFile(targetConfigName);
            Assert.AreEqual(theConfigs.Count, theReadConfigs.Count);
            for (int i = 0; i < theReadConfigs.Count; i++)
            {
                Assert.AreEqual(theConfigs[i],theReadConfigs[i]);
            }
            //清理
            CommandRunner.CleanUpDirectory(_TestTempDirectory);
        }

        [Test]
        public void Test6()
        {
            string tempOfFiles = _TestTempDirectory + "FilesTemp\\";
            DiskOperations.CheckAndCreateDirectory(tempOfFiles);
            //指定文件夹中未含有相关的文件，将不执行任何删除
            string result = DiskOperations.DelFilesFromDirectory(tempOfFiles, "nonFilesKey", "", 1);
            Console.WriteLine(result);
            Assert.AreEqual("--删除文件：未删除任何文件", result);

            //在指定文件夹中加入以下文件
            AddFileToDirectory(tempOfFiles, "xy1.txt");
            AddFileToDirectory(tempOfFiles, "xy2.txt");
            AddFileToDirectory(tempOfFiles, "xy3.txt");
            AddFileToDirectory(tempOfFiles, "notReleatedFile.txt");

            //未匹配Key的文件不会删除
            string result1 = DiskOperations.DelFilesFromDirectory(tempOfFiles, "nonFilesKey", "", 1);
            Console.WriteLine(result1);
            Assert.AreEqual("--删除文件：未删除任何文件", result);
            Assert.IsTrue(File.Exists(tempOfFiles + "xy1.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "xy2.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "xy3.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "notReleatedFile.txt"));

            //匹配Key,未指定受保护对象,将会把最早创建的xy1删除
            string result2 = DiskOperations.DelFilesFromDirectory(tempOfFiles, "xy", "", 2);
            Console.WriteLine(result2);
            Assert.AreEqual(@"--删除文件：C:\TestTempData\FilesTemp\xy1.txt", result2);
            Assert.IsTrue(File.Exists(tempOfFiles + "xy2.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "xy3.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "notReleatedFile.txt"));

            //匹配Key，但是限制了文件夹内含有的数量，不会删除任何对象
            string result3 = DiskOperations.DelFilesFromDirectory(tempOfFiles, "xy", "", 2);
            Console.WriteLine(result3);
            Assert.AreEqual("--删除文件：未删除任何文件", result3);
            Assert.IsTrue(File.Exists(tempOfFiles + "xy2.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "xy3.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "notReleatedFile.txt"));

            //匹配Key,指定受保护对象(xy2.txt)，将会把最晚创建的xy3删除
            string result4 = DiskOperations.DelFilesFromDirectory(tempOfFiles, "xy", tempOfFiles + "xy2.txt", 1);
            Console.WriteLine(result4);
            Assert.AreEqual(@"--删除文件：C:\TestTempData\FilesTemp\xy3.txt", result4);
            Assert.IsTrue(File.Exists(tempOfFiles + "xy2.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "notReleatedFile.txt"));

            //清理文件夹
            CommandRunner.CleanUpDirectory(tempOfFiles);
        }

        public void AddFileToDirectory(string directory,string fileName)
        {
            StreamWriter sw = new StreamWriter(directory + fileName,false);
            sw.Write("只为测试而构建的数据");
            sw.Close();
        }
    }
}