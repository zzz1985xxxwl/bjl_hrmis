using System;

namespace TransferDatas
{
    public class Utility
    {
        #region 方法

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

        #region 运行状态描述

        /// <summary>
        /// 开始运行
        /// </summary>
        public const string _Process_Start = "开始运行";
        /// <summary>
        /// 所有任务运行成功!
        /// </summary>
        public const string _Process_Success = "所有任务运行成功!";
        /// <summary>
        /// 运行终止于此，原因是：
        /// </summary>
        public const string _RuningStopped_For = "运行终止于此，原因是：";
        /// <summary>
        /// 出现了不在控制范围内的严重错误，原因是：
        /// </summary>
        public const string _RuningError_For = "出现了不在控制范围内的严重错误，原因是：";
        /// <summary>
        /// 无法在规则中找到匹配的规则，该规则名为：
        /// </summary>
        public const string _Rule_NotFount = "无法在规则中找到匹配的规则，该规则名为：";
        /// <summary>
        /// 读入静态配置表
        /// </summary>
        public const string _Process_ReadStaticTable = "读入静态配置表";
        /// <summary>
        /// 配置日志对象
        /// </summary>
        public const string _Process_ConfigLogObj = "配置日志对象";
        /// <summary>
        /// 准备所需文件夹
        /// </summary>
        public const string _Process_PrepareDirectory = "准备所需文件夹";
        /// <summary>
        /// 检查Rar程序
        /// </summary>
        public const string _Process_CheckRar = "检查Rar程序";
        /// <summary>
        /// 寻找匹配规则
        /// </summary>
        public const string _Process_PrepareRule = "寻找匹配规则";
        /// <summary>
        /// 配置所有数据过滤器
        /// </summary>
        public const string _Process_ConfigFilter = "配置所有数据过滤器";
        /// <summary>
        /// 备份数据库:
        /// </summary>
        public const string _Process_BackUpDb = "备份数据库:";
        /// <summary>
        /// 复制数据库:
        /// </summary>
        public const string _Process_CopyDb = "复制数据库:";
        /// <summary>
        /// 筛选表:
        /// </summary>
        public const string _Process_FilterTable = "筛选表:";
        /// <summary>
        /// 备份筛选完毕的数据库:
        /// </summary>
        public const string _Process_BackUpFiltedTable = "备份筛选完毕的数据库:";
        /// <summary>
        /// 删除无用表
        /// </summary>
        public const string _Process_DelNonUseTable = "删除无用表:";
        /// <summary>
        /// 删除无用数据库拷贝：
        /// </summary>
        public const string _Process_DelNonUseDb = "删除无用数据库拷贝:";
        /// <summary>
        /// 打包下载文件
        /// </summary>
        public const string _Process_RarBackUpFile = "打包下载文件:";
        /// <summary>
        /// 写入配置文件
        /// </summary>
        public const string _Process_WriteConfig = "写入配置文件";
        /// <summary>
        /// 删减无用的数据库备份
        /// </summary>
        public const string _Process_DelNonuseDbBackUp = "删减无用的数据库备份";
        /// <summary>
        /// 清理无用数据
        /// </summary>
        public const string _Process_CleanNonUseData = "清理无用数据";
        /// <summary>
        /// 解析Rar数据
        /// </summary>
        public const string _Process_AnalyseRarData = "解析Rar数据";
        /// <summary>
        /// 检查所有数据库备份文件
        /// </summary>
        public const string _Process_CheckAllDbBackUp = "检查所有数据库备份文件";
        /// <summary>
        /// 检查所有数据库备份文件
        /// </summary>
        public const string _Process_RestoreTable = "还原表数据";

        #endregion

