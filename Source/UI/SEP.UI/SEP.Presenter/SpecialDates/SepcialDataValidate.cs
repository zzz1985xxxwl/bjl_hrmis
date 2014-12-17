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
                _ItsView.ResultMessage = "��ѡ��һ���������ã�";
                validation = false;
            }
            if (String.IsNullOrEmpty(_ItsView.SpecialHeader))
            {
                _ItsView.ValidateTitle = "��������˵������Ϊ�գ�";
                validation = false;
            }
            if (_ItsView.SpecialHeader.Length > 50)
            {
                _ItsView.ValidateTitle = "��������˵�����ܳ���50���ַ���";
                validation = false;
            }
            return validation;
        }
    }
}