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
                            <ȫ������>Sep_Release1670:[TAccount][TAccountAuth];Hrmis_Release1670[TLeaveRequest][TLeaveRequestItem][TLeaveRequestFlow]</ȫ������>
                            <Ա������>Sep_Release1670:[TAccount][TAccountAuth]</Ա������>
                            <��������>Hrmis_Release1670:[TLeaveRequest][TLeaveRequestItem][TLeaveRequestFlow]</��������>
                            <ָ���·ݵĿ�������>Hrmis_Release1670:[TLeaveRequest(LeaveRequestFilter)][TLeaveRequestItem(TLeaveRequestItemFilter)][TLeaveRequestFlow(TLeaveRequestFlowFilter)]</ָ���·ݵĿ�������>
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

        [Test, Description("���������Ķ�ȡ")]
        public void Test1()
        {
            StaticConfigTable.ConfigFilePath = newConfigFilePath;
            StaticConfigTable.ReadToTable();

            Assert.AreEqual("User Id=sa;Password=123qweasd;Initial Catalog=@DbName@;Data Source=localhost", StaticConfigTable.ConnectionString);
            Assert.AreEqual(@"C:\DataTemp\", StaticConfigTable.TempDirectory);
            Assert.AreEqual(@"C:\ShiXinTech\DbBackUp\", StaticConfigTable.BackUpDirectory);

            Assert.AreEqual(4, StaticConfigTable.TranferRule.Count);
            Assert.AreEqual("Sep_Release1670:[TAccount][TAccountAuth];Hrmis_Release1670[TLeaveRequest][TLeaveRequestItem][TLeaveRequestFlow]", StaticConfigTable.TranferRule["ȫ������"]);
            Assert.AreEqual("Sep_Release1670:[TAccount][TAccountAuth]", StaticConfigTable.TranferRule["Ա������"]);
            Assert.AreEqual("Hrmis_Release1670:[TLeaveRequest][TLeaveRequestItem][TLeaveRequestFlow]", StaticConfigTable.TranferRule["��������"]);
            Assert.AreEqual("Hrmis_Release1670:[TLeaveRequest(LeaveRequestFilter)][TLeaveRequestItem(TLeaveRequestItemFilter)][TLeaveRequestFlow(TLeaveRequestFlowFilter)]", StaticConfigTable.TranferRule["ָ���·ݵĿ�������"]);

            //����
            StaticConfigTable.ConfigFilePath = Environment.CurrentDirectory + "\\TransferConfig.xml";
        }
    }
}
