//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: Transaction.cs
// Creater:  Xue.wenlong
// Date:  2009-03-24
// Resume:
// ---------------------------------------------------------------

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Transaction
    {
        /// <summary>
        /// 
        /// </summary>
        protected abstract void Validation();
        /// <summary>
        /// 
        /// </summary>
        protected abstract void ExcuteSelf();
        /// <summary>
        /// 
        /// </summary>
        public void Excute()
        {
            Validation();
            ExcuteSelf();
        }
    }
}