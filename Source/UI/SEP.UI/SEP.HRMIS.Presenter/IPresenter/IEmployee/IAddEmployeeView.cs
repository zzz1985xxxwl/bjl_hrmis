//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: IAddEmployeeView.cs
// ������: �ߺ�
// ��������: 2008-06-16
// ����: AddEmployeeView��Ҫʵ�ֵĽӿ�
// �޸ģ�����
// �޸����ڣ�2008-09-02
// ����������Ա������ϸ��Ϣ
// ----------------------------------------------------------------

using System.Collections.Generic;


namespace SEP.HRMIS.Presenter.IPresenter
{
    public interface IAddEmployeeView
    {
        //string Message { get;set;}
        //string Title { get; set;}

        //������
        string EmployeeName { get; set;}
        string EmployeeNameMessage { get;set;}

        //�����ַ
        string Email1{ get; set;}
        string Email1Message { get;set;}

        /// <summary>
        /// ����
        /// </summary>
        string NativePlace { get; set;}
        string NativePlaceMessage { get;set;}

        //��������
        string BirthDay { get; set;}
        string BirthDayMessage { get;set;}


        //string ResidencePermit { get; set;}
        //string ResidencePermitMessage { get;set;}

        /// <summary>
        /// Ա��״̬
        /// </summary>
        string EmployeeType{ get; set;}
        string EmployeeTypeMessage { get;set;}

        /// <summary>
        ///��¼��
        /// </summary>
        string AccountName { get; set;}
        string AccountNameMessage { get; set;}

        /// <summary>
        /// �����ַ2
        /// </summary>
        string Email2 { get; set;}
        string Email2Message { get; set;}

        string GraduateDate { get; set;}

        ///����󶨵���ʾԴ
        Dictionary<string, string> EmployeeTypeSource { get;set;}
        //List<Position> PositionSource { get;set;}
        //List<Department> DepartmentSource { get;set;}


        Dictionary<int, string> EmployeeGenderSource { get; set;}
        Dictionary<int, string> PoliticalAffiliationSource { get; set;}
        Dictionary<int, string> PhysicalConditionSource { get; set;}
        Dictionary<int, string> EducationBackgroudSource { get; set;}

        //����İ�ť����
        //string ActionButtonTxt { get;set;}
        //bool ActionButtonVisable { get;set;}
        //bool ActionButtonEnable{ get; set;}

        //event EventHandler ActionButtonEvent;
        //event EventHandler CancelButtonEvent;

        //EmployeeDetails
        /// <summary>
        /// Ӣ����
        /// </summary>
        string EnglishName { get; set;}

        /// <summary>
        /// �Ա�
        /// </summary>
        int EmployeeGenderID { get; set;}
        string GenderMessage { get; set;}

       /// <summary>
       /// ����
       /// </summary>
        string Nationality { get; set;}
        string NationalityMessage { get; set;}

        /// <summary>
        /// ����״��
        /// </summary>
        bool MaritalStatus { get; set;}
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
        string PhoneMessage { get; set;}

        /// <summary>
        /// ����״��
        /// </summary>
        string PhysicalCondition { get; set;}
        string PhysicalConditionMessage { get; set;}

        /// <summary>
        /// ������ò��ѡ��id
        /// </summary>
        int PoliticalAffiId { get; set;}
        string PoliticalMessage { get; set;}

        /// <summary>
        /// ��Ƭ
        /// </summary>
        byte[] photo { get; set;}

        //IDCard
        /// <summary>
        /// ���֤��
        /// </summary>
        string IDNo { get; set;}
        string IDNoMessage { get; set;}

        /// <summary>
        /// ���֤��Ч��
        /// </summary>
        string IdDueDate { get; set;}
        string IDDueDateMessage { get; set;}

        //����
        /// <summary>
        /// �Ļ��̶�
        /// </summary>
        int EducationalBackground { get; set;}
        string EduMessage{ get; set;}

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
        /// ����
        /// </summary>
        string EmployeeID { get; set;}
    }


}
