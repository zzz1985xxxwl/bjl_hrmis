//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ViewUtility.cs
// 创建者: wangshali
// 创建日期: 2008-8-19
// 概述: 查询考评活动
// ----------------------------------------------------------------
using System;
using System.Drawing;
using System.Web.UI.WebControls;
using SEP.Performance.Views;

namespace SEP.Performance
{
    public class ViewUtility
    {
        public const string MouseStyle_Hand = "hand";
        public const string MouseStyle_Default = "Default";
        //参考　http://www.cnblogs.com/Jinglecat/archive/2007/07/15/818394.html
        public static void RowDataBound(object sender, GridViewRowEventArgs e, Button btnHiddenPostButton, string overmousestyle)
        {
            if (btnHiddenPostButton != null)
            {
                //事件定义
                if (overmousestyle == MouseStyle_Hand)
                {
                    e.Row.Attributes["onclick"] =
                        String.Format(
                            "if(typeof(Confirmed)=='undefined') Confirmed=true;" +
                            "if(typeof(Confirmed)!='undefined' && Confirmed==true) document.getElementById('{0}').click();" +
                            "Confirmed=true;",
                            btnHiddenPostButton.ClientID);
                }
                else
                {
                    e.Row.Attributes["onclick"] = "return;";
                }
                // 额外样式定义
                RowMouseOver(e, overmousestyle);
            }
        }
        public static void RowDataBound(object sender, GridViewRowEventArgs e, LinkButton btnHiddenPostButton, string overmousestyle)
        {
            if (btnHiddenPostButton != null)
            {
                //事件定义
                if (overmousestyle == MouseStyle_Hand)
                {
                    e.Row.Attributes["onclick"] =
                        String.Format(
                            "if(typeof(Confirmed)=='undefined') Confirmed=true;" +
                            "if(typeof(Confirmed)!='undefined' && Confirmed==true) document.getElementById('{0}').click();" +
                            "Confirmed=true;",
                            btnHiddenPostButton.ClientID);
                }
                else
                {
                    e.Row.Attributes["onclick"] = "return;";
                }
                // 额外样式定义
                RowMouseOver(e, overmousestyle);
            }
        }

        public static void SetGridViewDefaultStyle(GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                RowDataBound(null, e, btnHiddenPostButton, MouseStyle_Default);
            }
        }

        public static void SetTheGridHandStyle(GridViewRowEventArgs e, object sender)
        {
            LinkButton btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as LinkButton;
            if (btnHiddenPostButton != null)
            {
               RowDataBound(sender, e, btnHiddenPostButton, MouseStyle_Hand);
            }
        }

        public static void RowMouseOver(GridViewRowEventArgs e, string overmousestyle)
        {       
            if (e.Row.RowIndex != -1)
            {
                RowMouseOver(e);
                e.Row.Attributes["style"] = "cursor:" + overmousestyle;
            }
        }

        public static void RowMouseOver(GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                if (e.Row.RowIndex % 2 == 0)
                {
                    e.Row.Attributes["onmouseover"] = "$(this).addClass('tablerow_mouseover');";
                    e.Row.Attributes["onmouseout"] = "$(this).removeClass('tablerow_mouseover');";
                }
                else
                {
                    e.Row.Attributes["onmouseover"] = "$(this).removeClass('table_g');$(this).addClass('tablerow_mouseover');";
                    e.Row.Attributes["onmouseout"] = "$(this).addClass('table_g');$(this).removeClass('tablerow_mouseover');";
                }
            }
        }

        public static void RowMouseOver(DataGridItemEventArgs e, string overmousestyle)
        {
            if (e.Item.ItemIndex != -1)
            {
                if (e.Item.ItemIndex % 2 == 0)
                {
                    e.Item.Attributes["onmouseover"] = "$(this).addClass('tablerow_mouseover');";
                    e.Item.Attributes["onmouseout"] = "$(this).removeClass('tablerow_mouseover');";
                }
                else
                {
                    e.Item.Attributes["onmouseover"] = "$(this).removeClass('table_g');$(this).addClass('tablerow_mouseover');";
                    e.Item.Attributes["onmouseout"] = "$(this).addClass('table_g');$(this).removeClass('tablerow_mouseover');";
                }
                e.Item.Attributes["style"] = "cursor:" + overmousestyle;
            }
        }
        public static Color GetRandomColor(Random RandomNum_First, Random RandomNum_Sencond)
        {
            //  为了在白色背景上显示，尽量生成深色 
            int int_Red = RandomNum_First.Next(256);
            int int_Green = RandomNum_Sencond.Next(256);
            int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;

            return Color.FromArgb(int_Red, int_Green, int_Blue);
        }
        public static string SetTableCss(int startIndex, int endIndex, string defaultCss, int currentIndex)
        {
            string ret = defaultCss;
            if (currentIndex == startIndex)
            {
                ret = defaultCss + "Start";
            }
            if (currentIndex == endIndex)
            {
                ret = defaultCss + "End";
            }
            if (endIndex == startIndex)
            {
                ret = defaultCss + "StartEnd";
            }
            return ret;
        }
        public static void DataGridCellCssBind(DataGridItemEventArgs e, int dataGridRowCount)
        {
            foreach (TableCell cell in e.Item.Cells)
            {
                cell.CssClass = "FixedData";
            }
            e.Item.Cells[e.Item.Cells.Count - 1].CssClass = "FixedDataEnd";
            if (e.Item.ItemIndex == -1)
            {
                e.Item.Cells[0].CssClass = "FixedTitleRowColumn";
                for (int i = 1; i < e.Item.Cells.Count; i++)
                {
                    e.Item.Cells[i].CssClass = SetTableCss(1, e.Item.Cells.Count - 1, "FixedTitleRow", i);
                    e.Item.Cells[i].Attributes["nowrap"] = "nowrap";
                }
            }
            else
            {
                e.Item.Cells[0].CssClass =
                    SetTableCss(0, dataGridRowCount - 1, "FixedDataColumn",
                                            e.Item.ItemIndex);
            }
            e.Item.Cells[0].Attributes["nowrap"] = "nowrap";
        }
        [Obsolete]
        public static void GoPage(GridView gvCtrl, object dataSource)
        {
            TextBox txtGoPage = gvCtrl.BottomPagerRow.FindControl("txtGoPage") as TextBox;
            if (txtGoPage != null)
            {
                int index;
                if (int.TryParse(txtGoPage.Text.Trim(), out index))
                {
                    index = index < 1 ? 1 : index;
                    gvCtrl.PageIndex = index - 1;
                    gvCtrl.DataSource = dataSource;
                    gvCtrl.DataBind();
                }
            }
        }

        public static PageTemplate GetPageTemplate(GridView gvCtrl, string pageTemplate1CtrlName)
        {
            if (gvCtrl.BottomPagerRow != null)
            {
                PageTemplate PageTemplate1 =
                    (PageTemplate) gvCtrl.BottomPagerRow.FindControl(pageTemplate1CtrlName);

                return PageTemplate1;
            }
            return null;
        }

    }
}
