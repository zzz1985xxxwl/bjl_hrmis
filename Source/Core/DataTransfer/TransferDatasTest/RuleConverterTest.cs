using System;
using System.Collections.Generic;
using System.Data;
using NUnit.Framework;
using TransferDatas;

namespace TransferDatasTest
{
    [TestFixture]
    public class RuleConverterTest
    {
        [Test,Description("测试根据字符串生成Rule")]
        public void Test1()
        {
            Dictionary<string, string> theReadData = new Dictionary<string, string>();
            theReadData.Add("全部数据", "Sep_Release1670:[TAccount(AccountFilter)][TAccountAuth];Hrmis_Release1670:[TLeaveRequest][TLeaveRequestItem(LeaveRequestItemFilter)][TLeaveRequestFlow]");
            List<TransferRule> theConvertedRules = RuleConverter.Convert(theReadData);
            //第一个规则
            Assert.AreEqual(1, theConvertedRules.Count);
            TransferRule theRule = theConvertedRules[0];
            Assert.AreEqual("全部数据", theRule.RuleName);
            Assert.AreEqual(2, theRule.DbsToTransfer.Count);
            //第一个数据库
            Assert.AreEqual("Sep_Release1670", theRule.DbsToTransfer[0].DbName);
            Assert.AreEqual(2, theRule.DbsToTransfer[0].TablesToTransfer.Count);
            Assert.AreEqual("TAccount", theRule.DbsToTransfer[0].TablesToTransfer[0].TableName);
            Assert.AreEqual("AccountFilter", theRule.DbsToTransfer[0].TablesToTransfer[0].TableFilterName);
            Assert.AreEqual("TAccountAuth", theRule.DbsToTransfer[0].TablesToTransfer[1].TableName);
            Assert.AreEqual("", theRule.DbsToTransfer[0].TablesToTransfer[1].TableFilterName);
            //第二个数据库
            Assert.AreEqual("Hrmis_Release1670", theRule.DbsToTransfer[1].DbName);
            Assert.AreEqual(3, theRule.DbsToTransfer[1].TablesToTransfer.Count);
            Assert.AreEqual("TLeaveRequest", theRule.DbsToTransfer[1].TablesToTransfer[0].TableName);
            Assert.AreEqual("", theRule.DbsToTransfer[1].TablesToTransfer[0].TableFilterName);
            Assert.AreEqual("TLeaveRequestItem", theRule.DbsToTransfer[1].TablesToTransfer[1].TableName);
            Assert.AreEqual("LeaveRequestItemFilter", theRule.DbsToTransfer[1].TablesToTransfer[1].TableFilterName);
            Assert.AreEqual("TLeaveRequestFlow", theRule.DbsToTransfer[1].TablesToTransfer[2].TableName);
            Assert.AreEqual("", theRule.DbsToTransfer[1].TablesToTransfer[2].TableFilterName);
        }

        [Test,Description("测试空不正确的配置文件")]
        public void Test2()
        {
            //多个标点
            Dictionary<string, string> theReadData = new Dictionary<string, string>();
            theReadData.Add("全部数据", ":Sep_Release1670:[TAccount(AccountFilter)][TAccountAuth];Hrmis_Release1670:[TLeaveRequest][TLeaveRequestItem(leaveRequestItemFilter)][TLeaveRequestFlow]");
            try
            {
                RuleConverter.Convert(theReadData);
                Assert.Fail();
            }
            catch(ApplicationException ae)
            {
                Assert.IsTrue(ae.Message.Contains("根据当前数据迁移的配置文件读取的规则不正确，以下分别是2个规则的字符串"));
            }

            //少个括号
            Dictionary<string, string> theReadData1 = new Dictionary<string, string>();
            theReadData1.Add("全部数据", "Sep_Release1670:[TAccount(AccountFilter)][TAccountAuth];Hrmis_Release1670:[TLeaveRequest][TLeaveRequestItem(leaveRequestItemFilter][TLeaveRequestFlow]");
            try
            {
                RuleConverter.Convert(theReadData1);
                Assert.Fail();
            }
            catch (ApplicationException ae)
            {
                Assert.IsTrue(ae.Message.Contains("根据当前数据迁移的配置文件读取的规则不正确，以下分别是2个规则的字符串"));
            }
        }

        [Test,Description("测试空节点的配置文件也能正确读取")]
        public void Test3()
        {
            Dictionary<string, string> theReadData = new Dictionary<string, string>();
            List<TransferRule> theConvertedRules = RuleConverter.Convert(theReadData);
            Assert.AreEqual(0,theConvertedRules.Count);
        }

        [Test,Description("测试规则字符串")]
        public void Test4()
        {
            Dictionary<string, string> theReadData = new Dictionary<string, string>();
            theReadData.Add("全部数据", "Sep_Release1670:[TAccount][TAccountAuth];Hrmis_Release1670:[TLeaveRequest][TApplication(TApplicationFilter)][TLeaveRequestFlow]");
            List<TransferRule> theConvertedRules = RuleConverter.Convert(theReadData);
            Assert.AreEqual(1, theConvertedRules.Count);
            Console.WriteLine(theConvertedRules[0]);
        }
    }
}