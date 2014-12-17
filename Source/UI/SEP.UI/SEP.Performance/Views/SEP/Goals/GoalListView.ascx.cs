//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GoalListView.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-05
// 概述: 目标列表
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Model.Goals;
using SEP.Presenter.IPresenter.IGoals;
using ShiXin.Security;

namespace SEP.Performance.Views
{
    public partial class GoalListView : UserControl, IGoalBaseListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate(string.Empty);
        }

        protected void PersonLinkButtonGoPage_Click()
        {
            int index;
            if (int.TryParse(ViewState["PersonPageIndex"].ToString().Trim(), out index))
            {
                dvGoalList.PageIndex = index;
                Goal_Search(null, null);
            }
        }

        protected void TeamLinkButtonGoPage_Click()
        {
            int index;
            if (int.TryParse(ViewState["TeamPageIndex"].ToString().Trim(), out index))
            {
                dvGoalList.PageIndex = index;
                Goal_Search(null, null);
            }
        }

        protected void CompanyLinkButtonGoPage_Click()
        {
            int index;
            if (int.TryParse(ViewState["CompanyPageIndex"].ToString().Trim(), out index))
            {
                dvGoalList.PageIndex = index;
                Goal_Search(null, null);
            }
        }

        public void BindPageTemplate(string type)
        {
            if (type != string.Empty)
            {
                ViewState["type"] = type;
            }
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(dvGoalList, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                TextBox txtGoPage = (TextBox)PageTemplate1.FindControl("txtGoPage");

                int index;
                if (int.TryParse(txtGoPage.Text.Trim(), out index))
                {
                    index = index < 1 ? 1 : index;
                    if (type == "Person")
                    {
                        ViewState["PersonPageIndex"] = index - 1;
                    }
                    else if (type == "Team")
                    {
                        ViewState["TeamPageIndex"] = index - 1;
                    }
                    else if (type == "Company")
                    {
                        ViewState["CompanyPageIndex"] = index - 1;
                    }

                }
                if (ViewState["type"] != null)
                {
                    if (ViewState["type"].ToString() == "Person")
                    {
                        PageTemplate1.GoalLinkButtonGoPageClickdelegate += PersonLinkButtonGoPage_Click;
                    }
                    else if (ViewState["type"].ToString() == "Team")
                    {
                        PageTemplate1.GoalLinkButtonGoPageClickdelegate += TeamLinkButtonGoPage_Click;
                    }
                    else if (ViewState["type"].ToString() == "Company")
                    {
                        PageTemplate1.GoalLinkButtonGoPageClickdelegate += CompanyLinkButtonGoPage_Click;
                    }
                }
            }

        }

        private string _DetailRoot;
        private string _UpdateRoot;
        public bool IsEditGoal;

        public string DetailRoot
        {
            get { return string.Empty; }
            set
            {
                _DetailRoot = value;
            }
        }
        public string UpdateRoot
        {
            get { return string.Empty; }
            set
            {
                _UpdateRoot = value;
            }
        }

        public List<Goal> GoalList
        {
            get { return null;}
            set
            {
                if (value != null && value.Count > 0)
                {
                    tbGoalList.Visible = true;
                    dvGoalList.Columns.Clear();
                    //第一列 图
                    TemplateField templateField = new TemplateField();
                    templateField.ItemTemplate = new HiddenPost();
                    dvGoalList.Columns.Add(templateField);
                    //2标题

                    HyperLinkField link = new HyperLinkField();
                    link.HeaderText = "标题";
                    link.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    link.DataTextField = "Title";
                    string[] fields = new string[1];
                    fields[0] = "Id";

                    //link.DataNavigateUrlFields = fields;
                    //link.DataNavigateUrlFormatString = _DetailRoot;
                    dvGoalList.Columns.Add(link);
                    //3时间
                    BoundField col = new BoundField();
                    col.HeaderText = "设置时间";
                    col.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    dvGoalList.Columns.Add(col);
                    //4操作
                    if (IsEditGoal)
                    {
                        link = new HyperLinkField();
                        link.HeaderText = "操作";
                        link.DataNavigateUrlFields = fields;
                        //link.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        //link.ItemStyle.Width = 100;
                        link.Text = "编辑";
                        link.DataNavigateUrlFormatString = _UpdateRoot;
                        dvGoalList.Columns.Add(link);
                        templateField = new TemplateField();
                        templateField.ShowHeader = false;
                        MyTemplate template = new MyTemplate();
                        template.Delete += Goal_Delete;
                        templateField.ItemTemplate = template;
                        dvGoalList.Columns.Add(templateField);
                    }
                    else
                    {
                        col = new BoundField();
                        //col.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        //col.ItemStyle.Width = 100;
                        dvGoalList.Columns.Add(col);
                        col = new BoundField();
                        dvGoalList.Columns.Add(col);
                        btnAdd.Visible = false;
                    }

                    dvGoalList.DataSource = value;
                    dvGoalList.DataBind();
                    int page = dvGoalList.PageIndex;
                    for (int i = 0; i < dvGoalList.Rows.Count; i++)
                    {
                        int row = page*dvGoalList.PageSize + i;
                        dvGoalList.Rows[i].Cells[2].Text = value[row].SetTime.ToShortDateString();
                        ((Button) dvGoalList.Rows[i].Cells[0].Controls[0]).CommandArgument = value[row].Id.ToString();
                        if (IsEditGoal)
                        {
                            ((LinkButton) dvGoalList.Rows[i].Cells[4].Controls[0]).CommandArgument =
                                value[row].Id.ToString();
                        }
                        else
                        {
                            dvGoalList.Rows[i].Cells[3].Enabled = false;
                            dvGoalList.Rows[i].Cells[4].Enabled = false;
                            dvGoalList.Rows[i].Cells[3].Text ="编辑";
                            dvGoalList.Rows[i].Cells[4].Text ="删除";
                        }
                    }
                    dvGoalList.RowStyle.Height = Unit.Pixel(28);
                    dvGoalList.RowStyle.HorizontalAlign = HorizontalAlign.Left;
                    dvGoalList.Columns[0].ItemStyle.Width = Unit.Percentage(10);
                    dvGoalList.Columns[1].ItemStyle.Width = Unit.Percentage(29);
                    dvGoalList.Columns[2].ItemStyle.Width = Unit.Percentage(20);
                    dvGoalList.Columns[3].ItemStyle.Width = Unit.Pixel(55);
                }
                else
                {
                    tbGoalList.Visible = false;
                }
                btnAdd.Visible = IsEditGoal;
            }
        }
        public class MyTemplate : ITemplate
        {
            /// <summary> 
            /// 实现接口ITemplate的方法 
            public void InstantiateIn(Control container)
            {
                LinkButton button = new LinkButton();
                button.CausesValidation = false;
                button.CommandName = "Delete";
                button.Text = "删除";
                button.OnClientClick = "Confirmed = confirm('确定要删除吗？'); return Confirmed;";
                button.Command += GoalList_Command ;
                container.Controls.Add(button);
            }
            private void GoalList_Command(object sender, CommandEventArgs e)
            {
                 Delete(sender, e);
            }
            public CommandEventHandler Delete;
        }
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

        public string Title
        {
            set
            {
                lbl_Title.Text = value;
            }
        }

        public string Message
        {
            get { return string.Empty; }
            set
            {
                lblMessage.Text = value;
            }
        }

        public  CommandEventHandler Goal_Delete;
        public EventHandler Goal_Add;
        protected void dvGoalList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Goal_Add(sender, e);
        }
        public EventHandler Goal_Search;
        protected void dvGoalList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dvGoalList.PageIndex = e.NewPageIndex;
            Goal_Search(this, EventArgs.Empty);
        }

        protected void dvGoalList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    string url = _DetailRoot.Replace("../../Pages/", "");
                    Response.Redirect(string.Format(url, SecurityUtil.DECEncrypt(e.CommandArgument.ToString())));
                    return;
            }
        }

        protected void dvGoalList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }
    }
}