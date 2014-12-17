using System;
using SEP.Presenter.IPresenter;
using SEP.Presenter.IPresenter.ISpecialDate;

namespace SEP.Presenter.SpecialDates
{
    public class SepcialDataValidate : IVaildater
    {
        private readonly ISpecialDateEditView _ItsView;

        public SepcialDataValidate(ISpecialDateEditView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            bool validation = true;
            DateTime _SpecialDate;

            if (String.IsNullOrEmpty(_ItsView.SpecialDate) ||!DateTime.TryParse(_ItsView.SpecialDate, out _SpecialDate))
            {
                _ItsView.ResultMessage = "请选择一个日期设置！";
                validation = false;
            }
            if (String.IsNullOrEmpty(_ItsView.SpecialHeader))
            {
                _ItsView.ValidateTitle = "特殊日期说明不能为空！";
                validation = false;
            }
            if (_ItsView.SpecialHeader.Length > 50)
            {
                _ItsView.ValidateTitle = "特殊日期说明不能超过50个字符！";
                validation = false;
            }
            return validation;
        }
    }
}