//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ListContractTypePresenter.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-07
// 概述: 合同类型大界面
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;

namespace SEP.HRMIS.Presenter.Parameter.ContractTypePresenter
{
    public class ListContractTypePresenter
    {
        //private const string _ErrorNullContractType = "没有任何合同类型";

        private readonly IContractTypeList _ItsView;
        private List<ContractType> itsSource = new List<ContractType>();
        public IContractTypeFacade _IContractTypeFacade = InstanceFactory.CreateContractTypeFacade();

        public ListContractTypePresenter(IContractTypeList itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }
        
        public void AttachViewEvent()
        {
            _ItsView.BtnSearchEvent += ShowSearchView;
            //ShowSearchView();
        }

        public void ShowSearchView()
        {
            if (Validation())
            {
                    _ItsView.ContractTypeSource =
                        _IContractTypeFacade.GetContractTypeByCondition(-1, _ItsView.ContractTypeName);
                    itsSource = _IContractTypeFacade.GetContractTypeByCondition(-1, _ItsView.ContractTypeName);
                    if (itsSource == null || itsSource.Count.Equals(0))
                    {
                        _ItsView.Message = "<span class='font14b'>共查到 </span>" + "<span class='fontred'>" +
                                            0 + "</span>" + "<span class='font14b'> 条信息</span>";
                    }
                    else
                    {
                        _ItsView.Message = "<span class='font14b'>共查到 </span>" + "<span class='fontred'>" +
                                           itsSource.Count + "</span>" + "<span class='font14b'> 条信息</span>";
                    }
                }
     
        }

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                ShowSearchView();
            }
        }

        //private int temp = -1;
        private bool Validation()
        {
            //if (String.IsNullOrEmpty(_ItsView.ContractTypeID))
            //{
            //    temp = -1;
            //    return true;
            //}
            //if (!int.TryParse(_ItsView.ContractTypeID, out temp))
            //{
            //    _ItsView.Message = "合同类型编号必须是整型";
            //    return false;
            //}
            return true;
        }

        //for test
        public IContractTypeFacade ContractTypeSource
        {
            //get { return _IGetContractType; }
            set { _IContractTypeFacade = value; }
        }
    }
}
