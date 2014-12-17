using System;
using ComService.ServiceModels;
using System.ComponentModel;

namespace ComService.IBizLayer
{
    public interface IContact
    {
        /// <summary>
        /// ����ϵͳ��ʶ���û�ID��ȡ����ͨѶ¼�б�
        ///     ������ϵ������
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʶ</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="companyId"></param>
        /// <returns>����ͨѶ¼</returns>
        [Description("��ȡ��������ͨѶ¼")]
        Contact LoadAllContact(string sysNo, int userId, int companyId);

        /// <summary>
        /// ����ϵͳ��ʶ���û�ID��ȡ����ͨѶ¼
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʶ</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="companyId"></param>
        /// <param name="isExternal">�Ƿ��ȡ����</param>
        /// <returns>����ͨѶ¼</returns>
        [Description("��ȡ��������ͨѶ¼")]
        Contact LoadAllContact(string sysNo, int userId, int companyId, bool isExternal);

        /// <summary>
        /// ������ϵ������ģ����ѯͨѶ¼�б�
        ///     ������ϵ������
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʶ</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="companyId"></param>
        /// <param name="name">��ϵ������</param>
        /// <returns>����ͨѶ¼</returns>
        [Description("������ϵ������ģ����ѯͨѶ¼")]
        Contact LoadSomeContactByName(string sysNo, int userId, int companyId, string name);

        /// <summary>
        /// ������ϵ������ģ����ѯͨѶ¼
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʶ</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="companyId"></param>
        /// <param name="name">��ϵ������</param>
        /// <param name="isExternal">�Ƿ��ȡ����</param>
        /// <returns>����ͨѶ¼</returns>
        [Description("������ϵ������ģ����ѯͨѶ¼")]
        Contact LoadSomeContactByName(string sysNo, int userId, int companyId, string name, bool isExternal);

        /// <summary>
        /// ������ϵ��������׼ȷ��ѯͨѶ¼�б�
        ///     ������ϵ������
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʶ</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="companyId"></param>
        /// <param name="indexKey">��ϵ��������</param>
        /// <returns>ͨѶ¼�б�</returns>
        [Description("������ϵ��������׼ȷ��ѯͨѶ¼")]
        Contact LoadSomeContactByIndexKey(string sysNo, int userId, int companyId, string indexKey);

        /// <summary>
        /// ������ϵ��������׼ȷ��ѯͨѶ¼
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʶ</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="companyId"></param>
        /// <param name="indexKey">��ϵ��������</param>
        /// <param name="isExternal">�Ƿ��ȡ����</param>
        /// <returns>ͨѶ¼(</returns>
        [Description("������ϵ��������׼ȷ��ѯͨѶ¼")]
        Contact LoadSomeContactByIndexKey(string sysNo, int userId, int companyId, string indexKey, bool isExternal);

        /// <summary>
        /// ������ϵ��
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʶ</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="companyId"></param>
        /// <param name="linkman">��ϵ��</param>
        [Description("������ϵ��")]
        void SaveLinkman(string sysNo, int userId, int companyId, Linkman linkman);

        /// <summary>
        /// ������ϵ��IDɾ����ϵ��
        /// </summary>
        /// <param name="linkmanId">��ϵ��ID</param>
        [Description("ɾ����ϵ��")]
        void DeleteLinkman(Guid linkmanId);

        /// <summary>
        /// ɾ���û�ͨѶ¼
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʶ</param>
        /// <param name="userId">�û�ID</param>
        [Description("ɾ��������ϵ��")]
        void DeleteAllLinkman(string sysNo, int userId);
    }
}
