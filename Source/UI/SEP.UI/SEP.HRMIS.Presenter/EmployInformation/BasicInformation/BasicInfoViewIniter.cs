//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BasicInfoViewIniter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-20
// 概述: 初始化员工基本信息界面的类
// ----------------------------------------------------------------
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.BasicInformation
{
    public class BasicInfoViewIniter:IViewIniter
    {
        private readonly IBasicInfoView _ItsView;
        public INationalityFacade _ItsNationalityFacade = InstanceFactory.CreateNationalityFacade();

        public BasicInfoViewIniter(IBasicInfoView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            //字段消息为空
            SetFiledAndMessageEmpty();
            //类型数据源绑定
            BindTypesSource();
            //界面业务
            SetDefaultSelectedType();
        }

        private void SetFiledAndMessageEmpty()
        {
            _ItsView.AccountName = string.Empty;
            _ItsView.DepartmentName = string.Empty;
            _ItsView.BirthDay = string.Empty;
            _ItsView.BirthDayMessage = string.Empty;
            _ItsView.EducationalBackgroundMessage = string.Empty;
            _ItsView.Email1 = string.Empty;
            _ItsView.Email2 = string.Empty;
            _ItsView.EmployeeName = string.Empty;
            _ItsView.DepartmentName = string.Empty;
            _ItsView.PositionName = string.Empty;
            _ItsView.EmployeeTypeMessage = string.Empty;
            _ItsView.EnglishName = string.Empty;
            _ItsView.GenderMessage = string.Empty;
            _ItsView.Height = string.Empty;
            _ItsView.HeightMessage = string.Empty;
            _ItsView.IDDueDate = string.Empty;
            _ItsView.IDDueDateMessage = string.Empty;
            _ItsView.IDNo = string.Empty;
            _ItsView.IDNoMessage = string.Empty;
            _ItsView.Major = string.Empty;
            _ItsView.MajorMessage = string.Empty;
            _ItsView.MaritalStatusMessage = string.Empty;
            _ItsView.Nationality = string.Empty;
            _ItsView.NationalityMessage = string.Empty;
            _ItsView.NativePlace = string.Empty;
            _ItsView.NativePlaceMessage = string.Empty;
            _ItsView.Phone = string.Empty;
            _ItsView.PhysicalCondition = string.Empty;
            _ItsView.PhysicalConditionMessage = string.Empty;
            _ItsView.PoliticalAffiliationMessage = string.Empty;
            _ItsView.School = string.Empty;
            _ItsView.SchoolMessage = string.Empty;
            _ItsView.Weight = string.Empty;
            _ItsView.WeightMessage = string.Empty;
            _ItsView.GraduateDate = string.Empty;
        }

        private void SetDefaultSelectedType()
        {
            _ItsView.EmployeeType =((int)EmployeeTypeEnum.NormalEmployee).ToString();
            _ItsView.EducationalBackground = EducationalBackground.BenKe.Id.ToString();
            _ItsView.PoliticalAffiliation = PoliticalAffiliation.Mass.Id.ToString();
            _ItsView.Gender = Gender.Man.Id.ToString();
            _ItsView.MaritalStatus = MaritalStatus.UnMarried.Id.ToString();
        }

        private void BindTypesSource()
        {
            _ItsView.EmployeeTypeSource = EmployeeTypeUtility.GetAllEmployeeTypeEnum();
            _ItsView.EducationalBackgroundSource = EducationalBackground.AllEducationalBackgrounds;
            _ItsView.PoliticalAffiliationSource = PoliticalAffiliation.AllPoliticalAffiliations;
            _ItsView.GenderSource = Gender.AllGenders;
            _ItsView.MaritalStatusSource = MaritalStatus.GetAllMaritalStatus();
            _ItsView.CountryNationalitySource = _ItsNationalityFacade.GetNationalityByCondition(-1, "");
        }
    }
}