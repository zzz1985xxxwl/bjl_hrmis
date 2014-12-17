namespace SEP.Bll
{
    public abstract class Transaction
    {
        protected abstract void Validation();
        protected abstract void ExcuteSelf();
        public void Excute()
        {
            Validation();
            ExcuteSelf();
        }
    }
}