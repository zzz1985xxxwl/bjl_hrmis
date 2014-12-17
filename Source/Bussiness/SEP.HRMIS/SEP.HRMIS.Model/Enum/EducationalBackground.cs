//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EducationalBackground.cs
// 创建者: 倪豪
// 创建日期: 2008-08-26
// 概述: 教育背景
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 教育背景
    /// </summary>
    [Serializable]
    public class EducationalBackground:ParameterBase
    {
        public EducationalBackground(int id, string name)
            : base(id, name)
        {
        }

        public static EducationalBackground XiaoXue = new EducationalBackground(1, "小学");
        public static EducationalBackground ChuZhong = new EducationalBackground(2, "初中");
        public static EducationalBackground ZhongZhuan = new EducationalBackground(3, "中专");
        public static EducationalBackground JiXiao = new EducationalBackground(4, "技校");
        public static EducationalBackground GaoZhong = new EducationalBackground(5, "高中");
        public static EducationalBackground DaZhuan = new EducationalBackground(6, "大专");
        public static EducationalBackground BenKe = new EducationalBackground(7, "本科");
        public static EducationalBackground ShuoShi = new EducationalBackground(8, "硕士");
        public static EducationalBackground BoShi = new EducationalBackground(9, "博士");
        public static EducationalBackground UnKnow = new EducationalBackground(10, "不明确");

        public static EducationalBackground GetById(int id)
        {
            switch(id)
            {
            case 1:
                 return    XiaoXue;
             case 2:
                 return ChuZhong;
             case 3:
                 return ZhongZhuan;
             case 4:
                 return JiXiao;
             case 5:
                 return GaoZhong;
             case 6:
                 return DaZhuan;
             case 7:
                 return BenKe;
             case 8:
                 return ShuoShi;
             case 9:
                 return BoShi;
             case 10:
                 return UnKnow;
                default:
                    return null;

            }
        }

        public static List<EducationalBackground> AllEducationalBackgrounds
        {
            get
            {
                List<EducationalBackground> allEducationalBackground = new List<EducationalBackground>();
                allEducationalBackground.Add(XiaoXue);
                allEducationalBackground.Add(ChuZhong);
                allEducationalBackground.Add(ZhongZhuan);
                allEducationalBackground.Add(JiXiao);
                allEducationalBackground.Add(GaoZhong);
                allEducationalBackground.Add(DaZhuan);
                allEducationalBackground.Add(BenKe);
                allEducationalBackground.Add(ShuoShi);
                allEducationalBackground.Add(BoShi);
                allEducationalBackground.Add(UnKnow);
                return allEducationalBackground;
            }
        }
    }
}