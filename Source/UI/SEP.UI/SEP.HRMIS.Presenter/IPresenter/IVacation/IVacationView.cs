
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IVacationView
    {
        string SocietyWorkAge { get; set;}
        Employee Employee { get;set; }
        List<Vacation> VacationList { get;}
        bool IsBack{ set;}
    }
}
