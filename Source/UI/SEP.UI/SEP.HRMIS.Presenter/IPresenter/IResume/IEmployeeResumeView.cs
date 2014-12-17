using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IEmployeeResumeView
    {
        string Title { get; set;}
        string ForeignLanguageAbility { get; set;}
        string Certificates { get; set;}

        List<WorkExperience> WorkExperience { get;set;}
        List<EducationExperience> EducationExperience { get;set;}
        string Message { get; set;}

        event CommandEventHandler btnDeleteEdu;
        
        event CommandEventHandler btnDeleteWork;

        bool SetButtonStatus{ set;}

        
    }
}
 