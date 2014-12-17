using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Model
{
    public class TaxWithPointFunction
    {
        private readonly IndividualIncomeTax _IndividualIncomeTax;
        public TaxWithPointFunction(IndividualIncomeTax individualIncomeTax)
        {
            _IndividualIncomeTax =
                new IndividualIncomeTax(individualIncomeTax.TaxCutoffPoint, individualIncomeTax.ForeignTaxCutoffPoint,
                                        individualIncomeTax.TaxBands);
        }
        public object doFunction(object beforetax, object piont)
        {
            decimal dTemp;
            if (decimal.TryParse(piont.ToString(), out dTemp))
            {
                _IndividualIncomeTax.TaxCutoffPoint = dTemp;
            }
            return new TaxFunction(_IndividualIncomeTax).doFunction(beforetax);
        }
    }
}
