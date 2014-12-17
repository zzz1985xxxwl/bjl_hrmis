//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ItemClassficationEmnu.cs
// 创建者: 杨俞彬
// 创建日期: 2008-06-30
// 概述: 考评项分类
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    public enum ItemClassficationEmnu
    {
        All = -1,
        Performance,  //绩效
        Ability, //能力
        MoralCharacter,    //品德
        Acqierement ,   //学识
        /// <summary>
        /// 态度
        /// </summary>
        Attitude,

        /// <summary>
        /// 其它
        /// </summary>
        Other,
        _360
    }
}
