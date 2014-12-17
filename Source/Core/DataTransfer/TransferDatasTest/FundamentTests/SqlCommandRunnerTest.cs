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
            //开始构建1数据库
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

        [Test, Description("测试数据库的约束获取")]
        public void Test1()
        {
            //获取并打印数据库中指定表的约束
            List<ConstraintInfo> cis = SqlCommandRunner.GetConstraintInfo(_MainTableName, _TempDbName);
            Assert.AreEqual(2, cis.Count);
            PrintConstraintInfo(cis);

            //放弃这些约束
            SqlCommandRunner.DropConstraintInfo(cis, _MainTableName, _TempDbName);
            List<ConstraintInfo> cis1 = SqlCommandRunner.GetConstraintInfo(_MainTableName, _TempDbName);
            Assert.AreEqual(0,cis1.Count);

            //重建约束
            SqlCommandRunner.RestoreConstraintInfo(cis, _MainTableName, _TempDbName);
            List<ConstraintInfo> cis2 = SqlCommandRunner.GetConstraintInfo(_MainTableName, _TempDbName);
            Assert.AreEqual(2, cis2.Count);
            PrintConstraintInfo(cis2);

            //比较约束
            for(int i = 0 ;i< 2;i++)
            {
                Assert.IsTrue(cis[i].Equals(cis2[i]));
            }
        }

        [Test,Description("测试删除表与还原表的命令")]
        public void Test2()
        {
            //删除数据库1的一个表
            SqlCommandRunner.DropTable(_MainTableName, _TempOtherDbName);
            //表没有了，表信息就没有办法打印出来
            try
            {
                Console.WriteLine(SqlCommandRunner.GetTableInfo(_MainTableName, _TempOtherDbName));
                Assert.Fail();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //拷贝数据库的表过来作为替换
            SqlCommandRunner.CopyTable(_MainTableName, _TempDbName, _TempOtherDbName);
            Console.WriteLine(SqlCommandRunner.GetTableInfo(_MainTableName, _TempOtherDbName));
        }

        [Test,Description("测试数据库备份")]
        public void Test3()
        {
            string targetName = string.Format("{0}{1}.bak",DiskOperations.CorrectDirectory(_TestTempDirectory),_TempDbName);
            SqlCommandRunner.BackUpDb(_TempDbName, targetName);
            Assert.IsTrue(File.Exists(targetName));
            CommandRunner.DeleteFile(targetName);
        }

        private void PrintConstraintInfo(List<ConstraintInfo> cis)
        {
            Console.WriteLine("开始打印约束信息");
            foreach (ConstraintInfo ci in cis)
            {
                Console.WriteLine(ci);
            }
        }
    }
}