//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: VacationInfoListView.cs
// ������: xue.wenlong
// ��������: 2008-11-1
// ����: Ա��������ٵ��б�
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;

namespace SEP.Performance
{
    using Views;

    public partial class VacationInfoListView : UserControl, IVacationInfoListView
    {
        private readonly string VacationListViewStateName = "Vacation";
        private Employee _Employee;

        protected void Page_Load(object sender, EventArgs e)
        {
            new VacationInfoListPresenter(this, ManageVacationView1, IsPostBack);
            if (IsAdd)
            {
                btnOKEvent = ManageVacationViewAddEvent;
            }
            else
            {
                btnOKEvent = ManageVacationViewUpdateEvent;
            }
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gdVacationList.PageIndex = pageindex;
            BindVacationList();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gdVacationList, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        /// <summary>
        /// �����ж�С�����Ƿ�Ϊ����
        /// </summary>
        private bool IsAdd
        {
            get { return Convert.ToBoolean(lbIsAdd.Text.Trim()); }
            set { lbIsAdd.Text = value.ToString(); }
        }

        protected void gdVacationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdVacationList.PageIndex = e.NewPageIndex;
            BindVacationList();
        }

        #region �ӿ�        

        public List<Vacation> VacationList
        {
            set
            {
                ViewState[VacationListViewStateName] = value;
                BindVacationList();
            }
            get { return ViewState[VacationListViewStateName] as List<Vacation>; }
        }

        public Employee Employee
        {
            get
            {
                if (_Employee == null)
                {
                    _Employee = new Employee();
                    _Employee.Account.Id = 0;
                    _Employee.Account.Name = "";
                }
                return _Employee;
            }
            set { _Employee = value; }
        }

        public event EventHandler btnOKEvent;
        public event CommandEventHandler DeleteEvent;
        public event CommandEventHandler InitVacationDetailEvent;
        public event EventHandler UpdateEvent;
        public event EventHandler AddEvent;
        public event EventHandler InitEvent;

        #endregion

        public void BindVacationList()
        {
            if (VacationList == null || VacationList.Count < 1)
            {
                tbVacationList.Visible = false;
            }
            else
            {
                tbVacationList.Visible = true;
                //����
                Vacation vacation = new Vacation();
                SortList<Vacation> sortList =
                    new SortList<Vacation>(vacation, "VacationEndDate", ReverserInfo.Direction.DESC);
                VacationList.Sort(sortList);

                gdVacationList.DataSource = VacationList;
                gdVacationList.DataBind();
            }
        }

        //����������
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            IsAdd = true;
            btnOKEvent = ManageVacationViewAddEvent;
            InitVacationDetailEvent(sender, null);
            mpeEdit.Show();
        }

        //����޸����
        protected void BtnUpdate_Click(object sender, CommandEventArgs e)
        {
            IsAdd = false;
            btnOKEvent = ManageVacationViewUpdateEvent;
            InitVacationDetailEvent(sender, e);
            mpeEdit.Show();
        }

        protected void BtnDelete_Click(object sender, CommandEventArgs e)
        {
            DeleteEvent(sender, e);
            BindVacationList();
        }

        protected void ManageVacationViewAddEvent(object sender, EventArgs e)
        {
            AddEvent(sender, e);
            if (ManageVacationView1.IsError)
            {
                mpeEdit.Show();
            }
            else
            {
                mpeEdit.Hide();
                BindVacationList();
            }
        }

        protected void ManageVacationViewUpdateEvent(object sender, EventArgs e)
        {
            UpdateEvent(sender, e);
            if (ManageVacationView1.IsError)
            {
                mpeEdit.Show();
            }
            else
            {
                mpeEdit.Hide();
                BindVacationList();
            }
        }

        #region �������֮���ƶ�ʱ�Ķ�̬Ч��

        protected void gdVacationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        #endregion

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (ManageVacationView1.ViewValidation)
            {
                btnOKEvent(sender, e);
            }
            else
            {
                mpeEdit.Show();
            }
        }

        public bool ReadOnly
        {
            set { 
                btnAdd.Visible = !value;
                for (int i = 0; i < gdVacationList.Rows.Count; i++)
                {
                    LinkButton btnUpdate = (LinkButton)gdVacationList.Rows[i].FindControl("btnUpdate");
                    LinkButton btnDelete = (LinkButton)gdVacationList.Rows[i].FindControl("btnDelete");
                    btnUpdate.Visible = !value;
                    btnDelete.Visible = !value;
                }
            }
        }

        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    mpeEdit.Hide();
        //}
    }
}