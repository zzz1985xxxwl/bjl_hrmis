//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: TransferService.cs
// 创建者: 倪豪
// 创建日期: 2009-05-6
// 概述: 测试外部接口的一个实现,TApplicationFilter是否满足期望
//       待测试数据库含有3张表，TApplication,TApplicationEmployee,
//       TApplicationFlow,这里的测试将虚拟一个作为临时过渡的数据库
//       一个从系统的数据库，，然后查看数据迁移运作是否正常
// ----------------------------------------------------------------
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
    public class ApplicationFilterTest
    {
        private string _ConnectionString;
        private string _TestTempDirectory;
        private const string _MainTableName = "TApplication";
        private const string _TempDbName = "TestApplicationFilterTempDb";
        private const string _RestoreDbName = "TestApplicationFilterRestoreDb";

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
            string theBackUpDb = string.Format(@"{0}\..\..\TestResources\TestApplicationFilterDb.bak", currentPath);
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

        [Test, Description("测试对临时数据库的数据筛选工作")]
        public void Test1()
        {
            //构建一个以TApplication为主的迁移策略，策略本身不会执行，仅仅是其中的一部分数据筛选功能进行测试
            TransferRule aTr = MakeTransferRule();
            ITableFilter theTarget = new TApplicationFilter.TApplicationFilter();
            theTarget.ConfigTheFilter(aTr,_MainTableName, _RestoreDbName, _TempDbName, _RestoreDbName,_TempDbName);
            Assert.AreEqual(2, aTr.DbsToTransfer[0].ProtectTableNames.Count);

            string before = PrintAllTableInfo(aTr);
            Console.WriteLine("筛选之前的表信息");
            Console.WriteLine(before);

            string target = theTarget.FilterTableData(new DateTime(2008, 10, 1), new DateTime(2008, 11, 1));
            Console.WriteLine("进行筛选");
            Console.WriteLine(target);

            string after = PrintAllTableInfo(aTr);
            Console.WriteLine();
            Console.WriteLine("筛选之后的表信息");
            Console.WriteLine(after);

            Assert.IsTrue(before.Contains("表名：TApplication,最小ID：9,最大ID：670,总行数：615"));
            Assert.IsTrue(before.Contains("表名：TApplicationEmployee,最小ID：8,最大ID：1363,总行数：842"));
            Assert.IsTrue(before.Contains("表名：TApplicationFlow,最小ID：1,最大ID：1297,总行数：1252"));

            Assert.IsTrue(target.Contains("表TApplication共计:总行数615，删减535行数据"));
            Assert.IsTrue(target.Contains("表TApplicationEmployee共计:总行数842，删减749行数据"));
            Assert.IsTrue(target.Contains("表TApplicationFlow共计:总行数1252，删减1086行数据"));

            Assert.IsTrue(after.Contains("表名：TApplication,最小ID：258,最大ID：342,总行数：80"));
            Assert.IsTrue(after.Contains("表名：TApplicationEmployee,最小ID：778,最大ID：891,总行数：93"));
            Assert.IsTrue(after.Contains("表名：TApplicationFlow,最小ID：463,最大ID：666,总行数：166"));
        }

        [Test, Description("测试对数据库进行还原工作")]
        public void Test2()
        {
            TransferRule aTr = MakeTransferRule();
            ITableFilter theTarget = new TApplicationFilter.TApplicationFilter();
            theTarget.ConfigTheFilter(aTr, _MainTableName,_RestoreDbName, _TempDbName, _RestoreDbName, _TempDbName);
            Assert.AreEqual(2, aTr.DbsToTransfer[0].ProtectTableNames.Count);

            //第一次测试：假设没有任何数据发生变化
            Console.WriteLine("第一次测试");
            Console.WriteLine("筛选数据");

            string target11 = theTarget.FilterTableData(new DateTime(2008, 10, 1), new DateTime(2008, 11, 1));
            Console.WriteLine(target11);
            Console.WriteLine("进行还原");
            string target12 = theTarget.RestoreTableData(new DateTime(2008, 10, 1), new DateTime(2008, 11, 1));
            Console.WriteLine(target12);
            //全部数据还原没有任何数据改变
            Assert.IsTrue(target12.Contains("表TApplication共计：增加0行,覆盖0行,删除0行"));
            Assert.IsTrue(target12.Contains("表TApplicationEmployee共计：增加0行,覆盖0行,删除0行"));
            Assert.IsTrue(target12.Contains("表TApplicationFlow共计：增加0行,覆盖0行,删除0行"));

            //第二次测试，分别模拟数据的增、删、改
            Console.WriteLine("第二次测试");
            MockChangment();
            Console.WriteLine("筛选数据");
            string target21 = theTarget.FilterTableData(new DateTime(2008, 10, 1), new DateTime(2008, 11, 1));
            Console.WriteLine(target21);
            Console.WriteLine("进行还原");
            string target22 = theTarget.RestoreTableData(new DateTime(2008, 10, 1), new DateTime(2008, 11, 1));
            Console.WriteLine(target22);

            Assert.IsTrue(target22.Contains("表TApplication共计：增加1行,覆盖1行,删除1行"));
            Assert.IsTrue(target22.Contains("表TApplicationEmployee共计：增加0行,覆盖0行,删除1行"));
            Assert.IsTrue(target22.Contains("表TApplicationFlow共计：增加0行,覆盖0行,删除2行"));
        }

        #region 私有方法

        private void MockChangment()
        {
            //主表新增一行记录，修改一行记录，删除一行记录
            //附表1删除一行记录，附表2删除2行记录
            string sqlCommand = @"insert into tapplication(applicantid,applicantName,applicationDate,applicationFrom,ApplicationTo,CostTime,Status,Reason,Type,OvertimeType)
                                values(1,'','2008-10-2','2008-10-2','2008-10-2',4,1,'',1,1)
                                update tapplication
                                set applicantName = 'modifyByTester'
                                where pkid =278
                                delete tapplication 
                                where pkid = 279
                                delete tapplicationEmployee
                                where applicationId = 279
                                delete tapplicationFlow
                                where applicationId = 279";

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
            tt.TableName = "TApplication";
            dt.AddTransferTable(tt);
            aMockRule.DbsToTransfer.Add(dt);

            return aMockRule;
        }

        #endregion

    }
}