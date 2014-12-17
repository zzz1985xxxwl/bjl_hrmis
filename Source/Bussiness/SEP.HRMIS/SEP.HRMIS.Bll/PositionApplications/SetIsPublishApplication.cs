using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.PositionApplications
{
    public class SetIsPublishApplication: Transaction
    {
        private readonly IPositionApplicationDal _PositionApplicationDal = DalFactory.DataAccess.CreatePositionApplication();
        private readonly int _IsPublish;
        private readonly int _AppID;

        /// <summary>
        /// 
        /// </summary>
        public SetIsPublishApplication(int appID,int isPublish)
        {
            _IsPublish = isPublish;
            _AppID = appID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                _PositionApplicationDal.SetIsPublishApplication(_AppID, _IsPublish);
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }


        /// <summary>
        /// 有效性判断
        /// </summary>
        protected override void Validation()
        {
           
        }
    }
}