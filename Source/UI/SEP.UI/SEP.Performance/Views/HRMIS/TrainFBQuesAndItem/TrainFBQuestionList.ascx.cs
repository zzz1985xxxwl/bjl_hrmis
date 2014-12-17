using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.TrainFBQuesAndItem
{
    public partial class TrainFBQuestionList : UserControl, ITrainFBQuestionList
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grv.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grv, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        private List<TrainFBQuestion> _TrainFBQuestion;
        #region ITrainFBQuestionList ≥…‘±

        public string TrainQuesID
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string TrainQuestion
        {
            get
            {
                return txtFBQuesName.Text.Trim();
            }
            set
            {
                txtFBQuesName.Text = value;
            }
        }

        public string SearchMessage
        {
            get
            {
                return lblMessage.Text.Trim();
            }
            set
            {
                lblMessage.Text = value;
            }
        }

        public List<TrainFBQuestion> TrainQuestions
        {
            get
            {
                return _TrainFBQuestion;
            }
            set
            {

                _TrainFBQuestion = value;
                grv.DataSource = value;
                grv.DataBind();
                if (_TrainFBQuestion == null || _TrainFBQuestion.Count == 0)
                {
                    listQuestion.Style["display"] = "none";
                }
                else
                {
                    listQuestion.Style["display"] = "block";
                }
                lblMessage.Text = value.Count.ToString();
            }
        }

        public string TrainQuestionType
        {
            get
            {
                if (string.IsNullOrEmpty(ddType.SelectedValue))
                {
                    return "-1";
                }
                else
                    return ddType.SelectedValue;
            }



            set
            {
                ddType.SelectedValue = value;
            }
        }

        public List<TrainFBQuesType> TrainQuestionTypes
        {
            get { throw new NotImplementedException(); }
            set
            {
                ddType.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, "-1", true);
                ddType.Items.Add(itemAll);
                foreach (TrainFBQuesType type in value)
                {
                    ddType.Items.Add(new ListItem(type.Name, type.ParameterID.ToString(), true));
                }
            }
        }

        public event DelegateNoParameter btnSearchClick;

        public event EventHandler BtnAddEvent;

        public event CommandEventHandler BtnUpdateEvent;

        public event CommandEventHandler BtnDeleteEvent;

        public event CommandEventHandler BtnDetailEvent;

        //public event CommandEventHandler BtnItemEvent;

        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BtnAddEvent(sender, e);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearchClick();
        }

        protected void btnUpdate_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateEvent(sender, e);
        }

        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            BtnDeleteEvent(sender, e);
        }

        //protected void btnItems_Click(object sender, CommandEventArgs e)
        //{
        //    BtnItemEvent(sender, e);
        //}


        protected void grv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv.PageIndex = e.NewPageIndex;
            btnSearch_Click(sender, e);
        }

        protected void grv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    BtnDetailEvent(sender, e);
                    return;
            }

        }

        protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }

        }
    }
}