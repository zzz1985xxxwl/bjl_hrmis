using System;
using System.Collections.Generic;
using System.Web.UI;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter;
using SEP.HRMIS.Presenter.ChoseEmployee;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;
using SEP.HRMIS.Presenter.IPresenter.IChoseEmployee;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.PlanDutyViews
{
    public partial class SetPlanDutyInfoView : UserControl, ISetPlanDutyInfoView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ChoseEmployeePresenter choseEmployeePresenter=
                new ChoseEmployeePresenter(ChoseEmployeeView1,_Account);
            choseEmployeePresenter.PowerID = HrmisPowers.A502;
            new ReplaceDutyClassPresenter(ReplaceDutyClassView1);
            DefineOutSessionName();
            ChoseEmployeeView1.AttachAccountAjax += ChoseAccountAjax;
            ChoseEmployeeView1.SearchAjax += SearchAccountAjax;
        }

        #region Ñ¡Ô±¹¤

        private void DefineOutSessionName()
        {
            ChoseEmployeeView1.AccountRightViewStateName = "AccountRight";
            ChoseEmployeeView1.AccountLeftViewStateName = "AccountLeft";
        }

        private void ChoseAccountAjax(object sender, EventArgs e)
        {
            SetPlanDutyView1.EmployeeList = RequestUtility.GetEmployeeNames(ChoseEmployeeView1.AccountRight);
            mpeChoseEmployeeView.Show();
        }

        private void SearchAccountAjax(object sender, EventArgs e)
        {
            mpeChoseEmployeeView.Show();
        }

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

        #endregion

        public ISetPlanDutyView SetPlanDutyView
        {
            get { return SetPlanDutyView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public IChoseEmployeeView ChoseEmployeeView
        {
            get { return ChoseEmployeeView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public IReplaceDutyClassView ReplaceDutyClassView
        {
            get
            {
                return ReplaceDutyClassView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
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
        public bool IReplaceDutyClassViewVisible
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                if (value)
                {
                    mpeReplaceDutyClassView.Show();
                }
                else
                {
                    mpeReplaceDutyClassView.Hide();
                }
            }
        }

    }
}