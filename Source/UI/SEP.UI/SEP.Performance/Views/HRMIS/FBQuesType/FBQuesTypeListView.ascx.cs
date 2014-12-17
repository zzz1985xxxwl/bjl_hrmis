using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.FBQuesType
{
    public partial class FBQuesTypeListView : UserControl, IFBQuesTypeListView
    {
        private List<TrainFBQuesType> _TrainFBQuesTypes;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            GridView1.PageIndex = pageindex;
            BtnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(GridView1, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        #region IFBQuesTypeListView 成员

        public string FBQuesTypeName
        {
            get
            {
                return TxtName.Text.Trim();
            }
            set
            {
                TxtName.Text = value;
            }
        }

        public List<TrainFBQuesType> FBQuesTypes
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                _TrainFBQuesTypes = value;
                GridView1.DataSource = value;
                GridView1.DataBind();
                if (_TrainFBQuesTypes == null || _TrainFBQuesTypes.Count == 0)
                {
                    Result.Style["display"] = "none";
                }
                else
                {
                    Result.Style["display"] = "block";
                }
                LblMessage.Text = value.Count.ToString();
            }
        }

        public event DelegateNoParameter BtnAddEvent;

        public event DelegateID BtnDeleteEvent;

        public event DelegateID BtnUpdateEvent;

        public event DelegateNoParameter BtnSearchEvent;

        public event DelegateID BtnDetailEvent;

        #endregion

        public class HiddenPost : ITemplate
        {
            /// <summary> 
            /// 实现接口ITemplate的方法 
            public void InstantiateIn(Control container)
            {
                Button btnHiddenPostButton = new Button();
                btnHiddenPostButton.ID = "btnHiddenPostButton";
                btnHiddenPostButton.Text = "";
                btnHiddenPostButton.CommandName = "HiddenPostButtonCommand";
                btnHiddenPostButton.Style["display"] = "none";
                container.Controls.Add(btnHiddenPostButton);
            }
        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }


        protected void lbModify_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateEvent(e.CommandArgument.ToString());
        }

        protected void lbDelete_Click(object sender, CommandEventArgs e)
        {
            BtnDeleteEvent(e.CommandArgument.ToString());
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BtnSearch_Click(sender, e);
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    BtnDetailEvent(e.CommandArgument.ToString());
                    return;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as LinkButton;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BtnAddEvent();
        }
    }
}