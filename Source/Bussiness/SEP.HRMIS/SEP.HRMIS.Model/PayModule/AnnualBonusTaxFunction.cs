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
    /// ���ս���˰����������ս��ϼ�ֵ����12����������ΪtaxCutoffPoint������˰�ף�������ԭ���ս��ϼ�ֵ��ʹ�ô�˰�ʼ���˰
    /// �������ս��ϼ�Ϊϵͳ���׼���ֵ����˫н�����ս���ӻ��
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
            //�������滻_IndividualIncomeTax.TaxCutoffPoint�ᵼ������TaxCutoffPoint������
            //_IndividualIncomeTax.TaxCutoffPoint = (decimal) _TaxCutoffPoint;
            _MonthBonusBeforetax = _AnnualBonusBeforetax / 12;
            //���˰ǰ����С��������
            if (_MonthBonusBeforetax <= _TaxCutoffPoint)
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
            //���˰ǰ����-�������Ĳ�ֵС����С��˰��
            if (margin <= (double)_IndividualIncomeTax.TaxBands[0].BandMin)
            {
                return 0;
            }
            for (int i = 0; i < _IndividualIncomeTax.TaxBands.Count - 1; i++)
            {
                //�ҵ������㣬����ԭ���ս��ϼƽ���˰�ʼ���
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
