//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EducationalBackground.cs
// ������: �ߺ�
// ��������: 2008-08-26
// ����: ��������
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��������
    /// </summary>
    [Serializable]
    public class EducationalBackground:ParameterBase
    {
        public EducationalBackground(int id, string name)
            : base(id, name)
        {
        }

        public static EducationalBackground XiaoXue = new EducationalBackground(1, "Сѧ");
        public static EducationalBackground ChuZhong = new EducationalBackground(2, "����");
        public static EducationalBackground ZhongZhuan = new EducationalBackground(3, "��ר");
        public static EducationalBackground JiXiao = new EducationalBackground(4, "��У");
        public static EducationalBackground GaoZhong = new EducationalBackground(5, "����");
        public static EducationalBackground DaZhuan = new EducationalBackground(6, "��ר");
        public static EducationalBackground BenKe = new EducationalBackground(7, "����");
        public static EducationalBackground ShuoShi = new EducationalBackground(8, "˶ʿ");
        public static EducationalBackground BoShi = new EducationalBackground(9, "��ʿ");
        public static EducationalBackground UnKnow = new EducationalBackground(10, "����ȷ");

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