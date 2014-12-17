using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.INationality;

namespace SEP.HRMIS.Presenter.Nationalitys
{
    public class NationalityListPresenter
    {
        public INationalityFacade _ItsNationalityFacade = InstanceFactory.CreateNationalityFacade();
        private readonly INationalityListView _ItsView;

        public NationalityListPresenter(INationalityListView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }
    
        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                NationalityDataBind();
            }
        }

        public void AttachViewEvent()
        {
            _ItsView.BtnSearchEvent += NationalityDataBind;
        }

        public void NationalityDataBind()
        {
            List<Nationality> itsSource = _ItsNationalityFacade.GetNationalityByCondition(-1, _ItsView.NationalityName);
            _ItsView.Nationalitys = itsSource;
        }
    }
}

