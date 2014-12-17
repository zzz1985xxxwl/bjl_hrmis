//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SysErrorUtility.cs
// Creater:  Xue.wenlong
// Date:  2009-09-29
// Resume:
// ----------------------------------------------------------------


namespace SEP.HRMIS.Model.SystemError
{
    /// <summary>
    /// </summary>
    public class SysErrorUtility
    {
        /// <summary>
        /// 
        /// </summary>
        public static string DoorCardNoError(string cardno)
        {
            return ErrorString(cardno,  ErrorType.DoorCardNoError.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string DutyCalssError(string dutyCalss)
        {
            return ErrorString(dutyCalss,  ErrorType.DutyCalssError.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string DiyLeaveRequestError(string leaveRequest)
        {
            return ErrorString(leaveRequest,  ErrorType.DiyLeaveRequestError.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string DiyOutError(string outapplication)
        {
            return ErrorString(outapplication,  ErrorType.DiyOutError.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string DiyOverWorkError(string overWork)
        {
            return ErrorString(overWork,  ErrorType.DiyOverWorkError.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string DiyAssessError(string assess)
        {
            return ErrorString(assess,  ErrorType.DiyAssessError.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string DiyHRPrincipalError(string HRPrincipal)
        {
            return ErrorString(HRPrincipal,  ErrorType.DiyHRPrincipalError.Name);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public static string DiyReimburseError(string reimburse)
        //{
        //    return ErrorString(reimburse,  ErrorType.DiyReimburseError.Name);
        //}

        /// <summary>
        /// 
        /// </summary>
        public static string DiyTraineeApplicationError(string traineeApplication)
        {
            return ErrorString(traineeApplication,  ErrorType.DiyTraineeApplicationError.Name);
        }

        private static string ErrorString(string judge,  string type)
        {
            if (string.IsNullOrEmpty(judge))
            {
                return string.Format("ц╩сп{0}", type);
            }
            return "";
        }
    }
}