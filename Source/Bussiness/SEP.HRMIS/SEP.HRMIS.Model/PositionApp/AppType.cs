using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.PositionApp
{
    [Serializable]
    public class AppType : ParameterBase
    {
        public AppType(int id, string name)
            : base(id, name)
        {
        }

        public static AppType All = new AppType(-1, "");
        public static AppType New = new AppType(0, "新增职位");
        public static AppType Change = new AppType(1, "变更职位");

        /// <summary>
        /// 所有的申请类型
        /// </summary>
        public static List<AppType> AllAppType
        {
            get
            {
                List<AppType> allTypes = new List<AppType>();
                allTypes.Add(All);
                allTypes.Add(New);
                allTypes.Add(Change);
                return allTypes;
            }
        }

        /// <summary>
        /// 根据ID查找AppType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AppType FindAppType(int id)
        {
            switch (id)
            {
                case 0:
                    return New;
                case 1:
                    return Change;
                default:
                    return All;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppType"></param>
        /// <returns></returns>
        public static string AppTypeDisplay(AppType AppType)
        {
            //-1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 审核中
            switch (AppType.Id)
            {
                case 0:
                    return New.Name;
                case 1:
                    return Change.Name;
                default:
                    return "";
            }
        }
    }
}
