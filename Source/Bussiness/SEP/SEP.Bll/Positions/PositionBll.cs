using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Positions;
using SEP.IBll.Positions;
using SEP.Bll.Positions;

namespace SEP.Bll
{
    internal class PositionBll : IPositionBll
    {
        #region IPositionBll 成员

        public void CreatePosition(Position position, Account loginUser)
        {
            AddPosition addPosition = new AddPosition(position, loginUser);
            addPosition.Excute();
        }

        public void UpdatePosition(Position position, Account loginUser)
        {
            UpdatePosition updatePosition = new UpdatePosition(position, loginUser);
            updatePosition.Excute();
        }

        public void DeletePosition(int positionId, Account loginUser)
        {
            DeletePosition deletePosition = new DeletePosition(positionId, loginUser);
            deletePosition.Excute();
        }

        public void CreatePositionGrade(PositionGrade positionGrade, Account loginUser)
        {
            AddPositionGrade addPositionGrade = new AddPositionGrade(positionGrade, loginUser);
            addPositionGrade.Excute();
        }

        public void UpdatePositionGrade(PositionGrade positionGrade, Account loginUser)
        {
            UpdatePositionGrade updatePositionGrade = new UpdatePositionGrade(positionGrade, loginUser);
            updatePositionGrade.Excute();
        }

        public void DeletePositionGrade(int positionGradeId, Account loginUser)
        {
            DeletePositionGrade deletePositionGrade = new DeletePositionGrade(positionGradeId, loginUser);
            deletePositionGrade.Excute();
        }

        public List<Position> GetAllPosition(Account loginUser)
        {
            return DalInstance.PositionDalInstance.GetAllPosition();
        }

        public Position GetPositionByName(string name, Account loginUser)
        {
            return DalInstance.PositionDalInstance.GetPositionByName(name);
        }

        public Position GetPositionById(int id, Account loginUser)
        {
            Position position = DalInstance.PositionDalInstance.GetPositionById(id);
            if (position != null)
            {
                position.Departments = DalInstance.PositionDalInstance.GetPositionDeptByPositionID(id);
                position.Nature = DalInstance.PositionDalInstance.GetPositionNatureByPositionID(id);
                position.Members = new AccountBll().GetAccountByBaseCondition("", -1, id,null, false, true);
            }

            return position;
            //return DalInstance.PositionDalInstance.GetPositionById(id);
        }

        public List<PositionGrade> GetAllPositionGrade(Account loginUser)
        {
            return DalInstance.PositionDalInstance.GetAllPositionGrade();
        }

        public PositionGrade GetPositionGradeById(int id, Account loginUser)
        {
            return DalInstance.PositionDalInstance.GetPositionGradeById(id);
        }

        public PositionGrade GetPositionGradeByName(string name, Account loginUser)
        {
            return DalInstance.PositionDalInstance.GetPositionGradeByName(name);
        }

        public List<Position> GetPositionByGrade(int positionGradeId, Account loginUser)
        {
            return DalInstance.PositionDalInstance.GetPositionByGradeId(positionGradeId);
        }

        public List<Position> GetAllPosition()
        {
            return DalInstance.PositionDalInstance.GetAllPosition();
        }

        public List<Position> GetPositionByGrade(int gradeId)
        {
            return DalInstance.PositionDalInstance.GetPositionByGradeId(gradeId);
        }

        public List<PositionGrade> GetAllPositionGrade()
        {
            return DalInstance.PositionDalInstance.GetAllPositionGrade();
        }

        public List<Position> GetPositionByCondition(string nameLike, int levelId)
        {
            return DalInstance.PositionDalInstance.GetPositionByCondition(nameLike, levelId);
        }
        public List<Position> GetPositionByCondition(string sql)
        {
            return DalInstance.PositionDalInstance.GetPositionByCondition(sql);
        }


        public void SavePositionGradeList(List<PositionGrade> grades, List<int> delItems, Account loginUser)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    foreach (int i in delItems)
                    {
                        DeletePositionGrade(i, loginUser);
                    }
                    for (int i = 0; i < grades.Count; i++)
                    {
                        grades[i].Sequence = i;
                        if (grades[i].Id == -1)
                        {
                            CreatePositionGrade(grades[i], loginUser);
                        }
                        else
                        {
                            UpdatePositionGrade(grades[i], loginUser);
                        }
                    }
                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw MessageKeys.AppException(ex.Message);
            }

        }

        public bool HasUsing(int positionGradeId)
        {
            return DalInstance.PositionDalInstance.HasUsing(positionGradeId);
        }


        public void CreatePositionNature(PositionNature position)
        {
            AddPositionNature addPositionNature = new AddPositionNature(position);
            addPositionNature.Excute();
        }

        public void UpdatePositionNature(PositionNature position)
        {
            UpdatePositionNature updatePositionNature = new UpdatePositionNature(position);
            updatePositionNature.Excute();
        }

        public void DeletePositionNature(int id)
        {
            DeletePositionNature deletePosition = new DeletePositionNature(id);
            deletePosition.Excute();
        }

        public List<PositionNature> GetAllPositionNature()
        {
            return DalInstance.PositionDalInstance.GetAllPositionNature();
        }

        public List<PositionNature> GetPositionNatureListByName(string name)
        {
            return DalInstance.PositionDalInstance.GetPositionNatureListByName(name);
        }

        public PositionNature GetPositionNatureById(int id)
        {
            return DalInstance.PositionDalInstance.GetPositionNatureById(id);
        }

        /// <summary>
        /// 获取Leader领导的所有员工的职位，包括自己
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public List<Position> GetPositionByLeaderID(int employeeID)
        {
            List<Position> retpositions = new List<Position>();
            Account account = new AccountBll().GetAccountById(employeeID);
            if (account != null && account.Position != null)
            {
                retpositions.Add(account.Position);
            }
            List<Account> accounts = new AccountBll().GetSubordinates(employeeID);
            foreach (Account a in accounts)
            {
                if (a.Position == null)
                {
                    continue;
                }
                Position p = Position.FindPosition(retpositions, a.Position.Id);
                if (p == null)
                {
                    retpositions.Add(a.Position);
                }
            }
            Position.OrderByName(retpositions);
            return retpositions;
        }

        #endregion
    }
}
