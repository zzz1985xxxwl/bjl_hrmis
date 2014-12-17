using System;
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.Model
{
    [Serializable]
    public class WorkTask
    {
        private int _pkid;
        private Account _account = new Account();
        private string _title = string.Empty;
        private string _content = string.Empty;
        private WTPriority _priority = WTPriority.All;
        private WTStatus _status = WTStatus.All;
        private DateTime _startDate = DateTime.Today;
        private DateTime _endDate = DateTime.Today;
        private string _description = string.Empty;
        private string _remark = string.Empty;
        List<Account> _Responsibles = new List<Account>();
        List<WorkTaskQA> _WorkTaskQAs = new List<WorkTaskQA>();

        public int Pkid
        {
            get
            {
                return _pkid;
            }
            set
            {
                _pkid = value;
            }
        }

        public Account Account
        {
            get
            {
                return _account;
            }
            set
            {
                _account = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        public WTPriority Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
            }
        }

        public WTStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public string Remark
        {
            get
            {
                return _remark;
            }
            set
            {
                _remark = value;
            }
        }

        public List<Account> Responsibles
        {
            get
            {
                return _Responsibles;
            }
            set
            {
                _Responsibles = value;
            }
        }

        public List<WorkTaskQA> WorkTaskQAs
        {
            get
            {
                return _WorkTaskQAs;
            }
            set
            {
                _WorkTaskQAs = value;
            }
        }
    }
}