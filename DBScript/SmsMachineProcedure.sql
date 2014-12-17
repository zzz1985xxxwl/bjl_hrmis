
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SendMessageInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SendMessageInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SendMessageUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SendMessageUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ReceiveMessageInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ReceiveMessageInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ReceiveMessageUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ReceiveMessageUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSendMessageByStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetSendMessageByStatus]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetReceiveMessageByStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetReceiveMessageByStatus]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteReceiveMessageByPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteReceiveMessageByPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteSendMessageByPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteSendMessageByPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllSendMessage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllSendMessage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllReceiveMessage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllReceiveMessage]
GO
----------------客户信息相关
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClientInformationInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ClientInformationInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClientInformationUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ClientInformationUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteClientInformationByPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteClientInformationByPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ListenAddressInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ListenAddressInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ListenAddressUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ListenAddressUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteListenAddressByPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteListenAddressByPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetListenAddressByClientInformationId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetListenAddressByClientInformationId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetClientInformationByPkid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetClientInformationByPkid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteListenAddressModelByClientInformationId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteListenAddressModelByClientInformationId]
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE SendMessageInsert
(
        @PKID				INT out,
		@SendStatusEnum		INT,
		@SystemSmsId		INT,
		@SendToNumber		NVarChar(50),
		@SystemNumber		NVarChar(50),
		@Content			NVarChar (2000),
		@TriedCount			INT,
		@LastestSendTime	DateTime,
		@HrmisId			NVarChar(255)
)
AS
BEGIN
          SET NOCOUNT ON
          INSERT INTO T_SendMessages
           (
				SendStatusEnum,
				SystemSmsId,
				SendToNumber,
				SystemNumber,
				[Content],
				TriedCount,
				LastestSendTime,
				HrmisId
			)
          values
			(
				@SendStatusEnum,
				@SystemSmsId,
				@SendToNumber,
				@SystemNumber,
				@Content,
				@TriedCount,
				@LastestSendTime,
				@HrmisId
			)
          SELECT @PKID=SCOPE_IDENTITY()
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE SendMessageUpdate
(
        @PKID       INT,
        @SendStatusEnum		INT,
		@SystemSmsId		INT,
		@SendToNumber		NVarChar(50),
		@SystemNumber		NVarChar(50),
		@Content			NVarChar (2000),
		@TriedCount			INT,
		@LastestSendTime	DateTime,
		@HrmisId			NVarChar(255)
)
AS
BEGIN
          SET NOCOUNT ON
          UPDATE T_SendMessages 
		  SET
			SendStatusEnum=@SendStatusEnum,
			SystemSmsId=@SystemSmsId,
			SendToNumber=@SendToNumber,
			SystemNumber=@SystemNumber,
			[Content]=@Content,
			TriedCount=@TriedCount,
			LastestSendTime=@LastestSendTime,
			HrmisId=@HrmisId
          WHERE PKID=@PKID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE ReceiveMessageInsert
(
        @PKID				INT out,
		@BoradCasted		INT,				
		@Id					INT,				
		@TheNumber			NVarChar(50),	
		@Content			NVarChar (2000),	
		@ReceivedTime		DateTime,		
		@IsCleanMessage		INT
)
AS
BEGIN
          SET NOCOUNT ON
          INSERT INTO T_ReceiveMessages
           (
				BoradCasted,
				Id,			
				TheNumber,	
				[Content],	
				ReceivedTime,
				IsCleanMessage
			)
          values
			(
				@BoradCasted,
				@Id,			
				@TheNumber,	
				@Content,	
				@ReceivedTime,
				@IsCleanMessage
			)
          SELECT @PKID=SCOPE_IDENTITY()
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE ReceiveMessageUpdate
(
        @PKID       INT,
        @BoradCasted		INT,				
		@Id					INT,				
		@TheNumber			NVarChar(50),	
		@Content			NVarChar (2000),	
		@ReceivedTime		DateTime,		
		@IsCleanMessage		INT
)
AS
BEGIN
          SET NOCOUNT ON
          UPDATE T_ReceiveMessages 
		  SET
			BoradCasted=@BoradCasted,
			Id=@Id,			
			TheNumber=@TheNumber,	
			[Content]=@Content,	
			ReceivedTime=@ReceivedTime,
			IsCleanMessage=@IsCleanMessage
          WHERE PKID=@PKID
