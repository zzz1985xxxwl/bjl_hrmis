namespace TransferDatas
{
    public class TransferDataLogManager
    {
        private static ITransferDataLog _TheTransferDataLog;

        public static ITransferDataLog GetLogInstance
        {
            get
            {
                if(_TheTransferDataLog == null)
                {
                    _TheTransferDataLog = new TransferDataLog();
                }
                return _TheTransferDataLog;
            }
        }

        public static ITransferDataLog SetLogInstance
        {
            set
            {
                _TheTransferDataLog = value;
            }
        }

        public static void TryConfigLogObj()
        {
            _TheTransferDataLog = new TransferDataLog();
        }

        public static string TryConfigLogObjToString()
        {
            return Utility._Process_ConfigLogObj;
        }
    }
}