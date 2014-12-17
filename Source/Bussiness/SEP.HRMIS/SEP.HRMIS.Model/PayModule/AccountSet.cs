using System;
using System.Collections.Generic;
using Evaluant.Calculator.Extensions;

namespace SEP.HRMIS.Model.PayModule
{
    [Serializable]
    public class AccountSet
    {
        private int _AccountSetID;
        private string _AccountSetName;
        private List<AccountSetItem> _AccountSetItems;
        private string _Description;

        public AccountSet(int accountSetID, string accountSetName)
        {
            _AccountSetID = accountSetID;
            _AccountSetName = accountSetName;
        }
        public string ParameterNameTitle
        {
            get { return "A".ToUpper();}
        }
        public int AccountSetID
        {
            get { return _AccountSetID; }
            set { _AccountSetID = value; }
        }

        public string AccountSetName
        {
            get { return _AccountSetName; }
            set { _AccountSetName = value; }
        }

        public List<AccountSetItem> Items
        {
            get { return _AccountSetItems; }
            set { _AccountSetItems = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        /// <summary>
        /// AccountSetItems中是否包含accountSetItemID
        /// </summary>
        /// <param name="accountSetItemID"></param>
        /// <returns></returns>
        public bool IsContainAccountSetItem(int accountSetItemID)
        {
            foreach (AccountSetItem accountSetItem in _AccountSetItems)
            {
                if (accountSetItemID == accountSetItem.AccountSetItemID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 返回AccountSetItems中第一个等于accountSetParaID的元素
        /// </summary>
        /// <param name="accountSetParaID"></param>
        /// <returns></returns>
        public AccountSetItem FindAccountSetItemByParaID(int accountSetParaID)
        {
            foreach (AccountSetItem accountSetItem in _AccountSetItems)
            {
                if (accountSetParaID == accountSetItem.AccountSetPara.AccountSetParaID)
                {
                    return accountSetItem;
                }
            }
            return null;
        }


        /// <summary>
        /// 解释并计算
        /// </summary>
        /// <param name="individualIncomeTax"></param>
        /// <param name="employeeSalaryHistoryList">发薪历史，为去年全年的历史从1月到12月</param>
        /// <param name="salaryEndDateMonth">发薪月份，如发薪时间2009-1-21-2009-2-20 此时为2</param>
        public void CalculateItemList(IndividualIncomeTax individualIncomeTax, List<EmployeeSalaryHistory> employeeSalaryHistoryList, int salaryEndDateMonth)
        {
            if (_AccountSetItems == null)
            {
                return;
            }
            List<ExpressionItem> expressionItems =
                TurnExpressionItem.TurnToExpressionItemList(ParameterNameTitle, _AccountSetItems,
                                                            TurnExpressionItem.Operation.Calculate);
            CalculateExpressionItemList calculateExpressionItemList =
                new CalculateExpressionItemList(expressionItems, ParameterNameTitle);
            calculateExpressionItemList.IsSalaryEndDateMonthEquelFunction += new IsSalaryEndDateMonthEquelFunction(salaryEndDateMonth).doFunction;
            calculateExpressionItemList.DoubleSalaryFunction += new DoubleSalaryFunction(employeeSalaryHistoryList).doFunction;
            calculateExpressionItemList.ForeignTaxFunction += new ForeignTaxFunction(individualIncomeTax).doFunction;
            calculateExpressionItemList.AnnualBonusForeignTaxFunction += new AnnualBonusForeignTaxFunction(individualIncomeTax).doFunction;
            calculateExpressionItemList.TaxFunction += new TaxFunction(individualIncomeTax).doFunction;
            calculateExpressionItemList.TaxWithPointFunction += new TaxWithPointFunction(individualIncomeTax).doFunction;
            calculateExpressionItemList.AnnualBonusTaxFunction += new AnnualBonusTaxFunction(individualIncomeTax).doFunction;
            calculateExpressionItemList.CalculateExpressionResult();
            TurnExpressionItem.TurnBackAccountSetItemList(expressionItems, _AccountSetItems);
        }
        /// <summary>
        /// 多项验证
        /// </summary>
        /// <returns></returns>
        public bool CheckItemListValidation()
        {
            if (_AccountSetItems == null)
            {
                _AccountSetItems = new List<AccountSetItem>();
            }
            List<ExpressionItem> expressionItems =
                TurnExpressionItem.TurnToExpressionItemList(ParameterNameTitle, _AccountSetItems,
                                                            TurnExpressionItem.Operation.Check);
            CheckExpressionItemList checkExpressionItemList =
                new CheckExpressionItemList(expressionItems, ParameterNameTitle);
            checkExpressionItemList.TaxFunction +=
                new TaxFunction(new IndividualIncomeTax(0, 0, new List<TaxBand>())).doFunction;
            checkExpressionItemList.TaxWithPointFunction +=
                new TaxWithPointFunction(new IndividualIncomeTax(0, 0, new List<TaxBand>())).doFunction;
            checkExpressionItemList.AnnualBonusTaxFunction +=
                new AnnualBonusTaxFunction(new IndividualIncomeTax(0, 0, new List<TaxBand>())).doFunction;
            checkExpressionItemList.ForeignTaxFunction +=
                new ForeignTaxFunction(new IndividualIncomeTax(0, 0, new List<TaxBand>())).doFunction;
            checkExpressionItemList.AnnualBonusForeignTaxFunction +=
                new AnnualBonusForeignTaxFunction(new IndividualIncomeTax(0, 0, new List<TaxBand>())).doFunction;
            checkExpressionItemList.IsSalaryEndDateMonthEquelFunction +=
                new IsSalaryEndDateMonthEquelFunction(13).doFunction;
            checkExpressionItemList.DoubleSalaryFunction +=
                new DoubleSalaryFunction(new List<EmployeeSalaryHistory>()).doFunction;
            try
            {
                return checkExpressionItemList.CheckExpressionItemListValid();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
