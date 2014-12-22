using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IFacede
{
    ///<summary>
    ///</summary>
    public interface IFeedBackPaperFacade
    {
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="feedBackPaper"></param>
        void AddAFeedBackPaper(FeedBackPaper feedBackPaper);
        /// <summary>
        /// �޸ķ�����
        /// </summary>
        /// <param name="feedBackPaper"></param>
        void UpdateFeedBackPaper(FeedBackPaper feedBackPaper);
        /// <summary>
        /// ɾ��������
        /// </summary>
        /// <param name="pkid"></param>
        void DeleteFeedBackPaper(int pkid);

        /// <summary>
        /// ����ID��÷�������Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FeedBackPaper GetFeedBackPaperById(int id);

        /// <summary>
        /// ��ѯ������
        /// </summary>
        /// <param name="paperName"></param>
        /// <returns></returns>
        List<FeedBackPaper> GetFeedBackPaperByPaperName(string paperName);
    }
}
