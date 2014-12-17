using System;
using System.Collections.Generic;
using System.ServiceModel;
using SmsControlContract;
using SmsDataContract;

namespace WebControlClient
{
    public partial class MachineControl : System.Web.UI.Page
    {
        private ISmsControllerContract _TheSmsControllor;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckId();

            LoadComplete += OnLoadComplete;
            _TheSmsControllor = new ChannelFactory<ISmsControllerContract>("ISmsControllerContractService").CreateChannel();

            lblBasicMessage.Text = string.Empty;
            lblGaoJiMessage.Text = string.Empty;
            lblTestResult.Text = string.Empty;

            if (!Page.IsPostBack)
            {
                ReflashStatus();
            }
        }

        private void OnLoadComplete(object o,EventArgs e)
        {
            //todo ж���ŵ�
        }

        private void CheckId()
        {
            if (Session["MachineController"] == null)
            {
                Response.Redirect("MachineControlLogin.aspx");
            }
        }

        protected void btnQuickStart_Click(object sender, EventArgs e)
        {
            try
            {
                _TheSmsControllor.StartConnection();
                _TheSmsControllor.StartTheSmsThread();
            }
            catch (ApplicationException ae)
            {
                lblBasicMessage.Text = ae.Message;
            }
            ReflashStatus();
        }

        protected void btnQuickStop_Click(object sender, EventArgs e)
        {
            try
            {
                _TheSmsControllor.StopTheSmsThread();
                _TheSmsControllor.StopConnection();
            }
            catch (ApplicationException ae)
            {
                lblBasicMessage.Text = ae.Message;
            }
            ReflashStatus();
        }

        protected void btnSystemEventBind_Click(object sender, EventArgs e)
        {
            _TheSmsControllor.SetTheBoardStatus(true);
            ReflashStatus();
        }

        protected void btnSystemRemoveSmsEvent_Click(object sender, EventArgs e)
        {
            _TheSmsControllor.SetTheBoardStatus(false);
            ReflashStatus();
        }

        protected void btnAddSmsToQueue_Click(object sender, EventArgs e)
        {
            _TheSmsControllor.DelieveAMessage(new SendMessageDataModel(-999,txtSendToQueue.Text, txtSendContextQueue.Text,"smsController"));
            ReflashStatus();
        }

        protected void btnOpenPort_Click(object sender, EventArgs e)
        {
            try
            {
                _TheSmsControllor.StartConnection();
            }
            catch (ApplicationException ae)
            {
                lblGaoJiMessage.Text = ae.Message;
            }
            ReflashStatus();
        }

        protected void btnStopPort_Click(object sender, EventArgs e)
        {
            try
            {
                _TheSmsControllor.StopConnection();
            }
            catch (ApplicationException ae)
            {
                lblGaoJiMessage.Text = ae.Message;
            }
            ReflashStatus();
        }

        protected void btnStartThread_Click(object sender, EventArgs e)
        {
            try
            {
                _TheSmsControllor.StartTheSmsThread();
            }
            catch (ApplicationException ae)
            {
                lblGaoJiMessage.Text = ae.Message;
            }
            ReflashStatus();
        }

        protected void btnStopThread_Click(object sender, EventArgs e)
        {
            try
            {
                _TheSmsControllor.StopTheSmsThread();
            }
            catch (ApplicationException ae)
            {
                lblGaoJiMessage.Text = ae.Message;
            }
            ReflashStatus();
        }

        protected void btnTestMachine_Click(object sender, EventArgs e)
        {
            try
            {
                lblTestResult.Text = _TheSmsControllor.TestMachine() ? "����" : "������";
            }
            catch (ApplicationException ae)
            {
                lblGaoJiMessage.Text = ae.Message;
                lblTestResult.Text = "������";
            }
            ReflashStatus();
        }

        protected void btnSendSms_Click(object sender, EventArgs e)
        {
            try
            {
                _TheSmsControllor.SendAMessage(new SendMessageDataModel(-999,txtSendTo.Text, txtContent.Text,"smsController"));
            }
            catch(ApplicationException ae)
            {
                lblTiaoShi.Text = ae.Message;
            }
            ReflashStatus();
        }

        protected void btnSendMoneyMessage_Click(object sender, EventArgs e)
        {
            try
            {
                _TheSmsControllor.SendSearchMoneyMessage();
            }
            catch(ApplicationException ae)
            {
                lblTiaoShi.Text = ae.Message;
            }
            ReflashStatus();
        }

        protected void btnReceiveAllMessage_Click(object sender, EventArgs e)
        {
            try
            {
                _TheSmsControllor.ReceiveAllMessage();
            }
            catch (ApplicationException ae)
            {
                lblTiaoShi.Text = ae.Message;
            }
            ReflashStatus();
        }

        protected void btnSendCommand_Click(object sender, EventArgs e)
        {
            try
            {
                txtCommandReplay.Text = _TheSmsControllor.SendCommand(txtSendCommand.Text, int.Parse(txtWaitMillionSeconds.Text));
            }
            catch (ApplicationException ae)
            {
                lblTiaoShi.Text = ae.Message;
            }
            ReflashStatus();
        }

        protected void btnReflashStatus_Click(object sender, EventArgs e)
        {
            ReflashStatus();
        }

        private void ReflashStatus()
        {
            lblComStatus.Text = _TheSmsControllor.GetPortStatus() ? "��" : "�ر�";
            lblWorkThreadStatus.Text = _TheSmsControllor.GetWorkThreadStatus() ? "��" : "�ر�";
            lblTheEventHasHandler.Text = _TheSmsControllor.GetTheBoardStatus() ? "��" : "��";

            List<SendMessageDataModel> waitSendMessages = _TheSmsControllor.GetLogsForWaitSendMessages();
            gvWait.DataSource = waitSendMessages;
            gvWait.DataBind();
            lblWait.Text = waitSendMessages.Count + "����¼";

            List<ReceiveMessageDataModel> receivedMessage = _TheSmsControllor.GetLogsForReceiveMessages();
            gvReceive.DataSource = receivedMessage;
            gvReceive.DataBind();
            lblReceive.Text = receivedMessage.Count + "����¼";

            List<SendMessageDataModel> failedSendMessage = _TheSmsControllor.GetLogsForFailedSendMessages();
            gvFailed.DataSource = failedSendMessage;
            gvFailed.DataBind();
            lblFailed.Text = failedSendMessage.Count + "����¼";

            List<SendMessageDataModel> successSendMessage = _TheSmsControllor.GetLogsForSuccesssSendMessages();
            gvSuccess.DataSource = successSendMessage;
            gvSuccess.DataBind();
            lblSuccess.Text =successSendMessage.Count + "����¼";
        }

        protected void gvWait_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvWait.PageIndex = e.NewPageIndex;
            ReflashStatus();
        }

        protected void gvReceive_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvReceive.PageIndex = e.NewPageIndex;
            ReflashStatus();
        }

        protected void gvSuccess_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvSuccess.PageIndex = e.NewPageIndex;
            ReflashStatus();
        }

        protected void gvFailed_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvFailed.PageIndex = e.NewPageIndex;
            ReflashStatus();
        }
    }
}