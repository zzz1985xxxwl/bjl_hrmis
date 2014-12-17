using System;
using TransferDatas;

namespace AccountFilter
{
    public class AccountFilter:ITableFilter
    {
        #region ITableFilter 成员

        public bool GetNeedTimeFilter()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ConfigTheFilter(TransferRule theRule, string mainTableName, string orginDbName, string orginCopyDbName, string restoreDbName, string forRestoreCopyDbName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string RestoreTableData(DateTime? fromDay, DateTime? toDay)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string FilterTableData(DateTime? fromDay, DateTime? toDay)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region ICloneable 成员

        public object Clone()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
