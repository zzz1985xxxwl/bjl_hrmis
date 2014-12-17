using System;

namespace Sms.Entity
{
    public class ReceiveMessagesEntity
    {
        public int PKID { get; set; }
        public int BoradCasted { get; set; }

        /// <summary>
        ///     短信在短信机器中的编号，一般无用
        /// </summary>
        public int Id { get; set; }

        public string TheNumber { get; set; }
        public string Content { get; set; }
        public DateTime ReceivedTime { get; set; }
        /// <summary>
        ///  指示该信息是否是干净的：即只存在于内存中，已经不在Sim卡里了
        /// </summary>
        public int IsCleanMessage { get; set; }
    }
}