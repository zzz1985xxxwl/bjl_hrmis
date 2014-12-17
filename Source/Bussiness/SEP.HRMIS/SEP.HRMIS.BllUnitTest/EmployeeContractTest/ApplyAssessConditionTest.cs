using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class ApplyAssessConditionTest
    {
        [Test, Description("新增发起条件")]
        public void AddApplyAssessConditionTest()
        {
            ApplyAssessCondition item = new ApplyAssessCondition(1);
            item.ApplyAssessCharacterType = AssessCharacterType.PracticeII;
            item.ApplyDate = Convert.ToDateTime("2008-9-9");
            item.AssessScopeFrom = Convert.ToDateTime("2007-9-9");
            item.AssessScopeTo = Convert.ToDateTime("2009-9-9");
            List<ApplyAssessCondition> items = new List<ApplyAssessCondition>();
            AddApplyAssessCondition target = new AddApplyAssessCondition(items, item);
            target.Excute();
            Assert.IsTrue(items.Count == 1);
        }
        [Test, Description("修改发起条件")]
        public void UpdateApplyAssessConditionTest()
        {
            ApplyAssessCondition item = new ApplyAssessCondition(1);
            item.ConditionID = 1;
            item.ApplyAssessCharacterType = AssessCharacterType.PracticeII;
            item.ApplyDate = Convert.ToDateTime("2008-9-9");
            item.AssessScopeFrom = Convert.ToDateTime("2007-9-9");
            item.AssessScopeTo = Convert.ToDateTime("2009-9-9");
            List<ApplyAssessCondition> items = new List<ApplyAssessCondition>();
            items.Add(new ApplyAssessCondition(0));
            items.Add(new ApplyAssessCondition(1));
            items[0].ApplyAssessCharacterType = AssessCharacterType.PracticeII;
            items[0].ApplyDate = Convert.ToDateTime("2007-9-9");
            items[0].AssessScopeFrom = Convert.ToDateTime("2006-9-9");
            items[0].AssessScopeTo = Convert.ToDateTime("2008-9-9");
            items[1].ApplyAssessCharacterType = AssessCharacterType.PracticeII;
            items[1].ApplyDate = Convert.ToDateTime("2002-9-9");
            items[1].AssessScopeFrom = Convert.ToDateTime("2099-9-9");
            items[1].AssessScopeTo = Convert.ToDateTime("2100-9-9");

            UpdateApplyAssessCondition target = new UpdateApplyAssessCondition(items, item);
            target.Excute();
            Assert.IsTrue(DateTime.Compare(items[1].ApplyDate, Convert.ToDateTime("2008-9-9")) == 0);
            Assert.IsTrue(DateTime.Compare(items[1].AssessScopeFrom, Convert.ToDateTime("2007-9-9")) == 0);
            Assert.IsTrue(DateTime.Compare(items[1].AssessScopeTo, Convert.ToDateTime("2009-9-9")) == 0);
        }
        [Test, Description("删除发起条件")]
        public void DeleteApplyAssessConditionTest()
        {
            List<ApplyAssessCondition> items = new List<ApplyAssessCondition>();
            items.Add(new ApplyAssessCondition(0));
            items.Add(new ApplyAssessCondition(1));
            items[0].ApplyAssessCharacterType = AssessCharacterType.PracticeII;
            items[0].ApplyDate = Convert.ToDateTime("2007-9-9");
            items[0].AssessScopeFrom = Convert.ToDateTime("2006-9-9");
            items[0].AssessScopeTo = Convert.ToDateTime("2008-9-9");
            items[1].ApplyAssessCharacterType = AssessCharacterType.PracticeII;
            items[1].ApplyDate = Convert.ToDateTime("2002-9-9");
            items[1].AssessScopeFrom = Convert.ToDateTime("2099-9-9");
            items[1].AssessScopeTo = Convert.ToDateTime("2100-9-9");

            DeleteApplyAssessCondition target = new DeleteApplyAssessCondition(items, 1);
            target.Excute();
            Assert.IsTrue(items.Count == 1);
            Assert.IsTrue(items[0].ConditionID == 0);
        }
    }
}
