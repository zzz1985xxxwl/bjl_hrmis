using System;
using System.ServiceModel;
using System.Web.UI.WebControls;
using SmsControlContract;
using SmsControlContract.ClientAddressModels;

namespace WebControlClient
{
    public partial class ClientInformationMain : System.Web.UI.Page
    {
        private ISmsControllerContract _TheSmsControllor;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckId();

            _TheSmsControllor = new ChannelFactory<ISmsControllerContract>("ISmsControllerContractService").CreateChannel();
            if(!Page.IsPostBack)
            {
                DataBindsForClientInformations();
            }
            lblMessage.Text = string.Empty;
        }

        private void CheckId()
        {
            if (Session["MachineController"] == null)
            {
                Response.Redirect("MachineControlLogin.aspx");
            }
        }

        protected void lblDescript_Click(object sender, CommandEventArgs e)
        {
            try
            {
                DataBindClientInformationForDescript(int.Parse(e.CommandArgument.ToString()));
            }
            catch(FaultException fe)
            {
                lblMessage.Text = fe.Message;
            }
        }

        protected void lblOpenClient_Click(object sender, CommandEventArgs e)
        {
            try
            {
                _TheSmsControllor.ActiveTheClientInformation(int.Parse(e.CommandArgument.ToString()));
                DataBindsForClientInformations();
            }
            catch (FaultException fe)
            {
                lblMessage.Text = fe.Message;
            }
        }

        protected void lblCloseClient_Click(object sender, CommandEventArgs e)
        {
            try
            {
                _TheSmsControllor.DisableTheClientInformation(int.Parse(e.CommandArgument.ToString()));
                DataBindsForClientInformations();
            }
            catch (FaultException fe)
            {
                lblMessage.Text = fe.Message;
            }
        }

        protected void lblManage_Click(object sender, CommandEventArgs e)
        {
            try
            {
                DataBindForListenAddress(int.Parse(e.CommandArgument.ToString()));
            }
            catch (FaultException fe)
            {
                lblMessage.Text = fe.Message;
            }
        }

        protected void lblOpenAddress_Click(object sender, CommandEventArgs e)
        {
            try
            {
                _TheSmsControllor.ActiveTheListenAddress(int.Parse(lblSystemId.Text), int.Parse(e.CommandArgument.ToString()));
                DataBindForListenAddress(int.Parse(lblSystemId.Text));
            }
            catch (FaultException fe)
            {
                lblMessage.Text = fe.Message;
            }
        }

        protected void lblCloseAddress_Click(object sender, CommandEventArgs e)
        {
            try
            {
                _TheSmsControllor.DisableTheListenAddress(int.Parse(lblSystemId.Text), int.Parse(e.CommandArgument.ToString()));
                DataBindForListenAddress(int.Parse(lblSystemId.Text));
            }
            catch (FaultException fe)
            {
                lblMessage.Text = fe.Message;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _TheSmsControllor.AddActivedClientInformation(txtHrmisIdForAdd.Text, txtCompanyDescriptionForAdd.Text);
                DataBindsForClientInformations();
            }
            catch (FaultException fe)
            {
                lblMessage.Text = fe.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _TheSmsControllor.DescriptClientInformation(int.Parse(txtClientId.Text), txtCompanyDescriptionForUpdate.Text);
                DataBindsForClientInformations();
            }
            catch (FaultException fe)
            {
                lblMessage.Text = fe.Message;
            }
        }

        private void DataBindsForClientInformations()
        {
            try
            {
                grvClientInformation.DataSource = _TheSmsControllor.GetAllClientAddressModel();
                grvClientInformation.DataBind();
            }
            catch (FaultException fe)
            {
                lblMessage.Text = fe.Message;
            }
        }

        private void DataBindForListenAddress(int theClientInformationId)
        {
            grvListenAddress.DataSource = _TheSmsControllor.GetClientAddressModelById(theClientInformationId).TheAddressModelCollcetion;
            grvListenAddress.DataBind();
            lblSystemId.Text = theClientInformationId.ToString();
        }

        private void DataBindClientInformationForDescript(int theClientInformationId)
        {
            ClientInformationModel theClientInfo = _TheSmsControllor.GetClientAddressModelById(theClientInformationId);
            txtClientId.Text = theClientInformationId.ToString();
            txtClientId.Enabled = false;
            txtHrmisIdForUpdate.Text = theClientInfo.HrmisId;
            txtHrmisIdForUpdate.Enabled = false;
            txtCompanyDescriptionForUpdate.Text = theClientInfo.CompanyDescription;
            txtCompanyDescriptionForUpdate.Enabled = true;
        }
    }
}