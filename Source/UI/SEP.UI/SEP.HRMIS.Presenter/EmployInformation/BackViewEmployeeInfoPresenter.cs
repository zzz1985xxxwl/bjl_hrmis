//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: BackViewEmployeeInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-10-09
// ����: ��̨�鿴Ա���ܽ����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.WorkInformation;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation
{
    public class BackViewEmployeeInfoPresenter : ViewEmployeeInfoPresenterBase
    {
        public BackViewEmployeeInfoPresenter(IEmployeeInfoView itsView, string employeeId)
            : base(itsView, employeeId)
        {
            _ThePresenters.Add(new ViewWorkInfoPresenter(itsView.WorkInfoView, false));
        }
        /// <summary>
        /// �����̨��ʾԱ������ʱ����Щ��Ϣ���ɼ�
        /// </summary>
        /// <param name="pageIsPostBack"></param>
        protected override void InitOthers(bool pageIsPostBack)
        {
            _ItsView.DimissionInfoVisible = true;
            _ItsView.VocationInfoVisible = true;
            _ItsView.MailToHRVisible = false;
            _ItsView.BtnExportVisible = false;
        }
    }
}
