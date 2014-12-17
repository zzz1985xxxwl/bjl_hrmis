//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ParameterBase.cs
// ������: �ߺ�
// ��������: 2008-08-27
// ����: Ӳ����Ĳ����Ļ���
// ----------------------------------------------------------------

using System;

namespace SEP.Model
{
    [Serializable]
    public class ParameterBase
    {
        private int _Id;
        private string _Name;

        public ParameterBase(int id, string name)
        {
            _Id = id;
            _Name = name;
        }

        public int Id
        {
            get { return _Id; }
        }

        public string Name
        {
            get { return _Name; }
        }

        #region ��дEquals

        public override bool Equals(object obj)
        {
            ParameterBase anOtherObj = obj as ParameterBase;
            if (anOtherObj == null)
            {
                return false;
            }

            return _Id.Equals(anOtherObj._Id) &&
                   _Name.Equals(anOtherObj._Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        #endregion
    }
}