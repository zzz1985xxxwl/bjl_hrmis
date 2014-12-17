//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddDimissionInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: ������ְ��Ϣ���ܽ����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.DimissionBasicInfo;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;

namespace SEP.HRMIS.Presenter.EmployInformation.DimissionInformation
{
    public class AddDimissionInfoPresenter : AddUpdateDimissionPresenterBase,IAddEmployeePresenter
    {
        private readonly AddDimissionBasicInfoPresenter _BasicPresenter;
        /// <summary>
        /// �̳�AddUpdateDimissionPresenterBase����С����֮��Ĳ���
        /// </summary>
        /// <param name="itsView"></param>
        public AddDimissionInfoPresenter(IDimissionInfoView itsView)
            :base(itsView)
        {
            _BasicPresenter = new AddDimissionBasicInfoPresenter(itsView.DimmissionBasicView);
        }
        /// <summary>
        /// ��֤
        /// </summary>
        /// <returns></returns>
        public bool Vaildate()
        {
            return _BasicPresenter.Vaildate();
        }
        /// <summary>
        /// ��Ϣ��ֵ��theObjectToComplete
        /// </summary>
        /// <param name="theObjectToComplete"></param>
        public void CompleteTheObject(Employee theObjectToComplete)
        {
            _BasicPresenter.CompleteTheObject(theObjectToComplete);
        }

        public void AttachViewEvent()
        {
        }
        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="pageIsPostBack"></param>
        public void InitView(bool pageIsPostBack)
        {
            _BasicPresenter.InitView(pageIsPostBack);
        }
    }
}