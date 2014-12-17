using System;
using ComService.IBizLayer;
using ComService.ServiceModels;
using System.ComponentModel;

namespace ComService.ServiceContracts.Impls
{
    public class ContactServices : IContactServices
    {
        private readonly IContact _IContact = BizFactory.ContactBiz;

        #region IContactServices 成员

        /// <summary>
        /// 根据系统标识和用户ID获取个人通讯录列表
        ///     加载联系人详情
        /// </summary>
        /// <param name="sysNo">系统标识</param>
        /// <param name="userId">用户ID</param>
        /// <param name="companyId"></param>
        /// <returns>个人通讯录</returns>
        [Description("获取个人所有通讯录")]
        public Contact LoadAllContact(string sysNo, int userId, int companyId)
        {
            return LoadAllContact(sysNo, userId, companyId, true);
        }

        /// <summary>
        /// 根据系统标识和用户ID获取个人通讯录
        /// </summary>
        /// <param name="sysNo">系统标识</param>
        /// <param name="userId">用户ID</param>
        /// <param name="companyId"></param>
        /// <param name="isExternal">是否获取详情</param>
        /// <returns>个人通讯录</returns>
        [Description("获取个人所有通讯录")]
        public Contact LoadAllContact(string sysNo, int userId, int companyId, bool isExternal)
        {
            return _IContact.LoadAllContact(sysNo, userId, companyId, isExternal);
        }

        /// <summary>
        /// 根据联系人姓名模糊查询通讯录列表
        ///     加载联系人详情
        /// </summary>
        /// <param name="sysNo">系统标识</param>
        /// <param name="userId">用户ID</param>
        /// <param name="companyId"></param>
        /// <param name="name">联系人姓名</param>
        /// <returns>个人通讯录</returns>
        [Description("根据联系人姓名模糊查询通讯录")]
        public Contact LoadSomeContactByName(string sysNo, int userId, int companyId, string name)
        {
            return LoadSomeContactByName(sysNo, userId, companyId, name, true);
        }

        /// <summary>
        /// 根据联系人姓名模糊查询通讯录
        /// </summary>
        /// <param name="sysNo">系统标识</param>
        /// <param name="userId">用户ID</param>
        /// <param name="companyId"></param>
        /// <param name="name">联系人姓名</param>
        /// <param name="isExternal">是否获取详情</param>
        /// <returns>个人通讯录</returns>
        [Description("根据联系人姓名模糊查询通讯录")]
        public Contact LoadSomeContactByName(string sysNo, int userId, int companyId, string name, bool isExternal)
        {
            if (!String.IsNullOrEmpty(name))
                name = name.Trim();

            return _IContact.LoadSomeContactByName(sysNo, userId, companyId, name, isExternal);
        }

        /// <summary>
        /// 根据联系人索引键准确查询通讯录列表
        ///     加载联系人详情
        /// </summary>
        /// <param name="sysNo">系统标识</param>
        /// <param name="userId">用户ID</param>
        /// <param name="companyId"></param>
        /// <param name="indexKey">联系人索引键</param>
        /// <returns>通讯录列表</returns>
        [Description("根据联系人索引键准确查询通讯录")]
        public Contact LoadSomeContactByIndexKey(string sysNo, int userId, int companyId, string indexKey)
        {
            return LoadSomeContactByIndexKey(sysNo, userId, companyId, indexKey, true);
        }

        /// <summary>
        /// 根据联系人索引键准确查询通讯录
        /// </summary>
        /// <param name="sysNo">系统标识</param>
        /// <param name="userId">用户ID</param>
        /// <param name="companyId"></param>
        /// <param name="indexKey">联系人索引键</param>
        /// <param name="isExternal">是否获取详情</param>
        /// <returns>通讯录(</returns>
        [Description("根据联系人索引键准确查询通讯录")]
        public Contact LoadSomeContactByIndexKey(string sysNo, int userId, int companyId, string indexKey, bool isExternal)
        {
            if (!String.IsNullOrEmpty(indexKey))
                indexKey = indexKey.Trim().ToUpper();

            return _IContact.LoadSomeContactByIndexKey(sysNo, userId, companyId, indexKey, isExternal);
        }

        /// <summary>
        /// 保存联系人
        /// </summary>
        /// <param name="sysNo">系统标识</param>
        /// <param name="userId">用户ID</param>
        /// <param name="companyId"></param>
        /// <param name="linkman">联系人</param>
        [Description("保存联系人")]
        public void SaveLinkman(string sysNo, int userId, int companyId, Linkman linkman)
        {
            _IContact.SaveLinkman(sysNo, userId,companyId, linkman);
        }

        /// <summary>
        /// 根据联系人ID删除联系人
        /// </summary>
        /// <param name="linkmanId">联系人ID</param>
        [Description("删除联系人")]
        public void DeleteLinkman(Guid linkmanId)
        {
            _IContact.DeleteLinkman(linkmanId);
        }

        /// <summary>
        /// 删除用户通讯录
        /// </summary>
        /// <param name="sysNo">系统标识</param>
        /// <param name="userId">用户ID</param>
        [Description("删除所有联系人")]
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
