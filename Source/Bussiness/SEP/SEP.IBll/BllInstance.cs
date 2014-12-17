//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: BllInstance.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 业务接口实例化
// ----------------------------------------------------------------
using System;
using System.Configuration;
using System.Reflection;

using SEP.IBll.Accounts;
using SEP.IBll.Bulletins;
using SEP.IBll.CompanyRegulations;
using SEP.IBll.Departments;
using SEP.IBll.Goals;
using SEP.IBll.Mail;
using SEP.IBll.Positions;
using SEP.IBll.SpecialDates;
using SEP.IBll.WelcomeMails;
using SEP.IBll.SMS;

namespace SEP.IBll
{
    /// <summary>
    /// 业务接口实例化
    /// </summary>
    public static class BllInstance
    {
        /// <summary>
        /// 业务层实现程序集文件名
        /// </summary>
        public static string _path = ConfigurationManager.AppSettings["SEPBll"];

        private static Assembly _SEPBllInstance;

        private static IAccountBll           _AccountBllInstance;
        private static IAccountGroupBll _AccountGroupBllInstance;
        private static IAuthBll              _AuthBllInstance;
        private static IBulletinBll          _BulletinBllInstance;
        private static ICompanyRegulationBll _CompanyRegulationBllInstance;
        private static IDepartmentBll        _DepartmentBllInstance;
        private static IGoalBll              _GoalBllInstance;
        private static IPositionBll          _PositionBllInstance;
        private static ISpecialDateBll       _SpecialDateBllInstance;
        private static IWelcomeMailBll       _WelcomeMailBllInstance;
        private static IMailSource           _MailSource;
        private static IMailGateWay          _MailGateWay;
        private static ISendSMSBll           _SendSMSBllInstance;
        private static IWorkTaskBll _WorkTaskBllInstance;
        static BllInstance()
        {
            InitAssembly();
        }

        private static void InitAssembly()
        {
            if (String.IsNullOrEmpty(_path))
            {
                return;
                //note by colbert for test
                //throw new Exception("SEPBll Assembly Config Error!");
            }

            if (_SEPBllInstance == null)
                _SEPBllInstance = Assembly.Load(_path);

            //note by colbert for test
            //if (_SEPBllInstance == null)
            //{
            //    throw new Exception("Load SEPBll Assembly Error!");
            //}
        }

        public static IAccountBll AccountBllInstance
        {
            get
            {
                if (_AccountBllInstance != null)
                    return _AccountBllInstance;

                InitAssembly();

                if(_SEPBllInstance != null)
                    _AccountBllInstance = (IAccountBll)_SEPBllInstance.CreateInstance(_path + ".AccountBll");

                //note by colbert for test
                //if (_AccountBllInstance == null)
                //{
                //    throw new Exception("Load SEPBll Assembly Error!");
                //}
                return _AccountBllInstance;
            }
        }


        public static IAccountGroupBll AccountGroupBllInstance
        {
            get
            {
                if (_AccountGroupBllInstance != null)
                    return _AccountGroupBllInstance;

                InitAssembly();

                if (_SEPBllInstance != null)
                    _AccountGroupBllInstance = (IAccountGroupBll)_SEPBllInstance.CreateInstance(_path + ".AccountGroupBll");

                //note by colbert for test
                //if (_AccountBllInstance == null)
                //{
                //    throw new Exception("Load SEPBll Assembly Error!");
                //}
                return _AccountGroupBllInstance;
            }
        }

        public static IAuthBll AuthBllInstance
        {
            get
            {
                if (_AuthBllInstance != null)
                    return _AuthBllInstance;

                InitAssembly();

                if(_SEPBllInstance != null)
                    _AuthBllInstance =
                        (IAuthBll)_SEPBllInstance.CreateInstance(_path + ".AuthBll");

                //note by colbert for test
                //if (_AuthBllInstance == null)
                //{
                //    throw new Exception("Load SEPBll Assembly Error!");
                //}
                return _AuthBllInstance;
            }
        }

        public static IBulletinBll BulletinBllInstance
        {
            get
            {
                if (_BulletinBllInstance != null)
                    return _BulletinBllInstance;

                InitAssembly();

                if (_SEPBllInstance != null)
                    _BulletinBllInstance =
                        (IBulletinBll)_SEPBllInstance.CreateInstance(_path + ".BulletinBll");

                //note by colbert for test
                //if (_BulletinBllInstance == null)
                //{
                //    throw new Exception("Load SEPBll Assembly Error!");
                //}
                return _BulletinBllInstance;
            }
        }

        public static ICompanyRegulationBll CompanyRegulationBllInstance
        {
            get
            {
                if (_CompanyRegulationBllInstance != null)
                    return _CompanyRegulationBllInstance;

                InitAssembly();

                if (_SEPBllInstance != null)
                    _CompanyRegulationBllInstance =
                        (ICompanyRegulationBll)_SEPBllInstance.CreateInstance(_path + ".CompanyRegulationBll");

                //note by colbert for test
                //if (_CompanyRegulationBllInstance == null)
                //{
                //    throw new Exception("Load SEPBll Assembly Error!");
                //}
                return _CompanyRegulationBllInstance;
            }
        }

