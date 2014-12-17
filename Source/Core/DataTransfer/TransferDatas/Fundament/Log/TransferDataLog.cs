using System;
using System.IO;
using log4net;

namespace TransferDatas
{
    public class TransferDataLog : ITransferDataLog
    {
        private const string InfoLoggerName = "transferDataLog";
        private const string ErrorLoggerName = "transferDataLog.Errors";

        public TransferDataLog()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure(new FileInfo(StaticConfigTable.Log4NetConfigPath));
            }
            catch(Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_LogConfig_NotExits, e.Message));
            }
        }

        public void AddInfo(string info)
        {
            info += Environment.NewLine;
            ILog logger = LogManager.GetLogger(InfoLoggerName);
            if (logger.IsInfoEnabled)
            {
                logger.Info(info);
            }
        }

        public void AddWarn(string warn)
        {
            warn += Environment.NewLine;
            ILog logger = LogManager.GetLogger(InfoLoggerName);
            if (logger.IsWarnEnabled)
            {
                logger.Warn(warn);
            }
        }

        public void AddError(string error)
        {
            error += Environment.NewLine;
            ILog logger = LogManager.GetLogger(ErrorLoggerName);
            logger.Error(error);
        }
    }
}