//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CourseValidation.cs
// 创建者: ZZ
// 创建日期: 2008-11-13
// 概述:培训课程界面信息验证
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class CourseValidation
    {
        private readonly ICourseView _ItsView;

        public CourseValidation(ICourseView itsView)
        {
            _ItsView = itsView;
        }
        public bool Vaildate()
        {
            return Vaildation();
        }

        public bool VaildationUpdate()
        {
            return Vaildation() && ActualHourValidate() && ActualCostValidate();
        }

        public bool Vaildation()
        {
            bool courseName = CouseNameValidate();
            bool place = PlaceValidate();
            bool coordinator = CoordinatorValidate();
            bool trainer = TrainerValidate();
            bool skills = SkillsValidate();
            bool employees = EmployeesValidate();
            bool expectHour = ExpectHourValidate();
            bool expectCost = ExpectCostValidate();
            bool expectST = ExpectSTValidate();
            bool expectET = ExpectETValidate();
            bool actualST = ActualSTValidate();
            bool actualET = ActualETValidate();
            bool expectSTAndExpectET = ExpectSTAndExpectETValidate();
            bool actualSTAndActualET = ActualSTAndActualETValidate();
            bool actualHourInit = ActualHourInitValidate();
            bool actualCostInite = ActualCostIniteValidate();
            return
                courseName && place && coordinator && trainer && skills && expectHour && expectCost &&
                employees && expectST && expectET && actualST && actualET && expectSTAndExpectET && actualSTAndActualET
                && actualHourInit && actualCostInite;

        }

        private bool CouseNameValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.CourseName.Trim()))
            {
                _ItsView.CourseNameMsg = CourseUtility._IsEmpty;
                return false;
            }
            _ItsView.CourseNameMsg = string.Empty;
            return true;
        }

        private bool PlaceValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.Place.Trim()))
            {
                _ItsView.PlaceMsg = CourseUtility._IsEmpty;
                return false;
            }
            _ItsView.PlaceMsg = string.Empty;
            return true;
        }

        private bool CoordinatorValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.Coordinator.Trim()))
            {
                _ItsView.CoordinatorMsg = CourseUtility._IsEmpty;
                return false;
            }
            _ItsView.CoordinatorMsg = string.Empty;
            return true;
        }
        private bool TrainerValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.Trainer.Trim()))
            {
                _ItsView.TrainersMsg = CourseUtility._IsEmpty;
                return false;
            }
            _ItsView.TrainersMsg = string.Empty;
            return true;
        }
        private bool SkillsValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.ChoosedSkills.Trim()))
            {
                _ItsView.SkillsMsg = CourseUtility._IsEmpty;
                return false;
            }
            _ItsView.SkillsMsg = string.Empty;
            return true;
        }

        private bool EmployeesValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.ChoosedEmployees.Trim()))
            {
                _ItsView.EmployeeMsg = CourseUtility._IsEmpty;
                return false;
            }
            _ItsView.EmployeeMsg = string.Empty;
            return true;
        }

        private bool ExpectHourValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.ExpectHour.Trim()))
            {
                _ItsView.ExpectHour = "0";
            }
            decimal expectHour;
            if (!decimal.TryParse(_ItsView.ExpectHour, out expectHour))
            {
                _ItsView.ExpectHourMsg = CourseUtility._FieldWrongFormat;
                return false;
            }
            if (expectHour <= 0)
            {
                _ItsView.ExpectHourMsg = CourseUtility._ExpectHourError;
                return false;
            }
            _ItsView.ExpectHourMsg = string.Empty;
            return true;
        }

        private bool ExpectCostValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.ExpectCost.Trim()))
            {
                _ItsView.ExpectCost = "0";
            }
            decimal expectCost;
            if (!decimal.TryParse(_ItsView.ExpectCost, out expectCost))
            {
                _ItsView.ExpectCostMsg = CourseUtility._FieldWrongFormat;
                return false;
            }
            if (expectCost <= 0)
            {
                _ItsView.ExpectCostMsg = CourseUtility._ExpectCostError;
                return false;
            }
            _ItsView.ExpectCostMsg = string.Empty;
            return true;
        }

        private bool ExpectSTValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.ExpectST.Trim()))
            {
                _ItsView.ExpectSTMsg = CourseUtility._IsEmpty;
                return false;
            }
            DateTime expectST;
            if (!DateTime.TryParse(_ItsView.ExpectST, out expectST))
            {
                _ItsView.ExpectSTMsg = CourseUtility._FieldWrongFormat;
                return false;
            }
            _ItsView.ExpectSTMsg = string.Empty;

            return true;
        }
        private bool ExpectETValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.ExpectET.Trim()))
            {
                _ItsView.ExpectETMsg = CourseUtility._IsEmpty;
                return false;
            }
            DateTime expectET;
            if (!DateTime.TryParse(_ItsView.ExpectET, out expectET))
            {
                _ItsView.ExpectETMsg = CourseUtility._FieldWrongFormat;
                return false;
            }

            _ItsView.ExpectETMsg = string.Empty;
            return true;
        }

        private bool ActualSTValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.ActualST.Trim()))
            {
                _ItsView.ActualSTMsg = string.Empty;
                if (ExpectSTValidate())
                {
                    _ItsView.ActualST = _ItsView.ExpectST;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            DateTime actualST;
            if (!DateTime.TryParse(_ItsView.ActualST, out actualST))
            {
                _ItsView.ActualSTMsg = CourseUtility._FieldWrongFormat;
                return false;
            }
            _ItsView.ActualSTMsg = string.Empty;
            return true;

        }

        private bool ActualETValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.ActualET.Trim()))
            {
                _ItsView.ActualETMsg = string.Empty;
                if (ExpectETValidate())
                {
                    _ItsView.ActualET = _ItsView.ExpectET;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            DateTime actualET;
            if (!DateTime.TryParse(_ItsView.ActualET, out actualET))
            {
                _ItsView.ActualETMsg = CourseUtility._FieldWrongFormat;
                return false;
            }
            _ItsView.ActualETMsg = string.Empty;
            return true;
        }

        private bool ExpectSTAndExpectETValidate()
        {
            if (ExpectSTValidate() && ExpectETValidate())
            {
                if (DateTime.Compare(Convert.ToDateTime(_ItsView.ExpectST), Convert.ToDateTime(_ItsView.ExpectET)) > 0)
                {
                    _ItsView.ExpectETMsg = CourseUtility._StartEndDateError;
                    return false;
                }
                else
                {
                    _ItsView.ExpectETMsg = string.Empty;
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private bool ActualSTAndActualETValidate()
        {
            if (ActualSTValidate() && ActualETValidate())
            {
                if (DateTime.Compare(Convert.ToDateTime(_ItsView.ActualST), Convert.ToDateTime(_ItsView.ActualET)) > 0)
                {
                    _ItsView.ActualETMsg = CourseUtility._StartEndDateError;
                    return false;
                }
                else
                {
                    _ItsView.ActualETMsg = string.Empty;
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private bool ActualHourInitValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.ActualHour.Trim()))
            {
                _ItsView.ActualHour = "0";
            }

            decimal actualHour;
            if (!decimal.TryParse(_ItsView.ActualHour, out actualHour))
            {
                _ItsView.ActualHourMsg = CourseUtility._FieldWrongFormat;
                return false;
            }
            _ItsView.ActualHourMsg = string.Empty;
            return true;
        }

        private bool ActualCostIniteValidate()
        {
            if (string.IsNullOrEmpty(_ItsView.ActualCost.Trim()))
            {
                _ItsView.ActualCost = "0";
            }
            decimal actualCost;
            if (!decimal.TryParse(_ItsView.ActualCost, out actualCost))
            {
                _ItsView.ActualCostMsg = CourseUtility._FieldWrongFormat;
                return false;
            }
            _ItsView.ActualCostMsg = string.Empty;
            return true;
        }

        #region 修改结束课程时,成本和课时验证
        private bool ActualHourValidate()
        {
            if (Convert.ToDecimal(_ItsView.ActualHour) <= 0)
            {
                _ItsView.ActualHourMsg = CourseUtility._ActualHourError;
            }
            _ItsView.ActualHourMsg = string.Empty;
            return true;
        }


        private bool ActualCostValidate()
        {
            if (Convert.ToDecimal(_ItsView.ActualCost) <= 0)
            {
                _ItsView.ActualHourMsg = CourseUtility._ActualCostError;
            }
            _ItsView.ActualCostMsg = string.Empty;
            return true;
        }
        #endregion
    }
}
