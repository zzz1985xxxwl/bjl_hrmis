
using System.Collections.Generic;
using SEP.HRMIS.Logic;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseItem
{
    public class ReimburseItemViewIniter
    {
        private readonly IReimburseItemView _ItsView;
        private readonly bool _IsTravel;

        public ReimburseItemViewIniter(IReimburseItemView itsView, bool isTravel)
        {
            _ItsView = itsView;
            _IsTravel = isTravel;
        }

        public void InitTheViewToDefault()
        {
            if (_IsTravel)
            {
                _ItsView.ReimburseTypeSource = GetTravelReimburseTypeEnum();
                _ItsView.IsTravelReimburse = false;
            }
            else
            {
                _ItsView.ReimburseTypeSource = GetUnTravelReimburseTypeEnum();
                _ItsView.IsTravelReimburse = true;
            }

            _ItsView.ConsumePlace = string.Empty;
            _ItsView.Message = string.Empty;
            _ItsView.Reason = string.Empty;
            _ItsView.ReasonMsg = string.Empty;
            _ItsView.TotalCost = string.Empty;
            _ItsView.TotalCostMsg = string.Empty;
            _ItsView.CustomerName = string.Empty;
            _ItsView.CustomerNameCode = string.Empty;
            _ItsView.CustomerNameError = string.Empty;
            _ItsView.CustomerID = null;
        }

        private static Dictionary<string, string> GetTravelReimburseTypeEnum()
        {
            Dictionary<string, string> reimburseType = new Dictionary<string, string>();
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.ShortDistanceCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.LongDistanceCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.LodgingCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.CommunicationEntertainmentCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.OtherCost);
            return reimburseType;
        }

        private static Dictionary<string, string> GetUnTravelReimburseTypeEnum()
        {
            Dictionary<string, string> reimburseType = new Dictionary<string, string>();
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.CityTrafficCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.MealCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.AdminCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.CommunicationCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.VehicleRunningCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.TrainingCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.WelfareCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.AccommodationCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.ConferenceFeesCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.ConsultancyFeesCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.MailPostCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.MarkCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.WarehouseCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.ExhibitionCost);
            hrmisModel.ReimburseItem.AddReimburseTypeValueAndNameIntoDictionary(reimburseType, ReimburseTypeEnum.OtherCost);
            return reimburseType;
        }


    }
}
