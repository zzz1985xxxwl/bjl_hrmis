using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeAdjustRest;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;

namespace SEP.HRMIS.Presenter.EmployeeAdjustRest
{
    public class EmployeeAdjustRestListPresenter
    {
        private IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
        private IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private IEmployeeAttendanceFacade _IEmployeeAttendanceFacade = InstanceFactory.CreateEmployeeAttendanceFacade(); 
        private readonly IEmployeeAdjustRestListView _View;
        private readonly Account _Operator;
        public EmployeeAdjustRestListPresenter(IEmployeeAdjustRestListView view, Account _operator)
        {
            _View = view;
            _Operator = _operator;
        }

        public void InitView(bool ispostback)
        {
            _View.ResultMsg = string.Empty;
            if (!ispostback)
            {
                List<Department> deptList = _IDepartmentBll.GetAllDepartment();
                _View.DepartmentSource =
                    Tools.RemoteUnAuthDeparetment(deptList, AuthType.HRMIS, _Operator, HrmisPowers.A405);
                _View.PositionSource = _IPositionBll.GetAllPosition();
                _View.EmployeeTypeSource = EmployeeTypeUtility.GetAllEmployeeTypeEnum();
                _View.EmployeeType = EmployeeTypeEnum.All;
                SearchEvent();
            }
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            _View.BtnSearchEvent += SearchEvent;
            _View.BtnSaveEvent += SaveEvent;
        }
        private void SearchEvent()
        {
            _View.AdjustRestSource =
                _IEmployeeAttendanceFacade.GetAdjustRestByCondition(_View.EmployeeName, _View.EmployeeType,
                                                                    _View.PositionId, _View.DepartmentId,
                                                                    _View.RecursionDepartment, _Operator,
                                                                    HrmisPowers.A405,
                                                                    Convert.ToInt32(_View.EmployeeStatusId));
        }
        private void SaveEvent()
        {
            try
            {
                if (_View.CheckValidResult)
                {
                    int failCount = 0;
                    int successCount = 0;
                    int outofdateCount = 0;
                    string outofdateMsg = string.Empty;
                    List<AdjustRest> adjustRestList = _View.AdjustRestChangeValueSource;
                    foreach (AdjustRest adjustRest in adjustRestList)
                    {
                        try
                        {
                            AdjustRest currAdjustRest =
                                _IEmployeeAttendanceFacade.GetAdjustRestByPKID(adjustRest.AdjustRestID);
                            if (currAdjustRest.SurplusHours != _View.GetOldSurplusHours(adjustRest.AdjustRestID))
                            {
                                _View.OperationResultColorSet(adjustRest.AdjustRestID, OperationResult.OutOfDate,
                                                              currAdjustRest.SurplusHours);
                                outofdateCount++;
                                outofdateMsg += "<br>" + currAdjustRest.Employee.Account.Name + "��ʣ������ѱ�����Ϊ" +
                                                currAdjustRest.SurplusHours;
                                failCount++;
                                continue;
                            }
                            _IEmployeeAttendanceFacade.UpdateAdjustRest(adjustRest.AdjustRestID,
                                                                        adjustRest.SurplusHours,
                                                                        adjustRest.AdjustRestHistoryList[0].Remark,
                                                                        _Operator.Id);
                            _View.OperationResultColorSet(adjustRest.AdjustRestID, OperationResult.Success, 0);
                            successCount++;
                        }
                        catch
                        {
                            failCount++;
                            _View.OperationResultColorSet(adjustRest.AdjustRestID, OperationResult.Fail, 0);
                        }
                    }
                    _View.ResultMsg = successCount + " ����¼�޸ĳɹ���" + failCount + " ����¼�޸�ʧ�ܡ�";
                    if (outofdateCount>0)
                    {
                        _View.ResultMsg += "������" + outofdateCount + " ����¼�ѱ������޸ġ�����������£����ʵ�󱣴���£�" + outofdateMsg;
                    }
                }
                else
                {
                    _View.ResultMsg = "����ʧ�ܣ����ݸ�ʽ����ȷ������û����д�޸�ԭ��";
                }
            }
            catch (Exception ex)
            {
                _View.ResultMsg = ex.Message;
            }
        }
    }
}
