using System;
using System.Collections.Generic;
using TransferDatas;

namespace TApplicationFilter
{
    public class TApplicationFilter : TableFilterTemplate
    {
        private const string _ProtectedTableName1 = "TApplicationEmployee";
        private const string _ProtectedTableName2 = "TApplicationFlow";

        public override bool GetNeedTimeFilter()
        {
            return true;
        }

        protected override TableFilterTemplate DefineNewObj()
        {
            return new TApplicationFilter();
        }

        protected override string DefineTheMainTableFilterCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("delete from {0} where applicationFrom < '{1}' or applicationFrom > '{2}'", _MainTable, fromDay.Value.ToShortDateString(), toDay.Value.ToShortDateString());
        }

        protected override string DefineOperationString()
        {
            return string.Format("根据时间筛选主表，根据外键删选表：{0}、{1}", _ProtectedTableName1, _ProtectedTableName2);
        }

        protected override Dictionary<string, string> DefineProtectedTableFkColumnName()
        {
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            retVal.Add(_ProtectedTableName1, "applicationid");
            retVal.Add(_ProtectedTableName2, "applicationid");

            return retVal;
        }

        protected override string DefineTheMainTableSelectCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("select pkid from {0} where applicationFrom >= '{1}' and applicationFrom <= '{2}'", _MainTable, fromDay.Value.ToShortDateString(), toDay.Value.ToShortDateString());
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