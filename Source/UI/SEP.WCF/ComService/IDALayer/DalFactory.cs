using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace ComService.IDALayer
{
    /// <summary>
    /// 创建数据访问实例
    /// </summary>
    public class DalFactory
    {
        private static IContactDA _contactDA;
        public static IContactDA ContactDA
        {
            get
            {
                return _contactDA;
            }
        }

        static DalFactory()
        {
            string config = ConfigurationManager.AppSettings["IContactDA"];
            string[] assemblyKeys = config.Split(';');
            _contactDA = Assembly.Load(assemblyKeys[0]).CreateInstance(assemblyKeys[1]) as IContactDA;
        }
    }
}
