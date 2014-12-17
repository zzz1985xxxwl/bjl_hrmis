using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using NUnit.Framework;
using TransferDatas;

namespace TransferDatasTest
{
    [TestFixture]
    public class TLeaveRequestFilterTest
    {
        private string _ConnectionString;
        private string _TestTempDirectory;
        private const string _MainTableName = "TLeaveRequest";
        private const string _TempDbName = "TestTLeaveRequestTempDb";
        private const string _RestoreDbName = "TestTLeaveRequestRestoreDb";

        #region SeUp&TearDown

        [SetUp]
        public void SetUp()
        {
            //配置文件读取
            _ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            _TestTempDirectory = ConfigurationManager.AppSettings["TestTempDirectory"];
            Assert.IsNotNull(_ConnectionString);
            Assert.IsNotNull(_TestTempDirectory);
            StaticConfigTable.ConnectionString = _ConnectionString;
            DiskOperations.CheckAndCreateDirectory(DiskOperations.CorrectDirectory(_TestTempDirectory));
            //数据库资源路径
            string currentPath = Environment.CurrentDirectory;
            string theBackUpDb = string.Format(@"{0}\..\..\TestResources\TestTLeaveRequestFilterDb.bak", currentPath);
            Assert.IsTrue(File.Exists(theBackUpDb));
            //开始构建2个数据库
            SqlCommandRunner.RestoreDbFromFile(_TempDbName, DiskOperations.CorrectDirectory(_TestTempDirectory), theBackUpDb);
            SqlCommandRunner.RestoreDbFromFile(_RestoreDbName, DiskOperations.CorrectDirectory(_TestTempDirectory), theBackUpDb);
        }

        [TearDown]
        public void TearDown()
        {
            SqlCommandRunner.DeleteDb(_TempDbName);
            SqlCommandRunner.DeleteDb(_RestoreDbName);
        }

        #endregion

        [Test,Description("测试数据的筛选工作")]
        public void Test1()
        {
            //构建一个以TApplication为主的迁移策略，策略本身不会执行，仅仅是其中的一部分数据筛选功能进行测试
            TransferRule aTr = MakeTransferRule();
            ITableFilter theTarget = new TLeaveRequestFilter.TLeaveRequestFilter();
            theTarget.ConfigTheFilter(aTr, _MainTableName, _RestoreDbName, _TempDbName, _TempDbName, _RestoreDbName);
            Assert.AreEqual(2, aTr.DbsToTransfer[0].ProtectTableNames.Count);

            string before = PrintAllTableInfo(aTr);
            Console.WriteLine("筛选之前的表信息");
            Console.WriteLine(before);

            string target = theTarget.FilterTableData(new DateTime(2009, 6, 8), new DateTime(2009, 6, 9));
            Console.WriteLine("进行筛选");
            Console.WriteLine(target);

            string after = PrintAllTableInfo(aTr);
            Console.WriteLine();
            Console.WriteLine("筛选之后的表信息");
            Console.WriteLine(after);

            Assert.IsTrue(before.Contains("表名：TLeaveRequest,最小ID：1,最大ID：2,总行数：2"));
            Assert.IsTrue(before.Contains("表名：TLeaveRequestItem,最小ID：1,最大ID：2,总行数：2"));
            Assert.IsTrue(before.Contains("表名：TLeaveRequestFlow,最小ID：1,最大ID：4,总行数：4"));

            Assert.IsTrue(target.Contains("表TLeaveRequest共计:总行数2，删减1行数据"));
            Assert.IsTrue(target.Contains("表TLeaveRequestItem共计:总行数2，删减1行数据"));
            Assert.IsTrue(target.Contains("表TLeaveRequestFlow共计:总行数4，删减2行数据"));

            Assert.IsTrue(after.Contains("表名：TLeaveRequest,最小ID：1,最大ID：1,总行数：1"));
            Assert.IsTrue(after.Contains("表名：TLeaveRequestItem,最小ID：1,最大ID：1,总行数：1"));
            Assert.IsTrue(after.Contains("表名：TLeaveRequestFlow,最小ID：1,最大ID：2,总行数：2"));
        }

