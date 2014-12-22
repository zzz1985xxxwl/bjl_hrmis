using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.Nationalitys
{
    /// <summary>
    /// 
    /// </summary>
    public class GetNationality
    {
        private readonly IParameter _IParameter = new ParameterDal();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public Nationality GetNationalityByPkid(int pkid)
        {
            return _IParameter.GetNationalityByPKID(pkid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Nationality> GetNationalityByCondition(int pkid, string name)
        {
            return _IParameter.GetNationalityByCondition(pkid, name);
        }
    }
}
