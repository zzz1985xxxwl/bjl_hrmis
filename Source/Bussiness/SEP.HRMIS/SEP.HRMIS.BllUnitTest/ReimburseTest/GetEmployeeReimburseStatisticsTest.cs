using System;
using NUnit.Framework;
using SEP.HRMIS.Bll.Reimburse;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.ReimburseTest
{
    [TestFixture]
    public class GetEmployeeReimburseStatisticsTest
    {
        [Test, Description("拆分报销单")]
        public void SplitTotalCostTest()
        {
            //ReimburseItem reimburseItem = new ReimburseItem
            //    (ReimburseTypeEnum.CommunicationCost, 100, "");
            //GetEmployeeReimburseStatistics getEmployeeReimburseStatistics = new GetEmployeeReimburseStatistics();

            //Assert.AreEqual(50, getEmployeeReimburseStatistics.SplitTotalCost(reimburseItem, Convert.ToDateTime("2009-5-16"),
            //                                              Convert.ToDateTime("2009-5-20")));
            //Assert.AreEqual(50, getEmployeeReimburseStatistics.SplitTotalCost(reimburseItem, Convert.ToDateTime("2009-5-16"),
            //                                              Convert.ToDateTime("2009-5-30")));
            //Assert.AreEqual(50, getEmployeeReimburseStatistics.SplitTotalCost(reimburseItem, Convert.ToDateTime("2009-5-6"),
            //                                              Convert.ToDateTime("2009-5-15")));

            //Assert.AreEqual(100, getEmployeeReimburseStatistics.SplitTotalCost(reimburseItem, Convert.ToDateTime("2009-5-6"),
            //                                              Convert.ToDateTime("2009-5-30")));

            //reimburseItem = new ReimburseItem
            //    (ReimburseTypeEnum.CommunicationCost, 100, "");

            //Assert.AreEqual(50, getEmployeeReimburseStatistics.SplitTotalCost(reimburseItem, Convert.ToDateTime("2009-7-1"),
            //                                  Convert.ToDateTime("2009-7-31")));
        }
    }
}