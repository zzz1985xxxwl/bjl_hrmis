//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DataCollector.cs
// ������: �ߺ�
// ��������: 2008-09-04
// ����: �����ռ��ӿڣ���view�����ݸ�������
// ----------------------------------------------------------------
namespace SEP.Presenter.IPresenter
{
    public interface IDataCollector<T>
    {
        void CompleteTheObject(T theObjectToComplete);
    }
}