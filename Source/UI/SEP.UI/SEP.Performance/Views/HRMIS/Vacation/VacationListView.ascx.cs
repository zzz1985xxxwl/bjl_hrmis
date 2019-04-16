//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: VacationListView.cs
// ������: ���h��
// ��������: 2008-06-05
// ����: ����б�
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;

namespace SEP.Performance
{
    using System.Data;
    using Views;

    public partial class VacationListView : UserControl, IVacationBaseListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Error.Visible = false;
            count.Visible = true;
            Result.Visible = true;
            if (IsAdd)
            {
                OKEvent = ManageVacationViewAddEvent;
            }
            else
            {
                OKEvent = ManageVacationViewUpdateEvent;
            }
            BindPageTemplate();
        }

        public string EmployeeStatusId
        {
            get
            {
                return ddlEmployeeStatus.SelectedValue;
            }
        }
        protected void LinkButtonGoPage_Click(int pageindex)
        {
            dvVacationList.PageIndex = pageindex;
            Search(this, EventArgs.Empty);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(dvVacationList, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        private EventHandler OKEvent;
        public event EventHandler UpdateEvent;
        public event EventHandler AddEvent;
        public event CommandEventHandler Delete;
        public event CommandEventHandler InitAddVacationDetailEvent;
        public event CommandEventHandler InitUpdateVacationDetailEvent;
        public event EventHandler Search;

        private bool IsAdd
        {
            get
            {
                if (ViewState["IsAdd"] == null)
                {
                    return true;
                }
                else
                {
                    return (bool)ViewState["IsAdd"];
                }
            }
            set { ViewState["IsAdd"] = value; }
        }

        public IVacationBaseView IVacationBaseView
        {
            get { return ManageVacationView1; }
            set { }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            OKEvent(sender, e);
        }

        #region delete

        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            Delete(sender, e);
            Search(sender, e);
        }

        #endregion

        #region update

        protected void btnUpdate_Click(object sender, CommandEventArgs e)
        {
            IsAdd = false;
            InitUpdateVacationDetailEvent(null, e);
            mpeEdit.Show();
        }

        private void ManageVacationViewUpdateEvent(object sender, EventArgs e)
        {
            UpdateEvent(sender, e);
            if (ManageVacationView1.IsError)
            {
                mpeEdit.Show();
            }
            else
            {
                mpeEdit.Hide();
                Search(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Add

        protected void btnAdd_Click(object sender, CommandEventArgs e)
        {
            IsAdd = true;
            InitAddVacationDetailEvent(null, e);
            mpeEdit.Show();
        }

        private void ManageVacationViewAddEvent(object sender, EventArgs e)
        {
            AddEvent(sender, e);
            if (ManageVacationView1.IsError)
            {
                mpeEdit.Show();
            }
            else
            {
                mpeEdit.Hide();
                Search(this, EventArgs.Empty);
            }
        }

        #endregion

        #region search

        public string Message
        {
            set
            {
                lblMessage.Text = value;
                Error.Visible = !string.IsNullOrEmpty(lblMessage.Text.Trim());
                count.Visible = string.IsNullOrEmpty(lblMessage.Text.Trim());
            }
            get { return string.Empty; }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search(sender, e);
        }


        private List<Vacation> VacationSourceViewState
        {
            get { return ViewState["VacationSource"] as List<Vacation>; }
            set { ViewState["VacationSource"] = value; }
        }
        private List<Vacation> _VacationList;

        public List<Vacation> VacationList
        {
            get { return _VacationList ?? new List<Vacation>(); }
            set
            {
                VacationSourceViewState = value;
                lbCount.Text = value.Count.ToString();
                Result.Visible = value.Count <= 0 ? false : true;
                _VacationList = value;
                dvVacationList.DataSource = value;
                dvVacationList.DataBind();
            }
        }

        public string EmployeeNameForSearch
        {
            get { return txtName.Text.Trim(); }
            set { }
        }

        public string VacationDayNumStart
        {
            get { return txtVacationDayNumStart.Text.Trim(); }
            set { }
        }

        public string VacationDayNumEnd
        {
            get { return txtVacationDayNumEnd.Text.Trim(); }
            set { }
        }

        public string VacationEndDateStart
        {
            get { return txtVacationEndDateStart.Text.Trim(); }
            set { }
        }

        public string VacationEndDateEnd
        {
            get { return txtVacationEndDateEnd.Text.Trim(); }
            set { }
        }

        public string SurplusDayNumStart
        {
            get { return txtSurplusDayNumStart.Text.Trim(); }
            set { }
        }

        public string SurplusDayNumEnd
        {
            get { return txtSurplusDayNumEnd.Text.Trim(); }
            set { }
        }

        #endregion

        protected void dvVacationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dvVacationList.PageIndex = e.NewPageIndex;
            Search(this, EventArgs.Empty);
        }

        protected void dvVacationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable ret_dt = new DataTable();
            ret_dt.Columns.Add("Ա������");
            ret_dt.Columns.Add("��������");
            ret_dt.Columns.Add("ְλ");
            ret_dt.Columns.Add("�����ʼ��");
            ret_dt.Columns.Add("��ٵ�����");
            ret_dt.Columns.Add("���������");
            ret_dt.Columns.Add("��������");
            ret_dt.Columns.Add("ʣ������");
            ret_dt.Columns.Add("��ע");
            for (int i = 0; i < VacationSourceViewState.Count; i++)
            {
                DataRow dr = ret_dt.NewRow();
                dr["Ա������"] = VacationSourceViewState[i] != null &&
                                         VacationSourceViewState[i].Employee != null &&
                                         VacationSourceViewState[i].Employee.Account != null &&
                                         VacationSourceViewState[i].Employee.Account.Name != null
                                             ? VacationSourceViewState[i].Employee.Account.Name
                                             : "";
                dr["��������"] = VacationSourceViewState[i] != null &&
                                        VacationSourceViewState[i].Employee != null &&
                                        VacationSourceViewState[i].Employee.Account != null &&
                                        VacationSourceViewState[i].Employee.Account.Dept != null &&
                                        VacationSourceViewState[i].Employee.Account.Dept.Name != null
                                            ? VacationSourceViewState[i].Employee.Account.Dept.Name
                                            : "";
                dr["ְλ"] = VacationSourceViewState[i] != null &&
                                        VacationSourceViewState[i].Employee != null &&
                                        VacationSourceViewState[i].Employee.Account != null &&
                                        VacationSourceViewState[i].Employee.Account.Position != null &&
                                        VacationSourceViewState[i].Employee.Account.Position.Name != null
                                            ? VacationSourceViewState[i].Employee.Account.Position.Name
                                            : "";
                dr["�����ʼ��"] = VacationSourceViewState[i].VacationStartDate;
                dr["��ٵ�����"] = VacationSourceViewState[i].VacationEndDate;
                dr["���������"] = VacationSourceViewState[i].VacationDayNum;
                dr["��������"] = VacationSourceViewState[i].UsedDayNum;
                dr["ʣ������"] = VacationSourceViewState[i].SurplusDayNum;
                dr["��ע"] = VacationSourceViewState[i].Remark;
                ret_dt.Rows.Add(dr);
            }
            MemoryStream ms = ExcelExportUtility.DataTableTurnToExcel(ret_dt, "Ա�����");
            ExcelExportUtility.OutputExcel(Server, Response, "Ա�����", ms);

        }

    }
}