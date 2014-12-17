using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews
{
    public interface IFamilyMemberView
    {
        /// <summary>
        /// 标识
        /// </summary>
        string Id { get; set;}
        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; set;}
        /// <summary>
        /// 姓名
        /// </summary>
        string Name { get; set;}
        string NameMessage { get; set;}
        /// <summary>
        ///  关系
        /// </summary>
        string Relationship { get; set;}
        string RelationshipMessage { get; set;}
        /// <summary>
        /// 生日
        /// </summary>
        string Birthday { get; set;}
        string BirthdayMessage { get; set;}
        /// <summary>
        /// 年龄
        /// </summary>
        string Age { set;}
        string AgeMessage { get; set;}
        /// <summary>
        /// 公司
        /// </summary>
        string Company { get; set;}
        /// <summary>
        /// 备注
        /// </summary>
        string Remark { get; set;}
        /// <summary>
        /// FamilyMember数据源
        /// </summary>
        List<FamilyMember> FamilyMemberDataSource { get; set;}
        /// <summary>
        /// 确认按钮
        /// </summary>
        event DelegateNoParameter BtnActionEvent;
        /// <summary>
        /// 事件是否成功
        /// </summary>
        bool ActionSuccess { get; set;}
        /// <summary>
        /// 取消按钮
        /// </summary>
        event DelegateNoParameter BtnCancelEvent;
    }
}