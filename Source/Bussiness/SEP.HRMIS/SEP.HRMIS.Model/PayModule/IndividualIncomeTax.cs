using System.Collections.Generic;

namespace SEP.HRMIS.Model.PayModule
{
    public class IndividualIncomeTax
    {
        private decimal _TaxCutoffPoint;
        private decimal _ForeignTaxCutoffPoint;

        private List<TaxBand> _TaxBands;

        public IndividualIncomeTax(decimal taxCutoffPoint, decimal taxForeignCutoffPoint, List<TaxBand> taxBands)
        {
            _TaxCutoffPoint = taxCutoffPoint;
            _ForeignTaxCutoffPoint = taxForeignCutoffPoint;
            _TaxBands = taxBands;
        }

        /// <summary>
        /// ����˰
        /// </summary>
        public decimal TaxCutoffPoint
        {
            get { return _TaxCutoffPoint; }
            set { _TaxCutoffPoint = value; }
        }

        /// <summary>
        /// ˰��
        /// </summary>
        public List<TaxBand> TaxBands
        {
            get { return _TaxBands; }
            set { _TaxBands = value; }
        }

        ///<summary>
        /// ����������
        ///</summary>
        public decimal ForeignTaxCutoffPoint
        {
            get { return _ForeignTaxCutoffPoint; }
            set { _ForeignTaxCutoffPoint = value; }
        }


        /// <summary>
        /// ���˰������
        /// </summary>
        /// <returns></returns>
        public void GetBandMax()
        {
           if(_TaxBands!=null&&_TaxBands.Count>0)
           {
               SortList<TaxBand> sortList =
                   new SortList<TaxBand>(_TaxBands[0], "BandMin", ReverserInfo.Direction.ASC);
               _TaxBands.Sort(sortList);
               for(int i=0;i<_TaxBands.Count-1;i++)
               {
                   _TaxBands[i].BandMax = _TaxBands[i + 1].BandMin;
               }
           }
        }
    }
}