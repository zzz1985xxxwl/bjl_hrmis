using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    ///<summary>
    ///</summary>
    public interface IVacationFacade
    {
        /// <summary>
        /// ����Ա�������Ϣ
        /// </summary>
        /// <param name="vacation"></param>
        void AddVacation(Vacation vacation);
        /// <summary>
        /// �޸�Ա�������Ϣ
        /// </summary>
        /// <param name="vacation"></param>
        void UpdateVacation(Vacation vacation);
        /// <summary>
        /// ɾ��Ա�������Ϣ
        /// </summary>
        /// <param name="vacationID"></param>
        void DeleteVacation(int vacationID);
        /// <summary>
        /// �������ID��������Ϣ
        /// </summary>
        /// <param name="vacationID"></param>
        /// <returns></returns>
        Vacation GetVacationByVacationID(int vacationID);
        /// <summary>
        /// �༭һ��Ա���������Ϣ
        /// </summary>
        /// <param name="list"></param>
        /// <param name="employee"></param>
        void EditVacation(List<Vacation> list, Employee employee);
        /// <summary>
        /// ����Ա���ʺ�ID���Ա��������б�
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<Vacation> GetVacationByAccountID(int accountID);
        /// <summary>
        /// ����Ա���ʺ�ID���Ա�������������Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Vacation GetLastVacationByAccountID(int accountID);
        /// <summary>
        /// �����������Ա�������Ϣ
        /// </summary>
        /// <returns></returns>
        List<Vacation> GetVacationByCondition(string employeeName, decimal vacationDayNumStart, decimal vacationDayNumEnd,
                                                     DateTime vacationEndDateStart, DateTime vacationEndDateEnd,
                                                    decimal SurplusDayNumStart, decimal surplusDayNumEnd, Account Operator, int employeeStatus);
        

    }
}
