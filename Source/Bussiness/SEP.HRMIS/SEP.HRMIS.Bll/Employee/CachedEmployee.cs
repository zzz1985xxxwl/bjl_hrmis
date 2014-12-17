//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetEmployeeFromCache.cs
// 创建者: 倪豪
// 创建日期: 2008-11-20
// 概述: 通过访问EmployeeCache得到员工信息，缓存中的每一个信息精确到
//        private int _EmployeeID;
//        private string _Name;
//        private string _Email;
//        private string _Email2;
//        private EmployeeTypeEnum _EmployeeType;
//        private Position _Position;
//        private Department _Department;
//        private AccountsFront _AccountsFront;
//        private EmployeeDetails _EmployeeDetails;
//        以上的每一个字段，除此之外的信息并未加载，也并未保证
//        注意，在缓存中的获取的对象无法完成更新，即这些对象都
//        工作在查询器状态
// ----------------------------------------------------------------
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 员工缓存
    /// </summary>
    public class CachedEmployee
    {
        /// <summary>
        /// 通过电话号码获取员工对象，在该类中，只要满足数据精确性，就可以构建不同的查询方法
        /// </summary>
        public static Employee GetEmployeeByPhoneNumber(string phoneNumber)
        {
            foreach (Employee detailedEmployee in EmployeeCache.GetAllEmployeeBasicInfoFromCache)
            {
                if (detailedEmployee.EmployeeDetails != null)
                {
                    if (detailedEmployee.Account.MobileNum == phoneNumber)
                    {
                        return detailedEmployee;
                    }
                }
            }
            return null;
        }
    }
}