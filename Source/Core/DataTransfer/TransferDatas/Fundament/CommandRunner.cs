using System;
using System.Diagnostics;
using System.IO;

namespace TransferDatas
{
    public class CommandRunner
    {
        private const string _Default_RarPath = @"C:\Program Files\WinRAR\winrar.exe";

        #region ��������

        /// <summary>
        /// ���ó�ʱ�ȴ����г���
        /// </summary>
        public static bool Run(string exeName, string argsLine, int timeoutSecondes)
        {
            string outPut;
            return Run(exeName, argsLine, timeoutSecondes, out outPut, false);
        }

        /// <summary>
        /// �����Ƶȴ����г���
        /// </summary>
        public static bool Run(string exeName, string argsLine)
        {
            string outPut;
            return Run(exeName, argsLine, 0, out outPut, false);
        }

        public static bool Run(string exeName, string argsLine, int timeoutSeconds, out string output, bool needOutPut)
        {
            bool ifSuccess;
            StreamReader outputStream = StreamReader.Null;
            output = string.Empty;

            try
            {
                Process newProcess = new Process();
                newProcess.StartInfo.FileName = exeName;
                newProcess.StartInfo.Arguments = argsLine;
                newProcess.StartInfo.UseShellExecute = false;
                newProcess.StartInfo.CreateNoWindow = true;
                newProcess.StartInfo.RedirectStandardOutput = needOutPut;
                newProcess.Start();

                if (0 == timeoutSeconds)
                {
                    if (needOutPut)
                    {
                        outputStream = newProcess.StandardOutput;
                        output = outputStream.ReadToEnd();
                    }
                    newProcess.WaitForExit();
                    ifSuccess = true;
                }
                else
                {
                    ifSuccess = newProcess.WaitForExit(timeoutSeconds * 1000);

                    if (ifSuccess)
                    {
                        if (needOutPut)
                        {
                            outputStream = newProcess.StandardOutput;
                            output = outputStream.ReadToEnd();
                        }
                    }
                    else
                    {
                        output = "����" + exeName + "��ʱ";
                        newProcess.Kill();
                    }
                }
            }
            catch (Exception e)
            {
                throw (new Exception("����" + exeName + "��������", e));
            }
            finally
            {
                outputStream.Close();
            }

            return ifSuccess;
        }

        #endregion

        #region ʵ�÷���(�����Ѿ���װ)

