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
        [Test,Description("���Ը����ַ�������Rule")]
        public void Test1()
        {
            Dictionary<string, string> theReadData = new Dictionary<string, string>();
            theReadData.Add("ȫ������", "Sep_Release1670:[TAccount(AccountFilter)][TAccountAuth];Hrmis_Release1670:[TLeaveRequest][TLeaveRequestItem(LeaveRequestItemFilter)][TLeaveRequestFlow]");
            List<TransferRule> theConvertedRules = RuleConverter.Convert(theReadData);
            //��һ������
            Assert.AreEqual(1, theConvertedRules.Count);
            TransferRule theRule = theConvertedRules[0];
            Assert.AreEqual("ȫ������", theRule.RuleName);
            Assert.AreEqual(2, theRule.DbsToTransfer.Count);
            //��һ�����ݿ�
            Assert.AreEqual("Sep_Release1670", theRule.DbsToTransfer[0].DbName);
            Assert.AreEqual(2, theRule.DbsToTransfer[0].TablesToTransfer.Count);
            Assert.AreEqual("TAccount", theRule.DbsToTransfer[0].TablesToTransfer[0].TableName);
            Assert.AreEqual("AccountFilter", theRule.DbsToTransfer[0].TablesToTransfer[0].TableFilterName);
            Assert.AreEqual("TAccountAuth", theRule.DbsToTransfer[0].TablesToTransfer[1].TableName);
            Assert.AreEqual("", theRule.DbsToTransfer[0].TablesToTransfer[1].TableFilterName);
            //�ڶ������ݿ�
            Assert.AreEqual("Hrmis_Release1670", theRule.DbsToTransfer[1].DbName);
            Assert.AreEqual(3, theRule.DbsToTransfer[1].TablesToTransfer.Count);
            Assert.AreEqual("TLeaveRequest", theRule.DbsToTransfer[1].TablesToTransfer[0].TableName);
            Assert.AreEqual("", theRule.DbsToTransfer[1].TablesToTransfer[0].TableFilterName);
            Assert.AreEqual("TLeaveRequestItem", theRule.DbsToTransfer[1].TablesToTransfer[1].TableName);
            Assert.AreEqual("LeaveRequestItemFilter", theRule.DbsToTransfer[1].TablesToTransfer[1].TableFilterName);
            Assert.AreEqual("TLeaveRequestFlow", theRule.DbsToTransfer[1].TablesToTransfer[2].TableName);
            Assert.AreEqual("", theRule.DbsToTransfer[1].TablesToTransfer[2].TableFilterName);
        }

        [Test,Description("���Կղ���ȷ�������ļ�")]
        public void Test2()
        {
            //������
            Dictionary<string, string> theReadData = new Dictionary<string, string>();
            theReadData.Add("ȫ������", ":Sep_Release1670:[TAccount(AccountFilter)][TAccountAuth];Hrmis_Release1670:[TLeaveRequest][TLeaveRequestItem(leaveRequestItemFilter)][TLeaveRequestFlow]");
            try
            {
                RuleConverter.Convert(theReadData);
                Assert.Fail();
            }
            catch(ApplicationException ae)
            {
                Assert.IsTrue(ae.Message.Contains("���ݵ�ǰ����Ǩ�Ƶ������ļ���ȡ�Ĺ�����ȷ�����·ֱ���2��������ַ���"));
            }

            //�ٸ�����
            Dictionary<string, string> theReadData1 = new Dictionary<string, string>();
            theReadData1.Add("ȫ������", "Sep_Release1670:[TAccount(AccountFilter)][TAccountAuth];Hrmis_Release1670:[TLeaveRequest][TLeaveRequestItem(leaveRequestItemFilter][TLeaveRequestFlow]");
            try
            {
                RuleConverter.Convert(theReadData1);
                Assert.Fail();
            }
            catch (ApplicationException ae)
            {
                Assert.IsTrue(ae.Message.Contains("���ݵ�ǰ����Ǩ�Ƶ������ļ���ȡ�Ĺ�����ȷ�����·ֱ���2��������ַ���"));
            }
        }

        [Test,Description("���Կսڵ�������ļ�Ҳ����ȷ��ȡ")]
        public void Test3()
        {
            Dictionary<string, string> theReadData = new Dictionary<string, string>();
            List<TransferRule> theConvertedRules = RuleConverter.Convert(theReadData);
            Assert.AreEqual(0,theConvertedRules.Count);
        }

        [Test,Description("���Թ����ַ���")]
        public void Test4()
        {
            Dictionary<string, string> theReadData = new Dictionary<string, string>();
            theReadData.Add("ȫ������", "Sep_Release1670:[TAccount][TAccountAuth];Hrmis_Release1670:[TLeaveRequest][TApplication(TApplicationFilter)][TLeaveRequestFlow]");
            List<TransferRule> theConvertedRules = RuleConverter.Convert(theReadData);
            Assert.AreEqual(1, theConvertedRules.Count);
            Console.WriteLine(theConvertedRules[0]);
        }
    }
}