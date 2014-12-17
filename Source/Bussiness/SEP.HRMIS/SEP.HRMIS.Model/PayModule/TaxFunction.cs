//add by wsl
//ʵ��Evaluant.Calculator�Ĵ�����TaxFunction
//���TaxFunction˰�Ƶļ���


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
            //�ж�����
            if (beforetax == null || !double.TryParse(beforetax.ToString(), out _BeforeTax) ||
                _IndividualIncomeTax == null ||
                _IndividualIncomeTax.TaxBands == null ||_IndividualIncomeTax.TaxBands.Count == 0)
            {
                return 0;
            }
            //���˰ǰ����С��������
            if(_BeforeTax <=(double)_IndividualIncomeTax.TaxCutoffPoint)
            {
                return 0;
            }
            //����
            SortList<TaxBand> sortList =
                new SortList<TaxBand>(_IndividualIncomeTax.TaxBands[0], "BandMin", ReverserInfo.Direction.ASC);
            _IndividualIncomeTax.TaxBands.Sort(sortList);
            

            //�����ޣ����һ����û�У�
            for (int i = 0; i < _IndividualIncomeTax.TaxBands.Count - 1; i++)
            {
                _IndividualIncomeTax.TaxBands[i].BandMax = _IndividualIncomeTax.TaxBands[i + 1].BandMin;
            }
            //�����۳���
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
            //���˰ǰ����-�������Ĳ�ֵС����С��˰��
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
