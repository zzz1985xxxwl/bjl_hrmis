using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using NUnit.Framework;
using TransferDatas;

namespace TransferDatasTest
{
    [TestFixture]
    public class SqlCommandRunnerTest
    {
        private string _ConnectionString;
        private string _TestTempDirectory;
        private const string _MainTableName = "TApplication";
        private const string _TempDbName = "TestDb";
        private const string _TempOtherDbName = "TestDb1";

        #region SeUp&TearDown

        [TestFixtureSetUp]
        public void SetUp()
        {
            //�����ļ���ȡ
            _ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            _TestTempDirectory = ConfigurationManager.AppSettings["TestTempDirectory"];
            Assert.IsNotNull(_ConnectionString);
            Assert.IsNotNull(_TestTempDirectory);
            StaticConfigTable.ConnectionString = _ConnectionString;
            DiskOperations.CheckAndCreateDirectory(DiskOperations.CorrectDirectory(_TestTempDirectory));
            //���ݿ���Դ·��
            string currentPath = Environment.CurrentDirectory;
            string theBackUpDb = string.Format(@"{0}\..\..\TestResources\TestApplicationFilterDb.bak", currentPath);
            Assert.IsTrue(File.Exists(theBackUpDb));
            //��ʼ����1���ݿ�
            SqlCommandRunner.RestoreDbFromFile(_TempDbName, DiskOperations.CorrectDirectory(_TestTempDirectory), theBackUpDb);
            SqlCommandRunner.RestoreDbFromFile(_TempOtherDbName, DiskOperations.CorrectDirectory(_TestTempDirectory), theBackUpDb);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            SqlCommandRunner.DeleteDb(_TempDbName);
            SqlCommandRunner.DeleteDb(_TempOtherDbName);
        }

        #endregion

        [Test, Description("�������ݿ��Լ����ȡ")]
        public void Test1()
        {
            //��ȡ����ӡ���ݿ���ָ�����Լ��
            List<ConstraintInfo> cis = SqlCommandRunner.GetConstraintInfo(_MainTableName, _TempDbName);
            Assert.AreEqual(2, cis.Count);
            PrintConstraintInfo(cis);

            //������ЩԼ��
            SqlCommandRunner.DropConstraintInfo(cis, _MainTableName, _TempDbName);
            List<ConstraintInfo> cis1 = SqlCommandRunner.GetConstraintInfo(_MainTableName, _TempDbName);
            Assert.AreEqual(0,cis1.Count);

            //�ؽ�Լ��
            SqlCommandRunner.RestoreConstraintInfo(cis, _MainTableName, _TempDbName);
            List<ConstraintInfo> cis2 = SqlCommandRunner.GetConstraintInfo(_MainTableName, _TempDbName);
            Assert.AreEqual(2, cis2.Count);
            PrintConstraintInfo(cis2);

            //�Ƚ�Լ��
            for(int i = 0 ;i< 2;i++)
            {
                Assert.IsTrue(cis[i].Equals(cis2[i]));
            }
        }

        [Test,Description("����ɾ�����뻹ԭ�������")]
        public void Test2()
        {
            //ɾ�����ݿ�1��һ����
            SqlCommandRunner.DropTable(_MainTableName, _TempOtherDbName);
            //��û���ˣ�����Ϣ��û�а취��ӡ����
            try
            {
                Console.WriteLine(SqlCommandRunner.GetTableInfo(_MainTableName, _TempOtherDbName));
                Assert.Fail();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //�������ݿ�ı������Ϊ�滻
            SqlCommandRunner.CopyTable(_MainTableName, _TempDbName, _TempOtherDbName);
            Console.WriteLine(SqlCommandRunner.GetTableInfo(_MainTableName, _TempOtherDbName));
        }

        [Test,Description("�������ݿⱸ��")]
        public void Test3()
        {
            string targetName = string.Format("{0}{1}.bak",DiskOperations.CorrectDirectory(_TestTempDirectory),_TempDbName);
            SqlCommandRunner.BackUpDb(_TempDbName, targetName);
            Assert.IsTrue(File.Exists(targetName));
            CommandRunner.DeleteFile(targetName);
        }

        private void PrintConstraintInfo(List<ConstraintInfo> cis)
        {
            Console.WriteLine("��ʼ��ӡԼ����Ϣ");
            foreach (ConstraintInfo ci in cis)
            {
                Console.WriteLine(ci);
            }
        }
    }
}