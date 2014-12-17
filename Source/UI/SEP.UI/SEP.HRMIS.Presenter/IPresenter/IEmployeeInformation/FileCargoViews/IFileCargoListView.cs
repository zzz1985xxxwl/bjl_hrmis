using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews
{
    public interface IFileCargoListView
    {
        ///// <summary>
        ///// 档案的数据源,与Session相关，请将此仅仅用作存取对象
        ///// </summary>
        //List<FileCargo> FileCargoDataSource { get; set;}

        /// <summary>
        /// 档案的界面显示，与Session无关，请将此看作界面的控件的数据源
        /// 就如同Title这样的字段一样
        /// </summary>
        List<FileCargo> FileCargoDataView { get; set;}
        /// <summary>
        /// 新增学习经历按钮
        /// </summary>
        event DelegateNoParameter BtnAddFileCargoEvent;
        bool BtnAddFileCargoVisible { get; set;}

        int AccountID{ get; set;}
        /// <summary>
        /// 修改学习经历按钮
        /// </summary>
        event DelegateID BtnUpdateFileCargoEvent;
        bool BtnUpdateFileCargoVisible { get; set;}
        /// <summary>
        /// 删除学习经历按钮
        /// </summary>
        event DelegateID BtnDeleteFileCargoEvent;
        bool BtnDeleteFileCargoVisible { get; set;}

        /// <summary>
        /// 
        /// </summary>
        event DelegateNoParameter GetFileList;
    }
}
