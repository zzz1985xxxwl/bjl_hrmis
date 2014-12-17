using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.INationality;

namespace SEP.HRMIS.Presenter.Nationalitys
{
    public class NationalityDataBinder
    {
        public INationalityFacade _ItsNationalityFacade = InstanceFactory.CreateNationalityFacade();
        private readonly INationalityView _ItsView;

        public NationalityDataBinder(INationalityView itsView)
        {
            _ItsView = itsView;
        }

        public void DataBind(string leaveRequestTypeId)
        {
            Nationality theDataToBind = _ItsNationalityFacade.GetNationalityByPkid(Convert.ToInt32(leaveRequestTypeId));
            if (theDataToBind != null)
            {
                _ItsView.NationalityID = theDataToBind.ParameterID.ToString();
                _ItsView.NationalityName = theDataToBind.Name;
                _ItsView.NationalityDescription = theDataToBind.Description;
            }
        }

    }
}
