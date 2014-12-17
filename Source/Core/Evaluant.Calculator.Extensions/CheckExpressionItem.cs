//add by wsl
//��֤���ʽ�ڲ���Ч�ԣ���֤�������ʽ
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
            //��ʽ����Сд����
            FormatAccordingtoIsDiffUpperOrLower();
            //��ȡ�ַ����Ķ�����Ϣ
            _ExpressionItem = Utility.GetExpressionItemByParameter(_ExpressionItemList, _Parameter);
            _ExpressionItem.Expression = Utility.FormatExpressionBase(_ExpressionItem.Expression);
            //��֤�ַ������Ƿ��������﷨��ʶ��
            CheckExpressionStringFieldValid();
            //�����ַ���
            string[] fields = _ExpressionItem.Expression.Split(Utility.CalculateSymbols, StringSplitOptions.None);
            //��֤���ʽ�е��ֶ��Ƿ���Ч
            CheckExpressionFieldValid(fields);
            //��ʽ���ַ���
            string formattedExpression = FormatExpression(fields);
            //������в�������
            Expression exEvaluate = new Expression(formattedExpression);
            exEvaluate.TaxFunction += TaxFunction;
            exEvaluate.TaxWithPointFunction += TaxWithPointFunction;
            exEvaluate.AnnualBonusTaxFunction += AnnualBonusTaxFunction;
            exEvaluate.ForeignTaxFunction += ForeignTaxFunction;
            exEvaluate.AnnualBonusForeignTaxFunction += AnnualBonusForeignTaxFunction;
            exEvaluate.IsSalaryEndDateMonthEquelFunction += IsSalaryEndDateMonthEquelFunction;
            exEvaluate.DoubleSalaryFunction += DoubleSalaryFunction;
            object evaluateResult = exEvaluate.Evaluate();
            //��֤�����ķ��������Ƿ���ȷ
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
        /// ��֤�����ķ��������Ƿ���ȷ
        /// </summary>
        /// <param name="result"></param>
        private void CheckResultDataType(object result)
        {
            if (_ExpressionItem.EnumDataType == EnumDataType.Number) //�������滻
            {
                decimal decimalResult;
                if (!Decimal.TryParse(result.ToString(), out decimalResult))
                {
                    throw new Exception("�޷���" + _ExpressionItem.Parameter + "�����ļ�����ת��Ϊ��������");
                }
            }
            if (_ExpressionItem.EnumDataType == EnumDataType.DateTime) //�������滻
            {
                DateTime dateTimeResult;
                if (!DateTime.TryParse(result.ToString(), out dateTimeResult))
                {
                    throw new Exception("�޷���" + _ExpressionItem.Parameter + "�����ļ�����ת��Ϊ��������");
                }
            }
            if (_ExpressionItem.EnumDataType == EnumDataType.Other)
            {
                throw new Exception(_ExpressionItem.Parameter + "�������������Ͳ������޷�����");
            }
        }

        #region ����
        /// <summary>
        /// ��֤�ַ������Ƿ��������﷨��ʶ��
        /// </summary>
        private void CheckExpressionStringFieldValid()
        {
            string[] fields = _ExpressionItem.Expression.Split(Utility.LanguageSymbols, StringSplitOptions.None);
            if(fields.Length>1)
            {
                throw new Exception("�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            }
        }

        /// <summary>
        /// ��ʽ���ַ���
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        private string FormatExpression(string[] fields)
        {
            string formattedExpression;
            //�滻%Ϊ*0.01����Ϊ%�ᱻ����������Ϊmod������������Ҫ������
            formattedExpression = _ExpressionItem.Expression.Replace("%", "*0.01");
            Random rd = new Random();
            foreach (string field in fields)
            {
                int i;
                //_ParameterName��ͷ && ���ֽ�β
                if (field.StartsWith(_ParameterName) && int.TryParse(field.Substring(_ParameterName.Length), out i))
                {
                    //��parameterName�������ɲ�������
                    if (Utility.GetDataTypeByParameter(_ExpressionItemList, field) == EnumDataType.Number)//�������滻
                    {
                        formattedExpression = formattedExpression.Replace(field, rd.NextDouble().ToString());
                    }
                    if (Utility.GetDataTypeByParameter(_ExpressionItemList, field) == EnumDataType.DateTime)//�������滻
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
        /// ��֤���ʽ�е��ֶ��Ƿ���Ч
        /// Ŀǰ��Ҫ��֤%��β���ֶ��Ƿ����ת��������*0.01
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        private bool CheckExpressionFieldValid(string[] fields)
        {
            foreach (string field in fields)
            {
                //�Ƿ���%��β
                if (field.EndsWith("%"))
                {
                    double trydouble;
                    if (!double.TryParse(field.Substring(0, field.Length - 1), out trydouble))
                    //ע�⣺������removeȥ��%Ҫ��substring
                    {
                        throw new Exception("����" + field + "����Ч���ʽ");
                    }
                }
            }
            return true;
        }
        #endregion

    }
}
