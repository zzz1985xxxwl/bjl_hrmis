//-----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: TransferService.cs
// ������: �ߺ�
// ��������: 2009-05-6
// ����: ���𽫶�ȡ����config��rule���ַ���ת����Ϊrule�Ķ���
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TransferDatas
{
    public class RuleConverter
    {
        /// <summary>
        /// ���𽫶�ȡ����config��rule���ַ���ת����Ϊrule�Ķ���
        /// </summary>
        /// <param name="theReadData">Key��ŵ��ǹ������֣�Value��ŵ��Ǹù�����ַ���</param>
        /// <returns>rule����</returns>
        public static List<TransferRule> Convert(Dictionary<string, string> theReadData)
        {
            List<TransferRule> retVal = new List<TransferRule>();
            foreach (KeyValuePair<string, string> kvp in theReadData)
            {
                TransferRule aNewRule = CalculateRules(kvp.Key, kvp.Value);
                aNewRule.Check(kvp.Key, kvp.Value);
                aNewRule.Construct();
                retVal.Add(aNewRule);
            }
            return retVal;
        }

        #region ˽�з���

        /// <summary>
        /// ���ݶ�ȡ��rule�ַ�������һ��Rule����
        /// </summary>
        /// <param name="theRuleName">rule������</param>
        /// <param name="theRuleStrings">rule���ַ���</param>
        private static TransferRule CalculateRules(string theRuleName, string theRuleStrings)
        {
            TransferRule tr = new TransferRule();
            tr.RuleName = theRuleName;

            Regex rules = new Regex(@"(?<DbName>\w+):(\[(?<TableName>\w+)\(?(?<FilterRule>\w*)\)?\])+");
            MatchCollection matchCollection = rules.Matches(theRuleStrings);
            foreach (Match aMatch in matchCollection)
            {
                //ȷ�����ݿ�
                Utility.AssertAreSame(1, aMatch.Groups["DbName"].Captures.Count, DbErrorString(theRuleName));
                DbTransfer dt = new DbTransfer();
                dt.DbName = aMatch.Groups["DbName"].Captures[0].Value;
                //ȷ����
                Utility.AssertAreSame(aMatch.Groups["TableName"].Captures.Count, aMatch.Groups["FilterRule"].Captures.Count, TableErrorString(theRuleName));
                for (int i = 0; i < aMatch.Groups["TableName"].Captures.Count; i++)
                {
                    TableTransfer tt = new TableTransfer();
                    tt.TableName = aMatch.Groups["TableName"].Captures[i].Value;
                    tt.TableFilterName = aMatch.Groups["FilterRule"].Captures[i].Value;
                    dt.AddTransferTable(tt);
                }
                tr.DbsToTransfer.Add(dt);
            }
            return tr;
        }

        private static string DbErrorString(string ruleName)
        {
            return string.Format("{0}{1}", Utility._Error_XmlConfig_DbName_NotFit, ruleName);
        }

        private static string TableErrorString(string ruleName)
        {
            return string.Format("{0}{1}", Utility._Error_XmlConfig_TableName_NotFit, ruleName);
        }

        #endregion
    }
}