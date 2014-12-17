using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
    public interface IWorkExperienceView
    {
        string Message { get; set;}
        string Id { get; set;}

        string Company { get; set;}
        string ExperiencePeriod { get; set;}
        string Content { get; set;}
        string Remark { get; set;}
        string ContactPerson { get; set;}

        string MsgCompany { get; set;}
        string MsgPeriod { get; set;}
        string MsgContent { get; set;}
    }
}
