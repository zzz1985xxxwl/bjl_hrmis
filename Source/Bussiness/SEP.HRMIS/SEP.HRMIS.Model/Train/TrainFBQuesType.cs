//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: TrainFBQuesType.cs
// ������: ����
// ��������: 2008-11-05
// ����: ������������
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model
{
    ///<summary>
    /// ��ѵ������������
    ///</summary>
    [Serializable]
    public class TrainFBQuesType : Parameter
    {

        ///<summary>
        ///</summary>
        ///<param name="FBQuesTypeID"></param>
        ///<param name="FBQuesTypeName"></param>
        public TrainFBQuesType(int FBQuesTypeID, string FBQuesTypeName)
            : base(FBQuesTypeID, FBQuesTypeName, "")
        {
        }

       
    }
}

