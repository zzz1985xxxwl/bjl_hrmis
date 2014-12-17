//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EmployeeTypeEnum.cs
// ������: �����
// ��������: 2008-05-12
// ����: Ա������
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// Ա������
    /// </summary>
    public enum EmployeeTypeEnum
    {  
        /// <summary>
        /// ȫ��
        /// </summary>
        All=-1,
        /// <summary>
        /// ʵϰ
        /// </summary>
        PracticeEmployee,
        /// <summary>
        /// ����
        /// </summary>
        ProbationEmployee,
        /// <summary>
        /// ��ʽ
        /// </summary>
        NormalEmployee,
        /// <summary>
        /// ��ְ
        /// </summary>
        PartTimeEmployee,
        /// <summary>
        /// ��ְ
        /// </summary>
        DimissionEmployee,        
        /// <summary>
        /// ����
        /// </summary>
        BorrowedEmployee,
        /// <summary>
        /// ����
        /// </summary>
        Retirement,
        /// <summary>
        /// ��Ƹ
        /// </summary>
        RetirementHire,
        /// <summary>
        /// ����
        /// </summary>
        WorkEmployee
    }
}
