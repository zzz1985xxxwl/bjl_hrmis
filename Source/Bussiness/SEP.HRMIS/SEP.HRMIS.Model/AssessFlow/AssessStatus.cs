//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AssessStatus.cs
// ������: �ߺ�
// ��������: 2008-05-29
// ����: ����״̬
// ----------------------------------------------------------------
using System.Collections.Generic;
namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 
    /// </summary>
    public enum AssessStatus
    {
        /// <summary>
        /// ȫ��
        /// </summary>
        All = -1,

        /// <summary>
        /// ��ȷ��
        /// </summary>
        HRComfirming,

        /// <summary>
        /// ��������Դ����
        /// </summary>
        HRFilling,

        /// <summary>
        /// ����������
        /// </summary>
        PersonalFilling,

        /// <summary>
        /// ����������
        /// </summary>
        ManagerFilling,

        /// <summary>
        /// ������
        /// </summary>
        ApproveFilling,

        /// <summary>
        /// �ս�����
        /// </summary>
        SummarizeCommment,

        //DirectorFilling,
        //CEOFilling,

        /// <summary>
        /// ���
        /// </summary>
        Finish,

        /// <summary>
        /// �ж�
        /// </summary>
        Interrupt,
    }

    ///<summary>
    ///</summary>
    public static class AssessActivityName
    {
        public const string HRAssess = "������Դ����";
        public const string MyselfAssess  = "��������";
        public const string ManagerAssess = "��������";
        public const string Approve = "����";
        public const string SummarizeCommment = "�ս�����";

        ///<summary>
        ///</summary>
        public static List<string> AssessActivityNameList
        {
            get
            {
                List<string> list = new List<string>();
                list.Add(HRAssess);
                list.Add(MyselfAssess);
                list.Add(ManagerAssess);
                list.Add(Approve);
                list.Add(SummarizeCommment);
                return list;
            }
        }
    }
}
