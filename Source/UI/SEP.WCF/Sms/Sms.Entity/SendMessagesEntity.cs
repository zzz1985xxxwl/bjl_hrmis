using System;

namespace Sms.Entity
{
    public class SendMessagesEntity
    {
        public int PKID { get; set; }
        public int SendStatusEnum { get; set; }
        public int SystemSmsId { get; set; }
        public string SendToNumber { get; set; }
        public string SystemNumber { get; set; }
        public string Content { get; set; }
        public int TriedCount { get; set; }
        public DateTime LastestSendTime { get; set; }
        public string HrmisId { get; set; }
    }
}