//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IAddEmployeePresenter.cs
// ������: �ߺ�
// ��������: 2008-09-04
// ����: ����Employee���޸ĵ�ÿһ��tabҳ��Ӧ��ʵ�ָýӿ�
// ----------------------------------------------------------------
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces
{
    public interface IUpdateEmployeePresenter : IDataBinder<Employee>, IVaildater, IDataCollector<Employee>, IEmployeeBasePresenter
    {
    }
}