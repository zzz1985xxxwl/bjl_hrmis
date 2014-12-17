using System.Xml;

namespace SEP.Performance.Pages.Config.Views
{
    public partial class AutoRemindFunctionSetView : System.Web.UI.UserControl
    {
        public void SetFunctionSetting(XmlDocument webconfigDoc)
        {
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyIsAutoAssess,
                                                  cbIsAutoAssess.Checked ? "true" : "false");
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyIsAutoEmployeeResidenceDateRearch,
                                                  cbIsAutoEmployeeResidenceDateRearch.Checked ? "true" : "false");
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyIsAutoRemindEmployeeConfirmAttendance,
                                                  cbIsAutoRemindEmployeeConfirmAttendance.Checked ? "true" : "false");
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyIsAutoRemindVacation,
                                                  cbIsAutoRemindVacation.Checked ? "true" : "false");
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyIsAutoRemindContract,
                                                  cbIsAutoRemindContract.Checked ? "true" : "false");
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyIsAutoRemindProbationDateRearch,
                                                  cbIsAutoRemindProbationDateRearch.Checked ? "true" : "false");
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyBeforeEmployeeResidenceDateRearchDays,
                                                  txtBeforeEmployeeResidenceDateRearchDays.Text.Trim());
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyBeforeRemindVacationDays,
                                                  txtBeforeRemindVacationDays.Text.Trim());
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyBeforeRemindContractDays,
                                                  txtBeforeRemindContractDays.Text.Trim());
            ConfigUtility.SetAppSettingsNodeValue(webconfigDoc,
                                                  ConfigUtility.Const_KeyBeforeProbationDateRearchDays,
                                                  txtBeforeRemindProbationDateRearchDays.Text.Trim());
        }

        public void GetFunctionSetting(XmlDocument webconfigDoc)
        {
            cbIsAutoAssess.Checked =
                ConfigUtility.GetAppSettingsNodeBoolValue(webconfigDoc, ConfigUtility.Const_KeyIsAutoAssess);
            cbIsAutoEmployeeResidenceDateRearch.Checked =
                ConfigUtility.GetAppSettingsNodeBoolValue(webconfigDoc,
                                                          ConfigUtility.Const_KeyIsAutoEmployeeResidenceDateRearch);
            cbIsAutoRemindEmployeeConfirmAttendance.Checked =
                ConfigUtility.GetAppSettingsNodeBoolValue(webconfigDoc,
                                                          ConfigUtility.Const_KeyIsAutoRemindEmployeeConfirmAttendance);
            cbIsAutoRemindVacation.Checked =
                ConfigUtility.GetAppSettingsNodeBoolValue(webconfigDoc,
                                                          ConfigUtility.Const_KeyIsAutoRemindVacation);
            cbIsAutoRemindContract.Checked =
                ConfigUtility.GetAppSettingsNodeBoolValue(webconfigDoc,
                                                          ConfigUtility.Const_KeyIsAutoRemindContract);
            cbIsAutoRemindProbationDateRearch.Checked =
                ConfigUtility.GetAppSettingsNodeBoolValue(webconfigDoc,
                                                          ConfigUtility.Const_KeyIsAutoRemindProbationDateRearch);
            txtBeforeEmployeeResidenceDateRearchDays.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                                                  ConfigUtility.
                                                                                                      Const_KeyBeforeEmployeeResidenceDateRearchDays);
            txtBeforeRemindVacationDays.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                                     ConfigUtility.
                                                                                         Const_KeyBeforeRemindVacationDays);
            txtBeforeRemindContractDays.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                                     ConfigUtility.
                                                                                         Const_KeyBeforeRemindContractDays);
            txtBeforeRemindProbationDateRearchDays.Text = ConfigUtility.GetAppSettingsNodeValue(webconfigDoc,
                                                                                                ConfigUtility.
                                                                                                    Const_KeyBeforeProbationDateRearchDays);
        }

        public bool CheckValid()
        {
            bool bRet = true;
            int result;
            if (!int.TryParse(txtBeforeEmployeeResidenceDateRearchDays.Text.Trim(), out result) || result < 0)
            {
                lbBeforeEmployeeResidenceDateRearchDaysMsg.Text = "请输入一个大于等于零的整数";
                bRet = false;
            }
            else
            {
                lbBeforeEmployeeResidenceDateRearchDaysMsg.Text = "";
            }

            if (!int.TryParse(txtBeforeRemindVacationDays.Text.Trim(), out result) || result < 0)
            {
                lbBeforeRemindVacationDaysMsg.Text = "请输入一个大于等于零的整数";
                bRet = false;
            }
            else
            {
                lbBeforeRemindVacationDaysMsg.Text = "";
            }

            if (!int.TryParse(txtBeforeRemindContractDays.Text.Trim(), out result) || result < 0)
            {
                lbBeforeRemindContractDaysMsg.Text = "请输入一个大于等于零的整数";
                bRet = false;
            }
            else
            {
                lbBeforeRemindContractDaysMsg.Text = "";
            }
            if (!int.TryParse(txtBeforeRemindProbationDateRearchDays.Text.Trim(), out result) || result < 0)
            {
                lbBeforeRemindProbationDateRearchDays.Text = "请输入一个大于等于零的整数";
                bRet = false;
            }
            else
            {
                lbBeforeRemindProbationDateRearchDays.Text = "";
            }
            return bRet;
        }
    }
}