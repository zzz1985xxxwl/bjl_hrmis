//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ContractTypeInfoView.ascx.cs
// ������: ���޾�
// ��������: 2008-10-08
// ����: ��ͬ���͵��ܽ���
// ----------------------------------------------------------------
using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;

namespace SEP.Performance.Views.ContractType
{
    public partial class ContractTypeInfoView : UserControl,IContractTypeInfoView
    {
        #region IContractTypeInfoView ��Ա

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