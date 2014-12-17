//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IParameter.cs
// 创建者: 张燕
// 创建日期: 2008-05-21
// 概述: 系统参数
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IParameter
    {
        #region FBQuesType
        int InsertFBQuesType(TrainFBQuesType obj);
        int UpdateFBQuesType(TrainFBQuesType obj);
        int DeleteFBQuesType(int pkid);

        int CountFBQuesTypeByName(string Name);
        int CountFBQuesTypeByNameDiffPKID(int pkid, string Name);
        TrainFBQuesType GetTrainFBQuesTypeByPKID(int pkid);
        List<TrainFBQuesType> GetTrainFBQuesTypeByCondition(int pkid, string name);
        #endregion

        #region SkillType
        int InsertSkillType(SkillType obj);
        int UpdateSkillType(SkillType obj);
        int DeleteSkillType(int skillId);

        int CountSkillTypeByName(string SkillTypeName);
        int CountSkillTypeByNameDiffPKID(int pkid, string Name);
        SkillType GetSkillTypeByPkid(int pkid);
        List<SkillType> GetSkillTypeByCondition(int pkid, string name);

        #endregion

        #region Nationality
        int InsertNationality(Nationality obj);
        int UpdateNationality(Nationality obj);
        int DeleteNationality(int pkid);
        int CountNationalityByName(string Name);
        int CountNationalityByNameDiffPKID(int pkid, string Name);
        Nationality GetNationalityByPKID(int pkid);
        List<Nationality> GetNationalityByCondition(int pkid, string name);
        #endregion
    }
}
