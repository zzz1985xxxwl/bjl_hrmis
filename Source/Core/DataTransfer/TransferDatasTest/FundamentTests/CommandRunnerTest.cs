using System.Configuration;
using System.IO;
using NUnit.Framework;
using TransferDatas;

namespace TransferDatasTest
{
    [TestFixture]
    public class CommandRunnerTest
    {
        private string _TestTempDirectory;

        [TestFixtureSetUp]
        public void SetUp()
        {
            //构建临时数据文件夹
            _TestTempDirectory = ConfigurationManager.AppSettings["TestTempDirectory"];
            Assert.IsNotNull(_TestTempDirectory);
            _TestTempDirectory = DiskOperations.CorrectDirectory(_TestTempDirectory);
            DiskOperations.CheckAndCreateDirectory(_TestTempDirectory);
        }
        
        [Test,Description("测试文件->文件的拷贝")]
        public void Test1()
        {
            const string fileName = "testFile.txt";
            const string targetFileName = "copyFile.txt";

            //先构建一个文件
            StreamWriter sw = new StreamWriter(_TestTempDirectory + fileName,false);
            sw.Write("测试文件，随意删除，不过见到此文件就说明垃圾清理工作没有做好-_-!");
            sw.Close();
            //拷贝
            CommandRunner.CopyToFile(_TestTempDirectory + fileName, _TestTempDirectory + targetFileName);
            Assert.IsTrue(File.Exists(_TestTempDirectory + targetFileName));
            //清理
            CommandRunner.CleanUpDirectory(_TestTempDirectory);
            Assert.IsTrue(!File.Exists(_TestTempDirectory + targetFileName));
        }

        [Test, Description("测试文件->文件夹的拷贝")]
        public void Test2()
        {
            const string fileName = "testFile.txt";
            const string tempDirectoryName = "Temps";

            string completeDir = DiskOperations.CorrectDirectory(_TestTempDirectory) + tempDirectoryName + "\\";
            DiskOperations.CheckAndCreateDirectory(completeDir);

            //先构建一个文件
            StreamWriter sw = new StreamWriter(_TestTempDirectory + fileName, false);
            sw.Write("测试文件，随意删除，不过见到此文件就说明垃圾清理工作没有做好-_-!");
            sw.Close();
            //拷贝
            CommandRunner.CopyToDirectory(_TestTempDirectory + fileName, completeDir);
            Assert.IsTrue(File.Exists(completeDir + fileName));
            //清理
            CommandRunner.CleanUpDirectory(_TestTempDirectory);
            CommandRunner.DeleteFile(completeDir + fileName);
            Assert.IsTrue(!File.Exists(completeDir + fileName));
        }

        [Test,Description("测试压缩文件夹与解压缩文件")]
        public void Test3()
        {
            const string fileName = "testFile.txt";
            string targetFile = _TestTempDirectory + "test.rar";
            //先构建一个文件
            StreamWriter sw = new StreamWriter(_TestTempDirectory + fileName, false);
            sw.Write("测试文件，随意删除，不过见到此文件就说明垃圾清理工作没有做好-_-!");
            sw.Close();
            //压缩该文件夹
            CommandRunner.RarDirectoryToFile(targetFile, _TestTempDirectory);
            Assert.IsTrue(File.Exists(targetFile));
            //解压缩
            string tempDir = DiskOperations.CorrectDirectory(_TestTempDirectory) + "Temps" + "\\";
            Assert.IsTrue(!File.Exists(tempDir + fileName));
            DiskOperations.CheckAndCreateDirectory(tempDir);
            CommandRunner.UnRarFileToDirectory(targetFile, tempDir,true);
            Assert.IsTrue(File.Exists(tempDir + fileName));
            //清理
            CommandRunner.CleanUpDirectory(tempDir);
            CommandRunner.CleanUpDirectory(_TestTempDirectory);
        }

        [Test,Description("bug:测试名字中间有空格或者目标地址有空格的压缩/解压缩情况")]
        public void Test4()
        {
            const string fileName = "testFile.txt";
            string targetFile = _TestTempDirectory + "t e s t.rar";
            StreamWriter sw = new StreamWriter(_TestTempDirectory + fileName, false);
            sw.Write("测试文件，随意删除，不过见到此文件就说明垃圾清理工作没有做好-_-!");
            sw.Close();
            CommandRunner.RarDirectoryToFile(targetFile, _TestTempDirectory);
            Assert.IsTrue(File.Exists(targetFile));

            string tempDir = DiskOperations.CorrectDirectory(_TestTempDirectory) + "T e m p s" + "\\";
            Assert.IsTrue(!File.Exists(tempDir + fileName));
            DiskOperations.CheckAndCreateDirectory(tempDir);
            CommandRunner.UnRarFileToDirectory(targetFile, tempDir, true);
            Assert.IsTrue(File.Exists(tempDir + fileName));

            CommandRunner.CleanUpDirectory(tempDir);
            CommandRunner.CleanUpDirectory(_TestTempDirectory);
        }
    }
}