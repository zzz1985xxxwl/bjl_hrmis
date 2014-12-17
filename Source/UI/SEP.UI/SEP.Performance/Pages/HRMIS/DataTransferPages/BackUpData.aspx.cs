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
using SEP.Performance.Pages;
using TransferDatas;

namespace AJAXEnabledWebApplication1
{
    public partial class _Default : BasePage
    {
        private const string _TimeNeed = "时间参数不正确";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            Message.Visible = false;
            if(!Page.IsPostBack)
            {
                Timer1.Enabled = false;
                //指定配置文件路径，指定扩展库路径，指定下载文件绝对路径，就可以使用导入导出功能
                StaticConfigTable.ConfigFilePath = HttpContext.Current.Request.PhysicalApplicationPath + "DataTransferConfig.xml";
                StaticConfigTable.ExpandDllPath = HttpContext.Current.Request.PhysicalApplicationPath + "bin";
                StaticConfigTable.DownloadFilesDirectory = HttpContext.Current.Request.PhysicalApplicationPath + "DownLoadDirectory";
                StaticConfigTable.Log4NetConfigPath = HttpContext.Current.Request.PhysicalApplicationPath + "DataTransferConfig.xml";
                ShowAllRules();
                SetDownloadFileDisplay(false);
            }
        }

        protected void btnBackUp_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
            SetBtnEnable(false);
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
                        Message.Visible = true;
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
                lblRunningStatus.Text = RunningStatus.StatusToString(bus.Status);
                txtRunningDetails.Text = bus.RunningDetails;

                if (bus.Status != Status.Running)
                {
                    Timer1.Enabled = false;
                    SetBtnEnable(true);
                }
                if(bus.Status == Status.Success)
                {
                    hlDownloadFile.NavigateUrl = @"~\DownLoadDirectory\" + bus.SuccessFileName;
                    SetDownloadFileDisplay(true);
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ShowAllRules();
        }

        protected void ddlAllRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectRuleChanged();
        }

        protected void btnRuleToString_Click(object sender, EventArgs e)
        {
            TransferRule tr = GetCurrentSelectedRule();
            if (tr != null)
            {
                txtRunningDetails.Text = tr.ToString();
            }
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
                Message.Visible = true;
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
                if (ddlAllRules.Items.Count == 0)
                {
                    SetBtnEnable(false);
                    SetTimeParameterDisplay(false);
                }
                else
                {
                    SelectRuleChanged();
                    SetBtnEnable(true);
                }
            }
            catch (ApplicationException ae)
            {
                lblMessage.Text = ae.Message;
                Message.Visible = true;
                btnBackUp.Enabled = false;
            }
        }

        private void SetBtnEnable(bool isEnabled)
        {
            btnBackUp.Enabled = isEnabled;
            btnRuleToString.Enabled = isEnabled;
        }

        private void SelectRuleChanged()
        {
            TransferRule tr = GetCurrentSelectedRule();
            if(tr != null)
            {
                SetTimeParameterDisplay(tr.GetNeedTimeFilter());
            }
        }

        private TransferRule GetCurrentSelectedRule()
        {
            string ruleName = ddlAllRules.SelectedItem.Text;
            if(string.IsNullOrEmpty(ruleName))
            {
                return null;
            }
            return RulesPool.FindRuleByName(ruleName);
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
