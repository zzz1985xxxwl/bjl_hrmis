//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: VacationShowView.cs
// ������: xue.wenlong
// ��������: 2008-11-1
// ����: Ա���������Ϣ��ʾ�ؼ����൱��detail���棬����ֱ�Ӱ�����aspxҳ�У��ֱ�����VacationView�У�Ȼ�������ʾ
// ----------------------------------------------------------------
using System;
using System.Web.UI;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;

namespace SEP.Performance
{
    public partial class VacationShowView : UserControl
    {
        private Employee _Employee;
        private ShowVacationPresenter _ShowVacationPresenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            ManageVacationView1.AdjustRestVisible = false;
            _ShowVacationPresenter = new ShowVacationPresenter(ManageVacationView1);
            _ShowVacationPresenter.InitVacation(Employee, IsPostBack);
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
    }
}