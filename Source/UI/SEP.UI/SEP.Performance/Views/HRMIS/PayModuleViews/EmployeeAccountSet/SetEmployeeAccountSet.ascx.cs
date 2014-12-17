using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Model;

namespace SEP.Performance.Views.HRMIS.PayModuleViews
{
    public partial class SetEmployeeAccountSet : UserControl, ISetEmployeeAccountSetPresenter
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
                return Operation.Value;
            }
            set
            {
                Operation.Value = value;
            }
        }

        private bool _IsPostBack;
        public bool IsPostBack
        {
            get
            {
                return _IsPostBack;
            }
            set
            {
                _IsPostBack = value;
            }
        }

        public string Description
        {
            get
            {
                return tbDescription.Text;
            }
            set
            {
                tbDescription.Text = value;
            }
        }

        public EmployeeSalary EmployeeSalary
        {
            get
            {
                EmployeeSalary employeeSalary = new EmployeeSalary(Convert.ToInt32(EmployeeID));
                employeeSalary.AccountSet = AccountSet;
                return employeeSalary;
            }
            set
            {
                EmployeeSalary employeeSalary = value;
                lbName.Text = employeeSalary.Employee.Account.Name;
                lbDepartment.Text = employeeSalary.Employee.Account.Dept.DepartmentName;
                lbPosition.Text = employeeSalary.Employee.Account.Position.Name;
                lbType.Text = EmployeeTypeUtility.EmployeeTypeDisplay(employeeSalary.Employee.EmployeeType);
                AccountSet = value.AccountSet;
            }
        }

        public List<AccountSet> AccountSetSource
        {
            set
            {
                foreach (AccountSet accountSet in value)
                {
                    ListItem item = new ListItem(accountSet.AccountSetName, accountSet.AccountSetID.ToString(), true);
                    ddlAccountSet.Items.Add(item);
                }
            }
        }

        public int AccountSetID
        {
            set
            {
                ddlAccountSet.SelectedValue = value.ToString();
            }
            get
            {
                return Convert.ToInt32(ddlAccountSet.SelectedValue);
            }
        }

        public AccountSet AccountSet
        {
            get
            {
                AccountSet accountSet =
                    new AccountSet(Convert.ToInt32(ddlAccountSet.SelectedValue),
                                   ddlAccountSet.SelectedItem.Text);
                accountSet.Description = Description;

                List<AccountSetItem> accountSetItemList = new List<AccountSetItem>();
                if (tbAccountSet.Rows.Count > 0)
                {
                    for (int i = 0; i < tbAccountSet.Rows.Count; i++)
                    {
                        int accountSetParaID = Convert.ToInt32((tbAccountSet.Rows[i].Cells[0].Controls[0]).ID);
                        AccountSetPara accountSetPara =
                            new AccountSetPara(accountSetParaID,
                                               ((Label) tbAccountSet.Rows[i].Cells[0].Controls[0]).Text);
                        AccountSetItem accountSetItem = new AccountSetItem(0, accountSetPara, "");
                        accountSetItem.CalculateResult =
                            Convert.ToDecimal(((TextBox) tbAccountSet.Rows[i].Cells[1].Controls[0]).Text);
                        accountSetItemList.Add(accountSetItem);

                        try
                        {
                            if (tbAccountSet.Rows[i].Cells[2].Controls[0] != null)
                            {
                                int accountSetParaID2 = Convert.ToInt32((tbAccountSet.Rows[i].Cells[2].Controls[0]).ID);
                                AccountSetPara accountSetPara2 =
                                    new AccountSetPara(accountSetParaID2,
                                                       ((Label) tbAccountSet.Rows[i].Cells[2].Controls[0]).Text);
                                AccountSetItem accountSetItem2 = new AccountSetItem(0, accountSetPara2, "");

                                accountSetItem2.CalculateResult =
                                    Convert.ToDecimal(((TextBox) tbAccountSet.Rows[i].Cells[3].Controls[0]).Text);
                                accountSetItemList.Add(accountSetItem2);
                            }
                        }
                        catch(ArgumentOutOfRangeException ex)
                        {
                            continue;
                        }
                    }
                }
                accountSet.Items = accountSetItemList;
                return accountSet;
            }
            set
            {
                if (value != null && value.Items != null && value.Items.Count > 0)
                {
                    AccountSetID = value.AccountSetID;

                    //if (!IsPostBack)
                    //{
                    //    Description = value.Description;
                    //}

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
                        TextBox textBox = new TextBox();
                        textBox.Width = Unit.Parse("60%");
                        textBox.Text = itemsList[i].CalculateResult.ToString();
                        textBox.CssClass = "input1";
                        textBox.ID = "TextBox" + itemsList[i].AccountSetPara.AccountSetParaName;
                        textBox.Enabled = itemsList[i].AccountSetPara.FieldAttribute.Id == FieldAttributeEnum.FixedField.Id;
                        if (i % 2 == 1)
                        {
                            tbAccountSet.Rows[j].Cells[2].Controls.Add(lb);
                            tbAccountSet.Rows[j].Cells[3].Controls.Add(textBox);
                            j++;
                        }
                        else
                        {
                            tbAccountSet.Rows[j].Cells[0].Controls.Add(lb);
                            tbAccountSet.Rows[j].Cells[1].Controls.Add(textBox);
                        }
                    }

                    #endregion
                }
            }
        }

        public event EventHandler BtnOKEvent;
        protected void btnOK_Click(object sender, EventArgs e)
        {
            BtnOKEvent(sender, e);
        }

        public event EventHandler BtnCancelEvent;
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BtnCancelEvent(sender, e);
        }

        protected void ddlAccountSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlAccountSetSelectedIndexChanged(sender, e);
        }
    }
}