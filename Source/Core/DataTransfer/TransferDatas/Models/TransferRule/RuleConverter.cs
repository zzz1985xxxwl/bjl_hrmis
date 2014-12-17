//-----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: TransferService.cs
// 创建者: 倪豪
// 创建日期: 2009-05-6
// 概述: 负责将读取到的config中rule的字符串转换成为rule的对象
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TransferDatas
{
    public class RuleConverter
    {
        /// <summary>
        /// 负责将读取到的config中rule的字符串转换成为rule的对象
        /// </summary>
        /// <param name="theReadData">Key存放的是规则名字，Value存放的是该规则的字符串</param>
        /// <returns>rule集合</returns>
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

        #region 私有方法

        /// <summary>
        /// 根据读取的rule字符构建成一个Rule对象
        /// </summary>
        /// <param name="theRuleName">rule的名字</param>
        /// <param name="theRuleStrings">rule的字符串</param>
        private static TransferRule CalculateRules(string theRuleName, string theRuleStrings)
        {
            TransferRule tr = new TransferRule();
            tr.RuleName = theRuleName;

            Regex rules = new Regex(@"(?<DbName>\w+):(\[(?<TableName>\w+)\(?(?<FilterRule>\w*)\)?\])+");
            MatchCollection matchCollection = rules.Matches(theRuleStrings);
            foreach (Match aMatch in matchCollection)
            {
                //确定数据库
                Utility.AssertAreSame(1, aMatch.Groups["DbName"].Captures.Count, DbErrorString(theRuleName));
                DbTransfer dt = new DbTransfer();
                dt.DbName = aMatch.Groups["DbName"].Captures[0].Value;
                //确定表
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