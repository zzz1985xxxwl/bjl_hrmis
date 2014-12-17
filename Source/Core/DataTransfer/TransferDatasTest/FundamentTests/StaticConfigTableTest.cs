using System;
using System.IO;
using NUnit.Framework;
using TransferDatas;

namespace TransferDatasTest
{
    [TestFixture]
    public class StaticConfigTableTest
    {
        private readonly string newConfigFilePath = Environment.CurrentDirectory + "\\TestConfig.xml"; 

        [SetUp]
        public void SetUp()
        {
            StreamWriter sw = new StreamWriter(File.Create(newConfigFilePath));
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sw.Write(@"<configuration>
                        <ConnectionString>User Id=sa;Password=123qweasd;Initial Catalog=@DbName@;Data Source=localhost</ConnectionString>
                        <TransferRule>
                            <全部数据>Sep_Release1670:[TAccount][TAccountAuth];Hrmis_Release1670[TLeaveRequest][TLeaveRequestItem][TLeaveRequestFlow]</全部数据>
                            <员工数据>Sep_Release1670:[TAccount][TAccountAuth]</员工数据>
                            <考勤数据>Hrmis_Release1670:[TLeaveRequest][TLeaveRequestItem][TLeaveRequestFlow]</考勤数据>
                            <指定月份的考勤数据>Hrmis_Release1670:[TLeaveRequest(LeaveRequestFilter)][TLeaveRequestItem(TLeaveRequestItemFilter)][TLeaveRequestFlow(TLeaveRequestFlowFilter)]</指定月份的考勤数据>
                        </TransferRule>
                        <TempDirectory>C:\DataTemp\</TempDirectory>
                        <BackUpDirectory>C:\ShiXinTech\DbBackUp\</BackUpDirectory>
                        </configuration>");
            sw.Flush();
            sw.Close();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(newConfigFilePath);
        }

        [Test, Description("测试正常的读取")]
        public void Test1()
        {
            StaticConfigTable.ConfigFilePath = newConfigFilePath;
            StaticConfigTable.ReadToTable();

            Assert.AreEqual("User Id=sa;Password=123qweasd;Initial Catalog=@DbName@;Data Source=localhost", StaticConfigTable.ConnectionString);
            Assert.AreEqual(@"C:\DataTemp\", StaticConfigTable.TempDirectory);
            Assert.AreEqual(@"C:\ShiXinTech\DbBackUp\", StaticConfigTable.BackUpDirectory);

            Assert.AreEqual(4, StaticConfigTable.TranferRule.Count);
            Assert.AreEqual("Sep_Release1670:[TAccount][TAccountAuth];Hrmis_Release1670[TLeaveRequest][TLeaveRequestItem][TLeaveRequestFlow]", StaticConfigTable.TranferRule["全部数据"]);
            Assert.AreEqual("Sep_Release1670:[TAccount][TAccountAuth]", StaticConfigTable.TranferRule["员工数据"]);
            Assert.AreEqual("Hrmis_Release1670:[TLeaveRequest][TLeaveRequestItem][TLeaveRequestFlow]", StaticConfigTable.TranferRule["考勤数据"]);
            Assert.AreEqual("Hrmis_Release1670:[TLeaveRequest(LeaveRequestFilter)][TLeaveRequestItem(TLeaveRequestItemFilter)][TLeaveRequestFlow(TLeaveRequestFlowFilter)]", StaticConfigTable.TranferRule["指定月份的考勤数据"]);

            //清理
            StaticConfigTable.ConfigFilePath = Environment.CurrentDirectory + "\\TransferConfig.xml";
        }
    }
}
