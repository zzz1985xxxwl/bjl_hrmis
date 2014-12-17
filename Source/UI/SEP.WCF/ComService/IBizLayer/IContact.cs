using System;
using ComService.ServiceModels;
using System.ComponentModel;

namespace ComService.IBizLayer
{
    public interface IContact
    {
        /// <summary>
        /// 根据系统标识和用户ID获取个人通讯录列表
        ///     加载联系人详情
        /// </summary>
        /// <param name="sysNo">系统标识</param>
        /// <param name="userId">用户ID</param>
        /// <param name="companyId"></param>
        /// <returns>个人通讯录</returns>
        [Description("获取个人所有通讯录")]
        Contact LoadAllContact(string sysNo, int userId, int companyId);

        /// <summary>
        /// 根据系统标识和用户ID获取个人通讯录
        /// </summary>
        /// <param name="sysNo">系统标识</param>
        /// <param name="userId">用户ID</param>
        /// <param name="companyId"></param>
        /// <param name="isExternal">是否获取详情</param>
        /// <returns>个人通讯录</returns>
        [Description("获取个人所有通讯录")]
        Contact LoadAllContact(string sysNo, int userId, int companyId, bool isExternal);

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
        Contact LoadSomeContactByName(string sysNo, int userId, int companyId, string name);

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
        Contact LoadSomeContactByName(string sysNo, int userId, int companyId, string name, bool isExternal);

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
        Contact LoadSomeContactByIndexKey(string sysNo, int userId, int companyId, string indexKey);

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
        Contact LoadSomeContactByIndexKey(string sysNo, int userId, int companyId, string indexKey, bool isExternal);

        /// <summary>
        /// 保存联系人
        /// </summary>
        /// <param name="sysNo">系统标识</param>
        /// <param name="userId">用户ID</param>
        /// <param name="companyId"></param>
        /// <param name="linkman">联系人</param>
        [Description("保存联系人")]
        void SaveLinkman(string sysNo, int userId, int companyId, Linkman linkman);

        /// <summary>
        /// 根据联系人ID删除联系人
        /// </summary>
        /// <param name="linkmanId">联系人ID</param>
        [Description("删除联系人")]
        void DeleteLinkman(Guid linkmanId);

        /// <summary>
        /// 删除用户通讯录
        /// </summary>
        /// <param name="sysNo">系统标识</param>
        /// <param name="userId">用户ID</param>
        [Description("删除所有联系人")]
        void DeleteAllLinkman(string sysNo, int userId);
    }
}
