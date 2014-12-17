using System;
using System.Collections.Generic;
using Evaluant.Calculator.Extensions;

namespace SEP.HRMIS.Model.PayModule
{
    [Serializable]
    public class AccountSetItem
    {
        private AccountSetPara _AccountSetPara;
        private string _CalculateFormula;
        private decimal _CalculateResult;
        private int _AccountSetItemID;
        /// <summary>
        /// 帐套项ID
        /// </summary>
        public int AccountSetItemID
        {
            get { return _AccountSetItemID; }
            set { _AccountSetItemID = value; }
        }
        public string ParameterNameTitle
        {
            get { return "A".ToUpper(); }
        }

        public AccountSetItem(int accountSetItemID, AccountSetPara accountSetPara, string calculateFormula)
        {
            _AccountSetItemID = accountSetItemID;
            _AccountSetPara = accountSetPara;
            _CalculateFormula = calculateFormula;
        }
        /// <summary>
        /// 帐套项参数
        /// </summary>
        public AccountSetPara AccountSetPara
        {
            get { return _AccountSetPara; }
            set { _AccountSetPara = value; }
        }

        /// <summary>
        /// 计算公式
        /// </summary>
        public string CalculateFormula
        {
            get { return _CalculateFormula; }
            set
            {
                //_CalculateFormula = value;
                _CalculateFormula = value.Replace(" ", "");
                _CalculateFormula = _CalculateFormula.Replace("　", "");
                _CalculateFormula = _CalculateFormula.ToUpper();
            }
        }

        /// <summary>
        /// 计算结果
        /// </summary>
        public decimal CalculateResult
        {
            get { return _CalculateResult; }
            set { _CalculateResult = value; }
        }
        /// <summary>
        /// 单项验证
        /// </summary>
        /// <param name="accountSetItemList"></param>
        /// <returns></returns>
        public bool CheckItemValidation(List<AccountSetItem> accountSetItemList)
        {
            //if (_CardPropertyPara == null)
            //{
            //    throw new ApplicationException(MyCmmiUtility._CardPropertyPara_IsNull);
            //}
            if (accountSetItemList == null)
            {
                accountSetItemList = new List<AccountSetItem>();
            }
            if (_AccountSetPara == null || _AccountSetPara.MantissaRound == null)
            {
                _AccountSetPara.MantissaRound = MantissaRoundEnum.AllMantissaRound;
            }
            CheckExpressionItem checkExpressionItem =
                new CheckExpressionItem(ParameterNameTitle + _AccountSetPara.AccountSetParaID, ParameterNameTitle,
                                        TurnExpressionItem.TurnToExpressionItemList(ParameterNameTitle,
                                                                                    accountSetItemList,
                                                                                    TurnExpressionItem.Operation.Check));
            try
            {
                checkExpressionItem.TaxFunction +=
                    new TaxFunction(new IndividualIncomeTax(0, 0, new List<TaxBand>())).doFunction;
                checkExpressionItem.TaxWithPointFunction +=
                    new TaxWithPointFunction(new IndividualIncomeTax(0, 0, new List<TaxBand>())).doFunction;
                checkExpressionItem.AnnualBonusTaxFunction +=
                    new AnnualBonusTaxFunction(new IndividualIncomeTax(0, 0, new List<TaxBand>())).doFunction;
                checkExpressionItem.ForeignTaxFunction +=
                    new ForeignTaxFunction(new IndividualIncomeTax(0, 0, new List<TaxBand>())).doFunction;
                checkExpressionItem.AnnualBonusForeignTaxFunction +=
                    new AnnualBonusForeignTaxFunction(new IndividualIncomeTax(0, 0, new List<TaxBand>())).doFunction;
                checkExpressionItem.IsSalaryEndDateMonthEquelFunction +=
                    new IsSalaryEndDateMonthEquelFunction(12).doFunction;
                checkExpressionItem.DoubleSalaryFunction +=
                    new DoubleSalaryFunction(new List<EmployeeSalaryHistory>()).doFunction;
                return checkExpressionItem.CheckExpressionItemValid();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
