using System;
using ComService.ServiceModels;
using ComService.ServiceContracts;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SEP.Presenter.IPresenter.IContact;
using SEP.Model.Utility;
using SEP.HRMIS.IFacede;

namespace SEP.Presenter.Contacts
{
    public class ContactPresenter : IDisposable
    {
        private static readonly IContactServices _contactService;
        private  readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private  int _CompanyId;
        static ContactPresenter()
        {
            _contactService = new ChannelFactory<IContactServices>("BasicHttpBinding_ContactServices").CreateChannel();
      
        }


        private IEmployeeContact _view;
        private void Init()
        {
            _view.Message = string.Empty;
            _view.SearchByName += view_SearchByName;
            _view.SearchByIndexKey += view_SearchByIndexKey;
            _view.SaveLinkman += view_SaveLinkman;
            _view.DeleteLinkman += _view_DeleteLinkman;
            //获取公司id
            _CompanyId = _IEmployeeFacade.GetEmployeeByAccountID(_view.UserId).EmployeeDetails.Work.Company.DepartmentID;
        }

        private void _view_DeleteLinkman(Guid guid)
        {
            _contactService.DeleteLinkman(guid);
        }
        private void view_SaveLinkman(Linkman linkman)
        {
            try
            {
                _contactService.SaveLinkman(CompanyConfig.SYSTEMID, _view.UserId,0, linkman);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void view_SearchByIndexKey(string condition)
        {
            if (_view.IsCompany)
            {
                _view.CurrentContact = _contactService.LoadSomeContactByIndexKey(CompanyConfig.SYSTEMID, 0, _CompanyId,
                                                                                 condition);
            }
            else
            {
                _view.CurrentContact = _contactService.LoadSomeContactByIndexKey(CompanyConfig.SYSTEMID, _view.UserId, 0,
                                                                 condition);
            }
        }
        private void view_SearchByName(string condition)
        {
            if (_view.IsCompany)
            {
                _view.CurrentContact = _contactService.LoadSomeContactByName(CompanyConfig.SYSTEMID, 0, _CompanyId,
                                                                             condition);
            }
            else
            {
                _view.CurrentContact = _contactService.LoadSomeContactByIndexKey(CompanyConfig.SYSTEMID, _view.UserId, 0,
                                                 condition);
            }
        }


        public ContactPresenter(IEmployeeContact view)
        {
            _view = view;

            Init();
        }


        #region IDisposable 成员

        public void Dispose()
        {
            if (_contactService != null)
            {
                IChannelFactory channel = _contactService as IChannelFactory;
                if (channel != null && channel.State != CommunicationState.Closed)
                {
                    channel.Close();
                }
            }
        }

        #endregion
    }
}