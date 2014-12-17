using System;
using SEP.Model.Accounts;

namespace SEP.Model
{
    [Serializable]
    public class WorkTaskQA
    {
        public WorkTaskQA()
        {
        }

        public WorkTaskQA(int id, string qAccount, string aAccount, string question, string answer, DateTime questionDate, DateTime answerDate)
        {
            _pkid = id;
            _qAccount = new Account(0, "", qAccount);
            _aAccount = new Account(0, "", aAccount);
            _question = question;
            _answer = answer;
            _questionDate = questionDate;
            _answerDate = answerDate;
        }

        private int _pkid;
        private WorkTask _workTask = new WorkTask();
        private Account _qAccount = new Account();
        private Account _aAccount = new Account();
        private string _question = string.Empty;
        private string _answer = string.Empty;
        private DateTime _questionDate = DateTime.Now;
        private DateTime _answerDate = DateTime.Now;

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

        public WorkTask WorkTask
        {
            get
            {
                return _workTask;
            }
            set
            {
                _workTask = value;
            }
        }

        public Account QAccount
        {
            get
            {
                return _qAccount;
            }
            set
            {
                _qAccount = value;
            }
        }

        public Account AAccount
        {
            get
            {
                return _aAccount;
            }
            set
            {
                _aAccount = value;
            }
        }

        public string Question
        {
            get
            {
                return _question;
            }
            set
            {
                _question = value;
            }
        }

        public string Answer
        {
            get
            {
                return _answer;
            }
            set
            {
                _answer = value;
            }
        }

        public DateTime QuestionDate
        {
            get
            {
                return _questionDate;
            }
            set
            {
                _questionDate = value;
            }
        }

        public DateTime AnswerDate
        {
            get
            {
                return _answerDate;
            }
            set
            {
                _answerDate = value;
            }
        }
    }
}
