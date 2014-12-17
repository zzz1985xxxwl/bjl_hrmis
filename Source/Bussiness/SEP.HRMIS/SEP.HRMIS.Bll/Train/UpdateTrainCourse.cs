//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateTrainCourse.cs
// ������: ����
// ��������: 2008-11-12
// ����: ���¿γ�
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
        ///AddTrainCourse�Ĺ��캯����רΪ�����ṩ
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
        /// �����²�������γ̵ķ���
        /// </summary>
        protected override void ExcuteSelf()
        {
            //�������������ˣ�����������һ���γ�
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
                            //�����Ա������Ϣ���������Ϣ
                            _Course.TrainFBResult.TrainEmployeeFBs.Add(fb);
                            _Employees.Remove(employee);
                            break;
                        }
                    }
                }
                //����Ϣ��δ���½�һ������
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
              // throw new ApplicationException("��û�й����Э��Ա��Ȩ��");
                BllUtility.ThrowException(BllExceptionConst._Condinator_NoAuth);
            }
        }

        private List<TrainEmployeeFB> GetFbResults()
        {
            Course oldCourse = _DalTrain.GetTrainCourseByPKID(_Course.CourseID);
            return oldCourse.TrainFBResult.TrainEmployeeFBs;
        }

        /// <summary>
        /// �жϵ�½�û��Ƿ����ѡ���Э��Ա
        /// </summary>
        private bool IsLoginUserManage(Account addAccont, Account loginUser)
        {
            Auth myAuth = loginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A801);

            if (myAuth == null)
            {
                //throw new ApplicationException("��û�й�����ѵ�γ̵�Ȩ��");
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
