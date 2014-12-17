//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: IPositionDal.cs
// ������: colbert
// ��������: 2009-02-02
// ����: ְλ�־ò�ӿ�
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.Positions;
using SEP.Model.Departments;

namespace SEP.IDal.Positions
{
    /// <summary>
    /// ְλ�־ò�ӿ�
    /// </summary>
    public interface IPositionDal
    {
        void InsertPosition(Position obj);
        void UpdatePosition(Position obj);
        void DeletePosition(int id);

        List<Position> GetAllPosition();
        Position GetPositionById(int id);
        Position GetPositionByName(string name);
        bool IsExistPosition(int id);

        void InsertPositionGrade(PositionGrade obj);
        void UpdatePositionGrade(PositionGrade obj);
        void DeletePositionGrade(int id);

        List<PositionGrade> GetAllPositionGrade();
       PositionGrade GetPositionGradeById(int id);
      
        PositionGrade GetPositionGradeByName(string name);

        List<Position> GetPositionByGradeId(int positionGradeId);
        bool HasUsing(int positionGradeId);
        List<Position> GetPositionByCondition(string nameLike, int levelId);
     
        List<Position> GetPositionByCondition(string sql);
        void InsertPositionNature(PositionNature obj);
        void UpdatePositionNature(PositionNature obj);
        void DeletePositionNature(int id);
        List<Department> GetPositionDeptByPositionID(int id);

        List<PositionNature> GetAllPositionNature();
        List<PositionNature> GetPositionNatureByPositionID(int id);
        List<PositionNature> GetPositionNatureListByName(string name);
        PositionNature GetPositionNatureById(int id);
        int CountPositionByNatureId(int positionNatureId);
        int CountPositionNatureByNameDiffPKID(int pkid, string name);
    }
}
