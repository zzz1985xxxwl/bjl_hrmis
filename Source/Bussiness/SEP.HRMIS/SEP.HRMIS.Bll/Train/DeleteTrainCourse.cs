//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteTrainCourse.cs
// 创建者: 刘丹
// 创建日期: 2008-11-12
// 概述: 删除课程
// ----------------------------------------------------------------


using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    public class DeleteTrainCourse : Transaction
    {
        private static ITrain _DalTrain = new TrainDal();
        private readonly int _CourseId;

        public DeleteTrainCourse(int courseId)
        {
            _CourseId = courseId;
        }

        ///<summary>
        ///AddTrainCourse的构造函数，专为测试提供
        ///</summary>
        public DeleteTrainCourse(int courseId, ITrain iTrain)
        {
            _CourseId = courseId;
            _DalTrain = iTrain;
        }

        protected override void Validation()
        {
            Course course = _DalTrain.GetTrainCourseByPKID(_CourseId);
            if (course == null)
            {
                BllUtility.ThrowException(BllExceptionConst._TrainCourse_NotExist);
            }
            else if (course.Status == TrainStatusEnum.End)
            {
                BllUtility.ThrowException(BllExceptionConst._TrainCourse_End);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _DalTrain.DeleteTrainCourse(_CourseId); ;
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}
