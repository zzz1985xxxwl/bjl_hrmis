namespace Logs
{
    public class GetLogInstance
    {
        private static TLineEventLog _TheTLineEventLog;

        public static TLineEventLog GetInstance
        {
            get
            {
                if(_TheTLineEventLog == null)
                {
                    _TheTLineEventLog = new TLineEventLog("���ŷ�����","���ŷ�����");
                }
                return _TheTLineEventLog;
            }
        }
    }
}