//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteVacationByPKID.cs
// ������: Ѧ����
// ��������: 2008-11-1
// ����: �༭��٣���ٵ���ɾ�Ķ��ô���
// ----------------------------------------------------------------
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    public class EditVacation 
    {
        private static IVacation _Dal = DalFactory.DataAccess.CreateVacation();
        private readonly List<Model.Vacation> _VacationList;
        private readonly Employee _Employee;

        /// <summary>
        /// ������
        /// </summary>
        public EditVacation(List<Model.Vacation> vacationList, Employee employee, IVacation mockDal)
        {
            _Employee = employee;
            _VacationList = vacationList;
            _Dal = mockDal;
          
        }
        public EditVacation(List<Model.Vacation> vacationList, Employee employee)
        {
            _Employee = employee;
            _VacationList = vacationList;
        }

        public  void Excute()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _Dal.DeleteVacationByAccountID(_Employee.Account.Id);
                    if (_VacationList != null && _VacationList.Count > 0)
                    {
                        foreach (Model.Vacation vacation in _VacationList)
                        {
                            vacation.Employee = _Employee;
                            _Dal.Insert(vacation);
                        }
                    }
                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }


    }
}
