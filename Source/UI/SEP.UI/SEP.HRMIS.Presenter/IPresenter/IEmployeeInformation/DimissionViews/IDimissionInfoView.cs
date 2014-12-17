using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews
{
    public interface IDimissionInfoView
    {
        /// <summary>
        /// 基本信息界面
        /// </summary>
        IDimissionBasicView DimmissionBasicView { get; set;}
        /// <summary>
        /// 档案界面
        /// </summary>
        IFileCargoView FileCargoView { get; set;}
        /// <summary>
        /// 小界面是否可见
        /// </summary>
        bool FileCargoViewVisible { get; set;}
    }

    public delegate void DlgFileCargos(List<FileCargo> filecargos);
}