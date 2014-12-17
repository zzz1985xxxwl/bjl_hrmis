//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: IPositionBll.cs
// ������: colbert
// ��������: 2009-02-02
// ����: ְλҵ��ӿ�
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
        /// ��ȡ����ְλ
        /// </summary>
        List<Position> GetAllPosition(Account loginUser);

        /// <summary>
        /// ��ְλ���ƻ�ȡְλ��Ϣ
        /// </summary>
        Position GetPositionByName(string name, Account loginUser);

        /// <summary>
        /// ��ְλId��ȡְλ��Ϣ
        /// </summary>
        Position GetPositionById(int id, Account loginUser);

        /// <summary>
        /// ��ȡ����ְλ�ȼ�
        /// </summary>
        List<PositionGrade> GetAllPositionGrade(Account loginUser);

        /// <summary>
        /// ��ְλ�ȼ�Id��ȡְλ�ȼ���Ϣ
        /// </summary>
        PositionGrade GetPositionGradeById(int id, Account loginUser);

        /// <summary>
        /// ��ְλ�ȼ����ƻ�ȡְλ�ȼ���Ϣ
        /// </summary>
        PositionGrade GetPositionGradeByName(string name, Account loginUser);

        /// <summary>
        /// ��ȡ�õȼ�������ְλ
        /// </summary>
        List<Position> GetPositionByGrade(int positionGradeId, Account loginUser);


        /// <summary>
        /// ��ȡ����ְλ
        /// </summary>
        List<Position> GetAllPosition();
        /// <summary>
        /// ��ȡĳ�ȼ�������ְλ
        /// </summary>
        List<Position> GetPositionByGrade(int gradeId);
        /// <summary>
        /// ��ȡ����ְλ�ȼ�
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
