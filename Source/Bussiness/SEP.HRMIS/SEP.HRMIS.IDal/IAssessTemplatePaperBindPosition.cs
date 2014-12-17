//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: IAssessTemplatePaperBindPosition.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-06
// Resume: 
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Model.Positions;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAssessTemplatePaperBindPosition
    {
        /// <summary>
        /// 
        /// </summary>
        int Insert(int paperID, int positionID);

        /// <summary>
        /// 
        /// </summary>
        int DeleteByPaperID(int paperID);

        /// <summary>
        /// 
        /// </summary>
        List<Position> GetBindPostionByPaperID(int paperID);

        /// <summary>
        /// 
        /// </summary>
        List<Position> GetAssessTemplatePaperBindPostionByPositionIDDiffPaperID(int paperID, int positionID);

        /// <summary>
        /// 
        /// </summary>
        int GetAssessTemplatePaperIDByPositionID(int positionID);
    }
}