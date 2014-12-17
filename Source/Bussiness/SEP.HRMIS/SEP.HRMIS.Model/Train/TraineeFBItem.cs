
namespace SEP.HRMIS.Model
{
    ///<summary>
    /// 反馈问题项
    ///</summary>
    public class TraineeFBItem:FBPaperItem
    {
        private int _Grade;

        public int Grade
        {
            get { return _Grade; }
            set { _Grade = value; }
        }
    }
}