        /// <summary>
        /// ���Rar�����Ƿ����
        /// </summary>
        public static void CheckRarReady()
        {
            if(!File.Exists(_Default_RarPath))
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_Rar_NotFound, _Default_RarPath));
            }
        }

        public static string CheckRarReadyToString()
        {
            return Utility._Process_CheckRar;
        }

        /// <summary>
        /// �����ļ���ָ���ļ�λ��
        /// </summary>
        public static void CopyToFile(string fromFile,string toFile)
        {
            if(!File.Exists(fromFile))
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_File_NotExist, fromFile));
            }
            if (File.Exists(toFile))
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_File_Exist, toFile));
            }
            Copy(fromFile, toFile);
        }

        /// <summary>
        /// �����ļ����ļ���
        /// </summary>
        public static void CopyToDirectory(string fromFile,string toDirectory)
        {
            if (!File.Exists(fromFile))
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_File_NotExist, fromFile));
            }
            string fileName = fromFile.Substring(fromFile.LastIndexOf(@"\")+1);
            string targetFile = string.Format("{0}{1}", DiskOperations.CorrectDirectory(toDirectory), fileName);
            if (File.Exists(targetFile))
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_File_Exist, targetFile));
            }
            Copy(fromFile, toDirectory);
        }

        /// <summary>
        /// ����ļ��У�ɾ���ļ����������ļ�(���ݹ�)
        /// </summary>
        public static void CleanUpDirectory(string directory)
        {
            string theRightDirectory = DiskOperations.CorrectDirectory(directory);
            string command = string.Format("/c del \"{0}*\" /q", theRightDirectory);

            bool reslut;
            try
            {
                reslut = Run("cmd.exe", command, 20);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1},ԭ���ǣ�{2}", Utility._Error_CleanDirectory_Failed, theRightDirectory, e.Message));
            }
            if (!reslut)
            {
                throw new ApplicationException(string.Format("{0}{1},ԭ���ǣ���ʱ(20��������Ӧ)", Utility._Error_CleanDirectory_Failed, theRightDirectory));
            }
        }

        /// <summary>
        /// ɾ��ָ���ļ�
        /// </summary>
        /// <param name="filePath">�ļ��ľ���·��</param>
        public static void DeleteFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_DeleteFile_NotExist, filePath));
            }
            try
            {
                File.Delete(filePath);
            }
            catch(Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1},ԭ���ǣ�{2}", Utility._Error_DeleteFile_Failed, filePath, e.Message));
            }
        }

        /// <summary>
        /// ѹ��ָ���ļ�����ָ�����ļ�
        /// </summary>
        /// <param name="targetRarFile">ָ�����ļ�</param>
        /// <param name="sourceDirectory">ָ�����ļ���</param>
        public static void RarDirectoryToFile(string targetRarFile,string sourceDirectory)
        {
            AssertIsRarFile(targetRarFile);
            if(File.Exists(targetRarFile))
            {
                throw new ApplicationException(string.Format("{0}{1},ԭ���ǣ�ָ��λ���Ѿ���Ŀ���ļ�����", Utility._Error_RarDirectory_Failed, sourceDirectory));
            }

            string theArgOfRar = string.Format("a -r -s -ibck -inul \"{0}\" \"{1}\"", targetRarFile, sourceDirectory);
            bool reslut;
            try
            {
                reslut = Run(@"C:\Program Files\WinRAR\winrar.exe", theArgOfRar, 120);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1},ԭ���ǣ�{2}", Utility._Error_RarDirectory_Failed, sourceDirectory,e.Message));
            }
            if (!reslut)
            {
                throw new ApplicationException(string.Format("{0}{1},ԭ���ǣ���ʱ(120��������Ӧ)", Utility._Error_RarDirectory_Failed, sourceDirectory));
            }
        }

        /// <summary>
        /// ��ѹ���ļ���ָ���ļ���
        /// </summary>
        /// <param name="sourceRarFile">Դrar�ļ�</param>
        /// <param name="targetDirectory">Ŀ���ļ���</param>
        /// <param name="coverExist">�Ƿ񸲸��Ѿ����ڵ��ļ�</param>
        public static void UnRarFileToDirectory(string sourceRarFile,string targetDirectory,bool coverExist)
        {
            AssertIsRarFile(sourceRarFile);
            if (!File.Exists(sourceRarFile))
            {
                throw new ApplicationException(string.Format("{0}{1},ԭ���ǣ�Դrar�ļ��޷��ҵ�", Utility._Error_UnRarFile_Failed, sourceRarFile));
            }

            string needCoverExist = coverExist ? "-o+" : "-o-";
            string theArgOfRar = string.Format("E -ibck -inul {0} \"{1}\" \"{2}\"",needCoverExist,  sourceRarFile, targetDirectory);
            bool reslut;
            try
            {
                reslut = Run(@"C:\Program Files\WinRAR\winrar.exe", theArgOfRar, 120);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1},ԭ���ǣ�{2}", Utility._Error_UnRarFile_Failed, sourceRarFile, e.Message));
            }
            if (!reslut)
            {
                throw new ApplicationException(string.Format("{0}{1},ԭ���ǣ���ʱ(120��������Ӧ)", Utility._Error_UnRarFile_Failed, sourceRarFile));
            }
        }

        public static void AssertIsRarFile(string fullFilePath)
        {
            if (!fullFilePath.EndsWith(".rar"))
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_CheckRarFileName_Failed, fullFilePath));
            }
        }

        #endregion

        #region ˽�з���

        private static void Copy(string from,string to)
        {
            string theArgOfRar = string.Format("/c copy \"{0}\" \"{1}\"", from, to);
            bool reslut;
            try
            {
                reslut = Run("cmd.exe", theArgOfRar, 20);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}/{2},ԭ���ǣ�{3}", Utility._Error_Copy_Failed, from, to, e.Message));
            }
            if (!reslut)
            {
                throw new ApplicationException(string.Format("{0}{1}/{2},ԭ���ǣ���ʱ(20��������Ӧ)", Utility._Error_Copy_Failed, from, to));
            }
        }


        #endregion
    }
}