using System;
using System.IO;
using SEP.Model.CompanyRegulations;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.ICompanyRegulations;
using SEP.IBll;
using SEP.Model.Accounts;

namespace SEP.Presenter.CompanyRegulations
{
   public class CompanyRegulationPresenter : BasePresenter
    {
       private readonly ICompanyRegulation _View;

       public CompanyRegulationPresenter(ICompanyRegulation view, Account account)
           : base(account)
       {
           _View = view;
           AttachViewEvent();
       }

       private void AttachViewEvent()
       {
           _View.ShowApplication += Init;
       }

       public void Init(object sender, EventArgs e)
       {
           CompanyRegulation CompanyRegulation = BllInstance.CompanyRegulationBllInstance.GetCompanyRegulationsByType(_View.ReguType, LoginUser);
           _View.PageTitle = CompanyRegulation.Title;
           _View.Content = CompanyRegulation.Content;
           _View.AppendixList = CompanyRegulation.AppendixList;
           FindAppendixInDirectory();
       }

       private void FindAppendixInDirectory()
       {
           CompanyReguAppendix[] appendixtemp = new CompanyReguAppendix[_View.AppendixList.Count];
           (_View.AppendixList).CopyTo(appendixtemp);
           foreach (CompanyReguAppendix appendix in appendixtemp)
           {
               if (!File.Exists(appendix.Directory))
               {
                   _View.AppendixList.Remove(appendix);
               }
           }
           _View.AppendixList = _View.AppendixList;

       }

       public override void Initialize(bool isPostBack)
       {
           throw new Exception("The method or operation is not implemented.");
       }
   }
}