        //----------------------------------------------------------静态配置表
        /// <summary>
        /// 未在当前运行目录找到数据迁移的配置文件TransferConfig.xml
        /// </summary>
        public const string _Error_XmlConfig_NotExist = "未在当前运行目录找到数据迁移的配置文件：";
        /// <summary>
        /// 当前数据迁移的配置文件无法正确读取该文件物理地址是:
        /// </summary>
        public const string _Error_XmlConfig_NotFit = "当前的数据迁移的配置文件无法正确读取该文件物理地址是：";
        /// <summary>
        /// 当前数据迁移的配置文件中无法读取到以下关键字:
        /// </summary>
        public const string _Error_XmlConfigKey_NotExist = "当前的数据迁移的配置文件中无法读取到以下关键字：";
        /// <summary>
        /// 当前数据迁移的配置文件中以下关键字的配置为空:
        /// </summary>
        public const string _Error_XmlConfig_Exist_Empty = "当前数据迁移的配置文件中以下关键字的配置为空：";

        //----------------------------------------------------------硬盘操作
        /// <summary>
        /// 当前数据迁移的配置文件中以下配置有问题，因为TempDirectory文件夹会被程序清空造成重要数据丢失,无法在TempDirectory文件夹下配置BackUpDirectory或者DownloadFilesDirectory
        /// </summary>
        public const string _Error_DirectoryConfig_NotFit = "当前数据迁移的配置文件中以下配置有问题，因为TempDirectory文件夹会被程序清空造成重要数据丢失,无法在TempDirectory文件夹下配置BackUpDirectory或者DownloadFilesDirectory";
        /// <summary>
        /// 清空文件夹失败，原因是:
        /// </summary>
        public const string _Error_DirectoryDelete_Failed = "清空文件夹失败，原因是:";
        /// <summary>
        /// 无法完成完整的规则构建工作，由于当前运行环境中无法找到指定的文件，该文件是：
        /// </summary>
        public const string _Error_File_NotExist_Enviroment = "无法完成完整的规则构建工作，由于当前运行环境中无法找到指定的文件，该文件是：";
        /// <summary>
        /// 创建接口的实例失败，类库需要有一个指定名字(即配置文件中指定扩展类库的名字)的类来继承接口，否则程序无法定位到相关的文件，该类库是：
        /// </summary>
        public const string _Error_InstanceCreation_Failed = "创建接口的实例失败，类库需要有一个指定名字(即配置文件中指定扩展类库的名字)的类来继承接口，否则程序无法定位到相关的文件，该类库是：";
        /// <summary>
        /// 写配置文件失败，目标文件是：
        /// </summary>
        public const string _Error_WriteString_Failed = "写配置文件失败，目标文件是：";
        /// <summary>
        /// 读配置文件失败，目标文件是：
        /// </summary>
        public const string _Error_ReadConfig_Failed = "读配置文件失败，目标文件是：";
        /// <summary>
        /// 缩减文件夹时需要必须指定一个KeyWord
        /// </summary>
        public const string _Error_KeyWord_NotFit = "缩减文件夹时需要必须指定一个KeyWord";
        /// <summary>
        /// 根据文件创建时间排序失败，原因是:
        /// </summary>
        public const string _Error_OrderFile_Failed = "根据文件创建时间排序失败，原因是:";
        /// <summary>
        /// 在文件夹中删除指定文件，至少需要保护一个相关文件,该文件夹是：
        /// </summary>
        public const string _Error_DeleteFileFromDirectory_NeedOneFile = "在文件夹中删除指定文件，至少需要保护一个相关文件,该文件夹是：";


