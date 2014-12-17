//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EmployeeCache.cs
// ������: �ߺ�
// ��������: 2008-11-20
// ����: ʹ�õ�����ʽ����������Ա�����棬�û�������ݾ�ȷ��֤��
//        private int _EmployeeID;
//        private string _Name;
//        private string _Email;
//        private string _Email2;
//        private EmployeeTypeEnum _EmployeeType;
//        private Position _Position;
//        private Department _Department;
//        private AccountsFront _AccountsFront;
//        private EmployeeDetails _EmployeeDetails;
//        ���ϵ�ÿһ���ֶΣ�����֮�����Ϣ��δ���أ�Ҳ��δ��֤
//        ��Ƭ��Ϣ�Ƿ񻺴��������
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    public static class EmployeeCache
    {
        private static readonly IEmployee _EmployeeDal = DalFactory.DataAccess.CreateEmployee();
        private static List<Employee> _EmployeeCache;

        /// <summary>
        /// ����Ա���Ļ�����Ϣ(��������������Ϣ��������������Ҫ�ٴμ��ص���Ϣ)
        /// ���Է��ʵ�Ա���ĵ绰��Ϣ�ȶ�����������Ϣ
        /// ����ȴ�޷�����Ա���ĺ�ͬ��Ϣ/������Ϣ/������Ϣ/�ʼ��ʺ�/�����Ϣ/��
        /// </summary>
        public static List<Employee> GetAllEmployeeBasicInfoFromCache
        {
            get
            {
                if(_EmployeeCache == null)
                {
                    _EmployeeCache = LoadAllEmployeeInfoWith(false);
                }
                return _EmployeeCache;
            }
        }

        public static void DisableEmployeeCache()
        {
            _EmployeeCache = null;
        }

        private static List<Employee> LoadAllEmployeeInfoWith(bool photoEnable)
        {
            List<Employee> allEmployees = _EmployeeDal.GetAllEmployeeBasicInfo();

            List<Employee> theDetailEmployees = new List<Employee>();
            foreach (Employee e in allEmployees)
            {
                Employee detailEmployee = _EmployeeDal.GetEmployeeByAccountID(e.Account.Id);
                //������ֶη�ֹ������س��������»�ȥ
                detailEmployee.ObjectStatus = false;
                //�Ƿ񻺴���Ƭ��Ϣ
                if (!photoEnable)
                {
                    detailEmployee.EmployeeDetails.Photo = null;
                }
                theDetailEmployees.Add(detailEmployee);
            }

            return theDetailEmployees;
        }
    }
}