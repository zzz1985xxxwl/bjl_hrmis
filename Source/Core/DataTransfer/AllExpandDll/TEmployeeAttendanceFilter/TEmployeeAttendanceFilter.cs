using System;
using System.Collections.Generic;
using TransferDatas;

namespace TEmployeeAttendanceFilter
{
    public class TEmployeeAttendanceFilter : TableFilterTemplate
    {
        public override bool GetNeedTimeFilter()
        {
            return true;
        }

        protected override TableFilterTemplate DefineNewObj()
        {
            return new TEmployeeAttendanceFilter();
        }

        protected override string DefineTheMainTableFilterCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("delete from {0} where not (TheDay >= '{1}' and TheDay <= '{2}')", _MainTable, fromDay.Value, toDay.Value);
        }

        protected override string DefineTheMainTableSelectCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("select pkid from {0} where  TheDay >= '{1}' and TheDay <= '{2}'", _MainTable, fromDay.Value, toDay.Value);
        }

        protected override Dictionary<string, string> DefineProtectedTableFkColumnName()
        {
            return new Dictionary<string, string>();
        }

        protected override string DefineOperationString()
        {
            return "根据时间筛选主表:";
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
