using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews
{
    public interface IFileCargoView
    {
        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; set;}
        /// <summary>
        /// 标识
        /// </summary>
        string Id { get; set;}
        /// <summary>
        /// 动作是否成功
        /// </summary>
        bool ActionSuccess { get; set;}
        /// <summary>
        /// 选择的档案类型
        /// </summary>
        string FileCargoName { get; set;}
        /// <summary>
        /// 备注
        /// </summary>
        string Remark { get; set;}
        /// <summary>
        /// 文件地址
        /// </summary>
        string File { get; set;}

        int AccountID{ get; set;}
        /// <summary>
        /// 档案类型的数据源 
        /// </summary>
        List<FileCargoName> FileCargoNameSource { set; get;}

        /// <summary>
        /// 确定按钮事件
        /// </summary>
        event DelegateNoParameter BtnActionEvent;
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        event DelegateNoParameter BtnCancelEvent;
    }
}