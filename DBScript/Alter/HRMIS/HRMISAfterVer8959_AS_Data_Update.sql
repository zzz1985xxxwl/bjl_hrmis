update TLeaveRequestItem set status=6 where status=7
update TLeaveRequestFlow set operation=6 where operation=7
update TLeaveRequestItem set status=6 where pkid=155
delete from TLeaveRequestFlow where pkid=176
delete from TleaveRequestFlow where pkid=175
delete from TleaveRequestFlow where pkid=383

update TVacation set UsedDayNum= UsedDayNum-3*0.125 ,SurplusDayNum=SurplusDayNum+3*0.125 where accountid=223
update TVacation set UsedDayNum=UsedDayNum-2*0.125 ,SurplusDayNum=SurplusDayNum+2*0.125 where accountid=171


update TApplyAssessCondition
set applydate = dateadd(dd,30,applydate)
--select *,dateadd(dd,30,applydate)as aa  from dbo.TApplyAssessCondition
where applyassesscharactertype in (0)


update TApplyAssessCondition
set applydate = dateadd(m,1,applydate)
--select applydate,dateadd(m,1,applydate)as aa from dbo.TApplyAssessCondition
where applyassesscharactertype in (8)

update TApplyAssessCondition
set assessscopefrom=temployeecontract.startdate
--select * from dbo.TApplyAssessCondition,temployeecontract
from temployeecontract
where TApplyAssessCondition.employeecontractID = temployeecontract.pkid
and applyassesscharactertype in (0)
