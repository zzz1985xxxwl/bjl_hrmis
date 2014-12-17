//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: PositionGrade.cs
// ������: colbert
// ��������: 2009-02-02
// ����: ְλ�ȼ�
// ----------------------------------------------------------------

using System;

namespace SEP.Model.Positions
{
    /// <summary>
    /// ְλ�ȼ�
    /// </summary>
    [Serializable]
    public class PositionGrade
    {
        public PositionGrade(int id, string name, string description)
        {
            _Id = id;
            _Name = name;
            _Description = description;
        }
        public PositionGrade()
        {
        }
        #region

        private int _Id;
        private string _Name;
        private int _Sequence;
        private string _Description;

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        public int Sequence
        {
            get
            {
                return _Sequence;
            }
            set
            {
                _Sequence = value;
            }
        }
        //todo noted by wsl transfer waiting for modify
        public int ParameterID
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        #endregion
    }
}
