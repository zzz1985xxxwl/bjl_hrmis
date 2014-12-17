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
            //构建临时数据文件夹
            _TestTempDirectory = ConfigurationManager.AppSettings["TestTempDirectory"];
            Assert.IsNotNull(_TestTempDirectory);
            _TestTempDirectory = DiskOperations.CorrectDirectory(_TestTempDirectory);
            DiskOperations.CheckAndCreateDirectory(_TestTempDirectory);

            //拷贝配置文件
            string theTransferRuleConfig = string.Format(@"{0}\..\..\TestResources\TransferConfig.xml", currentPath);
            Assert.IsTrue(File.Exists(theTransferRuleConfig));
            CommandRunner.CopyToDirectory(theTransferRuleConfig, currentPath);
            //还原2个数据库用于测试
            string rarFile = string.Format(@"{0}\..\..\TestResources\TestDbs.rar", currentPath);
            Assert.IsTrue(File.Exists(rarFile));
            CommandRunner.UnRarFileToDirectory(rarFile, _TestTempDirectory,true);
            Assert.IsTrue(File.Exists(_TestTempDirectory + "As_BackUp.bak"));
            Assert.IsTrue(File.Exists(_TestTempDirectory + "Crm_BackUp.bak"));
            SqlCommandRunner.RestoreDbFromFile(_Db1, _TestTempDirectory, _TestTempDirectory + "As_BackUp.bak");
            SqlCommandRunner.RestoreDbFromFile(_Db2, _TestTempDirectory, _TestTempDirectory + "Crm_BackUp.bak");
            //mock日志记录
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

        //运行需要1分钟时间,如果单独运行不成功，查看运行结果，若状态还是“运行”，则需要调长运行时间
        [Test, Description("测试最基本的全覆盖式数据迁移(挑选了老Hrmis中许多表，Crm中所有表进行测试)")]
        public void Test1()
        {
            //备份
            BackUpStatus bs = new BackUpStatus();
            bs.AddStatusChangeObserver(new MockInfoObserver());
            TransferService.BackUpData("测试全覆盖式数据迁移", null, null, bs);
            Thread.Sleep(40000);
            Console.WriteLine(string.Format("状态：{0}  下载文件地址:{1}", bs.Status, bs.SuccessFileName));
            Console.WriteLine(string.Format("起始时间：{0}  结束时间:{1}", bs.StartTime, bs.EndTime));
            Assert.AreEqual(bs.Status, Status.Success);
            Assert.IsFalse(string.IsNullOrEmpty(bs.SuccessFileName));

            //清空待还原的数据库
            DeleteAllTableData(_Db1);
            DeleteAllTableData(_Db2);
            Assert.AreEqual(0, GetCountOfTable("TEmployee", _Db1));
            Assert.AreEqual(0, GetCountOfTable("TCustomer", _Db2));

            //还原数据
            RestoreStatus rs = new RestoreStatus();
            rs.AddStatusChangeObserver(new MockInfoObserver());
            TransferService.RestoreData(bs.SuccessFullFileName, rs);
            Thread.Sleep(30000);
            Console.WriteLine(string.Format("状态：{0}", rs.Status));
            Console.WriteLine(string.Format("起始时间：{0}  结束时间:{1}", rs.StartTime, rs.EndTime));
            Assert.AreEqual( Status.Success,rs.Status);

            //测试数据是否还原成功
            Assert.AreEqual(118, GetCountOfTable("TEmployee", _Db1));
            Assert.AreEqual(1052, GetCountOfTable("TCustomer", _Db2));

            _MockITransferDataLog.PrintLogs();
            _MockITransferDataLog.ClearLogs();
        }

        [Test, Description("测试筛选式数据迁移")]
        public void Test2()
        {
            //备份
            BackUpStatus bs = new BackUpStatus();
            bs.AddStatusChangeObserver(new MockInfoObserver());
            TransferService.BackUpData("测试筛选式数据迁移", new DateTime(2008, 12, 1), new DateTime(2009, 3, 1), bs);
            Thread.Sleep(30000);
            Console.WriteLine(string.Format("状态：{0}  下载文件地址:{1}", bs.Status, bs.SuccessFileName));
            Console.WriteLine(string.Format("起始时间：{0}  结束时间:{1}", bs.StartTime, bs.EndTime));
            Assert.AreEqual(bs.Status, Status.Success);
            Assert.IsFalse(string.IsNullOrEmpty(bs.SuccessFileName));

            //清空待还原的数据库
            DeleteAllTableData(_Db1);
            Assert.AreEqual(0, GetCountOfTable("TApplication", _Db1));
            Assert.AreEqual(0, GetCountOfTable("TApplicationEmployee", _Db1));
            Assert.AreEqual(0, GetCountOfTable("TApplicationFlow", _Db1));
            Assert.AreEqual(0, GetCountOfTable("TEmployee", _Db1));
            DeleteAllTableData(_Db2);
            Assert.AreEqual(0, GetCountOfTable("TCustomer", _Db2));

            //还原
            RestoreStatus rs = new RestoreStatus();
            rs.AddStatusChangeObserver(new MockInfoObserver());
            TransferService.RestoreData(bs.SuccessFullFileName, rs);
            Thread.Sleep(30000);
            Console.WriteLine(string.Format("状态：{0}", rs.Status));
            Console.WriteLine(string.Format("起始时间：{0}  结束时间:{1}", rs.StartTime, rs.EndTime));
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

            #region ITransferDataLog 成员

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
                Console.WriteLine(string.Format("信息：{0}", _Info));
                Console.WriteLine(string.Format("警告：{0}", _Warn));
                Console.WriteLine(string.Format("错误：{0}", _Error));
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
            throw new Exception("未找到行数量");
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