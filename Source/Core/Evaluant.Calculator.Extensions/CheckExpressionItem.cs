//add by wsl
//验证表达式内部有效性，验证单条表达式
using System;
using System.Collections.Generic;
using Evaluant.Calculator;

namespace Evaluant.Calculator.Extensions
{
    public class CheckExpressionItem
    {
        public event IsSalaryEndDateMonthEquelFunctionDelegate IsSalaryEndDateMonthEquelFunction;
        public event DoubleSalaryFunctionDelegate DoubleSalaryFunction;
        public event AnnualBonusTaxFunctionDelegate AnnualBonusTaxFunction;
        public event TaxWithPointFunctionDelegate TaxWithPointFunction;
        public event TaxFunctionDelegate TaxFunction;
        public event AnnualBonusForeignTaxFunctionDelegate AnnualBonusForeignTaxFunction;
        public event ForeignTaxFunctionDelegate ForeignTaxFunction;
        private string _ParameterName;
        private ExpressionItem _ExpressionItem;
        private readonly List<ExpressionItem> _ExpressionItemList;
        private string _Parameter;
        #region 属性
        /// <summary>
        /// 表达式是否大小写敏感
        /// </summary>
        private bool _IsDiffUpperOrLower;
        public bool IsDiffUpperOrLower
        {
            set { _IsDiffUpperOrLower = value; }
        }
        #endregion
        public CheckExpressionItem(string parameter, string parameterName, List<ExpressionItem> expressionItemList)
        {
            if (expressionItemList == null)
            {
                expressionItemList=new List<ExpressionItem>();
            }
            _Parameter = parameter;
            _ParameterName = parameterName;
            _ExpressionItemList = expressionItemList;
        }

        public bool CheckExpressionItemValid()
        {
            //格式化大小写敏感
            FormatAccordingtoIsDiffUpperOrLower();
            //获取字符串的对象信息
            _ExpressionItem = Utility.GetExpressionItemByParameter(_ExpressionItemList, _Parameter);
            _ExpressionItem.Expression = Utility.FormatExpressionBase(_ExpressionItem.Expression);
            //验证字符串中是否有敏感语法标识符
            CheckExpressionStringFieldValid();
            //分离字符串
            string[] fields = _ExpressionItem.Expression.Split(Utility.CalculateSymbols, StringSplitOptions.None);
            //验证表达式中的字段是否有效
            CheckExpressionFieldValid(fields);
            //格式化字符串
            string formattedExpression = FormatExpression(fields);
            //带入进行测试运算
            Expression exEvaluate = new Expression(formattedExpression);
            exEvaluate.TaxFunction += TaxFunction;
            exEvaluate.TaxWithPointFunction += TaxWithPointFunction;
            exEvaluate.AnnualBonusTaxFunction += AnnualBonusTaxFunction;
            exEvaluate.ForeignTaxFunction += ForeignTaxFunction;
            exEvaluate.AnnualBonusForeignTaxFunction += AnnualBonusForeignTaxFunction;
            exEvaluate.IsSalaryEndDateMonthEquelFunction += IsSalaryEndDateMonthEquelFunction;
            exEvaluate.DoubleSalaryFunction += DoubleSalaryFunction;
            object evaluateResult = exEvaluate.Evaluate();
            //验证参数的返回类型是否正确
            CheckResultDataType(evaluateResult);
            return true;
        }

        private void FormatAccordingtoIsDiffUpperOrLower()
        {
            if (!_IsDiffUpperOrLower)
            {
                _Parameter = Utility.FormatExpressionToDiffUpperOrLower(_Parameter);
                _ParameterName = Utility.FormatExpressionToDiffUpperOrLower(_ParameterName);
                foreach (ExpressionItem expressionItem in _ExpressionItemList)
                {
                    expressionItem.Parameter = Utility.FormatExpressionToDiffUpperOrLower(expressionItem.Parameter);
                    expressionItem.Expression = Utility.FormatExpressionToDiffUpperOrLower(expressionItem.Expression);
                }
            }
        }

        /// <summary>
        /// 验证参数的返回类型是否正确
        /// </summary>
        /// <param name="result"></param>
        private void CheckResultDataType(object result)
        {
            if (_ExpressionItem.EnumDataType == EnumDataType.Number) //数字型替换
            {
                decimal decimalResult;
                if (!Decimal.TryParse(result.ToString(), out decimalResult))
                {
                    throw new Exception("无法将" + _ExpressionItem.Parameter + "参数的计算结果转换为数字类型");
                }
            }
            if (_ExpressionItem.EnumDataType == EnumDataType.DateTime) //日期型替换
            {
                DateTime dateTimeResult;
                if (!DateTime.TryParse(result.ToString(), out dateTimeResult))
                {
                    throw new Exception("无法将" + _ExpressionItem.Parameter + "参数的计算结果转换为日期类型");
                }
            }
            if (_ExpressionItem.EnumDataType == EnumDataType.Other)
            {
                throw new Exception(_ExpressionItem.Parameter + "参数的数据类型不明，无法计算");
            }
        }

        #region 方法
        /// <summary>
        /// 验证字符串中是否有敏感语法标识符
        /// </summary>
        private void CheckExpressionStringFieldValid()
        {
            string[] fields = _ExpressionItem.Expression.Split(Utility.LanguageSymbols, StringSplitOptions.None);
            if(fields.Length>1)
            {
                throw new Exception("语法严重错误，系统无法解释计算公式表达式");
            }
        }

        /// <summary>
        /// 格式化字符串
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        private string FormatExpression(string[] fields)
        {
            string formattedExpression;
            //替换%为*0.01，因为%会被解释器解释为mod，所以在这里要做处理
            formattedExpression = _ExpressionItem.Expression.Replace("%", "*0.01");
            Random rd = new Random();
            foreach (string field in fields)
            {
                int i;
                //_ParameterName开头 && 数字结尾
                if (field.StartsWith(_ParameterName) && int.TryParse(field.Substring(_ParameterName.Length), out i))
                {
                    //将parameterName参数换成测试数据
                    if (Utility.GetDataTypeByParameter(_ExpressionItemList, field) == EnumDataType.Number)//数字型替换
                    {
                        formattedExpression = formattedExpression.Replace(field, rd.NextDouble().ToString());
                    }
                    if (Utility.GetDataTypeByParameter(_ExpressionItemList, field) == EnumDataType.DateTime)//日期型替换
                    {
                        formattedExpression =
                            formattedExpression.Replace(field,
                                                        "'" + rd.Next(1000, 3000) + "-" + rd.Next(1, 12) + "-" +
                                                        rd.Next(1, 28) + "'");
                    }
                }
            }
            return formattedExpression;
        }



        /// <summary>
        /// 验证表达式中的字段是否有效
        /// 目前主要验证%结尾的字段是否可以转换成数字*0.01
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        private bool CheckExpressionFieldValid(string[] fields)
        {
            foreach (string field in fields)
            {
                //是否是%结尾
                if (field.EndsWith("%"))
                {
                    double trydouble;
                    if (!double.TryParse(field.Substring(0, field.Length - 1), out trydouble))
                    //注意：不可用remove去掉%要用substring
                    {
                        throw new Exception("参数" + field + "是无效表达式");
                    }
                }
            }
            return true;
        }
        #endregion

    }
}
