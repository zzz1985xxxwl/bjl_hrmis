using System;
using System.Collections.Generic;
using TransferDatas;

namespace TOutApplicationFilter
{
    public class TOutApplicationItemFilter : TableFilterTemplate
    {
        private const string _ErrorNoValue = "未设置二层筛选需要的表名与标识";
        private const string _ErrorNoReleatedTable = "没有在传递的表/标识集合的对中找到相关的表，该表是：";
        private const string _ProtectedTable = "TOutApplicationFlow";

        private Dictionary<string, List<int>> _AfterBackTableAndIds;
        private Dictionary<string, List<int>> _BeforeRestoreTableAndIds;

        public override bool GetNeedTimeFilter()
        {
            return false;
        }

        protected override TableFilterTemplate DefineNewObj()
        {
            return new TOutApplicationItemFilter();
        }

        protected override string DefineTheMainTableFilterCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("delete from {0} where pkid not in ({1})", _MainTable, MakePkidStrings(GetIdsByTableName(AfterBackTableAndIds, _MainTable)));
        }

        protected override string DefineTheMainTableSelectCommand(DateTime? fromDay, DateTime? toDay)
        {
            return string.Format("select pkid from {0} where pkid in ({1})", _MainTable, MakePkidStrings(GetIdsByTableName(BeforeRestoreTableAndIds, _MainTable)));
        }

        protected override Dictionary<string, string> DefineProtectedTableFkColumnName()
        {
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            retVal.Add(_ProtectedTable, "OutApplicationItemID");
            return retVal;
        }

        protected override string DefineOperationString()
        {
            return string.Format("二层筛选表：{0}", _ProtectedTable);
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

        public Dictionary<string, List<int>> AfterBackTableAndIds
        {
            get
            {
                if (_AfterBackTableAndIds == null)
                {
                    throw new ApplicationException(_ErrorNoValue);
                }
                return _AfterBackTableAndIds;
            }
            set
            {
                _AfterBackTableAndIds = value;
            }
        }

        public Dictionary<string, List<int>> BeforeRestoreTableAndIds
        {
            get
            {
                if (_BeforeRestoreTableAndIds == null)
                {
                    throw new ApplicationException(_ErrorNoValue);
                }
                return _BeforeRestoreTableAndIds;
            }
            set
            {
                _BeforeRestoreTableAndIds = value;
            }
        }

        public List<int> GetIdsByTableName(Dictionary<string, List<int>> theTablesAndIds, string tableName)
        {
            if (theTablesAndIds.ContainsKey(tableName))
            {
                return theTablesAndIds[tableName];
            }
            else
            {
                throw new ApplicationException(_ErrorNoReleatedTable + tableName);
            }
        }
    }
}