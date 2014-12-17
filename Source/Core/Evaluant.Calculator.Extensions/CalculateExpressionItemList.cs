//add by wsl
//�������б��ʽ
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
        #region ����
        /// <summary>
        /// ���ʽ�Ƿ��Сд����
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
            //�����Сд����
            FormatAccordingtoIsDiffUpperOrLower();
            //����ÿ�����ʽ
            CalculateEachExpressionResult();
        }
        /// <summary>
        /// ����ÿ�����ʽ
        /// </summary>
        private void CalculateEachExpressionResult()
        {
            foreach (ExpressionItem expressionItem in _ExpressionItemList)
            {
                if (expressionItem.ExpressionForCalculator == null)
                {
                    //��parameter�����õ���A1,A2,...An��ֵ���ݹ��滻�ɿɼ���ı��ʽ
                    ChangeParameterForCalculator(expressionItem.Parameter);
                }
                //�������"<NULL>"˵������ֵ�������������㣬ֱ�ӷ���null
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
        /// �����Сд����
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
        /// ��parameter�����õ���A1,A2,...An��ֵ���ݹ��滻�ɿɼ���ı��ʽ
        /// ������֪��ʽA3=A2+A1*50��A2=A1+3��A1=100��ͨ���ݹ��A3=(100)+3+(100)*50
        /// �㷨ʾ������
        /// �������parameter=A3
        /// GetItemByParameter����parameter��ȡExpressionItem����ExpressionItem.ParameterΪA3��ExpressionItem.ExpressionΪA2+A1*50
        /// GetParameterFromExpression��A2+A1*50����ȡ����ز���A1��A2
        /// �ȵݹ����A1����ȡA1�ı��ʽ=100���滻A3��ʽ��A1�Ĳ��֣���Ϊ���ʽA2+(100)*50
        /// �ٵݹ�A2����ȡA2�ı��ʽ=A1+3������GetParameterFromExpression����A2������ز���A1�����ٴα���A1���滻A2��ʽ��A1�Ĳ��֣�A2��Ϊ���ʽ(100)+3
        /// A2�ݹ�������滻A3��ʽ��A2�Ĳ��֣���Ϊ���ʽ(100)+3+(100)*50
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private object ChangeParameterForCalculator(string parameter)
        {
            ExpressionItem expressionItem = Utility.GetExpressionItemByParameter(_ExpressionItemList, parameter);
            if (expressionItem == null)
            {
                throw new Exception(parameter + "û�ж��壬ϵͳ�޷�����");
            }
            if (expressionItem.ExpressionForCalculator != null)
            {
                return expressionItem.ExpressionForCalculator;//�Ѿ��ݹ飬��ֱ�ӷ��ؽ��
            }
            //�������"<NULL>"˵������ֵ�������������㣬ֱ�ӷ���null
            if (expressionItem.Expression.Contains(Utility.NULLString))
            {
                expressionItem.Expression = Utility.NULLString;
            }
            expressionItem.ExpressionForCalculator = expressionItem.Expression;
            //�滻%Ϊ*0.01
            expressionItem.ExpressionForCalculator = expressionItem.ExpressionForCalculator.Replace("%", "*0.01");

            ArrayList paras = Utility.GetParameterFromExpression(expressionItem.Expression, _ParameterName); //�����ز��������ظ�

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