namespace TransferDatas
{
    public class RestoreStatus : RunningStatus
    {
        private const string _StatusName = "��ϵͳ��������";

        protected override string DefineNameOfOperation()
        {
            return _StatusName;
        }
    }
}