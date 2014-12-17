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
        /// 查看保存事件
        /// </summary>
        event DelegateNoParameter BtnSaveEvent;
        /// <summary>
        /// 查看详情事件
        /// </summary>
        event DelegateID BtnDetailEvent;
        /// <summary>
        /// 查询按钮事件
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
        string ResultMsg { get;set;}

        /// <summary>
        /// 设置操作结果颜色
        /// </summary>
        void OperationResultColorSet(int adjustID, OperationResult operationResult, decimal newSurplusAdjustRest);
        /// <summary>
        /// 获得旧的剩余调休
        /// </summary>
        decimal GetOldSurplusHours(int adjustID);
    }
}
