using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TransferDatas;

namespace AJAXEnabledWebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        private const string _TimeNeed = "时间参数不正确";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            if(!Page.IsPostBack)
            {
                Timer1.Enabled = false;
                //指定配置文件路径，指定扩展库路径，指定下载文件绝对路径，就可以使用导入导出功能
                StaticConfigTable.ConfigFilePath = HttpContext.Current.Request.PhysicalApplicationPath + "TransferConfig.xml";
                StaticConfigTable.ExpandDllPath = HttpContext.Current.Request.PhysicalApplicationPath + "bin";
                StaticConfigTable.DownloadFilesDirectory = HttpContext.Current.Request.PhysicalApplicationPath + "DownLoadDirectory";
                StaticConfigTable.Log4NetConfigPath = HttpContext.Current.Request.PhysicalApplicationPath + "Log4Net.config";
                ShowAllRules();
                SetDownloadFileDisplay(false);
            }
        }

        protected void btnBackUp_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
            btnBackUp.Enabled = false;
            SetDownloadFileDisplay(false);
            BackUpStatus bus = new BackUpStatus();
            Session["DtStatus"] = bus;

            TransferRule tr = RulesPool.FindRuleByName(ddlAllRules.SelectedItem.Text);
            if(tr!= null)
            {
                if (tr.GetNeedTimeFilter())
                {
                    DateTime startTime;
                    DateTime endTime;
                    if (!DateTime.TryParse(txtStartTime.Text, out startTime) || !DateTime.TryParse(txtEndTime.Text, out endTime))
                    {
                        lblMessage.Text = _TimeNeed;
                        return;
                    }
                    TryRunBackUp(startTime, endTime, bus);
                }
                else
                {
                    TryRunBackUp(null, null, bus);
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            BackUpStatus bus = Session["DtStatus"] as BackUpStatus;
            if (bus != null)
            {
                lblRunningStatus.Text = bus.Status.ToString();
                txtRunningDetails.Text = bus.RunningDetails;

                if (bus.Status != Status.Running)
                {
                    Timer1.Enabled = false;
                    btnBackUp.Enabled = true;
                }
                if(bus.Status == Status.Success)
                {
                    hlDownloadFile.NavigateUrl = @"~\DownLoadDirectory\" + bus.SuccessFileName;
                    SetDownloadFileDisplay(true);
                }
            }
        }

        protected void ddlAllRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectRuleChanged();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ShowAllRules();
        }

        #region 私有方法

        private void TryRunBackUp(DateTime? startTime,DateTime? endTime,BackUpStatus bs)
        {
            try
            {
                TransferService.BackUpData(ddlAllRules.SelectedItem.Text, startTime, endTime, bs);
            }
            catch(ApplicationException ae)
            {
                lblMessage.Text = ae.Message;
            }
        }

        private void ShowAllRules()
        {
            ddlAllRules.Items.Clear();
            try
            {
                TransferService.ResetAllRules();
                foreach (TransferRule aRule in RulesPool.AllTransferRules)
                {
                    ddlAllRules.Items.Add(aRule.RuleName);
                }
                SelectRuleChanged();
                btnBackUp.Enabled = true;
            }
            catch(ApplicationException ae)
            {
                lblMessage.Text = ae.Message;
                btnBackUp.Enabled = false;
            }
        }

        private void SelectRuleChanged()
        {
            string ruleName = ddlAllRules.SelectedItem.Text;
            if(string.IsNullOrEmpty(ruleName))
            {
                return;
            }

            TransferRule tr =  RulesPool.FindRuleByName(ruleName);
            if(tr != null)
            {
                SetTimeParameterDisplay(tr.GetNeedTimeFilter());
            }
        }

        private void SetTimeParameterDisplay(bool isShow)
        {
            lblStartTime.Visible = isShow;
            txtStartTime.Visible = isShow;
            lblEndTime.Visible = isShow;
            txtEndTime.Visible = isShow;
        }

        private void SetDownloadFileDisplay(bool isShow)
        {
            lblDownloadFile.Visible = isShow;
            hlDownloadFile.Visible = isShow;
        }

        #endregion

    }
}
