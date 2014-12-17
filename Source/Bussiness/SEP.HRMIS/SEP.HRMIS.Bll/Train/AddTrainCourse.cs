//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddTrainCourse.cs
// 创建者: 刘丹
// 创建日期: 2008-11-12
// 概述: 新增课程
// ----------------------------------------------------------------

using System.Collections.Generic;
using System.Text;
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
    public class AddTrainCourse:Transaction
    {
        private static ITrain _DalTrain = DalFactory.DataAccess.CreateTrain();
        //private static IFBQuestion _DalFBQues = DalFactory.DataAccess.CreateFBQues();
        private static IFeedBackPaper _IFeedBackPaper = DalFactory.DataAccess.CreateFeedBackPaper();
        protected static IEmployee _EmployeeDal = DalFactory.DataAccess.CreateEmployee();
        private readonly IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private readonly Course _Course;
        private readonly List<Skill> _Skills;
        private readonly List<Account> _Employees;
        protected Account _ItsCordinator;
        protected Account _LoginUser;

        ///<summary>
        ///</summary>
        ///<param name="course"></param>
        ///<param name="skills"></param>
        ///<param name="employees"></param>
        ///<param name="loginUser"></param>
        public AddTrainCourse(Course course, List<Skill> skills, List<Account> employees,Account loginUser)
        {
            _Course = course;
            _Skills = skills;
            _Employees = employees;
            _LoginUser = loginUser;
        }

        ///<summary>
        ///AddTrainCourse的构造函数，专为测试提供
        ///</summary>
        public AddTrainCourse(Course course, List<Skill> skills, List<Account> employees, ITrain iTrain, IFeedBackPaper ipaper, IEmployee iemployee, IAccountBll mockIAccountBll, Account loginUser)
        {
            _Course = course;
            _Skills = skills;
            _Employees = employees;
            _DalTrain = iTrain;
            //_DalFBQues = iQues;
            _IFeedBackPaper = ipaper;
            _EmployeeDal = iemployee;
            _IAccountBll = mockIAccountBll;
            _LoginUser = loginUser;
        }

        /// <summary>
        /// 调用下层的新增课程的方法
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                _Course.Skill = new List<Skill>();
                foreach (Skill skill in _Skills)
                {
                    _Course.Skill.Add(skill);
                }
                _Course.TrainFBResult = new TrainFBResult();
                _Course.TrainFBResult.FBPaperItem = GetFBItem();
                _Course.TrainFBResult.TrainEmployeeFBs = new List<TrainEmployeeFB>();
                foreach (Account employee in _Employees)
                {
                    TrainEmployeeFB employeeFb = new TrainEmployeeFB(null, string.Empty);
                    employeeFb.Trainee = employee;
                    _Course.TrainFBResult.TrainEmployeeFBs.Add(employeeFb);
                }
                _Course.Coordinator = _ItsCordinator;
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DalTrain.InsertTrainCourse(_Course);
                    ts.Complete();
                }
                new AddCourseSendMail(_Employees, _Course).Excute();
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        protected override void Validation()
        {
            _ItsCordinator = _IAccountBll.GetAccountByName(_Course.Coordinator.Name);
            if (_ItsCordinator == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Condinator_Cannot_Find);
            }
            if (_Course.Status == TrainStatusEnum.End || _Course.Status == TrainStatusEnum.Interrupt)
            {
                BllUtility.ThrowException(BllExceptionConst._TrainCourseNew_Cannot_End);
            }
            //if (_Course.Status != TrainStatusEnum.Start)
            //{
            //    BllUtility.ThrowException(BllExceptionConst._TrainCourseNew_Cannot_End);
            //}
            if (!IsLoginUserManage(_ItsCordinator, _LoginUser))
            {
                //throw new ApplicationException("您没有管理该协调员的权限");
                BllUtility.ThrowException(BllExceptionConst._Condinator_NoAuth);
            }
        }

        private List<FBPaperItem> GetFBItem()
        {
            //List<TrainFBQuestion> question= _DalFBQues.GetFBQuestionByConditon(string.Empty, -1);
            FeedBackPaper paper = _IFeedBackPaper.GetFeedBackPaperById(_Course.CourseFeedBackPaper.FeedBackPaperId);
            if(paper==null ||paper.FBQuestions==null)
            {
                return new List<FBPaperItem>();
            }
            List<TrainFBQuestion> question = paper.FBQuestions;
            List<FBPaperItem> paperItems=new List<FBPaperItem>();
  
            foreach(TrainFBQuestion ques in question)
            {
                if (ques.FBItems.Count != 0 && ques.FBItems != null)
                {
                    FBPaperItem item = new FBPaperItem();
                    item.FBQuestion = ques.Description;
                    item.FBQueItems = GetItemString(ques.FBItems);
                    item.Worths = GetItemWorth(ques.FBItems);
                    paperItems.Add(item);
                }
            }
            return paperItems;
        }

        private static string GetItemString(List<TrainFBItem> items)
        {
            StringBuilder strItems = new StringBuilder();
            if (items != null)
            {
                int count = items.Count;
                for (int i = 0; i < count; i++)
                {
                    strItems.Append(items[i].Description);
                    if (i < count - 1) strItems.Append(",");
                }
            }
            return strItems.ToString();
        }

        private static string GetItemWorth(List<TrainFBItem> items)
        {
            StringBuilder strWorths = new StringBuilder();
            if (items != null)
            {
                int count = items.Count;
                for (int i = 0; i < count; i++)
                {
                    strWorths.Append(items[i].Worth);
                    if (i < count - 1) strWorths.Append(",");
                }
            }
            return strWorths.ToString();
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
