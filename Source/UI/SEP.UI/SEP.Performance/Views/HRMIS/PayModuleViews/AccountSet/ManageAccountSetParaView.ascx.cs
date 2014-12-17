//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���:ManageAccountSetParaView.cs
// ������: wyq
// ��������: 2008-12-25
// ����: ����ManageAccountSetParaView
// ----------------------------------------------------------------

using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet;

namespace SEP.Performance.Views.HRMIS.PayModuleViews
{
    public partial class ManageAccountSetParaView : UserControl, IManageAccountSetParaView
    {
        public IAccountSetParaListView AccountSetParaListView
        {
            get { return AccountSetParaListView1; }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public IAccountSetParaView AccountSetParaView
        {
            get { return AccountSetParaView1; }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool AccountSetParaViewVisible
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }

            set
            {
                if (value)
                {
                    mpeAccountSetPara.Show();
                }

                else
                {
                    mpeAccountSetPara.Hide();
                }
            }
        }
    }
}