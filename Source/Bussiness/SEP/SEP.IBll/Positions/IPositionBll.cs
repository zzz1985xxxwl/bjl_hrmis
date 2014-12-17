//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: IPositionBll.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 职位业务接口
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Positions;

namespace SEP.IBll.Positions
{
    public interface IPositionBll
    {
        void CreatePosition(Position position, Account loginUser);
        void UpdatePosition(Position position, Account loginUser);
        void DeletePosition(int positionId, Account loginUser);

        void CreatePositionGrade(PositionGrade positionGrade, Account loginUser);
        void UpdatePositionGrade(PositionGrade positionGrade, Account loginUser);
        void DeletePositionGrade(int positionGradeId, Account loginUser);

        /// <summary>
        /// 获取所有职位
        /// </summary>
        List<Position> GetAllPosition(Account loginUser);

        /// <summary>
        /// 按职位名称获取职位信息
        /// </summary>
        Position GetPositionByName(string name, Account loginUser);

        /// <summary>
        /// 按职位Id获取职位信息
        /// </summary>
        Position GetPositionById(int id, Account loginUser);

        /// <summary>
        /// 获取所有职位等级
        /// </summary>
        List<PositionGrade> GetAllPositionGrade(Account loginUser);

        /// <summary>
        /// 按职位等级Id获取职位等级信息
        /// </summary>
        PositionGrade GetPositionGradeById(int id, Account loginUser);

        /// <summary>
        /// 按职位等级名称获取职位等级信息
        /// </summary>
        PositionGrade GetPositionGradeByName(string name, Account loginUser);

        /// <summary>
        /// 获取该等级的所有职位
        /// </summary>
        List<Position> GetPositionByGrade(int positionGradeId, Account loginUser);


        /// <summary>
        /// 获取所有职位
        /// </summary>
        List<Position> GetAllPosition();
        /// <summary>
        /// 获取某等级的所有职位
        /// </summary>
        List<Position> GetPositionByGrade(int gradeId);
        /// <summary>
        /// 获取所有职位等级
        /// </summary>
        List<PositionGrade> GetAllPositionGrade();

        List<Position> GetPositionByCondition(string nameLike, int levelId);
        List<Position> GetPositionByCondition(string sql);
        void SavePositionGradeList(List<PositionGrade> grades, List<int> delItems, Account loginUser);
        bool HasUsing(int positionGradeId);


        void CreatePositionNature(PositionNature position);
        void UpdatePositionNature(PositionNature position);
        void DeletePositionNature(int id);
        PositionNature GetPositionNatureById(int id);
        List<PositionNature> GetAllPositionNature();
        List<PositionNature> GetPositionNatureListByName(string name);
        List<Position> GetPositionByLeaderID(int employeeID);
    }
}
