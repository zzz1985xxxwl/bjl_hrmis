using System;
using System.Web.UI;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;

namespace SEP.Performance.Views.Employee
{
    public partial class ContractWithConditionView : UserControl
    {
        public ApplyAssessConditionAddPresenter applyAssessConditionAddPresenter;
        public ApplyAssessConditionUpdatePresenter applyAssessConditionUpdatePresenter;
        public ApplyAssessConditionDeletePresenter applyAssessConditionDeletePresenter;
        public ApplyAssessConditionDetailPresenter applyAssessConditionDetailPresenter;
        public ApplyAssessConditionListInContractPresenter applyAssessConditionListInContractPresenter;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            EmployeeContractView1._ShowWindowForAddAssessCondition = ShowWindowForAdd;
            EmployeeContractView1._ShowWindowForModifyAssessCondition = ShowWindowForModify;
            EmployeeContractView1._ShowWindowForDeleteAssessCondition = ShowWindowForDelete;
            EmployeeContractView1._ShowWindowForDetailAssessCondition = ShowWindowForDetail;
            EmployeeContractView1._GetSystemSet = GetSystemSetForList;
            applyAssessConditionListInContractPresenter =
                new ApplyAssessConditionListInContractPresenter(EmployeeContractView1, ApplyAssessConditionView1);

            applyAssessConditionAddPresenter = new ApplyAssessConditionAddPresenter(ApplyAssessConditionView1);
            applyAssessConditionAddPresenter._GVAddApplyAssessCondition += GVAddApplyAssessCondition;
            applyAssessConditionUpdatePresenter = new ApplyAssessConditionUpdatePresenter(ApplyAssessConditionView1);
            applyAssessConditionUpdatePresenter._GVUpdateApplyAssessCondition += GVUpdateApplyAssessCondition;
            applyAssessConditionDeletePresenter = new ApplyAssessConditionDeletePresenter(ApplyAssessConditionView1);
            applyAssessConditionDeletePresenter._GVDeleteApplyAssessCondition = GVDeleteApplyAssessCondition;
            applyAssessConditionDetailPresenter = new ApplyAssessConditionDetailPresenter(ApplyAssessConditionView1);
            ApplyAssessConditionView1._UpdateListWindow = UpdateWindow;
            ApplyAssessConditionView1.btnCancelClick += HideWindow;

            switch (Operation.Value)
            {
                case "add":
                    ApplyAssessConditionView1.btnOKClick += applyAssessConditionAddPresenter.btnOKClick;
                    break;
                case "update":
                    ApplyAssessConditionView1.btnOKClick += applyAssessConditionUpdatePresenter.btnOKClick;
                    break;
                case "delete":
                    ApplyAssessConditionView1.btnOKClick += applyAssessConditionDeletePresenter.btnOKClick;
                    break;
                case "detail":
                    ApplyAssessConditionView1._UpdateListWindow = None;
                    ApplyAssessConditionView1.btnOKClick += HideWindow;
                    break;
                default:
                    break;
            }

            ApplyAssessConditionView1.btnCancelOnClientClick
             = "return CloseModalPopupExtender('" + divMPE.ClientID + "');";


        }

        private void HideWindow(object sender, EventArgs e)
        {
            mpeAssessCondition.Hide();
        }
        private void ShowWindowForAdd()
        {
            Operation.Value = "add";
            applyAssessConditionAddPresenter.InitView(false);
            mpeAssessCondition.Show();
        }
        private void ShowWindowForModify(ApplyAssessCondition applyAssessCondition)
        {
            Operation.Value = "update";
            applyAssessConditionUpdatePresenter.InitView(applyAssessCondition, false);
            UpdatePanelWork.Update();
            mpeAssessCondition.Show();
        }
        private void ShowWindowForDelete(ApplyAssessCondition applyAssessCondition)
        {
            Operation.Value = "delete";
            applyAssessConditionDeletePresenter.InitView(applyAssessCondition, false);
            UpdatePanelWork.Update();
            mpeAssessCondition.Show();
        }
        private void ShowWindowForDetail(ApplyAssessCondition applyAssessCondition)
        {
            Operation.Value = "detail";
            applyAssessConditionDetailPresenter.InitView(applyAssessCondition, false);
            UpdatePanelWork.Update();
            mpeAssessCondition.Show();
        }
        private void UpdateWindow()
        {
            if (string.IsNullOrEmpty(ApplyAssessConditionView1.Message) &&
                string.IsNullOrEmpty(ApplyAssessConditionView1.ApplyDateMsg) &&
                string.IsNullOrEmpty(ApplyAssessConditionView1.ScopeMsg))
            {
                UpdatePanelWork.Update();
                mpeAssessCondition.Hide();
            }
            else
            {
                mpeAssessCondition.Show();
            }
        }
        public void None()
        {
        }
        private void GetSystemSetForList()
        {
            applyAssessConditionListInContractPresenter.GetSystemSet();
        }

        public void GVAddApplyAssessCondition(ApplyAssessCondition applyAssessCondition)
        {
            applyAssessConditionListInContractPresenter.AddApplyAssessConditionInContractView(applyAssessCondition);
        }
        public void GVUpdateApplyAssessCondition(ApplyAssessCondition applyAssessCondition)
        {
            applyAssessConditionListInContractPresenter.UpdateApplyAssessConditionInContractView(applyAssessCondition);
        }
        public void GVDeleteApplyAssessCondition(int applyAssessConditionID)
        {
            applyAssessConditionListInContractPresenter.DeleteApplyAssessConditionInContractView(applyAssessConditionID);
        }

    }
}