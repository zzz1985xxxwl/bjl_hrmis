//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddCourseFeedBack.cs
// 创建者: 刘丹
// 创建日期: 2008-11-13
// 概述: 员工反馈
// ----------------------------------------------------------------

using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    public class AddCourseFeedBack:Transaction
    {
        private static ITrain _DalTrain = new TrainDal();
        private Course _Course;
        private readonly int _CourseId;
        private readonly TrainEmployeeFB _TrainEmployeeFb;

        public AddCourseFeedBack(int courseId,TrainEmployeeFB employeeFB)
        {
            _CourseId = courseId;
            _TrainEmployeeFb = employeeFB;
        }

        ///<summary>
        ///AddTrainCourse的构造函数，专为测试提供
        ///</summary>
        public AddCourseFeedBack(int courseId,TrainEmployeeFB employeeFB, ITrain iTrain)
        {
            _CourseId = courseId;
            _TrainEmployeeFb = employeeFB;
            _DalTrain = iTrain;
        }

        /// <summary>
        /// 调用下层的新增课程的方法
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                //把反馈人信息先删除
                _Course.TrainFBResult.TrainEmployeeFBs.Remove(
                    _Course.TrainFBResult.TrainEmployeeFBs.Find(FindTrainEmployeeFB));
                _Course.TrainFBResult.TrainEmployeeFBs.Add(_TrainEmployeeFb);
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DalTrain.UpdateTrainCourse(_Course);
                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        protected override void Validation()
        {
            _Course = _DalTrain.GetTrainCourseByPKID(_CourseId);
            if (_Course == null)
            {
                BllUtility.ThrowException(BllExceptionConst._TrainCourse_NotExist);
            }
            else if (_Course.Status == TrainStatusEnum.End)
            {
                BllUtility.ThrowException(BllExceptionConst._TrainCourse_End);
            }
            
        }

        private bool FindTrainEmployeeFB(TrainEmployeeFB fb)
        {
            return fb.Trainee.Id.Equals(_TrainEmployeeFb.Trainee.Id);
        }

    }
}
