//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DbEnums.cs
// ������: �ߺ�
// ��������: 2008-6-3
// ����: ����ö�����ݿ��ֶε�typeֵ
// ----------------------------------------------------------------

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// ���ݿ�assessActivityItem�ı��type�ֶε�ö��
    /// </summary>
   public enum  DbAssessActivityItemType
   {
       HrItem,
       PersonalItem,
       ManagerItem,
   }

    /// <summary>
    /// ���ݿ�assessActivityPaper����type�ֶε�ö��
    /// </summary>
    public enum  DbSubmitInfoType
    {
        Hr,
        Personal,
        Manager,
        Direct,
        Ceo,
        SummarizeCommment,
    }
}
