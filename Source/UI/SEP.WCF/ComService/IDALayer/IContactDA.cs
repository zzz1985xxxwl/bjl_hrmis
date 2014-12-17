using System;
using ComService.ServiceModels;

namespace ComService.IDALayer
{
    public interface IContactDA
    {
        #region Operation

        /// <summary>
        /// 新增联系人(含详细信息),companyId add by liudan
        /// </summary>
        /// <param name="sysNo">系统ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="companyId"></param>
        /// <param name="linkman">联系人信息</param>
        void AddLinkman(string sysNo, int userId,int companyId, Linkman linkman);

        /// <summary>
        /// 修改联系人信息(含详细信息)
        /// </summary>
        void UpdateLinkman(Linkman linkman);

        /// <summary>
        /// 删除联系人(含详细信息)
        /// </summary>
        /// <param name="linkmanId"></param>
        void DeleteLinkman(Guid linkmanId);

        /// <summary>
        /// 新增联系人详情
        /// </summary>
        /// <param name="linkmanId">联系人ID</param>
        /// <param name="linkmanDetail">联系人详情</param>
        void AddLinkmanDetail(Guid linkmanId, LinkmanDetail linkmanDetail);

        /// <summary>
        /// 修改联系人详情
        /// </summary>
        /// <param name="linkmanDetail">联系人详情</param>
        void UpdateLinkmanDetail(LinkmanDetail linkmanDetail);

        /// <summary>
        /// 删除联系人详情
        /// </summary>
        /// <param name="linkmanDetailId">联系人详情ID</param>
        void DeleteLinkmanDetail(Guid linkmanDetailId);

        /// <summary>
        /// 删除用户通讯录
        /// </summary>
        /// <param name="sysNo">系统标示</param>
        /// <param name="userId">用户ID</param>
        void DeleteContact(string sysNo, int userId);

        #endregion

        #region Select

        /// <summary>
        /// 获取用户所有联系人,companyId add by liudan
        /// </summary>
        /// <param name="sysNo">系统标示</param>
        /// <param name="userId">用户ID</param>
        /// <param name="companyId">公司id</param>
        /// <param name="isExternal">是否加载联系人详情</param>
        Contact GetAllLinkmans(string sysNo, int userId,int companyId, bool isExternal);

        /// <summary>
        /// 按联系人姓名模糊查询用户联系人
        /// </summary>
        /// <param name="sysNo">系统标示</param>
        /// <param name="userId">用户ID</param>
        /// <param name="name">联系人姓名</param>
        /// <param name="companyId">公司id</param>
        /// <param name="isExternal">是否加载联系人详情</param>
        Contact GetLinkmansByName(string sysNo, int userId, string name,int companyId, bool isExternal);

        /// <summary>
        /// 按联系人索引键查询用户联系人
        /// </summary>
        /// <param name="sysNo">系统标示</param>
        /// <param name="userId">用户ID</param>
        /// <param name="companyId"></param>
        /// <param name="indexKey">联系人索引键</param>
        /// <param name="isExternal">是否加载联系人详情</param>
        Contact GetAllLinkmansByIndexKey(string sysNo, int userId,int companyId, string indexKey, bool isExternal);

        /// <summary>
        /// 根据联系人ID获取联系人详情
        /// </summary>
        /// <param name="sysNo">系统标示</param>
        /// <param name="userId">用户ID</param>
        /// <param name="companyId"></param>
        /// <param name="linkmanId">联系人ID</param>
        Contact GetLinkman(string sysNo, int userId, int companyId, Guid linkmanId);

        #endregion
    }
}
