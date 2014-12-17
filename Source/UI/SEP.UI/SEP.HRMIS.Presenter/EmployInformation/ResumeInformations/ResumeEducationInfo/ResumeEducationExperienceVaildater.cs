//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ResumeEducationExperienceVaildater.cs
// ������: �ߺ�
// ��������: 2008-09-04
// ����: ���������Ľ�������С�����������֤��
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeEducationInfo
{
    public class ResumeEducationExperienceVaildater:IVaildater
    {
        private readonly IResumeEducationExperienceView _ItsView;

        public ResumeEducationExperienceVaildater(IResumeEducationExperienceView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            bool iRet = true;
            if (string.IsNullOrEmpty(_ItsView.School.Trim()))
            {
                _ItsView.SchoolMessage = EmployeePresenterUtilitys._FieldNotEmpty;
                iRet = false;
            }
            else
            {
                _ItsView.SchoolMessage = string.Empty;
            }
            if (string.IsNullOrEmpty(_ItsView.ExperiencePeriod.Trim()))
            {
                _ItsView.ExperiencePeriodMessage = EmployeePresenterUtilitys._FieldNotEmpty;
                iRet = false;
            }
            else
            {
                _ItsView.ExperiencePeriodMessage = string.Empty;
            }
            if (string.IsNullOrEmpty(_ItsView.Contect.Trim()))
            {
                _ItsView.ContectMessage = EmployeePresenterUtilitys._FieldNotEmpty;
                iRet = false;
            }
            else
            {
                _ItsView.ContectMessage = string.Empty;
            }
            return iRet;
        }
    }
}