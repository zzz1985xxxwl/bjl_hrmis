//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: SendEmailRullType.cs
// ������: ����
// ��������: 2008-10-15
// ����: ��ȡ���ں󣬷��͸������ʼ��Ĺ���
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    public enum SendEmailRuleType
    {
        InEmpty,    //�ҽ���ʱ��Ϊ�յļ�¼�����͸�����
        OutEmpty,   //�ҳ�ȥʱ��Ϊ�յļ�¼�����͸�����
        InAndOutEmpty, //�ҽ���ʱ��ͳ�ȥʱ�䶼Ϊ�յļ�¼�����͸�����
        InOrOutEmpty  //�ҽ���ʱ����߳�ȥʱ��Ϊ�յļ�¼�����͸�����
 
    }
}
