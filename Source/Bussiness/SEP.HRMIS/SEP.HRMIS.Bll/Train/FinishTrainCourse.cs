//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: FinishTrainCourse.cs
// ������: ����
// ��������: 2008-11-13
// ����: ������ѵ�γ�
// ----------------------------------------------------------------

using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    ///<summary>
    ///</summary>
    public class FinishTrainCourse : Transaction
    {
        private static ITrain _DalTrain = DalFactory.DataAccess.CreateTrain();
        private static IEmployeeSkill _DalEmployeeSkill = DalFactory.DataAccess.CreateEmployeeSkill();
        private readonly int _CourseId;
        private Course _Course;
        private int _SkillId;

        ///<summary>
        ///</summary>
        ///<param name="courseId"></param>
        public FinishTrainCourse(int courseId)
        {
            _CourseId = courseId;
        }

        ///<summary>
        ///AddTrainCourse�Ĺ��캯����רΪ�����ṩ
        ///</summary>
        public FinishTrainCourse(int courseId, ITrain iTrain, IEmployeeSkill iEmployeeSkill)
        {
            _CourseId = courseId;
            _DalTrain = iTrain;
            _DalEmployeeSkill = iEmployeeSkill;
        }

        protected override void Validation()
        {
            _Course = _DalTrain.GetTrainCourseByPKID(_CourseId);
            if (_Course == null)
            {
                BllUtility.ThrowException(BllExceptionConst._TrainCourse_NotExist);
            }
            else switch (_Course.Status)
            {
                case TrainStatusEnum.Interrupt:
                    BllUtility.ThrowException(BllExceptionConst._TrainCourse_Interrupt);
                    break;
                case TrainStatusEnum.End:
                    BllUtility.ThrowException(BllExceptionConst._TrainCourse_End);
                    break;
            }

        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _Course.Status = TrainStatusEnum.End;
                    _DalTrain.UpdateTrainCourse(_Course);
                    List<Skill> skills = _Course.Skill;
                    List<TrainEmployeeFB> employeeFBs = _Course.TrainFBResult.TrainEmployeeFBs;
                    foreach (TrainEmployeeFB fb in employeeFBs)
                    {
                        if (fb.FBTime != null)
                        {
                            InsertEmployeeSkill(fb.Trainee.Id, skills);
                        }
                    }
                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="employeeId"></param>
        ///<param name="skills"></param>
        public void InsertEmployeeSkill(int employeeId, List<Skill> skills)
        {
            Employee employee =
                _DalEmployeeSkill.GetEmployeeSkillByAccountID(employeeId, string.Empty, -1, SkillLevelEnum.All);
            foreach (Skill skill in skills)
            {
                EmployeeSkill employeeSkillT = new EmployeeSkill(skill, SkillLevelEnum.Trained);
                _SkillId = skill.SkillID;
                //�жϴ�Ա���Ƿ��д˼���
                if (!employee.EmployeeSkills.Exists(FindEmployeeSkill))
                {
                    employee.EmployeeSkills.Add(employeeSkillT);
                }
            }
            _DalEmployeeSkill.UpdateEmployeeSkill(employee);
        }

        private bool FindEmployeeSkill(EmployeeSkill skill)
        {
            return skill.Skill.SkillID.Equals(_SkillId);
        }
    }
}
