//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: StaticConfigTable.cs
// 创建者: 倪豪
// 创建日期: 2009-05-6
// 概述: 数据迁移静态配置表
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace TransferDatas
{
    public class StaticConfigTable
    {
        private static string _ConnectionString;
        private static Dictionary<string, string> _TranferRule;
        private static string _TempDirectory;
        private static string _BackUpDirectory;
        //以下为默认配置，需要在运行时候设置
        private static string _DownloadFilesDirectory = Environment.CurrentDirectory + "\\DownloadFileDirectory\\";
        private static string _ConfigFilePath = Environment.CurrentDirectory + "\\TransferConfig.xml";
        private static string _ExpandDllPath = Environment.CurrentDirectory;
        private static string _UploadFileDirectory = Environment.CurrentDirectory + "\\UploadFileDirectory\\";
        private static string _Log4NetConfigPath = Environment.CurrentDirectory + "\\Log4Net.config";

        #region 属性

        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }

        /// <summary>
        /// 规则的字符串
        /// </summary>
        public static Dictionary<string, string> TranferRule
        {
            get
            {
                return _TranferRule;
            }
            set
            {
                _TranferRule = value;
            }
        }

        /// <summary>
        /// 临时目录
        /// </summary>
        public static string TempDirectory
        {
            get
            {
                return _TempDirectory;
            }
            set
            {
                _TempDirectory = value;
            }
        }

        /// <summary>
        /// 备份数据的目录
        /// </summary>
        public static string BackUpDirectory
        {
            get
            {
                return _BackUpDirectory;
            }
            set
            {
                _BackUpDirectory = value;
            }
        }

        /// <summary>
        /// 下载的路径
        /// </summary>
        public static string DownloadFilesDirectory
        {
            get
            {
                return _DownloadFilesDirectory;
            }
            set
            {
                _DownloadFilesDirectory = value;
            }
        }

        /// <summary>
        ///  获取或设置Config目录，默认放置在当前运行环境下
        /// </summary>
        public static string ConfigFilePath
        {
            get
            {
                return _ConfigFilePath;
            }
            set
            {
                _ConfigFilePath = value;
            }
        }

        /// <summary>
        /// 外部扩展类库的存放文件夹地址
        /// </summary>
        public static string ExpandDllPath
        {
            get
            {
                return _ExpandDllPath;
            }
            set
            {
                _ExpandDllPath = value;
            }
        }

        /// <summary>
        /// 上传文件存放地址
        /// </summary>
        public static string UploadFileDirectory
        {
            get
            {
                return _UploadFileDirectory;
            }
            set
            {
                _UploadFileDirectory = value;
            }
        }

        /// <summary>
        /// 日志配置文件存放路径
        /// </summary>
        public static string Log4NetConfigPath
        {
            get
            {
                return _Log4NetConfigPath;
            }
            set
            {
                _Log4NetConfigPath = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 将配置文件中的配置读到静态配置表中
        /// </summary>
        public static void ReadToTable()
        {
            if (_ConnectionString == null || _TranferRule == null ||  _TempDirectory == null || _BackUpDirectory == null)
            {
                if (!File.Exists(ConfigFilePath))
                {
                    throw new ApplicationException(string.Format("{0}{1}", Utility._Error_XmlConfig_NotExist, ConfigFilePath));
                }
                else
                {
                    ReadAllConfigs(GetConfigFile(ConfigFilePath));
                }
            }
        }

        public static void ResetConfigs()
        {
            _ConnectionString = null;
            _TranferRule = null;
            _TempDirectory = null;
            _BackUpDirectory = null;
        }

        public static void SetRunningConfigDefault()
        {
            _DownloadFilesDirectory = Environment.CurrentDirectory + "\\DownloadFileDirectory\\";
            _ConfigFilePath = Environment.CurrentDirectory + "\\TransferConfig.xml";
            _ExpandDllPath = Environment.CurrentDirectory;
            _UploadFileDirectory = Environment.CurrentDirectory + "\\UploadFileDirectory\\";
        }

        public static string ReadToTableToString()
        {
            return Utility._Process_ReadStaticTable;
        }


        #endregion

        #region 私有方法

        private static void ReadAllConfigs(XmlNodeList nodeList)
        {
            _ConnectionString = GetNormalKey("ConnectionString", nodeList);
            _TranferRule = GetTwoLayerKey("TransferRule", nodeList);
            //文件夹路径
            _TempDirectory = GetNormalKey("TempDirectory", nodeList);
            _BackUpDirectory = GetNormalKey("BackUpDirectory", nodeList);
        }

        private static string GetNormalKey(string configKey,XmlNodeList nodeList)
        {
            foreach (XmlNode xmlNode in nodeList)
            {
                if (xmlNode.Name == configKey)
                {
                    if (string.IsNullOrEmpty(xmlNode.InnerXml))
                    {
                        throw new ApplicationException(string.Format("{0}{1}", Utility._Error_XmlConfig_Exist_Empty, configKey));
                    }
                    return xmlNode.InnerXml;
                }
            }
            throw new ApplicationException(string.Format("{0}{1}", Utility._Error_XmlConfigKey_NotExist, configKey));
        }

        private static Dictionary<string, string> GetTwoLayerKey(string configKey, XmlNodeList nodeList)
        {
            Dictionary<string, string> theConfigs = new Dictionary<string, string>();

            foreach (XmlNode xmlNode in nodeList)
            {
                if (xmlNode.Name == configKey)
                {
                    XmlNodeList xnl = xmlNode.ChildNodes;
                    foreach (XmlNode aChildNode in xnl)
                    {
                        theConfigs.Add(aChildNode.Name, aChildNode.InnerXml);
                    }
                    break;
                }
            }
            //注释的原因是从系统不需要配置文件
            //if (theConfigs.Count >0)
            //{
                return theConfigs;
            //}
            //else
            //{
            //    throw new ApplicationException(string.Format("{0}{1}", Utility._Error_XmlConfigKey_NotExist, configKey));
            //}
        }

        private static XmlNodeList GetConfigFile(string fileName)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(fileName);
            if (xmldoc.DocumentElement != null)
            {
                XmlNodeList xmlNodeList = xmldoc.DocumentElement.ChildNodes;
                return xmlNodeList;
            }
            else
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_XmlConfig_NotFit, fileName));
            }
        }


        #endregion
    }
}