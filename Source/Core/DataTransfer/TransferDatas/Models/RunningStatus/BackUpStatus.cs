namespace TransferDatas
{
    public class BackUpStatus : RunningStatus
    {
        private string _SuccessFileName;
        private string _SuccessFullFileName;
        private const string _StatusName = "主系统备份数据";


        /// <summary>
        /// 成功备份出来的文件名字
        /// </summary>
        public string SuccessFileName
        {
            get
            {
                return _SuccessFileName;
            }
            set
            {
                _SuccessFileName = value;
            }
        }

        /// <summary>
        /// 成功备份出来的完整的路径名
        /// </summary>
        public string SuccessFullFileName
        {
            get
            {
                return _SuccessFullFileName;
            }
            set
            {
                _SuccessFullFileName = value;
            }
        }

        protected override string DefineNameOfOperation()
        {
            return _StatusName;
        }
    }
}