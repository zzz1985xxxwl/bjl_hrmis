//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateTrainCourse.cs
// 创建者: 刘丹
// 创建日期: 2008-11-12
// 概述: 更新课程
// ----------------------------------------------------------------

using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll
{
    ///<summary>
    ///</summary>
    public class UpdateTrainCourse : Transaction
    {
        private static ITrain _DalTrain = DalFactory.DataAccess.CreateTrain();
        protected static IEmployee _EmployeeDal = DalFactory.DataAccess.CreateEmployee();
        private readonly IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private readonly Course _Course;
        private readonly List<Skill> _Skills;
        private readonly List<Account> _Employees;
        protected Account _ItsCordinator;
        protected Account _LoginUser;
        private bool _IsFeedBackPaperUpdate=true;

        ///<summary>
        ///</summary>
        ///<param name="course"></param>
        ///<param name="skills"></param>
        ///<param name="employees"></param>
        ///<param name="loginUser"></param>
        public UpdateTrainCourse(Course course, List<Skill> skills, List<Account> employees, Account loginUser)
        {
            _Course = course;
            _Skills = skills;
            _Employees = employees;
            _LoginUser = loginUser;
        }

        ///<summary>
        ///AddTrainCourse的构造函数，专为测试提供
        ///</summary>
        public UpdateTrainCourse(Course course, List<Skill> skills, List<Account> employees, ITrain iTrain, IEmployee iemployee, IAccountBll mockIAccountBll,Account loginUser)
        {
            _Course = course;
            _Skills = skills;
            _Employees = employees;
            _DalTrain = iTrain;
            _EmployeeDal = iemployee;
            _IAccountBll = mockIAccountBll;
            _LoginUser = loginUser;
        }

        /// <summary>
        /// 调用下层的新增课程的方法
        /// </summary>
        protected override void ExcuteSelf()
        {
            //如果反馈表更新了，就重新新增一个课程
            if (_IsFeedBackPaperUpdate)
            {
                new DeleteTrainCourse(_Course.CourseID).Excute();
                new AddTrainCourse(_Course, _Skills, _Employees, _LoginUser).Excute();
                return;
            }
            try
            {

                _Course.Skill = new List<Skill>();
                foreach (Skill skill in _Skills)
                {
                    _Course.Skill.Add(skill);
                }
                _Course.TrainFBResult = new TrainFBResult();
                _Course.TrainFBResult.TrainEmployeeFBs = new List<TrainEmployeeFB>();

                TrainEmployeeFB employeeFb;
                foreach (TrainEmployeeFB fb in GetFbResults())
                {
                    foreach (Account employee in _Employees)
                    {
                        if (fb.Trainee.Id.Equals(employee.Id))
                        {
                            //如果该员工有信息，添加其信息
                            _Course.TrainFBResult.TrainEmployeeFBs.Add(fb);
                            _Employees.Remove(employee);
                            break;
                        }
                    }
                }
                //无信息，未起新建一条数据
                if (_Employees.Count != 0)
                {
                    foreach (Account employee in _Employees)
                    {
                        employeeFb = new TrainEmployeeFB(null, string.Empty);
                        employeeFb.Trainee = employee;
                        _Course.TrainFBResult.TrainEmployeeFBs.Add(employeeFb);
                    }
                }
                _Course.Coordinator = _ItsCordinator;
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DalTrain.UpdateTrainCourse(_Course);
                    ts.Complete();
                }
                if (_Course.Status == TrainStatusEnum.End)
                {
                    List<Skill> skills = _Course.Skill;
                    List<TrainEmployeeFB> employeeFBs = _Course.TrainFBResult.TrainEmployeeFBs;
                    foreach (TrainEmployeeFB fb in employeeFBs)
                    {
                        if (fb.FBTime != null)
                        {
                            new FinishTrainCourse(_Course.CourseID).InsertEmployeeSkill(fb.Trainee.Id, skills);
                        }
                    }
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        protected override void Validation()
        {
            Course oldcourse = _DalTrain.GetTrainCourseByPKID(_Course.CourseID);
            if (oldcourse == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Skill_Name_NotExist);
            }
            else if(oldcourse.CourseFeedBackPaper.FeedBackPaperId.Equals(_Course.CourseFeedBackPaper.FeedBackPaperId))
            {
                _IsFeedBackPaperUpdate = false;
            }

            if (oldcourse != null)
                switch (oldcourse.Status)
                {
                    case TrainStatusEnum.Interrupt:
                        BllUtility.ThrowException(BllExceptionConst._TrainCourse_Interrupt);
                        break;
                    case TrainStatusEnum.End:
                        BllUtility.ThrowException(BllExceptionConst._TrainCourse_End);
                        break;
                }
            _ItsCordinator = _IAccountBll.GetAccountByName(_Course.Coordinator.Name);
            if (_ItsCordinator == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Employee_Not_Found);
            }

            if (!IsLoginUserManage(_ItsCordinator, _LoginUser))
            {
              // throw new ApplicationException("您没有管理该协调员的权限");
                BllUtility.ThrowException(BllExceptionConst._Condinator_NoAuth);
            }
        }

        private List<TrainEmployeeFB> GetFbResults()
        {
            Course oldCourse = _DalTrain.GetTrainCourseByPKID(_Course.CourseID);
            return oldCourse.TrainFBResult.TrainEmployeeFBs;
        }

        /// <summary>
        /// 判断登陆用户是否可以选择该协调员
        /// </summary>
        private bool IsLoginUserManage(Account addAccont, Account loginUser)
        {
            Auth myAuth = loginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A801);

            if (myAuth == null)
            {
                //throw new ApplicationException("您没有管理培训课程的权限");
                BllUtility.ThrowException(BllExceptionConst._TrainCourseManagement_NoAuth);
            }

            if (myAuth.Departments.Count == 0)
                return true;

            if (Tools.IsDeptListContainsDept(myAuth.Departments, _IAccountBll.GetAccountById(addAccont.Id).Dept))
                return true;

            return false;
        }
    }
}
