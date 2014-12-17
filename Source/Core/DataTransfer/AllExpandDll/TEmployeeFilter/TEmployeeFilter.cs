using System;
using System.Collections.Generic;
using TransferDatas;

namespace TEmployeeFilter
{
    public class TEmployeeFilter : TableFilterTemplate
    {
        public override bool GetNeedTimeFilter()
        {
            return false;
        }

        protected override TableFilterTemplate DefineNewObj()
        {
            return new TEmployeeFilter();
        }

        protected override string DefineTheMainTableFilterCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("update {0} set photo = null", _MainTable);
        }

        protected override string DefineTheMainTableSelectCommand(DateTime? fromDay, DateTime? toDay)
        {
             return string.Format("select pkid from {0}", _MainTable);
        }

        protected override Dictionary<string, string> DefineProtectedTableFkColumnName()
        {
            return new Dictionary<string, string>();
        }

        protected override string DefineOperationString()
        {
            return "覆盖式同步主表(不同步照片数据)";
        }

        protected override string AfterBackUpMainProcess(Dictionary<string, List<int>> tablesAndIds, DateTime? startDay, DateTime? endDay)
        {
            return string.Empty;
        }

        protected override string BeforeRestoreMainProcess(Dictionary<string, List<int>> orginTablesAndIds, DateTime? startDay, DateTime? endDay)
        {
            return string.Empty;
        }

        public override void AfterConfigTheFilter(TransferRule theRule, string orginDbName, string orginCopyDbName, string restoreDbName, string forRestoreCopyDbName)
        {
        }
    }
}
