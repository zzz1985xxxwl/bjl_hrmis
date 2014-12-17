//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: DalInstance.cs
// 创建者: colbert
// 创建日期: 2009-02-19
// 概述: 持久层实例化
// ----------------------------------------------------------------
using System;
using System.Configuration;
using System.Reflection;
using SEP.IDal.Accounts;
using SEP.IDal.Bulletins;
using SEP.IDal.CompanyRegulations;
using SEP.IDal.Departments;
using SEP.IDal.Goals;
using SEP.IDal.Positions;
using SEP.IDal.SpecialDates;
using SEP.IDal.WelcomeMails;
using SEP.IDal.WorkTasks;
namespace SEP.IDal
{
    /// <summary>
    /// 持久层实例化
    /// </summary>
    public static class DalInstance
    {
        /// <summary>
        /// 持久层实现程序集文件名
        /// </summary>
        public static string _path = ConfigurationManager.AppSettings["SEPDal"];

        private static Assembly _SEPDalInstance;
        private static IAccountDal _AccountDalInstance;
        private static IAccountGroupDal _AccountGroupDalInstance;
        private static IAuthDal _AuthDalInstance;
        private static IDepartmentDal _DeptDalInstance;
        private static IPositionDal _PositionDalInstance;
        private static IBulletinDal _BulletinDalInstance;
        private static ICompanyRegulationDal _CompanyRegulationDalInstance;
        private static IGoalDal _GoalDalInstance;
        private static ISpecialDateDal _SpecialDateDalInstance;
        private static IWelcomeMailDal _WelcomeMailDalInstance;
        private static IWorkTaskDal _WorkTaskDalInstance;
        static DalInstance()
        {
            InitAssembly();
        }

        private static void InitAssembly()
        {
            if (String.IsNullOrEmpty(_path))
            {
                return;
                //note by colbert for test
                //throw new Exception("SEPDal Assembly Config Error!");
            }

            if (_SEPDalInstance == null)
                _SEPDalInstance = Assembly.Load(_path);

            //note by colbert for test
            //if (_SEPDalInstance == null)
            //{
            //    throw new Exception("Load SEPDal Assembly Error!");
            //}
        }

        public static IAccountDal AccountDalInstance
        {
            get
            {
                if (_AccountDalInstance != null)
                    return _AccountDalInstance;

                InitAssembly();

                if(_SEPDalInstance != null)
                    _AccountDalInstance = (IAccountDal) _SEPDalInstance.CreateInstance(_path + ".AccountDal");

                //note by colbert for test
                //if(_AccountDalInstance == null)
                //{
                //    throw new Exception("Load SEPDal Assembly Error!");
                //}
                return _AccountDalInstance;
            }
        }

        public static IAuthDal AuthDalInstance
        {
            get
            {
                if (_AuthDalInstance != null)
                    return _AuthDalInstance;

                InitAssembly();

                if (_SEPDalInstance != null)
                    _AuthDalInstance = (IAuthDal)_SEPDalInstance.CreateInstance(_path + ".AuthDal");

                //if (_AuthDalInstance == null)
                //{
                //    throw new Exception("Load SEPDal Assembly Error!");
                //}
                return _AuthDalInstance;
            }
        }

        public static IDepartmentDal DeptDalInstance
        {
            get
            {
                if (_DeptDalInstance != null)
                    return _DeptDalInstance;

                InitAssembly();

                if (_SEPDalInstance != null)
                    _DeptDalInstance = (IDepartmentDal)_SEPDalInstance.CreateInstance(_path + ".DepartmentDal");

                //if (_DeptDalInstance == null)
                //{
                //    throw new Exception("Load SEPDal Assembly Error!");
                //}
                return _DeptDalInstance;
            }
        }

        public static IPositionDal PositionDalInstance
        {
            get
            {
                if (_PositionDalInstance != null)
                    return _PositionDalInstance;

                InitAssembly();

                if (_SEPDalInstance != null)
                    _PositionDalInstance = (IPositionDal)_SEPDalInstance.CreateInstance(_path + ".PositionDal");

                //if (_PositionDalInstance == null)
                //{
                //    throw new Exception("Load SEPDal Assembly Error!");
                //}
                return _PositionDalInstance;
            }
        }

