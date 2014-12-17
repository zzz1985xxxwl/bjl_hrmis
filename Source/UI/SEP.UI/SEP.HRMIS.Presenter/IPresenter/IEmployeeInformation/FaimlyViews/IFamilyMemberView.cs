using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews
{
    public interface IFamilyMemberView
    {
        /// <summary>
        /// ��ʶ
        /// </summary>
        string Id { get; set;}
        /// <summary>
        /// ����
        /// </summary>
        string Title { get; set;}
        /// <summary>
        /// ����
        /// </summary>
        string Name { get; set;}
        string NameMessage { get; set;}
        /// <summary>
        ///  ��ϵ
        /// </summary>
        string Relationship { get; set;}
        string RelationshipMessage { get; set;}
        /// <summary>
        /// ����
        /// </summary>
        string Birthday { get; set;}
        string BirthdayMessage { get; set;}
        /// <summary>
        /// ����
        /// </summary>
        string Age { set;}
        string AgeMessage { get; set;}
        /// <summary>
        /// ��˾
        /// </summary>
        string Company { get; set;}
        /// <summary>
        /// ��ע
        /// </summary>
        string Remark { get; set;}
        /// <summary>
        /// FamilyMember����Դ
        /// </summary>
        List<FamilyMember> FamilyMemberDataSource { get; set;}
        /// <summary>
        /// ȷ�ϰ�ť
        /// </summary>
        event DelegateNoParameter BtnActionEvent;
        /// <summary>
        /// �¼��Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}
        /// <summary>
        /// ȡ����ť
        /// </summary>
        event DelegateNoParameter BtnCancelEvent;
    }
}