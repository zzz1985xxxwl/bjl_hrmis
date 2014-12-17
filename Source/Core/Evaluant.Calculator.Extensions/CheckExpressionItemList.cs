//add by wsl
//验证表达式List，验证表达式之间的有效性，如是否有回路
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
        //依赖矩阵，dependenceMatrix[i，j]表示第i个参数是否受第j个参数的依赖
        //如果dependenceMatrix[i，j]值为null，则表示没有依赖，如果为1，则表示有依赖关系
        private readonly int[,] dependenceMatrix;
        //第parameterIndex个参数已经找过了所有要依赖的参数
        private readonly bool[] isFillDependenceMatrix;

        private readonly List<ExpressionItem> _ExpressionItemList;
        private string _ParameterName;
        #region 属性
        /// <summary>
        /// 表达式是否大小写敏感
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
            //处理大小写敏感
            FormatAccordingtoIsDiffUpperOrLower();
            //判断每个表达式是否有效
            CheckEachExpressionItem();
            //判断是否有回路，参数之间是否有相互依赖，以防死循环。如A1=A2，A2=A1
            CheckHasCircuit();
            return true;
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
        /// 判断每个表达式是否有效
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
        /// 判断是否有回路，参数之间是否有相互依赖，以防死循环。如A1=A2，A2=A1
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
        /// 检测parameter中所用到的A1,A2,...An的值，递归为dependenceMatrix赋值
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private void FillDependenceMatrixByParameter(string parameter)
        {
            ExpressionItem expressionItem = Utility.GetExpressionItemByParameter(_ExpressionItemList,parameter);
            if (expressionItem == null)
            {
                throw new Exception(parameter + "没有定义，系统无法解释");
            }
            //获得当前parameter在_ExpressionItemList的Index
            int parameterIndex = _ExpressionItemList.IndexOf(expressionItem);
            ArrayList paras = Utility.GetParameterFromExpression(expressionItem.Expression, _ParameterName); //获得相关参数，无重复
            for (int i = 0; i < paras.Count; i++)
            {
                ExpressionItem factorExpressionItem =
                    Utility.GetExpressionItemByParameter(_ExpressionItemList, paras[i].ToString());
                if (factorExpressionItem == null)
                {
                    throw new Exception(paras[i] + "没有定义，系统无法解释");
                }
                //获得相关参数paras[i]在_ExpressionItemList的Index
                int factorIndex = _ExpressionItemList.IndexOf(factorExpressionItem);
                SetDependenceMatrixByParameterAndFactor(parameterIndex, factorIndex);
                //将factorIndex依赖的所有参数找出来，给parameterIndex和j确立依赖关系，即factorIndex得依赖项也是parameterIndex依赖项
                for (int j = 0; j < _ExpressionItemList.Count; j++)
                {
                    if (dependenceMatrix[factorIndex, j] == 1)
                    {
                        SetDependenceMatrixByParameterAndFactor(parameterIndex, j);
                    }
                }
                FillDependenceMatrixByParameter(paras[i].ToString());
            }
            //第parameterIndex个参数已经找过了所有要依赖的参数
            isFillDependenceMatrix[parameterIndex] = true;
        }

        private void SetDependenceMatrixByParameterAndFactor(int parameterIndex, int factorIndex)
        {
            //为dependenceMatrix[parameterIndex, factorIndex]赋值，表示存在依赖关系
            dependenceMatrix[parameterIndex, factorIndex] = 1;
            //判断dependenceMatrix[parameterIndex, factorIndex]在矩阵转置位也为1，如果也为1，则表示两者相互依赖
            if (dependenceMatrix[parameterIndex, factorIndex] == dependenceMatrix[factorIndex, parameterIndex])
            {
                throw new Exception("计算公式中出现依赖，请检查"+_ExpressionItemList[parameterIndex].Parameter + "的公式");
            }
        }
    }
}