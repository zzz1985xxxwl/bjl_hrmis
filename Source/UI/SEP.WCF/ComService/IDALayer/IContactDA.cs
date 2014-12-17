using System;
using ComService.ServiceModels;

namespace ComService.IDALayer
{
    public interface IContactDA
    {
        #region Operation

        /// <summary>
        /// ������ϵ��(����ϸ��Ϣ),companyId add by liudan
        /// </summary>
        /// <param name="sysNo">ϵͳID</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="companyId"></param>
        /// <param name="linkman">��ϵ����Ϣ</param>
        void AddLinkman(string sysNo, int userId,int companyId, Linkman linkman);

        /// <summary>
        /// �޸���ϵ����Ϣ(����ϸ��Ϣ)
        /// </summary>
        void UpdateLinkman(Linkman linkman);

        /// <summary>
        /// ɾ����ϵ��(����ϸ��Ϣ)
        /// </summary>
        /// <param name="linkmanId"></param>
        void DeleteLinkman(Guid linkmanId);

        /// <summary>
        /// ������ϵ������
        /// </summary>
        /// <param name="linkmanId">��ϵ��ID</param>
        /// <param name="linkmanDetail">��ϵ������</param>
        void AddLinkmanDetail(Guid linkmanId, LinkmanDetail linkmanDetail);

        /// <summary>
        /// �޸���ϵ������
        /// </summary>
        /// <param name="linkmanDetail">��ϵ������</param>
        void UpdateLinkmanDetail(LinkmanDetail linkmanDetail);

        /// <summary>
        /// ɾ����ϵ������
        /// </summary>
        /// <param name="linkmanDetailId">��ϵ������ID</param>
        void DeleteLinkmanDetail(Guid linkmanDetailId);

        /// <summary>
        /// ɾ���û�ͨѶ¼
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʾ</param>
        /// <param name="userId">�û�ID</param>
        void DeleteContact(string sysNo, int userId);

        #endregion

        #region Select

        /// <summary>
        /// ��ȡ�û�������ϵ��,companyId add by liudan
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʾ</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="companyId">��˾id</param>
        /// <param name="isExternal">�Ƿ������ϵ������</param>
        Contact GetAllLinkmans(string sysNo, int userId,int companyId, bool isExternal);

        /// <summary>
        /// ����ϵ������ģ����ѯ�û���ϵ��
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʾ</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="name">��ϵ������</param>
        /// <param name="companyId">��˾id</param>
        /// <param name="isExternal">�Ƿ������ϵ������</param>
        Contact GetLinkmansByName(string sysNo, int userId, string name,int companyId, bool isExternal);

        /// <summary>
        /// ����ϵ����������ѯ�û���ϵ��
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʾ</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="companyId"></param>
        /// <param name="indexKey">��ϵ��������</param>
        /// <param name="isExternal">�Ƿ������ϵ������</param>
        Contact GetAllLinkmansByIndexKey(string sysNo, int userId,int companyId, string indexKey, bool isExternal);

        /// <summary>
        /// ������ϵ��ID��ȡ��ϵ������
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʾ</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="companyId"></param>
        /// <param name="linkmanId">��ϵ��ID</param>
        Contact GetLinkman(string sysNo, int userId, int companyId, Guid linkmanId);

        #endregion
    }
}
