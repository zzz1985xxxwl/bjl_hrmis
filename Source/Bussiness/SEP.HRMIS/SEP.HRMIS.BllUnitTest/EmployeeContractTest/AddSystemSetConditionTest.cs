using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.EmployeeContractTest
{
    [TestFixture]
    public class AddSystemSetConditionTest
    {
        #region 劳动合同
        [Test, Description("劳动合同签订一年以上，系统自动发起设置")]
        public void AddSystemSetConditionForLabourTest1()
        {
            IAddSystemSetCondition iAddSystemSetCondition = new AddSystemSetConditionForLabour();
            List<ApplyAssessCondition> actualApplyAssessConditions = new List<ApplyAssessCondition>();
            iAddSystemSetCondition.AddSystemSetCondition(actualApplyAssessConditions, Convert.ToDateTime("2007-7-1"), Convert.ToDateTime("2010-6-30"), Convert.ToDateTime("2007-7-8"));
            List<ApplyAssessCondition> expectedApplyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessCondition expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.ProbationI;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2007-9-14");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-7-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2007-9-30");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.ProbationII;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2007-11-28");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-10-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2007-12-31");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Normal;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2008-05-31");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-07-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-06-30");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Normal;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2009-05-31");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2008-07-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2009-06-30");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.NormalForContract;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2010-05-31");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-07-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2010-06-30");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2007-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-7-8");//入职时间为准
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2007-12-31");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2008-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2008-1-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-12-31");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2009-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2009-1-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2009-12-31");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            AssertConditions(expectedApplyAssessConditions, actualApplyAssessConditions);

        }
        [Test, Description("劳动合同签订一年以下，系统自动发起设置")]
        public void AddSystemSetConditionForLabourTest2()
        {
            IAddSystemSetCondition iAddSystemSetCondition = new AddSystemSetConditionForLabour();
            List<ApplyAssessCondition> actualApplyAssessConditions = new List<ApplyAssessCondition>();
            iAddSystemSetCondition.AddSystemSetCondition(actualApplyAssessConditions, Convert.ToDateTime("2007-7-1"), Convert.ToDateTime("2008-6-30"), Convert.ToDateTime("2006-1-1"));
            List<ApplyAssessCondition> expectedApplyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessCondition expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.ProbationII;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2007-8-15");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-7-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2007-8-31");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.NormalForContract;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2008-5-31");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-7-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-6-30");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2007-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-1-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2007-12-31");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            AssertConditions(expectedApplyAssessConditions, actualApplyAssessConditions);

        }

        #endregion

        #region 续签劳动合同
        [Test, Description("续签劳动合同，系统自动发起设置")]
        public void AddSystemSetConditionForContinuedLabourTest()
        {
            IAddSystemSetCondition iAddSystemSetCondition = new AddSystemSetConditionForContinuedLabour();
            List<ApplyAssessCondition> actualApplyAssessConditions = new List<ApplyAssessCondition>();
            iAddSystemSetCondition.AddSystemSetCondition(actualApplyAssessConditions, Convert.ToDateTime("2007-7-1"), Convert.ToDateTime("2010-6-30"), Convert.ToDateTime("2007-9-1"));
            List<ApplyAssessCondition> expectedApplyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessCondition expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Normal;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2008-05-31");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-7-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-06-30");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0); 
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Normal;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2009-05-31");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2008-07-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2009-06-30");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.NormalForContract;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2010-05-31");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-07-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2010-06-30");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2007-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-9-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2007-12-31");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2008-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2008-1-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-12-31");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2009-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2009-1-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2009-12-31");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            AssertConditions(expectedApplyAssessConditions, actualApplyAssessConditions);

        }

        #endregion

        #region 实习协议
        [Test, Description("实习协议，在4月1之后开始实习，在第二年的4月1之后结束实习，系统自动发起设置")]
        public void AddSystemSetConditionForPracticeTest1()
        {
            IAddSystemSetCondition iAddSystemSetCondition = new AddSystemSetConditionForPractice();
            List<ApplyAssessCondition> actualApplyAssessConditions = new List<ApplyAssessCondition>();
            iAddSystemSetCondition.AddSystemSetCondition(actualApplyAssessConditions, Convert.ToDateTime("2007-7-1"), Convert.ToDateTime("2008-6-30"), Convert.ToDateTime("0001-1-1"));
            List<ApplyAssessCondition> expectedApplyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessCondition expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.PracticeI;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2008-3-5");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-07-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-3-31");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.PracticeII;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2008-6-15");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-07-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-06-30");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2007-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-1-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2007-12-31");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            AssertConditions(expectedApplyAssessConditions, actualApplyAssessConditions);

        }
        [Test, Description("实习协议，在4月1之后开始实习，当年结束实习，系统自动发起设置")]
        public void AddSystemSetConditionForPracticeTest2()
        {
            IAddSystemSetCondition iAddSystemSetCondition = new AddSystemSetConditionForPractice();
            List<ApplyAssessCondition> actualApplyAssessConditions = new List<ApplyAssessCondition>();
            iAddSystemSetCondition.AddSystemSetCondition(actualApplyAssessConditions, Convert.ToDateTime("2008-4-1"), Convert.ToDateTime("2008-6-30"), Convert.ToDateTime("2007-4-1"));
            List<ApplyAssessCondition> expectedApplyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessCondition expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.PracticeII;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2008-06-15");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2008-04-01");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-06-30");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            AssertConditions(expectedApplyAssessConditions, actualApplyAssessConditions);

        }

        [Test, Description("实习协议，在4月1之前开始实习，当年4月1之后结束实习，系统自动发起设置")]
        public void AddSystemSetConditionForPracticeTest3()
        {
            IAddSystemSetCondition iAddSystemSetCondition = new AddSystemSetConditionForPractice();
            List<ApplyAssessCondition> actualApplyAssessConditions = new List<ApplyAssessCondition>();
            iAddSystemSetCondition.AddSystemSetCondition(actualApplyAssessConditions, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2008-6-30"), Convert.ToDateTime("0001-1-1"));
            List<ApplyAssessCondition> expectedApplyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessCondition expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.PracticeI;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2008-3-5");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2008-1-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-3-31");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0); 
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.PracticeII;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2008-6-15");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2008-1-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-06-30");
            expectedApplyAssessCondition.ConditionID = 0;
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            AssertConditions(expectedApplyAssessConditions, actualApplyAssessConditions);

        }

        #endregion

        #region 判断方法
        private static void AssertConditions(List<ApplyAssessCondition> expectedLists, List<ApplyAssessCondition> actualLists)
        {
            Assert.AreEqual(expectedLists.Count, actualLists.Count);
            int index = 0;
            foreach (ApplyAssessCondition ta in expectedLists)
            {
                AssertCondition(ta, actualLists[index++]);
            }
        }
        private static void AssertCondition(ApplyAssessCondition expected, ApplyAssessCondition actual)
        {
            Assert.AreEqual(expected.ApplyAssessCharacterType, actual.ApplyAssessCharacterType);
            Assert.AreEqual(expected.ApplyDate, actual.ApplyDate);
            Assert.AreEqual(expected.AssessScopeFrom, actual.AssessScopeFrom);
            Assert.AreEqual(expected.AssessScopeTo, actual.AssessScopeTo);
            Assert.AreEqual(expected.ConditionID, actual.ConditionID);
            Assert.AreEqual(expected.EmployeeContractID, actual.EmployeeContractID);
        }
        #endregion
    }
}
