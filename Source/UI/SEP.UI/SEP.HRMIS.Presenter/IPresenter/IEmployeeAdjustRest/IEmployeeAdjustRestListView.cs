using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Presenter;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeAdjustRest
{
    public interface IEmployeeAdjustRestListView
    {
        List<AdjustRest> AdjustRestChangeValueSource { get;}
        bool CheckValidResult { get;}
        string EmployeeName { get;}
        EmployeeTypeEnum EmployeeType { get;set;}

        Dictionary<string, string> EmployeeTypeSource { set;}
        List<Position> PositionSource { set;}
        List<AdjustRest> AdjustRestSource { set;}
        List<Department> DepartmentSource { set; }

        string EmployeeStatusId { get;}
        int PositionId { get;}
        int DepartmentId { get;}

        bool RecursionDepartment { get; }

        /// <summary>
        /// �鿴�����¼�
        /// </summary>
        event DelegateNoParameter BtnSaveEvent;
        /// <summary>
        /// �鿴�����¼�
        /// </summary>
        event DelegateID BtnDetailEvent;
        /// <summary>
        /// ��ѯ��ť�¼�
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
        string ResultMsg { get;set;}

        /// <summary>
        /// ���ò��������ɫ
        /// </summary>
        void OperationResultColorSet(int adjustID, OperationResult operationResult, decimal newSurplusAdjustRest);
        /// <summary>
        /// ��þɵ�ʣ�����
        /// </summary>
        decimal GetOldSurplusHours(int adjustID);
    }
}
