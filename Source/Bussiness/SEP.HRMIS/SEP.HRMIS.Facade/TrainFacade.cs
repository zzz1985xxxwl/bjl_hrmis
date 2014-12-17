using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.Train;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
   ///<summary>
   ///</summary>
    public class TrainFacade : ITrainFacade
    {
        public void AddFBQuesType(TrainFBQuesType trainfbquestype)
        {
            AddFBQuesType addFBQuesType = new AddFBQuesType(trainfbquestype);
            addFBQuesType.Excute();
        }

        public void UpdateFBQuesType(TrainFBQuesType fbQuesType)
        {
            UpdateFBQuesType updateFBQuesType = new UpdateFBQuesType(fbQuesType);
            updateFBQuesType.Excute();
        }

        public void DeleteFBQuesType(TrainFBQuesType fbQuesType)
        {
            DeleteFBQuesType deleteFBQuesType = new DeleteFBQuesType(fbQuesType);
            deleteFBQuesType.Excute();
        }

        public TrainFBQuesType GetTrainFBQuesTypeByPKID(int pkid)
        {
            GetTrainFBQuesType getTrainFBQuesType = new GetTrainFBQuesType();
            return getTrainFBQuesType.GetTrainFBQuesTypeByPKID(pkid);
        }

        public List<TrainFBQuesType> GetTrainFBQuesTypeByCondition(int pkid, string name)
        {
            GetTrainFBQuesType getTrainFBQuesType = new GetTrainFBQuesType();
            return getTrainFBQuesType.GetTrainFBQuesTypeByCondition(pkid, name);
        }

        public void AddTrainFBQuestion(TrainFBQuestion fbquestion)
        {
            AddTrainFBQuestion addTrainFBQuestion = new AddTrainFBQuestion(fbquestion);
            addTrainFBQuestion.Excute();
        }

        public void UpdateTrainFBQuestion(TrainFBQuestion fbquestion)
        {
            UpdateTrainFBQuestion updateTrainFBQuestion = new UpdateTrainFBQuestion(fbquestion);
            updateTrainFBQuestion.Excute();
        }

        public void DeleteTrainFBQuestion(TrainFBQuestion fbquestion)
        {
            DeleteTrainFBQuestion deleteTrainFBQuestion = new DeleteTrainFBQuestion(fbquestion);
            deleteTrainFBQuestion.Excute();
        }

        public TrainFBQuestion GetFBQuestionByID(int pkid)
        {
            GetTrainFBQuestion getTrainFBQuestion = new GetTrainFBQuestion();
            return getTrainFBQuestion.GetFBQuestionByID(pkid);
        }

        public List<TrainFBQuestion> GetFBQuestionByConditon(string name, int type)
        {
            GetTrainFBQuestion getTrainFBQuestion = new GetTrainFBQuestion();
            return getTrainFBQuestion.GetFBQuestionByConditon(name, type);
        }

        public void AddTrainCourse(Course course, List<Skill> skills, List<Account> employees, Account loginUser)
        {
            AddTrainCourse addTrainCourse = new AddTrainCourse(course, skills, employees, loginUser);
            addTrainCourse.Excute();
        }

        public void UpdateTrainCourse(Course course, List<Skill> skills, List<Account> employees, Account loginUser)
        {
            UpdateTrainCourse updateTrainCourse = new UpdateTrainCourse(course, skills, employees, loginUser);
            updateTrainCourse.Excute();
        }

        public void DeleteTrainCourse(int courseId)
        {
            DeleteTrainCourse deleteTrainCourse = new DeleteTrainCourse(courseId);
            deleteTrainCourse.Excute();
        }

        public void AddCourseFeedBack(int courseId, TrainEmployeeFB employeeFB)
        {
            AddCourseFeedBack addCourseFeedBack = new AddCourseFeedBack(courseId, employeeFB);
            addCourseFeedBack.Excute();
        }

        public void FinishTrainCourse(int courseId)
        {
            FinishTrainCourse finishTrainCourse = new FinishTrainCourse(courseId);
            finishTrainCourse.Excute();
        }

        public Course GetTrainCourseByPKID(int pkid)
        {
            GetTrainCourse getTrainCourse = new GetTrainCourse();
            return getTrainCourse.GetTrainCourseByPKID(pkid);
        }

        public List<Course> GetCourseByConditon(string courseName, string coordinator, int scope, int status,
            string trainer, string trainee, string skillName, DateTime expectedTimeFrom, DateTime expectedTimeTo,
            DateTime actualTimeFrom, DateTime actualTimeTo, decimal expctedCostFrom, decimal expectedCostTo,
            decimal actaulCostFrom, decimal actualCostTo, Account loginUser)
        {
            GetTrainCourse getTrainCourse = new GetTrainCourse();
            return getTrainCourse.GetCourseByConditon(courseName, coordinator, scope, status, trainer, trainee, skillName,
                                                      expectedTimeFrom,
                                                      expectedTimeTo, actualTimeFrom, actualTimeTo, expctedCostFrom,
                                                      expectedCostTo, actaulCostFrom, actualCostTo, loginUser);
        }

        public List<Course> GetCourseTrainneeByCondition(int traineeAccontID, int courseId, string courseName,
            string traineeName, int status, DateTime? startTime, DateTime? endTime)
        {
            GetTrainCourse getTrainCourse = new GetTrainCourse();
            return getTrainCourse.GetCourseTrainneeByCondition(traineeAccontID, courseId, courseName, traineeName, status,
                                                               startTime, endTime);
        }

        public List<TrainEmployeeFB> GetTrainEmployeeFB(int traineeAccountID, int courseId, string courseName, string traineeName,
            int status, DateTime? startTime, DateTime? endTime, Account loginUser, bool isMyFB)
        {
            GetTrainCourse getTrainCourse = new GetTrainCourse();
            return getTrainCourse.GetTrainEmployeeFB(traineeAccountID, courseId, courseName, traineeName, status, startTime,
                                                     endTime, loginUser, isMyFB);
        }

        public List<TraineeFBItem> GetTraineeFBItems(int courseId, int employeeAccountId)
        {
            GetTrainCourse getTrainCourse = new GetTrainCourse();
            return getTrainCourse.GetTraineeFBItems(courseId, employeeAccountId);
        }
        public string ExportFeedBackResult(int courseId, string reportTemplateLocation)
        {
            return new ExportFeedBackResult(courseId, reportTemplateLocation).Excute();
        }
    }
}
