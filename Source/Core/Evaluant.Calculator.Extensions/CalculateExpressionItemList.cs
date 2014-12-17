//add by wsl
//计算所有表达式
using System;
using System.Collections;
using System.Collections.Generic;

namespace Evaluant.Calculator.Extensions
{
    public class CalculateExpressionItemList
    {
        public event DoubleSalaryFunctionDelegate DoubleSalaryFunction;
        public event IsSalaryEndDateMonthEquelFunctionDelegate IsSalaryEndDateMonthEquelFunction;
        public event AnnualBonusForeignTaxFunctionDelegate AnnualBonusForeignTaxFunction;
        public event ForeignTaxFunctionDelegate ForeignTaxFunction;
        public event AnnualBonusTaxFunctionDelegate AnnualBonusTaxFunction;
        public event TaxWithPointFunctionDelegate TaxWithPointFunction;
        public event TaxFunctionDelegate TaxFunction;
        private readonly List<ExpressionItem> _ExpressionItemList;
        private string _ParameterName;
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

        public CalculateExpressionItemList(List<ExpressionItem> expressionItemList, string parameterName)
        {
            _ExpressionItemList = expressionItemList;
            _ParameterName = parameterName;
        }

        public void CalculateExpressionResult()
        {
            //处理大小写敏感
            FormatAccordingtoIsDiffUpperOrLower();
            //计算每个表达式
            CalculateEachExpressionResult();
        }
        /// <summary>
        /// 计算每个表达式
        /// </summary>
        private void CalculateEachExpressionResult()
        {
            foreach (ExpressionItem expressionItem in _ExpressionItemList)
            {
                if (expressionItem.ExpressionForCalculator == null)
                {
                    //将parameter中所用到的A1,A2,...An的值，递归替换成可计算的表达式
                    ChangeParameterForCalculator(expressionItem.Parameter);
                }
                //如果存在"<NULL>"说明条件值不够，不做计算，直接返回null
                if(expressionItem.ExpressionForCalculator.Contains(Utility.NULLString))
                {
                    expressionItem.Result = null;
                    continue;
                }
                Expression exEvaluate = new Expression(expressionItem.ExpressionForCalculator);
                exEvaluate.TaxFunction += TaxFunction;
                exEvaluate.TaxWithPointFunction += TaxWithPointFunction;
                exEvaluate.AnnualBonusTaxFunction += AnnualBonusTaxFunction;
                exEvaluate.ForeignTaxFunction += ForeignTaxFunction;
                exEvaluate.IsSalaryEndDateMonthEquelFunction += IsSalaryEndDateMonthEquelFunction;
                exEvaluate.DoubleSalaryFunction += DoubleSalaryFunction;
                exEvaluate.AnnualBonusForeignTaxFunction += AnnualBonusForeignTaxFunction;
                expressionItem.Result = exEvaluate.Evaluate();
            }
        }

        /// <summary>
        /// 处理大小写敏感
        /// </summary>
        private void FormatAccordingtoIsDiffUpperOrLower()
        {
            if (!_IsDiffUpperOrLower)
            {
                _ParameterName = Utility.FormatExpressionToDiffUpperOrLower(_ParameterName);
                foreach (ExpressionItem item in _ExpressionItemList)
                {
                    item.Parameter = Utility.FormatExpressionToDiffUpperOrLower(item.Parameter);
                    item.Expression = Utility.FormatExpressionToDiffUpperOrLower(item.Expression);
                }
            }
        }

        /// <summary>
        /// 将parameter中所用到的A1,A2,...An的值，递归替换成可计算的表达式
        /// 假设已知公式A3=A2+A1*50，A2=A1+3，A1=100，通过递归后A3=(100)+3+(100)*50
        /// 算法示例如下
        /// 传入参数parameter=A3
        /// GetItemByParameter根据parameter或取ExpressionItem对象，ExpressionItem.Parameter为A3，ExpressionItem.Expression为A2+A1*50
        /// GetParameterFromExpression将A2+A1*50中提取出相关参数A1和A2
        /// 先递归遍历A1，获取A1的表达式=100，替换A3公式中A1的部分，变为表达式A2+(100)*50
        /// 再递归A2，或取A2的表达式=A1+3，根据GetParameterFromExpression发现A2中有相关参数A1，则再次遍历A1，替换A2公式中A1的部分，A2变为表达式(100)+3
        /// A2递归结束后，替换A3公式中A2的部分，变为表达式(100)+3+(100)*50
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private object ChangeParameterForCalculator(string parameter)
        {
            ExpressionItem expressionItem = Utility.GetExpressionItemByParameter(_ExpressionItemList, parameter);
            if (expressionItem == null)
            {
                throw new Exception(parameter + "没有定义，系统无法解释");
            }
            if (expressionItem.ExpressionForCalculator != null)
            {
                return expressionItem.ExpressionForCalculator;//已经递归，可直接返回结果
            }
            //如果存在"<NULL>"说明条件值不够，不做计算，直接返回null
            if (expressionItem.Expression.Contains(Utility.NULLString))
            {
                expressionItem.Expression = Utility.NULLString;
            }
            expressionItem.ExpressionForCalculator = expressionItem.Expression;
            //替换%为*0.01
            expressionItem.ExpressionForCalculator = expressionItem.ExpressionForCalculator.Replace("%", "*0.01");

            ArrayList paras = Utility.GetParameterFromExpression(expressionItem.Expression, _ParameterName); //获得相关参数，无重复

            for (int i = 0; i < paras.Count; i++)
            {
                expressionItem.ExpressionForCalculator =
                    expressionItem.ExpressionForCalculator.Replace(paras[i].ToString(),
                                                         "(" + ChangeParameterForCalculator(paras[i].ToString()) + ")");
            }
            return expressionItem.ExpressionForCalculator;
        }
    }
}