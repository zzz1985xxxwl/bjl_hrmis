using System;

namespace TransferDatas
{
    public class Utility
    {
        #region ����

        public static void AssertAreSame(int expcetCount, int actualCount, string exceptionString)
        {
            if (expcetCount != actualCount)
            {
                throw new ApplicationException(exceptionString);
            }
        }

        public static void AssertStringNotEmpty(string theAssertString, string exceptionString)
        {
            if (string.IsNullOrEmpty(theAssertString))
            {
                throw new ApplicationException(exceptionString);
            }
        }

        public static void AssertAreSame(string expectString,string actualString,string exceptionString)
        {
            if(!expectString.Equals(actualString))
            {
                throw new ApplicationException(exceptionString);
            }
        }

        public static void AssertNotNull(Object o,string exceptionString)
        {
            if(o == null)
            {
                throw new ApplicationException(exceptionString);
            }
        }

        public static string GetTimeStamp()
        {
            return string.Format("_{0}_{1}_{2}_{3}_{4}_{5}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

        public static string MakeRunningErrorMsg(string errorMessage)
        {
            return string.Format("{0}{1}", _RuningStopped_For, errorMessage);
        }

        public static string MakeRunningExceptionMsg(string exceptionMessage)
        {
            return string.Format("{0}{1}", _RuningError_For, exceptionMessage);
        }

        #endregion

        #region ����״̬����

        /// <summary>
        /// ��ʼ����
        /// </summary>
        public const string _Process_Start = "��ʼ����";
        /// <summary>
        /// �����������гɹ�!
        /// </summary>
        public const string _Process_Success = "�����������гɹ�!";
        /// <summary>
        /// ������ֹ�ڴˣ�ԭ���ǣ�
        /// </summary>
        public const string _RuningStopped_For = "������ֹ�ڴˣ�ԭ���ǣ�";
        /// <summary>
        /// �����˲��ڿ��Ʒ�Χ�ڵ����ش���ԭ���ǣ�
        /// </summary>
        public const string _RuningError_For = "�����˲��ڿ��Ʒ�Χ�ڵ����ش���ԭ���ǣ�";
        /// <summary>
        /// �޷��ڹ������ҵ�ƥ��Ĺ��򣬸ù�����Ϊ��
        /// </summary>
        public const string _Rule_NotFount = "�޷��ڹ������ҵ�ƥ��Ĺ��򣬸ù�����Ϊ��";
        /// <summary>
        /// ���뾲̬���ñ�
        /// </summary>
        public const string _Process_ReadStaticTable = "���뾲̬���ñ�";
        /// <summary>
        /// ������־����
        /// </summary>
        public const string _Process_ConfigLogObj = "������־����";
        /// <summary>
        /// ׼�������ļ���
        /// </summary>
        public const string _Process_PrepareDirectory = "׼�������ļ���";
        /// <summary>
        /// ���Rar����
        /// </summary>
        public const string _Process_CheckRar = "���Rar����";
        /// <summary>
        /// Ѱ��ƥ�����
        /// </summary>
        public const string _Process_PrepareRule = "Ѱ��ƥ�����";
        /// <summary>
        /// �����������ݹ�����
        /// </summary>
        public const string _Process_ConfigFilter = "�����������ݹ�����";
        /// <summary>
        /// �������ݿ�:
        /// </summary>
        public const string _Process_BackUpDb = "�������ݿ�:";
        /// <summary>
        /// �������ݿ�:
        /// </summary>
        public const string _Process_CopyDb = "�������ݿ�:";
        /// <summary>
        /// ɸѡ��:
        /// </summary>
        public const string _Process_FilterTable = "ɸѡ��:";
        /// <summary>
        /// ����ɸѡ��ϵ����ݿ�:
        /// </summary>
        public const string _Process_BackUpFiltedTable = "����ɸѡ��ϵ����ݿ�:";
        /// <summary>
        /// ɾ�����ñ�
        /// </summary>
        public const string _Process_DelNonUseTable = "ɾ�����ñ�:";
        /// <summary>
        /// ɾ���������ݿ⿽����
        /// </summary>
        public const string _Process_DelNonUseDb = "ɾ���������ݿ⿽��:";
        /// <summary>
        /// ��������ļ�
        /// </summary>
        public const string _Process_RarBackUpFile = "��������ļ�:";
        /// <summary>
        /// д�������ļ�
        /// </summary>
        public const string _Process_WriteConfig = "д�������ļ�";
        /// <summary>
        /// ɾ�����õ����ݿⱸ��
        /// </summary>
        public const string _Process_DelNonuseDbBackUp = "ɾ�����õ����ݿⱸ��";
        /// <summary>
        /// ������������
        /// </summary>
        public const string _Process_CleanNonUseData = "������������";
        /// <summary>
        /// ����Rar����
        /// </summary>
        public const string _Process_AnalyseRarData = "����Rar����";
        /// <summary>
        /// ����������ݿⱸ���ļ�
        /// </summary>
        public const string _Process_CheckAllDbBackUp = "����������ݿⱸ���ļ�";
        /// <summary>
        /// ����������ݿⱸ���ļ�
        /// </summary>
        public const string _Process_RestoreTable = "��ԭ������";

        #endregion

        //----------------------------------------------------------��̬���ñ�
        /// <summary>
        /// δ�ڵ�ǰ����Ŀ¼�ҵ�����Ǩ�Ƶ������ļ�TransferConfig.xml
        /// </summary>
        public const string _Error_XmlConfig_NotExist = "δ�ڵ�ǰ����Ŀ¼�ҵ�����Ǩ�Ƶ������ļ���";
        /// <summary>
        /// ��ǰ����Ǩ�Ƶ������ļ��޷���ȷ��ȡ���ļ������ַ��:
        /// </summary>
        public const string _Error_XmlConfig_NotFit = "��ǰ������Ǩ�Ƶ������ļ��޷���ȷ��ȡ���ļ������ַ�ǣ�";
        /// <summary>
        /// ��ǰ����Ǩ�Ƶ������ļ����޷���ȡ�����¹ؼ���:
        /// </summary>
        public const string _Error_XmlConfigKey_NotExist = "��ǰ������Ǩ�Ƶ������ļ����޷���ȡ�����¹ؼ��֣�";
        /// <summary>
        /// ��ǰ����Ǩ�Ƶ������ļ������¹ؼ��ֵ�����Ϊ��:
        /// </summary>
        public const string _Error_XmlConfig_Exist_Empty = "��ǰ����Ǩ�Ƶ������ļ������¹ؼ��ֵ�����Ϊ�գ�";

        //----------------------------------------------------------Ӳ�̲���
        /// <summary>
        /// ��ǰ����Ǩ�Ƶ������ļ����������������⣬��ΪTempDirectory�ļ��лᱻ������������Ҫ���ݶ�ʧ,�޷���TempDirectory�ļ���������BackUpDirectory����DownloadFilesDirectory
        /// </summary>
        public const string _Error_DirectoryConfig_NotFit = "��ǰ����Ǩ�Ƶ������ļ����������������⣬��ΪTempDirectory�ļ��лᱻ������������Ҫ���ݶ�ʧ,�޷���TempDirectory�ļ���������BackUpDirectory����DownloadFilesDirectory";
        /// <summary>
        /// ����ļ���ʧ�ܣ�ԭ����:
        /// </summary>
        public const string _Error_DirectoryDelete_Failed = "����ļ���ʧ�ܣ�ԭ����:";
        /// <summary>
        /// �޷���������Ĺ��򹹽����������ڵ�ǰ���л������޷��ҵ�ָ�����ļ������ļ��ǣ�
        /// </summary>
        public const string _Error_File_NotExist_Enviroment = "�޷���������Ĺ��򹹽����������ڵ�ǰ���л������޷��ҵ�ָ�����ļ������ļ��ǣ�";
        /// <summary>
        /// �����ӿڵ�ʵ��ʧ�ܣ������Ҫ��һ��ָ������(�������ļ���ָ����չ��������)�������̳нӿڣ���������޷���λ����ص��ļ���������ǣ�
        /// </summary>
        public const string _Error_InstanceCreation_Failed = "�����ӿڵ�ʵ��ʧ�ܣ������Ҫ��һ��ָ������(�������ļ���ָ����չ��������)�������̳нӿڣ���������޷���λ����ص��ļ���������ǣ�";
        /// <summary>
        /// д�����ļ�ʧ�ܣ�Ŀ���ļ��ǣ�
        /// </summary>
        public const string _Error_WriteString_Failed = "д�����ļ�ʧ�ܣ�Ŀ���ļ��ǣ�";
        /// <summary>
        /// �������ļ�ʧ�ܣ�Ŀ���ļ��ǣ�
        /// </summary>
        public const string _Error_ReadConfig_Failed = "�������ļ�ʧ�ܣ�Ŀ���ļ��ǣ�";
        /// <summary>
        /// �����ļ���ʱ��Ҫ����ָ��һ��KeyWord
        /// </summary>
        public const string _Error_KeyWord_NotFit = "�����ļ���ʱ��Ҫ����ָ��һ��KeyWord";
        /// <summary>
        /// �����ļ�����ʱ������ʧ�ܣ�ԭ����:
        /// </summary>
        public const string _Error_OrderFile_Failed = "�����ļ�����ʱ������ʧ�ܣ�ԭ����:";
        /// <summary>
        /// ���ļ�����ɾ��ָ���ļ���������Ҫ����һ������ļ�,���ļ����ǣ�
        /// </summary>
        public const string _Error_DeleteFileFromDirectory_NeedOneFile = "���ļ�����ɾ��ָ���ļ���������Ҫ����һ������ļ�,���ļ����ǣ�";


        //----------------------------------------------------------Sql����
        /// <summary>
        /// �����������ݿ�ʱʧ�ܣ�ԭ���ǣ�
        /// </summary>
        public const string _Error_CopyDB_Failed = "�����������ݿ�ʱʧ��,ԭ���ǣ�";
        /// <summary>
        /// ��ȡ�������ݵ��߼�����ʧ��
        /// </summary>
        public const string _Error_ReadLogicName_Failed = "��ȡ�������ݵ��߼�����ʧ��";
        /// <summary>
        /// ɾ�����ݿ�ʧ�ܣ������ݿ���Ϊ��
        /// </summary>
        public const string _Error_DropDb_Failed = "ɾ�����ݿ�ʧ�ܣ������ݿ���Ϊ��";
        /// <summary>
        /// ��ȡ��������Ϣʧ�ܣ������ݿ������Ϊ��
        /// </summary>
        public const string _Error_ReadTable_Failed = "��ȡ��������Ϣʧ�ܣ������ݿ������Ϊ��";
        /// <summary>
        /// ��ȡ��Լ����Ϣʧ�ܣ��ñ�Ϊ��
        /// </summary>
        public const string _Error_ReadConstraint_Failed = "��ȡ��Լ����Ϣʧ�ܣ��ñ�Ϊ��";
        /// <summary>
        /// ��֧��������������Ǩ�ƣ��ؽ���Լ��ʧ�ܣ��ñ�Ϊ:
        /// </summary>
        public const string _Error_ReConstraint_PkFailed = "���ڲ�֧����������֧�֣��ؽ���Լ��ʧ�ܣ��ñ�Ϊ:";
        /// <summary>
        /// ��֧���������Ǩ�ƣ��ؽ���Լ��ʧ�ܣ��ñ�Ϊ:
        /// </summary>
        public const string _Error_ReConstraint_FkFailed = "��֧���������Ǩ�ƣ��ؽ���Լ��ʧ�ܣ��ñ�Ϊ:";
        /// <summary>
        /// �ؽ���Լ��ʧ�ܣ��ñ�Ϊ:
        /// </summary>
        public const string _Error_ReConstraint_Failed = "�ؽ���Լ��ʧ�ܣ��ñ�Ϊ:";
        /// <summary>
        /// ������Լ��ʧ�ܣ��ñ�Ϊ:
        /// </summary>
        public const string _Error_DropConstraint_Failed =  "������Լ��ʧ�ܣ��ñ�Ϊ:";
        /// <summary>
        /// �������ݿ�ʧ��,�����ݿ���Ŀ���ַ�ֱ�Ϊ��
        /// </summary>
        public const string _Error_BackUpDb_Failed = "�������ݿ�ʧ��,�����ݿ���Ŀ���ַ�ֱ�Ϊ��";
        /// <summary>
        /// ��ȡ���б���Ϣʧ�ܣ������ݿ�Ϊ��
        /// </summary>
        public const string _Error_GetAllTable_Failed = "��ȡ���б���Ϣʧ�ܣ������ݿ�Ϊ��";
        /// <summary>
        /// ɾ���������ʧ�ܣ������ݿ�Ϊ��
        /// </summary>
        public const string _Error_DelAllFk_Failed = "ɾ���������ʧ�ܣ������ݿ�Ϊ��";

        //----------------------------------------------------------CommandRunner
        /// <summary>
        /// �޷��ҵ�Rar����Ĭ��Ѱ��Rar��·���ǣ�
        /// </summary>
        public const string _Error_Rar_NotFound = "Rar�����޷����У�Ĭ��Ѱ��Rar��·���ǣ�";
        /// <summary>
        /// ����ʧ�ܣ�Ŀ���ļ��Ѿ����ڣ�·���ǣ�
        /// </summary>
        public const string _Error_File_Exist = "����ʧ�ܣ�Ŀ���ļ��Ѿ����ڣ�·���ǣ�";
        /// <summary>
        /// ����ʧ�ܣ�Դ�ļ������ڣ�·���ǣ�
        /// </summary>
        public const string _Error_File_NotExist = "����ʧ�ܣ�Դ�ļ������ڣ�·���ǣ�";
        /// <summary>
        /// ��������Դ��ַ��Ŀ���ַ�ֱ��ǣ�
        /// </summary>
        public const string _Error_Copy_Failed = "��������Դ��ַ��Ŀ���ַ�ֱ��ǣ�";
        /// <summary>
        /// ����ļ��г������ļ����ǣ�
        /// </summary>
        public const string _Error_CleanDirectory_Failed = "����ļ��г������ļ����ǣ�";
        /// <summary>
        /// ɾ��ָ���ļ��������ļ��ĵ�ַ�ǣ�
        /// </summary>
        public const string _Error_DeleteFile_Failed = "ɾ��ָ���ļ��������ļ��ĵ�ַ�ǣ�";
        /// <summary>
        /// ɾ��ָ���ļ������޷��ڸ�·�����ҵ����ļ���
        /// </summary>
        public const string _Error_DeleteFile_NotExist = "ɾ��ָ���ļ������޷��ڸ�·�����ҵ����ļ���";
        /// <summary>
        /// ѹ���ļ���ʧ�ܣ����ļ���Ϊ��
        /// </summary>
        public const string _Error_RarDirectory_Failed = "ѹ���ļ���ʧ�ܣ����ļ���Ϊ��";
        /// <summary>
        /// ��ѹ���ļ�ʧ�ܣ����ļ�Ϊ��
        /// </summary>
        public const string _Error_UnRarFile_Failed = "��ѹ���ļ�ʧ�ܣ����ļ�Ϊ��";
        /// <summary>
        /// ����ѹ���ļ���ʧ�ܣ�Ӧ����rarΪ��׺�������ļ����ǣ�
        /// </summary>
        public const string _Error_CheckRarFileName_Failed = "����ѹ���ļ���ʧ�ܣ�Ӧ����rarΪ��׺�������ļ����ǣ�";

        //----------------------------------------------------------Model_TransferRule
        /// <summary>
        /// ��ǰ����Ǩ�Ƶ������ļ���TransferRule�ڵ����й�����Ϊ�գ��޷����ת������
        /// </summary>
        public const string _Error_XmlConfig_TransferRule_KeyEmpty = "��ǰ����Ǩ�Ƶ������ļ���TransferRule�ڵ����й�����Ϊ�գ��޷����ת������";
        /// <summary>
        /// ��ǰ����Ǩ�Ƶ������ļ��е�TransferRule�ڵ����޷���ȷ��ȡ���ݿ������ù����������:
        /// </summary>
        public const string _Error_XmlConfig_DbName_NotFit = "��ǰ����Ǩ�Ƶ������ļ��е�TransferRule�ڵ����޷���ȷ��ȡ���ݿ������ù����������:";
        /// <summary>
        /// ��ǰ����Ǩ�Ƶ������ļ��е�TransferRule�ڵ����޷���ȷ��ȡ�������߹��˹��򣬸ù����������:
        /// </summary>
        public const string _Error_XmlConfig_TableName_NotFit = "��ǰ����Ǩ�Ƶ������ļ��е�TransferRule�ڵ����޷���ȷ��ȡ�������ù����������:";
        /// <summary>
        /// ���ݵ�ǰ����Ǩ�Ƶ������ļ���ȡ�Ĺ�����ȷ�����·ֱ���2��������ַ�����
        /// </summary>
        public const string _Error_XmlConfig_Read_NotFit = "���ݵ�ǰ����Ǩ�Ƶ������ļ���ȡ�Ĺ�����ȷ�����·ֱ���2��������ַ�����";
        /// <summary>
        /// ��ȡ�Զ���Ǩ�����ó����Ѿ�����صı�������Ǩ�Ʊ��л��߱������У������ݿ⡢�����ֱ�Ϊ��
        /// </summary>
        public const string _Error_DefineTransfer_Exist_Table = "��ȡ�Զ���Ǩ�����ó����Ѿ�����صı�������Ǩ�Ʊ��л��߱������У������ݿ⡢�����ֱ�Ϊ��";
        /// <summary>
        /// ����ɸѡ������ݿ�ʧ�ܣ���ָ��Ŀ¼�Ѿ��и����ݿ���ڣ�������������һ�εı��ݹ���û����ȷ�������
        /// </summary>
        public const string _Error_ExistTargetBackUpDb = "����ɸѡ������ݿ�ʧ�ܣ���ָ��Ŀ¼�Ѿ��и����ݿ���ڣ�������������һ�εı��ݹ���û����ȷ�������";


        //----------------------------------------------------------TransferService
        /// <summary>
        /// �޷����е�ǰ��Ǩ�����ݽ��̣��Ѿ���һ������߳��������У����Ե�����
        /// </summary>
        public const string _Error_RunningFlag_NotFit = "�޷����е�ǰ��Ǩ�����ݽ��̣��Ѿ���һ������߳��������У����Ե�����";
        /// <summary>
        /// ����Rarѹ���ļ��е�Ǩ�ƹ���ʧ�ܣ���ȷ������ϵͳ����������rar�ļ�û�б��޸Ĺ�
        /// </summary>
        public const string _Error_AnalyseRarData_Error = "����Rarѹ���ļ��е�Ǩ�ƹ���ʧ�ܣ���ȷ������ϵͳ����������rar�ļ�û�б��޸Ĺ�";



        //----------------------------------------------------------NullTableFilter
        /// <summary>
        /// ������ʧ��,�ñ����ǣ�
        /// </summary>
        public const string _Error_DropTable_Failed = "������ʧ��,�ñ����ǣ�";
        /// <summary>
        /// ���Ʊ�ʧ��,�ñ����ǣ�
        /// </summary>
        public const string _Error_CopyTable_Failed = "���Ʊ�ʧ��,�ñ����ǣ�";


        //----------------------------------------------------------TransferConfig
        /// <summary>
        /// �޷���������ļ��Ĵ��������ڹ���Ϊ��
        /// </summary>
        public const string _Error_TransferRule_NotNull = "�޷���������ļ��Ĵ��������ڹ���Ϊ��";
        /// <summary>
        ///�޷���ȡ�����ļ���δ�������ļ����ҵ���Ӧ�����ü����ü��ǣ�
        /// </summary>
        public const string _Error_Key_NotFound = "�޷���ȡ�����ļ���δ�������ļ����ҵ���Ӧ�����ü����ü��ǣ�";
        /// <summary>
        /// �޷�׼ȷ��ȡ�����ļ��е�ʱ����������ַ���Ϊ��
        /// </summary>
        public const string _Error_Parameter_ReadError = "�޷�׼ȷ��ȡ�����ļ��е�ʱ����������ַ���Ϊ��";


        //----------------------------------------------------------TransferRule
        /// <summary>
        /// ��ԭ����ʧ�ܣ�ִ���������г����˴��󣬸û�ԭ����������ԭ��ֱ��ǣ�
        /// </summary>
        public const string _Error_CleanUpRestoreData = "��ԭ����ʧ�ܣ�ִ���������г����˴��󣬸û�ԭ����������ԭ��ֱ��ǣ�";
        /// <summary>
        /// ��������ʧ�ܣ�ִ���������г����˴��󣬸û�ԭ����������ԭ��ֱ��ǣ�
        /// </summary>
        public const string _Error_CleanUpBackUpData = "��������ʧ�ܣ�ִ���������г����˴��󣬸û�ԭ����������ԭ��ֱ��ǣ�";


        //----------------------------------------------------------TransferDataLog
        /// <summary>
        /// �޷������־����Ĵ����������������޷��ҵ���Ӧ�������ļ����£��ô��������ǣ�
        /// </summary>
        public const string _Error_LogConfig_NotExits = "�޷������־����Ĵ����������������޷��ҵ���Ӧ�������ļ����£��ô��������ǣ�";
    }
}