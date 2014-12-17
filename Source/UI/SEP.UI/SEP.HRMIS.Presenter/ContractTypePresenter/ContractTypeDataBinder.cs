// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: ContractTypeDataBinder.cs
// ������: ���޾�
// ��������: 2008-10-07
// ����: �޸ĺ�ͬ����С��������ݰ���
// ----------------------------------------------------------------

using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;

namespace SEP.HRMIS.Presenter.Parameter.ContractTypePresenter
{
    public class ContractTypeDataBinder
    {
        private readonly IContractType _ItsView;
        private readonly IContractTypeFacade _IContractTypeFacade;

        public ContractTypeDataBinder(IContractType itsView, IContractTypeFacade getContractType)
        {
            _ItsView = itsView;
            _IContractTypeFacade = getContractType;
        }

        public bool DataBind(string contractTypeId)
        {
            int id;
            if (!int.TryParse(contractTypeId, out id))
            {
                return SetViewUnable();
            }

            Model.ContractType theDataToBind = _IContractTypeFacade.GetContractTypeByPKID(id);
            if(theDataToBind!=null)
            {
                _ItsView.ContractTypeID = theDataToBind.ContractTypeID.ToString();
                _ItsView.ContractTypeName = theDataToBind.ContractTypeName;
                return true;
            }
            return SetViewUnable();
        }

        private bool SetViewUnable()
        {
            _ItsView.ResultMessage = "����ı�ʶ���޷��������ʺ�";
            _ItsView.ActionButtonEnable = false;
            return false;
        }
    }
}
