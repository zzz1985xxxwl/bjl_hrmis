//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: IAddWorkView.cs
// ������: ���޾�
// ��������: 2008-09-04
// ����: AddWorkView��Ҫʵ�ֵĽӿ�
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.Presenter
{
    public interface IAddWorkView
    {
        //string Title { get; set;}

        /// <summary>
        /// ְλ
        /// </summary>
        string PositionMsg { get; set;}
        string PositionId { get;set;}

        /// <summary>
        /// Ƹ�ø�λ
        /// </summary>
        string ContractPosition { get; set;}

        /// <summary>
        /// ������˾
        /// </summary>
        string CompanyId { get;set;}
        string CompanyMsg { get; set;}

        /// <summary>
        /// ������˾������
        /// </summary>
        string CompanyLeader { get;set;}

        /// <summary>
        /// ����
        /// </summary>
        string DepartmentId { get;set;}
        string DepartmentMsg { get; set;}
        
        /// <summary>
        /// ���Ÿ�����
        /// </summary>
        string DepartmentLeader { get;set; }

        /// <summary>
        /// ��ְʱ��
        /// </summary>
        string ComeDate { get; set;}
        string ComeDateMsg { get; set;}

        /// <summary>
        /// ����ְ��
        /// </summary>
        string Responsibility { get; set;}

        /// <summary>
        /// ��ͬ��ʼ��
        /// </summary>
        string ContractStartDate { get; set;}

        /// <summary>
        /// �����ڵ�����
        /// </summary>
        string ProbationEndDate { get; set;}
        string ProbationMsg { get; set;}

        /// <summary>
        /// �º�ͬ��ʼ��
        /// </summary>
        string NewContractStartDate { get; set;}

        /// <summary>
        /// ��ͬ������
        /// </summary>
        string ContractEndDate { get; set;}

        //����󶨵���ʾԴ
        List<Position> PositionSource { set;}
        List<Department> DepartmentSource { set;}
        List<Department> DepartmentFatherSource { set;}
        List<Contract> EmployeeContract { get; set;}

        event EventHandler FatherSelectChange;
        event EventHandler DepartmentSelectChange;

    }

}
