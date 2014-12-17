//add by wsl
//��֤���ʽList����֤���ʽ֮�����Ч�ԣ����Ƿ��л�·
using System;
using System.Collections;
using System.Collections.Generic;

namespace Evaluant.Calculator.Extensions
{
    public class CheckExpressionItemList
    {
        public event IsSalaryEndDateMonthEquelFunctionDelegate IsSalaryEndDateMonthEquelFunction;
        public event DoubleSalaryFunctionDelegate DoubleSalaryFunction;
        public event AnnualBonusForeignTaxFunctionDelegate AnnualBonusForeignTaxFunction;
        public event ForeignTaxFunctionDelegate ForeignTaxFunction;
        public event AnnualBonusTaxFunctionDelegate AnnualBonusTaxFunction;
        public event TaxWithPointFunctionDelegate TaxWithPointFunction;
        public event TaxFunctionDelegate TaxFunction;
        //��������dependenceMatrix[i��j]��ʾ��i�������Ƿ��ܵ�j������������
        //���dependenceMatrix[i��j]ֵΪnull�����ʾû�����������Ϊ1�����ʾ��������ϵ
        private readonly int[,] dependenceMatrix;
        //��parameterIndex�������Ѿ��ҹ�������Ҫ�����Ĳ���
        private readonly bool[] isFillDependenceMatrix;

        private readonly List<ExpressionItem> _ExpressionItemList;
        private string _ParameterName;
        #region ����
        /// <summary>
        /// ���ʽ�Ƿ��Сд����
        /// </summary>
        private bool _IsDiffUpperOrLower;
        public bool IsDiffUpperOrLower
        {
            set { _IsDiffUpperOrLower = value;}
        }
        #endregion

        public CheckExpressionItemList(List<ExpressionItem> expressionItemList, string parameterName)
        {
            _ExpressionItemList = expressionItemList;
            _ParameterName = parameterName;
            dependenceMatrix = new int[_ExpressionItemList.Count, _ExpressionItemList.Count];
            isFillDependenceMatrix = new bool[_ExpressionItemList.Count];
        }

        public bool CheckExpressionItemListValid()
        {
            //�����Сд����
            FormatAccordingtoIsDiffUpperOrLower();
            //�ж�ÿ�����ʽ�Ƿ���Ч
            CheckEachExpressionItem();
            //�ж��Ƿ��л�·������֮���Ƿ����໥�������Է���ѭ������A1=A2��A2=A1
            CheckHasCircuit();
            return true;
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
        /// �ж�ÿ�����ʽ�Ƿ���Ч
        /// </summary>
        private void CheckEachExpressionItem()
        {
            foreach (ExpressionItem item in _ExpressionItemList)
            {
                CheckExpressionItem ce = new CheckExpressionItem(item.Parameter, _ParameterName, _ExpressionItemList);
                ce.AnnualBonusTaxFunction += AnnualBonusTaxFunction;
                ce.TaxFunction += TaxFunction;
                ce.TaxWithPointFunction += TaxWithPointFunction;
                ce.AnnualBonusForeignTaxFunction += AnnualBonusForeignTaxFunction;
                ce.ForeignTaxFunction += ForeignTaxFunction;
                ce.IsSalaryEndDateMonthEquelFunction += IsSalaryEndDateMonthEquelFunction;
                ce.DoubleSalaryFunction += DoubleSalaryFunction;
                ce.IsDiffUpperOrLower = true;
                ce.CheckExpressionItemValid();
            }
        }

        /// <summary>
        /// �ж��Ƿ��л�·������֮���Ƿ����໥�������Է���ѭ������A1=A2��A2=A1
        /// </summary>
        /// <returns></returns>
        private bool CheckHasCircuit()
        {
            for (int i = 0; i < _ExpressionItemList.Count; i++)
            {
                if (!isFillDependenceMatrix[i])
                {
                    FillDependenceMatrixByParameter(_ExpressionItemList[i].Parameter);
                }
            }
            return true;
        }

        /// <summary>
        /// ���parameter�����õ���A1,A2,...An��ֵ���ݹ�ΪdependenceMatrix��ֵ
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private void FillDependenceMatrixByParameter(string parameter)
        {
            ExpressionItem expressionItem = Utility.GetExpressionItemByParameter(_ExpressionItemList,parameter);
            if (expressionItem == null)
            {
                throw new Exception(parameter + "û�ж��壬ϵͳ�޷�����");
            }
            //��õ�ǰparameter��_ExpressionItemList��Index
            int parameterIndex = _ExpressionItemList.IndexOf(expressionItem);
            ArrayList paras = Utility.GetParameterFromExpression(expressionItem.Expression, _ParameterName); //�����ز��������ظ�
            for (int i = 0; i < paras.Count; i++)
            {
                ExpressionItem factorExpressionItem =
                    Utility.GetExpressionItemByParameter(_ExpressionItemList, paras[i].ToString());
                if (factorExpressionItem == null)
                {
                    throw new Exception(paras[i] + "û�ж��壬ϵͳ�޷�����");
                }
                //�����ز���paras[i]��_ExpressionItemList��Index
                int factorIndex = _ExpressionItemList.IndexOf(factorExpressionItem);
                SetDependenceMatrixByParameterAndFactor(parameterIndex, factorIndex);
                //��factorIndex���������в����ҳ�������parameterIndex��jȷ��������ϵ����factorIndex��������Ҳ��parameterIndex������
                for (int j = 0; j < _ExpressionItemList.Count; j++)
                {
                    if (dependenceMatrix[factorIndex, j] == 1)
                    {
                        SetDependenceMatrixByParameterAndFactor(parameterIndex, j);
                    }
                }
                FillDependenceMatrixByParameter(paras[i].ToString());
            }
            //��parameterIndex�������Ѿ��ҹ�������Ҫ�����Ĳ���
            isFillDependenceMatrix[parameterIndex] = true;
        }

        private void SetDependenceMatrixByParameterAndFactor(int parameterIndex, int factorIndex)
        {
            //ΪdependenceMatrix[parameterIndex, factorIndex]��ֵ����ʾ����������ϵ
            dependenceMatrix[parameterIndex, factorIndex] = 1;
            //�ж�dependenceMatrix[parameterIndex, factorIndex]�ھ���ת��λҲΪ1�����ҲΪ1�����ʾ�����໥����
            if (dependenceMatrix[parameterIndex, factorIndex] == dependenceMatrix[factorIndex, parameterIndex])
            {
                throw new Exception("���㹫ʽ�г�������������"+_ExpressionItemList[parameterIndex].Parameter + "�Ĺ�ʽ");
            }
        }
    }
}