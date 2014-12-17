
namespace SEP.HRMIS.Entity
{
    /// <summary>
    /// TProjectInfo的实体类
    /// </summary>
    public class ProjectInfoEntity
    {
        private int _PKID;
        /// <summary>
        /// 
        /// </summary>
        public int PKID
        {
            get
            {
                return _PKID;
            }
            set
            {
                _PKID = value;
            }
        }

        private string _ProjectName;
        /// <summary>
        /// 
        /// </summary>
        public string ProjectName
        {
            get
            {
                return _ProjectName;
            }
            set
            {
                _ProjectName = value;
            }
        }

    }
}

