using System;
using System.Collections.Generic;

namespace TransferDatas
{
    public class NullTableFilter : ITableFilter
    {
        private TransferRule _TheRule;
        // 主表名
        private string _MainTable;
        //数据源的数据库名(主系统的数据库名)
        private string _OrginDbName;
        //数据源源的拷贝数据库名(拷贝主系统的数据库名)
        private string _OrginCopyDbName;
        //需要迁移的数据库名(从系统的数据库名)
        private string _RestoreDbName;
        //主系统拷贝数据库在从系统上的拷贝
        private string _ForRestoreCopyDbName;

        #region ITableFilter 成员

        public bool GetNeedTimeFilter()
        {
            return false;
        }

        public void ConfigTheFilter(TransferRule theRule, string mainTableName, string orginDbName, string orginCopyDbName, string restoreDbName, string forRestoreCopyDbName)
        {
            _MainTable = mainTableName;
            _TheRule = theRule;
            _OrginDbName = orginDbName;
            _OrginCopyDbName = orginCopyDbName;
            _RestoreDbName = restoreDbName;
            _ForRestoreCopyDbName = forRestoreCopyDbName;
        }

        public string FilterTableData(DateTime? fromDay, DateTime? toDay)
        {
            int allCount = SqlCommandRunner.GetTableRowCount(_MainTable, _OrginDbName);
            return string.Format("--表{0}共计:总行数{1}，删减0行数据", _MainTable, allCount);
        }

        public string RestoreTableData(DateTime? fromDay, DateTime? toDay)
        {
            List<ConstraintInfo> backUpConstraintInfo = SqlCommandRunner.GetConstraintInfo(_MainTable, _RestoreDbName);
            SqlCommandRunner.DropTable(_MainTable, _RestoreDbName);
            SqlCommandRunner.CopyTable(_MainTable, _ForRestoreCopyDbName, _RestoreDbName);
            SqlCommandRunner.RestoreConstraintInfo(backUpConstraintInfo, _MainTable, _RestoreDbName);
            
            return string.Format("--表{0}共计:覆盖所有数据", _MainTable);
        }

        #endregion

        #region ICloneable 成员

        public object Clone()
        {
            NullTableFilter aCloneObj = new NullTableFilter();
            aCloneObj._ForRestoreCopyDbName = _ForRestoreCopyDbName;
            aCloneObj._MainTable = _MainTable;
            aCloneObj._OrginCopyDbName = _OrginCopyDbName;
            aCloneObj._OrginDbName = _OrginDbName;
            aCloneObj._RestoreDbName = _RestoreDbName;
            //这里的克隆有点特殊,在方法ConfigTheFilter后，该克隆将不会完全复制本身
            aCloneObj._TheRule = null;
            return aCloneObj;
        }

        public override string ToString()
        {
            return "全覆盖式操作";
        }

        #endregion
    }
}