using System;
using System.Data.SqlClient;

namespace TransferDatas
{
    public class ConstraintInfo
    {
        //数据库常量
        private const string _ColumnNameDefine = "COLUMN_NAME";
        private const string _ConstraintNameDefine = "CONSTRAINT_NAME";
        private const string _ConstraintTypeDefine = "CONSTRAINT_TYPE";
        private const string _PrimaryKey = "PRIMARY KEY";
        private const string _Unique = "UNIQUE";

        private string _TableName;
        private string _ColumnNameValue;
        private string _ConstraintNameValue;
        private string _ConstraintTypeValue;

        #region 属性

        public string ColumnNameValue
        {
            get
            {
                return _ColumnNameValue;
            }
            set
            {
                _ColumnNameValue = value;
            }
        }

        public string ConstraintNameValue
        {
            get
            {
                return _ConstraintNameValue;
            }
            set
            {
                _ConstraintNameValue = value;
            }
        }

        public string ConstraintTypeValue
        {
            get
            {
                return _ConstraintTypeValue;
            }
            set
            {
                _ConstraintTypeValue = value;
            }
        }

        public string TableName
        {
            get
            {
                return _TableName;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 从数据库Reader中将需要的约束信息提取出来
        /// </summary>
        public void ReadFromData(SqlDataReader sdr,string tableName)
        {
            _TableName = tableName;
            _ColumnNameValue = sdr[_ColumnNameDefine].ToString();
            _ConstraintNameValue = sdr[_ConstraintNameDefine].ToString();
            _ConstraintTypeValue = sdr[_ConstraintTypeDefine].ToString();

            Utility.AssertStringNotEmpty(_ColumnNameValue, string.Format("{0}{1}", Utility._Error_ReadConstraint_Failed, tableName));
            Utility.AssertStringNotEmpty(_ConstraintNameValue, string.Format("{0}{1}", Utility._Error_ReadConstraint_Failed, tableName));
            Utility.AssertStringNotEmpty(_ConstraintTypeValue, string.Format("{0}{1}", Utility._Error_ReadConstraint_Failed, tableName));
        }

        /// <summary>
        /// 将信息组装成Sql命令用于还原约束(不支持外键)
        /// </summary>
        public string MakeRestoreConstraintCommand(string tableName)
        {
            CheckTableName(tableName);
            if (_ConstraintTypeValue == _PrimaryKey || _ConstraintTypeValue == _Unique)
            {
                return string.Format(@"alter table {0} add CONSTRAINT {1} {2} NONCLUSTERED ({3}) ", TableName, _ConstraintNameValue, _ConstraintTypeValue, _ColumnNameValue);
            }
            else
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_ReConstraint_FkFailed, _TableName));
            }
        }

        /// <summary>
        /// 将信息组装成Sql命令用于放弃约束(支持外键)
        /// </summary>
        public string MakeDropConstraintCommand(string tableName)
        {
            CheckTableName(tableName);
            return string.Format(@"alter table {0} drop CONSTRAINT {1} ", TableName, _ConstraintNameValue);
        }

        private void CheckTableName(string tableName)
        {
            if (tableName != _TableName)
            {
                throw new ApplicationException(string.Format("{0}{1},原因是:指定需要还原的表名与存储的表名不一致", Utility._Error_ReConstraint_Failed, tableName));
            }
        }

        #endregion

        #region 重写方法

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(ConstraintInfo)) return false;
            return Equals((ConstraintInfo)obj);
        }

        public bool Equals(ConstraintInfo obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj._TableName, _TableName) && Equals(obj._ColumnNameValue, _ColumnNameValue) && Equals(obj._ConstraintNameValue, _ConstraintNameValue) && Equals(obj._ConstraintTypeValue, _ConstraintTypeValue);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (_TableName != null ? _TableName.GetHashCode() : 0);
                result = (result*397) ^ (_ColumnNameValue != null ? _ColumnNameValue.GetHashCode() : 0);
                result = (result*397) ^ (_ConstraintNameValue != null ? _ConstraintNameValue.GetHashCode() : 0);
                result = (result*397) ^ (_ConstraintTypeValue != null ? _ConstraintTypeValue.GetHashCode() : 0);
                return result;
            }
        }

        public override string ToString()
        {
            return string.Format("表名:{0}，列名:{1}，约束名:{2}，约束类型:{3}", _TableName, _ColumnNameValue, _ConstraintNameValue, _ConstraintTypeValue);
        }

        #endregion

    }
}