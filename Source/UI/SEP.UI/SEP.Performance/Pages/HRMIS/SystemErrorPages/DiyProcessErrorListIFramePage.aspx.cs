using System;
using System.Collections.Generic;
using System.Web.UI;
using SEP.HRMIS.Model.SystemError;

namespace SEP.Performance.Pages.HRMIS.SystemErrorPages
{
    public partial class DiyProcessErrorListIFramePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlErrorType.DataSource = GetDiyErrorType;
            ddlErrorType.DataValueField = "ID";
            ddlErrorType.DataTextField = "Name";
            ddlErrorType.DataBind();
        }

        private static List<ErrorType> GetDiyErrorType
        {
            get
            {
                List<ErrorType> errorTypeList = new List<ErrorType>();
                errorTypeList.Add(ErrorType.All);
                errorTypeList.AddRange(ErrorType.GetDiyErrorType);
                return errorTypeList;
            }
        }
    }
}