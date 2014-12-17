using System.Configuration;
using System.Diagnostics;

namespace SEP.AutoRemindServer
{
    public enum EventType { Error, Information, Warning }
    /// <summary>
    /// 
    /// </summary>
    public class TLineEventLog
    {
        // ������־
        static private readonly EventLog m_eventLog = new EventLog();
        // Դ���ƣ��������ļ��ж�ȡ
        private static string m_strEventSource = ConfigurationManager.AppSettings["EventSource"];
        // ��־���ƣ��������ļ��ж�ȡ
        static private string m_strEventLog = ConfigurationManager.AppSettings["EventLog"];

        // ������Ϣд����־
        static private readonly EventLogTraceListener cTraceListener =
             new EventLogTraceListener(m_eventLog);

        // ȱʡ���캯���������ļ���ȡʧ��ʱ���ṩĬ�ϵ�Դ���ƺ���־����
        public TLineEventLog()
        {
            if (m_strEventSource.Length == 0)
                m_strEventSource = "mySource";

            if (m_strEventLog.Length == 0)
                m_strEventLog = "myLog";

            m_eventLog.Source = m_strEventSource;
            m_eventLog.Log = m_strEventLog;
        }

        // ���캯�����ṩԴ���ƺ���־���ơ�
        public TLineEventLog(string strEventSource, string strEventLog)
        {
            m_strEventSource = strEventSource;
            m_strEventLog = strEventLog;
            m_eventLog.Source = m_strEventSource;
            m_eventLog.Log = m_strEventLog;
        }

        /// <summary>
        /// д�¼���־
        /// </summary>
        /// <param name="strMessage">�¼�����</param>
        /// <param name="eventType">�¼���𣬴��󡢾��������Ϣ</param>
        public void DoWriteEventLog(string strMessage, EventType eventType)
        {
            if (!EventLog.SourceExists(m_strEventSource))
            {
                EventLog.CreateEventSource(m_strEventSource, m_strEventLog);
            }

            EventLogEntryType entryType;
            switch (eventType)
            {
                case EventType.Error:
                    entryType = EventLogEntryType.Error;
                    break;
                case EventType.Information:
                    entryType = EventLogEntryType.Information;
                    break;
                case EventType.Warning:
                    entryType = EventLogEntryType.Warning;
                    break;
                default:
                    entryType = EventLogEntryType.Information;
                    break;
            }
            m_eventLog.WriteEntry(strMessage, entryType);
        }

        /// <summary>
        /// д�¼���־��Ĭ��Ϊ��Ϣ
        /// </summary>
        /// <param name="strMessage">�¼�����</param>
        static public void DoWriteEventLog(string strMessage)
        {
            if (!EventLog.SourceExists(m_strEventSource))
            {
                EventLog.CreateEventSource(m_strEventSource, m_strEventLog);
            }
            m_eventLog.WriteEntry(strMessage);
        }

        /// <summary>
        /// ������Ϣд����־
        /// </summary>
        public static void OpenTrace()
        {
            if (cTraceListener != null)
            {
                if (!Trace.Listeners.Contains(cTraceListener))
                {
                    Trace.Listeners.Add(cTraceListener);
                }
            }
        }

        /// <summary>
        /// ������Ϣ��д����־
        /// </summary>
        public static void CloseTrace()
        {
            if (Trace.Listeners.IndexOf(cTraceListener) >= 0)
            {
                Trace.Listeners.Remove(cTraceListener);
            }
        }
    }

}
