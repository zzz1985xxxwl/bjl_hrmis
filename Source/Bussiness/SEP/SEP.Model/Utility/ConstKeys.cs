
using System;
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.Model
{
    //note ���뵽Performance
    ///// <summary>
    ///// Session��ʶ��
    ///// </summary>
    //public class SessionKeys
    //{
    //    public const string LOGININFO   = "LoginInfo";
    //    public const string SEPAUTHTREE = "SEP_AuthTree";
    //    public const string SELECTEDAUTHTREEINDEX = "SelectedIndex";
    //}

    /// <summary>
    /// ��Ϣ����
    /// </summary>
    public class MessageKeys
    {
        public const string _NormalError = "δ֪����";
        public const string _DbError = "���ݿ���ʴ���";
        public const string _NoAuth = "�޸ò���Ȩ�ޣ�";

        #region Account

        public const string _Account_IsNot_Exist="��ǰ�ʺŲ����ڣ�";
        public const string _Account_Not_Exist = "��¼�������ڣ�";
        public const string _Account_Invalid = "�˺���ʧЧ��";
        public const string _Account_Password_Wrong = "�������";
        public const string _Account_UsbKey_Wrong = "UsbKey����";
        public const string _Account_Not_Repeat = "��¼�������ظ���";
        public const string _OldPassword_Wrong = "�����벻��ȷ��";

        public const string _Employee_Name_Repeat = "Ա�����������ظ���";

        public const string _UsbKey_Not_Exist = "�����UsbKey�����֤��";
        public const string _UsbKey_Not_Repeat = "��ȷ������һ��UsbKey�����֤��";

        public const string _Account_IsValidateUsbKey_NoUsbKey = "UsbKeyû�����ɣ�������UsbKey���ٿ���UsbKey�����֤��";

        public const string _Account_ElectronIdiograph_NoUsbKey = "���ӵ���ǩ����������UsbKey��";
        #endregion

        #region Bulletin

        /// <summary>
        /// ���������ظ�
        /// </summary>
        public const string _Appendix_Title_Repeat = "���������ظ�";
        /// <summary>
        /// ��������ظ�
        /// </summary>
        public const string _Bulletin_Title_Repeat = "��������ظ�";
        /// <summary>
        /// �ù��治����
        /// </summary>
        public const string _Bulletin_Not_Exist = "�ù��治����";
        /// <summary>
        /// ����������
        /// </summary>
        public const string _Appendix_Not_Exist = "����������";
        /// <summary>
        /// ������ⲻ��Ϊ��
        /// </summary>
        public const string _Bulletin_Title_Null = "������ⲻ��Ϊ��";
        /// <summary>
        /// ���鸽�������Ƿ�Ϊ�ջ����50���ַ�
        /// </summary>
        public const string _Appendix_Title_Null_Or_Big_Then_Fifty = "���鸽�������Ƿ�Ϊ�ջ����50���ַ�";
        /// <summary>
        /// ������ⲻ�ܳ���50���ַ�
        /// </summary>
        public const string _Bulletin_Title_Big_Then_Fifty = "������ⲻ�ܳ���50���ַ�";

        #endregion

        #region CompanyRegulations

        public const string _CompanyRegulations_Title_Null = "���ⲻ��Ϊ�գ�";
        public const string _CompanyReguAppendix_FileName_Null = "�������ⲻ��Ϊ�գ�";
        public const string _CompanyReguAppendix_Directory_Null = "����·������Ϊ�գ�";

        #endregion

        #region Department
        /// <summary>
        /// �������Ʋ����ظ�
        /// </summary>
        public const string _Department_Name_Repeat = "�������Ʋ����ظ���";
        /// <summary>
        /// �������ܲ���Ϊ��
        /// </summary>
        public const string _Department_Leader_NotEmpty = "�������ܲ���Ϊ�գ�";
        /// <summary>
        /// �����ڸò�������
        /// </summary>
        public const string _Department_Leader_NotExist = "�ò������ܲ����ڣ�";
        /// <summary>
        /// �ϼ����Ų���Ϊ��
        /// </summary>
        public const string _Department_ParentDepartment_CannotBeNull = "�ϼ����Ų���Ϊ�գ�";
        /// <summary>
        /// �ϼ����Ų�����
        /// </summary>
        public const string _Department_ParentDepartment_NotExist = "�ϼ����Ų����ڣ�";
        /// <summary>
        /// �ò��Ų�����
        /// </summary>
        public const string _Department_NotExist = "�ò��Ų����ڣ�";
        /// <summary>
        /// �������ϼ����Ų��ܱ��޸�
        /// </summary>
        public const string _Department_RootDepartment_CannotBeChanged = "�������ϼ����Ų��ܱ��޸ģ�";
        /// <summary>
        /// ����Ա�����ڸò���
        /// </summary>
        public const string _Department_HasEmployee = "����Ա�����ڸò��ţ�";
        /// <summary>
        /// �ò����´����Ӳ���
        /// </summary>
        public const string _Department_HasChildren = "�ò����´����Ӳ��ţ�";

        #endregion

        #region Employess

        public const string _Employee_NotExist = "��Ա�������ڣ�";

        #endregion

        #region Goal
        /// <summary>
        /// ��˾Ŀ������ظ�
        /// </summary>
        public const string _CompanyGoal_Title_Repeat = "��˾Ŀ������ظ�";
        /// <summary>
        /// ����Ŀ������ظ�
        /// </summary>
        public const string _PersonalGoal_Title_Repeat = "����Ŀ������ظ�";
        /// <summary>
        /// �Ŷ�Ŀ������ظ�
        /// </summary>
        public const string _DepartmentGoal_Title_Repeat = "�Ŷ�Ŀ������ظ�";
        /// <summary>
        /// ��Ŀ�겻����
        /// </summary>
        public const string _Goal_NotExist = "��Ŀ�겻����";
        /// <summary>
        /// �ù�˾Ŀ�겻����
        /// </summary>
        public const string _CompanyGoal_NotExist = "�ù�˾Ŀ�겻����";
        /// <summary>
        /// �ø���Ŀ�겻����
        /// </summary>
        public const string _PersonalGoal_NotExist = "�ø���Ŀ�겻����";
        /// <summary>
        /// ���Ŷ�Ŀ�겻����
        /// </summary>
        public const string _DepartmentGoal_NotExist = "���Ŷ�Ŀ�겻����";
        /// <summary>
        /// Ŀ����ⲻ��Ϊ��
        /// </summary>
        public const string _Goal_Title_Null = "Ŀ����ⲻ��Ϊ��";
        /// <summary>
        /// Ŀ����ⲻ�ܳ���50���ַ�
        /// </summary>
        public const string _Goal_Title_More_Then_Fifty = "Ŀ����ⲻ�ܳ���50���ַ�";


        #endregion

        #region Position
        public const string _Position_AddPageTitle = "����ְλ";
        public const string _Position_AddOperationType = "Add";

        public const string _Position_UpdatePageTitle = "�޸�ְλ";
        public const string _Position_UpdateOperationType = "Update";

        public const string _Position_DeletePageTitle = "ɾ��ְλ";
        public const string _Position_DeleteOperationType = "Delete";

        public const string _Position_DetailPageTitle = "�鿴ְλ";
        public const string _Position_DetailOperationType = "Detail";

        public const string _Position_NameIsEmpty = "����Ϊ�գ�";
        public const string _Position_GradeIsEmpty = "����Ϊ�գ�";

        public const string _Position_ErrorNullType = "û���κ�ְλ��";

        public const string _Position_Not_Exist = "ְλ�����ڣ�";
        public const string _Position_Name_Repeat = "ְλ���Ʋ����ظ���";
        public const string _Position_HasEmployee = "���ڸ�ְλ��Ա����";

        public const string _PositionGrade_NameIsEmpty = "ְλ�ȼ�����Ϊ�գ�";
        public const string _PositionGrade_Name_NotExist = "ְλ�ȼ������ڣ�";
        public const string _PositionGrade_Name_Repeat = "ְλ�ȼ����Ʋ����ظ���";
        public const string _PositionGrade_HasPosition = "���ڸ�ְλ�ȼ���ְλ��";

        public const string _PositionNature_Name_NotExist = "��λ���ʲ����ڣ�";
        public const string _PositionNature_Name_Repeat = "��λ�������Ʋ����ظ���";
        public const string _PositionNature_HasPosition = "���ڸø�λ���ʵ�ְλ��";

        #endregion
        #region WorkTask

        public const string _WorkTask_IsNot_Exist = "�ù����ƻ������ڣ�";

        public const string _WorkTaskQA_IsNot_Exist = "�����Բ����ڣ�";
        #endregion

        #region

        public static ApplicationException AppException(string msg)
        {
            return new ApplicationException(msg);
        }

        #endregion
    }


    /// <summary>
    /// Ȩ��ֵ
    /// </summary>
    public class Powers
    {
        #region 1 �û�����

        public const int A01 = 1;
        /// <summary>
        /// �����û�
        /// </summary>
        public const int A101 = 101;

        /// <summary>
        /// ��ѯ�û�
        /// </summary>
        public const int A102 = 102;

        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public const int A103 = 103;

        #endregion

        #region 2 ��֯�ṹ����

        public const int A02 = 2;
        /// <summary>
        /// ���Ź���
        /// </summary>
        public const int A201 = 201;

        /// <summary>
        /// ְλ����
        /// </summary>
        public const int A202 = 202;

        /// <summary>
        /// ְλ�ȼ�����
        /// </summary>
        public const int A203 = 203;

        #endregion

        #region 3 �������

        public const int A03 = 3;
        /// <summary>
        /// ��������
        /// </summary>
        public const int A301 = 301;

        /// <summary>
        /// ��ѯ����
        /// </summary>
        public const int A302 = 302;

        #endregion

        #region 4 ��˾Ŀ�����

        public const int A04 = 4;
        /// <summary>
        /// ������˾Ŀ��
        /// </summary>
        public const int A401 = 401;

        /// <summary>
        /// ��ѯ��˾Ŀ��
        /// </summary>
        public const int A402 = 402;

        #endregion

        #region 5 ��ҵ�Ļ�

        public const int A05 = 5;
        /// <summary>
        /// ���ù�˾����
        /// </summary>
        public const int A501 = 501;
        /// <summary>
        /// ���û�ӭ��
        /// </summary>
        public const int A502 = 502;
        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public const int A503 = 503;

        #endregion

        #region 6 ��ֵ����

        public const int A06 = 6;
        /// <summary>
        /// �鿴��������
        /// </summary>
        public const int A601 = 601;

        #endregion

        #region Ȩ����֤

        public static bool HasAuth(List<Auth> auths, AuthType type, int authId)
        {
            foreach (Auth auth in auths)
            {
                if (auth.Type != type)
                    continue;

                if (auth.IsExistAuth(authId))
                    return true;
            }

            return false;
        }

        #endregion
    }
}
