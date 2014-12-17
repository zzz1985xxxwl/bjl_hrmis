//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: TaxFunctionTest.cs
// Creater:  wyq
// Date:  2008-12-30
// Resume:
// ----------------------------------------------------------------


namespace SEP.HRMIS.Model.PayModule
{
    /// <summary>
    /// 年终奖个税计算规则：年终奖合计值除以12后，以起征点为taxCutoffPoint获得相关税阶，最终在原年终奖合计值上使用此税率计算税
    /// 其中年终奖合计为系统帐套计算值，由双薪和年终奖相加获得
    /// </summary>
    public class AnnualBonusTaxFunction
    {
        private readonly IndividualIncomeTax _IndividualIncomeTax;
        public AnnualBonusTaxFunction(IndividualIncomeTax individualIncomeTax)
        {
            _IndividualIncomeTax = individualIncomeTax;
        }

        public object doFunction(object taxCutoffPoint, object annualBonusbeforetax)
        {
            double _AnnualBonusBeforetax;
            double _MonthBonusBeforetax;
            double _TaxCutoffPoint;
            if (taxCutoffPoint == null || !double.TryParse(taxCutoffPoint.ToString(), out _TaxCutoffPoint) ||
                annualBonusbeforetax == null || !double.TryParse(annualBonusbeforetax.ToString(), out _AnnualBonusBeforetax) ||
                _IndividualIncomeTax == null ||
                _IndividualIncomeTax.TaxBands == null || _IndividualIncomeTax.TaxBands.Count == 0)
            {
                return 0;
            }
            //不可以替换_IndividualIncomeTax.TaxCutoffPoint会导致外界的TaxCutoffPoint被覆盖
            //_IndividualIncomeTax.TaxCutoffPoint = (decimal) _TaxCutoffPoint;
            _MonthBonusBeforetax = _AnnualBonusBeforetax / 12;
            //如果税前工资小于起征点
            if (_MonthBonusBeforetax <= _TaxCutoffPoint)
            {
                return 0;
            }
            //排序
            SortList<TaxBand> sortList =
                new SortList<TaxBand>(_IndividualIncomeTax.TaxBands[0], "BandMin", ReverserInfo.Direction.ASC);
            _IndividualIncomeTax.TaxBands.Sort(sortList);


            //付上限，最后一个，没有；
            for (int i = 0; i < _IndividualIncomeTax.TaxBands.Count - 1; i++)
            {
                _IndividualIncomeTax.TaxBands[i].BandMax = _IndividualIncomeTax.TaxBands[i + 1].BandMin;
            }
            //付最大扣除数
            for (int i = 0; i < _IndividualIncomeTax.TaxBands.Count; i++)
            {
                double quickDeduction = 0;
                for (int j = 0; j < i; j++)
                {
                    quickDeduction = quickDeduction +
                        (double)((_IndividualIncomeTax.TaxBands[j].BandMax - _IndividualIncomeTax.TaxBands[j].BandMin) *
                                  (_IndividualIncomeTax.TaxBands[i].TaxRate - _IndividualIncomeTax.TaxBands[j].TaxRate));
                }
                _IndividualIncomeTax.TaxBands[i].QuickDeduction = quickDeduction;
            }
            double margin = _MonthBonusBeforetax - _TaxCutoffPoint;
            //如果税前工资-起征点后的差值小于最小的税阶
            if (margin <= (double)_IndividualIncomeTax.TaxBands[0].BandMin)
            {
                return 0;
            }
            for (int i = 0; i < _IndividualIncomeTax.TaxBands.Count - 1; i++)
            {
                //找到起征点，并用原年终奖合计进行税率计算
                if (margin > (double)_IndividualIncomeTax.TaxBands[i].BandMin &&
                   margin <= (double)_IndividualIncomeTax.TaxBands[i].BandMax)
                {
                    return _AnnualBonusBeforetax * (double)_IndividualIncomeTax.TaxBands[i].TaxRate -
                        _IndividualIncomeTax.TaxBands[i].QuickDeduction;
                }
            }
            if (margin > (double)_IndividualIncomeTax.TaxBands[_IndividualIncomeTax.TaxBands.Count - 1].BandMin)
            {
                return _AnnualBonusBeforetax * (double)_IndividualIncomeTax.TaxBands[_IndividualIncomeTax.TaxBands.Count - 1].TaxRate -
                        _IndividualIncomeTax.TaxBands[_IndividualIncomeTax.TaxBands.Count - 1].QuickDeduction;
            }
            return 0;
            
        }
    }
}
