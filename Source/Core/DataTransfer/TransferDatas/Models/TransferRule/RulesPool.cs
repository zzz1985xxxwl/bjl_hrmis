using System;
using System.Collections.Generic;

namespace TransferDatas
{
    public class RulesPool
    {
        private static List<TransferRule> _AllTransferRules;

        public static List<TransferRule> AllTransferRules
        {
            get
            {
                if (_AllTransferRules == null)
                {
                    StaticConfigTable.ReadToTable();
                    _AllTransferRules = RuleConverter.Convert(StaticConfigTable.TranferRule);
                }
                return _AllTransferRules;
            }
        }

        public static void ResetAllRules()
        {
            StaticConfigTable.ResetConfigs();
            StaticConfigTable.ReadToTable();
            _AllTransferRules = RuleConverter.Convert(StaticConfigTable.TranferRule);
        }

        public static TransferRule FindRuleByName(string ruleName)
        {
            foreach(TransferRule tr in AllTransferRules)
            {
                if(tr.RuleName == ruleName)
                {
                    return tr;
                }
            }
            throw new ApplicationException(string.Format("{0}{1}", Utility._Rule_NotFount, ruleName));
        }

        public static string FindRuleByNameToString()
        {
            return Utility._Process_PrepareRule;
        }
    }
}