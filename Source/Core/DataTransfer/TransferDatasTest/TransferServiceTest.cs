using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading;
using NUnit.Framework;
using TransferDatas;

namespace TransferDatasTest
{
    [TestFixture]
    public class TransferServiceTest
    {
        private const string _Db1 = "TestDb1";
        private const string _Db2 = "TestDb2";
        private string _TestTempDirectory;
        private MockITransferDataLog _MockITransferDataLog;

        [TestFixtureSetUp]
        public void SetUp()
        {
            string currentPath = Environment.CurrentDirectory;
            StaticConfigTable.ConnectionString =  ConfigurationManager.AppSettings["ConnectionString"];
            StaticConfigTable.SetRunningConfigDefault();
            //������ʱ�����ļ���
            _TestTempDirectory = ConfigurationManager.AppSettings["TestTempDirectory"];
            Assert.IsNotNull(_TestTempDirectory);
            _TestTempDirectory = DiskOperations.CorrectDirectory(_TestTempDirectory);
            DiskOperations.CheckAndCreateDirectory(_TestTempDirectory);

            //���������ļ�
            string theTransferRuleConfig = string.Format(@"{0}\..\..\TestResources\TransferConfig.xml", currentPath);
            Assert.IsTrue(File.Exists(theTransferRuleConfig));
            CommandRunner.CopyToDirectory(theTransferRuleConfig, currentPath);
            //��ԭ2�����ݿ����ڲ���
            string rarFile = string.Format(@"{0}\..\..\TestResources\TestDbs.rar", currentPath);
            Assert.IsTrue(File.Exists(rarFile));
            CommandRunner.UnRarFileToDirectory(rarFile, _TestTempDirectory,true);
            Assert.IsTrue(File.Exists(_TestTempDirectory + "As_BackUp.bak"));
            Assert.IsTrue(File.Exists(_TestTempDirectory + "Crm_BackUp.bak"));
            SqlCommandRunner.RestoreDbFromFile(_Db1, _TestTempDirectory, _TestTempDirectory + "As_BackUp.bak");
            SqlCommandRunner.RestoreDbFromFile(_Db2, _TestTempDirectory, _TestTempDirectory + "Crm_BackUp.bak");
            //mock��־��¼
            _MockITransferDataLog = new MockITransferDataLog();
            TransferDataLogManager.SetLogInstance = _MockITransferDataLog;
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            CommandRunner.DeleteFile(Environment.CurrentDirectory + @"\TransferConfig.xml");
            SqlCommandRunner.DeleteDb(_Db1);
            SqlCommandRunner.DeleteDb(_Db2);
            CommandRunner.CleanUpDirectory(_TestTempDirectory);
        }

        //������Ҫ1����ʱ��,����������в��ɹ����鿴���н������״̬���ǡ����С�������Ҫ��������ʱ��
        [Test, Description("�����������ȫ����ʽ����Ǩ��(��ѡ����Hrmis������Crm�����б���в���)")]
        public void Test1()
        {
            //����
            BackUpStatus bs = new BackUpStatus();
            bs.AddStatusChangeObserver(new MockInfoObserver());
            TransferService.BackUpData("����ȫ����ʽ����Ǩ��", null, null, bs);
            Thread.Sleep(40000);
            Console.WriteLine(string.Format("״̬��{0}  �����ļ���ַ:{1}", bs.Status, bs.SuccessFileName));
            Console.WriteLine(string.Format("��ʼʱ�䣺{0}  ����ʱ��:{1}", bs.StartTime, bs.EndTime));
            Assert.AreEqual(bs.Status, Status.Success);
            Assert.IsFalse(string.IsNullOrEmpty(bs.SuccessFileName));

            //��մ���ԭ�����ݿ�
            DeleteAllTableData(_Db1);
            DeleteAllTableData(_Db2);
            Assert.AreEqual(0, GetCountOfTable("TEmployee", _Db1));
            Assert.AreEqual(0, GetCountOfTable("TCustomer", _Db2));

            //��ԭ����
            RestoreStatus rs = new RestoreStatus();
            rs.AddStatusChangeObserver(new MockInfoObserver());
            TransferService.RestoreData(bs.SuccessFullFileName, rs);
            Thread.Sleep(30000);
            Console.WriteLine(string.Format("״̬��{0}", rs.Status));
            Console.WriteLine(string.Format("��ʼʱ�䣺{0}  ����ʱ��:{1}", rs.StartTime, rs.EndTime));
            Assert.AreEqual( Status.Success,rs.Status);

            //���������Ƿ�ԭ�ɹ�
            Assert.AreEqual(118, GetCountOfTable("TEmployee", _Db1));
            Assert.AreEqual(1052, GetCountOfTable("TCustomer", _Db2));

            _MockITransferDataLog.PrintLogs();
            _MockITransferDataLog.ClearLogs();
        }