        [Test, Description("测试对数据库进行还原工作")]
        public void Test2()
        {
            TransferRule aTr = MakeTransferRule();
            ITableFilter theTarget = new TLeaveRequestFilter.TLeaveRequestFilter();
            theTarget.ConfigTheFilter(aTr, _MainTableName, _RestoreDbName, _TempDbName, _RestoreDbName, _TempDbName);
            Assert.AreEqual(2, aTr.DbsToTransfer[0].ProtectTableNames.Count);

            //第一次测试：假设没有任何数据发生变化
            Console.WriteLine("第一次测试");
            Console.WriteLine("筛选数据");

            string target11 = theTarget.FilterTableData(new DateTime(2009, 6, 1), new DateTime(2009, 6, 30));
            Console.WriteLine(target11);
            Console.WriteLine("进行还原");
            string target12 = theTarget.RestoreTableData(new DateTime(2009, 6, 1), new DateTime(2009, 6, 30));
            Console.WriteLine(target12);
            //全部数据还原没有任何数据改变
            Assert.IsTrue(target12.Contains("表TLeaveRequest共计：增加0行,覆盖0行,删除0行"));
            Assert.IsTrue(target12.Contains("表TLeaveRequestItem共计：增加0行,覆盖0行,删除0行"));
            Assert.IsTrue(target12.Contains("表TLeaveRequestFlow共计：增加0行,覆盖0行,删除0行"));
            //第二次测试，分别模拟数据的增、删、改
            Console.WriteLine("第二次测试");
            MockChangment();
            Console.WriteLine("筛选数据");
            string target21 = theTarget.FilterTableData(new DateTime(2009, 6, 8), new DateTime(2009, 6, 13));
            Console.WriteLine(target21);
            Console.WriteLine("进行还原");
            string target22 = theTarget.RestoreTableData(new DateTime(2009, 6, 8), new DateTime(2009, 6, 13));
            Console.WriteLine(target22);

            //由于在Filter的时候已经过滤了TLeaveRequestFlow的2行数据，所以匹配之后将待还原数据库的2行数据也删除了
            Assert.IsTrue(target22.Contains("表TLeaveRequestFlow共计：增加1行,覆盖2行,删除2行"));
            Assert.IsTrue(target22.Contains("表TLeaveRequestItem共计：增加0行,覆盖0行,删除1行"));
            Assert.IsTrue(target22.Contains("表TLeaveRequest共计：增加0行,覆盖2行,删除0行"));
        }

        [Test, Description("bug:在新增请假数据的时候，会出现主键重复无法新增的信息")]
        public void Test3()
        {
            TransferRule aTr = MakeTransferRule();
            ITableFilter theTarget = new TLeaveRequestFilter.TLeaveRequestFilter();
            theTarget.ConfigTheFilter(aTr, _MainTableName, _RestoreDbName, _TempDbName, _RestoreDbName, _TempDbName);
            MockAddLeaveRequest();
            Console.WriteLine("筛选数据");
            string target21 = theTarget.FilterTableData(new DateTime(2009, 6, 15), new DateTime(2009, 6, 16));
            Console.WriteLine(target21);
            Console.WriteLine("进行还原");
            string target22 = theTarget.RestoreTableData(new DateTime(2009, 6, 15), new DateTime(2009, 6, 16));
            Console.WriteLine(target22);

            Assert.IsTrue(target22.Contains("表TLeaveRequestFlow共计：增加1行,覆盖0行,删除0行"));
            Assert.IsTrue(target22.Contains("表TLeaveRequestItem共计：增加1行,覆盖0行,删除0行"));
            Assert.IsTrue(target22.Contains("表TLeaveRequest共计：增加1行,覆盖0行,删除0行"));
        }

        private void MockAddLeaveRequest()
        { 
            string sqlCommand = @"
            declare @id int
            insert into tleaverequest(accountid,leaverequesttypeid,reason,submitdate,absentfrom,absentto,absenthours,diyprocess)
            values(3,2,'','2009-6-9','2009-6-15','2009-6-15',8,'')
            select @id = SCOPE_IDENTITY()
            insert into tleaverequestitem(leaverequestid,status,absentfrom,absentto,absenthours,nextprocessid)
            values(@id,3,'2009-6-15','2009-6-15',8,3)
            select @id = SCOPE_IDENTITY()
            insert into tleaverequestflow(leaveRequestItemId,operatorId,operation,operationTime,remark)
            values(@id,88,55,'2009-6-9','hello')";
            SqlCommandRunner.ExecuteNonQuery(new SqlCommand(sqlCommand), _TempDbName);
        }

        private void MockChangment()
        {
            string sqlCommand = @"
            --修改tleaverequest的2行数据
            update tleaverequest set absentHours = 999
            --删除tleaverequestItem的1行数据
            delete tleaverequestitem where pkid = 2
            --增加/修改tleaverequestflow的4行数据
            update tleaverequestflow set operatorId = 99
            insert into tleaverequestflow(leaveRequestItemId,operatorId,operation,operationTime,remark)
            values(1,88,55,'2009-6-19','hello')";
            SqlCommandRunner.ExecuteNonQuery(new SqlCommand(sqlCommand), _TempDbName);
        }

        private string PrintAllTableInfo(TransferRule aTr)
        {
            StringBuilder retVal = new StringBuilder();
            retVal.AppendLine(SqlCommandRunner.GetTableInfo(aTr.DbsToTransfer[0].TablesToTransfer[0].TableName, _TempDbName));
            retVal.AppendLine(SqlCommandRunner.GetTableInfo(aTr.DbsToTransfer[0].ProtectTableNames[0], _TempDbName));
            retVal.AppendLine(SqlCommandRunner.GetTableInfo(aTr.DbsToTransfer[0].ProtectTableNames[1], _TempDbName));
            return retVal.ToString();
        }

        public static TransferRule MakeTransferRule()
        {
            TransferRule aMockRule = new TransferRule();
            aMockRule.RuleName = "新建数据迁移策略";
            DbTransfer dt = new DbTransfer();
            dt.DbName = _RestoreDbName;
            TableTransfer tt = new TableTransfer();
            tt.TableName = _MainTableName;
            dt.AddTransferTable(tt);
            aMockRule.DbsToTransfer.Add(dt);

            return aMockRule;
        }
    }
}