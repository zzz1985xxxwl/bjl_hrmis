using System;
using System.Data.SqlClient;

namespace TransferDatas
{
    public class ConstraintInfo
    {
        //���ݿⳣ��
        private const string _ColumnNameDefine = "COLUMN_NAME";
        private const string _ConstraintNameDefine = "CONSTRAINT_NAME";
        private const string _ConstraintTypeDefine = "CONSTRAINT_TYPE";
        private const string _PrimaryKey = "PRIMARY KEY";
        private const string _Unique = "UNIQUE";

        private string _TableName;
        private string _ColumnNameValue;
        private string _ConstraintNameValue;
        private string _ConstraintTypeValue;

        #region ����

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

        #region ����

        /// <summary>
        /// �����ݿ�Reader�н���Ҫ��Լ����Ϣ��ȡ����
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
        /// ����Ϣ��װ��Sql�������ڻ�ԭԼ��(��֧�����)
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
        /// ����Ϣ��װ��Sql�������ڷ���Լ��(֧�����)
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
                throw new ApplicationException(string.Format("{0}{1},ԭ����:ָ����Ҫ��ԭ�ı�����洢�ı�����һ��", Utility._Error_ReConstraint_Failed, tableName));
            }
        }

        #endregion

        #region ��д����

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
            return string.Format("����:{0}������:{1}��Լ����:{2}��Լ������:{3}", _TableName, _ColumnNameValue, _ConstraintNameValue, _ConstraintTypeValue);
        }

        #endregion

    }
}