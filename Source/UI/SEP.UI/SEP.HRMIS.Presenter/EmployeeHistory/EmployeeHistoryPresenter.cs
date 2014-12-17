using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.BasicInformation;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.EmployInformation.FamilyInformation;
using SEP.HRMIS.Presenter.EmployInformation.ResumeInformations;
using SEP.HRMIS.Presenter.EmployInformation.WelfareInformation;
using SEP.HRMIS.Presenter.EmployInformation.WorkInformation;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;
using SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.DimissionBasicInfo;
using SEP.HRMIS.Presenter.EmployInformation.FileCargosInformations;

namespace SEP.HRMIS.Presenter
{
    public class EmployeeHistoryPresenter
    {
        protected readonly IEmployeeInfoView _ItsView;
        protected readonly string _EmployeeId;
        private readonly List<IViewEmployeePresenter> _ThePresenters;
        private IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private IEmployeeHistoryFacade _IEmployeeHistoryFacade = InstanceFactory.CreateEmployeeHistoryFacade();

        public EmployeeHistoryPresenter(IEmployeeInfoView itsView, string employeeId)
        {
            _ItsView = itsView;
            _EmployeeId = employeeId;
            
            _ThePresenters = new List<IViewEmployeePresenter>();
            _ThePresenters.Add(new ViewBasicInfoPresenter(itsView.BasicInfoView));
            _ThePresenters.Add(new ViewDimissionBasicInfoPresenter(itsView.DimissionInfoView));
            _ThePresenters.Add(new ViewFamilyInfoPresenter(itsView.FamilyInfoView));
            _ThePresenters.Add(new ViewResumeInfoPresenter(itsView.ResumeInfoView));
            _ThePresenters.Add(new ViewWelfareInfoPresenter(itsView.WelfareInfoView));
            _ThePresenters.Add(new ViewWorkInfoPresenter(itsView.WorkInfoView,false));
            new ViewFileCargosInfoPresenter(itsView.FileCargoInfoView, _IEmployeeHistoryFacade.GetEmployeeHistoryByEmployeeHistoryID(Convert.ToInt32(_EmployeeId)).Employee.Account.Id);
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            foreach (IViewEmployeePresenter aPresenter in _ThePresenters)
            {
                aPresenter.InitView(pageIsPostBack);
            }
            //额外的界面信息设置
            if(!pageIsPostBack)
            {
                _ItsView.BtnActionVisible = false;
                _ItsView.Title = "查看员工";
                _ItsView.Message = string.Empty;
            }
            BindInfoToView(pageIsPostBack);
            _ItsView.DimissionInfoVisible = true;
            _ItsView.MailToHRVisible = false;
            _ItsView.BtnExportVisible = false;
            _ItsView.VocationInfoVisible = false;
            _ItsView.WelfareInfoView.EmployeeWelfareVisible = false;
        }

        private void BindInfoToView(bool pageIsPostBack)
        {
            int id;
            if (!int.TryParse(_EmployeeId, out id))
            {
                _ItsView.Message = "初始化信息失败，请联系管理员";
                _ItsView.BtnActionVisible = false;
                return;
            }

            if (!pageIsPostBack)
            {
                Employee theEmployee = _IEmployeeHistoryFacade.GetEmployeeHistoryByEmployeeHistoryID(id).Employee;
                Employee getPhoto = _IEmployeeFacade.GetEmployeeByAccountID(theEmployee.Account.Id);
                theEmployee.EmployeeDetails.Photo = getPhoto.EmployeeDetails.Photo;
                foreach (IViewEmployeePresenter aPresenter in _ThePresenters)
                {
                    aPresenter.DataBind(theEmployee);
                }
                //额外的界面信息绑定 
                _ItsView.ComeDate = theEmployee.EmployeeDetails.Work.ComeDate.ToShortDateString();
                _ItsView.Department = theEmployee.Account.Dept.Name;
                _ItsView.EmployeeName = theEmployee.Account.Name;
                _ItsView.AccountNo = theEmployee.Account.Id.ToString();
                _ItsView.Position = theEmployee.Account.Position.Name;

            }
        }
    }
}