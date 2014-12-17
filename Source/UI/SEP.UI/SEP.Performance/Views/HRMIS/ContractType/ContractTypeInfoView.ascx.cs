//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ContractTypeInfoView.ascx.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-08
// 概述: 合同类型的总界面
// ----------------------------------------------------------------
using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;

namespace SEP.Performance.Views.ContractType
{
    public partial class ContractTypeInfoView : UserControl,IContractTypeInfoView
    {
        #region IContractTypeInfoView 成员

        public IContractTypeList ContractTypeListView
        {
            get
            {
                return ContractTypeListView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public IContractType ContractTypeView
        {
            get
            {
                return ContractTypeView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool ContractTypeViewVisible
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                if (value)
                {
                    mpeContractType.Show();
                }
                else
                {
                    mpeContractType.Hide();
                }
            }
        }

        #endregion
    }
}