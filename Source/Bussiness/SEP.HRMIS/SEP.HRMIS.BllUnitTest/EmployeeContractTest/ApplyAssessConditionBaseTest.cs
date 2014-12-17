using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class ApplyAssessConditionBaseTest
    {
        [Test, Description("劳动合同签订一年以上，系统自动发起设置")]
        public void AddSystemSetConditionForLabourTest1()
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

            ApplyAssessConditionBase.GenerateConditions(actualApplyAssessConditions);

            for(int i =0;i<actualApplyAssessConditions.Count-1;i++)
            {
                Assert.AreEqual(i, actualApplyAssessConditions[i].ConditionID);
                Assert.IsTrue(
                    DateTime.Compare(actualApplyAssessConditions[i].ApplyDate,
                                     actualApplyAssessConditions[i + 1].ApplyDate) <= 0);
            }


        }

    }
}
