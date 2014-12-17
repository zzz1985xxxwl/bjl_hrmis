namespace SEP.HRMIS.Bll
{
    public interface ITranscationProxy
    {
        void BeforeTranscation();
        void AfterTranscation();
    }
}