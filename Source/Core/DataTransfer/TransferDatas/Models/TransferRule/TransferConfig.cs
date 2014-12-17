using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TransferDatas
{
    public class TransferConfig
    {
        private const string _DefaultConfigName = "config.txt";
        private const string _TransferRuleNameKey = "RuleName=";
        private const string _TransferRuleKey = "Rule=";
        private const string _TransderParameterKey = "Parameter=";
        private const int _NullTime = 0;

        /// <summary>
        /// 写入Config
        /// </summary>
        /// <param name="theRule">待写入的Rule</param>
        /// <param name="startTime">开始时间(方法参数)</param>
        /// <param name="endTime">结束时间(方法参数)</param>
        public static void WriteConfig(TransferRule theRule, DateTime? startTime, DateTime? endTime)
        {
            TransferRule _TransferRule = theRule;
            Utility.AssertNotNull(theRule, Utility._Error_TransferRule_NotNull);

            List<string> needWrite = new List<string>();
            //写规则的名字
            needWrite.Add(_TransferRuleNameKey + _TransferRule.RuleName);
            //写规则字符
            needWrite.Add(_TransferRuleKey + _TransferRule.MakeString());
            //写参数名字
            needWrite.Add(_TransderParameterKey + MakeParameters(startTime, endTime));
            string fullConfigName = DiskOperations.DataTemp_ForBackUpDirectory + _DefaultConfigName;
            DiskOperations.WriteLinesToFile(fullConfigName, needWrite);
        }

        public static string WriteConfigToString()
        {
            return Utility._Process_WriteConfig;
        }

        /// <summary>
        /// 读取Config，获取相应的规则字符串与调用参数
        /// </summary>
        /// <param name="directoryWithConfigFile">默认配置存放的文件夹，里面应该存有默认的配置文件，入config.txt</param>
        /// <param name="ruleString">规则字符串</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>规则名字</returns>
        public static string ReadConfig(string directoryWithConfigFile,out string ruleString, out DateTime? startTime, out DateTime? endTime)
        {
            //读取所有配置字符串
            string fullConfigName = DiskOperations.CorrectDirectory(directoryWithConfigFile) + _DefaultConfigName;
            List<string> readConfigs = DiskOperations.ReadLinesFromFile(fullConfigName);
            string theRuleNameString = FindLineContainsKey(readConfigs, _TransferRuleNameKey);
            string theRuleString = FindLineContainsKey(readConfigs, _TransferRuleKey);
            string theParameterString = FindLineContainsKey(readConfigs, _TransderParameterKey);
            //配对出参数，迁移名字以及迁移字符串
            GetParameter(theParameterString, out startTime, out endTime);
            ruleString = theRuleString.Replace(_TransferRuleKey,string.Empty);
            return theRuleNameString.Replace(_TransferRuleNameKey, string.Empty);
        }


        /// <summary>
        /// 分析Rar文件，并将Config解析为Rule与时间参数
        /// </summary>
        /// <param name="theRarFile">rar文件的地址</param>
        /// <param name="fromDay">开始时间</param>
        /// <param name="toDay">结合时间</param>
        /// <param name="directory">解压缩的文件夹</param>
        /// <param name="needClean">分析结束是否需要清理解压缩的文件夹</param>
        /// <param name="remainRarFile">分析结束是否需要保留Rar文件</param>
        /// <returns>迁移规则</returns>
        public static TransferRule AnalyseRarData(string theRarFile, out DateTime? fromDay, out DateTime? toDay,string directory,bool needClean,bool remainRarFile)
        {
            //解压缩
            CommandRunner.AssertIsRarFile(theRarFile);
            CommandRunner.UnRarFileToDirectory(theRarFile, DiskOperations.CorrectDirectory(directory), true);

            //分析config文件
            string ruleString;
            Dictionary<string, string> theRuleStrings = new Dictionary<string, string>();
            theRuleStrings.Add(ReadConfig(DiskOperations.CorrectDirectory(directory), out ruleString, out fromDay, out toDay), ruleString);
            List<TransferRule> allTransferRule = RuleConverter.Convert(theRuleStrings);
            if (allTransferRule.Count != 1)
            {
                throw new ApplicationException(Utility._Error_AnalyseRarData_Error);
            }

            if(needClean)
            {
                CommandRunner.CleanUpDirectory(DiskOperations.CorrectDirectory(directory));
            }
            if (!remainRarFile)
            {
                CommandRunner.DeleteFile(theRarFile);
            }

            return allTransferRule[0];
        }

        public static string AnalyseRarDataToString()
        {
            return Utility._Process_AnalyseRarData;
        }

        #region 私有方法

        private static void GetParameter(string theParameterString, out DateTime? startTime, out DateTime? endTime)
        {
            Regex rules = new Regex(@"(Parameter=\(Y(?<Year1>\d+)M(?<Month1>\d+)D(?<Day1>\d+)\)-\(Y(?<Year2>\d+)M(?<Month2>\d+)D(?<Day2>\d+)\))");
            Match aMatch = rules.Match(theParameterString);

            try
            {
                int year1 = int.Parse(aMatch.Groups["Year1"].Value);
                int month1 = int.Parse(aMatch.Groups["Month1"].Value);
                int day1 = int.Parse(aMatch.Groups["Day1"].Value);
                int year2 = int.Parse(aMatch.Groups["Year2"].Value);
                int month2 = int.Parse(aMatch.Groups["Month2"].Value);
                int day2 = int.Parse(aMatch.Groups["Day2"].Value);

                if (year1 == _NullTime)
                {
                    startTime = null;
                }
                else
                {
                    startTime = new DateTime(year1, month1, day1);
                }
                if (year2 == _NullTime)
                {
                    endTime = null;
                }
                else
                {
                    endTime = new DateTime(year2, month2, day2);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}，原因是:{2}", Utility._Error_Parameter_ReadError, theParameterString, e.Message));
            }
        }

        private static string MakeParameters(DateTime? stratTime, DateTime? endTime)
        {
            string startTimeString = stratTime.HasValue
                                         ? string.Format("Y{0}M{1}D{2}", stratTime.Value.Year, stratTime.Value.Month, stratTime.Value.Day)
                                         : string.Format("Y{0}M{0}D{0}", _NullTime);
            string endTimeString = endTime.HasValue
                                       ? string.Format("Y{0}M{1}D{2}", endTime.Value.Year, endTime.Value.Month, endTime.Value.Day)
                                       : string.Format("Y{0}M{0}D{0}", _NullTime);
            return string.Format("{0}({1})-({2})", _TransderParameterKey, startTimeString, endTimeString);
        }

        private static string FindLineContainsKey(List<string> allLines, string keyWord)
        {
            foreach (string aLine in allLines)
            {
                if (aLine.Contains(keyWord))
                {
                    return aLine;
                }
            }
            throw new ApplicationException(string.Format("{0}{1}", Utility._Error_Key_NotFound, keyWord));
        }

        #endregion
    }
}