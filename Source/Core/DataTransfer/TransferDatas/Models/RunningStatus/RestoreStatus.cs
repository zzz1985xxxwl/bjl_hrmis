namespace TransferDatas
{
    public class RestoreStatus : RunningStatus
    {
        private const string _StatusName = "从系统更新数据";

        protected override string DefineNameOfOperation()
        {
            return _StatusName;
        }
    }
}