        //----------------------------------------------------------Sql操作
        /// <summary>
        /// 创建拷贝数据库时失败，原因是：
        /// </summary>
        public const string _Error_CopyDB_Failed = "创建拷贝数据库时失败,原因是：";
        /// <summary>
        /// 读取备份数据的逻辑名字失败
        /// </summary>
        public const string _Error_ReadLogicName_Failed = "读取备份数据的逻辑名字失败";
        /// <summary>
        /// 删除数据库失败，该数据库名为：
        /// </summary>
        public const string _Error_DropDb_Failed = "删除数据库失败，该数据库名为：";
        /// <summary>
        /// 读取表数据信息失败，该数据库与表名为：
        /// </summary>
        public const string _Error_ReadTable_Failed = "读取表数据信息失败，该数据库与表名为：";
        /// <summary>
        /// 读取表约束信息失败，该表为：
        /// </summary>
        public const string _Error_ReadConstraint_Failed = "读取表约束信息失败，该表为：";
        /// <summary>
        /// 不支持联合主键数据迁移，重建表约束失败，该表为:
        /// </summary>
        public const string _Error_ReConstraint_PkFailed = "由于不支持联合主键支持，重建表约束失败，该表为:";
        /// <summary>
        /// 不支持外键数据迁移，重建表约束失败，该表为:
        /// </summary>
        public const string _Error_ReConstraint_FkFailed = "不支持外键数据迁移，重建表约束失败，该表为:";
        /// <summary>
        /// 重建表约束失败，该表为:
        /// </summary>
        public const string _Error_ReConstraint_Failed = "重建表约束失败，该表为:";
        /// <summary>
        /// 放弃表约束失败，该表为:
        /// </summary>
        public const string _Error_DropConstraint_Failed =  "放弃表约束失败，该表为:";
        /// <summary>
        /// 备份数据库失败,该数据库与目标地址分别为：
        /// </summary>
        public const string _Error_BackUpDb_Failed = "备份数据库失败,该数据库与目标地址分别为：";
        /// <summary>
        /// 读取所有表信息失败，该数据库为：
        /// </summary>
        public const string _Error_GetAllTable_Failed = "读取所有表信息失败，该数据库为：";
        /// <summary>
        /// 删除所有外键失败，该数据库为：
        /// </summary>
        public const string _Error_DelAllFk_Failed = "删除所有外键失败，该数据库为：";

        //----------------------------------------------------------CommandRunner
        /// <summary>
        /// 无法找到Rar程序，默认寻找Rar的路径是：
        /// </summary>
        public const string _Error_Rar_NotFound = "Rar程序无法运行，默认寻找Rar的路径是：";
        /// <summary>
        /// 拷贝失败，目标文件已经存在，路径是：
        /// </summary>
        public const string _Error_File_Exist = "拷贝失败，目标文件已经存在，路径是：";
        /// <summary>
        /// 拷贝失败，源文件不存在，路径是：
        /// </summary>
        public const string _Error_File_NotExist = "拷贝失败，源文件不存在，路径是：";
        /// <summary>
        /// 拷贝出错，源地址与目标地址分别是：
        /// </summary>
        public const string _Error_Copy_Failed = "拷贝出错，源地址与目标地址分别是：";
        /// <summary>
        /// 清空文件夹出错，该文件夹是：
        /// </summary>
        public const string _Error_CleanDirectory_Failed = "清空文件夹出错，该文件夹是：";
        /// <summary>
        /// 删除指定文件出错，改文件的地址是：
        /// </summary>
        public const string _Error_DeleteFile_Failed = "删除指定文件出错，该文件的地址是：";
        /// <summary>
        /// 删除指定文件出错，无法在该路径下找到该文件：
        /// </summary>
        public const string _Error_DeleteFile_NotExist = "删除指定文件出错，无法在该路径下找到该文件：";
        /// <summary>
        /// 压缩文件夹失败：该文件夹为：
        /// </summary>
        public const string _Error_RarDirectory_Failed = "压缩文件夹失败：该文件夹为：";
        /// <summary>
        /// 解压缩文件失败：该文件为：
        /// </summary>
        public const string _Error_UnRarFile_Failed = "解压缩文件失败：该文件为：";
        /// <summary>
        /// 检验压缩文件名失败，应该以rar为后缀，而该文件名是：
        /// </summary>
        public const string _Error_CheckRarFileName_Failed = "检验压缩文件名失败，应该以rar为后缀，而该文件名是：";

