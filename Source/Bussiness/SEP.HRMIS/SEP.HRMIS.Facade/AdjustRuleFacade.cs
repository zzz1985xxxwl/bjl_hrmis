using System.Collections.Generic;
using SEP.HRMIS.Bll.AdjustRules;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Adjusts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 
    /// </summary>
    public class AdjustRuleFacade : IAdjustRuleFacade
    {
        public void InsertAdjustRule(AdjustRule adjustRule)
        {
            new AddAdjustRule(adjustRule).Excute();
        }

        public void UpdateAdjustRule(AdjustRule adjustRule)
        {
            new UpdateAdjustRule(adjustRule).Excute();
        }

        public void DeleteAdjustRule(int pKID)
        {
            new DeleteAdjustRule(pKID).Excute();
        }

        public AdjustRule GetAdjustRuleByAdjustRuleID(int pKID)
        {
            return new GetAdjustRule().GetAdjustRuleByAdjustRuleID(pKID);
        }

        public List<AdjustRule> GetAdjustRuleByNameLike(string name)
        {
            return new GetAdjustRule().GetAdjustRuleByNameLike(name);
        }
    }
}