END
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetSendMessageByStatus
(
	@SendStatusEnum int
)
AS
BEGIN
    SELECT
			PKID,
			SendStatusEnum,
			SystemSmsId,
			SendToNumber,
			SystemNumber,
			[Content],
			TriedCount,
			LastestSendTime,
			HrmisId
    FROM T_SendMessages
	WHERE 	SendStatusEnum = @SendStatusEnum or
			@SendStatusEnum = -1
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAllSendMessage
AS
BEGIN
    SELECT
			PKID,
			SendStatusEnum,
			SystemSmsId,
			SendToNumber,
			SystemNumber,
			[Content],
			TriedCount,
			LastestSendTime,
			HrmisId
    FROM T_SendMessages
	Order BY PKID DESC
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetReceiveMessageByStatus
(
	@BoradCasted int
)
AS
BEGIN
    SELECT
			PKID,
			BoradCasted,
			Id,			
			TheNumber,	
			[Content],	
			ReceivedTime,
			IsCleanMessage		
    FROM T_ReceiveMessages
	WHERE 	BoradCasted = @BoradCasted or
			@BoradCasted = -1
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetAllReceiveMessage
AS
BEGIN
    SELECT
			PKID,
			BoradCasted,
			Id,			
			TheNumber,	
			[Content],	
			ReceivedTime,
			IsCleanMessage		
    FROM T_ReceiveMessages
	ORDER BY ReceivedTime DESC
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteSendMessageByPkid
(
	@PKID int
)
AS
BEGIN
    DELETE FROM	T_SendMessages
	WHERE 	PKID = @PKID or
			@PKID = -1
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteReceiveMessageByPkid
(
	@PKID int
)
AS
BEGIN
    DELETE FROM	T_ReceiveMessages
	WHERE 	PKID = @PKID or
			@PKID = -1
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE ClientInformationInsert
(
        @PKID				INT out,
		@HrmisId			NVarChar(255),
		@CompanyDescription	NVarChar(255),
		@IsPermitted		INT
)
AS
BEGIN
          SET NOCOUNT ON
          INSERT INTO T_ClientInformation
           (
				HrmisId,
				CompanyDescription,
				IsPermitted
			)
          values
			(
				@HrmisId,
				@CompanyDescription,
				@IsPermitted
			)
          SELECT @PKID=SCOPE_IDENTITY()
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE ClientInformationUpdate
(
        @PKID       INT,
        @HrmisId			NVarChar(255),
		@CompanyDescription	NVarChar(255),
		@IsPermitted		INT
)
AS
BEGIN
          SET NOCOUNT ON
          UPDATE T_ClientInformation 
		  SET
			HrmisId=@HrmisId,
			CompanyDescription=@CompanyDescription,
			IsPermitted=@IsPermitted
          WHERE PKID=@PKID
END
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteClientInformationByPkid
(
	@PKID int
)
AS
BEGIN
    DELETE FROM	T_ClientInformation
	WHERE 	PKID = @PKID or
			@PKID = -1
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE ListenAddressInsert
(
        @PKID					INT out,
		@ClientInformationId	INT,
		@ListenAddress			NVarChar(255),
		@IsPermitted			INT,
		@IsActived				INT,
		@LastTryActivitedTime	DateTime
)
AS
BEGIN
          SET NOCOUNT ON
          INSERT INTO T_ListenAddress
           (
				ClientInformationId,
				ListenAddress,
				IsPermitted,
				IsActived,
				LastTryActivitedTime
			)
          values
			(
				@ClientInformationId,
				@ListenAddress,
				@IsPermitted,
				@IsActived,
				@LastTryActivitedTime
			)
          SELECT @PKID=SCOPE_IDENTITY()
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE ListenAddressUpdate
(
        @PKID       INT,
        @ClientInformationId	INT,
		@ListenAddress			NVarChar(255),
		@IsPermitted			INT,
		@IsActived				INT,
		@LastTryActivitedTime	DateTime
)
AS
BEGIN
          SET NOCOUNT ON
          UPDATE T_ListenAddress 
		  SET
			ClientInformationId=@ClientInformationId,
			ListenAddress=@ListenAddress,
			IsPermitted=@IsPermitted,
			IsActived=@IsActived,
			LastTryActivitedTime=@LastTryActivitedTime
          WHERE PKID=@PKID
END
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteListenAddressByPkid
(
	@PKID int
)
AS
BEGIN
    DELETE FROM	T_ListenAddress
	WHERE 	PKID = @PKID or
			@PKID = -1
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetListenAddressByClientInformationId
(
		@ClientInformationId	INT
)
AS
BEGIN
    SELECT
			T_ListenAddress.PKID,
			T_ListenAddress.ListenAddress,
			T_ListenAddress.IsPermitted,
			T_ListenAddress.IsActived,
			T_ListenAddress.LastTryActivitedTime
    FROM	T_ListenAddress
	WHERE 	ClientInformationId = @ClientInformationId
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetClientInformationByPkid
(
		@PKID	INT
)
AS
BEGIN
    SELECT
			T_ClientInformation.PKID,
			T_ClientInformation.HrmisId,
			T_ClientInformation.CompanyDescription,
			T_ClientInformation.IsPermitted
    FROM	T_ClientInformation
	WHERE 	PKID = @PKID or
			@PKID = -1
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteListenAddressModelByClientInformationId
(
	@ClientInformationId int
)
AS
BEGIN
    DELETE FROM	T_ListenAddress
	WHERE 	ClientInformationId = @ClientInformationId
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO