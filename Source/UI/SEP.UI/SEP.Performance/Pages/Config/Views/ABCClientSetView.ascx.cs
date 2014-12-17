
namespace SEP.Performance.Pages.Config.Views
{
    public partial class ABCClientSetView : System.Web.UI.UserControl
    {
        public string ServerAddress
        {
            get { return txtServerAddress.Text.Trim(); }
            set { txtServerAddress.Text = value; }
        }
        public string ServerBinding
        {
            get { return txtServerBinding.Text.Trim(); }
            set { txtServerBinding.Text = value; }
        }
        public string ServerContract
        {
            get { return txtServerContract.Text.Trim(); }
            set { txtServerContract.Text = value; }
        }
        public string ServerName
        {
            set { txtServerName.Text = value; }
        }
        public bool IsOpenFunction
        {
            get { return cbOpenFunction.Checked; }
            set { cbOpenFunction.Checked = value; }
        }
        public bool IsOpenFunctionVisible
        {
            get { return cbOpenFunction.Visible; }
            set { cbOpenFunction.Visible = value; }
        }
        public string ServerBindingConfiguration
        {
            get { return txtServerBindingConfiguration.Text.Trim(); }
            set { txtServerBindingConfiguration.Text = value; }
        }
    }
}