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
        /// д��Config
        /// </summary>
        /// <param name="theRule">��д���Rule</param>
        /// <param name="startTime">��ʼʱ��(��������)</param>
        /// <param name="endTime">����ʱ��(��������)</param>
        public static void WriteConfig(TransferRule theRule, DateTime? startTime, DateTime? endTime)
        {
            TransferRule _TransferRule = theRule;
            Utility.AssertNotNull(theRule, Utility._Error_TransferRule_NotNull);

            List<string> needWrite = new List<string>();
            //д���������
            needWrite.Add(_TransferRuleNameKey + _TransferRule.RuleName);
            //д�����ַ�
            needWrite.Add(_TransferRuleKey + _TransferRule.MakeString());
            //д��������
            needWrite.Add(_TransderParameterKey + MakeParameters(startTime, endTime));
            string fullConfigName = DiskOperations.DataTemp_ForBackUpDirectory + _DefaultConfigName;
            DiskOperations.WriteLinesToFile(fullConfigName, needWrite);
        }

        public static string WriteConfigToString()
        {
            return Utility._Process_WriteConfig;
        }

        /// <summary>
        /// ��ȡConfig����ȡ��Ӧ�Ĺ����ַ�������ò���
        /// </summary>
        /// <param name="directoryWithConfigFile">Ĭ�����ô�ŵ��ļ��У�����Ӧ�ô���Ĭ�ϵ������ļ�����config.txt</param>
        /// <param name="ruleString">�����ַ���</param>
        /// <param name="startTime">��ʼʱ��</param>
        /// <param name="endTime">����ʱ��</param>
        /// <returns>��������</returns>
        public static string ReadConfig(string directoryWithConfigFile,out string ruleString, out DateTime? startTime, out DateTime? endTime)
        {
            //��ȡ���������ַ���
            string fullConfigName = DiskOperations.CorrectDirectory(directoryWithConfigFile) + _DefaultConfigName;
            List<string> readConfigs = DiskOperations.ReadLinesFromFile(fullConfigName);
            string theRuleNameString = FindLineContainsKey(readConfigs, _TransferRuleNameKey);
            string theRuleString = FindLineContainsKey(readConfigs, _TransferRuleKey);
            string theParameterString = FindLineContainsKey(readConfigs, _TransderParameterKey);
            //��Գ�������Ǩ�������Լ�Ǩ���ַ���
            GetParameter(theParameterString, out startTime, out endTime);
            ruleString = theRuleString.Replace(_TransferRuleKey,string.Empty);
            return theRuleNameString.Replace(_TransferRuleNameKey, string.Empty);
        }


        /// <summary>
        /// ����Rar�ļ�������Config����ΪRule��ʱ�����
        /// </summary>
        /// <param name="theRarFile">rar�ļ��ĵ�ַ</param>
        /// <param name="fromDay">��ʼʱ��</param>
        /// <param name="toDay">���ʱ��</param>
        /// <param name="directory">��ѹ�����ļ���</param>
        /// <param name="needClean">���������Ƿ���Ҫ�����ѹ�����ļ���</param>
        /// <param name="remainRarFile">���������Ƿ���Ҫ����Rar�ļ�</param>
        /// <returns>Ǩ�ƹ���</returns>
        public static TransferRule AnalyseRarData(string theRarFile, out DateTime? fromDay, out DateTime? toDay,string directory,bool needClean,bool remainRarFile)
        {
            //��ѹ��
            CommandRunner.AssertIsRarFile(theRarFile);
            CommandRunner.UnRarFileToDirectory(theRarFile, DiskOperations.CorrectDirectory(directory), true);

            //����config�ļ�
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

        #region ˽�з���

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
                throw new ApplicationException(string.Format("{0}{1}��ԭ����:{2}", Utility._Error_Parameter_ReadError, theParameterString, e.Message));
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