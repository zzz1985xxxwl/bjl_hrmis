using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;

namespace SEP.Performance.Views.HRMIS.Train
{
    public partial class TrainCourseBackSearch : UserControl, ITrainCourseBackSearchView
    {
        public EventHandler SearchEvent;
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchEvent(sender, e);
        }

        #region ITrainCourseBackSearchView ≥…‘±

        public string ErrorMessage
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        public string CourseName
        {
            get { return txtCourseName.Text; }
            set { txtCourseName.Text = value; }
        }

        public string Trainer
        {
            get { return txtTrainer.Text; }
            set { txtTrainer.Text = value; }
        }

        public string Codinator
        {
            get { return txtCodinator.Text; }
            set { txtCodinator.Text = value; }
        }

        public string Scope
        {
            get { return listScope.SelectedValue; }
            set { listScope.SelectedItem.Value = value; }
        }

        public string Status
        {
            get { return listStatus.SelectedValue; }
            set { listStatus.SelectedItem.Value = value; }
        }

        public string Skill
        {
            get { return txtSkill.Text; }
            set { txtSkill.Text = value; }
        }

        public string Trainee
        {
            get { return txtTrainee.Text; }
            set { txtTrainee.Text = value; }
        }

        public string ExpectedST
        {
            get { return txtExpectedST.Text; }
            set { txtExpectedST.Text = value; }
        }

        public string ExpectedET
        {
            get { return txtExpectedET.Text; }
            set { txtExpectedET.Text = value; }
        }

        public string ActualST
        {
            get { return txtActualST.Text; }
            set { txtActualST.Text = value; }
        }

        public string ActualET
        {
            get { return txtActualET.Text; }
            set { txtActualET.Text = value; }
        }

        public string TimeErrorMessage
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        public string ExpectedCost
        {
            get { return txtExpectedCost.Text; }
            set { txtExpectedCost.Text = value; }
        }

        public string ExpectedHour
        {
            get { return txtExpectedHour.Text; }
            set { txtExpectedHour.Text = value; }
        }

        public string ActualCost
        {
            get { return txtActualCost.Text; }
            set { txtActualCost.Text = value; }
        }

        public string ActualHour
        {
            get { return txtActualHour.Text; }
            set { txtActualHour.Text = value; }
        }

        public string CostErrorMessage
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        public List<TrainScopeType> ScopeSource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                listScope.Items.Clear();
                foreach (TrainScopeType scopeType in value)
                {
                    listScope.Items.Add(new ListItem(scopeType.Name, scopeType.Id.ToString(), true));
                }
            }
        }

        public List<TrainStatusType> StatusSource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                listStatus.Items.Clear();
                foreach (TrainStatusType statusType in value)
                {
                    listStatus.Items.Add(new ListItem(statusType.Name, statusType.Id.ToString(), true));
                }
            }
        }

        public ITrainCourseListView listView
        {
            get
            {
                return TrainCourseListView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTrainCourse.aspx");
        }
    }
}