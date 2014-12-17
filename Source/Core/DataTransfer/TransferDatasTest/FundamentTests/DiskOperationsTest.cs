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

            //������ʱ�����ļ���
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

        [Test, Description("���Ա���ʱ����ļ��д�������ȷ��")]
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

        [Test, Description("�������ݻָ�ʱ����ļ��д�������ȷ��")]
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


        [Test, Description("�����������Ŀ¼����")]
        public void Test3()
        {
            //����DownLoadFiles�ļ��е�����
            StaticConfigTable.DownloadFilesDirectory = @"C:\DataTemp\DownLoadFiles\";
            try
            {
                DiskOperations.PrepareForBackUp();
                Assert.Fail();
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("��ǰ����Ǩ�Ƶ������ļ����������������⣬��ΪTempDirectory�ļ��лᱻ������������Ҫ���ݶ�ʧ,�޷���TempDirectory�ļ���������BackUpDirectory����DownloadFilesDirectory", ae.Message);
            }

            //����BackUp�ļ��е�����
            StaticConfigTable.DownloadFilesDirectory = @"C:\ShiXinTech\DownLoadFiles\";
            StaticConfigTable.BackUpDirectory = @"C:\DataTemp\DataBackUp";
            try
            {
                DiskOperations.PrepareForBackUp();
                Assert.Fail();
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("��ǰ����Ǩ�Ƶ������ļ����������������⣬��ΪTempDirectory�ļ��лᱻ������������Ҫ���ݶ�ʧ,�޷���TempDirectory�ļ���������BackUpDirectory����DownloadFilesDirectory", ae.Message);
            }
            try
            {
                DiskOperations.PrepareForRestore();
                Assert.Fail();
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("��ǰ����Ǩ�Ƶ������ļ����������������⣬��ΪTempDirectory�ļ��лᱻ������������Ҫ���ݶ�ʧ,�޷���TempDirectory�ļ���������BackUpDirectory����DownloadFilesDirectory", ae.Message);
            }

            //����������
            StaticConfigTable.BackUpDirectory = @"C:\ShiXinTechDbBackUp";
            DiskOperations.PrepareForBackUp();
            DiskOperations.PrepareForRestore();
        }

        [Test,Description("����Assembly�Ķ�ȡ����ض���Ĵ���")]
        public void Test4()
        {
            ITableFilter theObj = DiskOperations.CreateTableFilterObj("TApplicationFilter.dll");
            Assert.IsNotNull(theObj);
            Assert.IsTrue(theObj is TApplicationFilter.TApplicationFilter);
        }

        [Test,Description("���������ļ���д�����ȡ")]
        public void Test5()
        {
            string targetConfigName = string.Format("{0}Config.txt", _TestTempDirectory);
            //д��
            List<string> theConfigs = new List<string>();
            theConfigs.Add("RuleName =It's a ruleName Test");
            theConfigs.Add("Parameter = (1999,1,1)-(2008,1,1)");
            DiskOperations.WriteLinesToFile(targetConfigName, theConfigs);
            Assert.IsTrue(File.Exists(targetConfigName));
            //��ȡ
            List<string> theReadConfigs = DiskOperations.ReadLinesFromFile(targetConfigName);
            Assert.AreEqual(theConfigs.Count, theReadConfigs.Count);
            for (int i = 0; i < theReadConfigs.Count; i++)
            {
                Assert.AreEqual(theConfigs[i],theReadConfigs[i]);
            }
            //����
            CommandRunner.CleanUpDirectory(_TestTempDirectory);
        }

        [Test]
        public void Test6()
        {
            string tempOfFiles = _TestTempDirectory + "FilesTemp\\";
            DiskOperations.CheckAndCreateDirectory(tempOfFiles);
            //ָ���ļ�����δ������ص��ļ�������ִ���κ�ɾ��
            string result = DiskOperations.DelFilesFromDirectory(tempOfFiles, "nonFilesKey", "", 1);
            Console.WriteLine(result);
            Assert.AreEqual("--ɾ���ļ���δɾ���κ��ļ�", result);

            //��ָ���ļ����м��������ļ�
            AddFileToDirectory(tempOfFiles, "xy1.txt");
            AddFileToDirectory(tempOfFiles, "xy2.txt");
            AddFileToDirectory(tempOfFiles, "xy3.txt");
            AddFileToDirectory(tempOfFiles, "notReleatedFile.txt");

            //δƥ��Key���ļ�����ɾ��
            string result1 = DiskOperations.DelFilesFromDirectory(tempOfFiles, "nonFilesKey", "", 1);
            Console.WriteLine(result1);
            Assert.AreEqual("--ɾ���ļ���δɾ���κ��ļ�", result);
            Assert.IsTrue(File.Exists(tempOfFiles + "xy1.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "xy2.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "xy3.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "notReleatedFile.txt"));

            //ƥ��Key,δָ���ܱ�������,��������紴����xy1ɾ��
            string result2 = DiskOperations.DelFilesFromDirectory(tempOfFiles, "xy", "", 2);
            Console.WriteLine(result2);
            Assert.AreEqual(@"--ɾ���ļ���C:\TestTempData\FilesTemp\xy1.txt", result2);
            Assert.IsTrue(File.Exists(tempOfFiles + "xy2.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "xy3.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "notReleatedFile.txt"));

            //ƥ��Key�������������ļ����ں��е�����������ɾ���κζ���
            string result3 = DiskOperations.DelFilesFromDirectory(tempOfFiles, "xy", "", 2);
            Console.WriteLine(result3);
            Assert.AreEqual("--ɾ���ļ���δɾ���κ��ļ�", result3);
            Assert.IsTrue(File.Exists(tempOfFiles + "xy2.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "xy3.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "notReleatedFile.txt"));

            //ƥ��Key,ָ���ܱ�������(xy2.txt)���������������xy3ɾ��
            string result4 = DiskOperations.DelFilesFromDirectory(tempOfFiles, "xy", tempOfFiles + "xy2.txt", 1);
            Console.WriteLine(result4);
            Assert.AreEqual(@"--ɾ���ļ���C:\TestTempData\FilesTemp\xy3.txt", result4);
            Assert.IsTrue(File.Exists(tempOfFiles + "xy2.txt"));
            Assert.IsTrue(File.Exists(tempOfFiles + "notReleatedFile.txt"));

            //�����ļ���
            CommandRunner.CleanUpDirectory(tempOfFiles);
        }

        public void AddFileToDirectory(string directory,string fileName)
        {
            StreamWriter sw = new StreamWriter(directory + fileName,false);
            sw.Write("ֻΪ���Զ�����������");
            sw.Close();
        }
    }
}