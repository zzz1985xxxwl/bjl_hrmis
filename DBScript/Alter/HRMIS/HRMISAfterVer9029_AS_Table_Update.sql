alter table dbo.TTrainApplication add EduSpuCost Decimal(25,2)  NULL

--begin            异常信息        -------------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TSystemError' AND type = 'U')
	DROP TABLE TSystemError	
GO
--end            异常信息        -------------

--begin 异常信息----------
CREATE TABLE	TSystemError	(
PKID	         INT	IDENTITY   NOT NULL,
ErrorType	     INT	           NOT NULL,  --类型 1门禁卡号,2排班规则,3请假流程，4外出申请流程,5加班申请流程,6绩效考核流程,7人事负责人,8报销流程,9培训申请流程
MarkID           INT	           NOT NULL,  --标识ID
 CONSTRAINT PK_TSystemError PRIMARY KEY NONCLUSTERED (PKID),
 CONSTRAINT TC_TSystemError UNIQUE NONCLUSTERED (PKID)
)
GO
--end 异常信息----------