        [Test, Description("����ɸѡʽ����Ǩ��")]
        public void Test2()
        {
            //����
            BackUpStatus bs = new BackUpStatus();
            bs.AddStatusChangeObserver(new MockInfoObserver());
            TransferService.BackUpData("����ɸѡʽ����Ǩ��", new DateTime(2008, 12, 1), new DateTime(2009, 3, 1), bs);
            Thread.Sleep(30000);
            Console.WriteLine(string.Format("״̬��{0}  �����ļ���ַ:{1}", bs.Status, bs.SuccessFileName));
            Console.WriteLine(string.Format("��ʼʱ�䣺{0}  ����ʱ��:{1}", bs.StartTime, bs.EndTime));
            Assert.AreEqual(bs.Status, Status.Success);
            Assert.IsFalse(string.IsNullOrEmpty(bs.SuccessFileName));

            //��մ���ԭ�����ݿ�
            DeleteAllTableData(_Db1);
            Assert.AreEqual(0, GetCountOfTable("TApplication", _Db1));
            Assert.AreEqual(0, GetCountOfTable("TApplicationEmployee", _Db1));
            Assert.AreEqual(0, GetCountOfTable("TApplicationFlow", _Db1));
            Assert.AreEqual(0, GetCountOfTable("TEmployee", _Db1));
            DeleteAllTableData(_Db2);
            Assert.AreEqual(0, GetCountOfTable("TCustomer", _Db2));

            //��ԭ
            RestoreStatus rs = new RestoreStatus();
            rs.AddStatusChangeObserver(new MockInfoObserver());
            TransferService.RestoreData(bs.SuccessFullFileName, rs);
            Thread.Sleep(30000);
            Console.WriteLine(string.Format("״̬��{0}", rs.Status));
            Console.WriteLine(string.Format("��ʼʱ�䣺{0}  ����ʱ��:{1}", rs.StartTime, rs.EndTime));
            Assert.AreEqual(rs.Status, Status.Success);

            Assert.AreEqual(118, GetCountOfTable("TEmployee", _Db1));
            Assert.AreEqual(1052, GetCountOfTable("TCustomer", _Db2));
            Assert.AreEqual(169, GetCountOfTable("TApplication", _Db1));
            Assert.AreEqual(227, GetCountOfTable("TApplicationEmployee", _Db1));
            Assert.AreEqual(343, GetCountOfTable("TApplicationFlow", _Db1));

            _MockITransferDataLog.PrintLogs();
            _MockITransferDataLog.ClearLogs();
        }

        private class MockInfoObserver:IStatusChangeObserver
        {
            public void NewInfoAdded(string theNewInfo)
            {
                Console.WriteLine(theNewInfo);
            }
        }

        private class MockITransferDataLog:ITransferDataLog
        {
            public static string _Info;
            public static string _Warn;
            public static string _Error;

            #region ITransferDataLog ��Ա

            public void AddInfo(string info)
            {
                _Info += info;
                _Info += Environment.NewLine;
            }

            public void AddWarn(string warn)
            {
                _Warn += warn;
                _Warn += Environment.NewLine;
          
            }

            public void AddError(string error)
            {
                _Error += error;
                _Error += Environment.NewLine;
            }

            public void PrintLogs()
            {
                Console.WriteLine(string.Format("��Ϣ��{0}", _Info));
                Console.WriteLine(string.Format("���棺{0}", _Warn));
                Console.WriteLine(string.Format("����{0}", _Error));
            }

            public void ClearLogs()
            {
                _Info = null;
                _Warn = null;
                _Error = null;
            }

            #endregion
        }

        private int GetCountOfTable(string tableName, string dbName)
        {
            string command = string.Format("select count(*) as RetValue from {0}", tableName);
            using (SqlDataReader sdr = SqlCommandRunner.ExecuteReader(new SqlCommand(command), dbName))
            {
                while (sdr.Read())
                {
                    return int.Parse(sdr["RetValue"].ToString());
                }
            }
            throw new Exception("δ�ҵ�������");
        }

        private void DeleteAllTableData(string dbName)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string tableName in SqlCommandRunner.GetAllTables(dbName))
            {
                sb.AppendLine(string.Format("delete from {0} ", tableName));
            }
            SqlCommandRunner.DelAllFks(_Db1);
            SqlCommandRunner.ExecuteNonQuery(new SqlCommand(sb.ToString()), dbName);
        }
    }
}