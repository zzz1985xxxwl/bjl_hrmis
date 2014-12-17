//add by wsl
//解释器常量，公共方法
using System;
using System.Collections;
using System.Collections.Generic;

namespace Evaluant.Calculator.Extensions
{
    public class Utility
    {
        public static string[] FunctionName = new string[]
            {
                //字符串长的放在最上面!!!
                "IsSalaryEndDateMonthEquel",
                "AnnualBonusForeignTax",
                "JianJiaoJinYuan",
                "AnnualBonusTax",
                "JianFenJinJiao",
                "IEEERemainder",
                "DoubleSalary",
                "TaxWithPoint",
                "RoundToJiao",
                "OmitFenJiao",
                "RoundToYuan",
                "RoundToFen",
                "NoDealWith",
                "ForeignTax",
                "Ceiling",
                "OmitFen",
                "DateMax",
                "Log10",
                "Floor",
                "Round",
                "Range",
                "Acos",
                "Asin",
                "Atan",
                "Sign",
                "Sqrt",
                "Abs",
                "Cos",
                "Tax",
                "Exp",
                "Log",
                "Pow",
                "Sin",
                "Tan",
                "Max",
                "Min",
                "if",
            };
        public static string[] LanguageSymbols = new string[]
            {
                ";",
                ":",
                "?",
            };

        public static string[] CalculateSymbols = new string[]
            {
                //字符串长的放在最上面!!!
                //注意：高元排在最前面
                //两元运算符
                ">=",
                "<=",
                "==",
                //一元运算符
                "+",
                "-",
                "*",
                "/",
                "(",
                ")",
                "<",
                ">",
                ",",
                "=",
            };

        public static string NULLString = "<NULL>";

        /// <summary>
        /// 获得表达式中的相关参数，无重复
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <param name="parameterName"></param>
        public static ArrayList GetParameterFromExpression(string expression, string parameterName)
        {
            string[] paras = expression.Split(CalculateSymbols, StringSplitOptions.None);
            ArrayList ret_paras = new ArrayList();
            for (int i = 0; i < paras.Length; i++)
            {
                int j;
                //_ParameterName开头 && 数字结尾
                if (paras[i].StartsWith(parameterName)
                    && int.TryParse(paras[i].Substring(parameterName.Length), out j)
                    && !ret_paras.Contains(paras[i]))
                {
                    ret_paras.Add(paras[i]);
                }
            }
            ret_paras = DescSortParameter(ret_paras, parameterName);
            return ret_paras;
        }
        /// <summary>
        /// 根据Parameter参数倒叙
        /// </summary>
        /// <param name="ret_paras"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        private static ArrayList DescSortParameter(ArrayList ret_paras, string parameterName)
        {
            for (int i = 0; i < ret_paras.Count - 1; i++)
            {
                for (int j = i + 1; j < ret_paras.Count; j++)
                {
                    int a = int.Parse(ret_paras[i].ToString().Substring(parameterName.Length));
                    int b = int.Parse(ret_paras[j].ToString().Substring(parameterName.Length));
                    if (a < b)
                    {
                        string temp = ret_paras[i].ToString();
                        ret_paras[i] = ret_paras[j];
                        ret_paras[j] = temp;
                    }
                }
            }
            return ret_paras;
        }
        /// <summary>
        /// 基本格式化功能，去除空格
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string FormatExpressionBase(string expression)
        {
            expression = expression.Replace(" ", "");
            expression = expression.Replace("　", "");
            return expression;
        }
        /// <summary>
        /// 将formula内部字段替换成严格字符串，处理大小写敏感
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string FormatExpressionToDiffUpperOrLower(string expression)
        {
            expression = FormatExpressionBase(expression);
            expression = FormatKeywordInExpression(expression);
            #region 函数

            foreach (string functionName in FunctionName)
            {
                expression =
                    expression.Replace(FormatKeywordInExpression(functionName) + "(", functionName + "(");
            }
            #endregion

            return expression;
        }
        public static string FormatKeywordInExpression(string expression)
        {
            expression = expression.ToUpper();
            expression = expression.Replace("true".ToUpper(), "true");
            expression = expression.Replace("false".ToUpper(), "false");
            expression = expression.Replace("and".ToUpper(), "and");
            expression = expression.Replace("or".ToUpper(), "or");
            expression = expression.Replace("not".ToUpper(), "not");
            return expression;
        }

        /// <summary>
        /// 根据参数名找到相应对象
        /// </summary>
        /// <param name="expressionItemList"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static ExpressionItem GetExpressionItemByParameter(List<ExpressionItem> expressionItemList, string parameter)
        {
            foreach (ExpressionItem item in expressionItemList)
            {
                if (item.Parameter == parameter)
                {
                    return item;
                }
            }
            throw new Exception(parameter + "没有定义，系统无法解释");
        }
        /// <summary>
        /// 根据参数名称，返回该参数的数据类型
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="expressionItemList"></param>
        /// <returns></returns>
        public static EnumDataType GetDataTypeByParameter(List<ExpressionItem> expressionItemList, string parameter)
        {
            ExpressionItem item = GetExpressionItemByParameter(expressionItemList, parameter);
            if (item == null)
            {
                throw new Exception(parameter + "没有定义，系统无法解释");
            }
            if (item.EnumDataType == EnumDataType.Other)
            {
                throw new Exception(parameter + "参数的数据类型不明，无法计算");
            }
            return item.EnumDataType;
        }
    }
}
