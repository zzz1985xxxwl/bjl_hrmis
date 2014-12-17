using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.PayModuleViews
{
    public partial class DECEmployeeSalaryView : UserControl, IDECEmployeeSalaryView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDECEmployeeSalary_Click(object sender, EventArgs e)
        {
            DECEmployeeSalaryEvent();
        }

        public event DelegateNoParameter DECEmployeeSalaryEvent;

        public string EmployeeSalaryCode
        {
            get { return txtEmployeeSalaryCode.Text.Trim(); }
            set { txtEmployeeSalaryCode.Text = value; }
        }

        public string EmployeeSalaryCodeMsg
        {
            set { lblEmployeeSalaryCodeMsg.Text = value; }
        }

        public string Message
        {
            set
            {
                lblMessage.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
            }
        }

        public string DECEmployeeSalaryResult
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    tbResult.Style["display"] = "none";
                }
                else
                {
                    string[] result = value.Split('|');
                    HtmlTableRow tr = new HtmlTableRow();
                    HtmlTableCell tc;
                    for (int i = 0; i < result.Length; i++)
                    {
                        tc = new HtmlTableCell();
                        tc.Attributes.Add("width", "50%");
                        tc.InnerText = result[i];
                        tc.Attributes.Add("align", "center");
                        if (i % 2 == 0)
                        {
                            tc.Attributes.Add("class", "green1");
                            tr = new HtmlTableRow();
                            //tr.Attributes.Add("height", "12px");
                            tbResult.Rows.Add(tr);
                        }
                        tr.Cells.Add(tc);
                    }
                    tbResult.Style["display"] = "block";
                }
            }
        }

        public string UsbKey
        {
            get { return lbUsbKey.Value; }
            set { lbUsbKey.Value = value; }
        }
        public int UsbKeyCount
        {
            get
            {
                try
                {
                    return Convert.ToInt32(lbUsbKeyCount.Value);
                }
                catch
                {
                    return -1;
                }
            }
        }

        public Account CurrentUser
        {
            get { return Session[SessionKeys.LOGININFO] as Account; }
        }
    }
}