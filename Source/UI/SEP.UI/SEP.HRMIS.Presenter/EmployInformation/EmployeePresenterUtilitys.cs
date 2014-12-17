//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: EmployeePresenterUtilitys.cs
// ������: �ߺ�
// ��������: 2008-06-16
// ����: ����EmployeeView��صĳ����ֶΣ��Լ��ദʹ�õķ��������ڴ���
// ----------------------------------------------------------------
using System.Text.RegularExpressions;

namespace SEP.HRMIS.Presenter.EmployInformation
{
    public static class EmployeePresenterUtilitys
    {
        #region message

        public const string _FieldNotEmpty = "����Ϊ��";
        public const string _FieldWrongFormat = "��ʽ����";
        public const string _ErrorType = "��Ч������";
        public const string _TypeNotDefined = "δָ��������";
        public const string _ObjectIsNull = "����дEmployee����ΪNull������ϵ����Ա�鿴�¼�ԭ��";

        #region EmployeeBasicInfo

        public const string _ErrorGender = "��Ч���Ա�����";
        
        #endregion

        #region ResumeInfo

        public const string _ResumeEducationExperienceAdd = "����������ѵ����";
        public const string _ResumeEducationExperienceUpdate = "�޸Ľ�����ѵ����";
        public const string _ResumeWorkExperienceAdd = "������������";
        public const string _ResumeWorkExperienceUpdate = "�޸Ĺ�������";

        #endregion

        #region DimissionInfo

        public const string _ErrorNumberRequired = "����Ϊ����";
        public const string _DimissionInfoFileCargoAdd = "��������";
        public const string _DimissionInfoFileCargoUpdate = "�޸ĵ���";

        #endregion

        #region FamilyInfo

        public const string _FamilyMebmerAdd = "������ͥ��Ա��Ϣ";
        public const string _FamilyMebmerUpdate = "�޸ļ�ͥ��Ա��Ϣ";


        #endregion

        #region EmployeeInfo

        public const string _ErrorEmployeeNotCompleted = "Ա����Ϣ��д����������д��ʽ����!";

        #endregion

        public const string _SkillSourceNull = "����ԴΪ��";
        public const string _SkillNameRepeat = "�������ظ�";

        //public const string _ErrorImage = "&nbsp;&nbsp;&nbsp;<img src='image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;";

        #endregion
    }
}