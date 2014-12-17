using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using SEP.HRMIS.Model.PayModule;

namespace SEP.Performance.Views.HRMIS.PayModuleViews
{
    using global::SEP.HRMIS.Model;

    public partial class AdjustHistoryDetailView : UserControl, IAdjustHistoryDetailPresenter
    {
        public string ResultMessage
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    divResultMessage.Style["display"] = "none";
                }
                else
                {
                    divResultMessage.Style["display"] = "block";
                    lbResultMessage.Text = value;
                }
            }
        }

        public string EmployeeID
        {
            get
            {
                return hdEmployeeID.Value;
            }
            set
            {
                hdEmployeeID.Value = value;
            }
        }

        public string AdjustHistoryID
        {
            get
            {
                return hdAdjustHistoryID.Value;
            }
            set
            {
                hdAdjustHistoryID.Value = value;
            }
        }

        public EmployeeSalary EmployeeSalary
        {
            set
            {
                EmployeeSalary employeeSalary = value;
                lbName.Text = employeeSalary.Employee.Account.Name;
                lbDepartment.Text = employeeSalary.Employee.Account.Dept.DepartmentName;
                lbPosition.Text = employeeSalary.Employee.Account.Position.Name;
                lbType.Text = EmployeeTypeUtility.EmployeeTypeDisplay(value.Employee.EmployeeType);
                EmployeeID = value.Employee.Account.Id.ToString();
                if (value.AdjustSalaryHistoryList != null && value.AdjustSalaryHistoryList.Count > 0)
                {
                    AccountSet = value.AdjustSalaryHistoryList[0].AccountSet;
                }
            }
        }

        public AccountSet AccountSet
        {
            set
            {
                if (value != null && value.Items != null && value.Items.Count > 0)
                {
                    lbAccountSet.Text = value.AccountSetName;
                    lbDescription.Text = value.Description;

                    int itemCount = value.Items.Count;
                    trAccountSet.Visible = itemCount > 0;

                    #region 生成表格

                    for (int i = 0; i < ((itemCount + itemCount % 2) / 2); i++)
                    {
                        HtmlTableRow row = new HtmlTableRow();
                        HtmlTableCell cell0 = new HtmlTableCell();
                        cell0.Width = "10%";
                        cell0.Align = "right";
                        HtmlTableCell cell1 = new HtmlTableCell();
                        cell1.Width = "40%";
                        cell1.Align = "left";
                        HtmlTableCell cell2 = new HtmlTableCell();
                        cell2.Width = "10%";
                        cell2.Align = "right";
                        HtmlTableCell cell3 = new HtmlTableCell();
                        cell3.Width = "40%";
                        cell3.Align = "left";
                        row.Cells.Add(cell0);
                        row.Cells.Add(cell1);
                        row.Cells.Add(cell2);
                        row.Cells.Add(cell3);
                        tbAccountSet.Rows.Add(row);
                    }

                    #endregion

                    #region 生成表格内的内容
                    List<AccountSetItem> itemsList = value.Items;
                    int j = 0;
                    for (int i = 0; i < itemCount; i++)
                    {
                        Label lb = new Label();
                        lb.ID = itemsList[i].AccountSetPara.AccountSetParaID.ToString();
                        lb.Text = itemsList[i].AccountSetPara.AccountSetParaName;

                        Label lbResult = new Label();
                        lbResult.Width = Unit.Parse("60%");
                        lbResult.Text = itemsList[i].CalculateResult.ToString();
                        lbResult.CssClass = "input1";
                        lbResult.ID = "Label" + itemsList[i].AccountSetPara.AccountSetParaName;
                        if (i % 2 == 1)
                        {
                            tbAccountSet.Rows[j].Cells[2].Controls.Add(lb);
                            tbAccountSet.Rows[j].Cells[3].Controls.Add(lbResult);
                            j++;
                        }
                        else
                        {
                            tbAccountSet.Rows[j].Cells[0].Controls.Add(lb);
                            tbAccountSet.Rows[j].Cells[1].Controls.Add(lbResult);
                        }
                    }

                    #endregion
                }
            }
        }

        public event EventHandler GoToListPage;
        protected void btnOK_Click(object sender, EventArgs e)
        {
            GoToListPage(sender, e);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            GoToListPage(sender, e);
        }
    }
}