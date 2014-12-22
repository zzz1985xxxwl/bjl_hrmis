//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AccountSetDataBinder.cs
// ������: wang.shali
// ��������: 2008-12
// ����: AccountSet�������ݰ�
// ----------------------------------------------------------------
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet.IAccountSet;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet
{
    public class AccountSetDataBinder
    {
        private readonly IAccountSetView _IAccountSetView;
        private readonly IAccountSetFacade _IAccountSetFacade = InstanceFactory.CreateAccountSetFacade();

        public AccountSetDataBinder(IAccountSetView itsView, IAccountSetFacade iAccountSetFacade)
        {
            _IAccountSetFacade = iAccountSetFacade;
            _IAccountSetView = itsView;
        }

        public void DataBind(int accountSetId)
        {
            try
            {
                Model.PayModule.AccountSet theDataToBind = _IAccountSetFacade.GetWholeAccountSetByPKID(accountSetId);
                _IAccountSetView.AccountSetName = theDataToBind.AccountSetName;
                _IAccountSetView.Description = theDataToBind.Description;
                _IAccountSetView.AccountSetItemList = theDataToBind.Items;
            }
            catch
            {
                _IAccountSetView.Message = "��ʼ����Ϣʧ��";
            }
        }
        public void DataBind(Model.PayModule.AccountSet theDataToBind)
        {
            try
            {
                _IAccountSetView.AccountSetName = theDataToBind.AccountSetName;
                _IAccountSetView.Description = theDataToBind.Description;
                _IAccountSetView.AccountSetItemList = theDataToBind.Items;
            }
            catch
            {
                _IAccountSetView.Message = "����Ϣʧ��";
            }
        }
    }
}
