//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DataBinder.cs
// ������: �ߺ�
// ��������: 2008-09-04
// ����: ���ݰ󶨽ӿڣ�������󶨵�view
// ----------------------------------------------------------------
namespace SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces
{
    public interface IDataBinder<T>
    {
        bool DataBind(T theDataToBind);
    }
}