using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP.HRMIS.Bll.EmployeeContract;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class ApplyAssessConditionUtilityTest
    {
        [Test, Description("GenerateConditionsTest")]
        public void GenerateConditionsTest()
        {
            List<ApplyAssessCondition> actualApplyAssessConditions = new List<ApplyAssessCondition>();
            actualApplyAssessConditions.Add(new ApplyAssessCondition(0));
            actualApplyAssessConditions.Add(new ApplyAssessCondition(0));
            actualApplyAssessConditions.Add(new ApplyAssessCondition(0));
            actualApplyAssessConditions.Add(new ApplyAssessCondition(0));
            actualApplyAssessConditions.Add(new ApplyAssessCondition(0));

            actualApplyAssessConditions[0].ApplyAssessCharacterType = AssessCharacterType.ProbationI;
            actualApplyAssessConditions[0].ApplyDate = Convert.ToDateTime("2008-1-8");
            actualApplyAssessConditions[0].AssessScopeFrom = Convert.ToDateTime("2008-1-8");
            actualApplyAssessConditions[0].AssessScopeTo = Convert.ToDateTime("2008-1-8");
            actualApplyAssessConditions[0].EmployeeContractID = 0;

            actualApplyAssessConditions[1].ApplyAssessCharacterType = AssessCharacterType.NormalForContract;
            actualApplyAssessConditions[1].ApplyDate = Convert.ToDateTime("2009-5-8");
            actualApplyAssessConditions[1].AssessScopeFrom = Convert.ToDateTime("2008-1-8");
            actualApplyAssessConditions[1].AssessScopeTo = Convert.ToDateTime("2008-1-8");
            actualApplyAssessConditions[1].EmployeeContractID = 0;

            actualApplyAssessConditions[2].ApplyAssessCharacterType = AssessCharacterType.ProbationII;
            actualApplyAssessConditions[2].ApplyDate = Convert.ToDateTime("2007-1-28");
            actualApplyAssessConditions[2].AssessScopeFrom = Convert.ToDateTime("2008-1-8");
            actualApplyAssessConditions[2].AssessScopeTo = Convert.ToDateTime("2008-1-8");
            actualApplyAssessConditions[2].EmployeeContractID = 0;

            actualApplyAssessConditions[3].ApplyAssessCharacterType = AssessCharacterType.Abnormal;
            actualApplyAssessConditions[3].ApplyDate = Convert.ToDateTime("2004-12-8");
            actualApplyAssessConditions[3].AssessScopeFrom = Convert.ToDateTime("2008-1-8");
            actualApplyAssessConditions[3].AssessScopeTo = Convert.ToDateTime("2008-1-8");
            actualApplyAssessConditions[3].EmployeeContractID = 0;

            actualApplyAssessConditions[4].ApplyAssessCharacterType = AssessCharacterType.Normal;
            actualApplyAssessConditions[4].ApplyDate = Convert.ToDateTime("2008-3-8");
            actualApplyAssessConditions[4].AssessScopeFrom = Convert.ToDateTime("2008-1-8");
            actualApplyAssessConditions[4].AssessScopeTo = Convert.ToDateTime("2008-1-8");
            actualApplyAssessConditions[4].EmployeeContractID = 0;

            ApplyAssessConditionUtility.GenerateConditions(actualApplyAssessConditions);

            for (int i = 0; i < actualApplyAssessConditions.Count - 1; i++)
            {
                Assert.AreEqual(i, actualApplyAssessConditions[i].ConditionID);
                Assert.IsTrue(
                    DateTime.Compare(actualApplyAssessConditions[i].ApplyDate,
                                     actualApplyAssessConditions[i + 1].ApplyDate) <= 0);
            }


        }
        [Test, Description("CreateAnnualConditionsTest,入职时间早于合同时间")]
        public void CreateAnnualConditionsTest1()
        {
            List<ApplyAssessCondition> expectedApplyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessCondition expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2007-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-1-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2007-12-31");
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2008-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2008-1-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-12-31");
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2009-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2009-1-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2009-12-31");
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            List<ApplyAssessCondition> actualApplyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessConditionUtility.CreateAnnualConditions(actualApplyAssessConditions, new DateTime(2007, 3, 3),
                                                               new DateTime(2010, 3, 2), new DateTime(2006, 1, 1));

            for (int i = 0; i < expectedApplyAssessConditions.Count - 1; i++)
            {
                Assert.AreEqual(expectedApplyAssessConditions[i].ApplyAssessCharacterType,
                                actualApplyAssessConditions[i].ApplyAssessCharacterType);
                Assert.AreEqual(expectedApplyAssessConditions[i].ApplyDate, actualApplyAssessConditions[i].ApplyDate);
                Assert.AreEqual(expectedApplyAssessConditions[i].AssessScopeFrom,
                                actualApplyAssessConditions[i].AssessScopeFrom);
                Assert.AreEqual(expectedApplyAssessConditions[i].AssessScopeTo,
                                actualApplyAssessConditions[i].AssessScopeTo);
            }
        }
        [Test, Description("CreateAnnualConditionsTest,入职时间等于于合同时间")]
        public void CreateAnnualConditionsTest2()
        {
            List<ApplyAssessCondition> expectedApplyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessCondition expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2007-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-3-3");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2007-12-31");
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2008-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2008-1-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-12-31");
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2009-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2009-1-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2009-12-31");
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            List<ApplyAssessCondition> actualApplyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessConditionUtility.CreateAnnualConditions(actualApplyAssessConditions, new DateTime(2007, 3, 3),
                                                               new DateTime(2010, 3, 2), new DateTime(2007, 3, 3));

            for (int i = 0; i < expectedApplyAssessConditions.Count - 1; i++)
            {
                Assert.AreEqual(expectedApplyAssessConditions[i].ApplyAssessCharacterType,
                                actualApplyAssessConditions[i].ApplyAssessCharacterType);
                Assert.AreEqual(expectedApplyAssessConditions[i].ApplyDate, actualApplyAssessConditions[i].ApplyDate);
                Assert.AreEqual(expectedApplyAssessConditions[i].AssessScopeFrom,
                                actualApplyAssessConditions[i].AssessScopeFrom);
                Assert.AreEqual(expectedApplyAssessConditions[i].AssessScopeTo,
                                actualApplyAssessConditions[i].AssessScopeTo);
            }
        }
        [Test, Description("CreateAnnualConditionsTest,入职时间晚于于合同时间")]
        public void CreateAnnualConditionsTest3()
        {
            List<ApplyAssessCondition> expectedApplyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessCondition expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2007-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-4-3");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2007-12-31");
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2008-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2008-1-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-12-31");
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2009-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2009-1-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2009-12-31");
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            List<ApplyAssessCondition> actualApplyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessConditionUtility.CreateAnnualConditions(actualApplyAssessConditions, new DateTime(2007, 3, 3),
                                                               new DateTime(2010, 3, 2), new DateTime(2007, 4, 3));

            for (int i = 0; i < expectedApplyAssessConditions.Count - 1; i++)
            {
                Assert.AreEqual(expectedApplyAssessConditions[i].ApplyAssessCharacterType,
                                actualApplyAssessConditions[i].ApplyAssessCharacterType);
                Assert.AreEqual(expectedApplyAssessConditions[i].ApplyDate, actualApplyAssessConditions[i].ApplyDate);
                Assert.AreEqual(expectedApplyAssessConditions[i].AssessScopeFrom,
                                actualApplyAssessConditions[i].AssessScopeFrom);
                Assert.AreEqual(expectedApplyAssessConditions[i].AssessScopeTo,
                                actualApplyAssessConditions[i].AssessScopeTo);
            }
        }
        [Test, Description("CreateAnnualConditionsTest,合同结束时间正好是12/31")]
        public void CreateAnnualConditionsTest4()
        {
            List<ApplyAssessCondition> expectedApplyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessCondition expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2007-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-4-3");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2007-12-31");
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2008-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2008-1-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-12-31");
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            expectedApplyAssessCondition = new ApplyAssessCondition(0);
            expectedApplyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Annual;
            expectedApplyAssessCondition.ApplyDate = Convert.ToDateTime("2009-12-1");
            expectedApplyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2009-1-1");
            expectedApplyAssessCondition.AssessScopeTo = Convert.ToDateTime("2009-12-31");
            expectedApplyAssessCondition.EmployeeContractID = 0;
            expectedApplyAssessConditions.Add(expectedApplyAssessCondition);

            List<ApplyAssessCondition> actualApplyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessConditionUtility.CreateAnnualConditions(actualApplyAssessConditions, new DateTime(2007, 3, 3),
                                                               new DateTime(2009, 12, 31), new DateTime(2007, 4, 3));

            for (int i = 0; i < expectedApplyAssessConditions.Count - 1; i++)
            {
                Assert.AreEqual(expectedApplyAssessConditions[i].ApplyAssessCharacterType,
                                actualApplyAssessConditions[i].ApplyAssessCharacterType);
                Assert.AreEqual(expectedApplyAssessConditions[i].ApplyDate, actualApplyAssessConditions[i].ApplyDate);
                Assert.AreEqual(expectedApplyAssessConditions[i].AssessScopeFrom,
                                actualApplyAssessConditions[i].AssessScopeFrom);
                Assert.AreEqual(expectedApplyAssessConditions[i].AssessScopeTo,
                                actualApplyAssessConditions[i].AssessScopeTo);
            }
        }

    }
}
