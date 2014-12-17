using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.CalendarExt;
using SEP.Model.Departments;
using SEP.Notes;
using SEP.Notes.RepeatTypes;
using SEP.Performance.Pages;

namespace SEP.Performance.Views.SEP.CalendarExt
{
    public partial class CalendarExtView : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Account _loginUser = Session[SessionKeys.LOGININFO] as Account;
            StringBuilder sb = new StringBuilder();
            if (BasePage.HasHrmisSystem && _loginUser.IsHRAccount)
            {
                foreach (CalendarShowType type in CalendarShowType.GetHrType())
                {
                    sb.AppendFormat(
                        "<li><input value='{0}' type='checkbox' {3} /><span style='margin-left:15px;color:{2};'>{1}</span></li>",
                        type.ID, type.Name, type.Color, type.DefaultChecked ? "checked='checked'" : "");
                }
            }
            foreach (CalendarShowType type in CalendarShowType.GetSepType())
            {
                sb.AppendFormat(
                    "<li><input value='{0}' type='checkbox' {3} /><span style='margin-left:15px;color:{2};'>{1}</span></li>",
                    type.ID, type.Name, type.Color, type.DefaultChecked ? "checked='checked'" : "");
            }

            typeUL.InnerHtml = sb.ToString();
            selfname.InnerHtml = _loginUser.Name;
            selfname.Attributes.Add("name",_loginUser.Name);


            /*便签*/
            List<NameValue> attributions = RepeatUtility.GetAll();
            ddlType.Items.Clear();
            foreach (NameValue attribution in attributions)
            {
                ListItem item = new ListItem(attribution.Name, attribution.Value, true);
                ddlType.Items.Add(item);
            }

            //部门
            List<Department> deps = BllInstance.DepartmentBllInstance.GetAllDepartment();
            ddlDepartment.Items.Clear();
            ListItem alldep = new ListItem(string.Empty, "-1", true);
            ddlDepartment.Items.Add(alldep);
            foreach (Department dep in deps)
            {
                ListItem item = new ListItem(dep.Name, dep.Id.ToString(), true);
                if(dep.Id==_loginUser.Dept.Id)
                {
                     item.Selected = true;
                }
                ddlDepartment.Items.Add(item);
            }

            //按月重复
            List<MonthDayTypeEnum> mdte = MonthDayTypeEnum.GetAll();
            ddlMonthDayTypeEnum.Items.Clear();
            foreach (MonthDayTypeEnum m in mdte)
            {
                ListItem item = new ListItem(m.Name, m.Value.ToString(), true);
                ddlMonthDayTypeEnum.Items.Add(item);
            }

            List<NDayMonthEnum> ndme = NDayMonthEnum.GetAll();
            ddlNDayMonthEnum.Items.Clear();
            foreach (NDayMonthEnum m in ndme)
            {
                ListItem item = new ListItem(m.Name, m.Value.ToString(), true);
                ddlNDayMonthEnum.Items.Add(item);
            }
        }
    }
}