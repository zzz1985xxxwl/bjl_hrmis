//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ContractType.cs
// 创建者: 杨俞彬
// 创建日期: 2008-05-12
// 概述: 参数
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class Parameter
    {
        private int _ParameterID;
        private string _Name;
        private string _Description;
        public Parameter(int parameterID, string name, string description)
        {
            _ParameterID = parameterID;
            _Name = name;
            _Description = description;
        }

        public int ParameterID
        {
            get
            {
                return _ParameterID;
            }
            set
            {
                _ParameterID = value;
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
        public static string GetParameterNameByType(ParameterTypeEnum parameterTypeEnum)
        {
            switch (parameterTypeEnum)
            {
                case ParameterTypeEnum.ContractType:
                    return "合同类型";
                case ParameterTypeEnum.Position:
                    return "职位";
                case ParameterTypeEnum.LeaveRequestType:
                    return "请假类型";
                case ParameterTypeEnum.SkillType:
                    return "技能类型";
                case ParameterTypeEnum.TrainFBQuesType:
                    return "反馈问题类型";
                default:
                    return "";
            }
        }

        #region 重写Equals

        public override bool Equals(object obj)
        {
            Parameter anOtherObj = obj as Parameter;
            if (anOtherObj == null)
            {
                return false;
            }
            return Name.Equals(anOtherObj.Name);
        }


        public int HashCode
        {
            get
            {
                return GetHashCode();
            }
        }

        #endregion
    }
}