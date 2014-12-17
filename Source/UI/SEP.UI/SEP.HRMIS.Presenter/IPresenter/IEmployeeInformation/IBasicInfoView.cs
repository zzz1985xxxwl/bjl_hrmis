using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation
{
    public interface IBasicInfoView
    {   
        /// <summary>
        /// ������
        /// <summary>
        string EmployeeName { get; set;}
        /// <summary>
        /// ����
        /// <summary>
        string DepartmentName { set;}
        /// <summary>
        /// ְλ
        /// <summary>
        string PositionName { set;}
        /// <summary>
        /// �����ַ
        /// <summary>
        string Email1 { get; set;}
        /// <summary>
        /// �����ַ2
        /// </summary>
        string Email2 { get; set;}
        /// <summary>
        /// ����
        /// </summary>
        string NativePlace { get; set;}
        string NativePlaceMessage { get;set;}
        /// <summary>
        /// ����
        /// </summary>
        string BirthDay { get; set;}
        string BirthDayMessage { get;set;}
        /// <summary>
        /// Ա������
        /// </summary>
        string EmployeeType { get; set;}
        string EmployeeTypeMessage { get;set;}
        /// <summary>
        /// ��¼��
        /// </summary>
        string AccountName { get; set;}
        /// <summary>
        /// Ӣ����
        /// </summary>
        string EnglishName { get; set;}
        /// <summary>
        /// �Ա�
        /// </summary>
        string Gender { get; set;}
        string GenderMessage { get; set;}
        /// <summary>
        /// ����
        /// </summary>
        string Nationality { get; set;}
        string NationalityMessage { get; set;}
        /// <summary>
        /// ����״��
        /// </summary>
        string MaritalStatus { get; set;}
        string MaritalStatusMessage { get; set;}
        /// <summary>
        /// ���
        /// </summary>
        string Height { get; set;}
        string HeightMessage { get; set;}
        /// <summary>
        /// ����
        /// </summary>
        string Weight { get; set;}
        string WeightMessage { get; set;}
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        string Phone { get; set;}
        /// <summary>
        /// ����״��
        /// </summary>
        string PhysicalCondition { get; set;}
        string PhysicalConditionMessage { get; set;}
        /// <summary>
        /// ������ò��ѡ��id
        /// </summary>
        string PoliticalAffiliation { get; set;}
        string PoliticalAffiliationMessage { get; set;}
        /// <summary>
        /// ���֤��
        /// </summary>
        string IDNo { get; set;}
        string IDNoMessage { get; set;}
        /// <summary>
        /// ���֤��Ч��
        /// </summary>
        string IDDueDate { get; set;}
        string IDDueDateMessage { get; set;}
        /// <summary>
        /// �Ļ��̶�
        /// </summary>
        string EducationalBackground { get; set;}
        string EducationalBackgroundMessage { get; set;}
        /// <summary>
        /// ѧУ
        /// </summary>
        string School { get; set;}
        string SchoolMessage { get; set;}
        /// <summary>
        /// רҵ
        /// </summary>
        string Major { get; set;}
        string MajorMessage { get; set;}
        /// <summary>
        /// ��ҵʱ��
        /// </summary>
        string GraduateDate { get; set;}
        string GraduateDateMessage { get; set; }

        /// <summary>
        /// ��Ƭ
        /// </summary>
        byte[] Photo { get; set;}

        /// <summary>
        /// �޸���Ƭ  
        /// </summary>
        string PhotoHref{ get; set;}
        /// <summary>
        /// Ա����������Դ
        /// </summary>
        Dictionary<string, string> EmployeeTypeSource { get; set;}
        /// <summary>
        /// �Ա�����Դ
        /// </summary>
        List<Gender> GenderSource { get; set;}
        /// <summary>
        /// ������ò����Դ
        /// </summary>
        List<PoliticalAffiliation> PoliticalAffiliationSource { get; set;}
        /// <summary>
        /// ������������Դ
        /// </summary>
        List<EducationalBackground> EducationalBackgroundSource { get; set;}
        /// <summary>
        /// ����״������Դ
        /// </summary>
        List<MaritalStatus> MaritalStatusSource { get; set;}
        /// <summary>
        /// ������ѡ��id
        /// </summary>
        string CountryNationality { get; set;}
        string CountryNationalityMessage { get; set;}
        List<Nationality> CountryNationalitySource{ get; set;}

    }
}
