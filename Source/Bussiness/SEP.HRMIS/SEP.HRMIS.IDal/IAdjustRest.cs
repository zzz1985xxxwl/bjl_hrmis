//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IAdjustRest.cs
// Creater:  Xue.wenlong
// Date:  2009-04-13
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAdjustRest;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAdjustRest
    {
       
        /// <summary>
        /// 
        /// </summary>
        int UpdateAdjustRest(AdjustRest adjustRest);


        /// <summary>
        /// 
        /// </summary>
        AdjustRest GetAdjustRestByPKID(int adjustID);

        /// <summary>
        /// 
        /// </summary>
        AdjustRest GetAdjustRestByAccountIDAndYear(int accountid,DateTime adjustYear);

        /// <summary>
        /// 
        /// </summary>
        int InsertAdjustRest(AdjustRest adjustRest);

        /// <summary>
        /// 
        /// </summary>
        int DeleteAdjustRestByAccountID(int accountID);
        /// <summary>
        /// ����Ա����õ�ǰ�ĵ�������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<AdjustRest> GetAdjustRestByAccountID(int id);
    }
}