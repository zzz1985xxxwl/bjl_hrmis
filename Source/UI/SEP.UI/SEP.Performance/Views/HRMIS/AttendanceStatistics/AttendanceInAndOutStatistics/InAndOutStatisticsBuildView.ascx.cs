//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: InAndOutStatisticsBuildView.cs
// ������: ���h��
// ��������: 2008-10-17
// ����: ����ͳ�Ƽ�¼
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.ChoseEmployee;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IAttendanceInAndOutStatistics;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.ReadDataViews;
using SEP.HRMIS.Presenter.IPresenter.IChoseEmployee;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceInAndOutStatistics
{
    public partial class InAndOutStatisticsBuildView : UserControl, IInAndOutStatisticsBuildView
    {
        /// <summary>
        /// �����
        /// </summary>
        public IInAndOutStatisticsView InAndOutStatisticsView
        {
            get { return (IInAndOutStatisticsView) InAndOutStatisticsView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }
        /// <summary>
        /// С����
        /// </summary>
        public IReadAttendanceRuleView ReadAttendanceRuleView
        {
            get { return SetReadDataRuleView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }
        /// <summary>
        /// С����
        /// </summary>
        public IReadHistoryListView ReadHistoryListView
        {
            get { return ReadHistoryListView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }
        ///// <summary>
        ///// С����
        ///// </summary>
        //public ICreateAttendanceForOperator CreateAttendanceForOperatorView
        //{
        //    get { return CreateAttendanceForOperator1; }
        //    set { throw new Exception("The method or operation is not implemented."); }
        //}
        /// <summary>
        /// С����ɼ�
        /// </summary>
        public bool CreateAttendanceForOperatorViewVisible
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set
            {
                if (value)
                {
                    mpeInAndOutStatistics3.Show();
                }
                else
                {
                    mpeInAndOutStatistics3.Hide();
                }
            }
        }
        public bool ReadAttendanceRuleViewVisible
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set
            {
                if (value)
                {
                    mpeInAndOutStatistics2.Show();
                }
                else
                {
                    mpeInAndOutStatistics2.Hide();
                }
            }
        }
        public bool ReadHistoryListViewVisible
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set
            {
                if (value)
                {
                    mpeInAndOutStatistics1.Show();
                }
                else
                {
                    mpeInAndOutStatistics1.Hide();
                }
            }
        }

        #region for ICreateAttendanceForOperator

        private Account _Account;
        public Account LoginUser
        {
            get { return _Account; }
            set { _Account = value; }
        }
        public List<Account> EmployeeList
        {
            get { return ChoseEmployeeView1.AccountRight; }
            set { ChoseEmployeeView1.AccountRight = value; }
        }
        public string Message
        {
            set
            {
                lblMessage.Text = value;
                if (!string.IsNullOrEmpty(value))
                {
                    tbMessage.Visible = true;
                }
                else
                {
                    tbMessage.Visible = false;
                }
            }
        }
        public string SearchFrom
        {
            get { return dtpScopeFrom.Text; }
        }
        public string SearchTo
        {
            get { return dtpScopeTo.Text; }
        }

        public event DelegateID BtnReadFromXLSEvent;
        public event DelegateNoParameter BtnCancelEvent;
        public event DelegateNoParameter ShowCreateAttendanceForOperator;

        public IChoseEmployeeView ChoseEmployeeView
        {
            get { return ChoseEmployeeView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }
        public bool IChoseEmployeeViewVisible
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set
            {
                if (value)
                {
                    mpeChoseEmployeeView.Show();
                }
                else
                {
                    mpeChoseEmployeeView.Hide();
                }
            }
        }
        protected void btnReadFromXLS_Click(object sender, EventArgs e)
        {
            string uploadFileLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
            if (!Directory.Exists(uploadFileLocation))
            {
                Directory.CreateDirectory(uploadFileLocation);
            }
            HttpPostedFile hpf = fuExcel.PostedFile;
            if (hpf != null)
            {
                string filename = Path.GetFileName(hpf.FileName);
                string fileExt = Path.GetExtension(hpf.FileName);
                string filePath = uploadFileLocation + "\\��������.xls";
                string returnMessage;
                if (Validation(filename, fileExt, out returnMessage))
                {
                    hpf.SaveAs(filePath);
                    if (BtnReadFromXLSEvent != null)
                    {
                        BtnReadFromXLSEvent(filePath);
                    }
                }
                else
                {
                    Message = "<span class='fontred'>" + returnMessage + "</span>";
                }
            }
            ShowCreateAttendanceForOperator();
        }
        private bool Validation(string filename, string fileExt, out string returnMessage)
        {
            returnMessage = "";
            bool returnValidation = true;
            if (!string.IsNullOrEmpty(filename.Trim()))
            {
                if (fileExt == ".xls" || fileExt == ".xlsx")
                {
                }
                else
                {
                    returnMessage = "������ļ���ʽ����";
                    returnValidation = false;
                }
            }
            else
            {
                returnMessage = "û��Ҫ������ļ�!";
                returnValidation = false;
            }
            if (EmployeeList.Count==0)
            {
                return returnValidation;
            }
            if (string.IsNullOrEmpty(dtpScopeFrom.Text) || string.IsNullOrEmpty(dtpScopeTo.Text))
            {
                returnMessage = returnMessage + " ���������ɿ���ͳ�Ƶ�ʱ�䷶Χ!";
                return false;
            }
            if (!DateTime.TryParse(dtpScopeFrom.Text, out _SearchFrom))
            {
                returnMessage = returnMessage + " ʱ���ʽ���ò���ȷ��";
                return false;
            }
            if (!DateTime.TryParse(dtpScopeTo.Text, out _SearchTo))
            {
                returnMessage = returnMessage + " ʱ���ʽ���ò���ȷ��";
                return false;
            }
            if (DateTime.Compare(_SearchFrom, _SearchTo) > 0)
            {
                returnMessage = returnMessage + " ʱ���ʽ���ò���ȷ��";
                return false;
            }
            return returnValidation;
        }

        private DateTime _SearchFrom;
        private DateTime _SearchTo;

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BtnCancelEvent();
        }

        #region ChoseEmployee

        private void DefineOutSessionName()
        {
            ChoseEmployeeView1.AccountRightViewStateName = "MailCCRight";
            ChoseEmployeeView1.AccountLeftViewStateName = "MailCCLeft";
        }

        private void ChoseAccountAjax(object sender, EventArgs e)
        {
            txtEmployeeList.Text = RequestUtility.GetEmployeeNames(ChoseEmployeeView1.AccountRight);
            mpeChoseEmployeeView.Show();
        }

        private void SearchAccountAjax(object sender, EventArgs e)
        {
            mpeChoseEmployeeView.Show();
        }

        public List<Account> ChoseEmployee
        {
            get { return ChoseEmployeeView1.AccountRight; }
            set { ChoseEmployeeView1.AccountRight = value; }
        }
        #endregion
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            ChoseEmployeePresenter choseEmployeePresenter =
    new ChoseEmployeePresenter(ChoseEmployeeView1, _Account);
            choseEmployeePresenter.PowerID = HrmisPowers.A503;
            DefineOutSessionName();
            ChoseEmployeeView1.AttachAccountAjax += ChoseAccountAjax;
            ChoseEmployeeView1.SearchAjax += SearchAccountAjax;

        }
    }
}