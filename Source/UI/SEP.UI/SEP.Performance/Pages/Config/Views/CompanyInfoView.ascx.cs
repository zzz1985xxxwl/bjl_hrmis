using System.Web.UI;
using System.Xml;

namespace SEP.Performance.Pages.Config.Views
{
    public partial class CompanyInfoView : UserControl
    {
        private const string Const_ATTENDANCEISNORMALISINCLUDEOUTINTIME = "ATTENDANCEISNORMALISINCLUDEOUTINTIME";
        private const string Const_SYSTEMMAILCOMMAND = "SYSTEMMAILCOMMAND";
        private const string Const_COMPANYFAX = "COMPANYFAX";
        private const string Const_COMPANYTEL = "COMPANYTEL";
        private const string Const_COMPANYTITLE = "COMPANYTITLE";
        private const string Const_DEFAULTPASSWORD = "DEFAULTPASSWORD";
        private const string Const_LOCALHOSTADDRESS = "LOCALHOSTADDRESS";
        private const string Const_SMTPHOST = "SMTPHOST";
        private const string Const_SYSTEMID = "SYSTEMID";
        private const string Const_SYSTEMMAILADDRESS = "SYSTEMMAILADDRESS";
        private const string Const_USERNAMEMAILADDRESS = "USERNAMEMAILADDRESS";
        private const string Const_USERNAMEPASSWORD = "USERNAMEPASSWORD";
        private const string Const_HELPADDRESS = "HELPADDRESS";
        private const string Const_MAILTOHR = "MAILTOHR";

        public void GetCompanyInfo(XmlDocument webconfigDoc)
        {
            txtATTENDANCEISNORMALISINCLUDEOUTINTIME.Text =
                ConfigUtility.GetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath,
                                                    Const_ATTENDANCEISNORMALISINCLUDEOUTINTIME);
            txtSYSTEMMAILCOMMAND.Text =
                ConfigUtility.GetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_SYSTEMMAILCOMMAND);
            txtCOMPANYFAX.Text =
                ConfigUtility.GetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_COMPANYFAX);
            txtCOMPANYTEL.Text =
                ConfigUtility.GetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_COMPANYTEL);
            txtCOMPANYTITLE.Text =
                ConfigUtility.GetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_COMPANYTITLE);
            txtDEFAULTPASSWORD.Text =
                ConfigUtility.GetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_DEFAULTPASSWORD);
            txtLOCALHOSTADDRESS.Text =
                ConfigUtility.GetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_LOCALHOSTADDRESS);
            txtSMTPHOST.Text =
                ConfigUtility.GetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_SMTPHOST);
            txtSYSTEMID.Text =
                ConfigUtility.GetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_SYSTEMID);
            txtSYSTEMMAILADDRESS.Text =
                ConfigUtility.GetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_SYSTEMMAILADDRESS);
            txtUSERNAMEMAILADDRESS.Text =
                ConfigUtility.GetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_USERNAMEMAILADDRESS);
            txtUSERNAMEPASSWORD.Text =
                ConfigUtility.GetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_USERNAMEPASSWORD);
            txtHELPADDRESS.Text =
                ConfigUtility.GetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_HELPADDRESS);
            txtMAILTOHR.Text =
                ConfigUtility.GetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_MAILTOHR);
        }

        public void SetCompanyInfo(XmlDocument webconfigDoc)
        {
            ConfigUtility.SetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath,
                                                Const_ATTENDANCEISNORMALISINCLUDEOUTINTIME,
                                                txtATTENDANCEISNORMALISINCLUDEOUTINTIME.Text);
            ConfigUtility.SetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_SYSTEMMAILCOMMAND,
                                                txtSYSTEMMAILCOMMAND.Text);
            ConfigUtility.SetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_COMPANYFAX,
                                                txtCOMPANYFAX.Text);
            ConfigUtility.SetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_COMPANYTEL,
                                                txtCOMPANYTEL.Text);
            ConfigUtility.SetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_COMPANYTITLE,
                                                txtCOMPANYTITLE.Text);
            ConfigUtility.SetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_DEFAULTPASSWORD,
                                                txtDEFAULTPASSWORD.Text);
            ConfigUtility.SetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_LOCALHOSTADDRESS,
                                                txtLOCALHOSTADDRESS.Text);
            ConfigUtility.SetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_SMTPHOST,
                                                txtSMTPHOST.Text);
            ConfigUtility.SetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_SYSTEMID,
                                                txtSYSTEMID.Text);
            ConfigUtility.SetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_SYSTEMMAILADDRESS,
                                                txtSYSTEMMAILADDRESS.Text);
            ConfigUtility.SetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_USERNAMEMAILADDRESS,
                                                txtUSERNAMEMAILADDRESS.Text);
            ConfigUtility.SetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_USERNAMEPASSWORD,
                                                txtUSERNAMEPASSWORD.Text);
            ConfigUtility.SetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_HELPADDRESS,
                                                txtHELPADDRESS.Text);
            ConfigUtility.SetNodeInnerTextValue(webconfigDoc, ConfigUtility._CompanyPath, Const_MAILTOHR,
                                                txtMAILTOHR.Text);
        }
    }
}