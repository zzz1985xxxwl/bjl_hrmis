//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: OutInRecordOperateStatusEnum.cs
// ������: wangyueqi
// ��������: 2008-10-16
// ����: ������¼�Ĳ�������
// ----------------------------------------------------------------


namespace SEP.HRMIS.Model
{
    public enum OutInRecordOperateStatusEnum
    {
        All=-1,
        /// <summary>
        /// 0:��ʾ��OA���ݿ����
        /// </summary>
        ReadFromDataBase = 0,
        /// <summary>
        /// 1��������Ա����
        /// </summary>
        AddByOperator = 1,
        /// <summary>
        /// 2��������Ա�޸�
        /// </summary>
        ModifyByOperator = 2,
        /// <summary>
        /// 3:������Աɾ��
        /// </summary>
        DeleteByOperator = 3,

        /// <summary>
        /// 4:������Ա���XLS����
        /// </summary>
        ImportByOperator = 4

    }
}
