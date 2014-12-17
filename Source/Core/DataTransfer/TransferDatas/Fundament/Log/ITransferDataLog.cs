namespace TransferDatas
{
    public interface ITransferDataLog
    {
        void AddInfo(string info);
        void AddWarn(string warn);
        void AddError(string error);
    }
}