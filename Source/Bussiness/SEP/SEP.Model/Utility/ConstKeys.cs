
using System;
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.Model
{
    //note 移入到Performance
    ///// <summary>
    ///// Session标识符
    ///// </summary>
    //public class SessionKeys
    //{
    //    public const string LOGININFO   = "LoginInfo";
    //    public const string SEPAUTHTREE = "SEP_AuthTree";
    //    public const string SELECTEDAUTHTREEINDEX = "SelectedIndex";
    //}

    /// <summary>
    /// 消息常量
    /// </summary>
    public class MessageKeys
    {
        public const string _NormalError = "未知错误！";
        public const string _DbError = "数据库访问错误！";
        public const string _NoAuth = "无该操作权限！";

        #region Account

        public const string _Account_IsNot_Exist="当前帐号不存在！";
        public const string _Account_Not_Exist = "登录名不存在！";
        public const string _Account_Invalid = "账号已失效！";
        public const string _Account_Password_Wrong = "密码错误！";
        public const string _Account_UsbKey_Wrong = "UsbKey错误！";
        public const string _Account_Not_Repeat = "登录名不能重复！";
        public const string _OldPassword_Wrong = "旧密码不正确！";

        public const string _Employee_Name_Repeat = "员工姓名不能重复！";

        public const string _UsbKey_Not_Exist = "请插入UsbKey身份认证！";
        public const string _UsbKey_Not_Repeat = "请确保插入一个UsbKey身份认证！";

        public const string _Account_IsValidateUsbKey_NoUsbKey = "UsbKey没有生成，请生成UsbKey后，再开启UsbKey身份认证！";

        public const string _Account_ElectronIdiograph_NoUsbKey = "增加电子签名请先设置UsbKey！";
        #endregion

        #region Bulletin

        /// <summary>
        /// 附件标题重复
        /// </summary>
        public const string _Appendix_Title_Repeat = "附件标题重复";
        /// <summary>
        /// 公告标题重复
        /// </summary>
        public const string _Bulletin_Title_Repeat = "公告标题重复";
        /// <summary>
        /// 该公告不存在
        /// </summary>
        public const string _Bulletin_Not_Exist = "该公告不存在";
        /// <summary>
        /// 附件不存在
        /// </summary>
        public const string _Appendix_Not_Exist = "附件不存在";
        /// <summary>
        /// 公告标题不能为空
        /// </summary>
        public const string _Bulletin_Title_Null = "公告标题不能为空";
        /// <summary>
        /// 请检查附件标题是否为空或大于50个字符
        /// </summary>
        public const string _Appendix_Title_Null_Or_Big_Then_Fifty = "请检查附件标题是否为空或大于50个字符";
        /// <summary>
        /// 公告标题不能超过50个字符
        /// </summary>
        public const string _Bulletin_Title_Big_Then_Fifty = "公告标题不能超过50个字符";

        #endregion

        #region CompanyRegulations

        public const string _CompanyRegulations_Title_Null = "标题不能为空！";
        public const string _CompanyReguAppendix_FileName_Null = "附件标题不能为空！";
        public const string _CompanyReguAppendix_Directory_Null = "附件路径不能为空！";

        #endregion

        #region Department
        /// <summary>
        /// 部门名称不能重复
        /// </summary>
        public const string _Department_Name_Repeat = "部门名称不能重复！";
        /// <summary>
        /// 部门主管不能为空
        /// </summary>
        public const string _Department_Leader_NotEmpty = "部门主管不能为空！";
        /// <summary>
        /// 不存在该部门主管
        /// </summary>
        public const string _Department_Leader_NotExist = "该部门主管不存在！";
        /// <summary>
        /// 上级部门不能为空
        /// </summary>
        public const string _Department_ParentDepartment_CannotBeNull = "上级部门不能为空！";
        /// <summary>
        /// 上级部门不存在
        /// </summary>
        public const string _Department_ParentDepartment_NotExist = "上级部门不存在！";
        /// <summary>
        /// 该部门不存在
        /// </summary>
        public const string _Department_NotExist = "该部门不存在！";
        /// <summary>
        /// 根结点的上级部门不能被修改
        /// </summary>
        public const string _Department_RootDepartment_CannotBeChanged = "根结点的上级部门不能被修改！";
        /// <summary>
        /// 还有员工属于该部门
        /// </summary>
        public const string _Department_HasEmployee = "还有员工属于该部门！";
        /// <summary>
        /// 该部门下存在子部门
        /// </summary>
        public const string _Department_HasChildren = "该部门下存在子部门！";

        #endregion

        #region Employess

        public const string _Employee_NotExist = "该员工不存在！";

        #endregion

        #region Goal
        /// <summary>
        /// 公司目标标题重复
        /// </summary>
        public const string _CompanyGoal_Title_Repeat = "公司目标标题重复";
        /// <summary>
        /// 个人目标标题重复
        /// </summary>
        public const string _PersonalGoal_Title_Repeat = "个人目标标题重复";
        /// <summary>
        /// 团队目标标题重复
        /// </summary>
        public const string _DepartmentGoal_Title_Repeat = "团队目标标题重复";
        /// <summary>
        /// 该目标不存在
        /// </summary>
        public const string _Goal_NotExist = "该目标不存在";
        /// <summary>
        /// 该公司目标不存在
        /// </summary>
        public const string _CompanyGoal_NotExist = "该公司目标不存在";
        /// <summary>
        /// 该个人目标不存在
        /// </summary>
        public const string _PersonalGoal_NotExist = "该个人目标不存在";
        /// <summary>
        /// 该团队目标不存在
        /// </summary>
        public const string _DepartmentGoal_NotExist = "该团队目标不存在";
        /// <summary>
        /// 目标标题不能为空
        /// </summary>
        public const string _Goal_Title_Null = "目标标题不能为空";
        /// <summary>
        /// 目标标题不能超过50个字符
        /// </summary>
        public const string _Goal_Title_More_Then_Fifty = "目标标题不能超过50个字符";


        #endregion

        #region Position
        public const string _Position_AddPageTitle = "新增职位";
        public const string _Position_AddOperationType = "Add";

        public const string _Position_UpdatePageTitle = "修改职位";
        public const string _Position_UpdateOperationType = "Update";

        public const string _Position_DeletePageTitle = "删除职位";
        public const string _Position_DeleteOperationType = "Delete";

        public const string _Position_DetailPageTitle = "查看职位";
        public const string _Position_DetailOperationType = "Detail";

        public const string _Position_NameIsEmpty = "不能为空！";
        public const string _Position_GradeIsEmpty = "不能为空！";

        public const string _Position_ErrorNullType = "没有任何职位！";

        public const string _Position_Not_Exist = "职位不存在！";
        public const string _Position_Name_Repeat = "职位名称不能重复！";
        public const string _Position_HasEmployee = "存在该职位的员工！";

        public const string _PositionGrade_NameIsEmpty = "职位等级不能为空！";
        public const string _PositionGrade_Name_NotExist = "职位等级不存在！";
        public const string _PositionGrade_Name_Repeat = "职位等级名称不能重复！";
        public const string _PositionGrade_HasPosition = "存在该职位等级的职位！";

        public const string _PositionNature_Name_NotExist = "岗位性质不存在！";
        public const string _PositionNature_Name_Repeat = "岗位性质名称不能重复！";
        public const string _PositionNature_HasPosition = "存在该岗位性质的职位！";

        #endregion
        #region WorkTask

        public const string _WorkTask_IsNot_Exist = "该工作计划不存在！";

        public const string _WorkTaskQA_IsNot_Exist = "该留言不存在！";
        #endregion

        #region

        public static ApplicationException AppException(string msg)
        {
            return new ApplicationException(msg);
        }

        #endregion
    }


    /// <summary>
    /// 权限值
    /// </summary>
    public class Powers
    {
        #region 1 用户管理

        public const int A01 = 1;
        /// <summary>
        /// 新增用户
        /// </summary>
        public const int A101 = 101;

        /// <summary>
        /// 查询用户
        /// </summary>
        public const int A102 = 102;

        /// <summary>
        /// 分配权限
        /// </summary>
        public const int A103 = 103;

        #endregion

        #region 2 组织结构管理

        public const int A02 = 2;
        /// <summary>
        /// 部门管理
        /// </summary>
        public const int A201 = 201;

        /// <summary>
        /// 职位管理
        /// </summary>
        public const int A202 = 202;

        /// <summary>
        /// 职位等级管理
        /// </summary>
        public const int A203 = 203;

        #endregion

        #region 3 公告管理

        public const int A03 = 3;
        /// <summary>
        /// 新增公告
        /// </summary>
        public const int A301 = 301;

        /// <summary>
        /// 查询公告
        /// </summary>
        public const int A302 = 302;

        #endregion

        #region 4 公司目标管理

        public const int A04 = 4;
        /// <summary>
        /// 新增公司目标
        /// </summary>
        public const int A401 = 401;

        /// <summary>
        /// 查询公司目标
        /// </summary>
        public const int A402 = 402;

        #endregion

        #region 5 企业文化

        public const int A05 = 5;
        /// <summary>
        /// 设置公司规章
        /// </summary>
        public const int A501 = 501;
        /// <summary>
        /// 设置欢迎信
        /// </summary>
        public const int A502 = 502;
        /// <summary>
        /// 设置特殊时间
        /// </summary>
        public const int A503 = 503;

        #endregion

        #region 6 增值服务

        public const int A06 = 6;
        /// <summary>
        /// 查看短信中心
        /// </summary>
        public const int A601 = 601;

        #endregion

        #region 权限验证

        public static bool HasAuth(List<Auth> auths, AuthType type, int authId)
        {
            foreach (Auth auth in auths)
            {
                if (auth.Type != type)
                    continue;

                if (auth.IsExistAuth(authId))
                    return true;
            }

            return false;
        }

        #endregion
    }
}
