using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews
{
    public interface IFamilyBasicInfoView
    {
        /// <summary>
        /// 家庭地址
        /// </summary>
        string FamilyAddress { get; set;}
        string FamilyAddressMessage { get; set;}
        /// <summary>
        /// 家庭电话
        /// </summary>
        string FamilyPhone { get; set;}
        /// <summary>
        /// 邮编
        /// </summary>
        string PostCode { get; set;}
        string PostCodeMessage { get; set;}
        /// <summary>
        /// 户口地址
        /// </summary>
        string RPRAddress { get; set;}
        string RPRAddressMessage { get; set;}
        /// <summary>
        /// 户口地邮编
        /// </summary>
        string PRPPostCode { get; set;}
        string PRPPostCodeMessage { get; set;}
        /// <summary>
        /// 户口所属街道
        /// </summary>
        string PRPStreet { get; set;}
        /// <summary>
        /// 户口所属区域
        /// </summary>
        string PRPArea { get; set;}
        string PRPAreaMessage { get; set;}
        /// <summary>
        /// 档案所在地
        /// </summary>
        string RecordPlace { get; set;}
        /// <summary>
        /// 紧急联系人
        /// </summary>
        string EmergencyContacts { get; set;}
        /// <summary>
        /// 孩子姓名
        /// </summary>
        string ChildName1 { get; set;}
        /// <summary>
        /// 孩子生日
        /// </summary>
        string ChildBirthday1 { get; set;}
        string ChildBirthday1Message { get; set;}
        /// <summary>
        /// 孩子2姓名
        /// </summary>
        string ChildName2 { get; set;}
        /// <summary>
        /// 孩子2生日
        /// </summary>
        string ChildBirthday2 { get; set;}
        string ChildBirthday2Message { get; set;}
        /// <summary>
        /// 家庭成员显示的view
        /// </summary>
        List<FamilyMember> FamilyMembersView { get; set;}
        /// <summary>
        /// 家庭成员的Session存储
        /// </summary>
        List<FamilyMember> FamilyMembersDataSource { get; set;}
        /// <summary>
        /// 新增家庭成员按钮
        /// </summary>
        event DelegateNoParameter BtnAddFamilyMemberEvent;
        bool BtnAddFamilyMemberVisible { get; set;}
        /// <summary>
        /// 修改家庭成员按钮
        /// </summary>
        event DelegateID BtnUpdateFamilyMemberEvent;
        bool BtnUpdateFamilyMemberVisible { get; set;}
        /// <summary>
        /// 删除家庭成员按钮
        /// </summary>
        event DelegateID BtnDeleteFamilyMemberEvent;
        bool BtnDeleteFamilyMemberVisible { get; set;}
    }
}