using System.Collections.Generic;

namespace SEP.Model.Mail
{
    public class MailType:ParameterBase
    {
                public MailType(int id, string name)
            : base(id, name)
        {
        }
        public static MailType WelcomeMail = new MailType(0,"Ա����ӭ��");
        public static MailType BirthdayMail = new MailType(1, "����ף����");
        //public static MailType MarryMail = new MailType(2, "���ף����");
        //public static MailType BirthMail = new MailType(3, "��Ů����ף����");

        /// <summary>
        /// ����ID�������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MailType GetById(int id)
        {
            switch (id)
            {
                case 0:
                    return WelcomeMail;
                case 1:
                    return BirthdayMail;
                //case 2:
                //    return MarryMail;
                //case 3:
                //    return BirthMail;
                default:
                    return null;
            }
        }
        /// <summary>
        /// ������е������б�
        /// </summary>
        /// <returns></returns>
        public static List<MailType> GetAllMailType()
        {
            List<MailType> retVal = new List<MailType>();
            retVal.Add(WelcomeMail);
            retVal.Add(BirthdayMail);
            //retVal.Add(MarryMail);
            //retVal.Add(BirthMail);
            return retVal;
        }
    }
}
