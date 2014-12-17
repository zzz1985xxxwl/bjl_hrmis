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
    public partial class RestoreData : System.Web.UI.Page
    {
        private const string _NeedRarFile = "需要上传并读取数据文件成功后才能导入数据";
        private const string _NeedUploadFile = "需要上传的数据文件";
        private const string _TimeNotDefine = "未指定";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                StaticConfigTable.ConfigFilePath = HttpContext.Current.Request.PhysicalApplicationPath + "TransferConfig.xml";
                StaticConfigTable.ExpandDllPath = HttpContext.Current.Request.PhysicalApplicationPath + "bin";
                StaticConfigTable.UploadFileDirectory = HttpContext.Current.Request.PhysicalApplicationPath + "UpLoadDirectory\\";
                StaticConfigTable.Log4NetConfigPath = HttpContext.Current.Request.PhysicalApplicationPath + "Log4Net.config";
                DiskOperations.CheckAndCreateDirectory(StaticConfigTable.UploadFileDirectory);
                Timer1.Enabled = false;
            }
            lblUploadMessage.Text = string.Empty;
            lblRestoreMessage.Text = string.Empty;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if(!UploadFile())
            {
                return;
            }
            ParseRarFile();
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Session["UploadTarget"].ToString()))
            {
                lblRestoreMessage.Text = _NeedRarFile;
                return;
            }

            Timer1.Enabled = true;
            SetBtn(false);
            RestoreStatus rs = new RestoreStatus();
            Session["RestoreStatus"] = rs;
            try
            {
                TransferService.RestoreData(Session["UploadTarget"].ToString(), rs);
            }
            catch(ApplicationException ae)
            {
                lblRestoreMessage.Text = ae.Message;
            }
            finally
            {
                Session["UploadTarget"] = string.Empty;
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            RestoreStatus bus = Session["RestoreStatus"] as RestoreStatus;
            if (bus != null)
            {
                lblRunningStatus.Text = bus.Status.ToString();
                txtRunningDetails.Text = bus.RunningDetails;

                if (bus.Status != Status.Running)
                {
                    Timer1.Enabled = false;
                    SetBtn(true);
                }
            }
        }

        #region 私有方法

        private bool UploadFile()
        {
            if (string.IsNullOrEmpty(FileUpload1.FileName))
            {
                lblUploadMessage.Text = _NeedUploadFile;
                return false;
            }
            try
            {
                string uploadTarget = string.Format("{0}{1}", StaticConfigTable.UploadFileDirectory,
                                                    FileUpload1.FileName);
                FileUpload1.SaveAs(uploadTarget);
                Session["UploadTarget"] = uploadTarget;
            }
            catch (Exception e)
            {
                lblUploadMessage.Text = e.Message;
                return false;
            }
            return true;
        }

        private void ParseRarFile()
        {
            DateTime? startTime;
            DateTime? endTime;
            TransferRule tr;
            try
            {
                tr = TransferService.AnalyseRarData(Session["UploadTarget"].ToString(), out startTime, out endTime);
            }
            catch(ApplicationException ae)
            {
                lblUploadMessage.Text = ae.Message;
                TryClean();
                return;
            }
            lblRuleNameValue.Text = tr.RuleName;
            string startTimeString = startTime.HasValue ? startTime.Value.ToShortDateString() : _TimeNotDefine;
            string endTimeString = endTime.HasValue ? endTime.Value.ToShortDateString() : _TimeNotDefine;
            lblParameterValue.Text = string.Format("{0}---{1}", startTimeString, endTimeString);
        }

        private void TryClean()
        {
            try
            {
                CommandRunner.DeleteFile(Session["UploadTarget"].ToString());
                Session["UploadTarget"] = string.Empty;
            }
            catch(ApplicationException)
            {
            }
        }

        private void SetBtn(bool isEnable)
        {
            btnUpload.Enabled = isEnable;
            btnRestore.Enabled = isEnable;
        }

        #endregion
    }
}
