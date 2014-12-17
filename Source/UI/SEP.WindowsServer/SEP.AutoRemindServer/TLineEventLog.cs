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
        // 任务日志
        static private readonly EventLog m_eventLog = new EventLog();
        // 源名称，从配置文件中读取
        private static string m_strEventSource = ConfigurationManager.AppSettings["EventSource"];
        // 日志名称，从配置文件中读取
        static private string m_strEventLog = ConfigurationManager.AppSettings["EventLog"];

        // 调试信息写入日志
        static private readonly EventLogTraceListener cTraceListener =
             new EventLogTraceListener(m_eventLog);

        // 缺省构造函数。配置文件读取失败时，提供默认的源名称和日志名称
        public TLineEventLog()
        {
            if (m_strEventSource.Length == 0)
                m_strEventSource = "mySource";

            if (m_strEventLog.Length == 0)
                m_strEventLog = "myLog";

            m_eventLog.Source = m_strEventSource;
            m_eventLog.Log = m_strEventLog;
        }

        // 构造函数。提供源名称和日志名称。
        public TLineEventLog(string strEventSource, string strEventLog)
        {
            m_strEventSource = strEventSource;
            m_strEventLog = strEventLog;
            m_eventLog.Source = m_strEventSource;
            m_eventLog.Log = m_strEventLog;
        }

        /// <summary>
        /// 写事件日志
        /// </summary>
        /// <param name="strMessage">事件内容</param>
        /// <param name="eventType">事件类别，错误、警告或者消息</param>
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
        /// 写事件日志，默认为消息
        /// </summary>
        /// <param name="strMessage">事件内容</param>
        static public void DoWriteEventLog(string strMessage)
        {
            if (!EventLog.SourceExists(m_strEventSource))
            {
                EventLog.CreateEventSource(m_strEventSource, m_strEventLog);
            }
            m_eventLog.WriteEntry(strMessage);
        }

        /// <summary>
        /// 调试信息写入日志
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
        /// 调试信息不写入日志
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
