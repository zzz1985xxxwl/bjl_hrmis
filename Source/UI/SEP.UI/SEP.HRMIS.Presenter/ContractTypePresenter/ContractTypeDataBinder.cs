// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ContractTypeDataBinder.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-07
// 概述: 修改合同类型小界面的数据绑定类
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
            _ItsView.ResultMessage = "错误的标识，无法操作该帐号";
            _ItsView.ActionButtonEnable = false;
            return false;
        }
    }
}
