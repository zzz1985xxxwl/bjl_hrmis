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
            //������ʱ�����ļ���
            _TestTempDirectory = ConfigurationManager.AppSettings["TestTempDirectory"];
            Assert.IsNotNull(_TestTempDirectory);
            _TestTempDirectory = DiskOperations.CorrectDirectory(_TestTempDirectory);
            DiskOperations.CheckAndCreateDirectory(_TestTempDirectory);
        }
        
        [Test,Description("�����ļ�->�ļ��Ŀ���")]
        public void Test1()
        {
            const string fileName = "testFile.txt";
            const string targetFileName = "copyFile.txt";

            //�ȹ���һ���ļ�
            StreamWriter sw = new StreamWriter(_TestTempDirectory + fileName,false);
            sw.Write("�����ļ�������ɾ���������������ļ���˵������������û������-_-!");
            sw.Close();
            //����
            CommandRunner.CopyToFile(_TestTempDirectory + fileName, _TestTempDirectory + targetFileName);
            Assert.IsTrue(File.Exists(_TestTempDirectory + targetFileName));
            //����
            CommandRunner.CleanUpDirectory(_TestTempDirectory);
            Assert.IsTrue(!File.Exists(_TestTempDirectory + targetFileName));
        }

        [Test, Description("�����ļ�->�ļ��еĿ���")]
        public void Test2()
        {
            const string fileName = "testFile.txt";
            const string tempDirectoryName = "Temps";

            string completeDir = DiskOperations.CorrectDirectory(_TestTempDirectory) + tempDirectoryName + "\\";
            DiskOperations.CheckAndCreateDirectory(completeDir);

            //�ȹ���һ���ļ�
            StreamWriter sw = new StreamWriter(_TestTempDirectory + fileName, false);
            sw.Write("�����ļ�������ɾ���������������ļ���˵������������û������-_-!");
            sw.Close();
            //����
            CommandRunner.CopyToDirectory(_TestTempDirectory + fileName, completeDir);
            Assert.IsTrue(File.Exists(completeDir + fileName));
            //����
            CommandRunner.CleanUpDirectory(_TestTempDirectory);
            CommandRunner.DeleteFile(completeDir + fileName);
            Assert.IsTrue(!File.Exists(completeDir + fileName));
        }

        [Test,Description("����ѹ���ļ������ѹ���ļ�")]
        public void Test3()
        {
            const string fileName = "testFile.txt";
            string targetFile = _TestTempDirectory + "test.rar";
            //�ȹ���һ���ļ�
            StreamWriter sw = new StreamWriter(_TestTempDirectory + fileName, false);
            sw.Write("�����ļ�������ɾ���������������ļ���˵������������û������-_-!");
            sw.Close();
            //ѹ�����ļ���
            CommandRunner.RarDirectoryToFile(targetFile, _TestTempDirectory);
            Assert.IsTrue(File.Exists(targetFile));
            //��ѹ��
            string tempDir = DiskOperations.CorrectDirectory(_TestTempDirectory) + "Temps" + "\\";
            Assert.IsTrue(!File.Exists(tempDir + fileName));
            DiskOperations.CheckAndCreateDirectory(tempDir);
            CommandRunner.UnRarFileToDirectory(targetFile, tempDir,true);
            Assert.IsTrue(File.Exists(tempDir + fileName));
            //����
            CommandRunner.CleanUpDirectory(tempDir);
            CommandRunner.CleanUpDirectory(_TestTempDirectory);
        }

        [Test,Description("bug:���������м��пո����Ŀ���ַ�пո��ѹ��/��ѹ�����")]
        public void Test4()
        {
            const string fileName = "testFile.txt";
            string targetFile = _TestTempDirectory + "t e s t.rar";
            StreamWriter sw = new StreamWriter(_TestTempDirectory + fileName, false);
            sw.Write("�����ļ�������ɾ���������������ļ���˵������������û������-_-!");
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