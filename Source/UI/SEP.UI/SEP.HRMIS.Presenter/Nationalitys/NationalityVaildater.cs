using SEP.HRMIS.Presenter.IPresenter.INationality;

namespace SEP.HRMIS.Presenter.Nationalitys
{
    public class NationalityVaildater
    {
        private readonly INationalityView _ItsView;

        public NationalityVaildater(INationalityView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            _ItsView.NameMsg = string.Empty;
            bool vaildate = true;
            if (string.IsNullOrEmpty(_ItsView.NationalityName))
            {
                _ItsView.NameMsg = NationalityUtility._NameIsEmpty;
                vaildate = false;
            }
            return vaildate;
        }
    }
}