        //----------------------------------------------------------Model_TransferRule
        /// <summary>
        /// 当前数据迁移的配置文件中TransferRule节点下有规则名为空，无法完成转换工作
        /// </summary>
        public const string _Error_XmlConfig_TransferRule_KeyEmpty = "当前数据迁移的配置文件中TransferRule节点下有规则名为空，无法完成转换工作";
        /// <summary>
        /// 当前数据迁移的配置文件中的TransferRule节点下无法正确读取数据库名，该规则的名字是:
        /// </summary>
        public const string _Error_XmlConfig_DbName_NotFit = "当前数据迁移的配置文件中的TransferRule节点下无法正确读取数据库名，该规则的名字是:";
        /// <summary>
        /// 当前数据迁移的配置文件中的TransferRule节点下无法正确读取表名或者过滤规则，该规则的名字是:
        /// </summary>
        public const string _Error_XmlConfig_TableName_NotFit = "当前数据迁移的配置文件中的TransferRule节点下无法正确读取表名，该规则的名字是:";
        /// <summary>
        /// 根据当前数据迁移的配置文件读取的规则不正确，以下分别是2个规则的字符串：
        /// </summary>
        public const string _Error_XmlConfig_Read_NotFit = "根据当前数据迁移的配置文件读取的规则不正确，以下分别是2个规则的字符串：";
        /// <summary>
        /// 读取自定义迁移配置出错，已经有相关的表定义在了迁移表中或者保护表中，该数据库、表名分别为：
        /// </summary>
        public const string _Error_DefineTransfer_Exist_Table = "读取自定义迁移配置出错，已经有相关的表定义在了迁移表中或者保护表中，该数据库、表名分别为：";
        /// <summary>
        /// 备份筛选完的数据库失败，在指定目录已经有该数据库存在，可能是由于上一次的备份工作没有正确完成所致
        /// </summary>
        public const string _Error_ExistTargetBackUpDb = "备份筛选完的数据库失败，在指定目录已经有该数据库存在，可能是由于上一次的备份工作没有正确完成所致";


        //----------------------------------------------------------TransferService
        /// <summary>
        /// 无法运行当前的迁移数据进程，已经有一个相关线程正在运行，请稍等再试
        /// </summary>
        public const string _Error_RunningFlag_NotFit = "无法运行当前的迁移数据进程，已经有一个相关线程正在运行，请稍等再试";
        /// <summary>
        /// 分析Rar压缩文件中的迁移规则失败，请确保从主系统下载下来的rar文件没有被修改过
        /// </summary>
        public const string _Error_AnalyseRarData_Error = "分析Rar压缩文件中的迁移规则失败，请确保从主系统下载下来的rar文件没有被修改过";



        //----------------------------------------------------------NullTableFilter
        /// <summary>
        /// 丢弃表失败,该表名是：
        /// </summary>
        public const string _Error_DropTable_Failed = "丢弃表失败,该表名是：";
        /// <summary>
        /// 复制表失败,该表名是：
        /// </summary>
        public const string _Error_CopyTable_Failed = "复制表失败,该表名是：";


        //----------------------------------------------------------TransferConfig
        /// <summary>
        /// 无法完成配置文件的创建，由于规则为空
        /// </summary>
        public const string _Error_TransferRule_NotNull = "无法完成配置文件的创建，由于规则为空";
        /// <summary>
        ///无法读取配置文件，未在配置文件中找到相应的配置键，该键是：
        /// </summary>
        public const string _Error_Key_NotFound = "无法读取配置文件，未在配置文件中找到相应的配置键，该键是：";
        /// <summary>
        /// 无法准确读取配置文件中的时间参数，该字符串为：
        /// </summary>
        public const string _Error_Parameter_ReadError = "无法准确读取配置文件中的时间参数，该字符串为：";


        //----------------------------------------------------------TransferRule
        /// <summary>
        /// 还原数据失败，执行清理工作中出现了错误，该还原规则与出错的原因分别是：
        /// </summary>
        public const string _Error_CleanUpRestoreData = "还原数据失败，执行清理工作中出现了错误，该还原规则与出错的原因分别是：";
        /// <summary>
        /// 备份数据失败，执行清理工作中出现了错误，该还原规则与出错的原因分别是：
        /// </summary>
        public const string _Error_CleanUpBackUpData = "备份数据失败，执行清理工作中出现了错误，该还原规则与出错的原因分别是：";


        //----------------------------------------------------------TransferDataLog
        /// <summary>
        /// 无法完成日志对象的创建，可能是由于无法找到相应的配置文件所致，该错误详情是：
        /// </summary>
        public const string _Error_LogConfig_NotExits = "无法完成日志对象的创建，可能是由于无法找到相应的配置文件所致，该错误详情是：";
    }
}