//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ITrain.cs
// 创建者: 刘丹
// 创建日期: 2008-11-09
// 概述: 培训接口
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    ///<summary>
    /// ITrain的接口
    ///</summary>
    public interface ITrain
    {
        ///<summary>
        /// 新增一个培训课程
        ///</summary>
        ///<param name="obj"></param>
        void InsertTrainCourse(Course obj);
        ///<summary>
        /// 修改一个培训课程
        ///</summary>
        ///<param name="obj"></param>
        void UpdateTrainCourse(Course obj);
        ///<summary>
        /// 删除一个培训课程
        ///</summary>
        ///<param name="courseId"></param>
        void DeleteTrainCourse(int courseId);

        ///<summary>
        /// 由ID获得一个培训课程
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        Course GetTrainCourseByPKID(int pkid);
        ///<summary>
        /// 根据条件获得培训课程
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
        ///<returns></returns>
        List<Course> GetCourseByConditon(string courseName, string coordinator, int scope, int status, string trainer, string trainee, 
            string skillName, DateTime expectedTimeFrom, DateTime expectedTimeTo, DateTime actualTimeFrom, DateTime actualTimeTo,
            decimal expctedCostFrom, decimal expectedCostTo,decimal actaulCostFrom, decimal actualCostTo);
       
        ///<summary>
        /// 根据条件获得培训课程
        ///</summary>
        ///<param name="traineeID"></param>
        ///<param name="courseId"></param>
        ///<param name="courseName"></param>
        ///<param name="traineeName"></param>
        ///<param name="status"></param>
        ///<param name="startTime"></param>
        ///<param name="endTime"></param>
        ///<returns></returns>
        List<Course> GetCourseTrainneeByCondition(int traineeID, int courseId, string courseName, string traineeName,
                                              int status, DateTime? startTime, DateTime? endTime);

        ///<summary>
        /// 由技能ID获得培训课程
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        int GetTrainCourseBySkillID(int pkid);

    }
}
