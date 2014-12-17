using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace ComService.IBizLayer
{
    /// <summary>
    /// 创建业务实现的实例
    /// </summary>
    public class BizFactory
    {
        private static IContact _contactBiz;
        public static IContact ContactBiz
        {
            get
            {
                return _contactBiz;
            }
        }

        static BizFactory()
        {
            string config = ConfigurationManager.AppSettings["IContactBiz"];
            string[] assemblyKeys = config.Split(';');
            _contactBiz = Assembly.Load(assemblyKeys[0]).CreateInstance(assemblyKeys[1]) as IContact;
        }
    }
}
