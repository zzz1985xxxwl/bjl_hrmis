//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ReimburseStatusEnum.cs
// ������: ��ɯ��
// ��������: 2008-10-06
// ����: ������״̬
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    public enum ReimburseStatusEnum
    {
        Added,  //����
        Reimbursing,  //�ύ��
        Reimbursed,       //�ѱ���
        Return,//�˻�
        Auditing,//ͨ�����
        WaitAudit,//���������
        All=-1
    }
}
