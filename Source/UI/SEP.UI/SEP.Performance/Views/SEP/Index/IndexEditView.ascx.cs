using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SEP.Model.Accounts;
using SEP.Presenter.Indexs;
using SEP.Presenter.IPresenter.IIndexs;

namespace SEP.Performance.Views.SEP.Index
{
    public partial class IndexEditView : UserControl, IIndexEditView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new IndexEditPresenter(this, Session[SessionKeys.LOGININFO] as Account);
        }

        public delegate void EmptyDelegate(string location, string id, string title, int webpart, bool isIFrame);

        public EmptyDelegate _AddView;

        public List<IndexItem> SepToolList
        {
            get { return ViewState["SepToolList"] as List<IndexItem>; }
            set { BuildTable(value, tableNormal, "SepToolList"); }
        }

        public List<IndexItem> HrmisToolList
        {
            get { return ViewState["HrmisToolList"] as List<IndexItem>; }
            set
            {
                if (value != null&&value.Count>0)
                {
                    lblHrmis.Text =
                        "<div id=\"floatbt2\" class=\"floatsetbt\"><a href=\"#\" onclick=\"conshowmenutext(2)\">Hrmis</a></div>";
                }
                BuildTable(value, tableHrmis, "HrmisToolList");
            }
        }

        public List<IndexItem> CrmToolList
        {
            get { return ViewState["CrmToolList"] as List<IndexItem>; }
            set
            {
                if (value != null && value.Count > 0)
                {
                    lblCrm.Text =
                        "<div id=\"floatbt3\" class=\"floatsetbt\"><a href=\"#\" onclick=\"conshowmenutext(3)\">CRM</a></div>";
                }
                BuildTable(value, tableCrm, "CrmToolList");
            }
        }

        public List<IndexItem> MyCmmiToolList
        {
            get { return ViewState["MyCmmiToolList"] as List<IndexItem>; }
            set
            {
                if (value != null && value.Count > 0)
                {
                    lblMyCmmi.Text =
                        "<div id=\"floatbt4\" class=\"floatsetbt\"><a href=\"#\" onclick=\"conshowmenutext(4)\">MyCMMI</a></div>";
                }
                BuildTable(value, tableMyCmmi, "MyCmmiToolList");
            }
        }

        ///// <summary>
        ///// 当加新的tap页时需要修改
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    AddWebPart(SepToolList, tableNormal);
        //    AddWebPart(HrmisToolList, tableHrmis);
        //    AddWebPart(CrmToolList, tableCrm);
        //    AddWebPart(MyCmmiToolList, tableMyCmmi);
        //}

        #region 内部方法

        private void BuildTable(IList<IndexItem> value, HtmlTable table, string viewStateName)
        {
            ViewState[viewStateName] = value;      
            if (value != null&&value.Count>0)
            {
                int rowcount = value.Count % 4 == 0 ? value.Count / 4 : ((value.Count + 4 - value.Count % 4) / 4);
                for (int i = 0; i < rowcount; i++)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    HtmlTableCell cell1 = new HtmlTableCell();
                    cell1.Width = "25%";
                    cell1.Align = "left";
                    row.Cells.Add(cell1);
                    HtmlTableCell cell2 = new HtmlTableCell();
                    cell2.Width = "25%";
                    cell2.Align = "left";
                    row.Cells.Add(cell2);
                    HtmlTableCell cell3 = new HtmlTableCell();
                    cell3.Width = "25%";
                    cell3.Align = "left";
                    row.Cells.Add(cell3);
                    HtmlTableCell cell4 = new HtmlTableCell();
                    cell4.Width = "25%";
                    cell4.Align = "left";
                    row.Cells.Add(cell4);
                    table.Rows.Add(row);
                }
                int j = 0;
                for (int i = 0; i < value.Count; i++)
                {
                    //Image img = new Image();
                    //img.Attributes["src"] = value[i].ImgSrc;
                    //img.Width = 78;
                    //img.Height = 85;
                    CheckBox checkBox = new CheckBox();
                    checkBox.Text = value[i].CheckBoxText;
                    //checkBox.Width = 80;
                    checkBox.ID = value[i].CheckBoxID;
                    checkBox.Attributes["viewLocation"] = "../../"+value[i].ViewLocation;
                    checkBox.Attributes["viewName"] = value[i].ViewName;
                    checkBox.Attributes["webPartLocation"] = value[i].WebPartLocation.ToString();

                    if ((i + 1)%4 == 1)
                    {
                        //table.Rows[j].Cells[0].Controls.Add(img);
                        table.Rows[j].Cells[0].Controls.Add(checkBox);
                    }
                    else if ((i + 1)%4 == 2)
                    {
                        //table.Rows[j].Cells[1].Controls.Add(img);
                        table.Rows[j].Cells[1].Controls.Add(checkBox);
                    }
                    else if ((i + 1) % 4 == 3)
                    {
                        //table.Rows[j].Cells[2].Controls.Add(img);
                        table.Rows[j].Cells[2].Controls.Add(checkBox);
                    }
                    else
                    {
                        //table.Rows[j].Cells[3].Controls.Add(img);
                        table.Rows[j].Cells[3].Controls.Add(checkBox);
                        j++;
                    }
                }
            }
        }
        private static IndexItem GetIndexItemByCheckBoxID(IEnumerable<IndexItem> items, string checkBoxID)
        {
            if (items != null)
            {
                foreach (IndexItem item in items)
                {
                    if (item.CheckBoxID == checkBoxID)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        //private void AddWebPart(IEnumerable<IndexItem> items, HtmlTable table)
        //{
        //    if (items != null)
        //    {
        //        for (int i = 0; i < table.Rows.Count; i++)
        //        {
        //            for (int j = 0; j < 4; j++)
        //            {
        //                if (table.Rows[i].Cells[j].Controls.Count == 1)
        //                {
        //                    CheckBox cbx;
        //                    Control c = table.Rows[i].Cells[j].Controls[0];
        //                    if ((cbx = c as CheckBox) != null)
        //                    {
        //                        if (cbx.Checked)
        //                        {
        //                            IndexItem item = GetIndexItemByCheckBoxID(items, cbx.ID);
        //                            if (item != null)
        //                            {
        //                                _AddView(item.ViewLocation, item.ViewID, item.ViewName, item.WebPartLocation);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        #endregion

    }
}
