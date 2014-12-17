using System.Collections.Generic;
using SEP.Model.SpecialDates;

namespace SEP.Presenter.IPresenter.ISpecialDate
{
    public interface ISpecialDateView
    {
        List<SpecialDate> SpecialDates { get;set;}
        string CurrentDay { get; set; }

        event DelegateSomeParameter SpecialDateSlection;
        event DelegateSomeParameter SetNullValue;
    }
}