        public static IBulletinDal BulletinDalInstance
        {
            get
            {
                if (_BulletinDalInstance != null)
                    return _BulletinDalInstance;

                InitAssembly();

                if (_SEPDalInstance != null)
                    _BulletinDalInstance = (IBulletinDal)_SEPDalInstance.CreateInstance(_path + ".BulletinDal");

                //if (_BulletinDalInstance == null)
                //{
                //    throw new Exception("Load SEPDal Assembly Error!");
                //}
                return _BulletinDalInstance;
            }
        }

        public static IAccountGroupDal AccountGroupDalInstance
        {
            get
            {
                if (_AccountGroupDalInstance != null)
                    return _AccountGroupDalInstance;

                InitAssembly();

                if (_SEPDalInstance != null)
                    _AccountGroupDalInstance = (IAccountGroupDal)_SEPDalInstance.CreateInstance(_path + ".AccountGroupDal");

                //note by colbert for test
                //if(_AccountDalInstance == null)
                //{
                //    throw new Exception("Load SEPDal Assembly Error!");
                //}
                return _AccountGroupDalInstance;
            }
        }

        public static ICompanyRegulationDal CompanyRegulationDalInstance
        {
            get
            {
                if (_CompanyRegulationDalInstance != null)
                    return _CompanyRegulationDalInstance;

                InitAssembly();

                if (_SEPDalInstance != null)
                    _CompanyRegulationDalInstance = 
                        (ICompanyRegulationDal)_SEPDalInstance.CreateInstance(_path + ".CompanyRegulationDal");

                //if (_CompanyRegulationDalInstance == null)
                //{
                //    throw new Exception("Load SEPDal Assembly Error!");
                //}
                return _CompanyRegulationDalInstance;
            }
        }

        public static IGoalDal GoalDalInstance
        {
            get
            {
                if (_GoalDalInstance != null)
                    return _GoalDalInstance;

                InitAssembly();

                if (_SEPDalInstance != null)
                    _GoalDalInstance =
                        (IGoalDal)_SEPDalInstance.CreateInstance(_path + ".GoalDal");

                //if (_GoalDalInstance == null)
                //{
                //    throw new Exception("Load SEPDal Assembly Error!");
                //}
                return _GoalDalInstance;
            }
        }

        public static ISpecialDateDal SpecialDateDalInstance
        {
            get
            {
                if (_SpecialDateDalInstance != null)
                    return _SpecialDateDalInstance;

                InitAssembly();

                if (_SEPDalInstance != null)
                    _SpecialDateDalInstance =
                        (ISpecialDateDal)_SEPDalInstance.CreateInstance(_path + ".SpecialDateDal");

                //if (_SpecialDateDalInstance == null)
                //{
                //    throw new Exception("Load SEPDal Assembly Error!");
                //}
                return _SpecialDateDalInstance;
            }
        }

        public static IWelcomeMailDal WelcomeMailDalInstance
        {
            get
            {
                if (_WelcomeMailDalInstance != null)
                    return _WelcomeMailDalInstance;

                InitAssembly();

                if (_SEPDalInstance != null)
                    _WelcomeMailDalInstance =
                        (IWelcomeMailDal)_SEPDalInstance.CreateInstance(_path + ".WelcomeMailDal");

                //if (_WelcomeMailDalInstance == null)
                //{
                //    throw new Exception("Load SEPDal Assembly Error!");
                //}
                return _WelcomeMailDalInstance;
            }
        }
         public static IWorkTaskDal WorkTaskDalInstance
        {
            get
            {
                if (_WorkTaskDalInstance != null)
                    return _WorkTaskDalInstance;

                InitAssembly();

                if (_SEPDalInstance != null)
                    _WorkTaskDalInstance =
                        (IWorkTaskDal)_SEPDalInstance.CreateInstance(_path + ".WorkTasks.WorkTaskDal");

                return _WorkTaskDalInstance;
            }
        }
    }
}
