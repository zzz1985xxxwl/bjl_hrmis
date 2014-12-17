//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ReimburseTypeEnum.cs
// 创建者: 王莎莉
// 创建日期: 2008-10-06
// 概述: 费用类型
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    public enum ReimburseTypeEnum
    {
        CityTrafficCost,  //市内交通费
        MealCost,       //餐费
        AdminCost,//行政费用
        //BizTrip,//差旅费
        CommunicationCost,//通讯费
        //BizCustomerCost,//业务服务费
        VehicleRunningCost,  //车辆运行费
        TrainingCost,       //培训费
        WelfareCost,//福利费
        AccommodationCost,  //房租
        ConferenceFeesCost,       //会务费
        ConsultancyFeesCost,//顾问费
        OtherCost ,//其它

        ShortDistanceCost,//短途交通费
        LongDistanceCost,  //长途交通费
        LodgingCost, //住宿费
        CommunicationEntertainmentCost,//交际应酬费
        /// <summary>
        /// 邮寄费
        /// </summary>
        MailPostCost,
        /// <summary>
        /// 市场费用
        /// </summary>
        MarkCost,
        /// <summary>
        /// 仓库费用
        /// </summary>
        WarehouseCost,
        /// <summary>
        /// 展览会费用
        /// </summary>
        ExhibitionCost,
        All=-1
    }
}
