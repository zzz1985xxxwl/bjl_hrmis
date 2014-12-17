using System;
using ComService.IBizLayer;
using ComService.ServiceModels;
using System.ComponentModel;

namespace ComService.ServiceContracts.Impls
{
    public class ContactServices : IContactServices
    {
        private readonly IContact _IContact = BizFactory.ContactBiz;

        #region IContactServices ��Ա

        /// <summary>
        /// ����ϵͳ��ʶ���û�ID��ȡ����ͨѶ¼�б�
        ///     ������ϵ������
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʶ</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="companyId"></param>
        /// <returns>����ͨѶ¼</returns>
        [Description("��ȡ��������ͨѶ¼")]
        public Contact LoadAllContact(string sysNo, int userId, int companyId)
        {
            return LoadAllContact(sysNo, userId, companyId, true);
        }

        /// <summary>
        /// ����ϵͳ��ʶ���û�ID��ȡ����ͨѶ¼
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʶ</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="companyId"></param>
        /// <param name="isExternal">�Ƿ��ȡ����</param>
        /// <returns>����ͨѶ¼</returns>
        [Description("��ȡ��������ͨѶ¼")]
        public Contact LoadAllContact(string sysNo, int userId, int companyId, bool isExternal)
        {
            return _IContact.LoadAllContact(sysNo, userId, companyId, isExternal);
        }

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
        public Contact LoadSomeContactByName(string sysNo, int userId, int companyId, string name)
        {
            return LoadSomeContactByName(sysNo, userId, companyId, name, true);
        }

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
        public Contact LoadSomeContactByName(string sysNo, int userId, int companyId, string name, bool isExternal)
        {
            if (!String.IsNullOrEmpty(name))
                name = name.Trim();

            return _IContact.LoadSomeContactByName(sysNo, userId, companyId, name, isExternal);
        }

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
        public Contact LoadSomeContactByIndexKey(string sysNo, int userId, int companyId, string indexKey)
        {
            return LoadSomeContactByIndexKey(sysNo, userId, companyId, indexKey, true);
        }

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
        public Contact LoadSomeContactByIndexKey(string sysNo, int userId, int companyId, string indexKey, bool isExternal)
        {
            if (!String.IsNullOrEmpty(indexKey))
                indexKey = indexKey.Trim().ToUpper();

            return _IContact.LoadSomeContactByIndexKey(sysNo, userId, companyId, indexKey, isExternal);
        }

        /// <summary>
        /// ������ϵ��
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʶ</param>
        /// <param name="userId">�û�ID</param>
        /// <param name="companyId"></param>
        /// <param name="linkman">��ϵ��</param>
        [Description("������ϵ��")]
        public void SaveLinkman(string sysNo, int userId, int companyId, Linkman linkman)
        {
            _IContact.SaveLinkman(sysNo, userId,companyId, linkman);
        }

        /// <summary>
        /// ������ϵ��IDɾ����ϵ��
        /// </summary>
        /// <param name="linkmanId">��ϵ��ID</param>
        [Description("ɾ����ϵ��")]
        public void DeleteLinkman(Guid linkmanId)
        {
            _IContact.DeleteLinkman(linkmanId);
        }

        /// <summary>
        /// ɾ���û�ͨѶ¼
        /// </summary>
        /// <param name="sysNo">ϵͳ��ʶ</param>
        /// <param name="userId">�û�ID</param>
        [Description("ɾ��������ϵ��")]
        public void DeleteAllLinkman(string sysNo, int userId)
        {
            _IContact.DeleteAllLinkman(sysNo, userId);
        }

        #endregion

        public bool TestConnection()
        {
            return true;
        }
    }
}
