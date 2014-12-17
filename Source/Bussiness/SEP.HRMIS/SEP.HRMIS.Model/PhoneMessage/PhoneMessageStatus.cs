

namespace SEP.HRMIS.Model.PhoneMessage
{
    /// <summary>
    /// 
    /// </summary>
    public enum PhoneMessageStatus
    {
        /// <summary>
        /// all
        /// </summary>
        All=-1,
        /// <summary>
        /// 待发送
        /// </summary>
         ToBeSent=0,   
        /// <summary>
         /// 待处理
        /// </summary>
         ToBeConfirm=1, 
        /// <summary>
         /// 处理结束
        /// </summary>
         End=2       
    }
}
