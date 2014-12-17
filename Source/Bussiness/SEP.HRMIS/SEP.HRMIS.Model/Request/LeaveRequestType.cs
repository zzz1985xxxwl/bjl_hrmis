using System.Collections.Generic;

namespace SEP.HRMIS.Model.Request
{
    /// <summary>
    /// �������
    /// </summary>
    public class LeaveRequestType
    {
        private int _LeaveRequestTypeID;
        private string _Name;
        private string _Description;
        private LegalHoliday _includeLegalHoliday;
        private RestDay _includeRestDay;
        private decimal _LeastHour;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="includeLegalHoliday"></param>
        /// <param name="includeRestDay"></param>
        /// <param name="leastHour"></param>
        public LeaveRequestType(string name, string description,
            LegalHoliday includeLegalHoliday,RestDay includeRestDay,
                                decimal leastHour)
        {
            _Name = name;
            _includeLegalHoliday = includeLegalHoliday;
            _includeRestDay = includeRestDay;
            _Description = description;
            _LeastHour = leastHour;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="includeLegalHoliday"></param>
        /// <param name="includeRestDay"></param>
        /// <param name="leastHour"></param>
        public LeaveRequestType(int id, string name, string description,
             LegalHoliday includeLegalHoliday, RestDay includeRestDay,
                                decimal leastHour) :
            this(name, description, includeLegalHoliday, includeRestDay, leastHour)
        {
            _LeaveRequestTypeID = id;
        }

        /// <summary>
        /// �������ID
        /// </summary>
        public int LeaveRequestTypeID
        {
            get { return _LeaveRequestTypeID; }
            set { _LeaveRequestTypeID = value; }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        /// <summary>
        /// �Ƿ������Ϣ��
        /// </summary>
        public RestDay IncludeRestDay
        {
            get { return _includeRestDay; }
            set { _includeRestDay = value; }
        }

        /// <summary>
        /// �Ƿ������������
        /// </summary>
        public LegalHoliday IncludeLegalHoliday
        {
            get { return _includeLegalHoliday; }
            set { _includeLegalHoliday = value; }
        }

        /// <summary>
        /// ��ٵ���ССʱ�������ڵ���0�����֣�������0.5�ı���
        /// </summary>
        public decimal LeastHour
        {
            get { return _LeastHour; }
            set { _LeastHour = value; }
        }
        /// <summary>
        /// ����ID���б��в���LeaveRequestType
        /// </summary>
        /// <param name="leaveRequestTypes"></param>
        /// <param name="leaveRequestTypeID"></param>
        /// <returns></returns>
        public static LeaveRequestType FindLeaveRequestType(List<LeaveRequestType> leaveRequestTypes, int leaveRequestTypeID)
        {
            foreach (LeaveRequestType leaveRequestType in leaveRequestTypes)
            {
                if (leaveRequestType.LeaveRequestTypeID == leaveRequestTypeID)
                    return leaveRequestType;
            }
            return null;
        }
        /// <summary>
        /// ��leaverequest�������򣬸���ID����
        /// </summary>
        /// <param name="leaveRequestTypeList"></param>
        public static void OrderLeaveRequestType(List<LeaveRequestType> leaveRequestTypeList)
        {
            if (leaveRequestTypeList.Count == 0)
            {
                return;
            }
            for (int i = 0; i < leaveRequestTypeList.Count - 1; i++)
            {
                for (int j = i + 1; j < leaveRequestTypeList.Count; j++)
                {
                    if (leaveRequestTypeList[j].LeaveRequestTypeID < leaveRequestTypeList[i].LeaveRequestTypeID)
                    {
                        LeaveRequestType leaveRequestTypeTmp = leaveRequestTypeList[i];
                        leaveRequestTypeList[i] = leaveRequestTypeList[j];
                        leaveRequestTypeList[j] = leaveRequestTypeTmp;
                    }
                }
            }
        }
    }

    /// <summary>
    /// �Ƿ������������
    /// </summary>
    public enum LegalHoliday
    {
        /// <summary>
        /// ��������������
        /// </summary>
        UnInclude = 0,

        /// <summary>
        /// ������������
        /// </summary>
        Include = 1
    }
    /// <summary>
    /// �Ƿ������Ϣ��
    /// </summary>
    public enum RestDay
    {
        /// <summary>
        /// ��������Ϣ��
        /// </summary>
        UnInclude = 0,

        /// <summary>
        /// ������Ϣ��
        /// </summary>
        Include = 1
    }
}