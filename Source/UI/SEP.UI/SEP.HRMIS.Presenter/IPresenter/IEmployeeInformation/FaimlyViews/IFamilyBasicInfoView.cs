using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews
{
    public interface IFamilyBasicInfoView
    {
        /// <summary>
        /// ��ͥ��ַ
        /// </summary>
        string FamilyAddress { get; set;}
        string FamilyAddressMessage { get; set;}
        /// <summary>
        /// ��ͥ�绰
        /// </summary>
        string FamilyPhone { get; set;}
        /// <summary>
        /// �ʱ�
        /// </summary>
        string PostCode { get; set;}
        string PostCodeMessage { get; set;}
        /// <summary>
        /// ���ڵ�ַ
        /// </summary>
        string RPRAddress { get; set;}
        string RPRAddressMessage { get; set;}
        /// <summary>
        /// ���ڵ��ʱ�
        /// </summary>
        string PRPPostCode { get; set;}
        string PRPPostCodeMessage { get; set;}
        /// <summary>
        /// ���������ֵ�
        /// </summary>
        string PRPStreet { get; set;}
        /// <summary>
        /// ������������
        /// </summary>
        string PRPArea { get; set;}
        string PRPAreaMessage { get; set;}
        /// <summary>
        /// �������ڵ�
        /// </summary>
        string RecordPlace { get; set;}
        /// <summary>
        /// ������ϵ��
        /// </summary>
        string EmergencyContacts { get; set;}
        /// <summary>
        /// ��������
        /// </summary>
        string ChildName1 { get; set;}
        /// <summary>
        /// ��������
        /// </summary>
        string ChildBirthday1 { get; set;}
        string ChildBirthday1Message { get; set;}
        /// <summary>
        /// ����2����
        /// </summary>
        string ChildName2 { get; set;}
        /// <summary>
        /// ����2����
        /// </summary>
        string ChildBirthday2 { get; set;}
        string ChildBirthday2Message { get; set;}
        /// <summary>
        /// ��ͥ��Ա��ʾ��view
        /// </summary>
        List<FamilyMember> FamilyMembersView { get; set;}
        /// <summary>
        /// ��ͥ��Ա��Session�洢
        /// </summary>
        List<FamilyMember> FamilyMembersDataSource { get; set;}
        /// <summary>
        /// ������ͥ��Ա��ť
        /// </summary>
        event DelegateNoParameter BtnAddFamilyMemberEvent;
        bool BtnAddFamilyMemberVisible { get; set;}
        /// <summary>
        /// �޸ļ�ͥ��Ա��ť
        /// </summary>
        event DelegateID BtnUpdateFamilyMemberEvent;
        bool BtnUpdateFamilyMemberVisible { get; set;}
        /// <summary>
        /// ɾ����ͥ��Ա��ť
        /// </summary>
        event DelegateID BtnDeleteFamilyMemberEvent;
        bool BtnDeleteFamilyMemberVisible { get; set;}
    }
}