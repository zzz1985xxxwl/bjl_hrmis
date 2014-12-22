using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    ///<summary>
    ///</summary>
    public interface ITrainFacade
    {
        #region 问题项
        ///<summary>
        ///</summary>
        ///<param name="trainfbquestype"></param>
        void AddFBQuesType(TrainFBQuesType trainfbquestype);
        ///<summary>
        ///</summary>
        ///<param name="fbQuesType"></param>
        void UpdateFBQuesType(TrainFBQuesType fbQuesType);
        ///<summary>
        ///</summary>
        ///<param name="fbQuesType"></param>
        void DeleteFBQuesType(TrainFBQuesType fbQuesType);

        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        TrainFBQuesType GetTrainFBQuesTypeByPKID(int pkid);
        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<param name="name"></param>
        ///<returns></returns>
        List<TrainFBQuesType> GetTrainFBQuesTypeByCondition(int pkid, string name);
        #endregion

        #region 问题
        ///<summary>
        ///</summary>
        ///<param name="fbquestion"></param>
        void AddTrainFBQuestion(TrainFBQuestion fbquestion);
        ///<summary>
        ///</summary>
        ///<param name="fbquestion"></param>
        void UpdateTrainFBQuestion(TrainFBQuestion fbquestion);
        ///<summary>
        ///</summary>
        ///<param name="fbquestion"></param>
        void DeleteTrainFBQuestion(TrainFBQuestion fbquestion);
        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        TrainFBQuestion GetFBQuestionByID(int pkid);
        ///<summary>
        ///</summary>
        ///<param name="name"></param>
        ///<param name="type"></param>
        ///<returns></returns>
        List<TrainFBQuestion> GetFBQuestionByConditon(string name, int type);
        #endregion

        #region 培训及反馈
        ///<summary>
        ///</summary>
        ///<param name="course"></param>
        ///<param name="skills"></param>
        ///<param name="employees"></param>
        ///<param name="loginUser"></param>
        void AddTrainCourse(Course course, List<Skill> skills, List<Account> employees, Account loginUser);
        ///<summary>
        ///</summary>
        ///<param name="course"></param>
        ///<param name="skills"></param>
        ///<param name="employees"></param>
        ///<param name="loginUser"></param>
        void UpdateTrainCourse(Course course, List<Skill> skills, List<Account> employees, Account loginUser);
        ///<summary>
        ///</summary>
        ///<param name="courseId"></param>
        void DeleteTrainCourse(int courseId);
        ///<summary>
        ///</summary>
        ///<param name="courseId"></param>
        ///<param name="employeeFB"></param>
        void AddCourseFeedBack(int courseId, TrainEmployeeFB employeeFB);
        ///<summary>
        ///</summary>
        ///<param name="courseId"></param>
        void FinishTrainCourse(int courseId);

        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        Course GetTrainCourseByPKID(int pkid);
        ///<summary>
        ///</summary>
        ///<param name="courseName"></param>
        ///<param name="coordinator"></param>
        ///<param name="scope"></param>
        ///<param name="status"></param>
        ///<param name="trainer"></param>
        ///<param name="trainee"></param>
        ///<param name="skillName"></param>
        ///<param name="expectedTimeFrom"></param>
        ///<param name="expectedTimeTo"></param>
        ///<param name="actualTimeFrom"></param>
        ///<param name="actualTimeTo"></param>
        ///<param name="expctedCostFrom"></param>
        ///<param name="expectedCostTo"></param>
        ///<param name="actaulCostFrom"></param>
        ///<param name="actualCostTo"></param>
        ///<param name="loginUser"></param>
        ///<returns></returns>
        List<Course> GetCourseByConditon(string courseName, string coordinator, int scope, int status, string trainer, string trainee,
            string skillName, DateTime expectedTimeFrom, DateTime expectedTimeTo, DateTime actualTimeFrom, DateTime actualTimeTo,
            decimal expctedCostFrom, decimal expectedCostTo, decimal actaulCostFrom, decimal actualCostTo, Account loginUser);
        ///<summary>
        ///</summary>
        ///<param name="traineeAccontID"></param>
        ///<param name="courseId"></param>
        ///<param name="courseName"></param>
        ///<param name="traineeName"></param>
        ///<param name="status"></param>
        ///<param name="startTime"></param>
        ///<param name="endTime"></param>
        ///<returns></returns>
        List<Course> GetCourseTrainneeByCondition(int traineeAccontID, int courseId, string courseName, string traineeName,
                                              int status, DateTime? startTime, DateTime? endTime);
        ///<summary>
        ///</summary>
        ///<param name="traineeAccontID"></param>
        ///<param name="courseId"></param>
        ///<param name="courseName"></param>
        ///<param name="traineeName"></param>
        ///<param name="status"></param>
        ///<param name="startTime"></param>
        ///<param name="endTime"></param>
        ///<param name="loginUser"></param>
        ///<returns></returns>
        List<TrainEmployeeFB> GetTrainEmployeeFB(int traineeAccontID, int courseId, string courseName, string traineeName,
                                               int status, DateTime? startTime, DateTime? endTime, Account loginUser,bool isMyFB);
        ///<summary>
        ///</summary>
        ///<param name="courseId"></param>
        ///<param name="employeeAccountId"></param>
        ///<returns></returns>
        List<TraineeFBItem> GetTraineeFBItems(int courseId, int employeeAccountId);
        /// <summary>
        /// 导出培训反馈结果
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="reportTemplateLocation"></param>
        /// <returns></returns>
        string ExportFeedBackResult(int courseId, string reportTemplateLocation);

        #endregion
    }
}
