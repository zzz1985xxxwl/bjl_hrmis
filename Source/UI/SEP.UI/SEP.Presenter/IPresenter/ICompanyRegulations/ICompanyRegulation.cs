using System;
using System.Collections.Generic;
using SEP.Model.CompanyRegulations;

namespace SEP.Presenter.IPresenter.ICompanyRegulations
{
    public interface ICompanyRegulation
    {
        string PageTitle { get; set; }
        ReguType ReguType { get; set; }
        string Content { get; set; }

        List<CompanyReguAppendix> AppendixList { get; set; }

        event EventHandler ShowApplication;
    }
}