using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 
    /// </summary>
    public interface INationalityFacade
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nationality"></param>
        void AddNationality(Nationality nationality);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nationality"></param>
        void UpdateNationality(Nationality nationality);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void DeleteNationality(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Nationality GetNationalityByPkid(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        List<Nationality> GetNationalityByCondition(int pkid, string name);
    }
}
