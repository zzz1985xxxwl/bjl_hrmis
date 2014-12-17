using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace TransferDatas
{
    public class DiskOperations
    {
        private static string _TempDirectory;
        private static string _DownLoadDirectory;
        private static string _DbBackUp_ForBackUpDirectory;
        private static string _DbBackUp_ForRestoreDirectory;
        private static string _DataTemp_ForBackUpDirectory;
        private static string _DataTemp_ForRestoreDirectory;

        private const string BackUpDirectory_Default = "ForBackUp";
        private const string RestoreDirectory_Default = "ForRestore";

        #region 属性

        /// <summary>
        /// 数据存放的临时文件夹
        /// </summary>
        public static string TempDirectory
        {
            get
            {
                return CorrectDirectory(_TempDirectory);
            }
            set
            {
                _TempDirectory = value;
            }
        }

        /// <summary>
        /// 数据库备份存放的目录(在备份的时候)
        /// </summary>
        public static string DbBackUp_ForBackUpDirectory
        {
            get
            {
                return CorrectDirectory(_DbBackUp_ForBackUpDirectory);
            }
            set
            {
                _DbBackUp_ForBackUpDirectory = value;
            }
        }

        /// <summary>
        /// 数据库备份存放的目录(在还原的时候)
        /// </summary>
        public static string DbBackUp_ForRestoreDirectory
        {
            get
            {
                return CorrectDirectory(_DbBackUp_ForRestoreDirectory);
            }
            set
            {
                _DbBackUp_ForRestoreDirectory = value;
            }
        }

        /// <summary>
        /// 备份的时候临时的数据存放文件夹(主要用来打包)
        /// </summary>
        public static string DataTemp_ForBackUpDirectory
        {
            get
            {
                return CorrectDirectory(_DataTemp_ForBackUpDirectory);
            }
            set
            {
                _DataTemp_ForBackUpDirectory = value;
            }
        }

        /// <summary>
        /// 还原的时候临时的数据存放文件夹(主要用来解压)
        /// </summary>
        public static string DataTemp_ForRestoreDirectory
        {
            get
            {
                return CorrectDirectory(_DataTemp_ForRestoreDirectory);
            }
            set
            {
                _DataTemp_ForRestoreDirectory = value;
            }
        }

        /// <summary>
        /// 文件下载路径(打包完成后文件的存放目录)
        /// </summary>
        public static string DownLoadDirectory
        {
            get
            {
                return CorrectDirectory(_DownLoadDirectory);
            }
            set
            {
                _DownLoadDirectory = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 为备份数据准备所有文件夹
        /// </summary>
        public static void PrepareForBackUp()
        {
            PrepareNecessary();
            _DbBackUp_ForBackUpDirectory = CorrectDirectory(StaticConfigTable.BackUpDirectory) + BackUpDirectory_Default;
            _DataTemp_ForBackUpDirectory = CorrectDirectory(StaticConfigTable.TempDirectory) + BackUpDirectory_Default;
            //例子 临时目录C:\Temp\ 数据库备份C:\Temp\BackUp 下载目录C:\Temp 因为temp目录会在某个时刻被清空所以有重要数据丢失的可能
            if (_DbBackUp_ForBackUpDirectory.Contains(_TempDirectory) || _DownLoadDirectory.Contains(_TempDirectory))
            {
                throw new ApplicationException(Utility._Error_DirectoryConfig_NotFit);
            }
            CheckAndCreateDirectory(_DbBackUp_ForBackUpDirectory);
            CheckAndCreateDirectory(_DataTemp_ForBackUpDirectory);
            CheckAndCreateCreateNecessary();
        }

        public static string PrepareForBackUpToString()
        {
            return Utility._Process_PrepareDirectory;
        }

        /// <summary>
        /// 为还原数据准备所有文件夹
        /// </summary>
        public static void PrepareForRestore()
        {
            PrepareNecessary();
            _DbBackUp_ForRestoreDirectory = CorrectDirectory(StaticConfigTable.BackUpDirectory) + RestoreDirectory_Default;
            _DataTemp_ForRestoreDirectory = CorrectDirectory(StaticConfigTable.TempDirectory) + RestoreDirectory_Default;
            if (_DbBackUp_ForRestoreDirectory.Contains(_TempDirectory))
            {
                throw new ApplicationException(Utility._Error_DirectoryConfig_NotFit);
            }
            CheckAndCreateDirectory(_DbBackUp_ForRestoreDirectory);
            CheckAndCreateDirectory(_DataTemp_ForRestoreDirectory);
            CheckAndCreateCreateNecessary();
        }

        public static string PrepareForRestoreToString()
        {
            return Utility._Process_PrepareDirectory;
        }

        /// <summary>
        /// 纠正文件夹路径
        /// </summary>
        public static string CorrectDirectory(string thePath)
        {
            if (!thePath.EndsWith("\\"))
            {
                return thePath + "\\";
            }
            return thePath;
        }

        /// <summary>
        /// 根据路径创建文件夹
        /// </summary>
        public static void CheckAndCreateDirectory(string theDirectory)
        {
            if (!Directory.Exists(theDirectory))
            {
                Directory.CreateDirectory(theDirectory);
            }
        }
        
        /// <summary>
        /// 根据类库名创建TableFilter的对象
        /// </summary>
        /// <param name="name">文件名</param>
        public static ITableFilter CreateTableFilterObj(string name)
        {
            //检查当前运行目录有无该文件存在 
            string completeName = string.Format(@"{0}{1}", CorrectDirectory(StaticConfigTable.ExpandDllPath), MakeDllName(name));
            if (!File.Exists(completeName))
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_File_NotExist_Enviroment, completeName));
            }
            return CreateInstanceFromFile(completeName, MakeUnDllName(name));
        }

        

        /// <summary>
        /// 写配置文件
        /// </summary>
        /// <param name="fileFullName">目标文件名</param>
        /// <param name="stringLinesToWrite">待写入的字符</param>
        public static void WriteLinesToFile(string fileFullName,List<string> stringLinesToWrite)
        {
            StreamWriter sw = new StreamWriter(fileFullName,false);
            try
            {
                foreach (string s in stringLinesToWrite)
                {
                    sw.WriteLine(s);
                }
            }
            catch(Exception e)
            {
               
                throw new ApplicationException(string.Format("{0}{1},原因是：{2}", Utility._Error_WriteString_Failed, fileFullName, e.Message));
            }
            finally
            {
                sw.Close();
            }
        }

        /// <summary>
        /// 根据配置文件读出配置字符串
        /// </summary>
        /// <param name="fileFullName">配置文件全名</param>
        public static List<string> ReadLinesFromFile(string fileFullName)
        {
            List<string> retVal = new List<string>();
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(fileFullName);
                string readData;
                while ((readData = sr.ReadLine()) != null)
                {
                    retVal.Add(readData);
                }
                return retVal;
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1},原因是：{2}", Utility._Error_ReadConfig_Failed, fileFullName, e.Message));
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        /// <summary>
        /// 在文件夹中删除，名字中含有指定KeyWord的文件(主要用于动态维护数据库备份文件夹与下载文件夹的大小，不至于因为文件过多而占满了整个硬盘空间)
        /// </summary>
        /// <param name="directory">指定文件夹</param>
        /// <param name="keyWord">指定的KeyWord，必须不为空</param>
        /// <param name="protectedFileName">保护文件(必须为全名)，本次运行中不会删除保护文件</param>
        /// <param name="count">指定数量(包括受保护的文件)，超过指定数量之后的文件将被删除</param>
        /// <returns>所有被删除的文件的名字</returns>
        public static string DelFilesFromDirectory(string directory,string keyWord,string protectedFileName,int count)
        {
            Utility.AssertStringNotEmpty(keyWord, Utility._Error_KeyWord_NotFit);
            if(count <= 0)
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_DeleteFileFromDirectory_NeedOneFile, directory));
            }

            //读取所有有KeyWord的文件
            string[] allFiles = Directory.GetFiles(directory);
            List<string> KeyWordFiles = new List<string>();
            foreach(string s in allFiles)
            {
                if(s.Contains(keyWord))
                {
                    KeyWordFiles.Add(s);
                }
            }
            //排除protectedFileName
            bool ifSuccess = KeyWordFiles.Remove(protectedFileName);
            int needDelCount = KeyWordFiles.Count - count;
            if (ifSuccess)
            {
                needDelCount++;
            }

            //删除最早的文件
            StringBuilder retVal = new StringBuilder("--删除文件：");
            if(needDelCount >0)
            {
                //排序并删除时间最早的
                List<string> theFilesWithCreateTime = OrderFilesByCreateTime(KeyWordFiles);
                for(int i =0 ;i<needDelCount;i++)
                {
                    CommandRunner.DeleteFile(theFilesWithCreateTime[i]);
                    retVal.Append(theFilesWithCreateTime[i]).Append(",");
                }
            }
            if(retVal.ToString().EndsWith(","))
            {
                return retVal.Remove(retVal.Length - 1, 1).ToString();
            }
            return retVal + "未删除任何文件";
        }


        /// <summary>
        /// 断言存在文件
        /// </summary>
        /// <param name="targetNameForRar">文件全名</param>
        /// <param name="exceptionString">错误信息</param>
        public static void AssertFileExist(string targetNameForRar, string exceptionString)
        {
            if(!File.Exists(targetNameForRar))
            {
                throw new ApplicationException(exceptionString);
            }
        }

        /// <summary>
        /// 断言不存在文件
        /// </summary>
        /// <param name="targetNameForRar">文件全名</param>
        /// <param name="exceptionString">错误信息</param>
        public static void AssertFileNotExist(string targetNameForRar, string exceptionString)
        {
            if (File.Exists(targetNameForRar))
            {
                throw new ApplicationException(exceptionString);
            }
        }

        #endregion

        #region 私有方法

        private static void PrepareNecessary()
        {
            _TempDirectory = CorrectDirectory(StaticConfigTable.TempDirectory);
            _DownLoadDirectory = CorrectDirectory(StaticConfigTable.DownloadFilesDirectory);
        }

        private static void CheckAndCreateCreateNecessary()
        {
            CheckAndCreateDirectory(_TempDirectory);
            CheckAndCreateDirectory(_DownLoadDirectory);
        }

        private static ITableFilter CreateInstanceFromFile(string completeName,string simpleName)
        {
            Assembly theExpendAssembly = Assembly.LoadFile(completeName);
            string typeFullName = null;
            foreach (Type type in theExpendAssembly.GetTypes())
            {
                Type[] theInterfaces = type.GetInterfaces();
                if (theInterfaces != null)
                {
                    foreach (Type anInterface in theInterfaces)
                    {
                        if (anInterface.Name.Equals(typeof(ITableFilter).Name) && type.Name.Equals(simpleName))
                        {
                            typeFullName = type.FullName;
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(typeFullName))
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_InstanceCreation_Failed, completeName));
            }
            ITableFilter retVal = theExpendAssembly.CreateInstance(typeFullName) as ITableFilter;
            if (retVal == null)
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_InstanceCreation_Failed, completeName));
            }
            return retVal;
        }

        private static string MakeDllName(string name)
        {
            if(!name.EndsWith(".dll"))
            {
                return name + ".dll";
            }
            return name;
        }

        private static string MakeUnDllName(string name)
        {
            if (name.EndsWith(".dll"))
            {
                return name.Replace(".dll",string.Empty);
            }
            return name;
        }

        private static List<string> OrderFilesByCreateTime(List<string> keyWordFiles)
        {
            //获取所有创建时间
            Dictionary<string, DateTime> theKeyWordWithCreateTime = new Dictionary<string, DateTime>();
            foreach (string file in keyWordFiles)
            {
                theKeyWordWithCreateTime.Add(file, File.GetCreationTime(file));
            }
            //排序
            List<string> retVal = new List<string>();
            for (int i = 0; i < theKeyWordWithCreateTime.Count; i++)
            {
                string theEarlyKey = GetTheEarlyestKey(theKeyWordWithCreateTime);
                retVal.Add(theEarlyKey);
                theKeyWordWithCreateTime.Remove(theEarlyKey);
            }
            return retVal;
        }

        private static string GetTheEarlyestKey(Dictionary<string, DateTime> theKeyWordWithCreateTime)
        {
            KeyValuePair<string, DateTime> theKvp = new KeyValuePair<string, DateTime>(string.Empty, new DateTime(2999, 12, 31));
            foreach (KeyValuePair<string, DateTime> kvp in theKeyWordWithCreateTime)
            {
                if (kvp.Value < theKvp.Value)
                {
                    theKvp = kvp;
                }
            }
            if (theKvp.Value == new DateTime(2999, 12, 31))
            {
                throw new ApplicationException(string.Format("{0}未能找到最早创建的文件", Utility._Error_OrderFile_Failed));
            }
            return theKvp.Key;
        }

        #endregion

    }
}