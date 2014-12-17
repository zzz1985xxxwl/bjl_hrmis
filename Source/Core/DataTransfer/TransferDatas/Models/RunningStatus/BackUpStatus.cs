namespace TransferDatas
{
    public class BackUpStatus : RunningStatus
    {
        private string _SuccessFileName;
        private string _SuccessFullFileName;
        private const string _StatusName = "��ϵͳ��������";


        /// <summary>
        /// �ɹ����ݳ������ļ�����
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
        /// �ɹ����ݳ�����������·����
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