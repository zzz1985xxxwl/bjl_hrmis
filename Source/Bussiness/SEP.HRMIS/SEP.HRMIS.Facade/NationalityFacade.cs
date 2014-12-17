using System.Collections.Generic;
using SEP.HRMIS.Bll.Nationalitys;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 
    /// </summary>
    public class NationalityFacade : INationalityFacade
    {
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="nationality"></param>
        public void AddNationality(Nationality nationality)
        {
            new InsertNationality(nationality).Excute();
        }

        /// <summary>
        /// �޸Ĺ���
        /// </summary>
        /// <param name="nationality"></param>
        public void UpdateNationality(Nationality nationality)
        {
            new UpdateNationality(nationality).Excute();
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="nationality"></param>
        public void DeleteNationality(int pkid)
        {
            new DeleteNationality(pkid).Excute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public Nationality GetNationalityByPkid(int id)
        {
            return new GetNationality().GetNationalityByPkid(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="name"></param>
        public List<Nationality> GetNationalityByCondition(int pkid, string name)
        {
            return new GetNationality().GetNationalityByCondition(pkid, name);
        }
    }
}
