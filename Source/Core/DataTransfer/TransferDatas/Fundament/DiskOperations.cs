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

        #region ����

        /// <summary>
        /// ���ݴ�ŵ���ʱ�ļ���
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
        /// ���ݿⱸ�ݴ�ŵ�Ŀ¼(�ڱ��ݵ�ʱ��)
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
        /// ���ݿⱸ�ݴ�ŵ�Ŀ¼(�ڻ�ԭ��ʱ��)
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
        /// ���ݵ�ʱ����ʱ�����ݴ���ļ���(��Ҫ�������)
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
        /// ��ԭ��ʱ����ʱ�����ݴ���ļ���(��Ҫ������ѹ)
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
        /// �ļ�����·��(�����ɺ��ļ��Ĵ��Ŀ¼)
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

        #region ����

        /// <summary>
        /// Ϊ��������׼�������ļ���
        /// </summary>
        public static void PrepareForBackUp()
        {
            PrepareNecessary();
            _DbBackUp_ForBackUpDirectory = CorrectDirectory(StaticConfigTable.BackUpDirectory) + BackUpDirectory_Default;
            _DataTemp_ForBackUpDirectory = CorrectDirectory(StaticConfigTable.TempDirectory) + BackUpDirectory_Default;
            //���� ��ʱĿ¼C:\Temp\ ���ݿⱸ��C:\Temp\BackUp ����Ŀ¼C:\Temp ��ΪtempĿ¼����ĳ��ʱ�̱������������Ҫ���ݶ�ʧ�Ŀ���
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
        /// Ϊ��ԭ����׼�������ļ���
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
        /// �����ļ���·��
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
        /// ����·�������ļ���
        /// </summary>
        public static void CheckAndCreateDirectory(string theDirectory)
        {
            if (!Directory.Exists(theDirectory))
            {
                Directory.CreateDirectory(theDirectory);
            }
        }
        
        /// <summary>
        /// �������������TableFilter�Ķ���
        /// </summary>
        /// <param name="name">�ļ���</param>
        public static ITableFilter CreateTableFilterObj(string name)
        {
            //��鵱ǰ����Ŀ¼���޸��ļ����� 
            string completeName = string.Format(@"{0}{1}", CorrectDirectory(StaticConfigTable.ExpandDllPath), MakeDllName(name));
            if (!File.Exists(completeName))
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_File_NotExist_Enviroment, completeName));
            }
            return CreateInstanceFromFile(completeName, MakeUnDllName(name));
        }

        

        /// <summary>
        /// д�����ļ�
        /// </summary>
        /// <param name="fileFullName">Ŀ���ļ���</param>
        /// <param name="stringLinesToWrite">��д����ַ�</param>
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
               
                throw new ApplicationException(string.Format("{0}{1},ԭ���ǣ�{2}", Utility._Error_WriteString_Failed, fileFullName, e.Message));
            }
            finally
            {
                sw.Close();
            }
        }

        /// <summary>
        /// ���������ļ����������ַ���
        /// </summary>
        /// <param name="fileFullName">�����ļ�ȫ��</param>
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
                throw new ApplicationException(string.Format("{0}{1},ԭ���ǣ�{2}", Utility._Error_ReadConfig_Failed, fileFullName, e.Message));
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
        /// ���ļ�����ɾ���������к���ָ��KeyWord���ļ�(��Ҫ���ڶ�̬ά�����ݿⱸ���ļ����������ļ��еĴ�С����������Ϊ�ļ������ռ��������Ӳ�̿ռ�)
        /// </summary>
        /// <param name="directory">ָ���ļ���</param>
        /// <param name="keyWord">ָ����KeyWord�����벻Ϊ��</param>
        /// <param name="protectedFileName">�����ļ�(����Ϊȫ��)�����������в���ɾ�������ļ�</param>
        /// <param name="count">ָ������(�����ܱ������ļ�)������ָ������֮����ļ�����ɾ��</param>
        /// <returns>���б�ɾ�����ļ�������</returns>
        public static string DelFilesFromDirectory(string directory,string keyWord,string protectedFileName,int count)
        {
            Utility.AssertStringNotEmpty(keyWord, Utility._Error_KeyWord_NotFit);
            if(count <= 0)
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_DeleteFileFromDirectory_NeedOneFile, directory));
            }

            //��ȡ������KeyWord���ļ�
            string[] allFiles = Directory.GetFiles(directory);
            List<string> KeyWordFiles = new List<string>();
            foreach(string s in allFiles)
            {
                if(s.Contains(keyWord))
                {
                    KeyWordFiles.Add(s);
                }
            }
            //�ų�protectedFileName
            bool ifSuccess = KeyWordFiles.Remove(protectedFileName);
            int needDelCount = KeyWordFiles.Count - count;
            if (ifSuccess)
            {
                needDelCount++;
            }

            //ɾ��������ļ�
            StringBuilder retVal = new StringBuilder("--ɾ���ļ���");
            if(needDelCount >0)
            {
                //����ɾ��ʱ�������
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
            return retVal + "δɾ���κ��ļ�";
        }


        /// <summary>
        /// ���Դ����ļ�
        /// </summary>
        /// <param name="targetNameForRar">�ļ�ȫ��</param>
        /// <param name="exceptionString">������Ϣ</param>
        public static void AssertFileExist(string targetNameForRar, string exceptionString)
        {
            if(!File.Exists(targetNameForRar))
            {
                throw new ApplicationException(exceptionString);
            }
        }

        /// <summary>
        /// ���Բ������ļ�
        /// </summary>
        /// <param name="targetNameForRar">�ļ�ȫ��</param>
        /// <param name="exceptionString">������Ϣ</param>
        public static void AssertFileNotExist(string targetNameForRar, string exceptionString)
        {
            if (File.Exists(targetNameForRar))
            {
                throw new ApplicationException(exceptionString);
            }
        }

        #endregion

        #region ˽�з���

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
            //��ȡ���д���ʱ��
            Dictionary<string, DateTime> theKeyWordWithCreateTime = new Dictionary<string, DateTime>();
            foreach (string file in keyWordFiles)
            {
                theKeyWordWithCreateTime.Add(file, File.GetCreationTime(file));
            }
            //����
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
                throw new ApplicationException(string.Format("{0}δ���ҵ����紴�����ļ�", Utility._Error_OrderFile_Failed));
            }
            return theKvp.Key;
        }

        #endregion

    }
}