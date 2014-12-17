//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddDimissionInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 新增离职信息的总界面的Presenter
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
        /// 继承AddUpdateDimissionPresenterBase，大小界面之间的操作
        /// </summary>
        /// <param name="itsView"></param>
        public AddDimissionInfoPresenter(IDimissionInfoView itsView)
            :base(itsView)
        {
            _BasicPresenter = new AddDimissionBasicInfoPresenter(itsView.DimmissionBasicView);
        }
        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public bool Vaildate()
        {
            return _BasicPresenter.Vaildate();
        }
        /// <summary>
        /// 信息赋值给theObjectToComplete
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
        /// 初始化
        /// </summary>
        /// <param name="pageIsPostBack"></param>
        public void InitView(bool pageIsPostBack)
        {
            _BasicPresenter.InitView(pageIsPostBack);
        }
    }
}