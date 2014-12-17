//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ConfirmAssessView.cs
// ������: ������
// ��������: 2008-06-17
// ����: ���ȷ�Ͽ�����Ľ���
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;

namespace MyCmmiWebSite.Performance.Views.AssessActivity
{
    public partial class ConfirmAssessView :UserControl,IConfirmAssessView
    {
        public EventHandler btnConfirmClick;

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            btnConfirmClick(sender,e);
        }

        #region IConfirmAssessView ��Ա

        public string SubmitID
        {
            get
            {
                return hfSubmitID.Value;
            }
            set
            {
                hfSubmitID.Value = value;
            }
        }

        public string Message
        {
            set
            {
                lblMessage.Text = value;
                if (String.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
            }
        }

        public string PersonalExpectedMsg
        {
            set { lblPersonalExpectedTimeMsg.Text = value; }
        }

        public string ManagerExpectedMsg
        {
            set { lblManagerExpectedTimeMsg.Text = value; }
        }

        public string PersonalExpectedTime
        {
            set { dtpPersonalExpectedFinish.Text = value; }
            get
            {
                return dtpPersonalExpectedFinish.Text;
            }
        }

        public string ManagerExpectedFinish
        {
            set { dtpManagerExpectedFinish.Text = value; }
            get
            {
                return dtpManagerExpectedFinish.Text;
            }
        }

        public List<AssessTemplatePaper> AssessTempletPaperNames
        {
            set
            {
                ddlTemplatePaper.DataSource = value;
                ddlTemplatePaper.DataTextField = "PaperName";
                ddlTemplatePaper.DataValueField = "AssessTemplatePaperID";
                ddlTemplatePaper.DataBind();
            }
        }

        public int AssessTempletPaperID
        {
            get
            {
                return Convert.ToInt32(ddlTemplatePaper.SelectedValue);
            }
            set
            {
                ddlTemplatePaper.SelectedValue = value.ToString();
            }
        }

        #endregion
    }
}