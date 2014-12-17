using System;


namespace SEP.HRMIS.Model.EmployeeAttendance.ReadData
{
    [Serializable]
    public class DataFromAccess
    {
        private string _CardNo;
        private InOutStatusEnum _InOrOut;
        private DateTime _IOTime;

        public DataFromAccess(string cardNo, InOutStatusEnum inOrOut, DateTime iOTime)
        {
            _CardNo = cardNo;
            _InOrOut = inOrOut;
            _IOTime = iOTime;
        }

        public string CardNo
        {
            get
            {
                return _CardNo;
            }
            set
            {
                _CardNo = value;
            }
        }
        public InOutStatusEnum InOrOut
        {
            get
            {
                return _InOrOut;
            }
            set
            {
                _InOrOut = value;
            }
        }
        public DateTime IOTime
        {
            get
            {
                return _IOTime;
            }
            set
            {
                _IOTime = value;
            }
        }
    }
}
