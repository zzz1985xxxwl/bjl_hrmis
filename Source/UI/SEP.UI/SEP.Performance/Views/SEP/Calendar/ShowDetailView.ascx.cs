//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ShowDetailView.cs
// 创建者: 王玥琦
// 创建日期: 2008-08-28
// 概述: 查看考勤详情
// ----------------------------------------------------------------
using System;
using System.Web.UI;
using SEP.Presenter.IPresenter.ICalendar;

namespace SEP.Performance.Views.SEP.Calendar
{
    public partial class ShowDetailView : UserControl, IShowDetailView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string Detail
        {
            get { return lbl_Detail.Text; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    lbl_Detail.Text += value + "<br />";
                }
                else
                {
                    lbl_Detail.Text = "";
                }
                //if (value == "")
                //{
                //    for (int i = DetailTable.Rows.Count - 1; i > 0; i--)
                //    {
                //        DetailTable.Rows.RemoveAt(i);
                //    }
                //    lbl_Detail.Text = "";
                //}
                //else
                //{
                //    if (lbl_Detail.Text == "")
                //    {
                //        lbl_Detail.Text = value;
                //    }
                //    else
                //    {
                //        HtmlTableRow htr = new HtmlTableRow();
                //        HtmlTableCell htc = new HtmlTableCell();
                //        htc.Align = "right";
                //        htc.Style.Add("height", "30px");
                //        htc.Style.Add("width", "2%;");
                //        htr.Cells.Add(htc);
                //        htc = new HtmlTableCell();
                //        htc.Align = "left";
                //        htc.Style.Add("height", "30px");
                //        Label label = new Label();
                //        label.Text = value;
                //        htc.Controls.Add(label);
                //        htr.Cells.Add(htc);
                //        DetailTable.Rows.Add(htr);
                //    }
                //}
            }
        }
    }
}