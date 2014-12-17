using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.AdjustRules;

namespace SEP.Performance.Views.HRMIS.AdjustRules
{
    public partial class AdjustRuleInfoView : UserControl
    {
        private AddAdjustRulePresenter _AddAdjustRulePresenter;
        private UpdateAdjustRulePresenter _UpdateAdjustRulePresenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            new AdjustRuleListPresenter(AdjustRuleListView1, IsPostBack);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            switch (AdjustRuleEditView1.OpreationType)
            {
                case "Add":
                    _AddAdjustRulePresenter = new AddAdjustRulePresenter(AdjustRuleEditView1, IsPostBack);
                    break;
                case "Update":
                    _UpdateAdjustRulePresenter = new UpdateAdjustRulePresenter(AdjustRuleEditView1, IsPostBack);
                    break;
                case "Detail":
                    new DetailAdjustRulePresenter(AdjustRuleEditView1, IsPostBack);
                    break;
                default:
                    _AddAdjustRulePresenter = new AddAdjustRulePresenter(AdjustRuleEditView1, IsPostBack);
                    break;
            }
        }

        public void AttachViewEvent()
        {
            //大界面按钮
            AdjustRuleListView1.AddAdjustRule += ShowAddView;
            AdjustRuleListView1.UpdateAdjustRule += ShowUpdateView;
            AdjustRuleListView1.ShowAdjustRule += ShowDetailView;
            if (_AddAdjustRulePresenter != null)
            {
                _AddAdjustRulePresenter._OverEvent += ActionEvent;
            }
            if (_UpdateAdjustRulePresenter != null)
            {
                _UpdateAdjustRulePresenter._OverEvent += ActionEvent;
            }
        }

        private void ShowAddView()
        {
            new AddAdjustRulePresenter(AdjustRuleEditView1, false);
            AdjustRuleEditView1.OpreationType = "Add";
            ShowView();
        }

        private void ShowUpdateView(string id)
        {
            AdjustRuleEditView1.AdjustRuleID = Convert.ToInt32(id);
            new UpdateAdjustRulePresenter(AdjustRuleEditView1, false);
            AdjustRuleEditView1.OpreationType = "Update";
            ShowView();
        }


        private void ShowDetailView(string id)
        {
            AdjustRuleEditView1.AdjustRuleID = Convert.ToInt32(id);
            new DetailAdjustRulePresenter(AdjustRuleEditView1, false);
            AdjustRuleEditView1.OpreationType = "Detail";
            ShowView();
        }


        public void ActionEvent()
        {
            if (AdjustRuleEditView1.AcctionSussess)
            {
                new AdjustRuleListPresenter(AdjustRuleListView1, false);
                mpeAdjustRule.Hide();
                UpdatePanel1.Update();
            }
            else
            {
                ShowView();
            }
        }
        private void ShowView()
        {
            AttachViewEvent();
            mpeAdjustRule.Show();
        }
    }
}