        public static IDepartmentBll DepartmentBllInstance
        {
            get
            {
                if (_DepartmentBllInstance != null)
                    return _DepartmentBllInstance;

                InitAssembly();

                if (_SEPBllInstance != null)
                    _DepartmentBllInstance =
                        (IDepartmentBll)_SEPBllInstance.CreateInstance(_path + ".DepartmentBll");

                //note by colbert for test
                //if (_DepartmentBllInstance == null)
                //{
                //    throw new Exception("Load SEPBll Assembly Error!");
                //}
                return _DepartmentBllInstance;
            }
        }

        public static IGoalBll GoalBllInstance
        {
            get
            {
                if (_GoalBllInstance != null)
                    return _GoalBllInstance;

                InitAssembly();

                if (_SEPBllInstance != null)
                    _GoalBllInstance =
                        (IGoalBll)_SEPBllInstance.CreateInstance(_path + ".GoalBll");

                //note by colbert for test
                //if (_GoalBllInstance == null)
                //{
                //    throw new Exception("Load SEPBll Assembly Error!");
                //}
                return _GoalBllInstance;
            }
        }

        public static IPositionBll PositionBllInstance
        {
            get
            {
                if (_PositionBllInstance != null)
                    return _PositionBllInstance;

                InitAssembly();

                if (_SEPBllInstance != null)
                    _PositionBllInstance =
                        (IPositionBll)_SEPBllInstance.CreateInstance(_path + ".PositionBll");

                //note by colbert for test
                //if (_PositionBllInstance == null)
                //{
                //    throw new Exception("Load SEPBll Assembly Error!");
                //}
                return _PositionBllInstance;
            }
        }

        public static ISpecialDateBll SpecialDateBllInstance
        {
            get
            {
                if (_SpecialDateBllInstance != null)
                    return _SpecialDateBllInstance;

                InitAssembly();

                if (_SEPBllInstance != null)
                    _SpecialDateBllInstance =
                        (ISpecialDateBll)_SEPBllInstance.CreateInstance(_path + ".SpecialDateBll");

                //note by colbert for test
                //if (_SpecialDateBllInstance == null)
                //{
                //    throw new Exception("Load SEPBll Assembly Error!");
                //}
                return _SpecialDateBllInstance;
            }
        }

        public static IWelcomeMailBll WelcomeMailBllInstance
        {
            get
            {
                if (_WelcomeMailBllInstance != null)
                    return _WelcomeMailBllInstance;

                InitAssembly();

                if (_SEPBllInstance != null)
                    _WelcomeMailBllInstance =
                        (IWelcomeMailBll)_SEPBllInstance.CreateInstance(_path + ".WelcomeMailBll");

                //note by colbert for test
                //if (_WelcomeMailBllInstance == null)
                //{
                //    throw new Exception("Load SEPBll Assembly Error!");
                //}
                return _WelcomeMailBllInstance;
            }
        }

        public static IMailSource MailSourceBllInstance
        {
            get
            {
                if (_MailSource != null)
                    return _MailSource;

                InitAssembly();

                if (_SEPBllInstance != null)
                    _MailSource =
                        (IMailSource)_SEPBllInstance.CreateInstance(_path + ".Mail.MailSource");

                //note by colbert for test
                //if (_MailSource == null)
                //{
                //    throw new Exception("Load SEPBll Assembly Error!");
                //}
                return _MailSource;
            }
        }

        public static IMailGateWay MailGateWayBllInstance
        {
            get
            {
                if (_MailGateWay != null)
                    return _MailGateWay;

                InitAssembly();

                if (_SEPBllInstance != null)
                    _MailGateWay =
                        (IMailGateWay)_SEPBllInstance.CreateInstance(_path + ".Mail.MailGateWay");

                //note by colbert for test
                //if (_MailGateWay == null)
                //{
                //    throw new Exception("Load SEPBll Assembly Error!");
                //}
                return _MailGateWay;
            }
        }



        public static ISendSMSBll SendSMSBllInstance
        {
            get
            {
                if (_SendSMSBllInstance != null)
                    return _SendSMSBllInstance;

                InitAssembly();

                if (_SEPBllInstance != null)
                    _SendSMSBllInstance =
                        (ISendSMSBll)_SEPBllInstance.CreateInstance(_path + ".SendSMSBll");

                //note by colbert for test
                //if (_SendSMSBllInstance == null)
                //{
                //    throw new Exception("Load SEPBll Assembly Error!");
                //}
                return _SendSMSBllInstance;
            }
        }
        public static IWorkTaskBll WorkTaskBllInstance
        {
            get
            {
                if (_WorkTaskBllInstance != null)
                    return _WorkTaskBllInstance;

                InitAssembly();

                if (_SEPBllInstance != null)
                    _WorkTaskBllInstance =
                        (IWorkTaskBll)_SEPBllInstance.CreateInstance(_path + ".WorkTasks.WorkTaskBll");
                return _WorkTaskBllInstance;
            }
        }
    }
}
