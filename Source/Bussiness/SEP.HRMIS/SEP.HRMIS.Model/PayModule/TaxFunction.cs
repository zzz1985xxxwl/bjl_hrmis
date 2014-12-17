//add by wsl
//实现Evaluant.Calculator的代理方法TaxFunction
//完成TaxFunction税制的计算


namespace SEP.HRMIS.Model.PayModule
{
    public class TaxFunction
    {
        private readonly IndividualIncomeTax _IndividualIncomeTax;
        public TaxFunction(IndividualIncomeTax individualIncomeTax)
        {
            _IndividualIncomeTax = individualIncomeTax;
        }

        public object doFunction(object beforetax)
        {
            double _BeforeTax;
            //判断输入
            if (beforetax == null || !double.TryParse(beforetax.ToString(), out _BeforeTax) ||
                _IndividualIncomeTax == null ||
                _IndividualIncomeTax.TaxBands == null ||_IndividualIncomeTax.TaxBands.Count == 0)
            {
                return 0;
            }
            //如果税前工资小于起征点
            if(_BeforeTax <=(double)_IndividualIncomeTax.TaxCutoffPoint)
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
            for (int i = 0; i < _IndividualIncomeTax.TaxBands.Count ; i++)
            {
                double quickDeduction = 0;
                for (int j = 0; j < i; j++)
                {
                    quickDeduction = quickDeduction +
                        (double)((_IndividualIncomeTax.TaxBands[j].BandMax - _IndividualIncomeTax.TaxBands[j].BandMin) * 
                                  (_IndividualIncomeTax.TaxBands[i].TaxRate-_IndividualIncomeTax.TaxBands[j].TaxRate));
                }
                _IndividualIncomeTax.TaxBands[i].QuickDeduction = quickDeduction;
            }
            double margin = _BeforeTax - (double) _IndividualIncomeTax.TaxCutoffPoint;
            //如果税前工资-起征点后的差值小于最小的税阶
            if (margin <= (double) _IndividualIncomeTax.TaxBands[0].BandMin)
            {
                return 0;
            }
            for(int i = 0; i < _IndividualIncomeTax.TaxBands.Count-1 ; i++)
            {
                if(margin>(double) _IndividualIncomeTax.TaxBands[i].BandMin &&
                   margin<=(double) _IndividualIncomeTax.TaxBands[i].BandMax)
                {
                    return margin*(double) _IndividualIncomeTax.TaxBands[i].TaxRate -
                        _IndividualIncomeTax.TaxBands[i].QuickDeduction;
                }
            }
            if (margin > (double)_IndividualIncomeTax.TaxBands[_IndividualIncomeTax.TaxBands.Count - 1].BandMin)
            {
                return margin * (double)_IndividualIncomeTax.TaxBands[_IndividualIncomeTax.TaxBands.Count - 1].TaxRate -
                        _IndividualIncomeTax.TaxBands[_IndividualIncomeTax.TaxBands.Count - 1 ].QuickDeduction;
            }
            return 0;
        }
    }
}
