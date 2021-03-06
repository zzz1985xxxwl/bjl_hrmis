/***********************************************************************************
**                                                                                **
**                               删除存储过程                                     **
**                                                                                **
***********************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountKeyByTableNameAndRowID]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CountKeyByTableNameAndRowID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteKeyByPKID]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[DeleteKeyByPKID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertKey]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[InsertKey]
GO
--Begin          卡片      -------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CardInsert]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CardInsert]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CardUpdate]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CardUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CardDelete]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CardDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCardByPKID]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetCardByPKID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCardByCondition]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetCardByCondition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountCardByCardTypeID]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CountCardByCardTypeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCardByCardTypeID]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetCardByCardTypeID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountCardByCardPropertyEnumValueID]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CountCardByCardPropertyEnumValueID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCardByCardPropertyParaID]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[GetCardByCardPropertyParaID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountCardByCardPropertyParaID]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CountCardByCardPropertyParaID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountCardByParentCardID]') and OBJECTPROPERTY(id, N'IsProcedure')=1)
drop procedure [dbo].[CountCardByParentCardID]
GO

--End            卡片      -------------

--Begin            卡片类型          ------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCardTypeByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCardTypeByPKID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCardTypeByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCardTypeByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCardType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCardType]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCardType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCardType]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountCardTypeByNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountCardTypeByNameDiffPKID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountCardFieldByCardPropertyParaID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountCardFieldByCardPropertyParaID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCardTypeByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteCardTypeByPKID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCardTypeByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCardTypeByCondition]
GO
--End            卡片类型          ------------

--Begin            卡片类型中的字段          ------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCardField]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCardField]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCardField]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCardField]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCardFieldByCardTypeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteCardFieldByCardTypeID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCardFieldExceptKeyByCardTypeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteCardFieldExceptKeyByCardTypeID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCardFieldByCardPropertyParaID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCardFieldByCardPropertyParaID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCardFieldByCardTypeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCardFieldByCardTypeID]
GO

--End            卡片类型中的字段         ------------

--Begin            卡片属性          ------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCardPropertyParaByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCardPropertyParaByPKID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCardPropertyParaByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCardPropertyParaByName]
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCardPropertyPara]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCardPropertyPara]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCardPropertyPara]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCardPropertyPara]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountCardPropertyParaByNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountCardPropertyParaByNameDiffPKID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCardPropertyParaByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteCardPropertyParaByPKID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCardPropertyParaByCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCardPropertyParaByCondition]
GO

--End            卡片属性           ------------

--Begin            卡片属性里的枚举集          ------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCardPropertyEnumValueByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCardPropertyEnumValueByPKID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCardPropertyEnumValue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCardPropertyEnumValue]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCardPropertyEnumValue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCardPropertyEnumValue]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountCardPropertyEnumValueByNameDiffPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountCardPropertyEnumValueByNameDiffPKID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCardPropertyEnumValueByPKID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteCardPropertyEnumValueByPKID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCardPropertyEnumValueByCardPropertyParaID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteCardPropertyEnumValueByCardPropertyParaID]
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCardPropertyEnumValueExceptKeyByCardPropertyParaID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteCardPropertyEnumValueExceptKeyByCardPropertyParaID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCardPropertyEnumValueByCardPropertyParaID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCardPropertyEnumValueByCardPropertyParaID]
GO
--End            卡片属性里的枚举集           ------------

/***********************************************************************************
**                                                                                **
**                               创建存储过程                                     **
**                                                                                **
***********************************************************************************/

CREATE PROCEDURE CountKeyByTableNameAndRowID
(       
    	 @TableName NVARCHAR(100),
   		 @RowID INT
)AS
begin 
             SET NOCOUNT ON
             select counts=count(PKID)
             from TKey
             Where (TableName=@TableName) and (RowID=@RowID)
end

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE DeleteKeyByPKID
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TKey
	  WHERE  PKID = @PKID 
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
CREATE PROCEDURE InsertKey
(
	@PKID            INT OUTPUT,
    @TableName		 NVARCHAR(100),
    @RowID	         INT
)
AS
BEGIN
    INSERT INTO TKey(
		TableName,
		RowID
	)
    VALUES (
		@TableName,
		@RowID
	)
    SELECT @PKID=SCOPE_IDENTITY()
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--Begin          卡片      -------------
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CardInsert
(
	@PKID                    INT OUTPUT,
    @CardTypeID		         INT,
	@CardTypeWhole			 IMAGE,
	@Title					 Nvarchar(255),
	@Content     			 TEXT,
    @ParentID		         INT,
    @ProjectID		         INT
)
AS
BEGIN
    INSERT INTO TCard(
		ProjectID,
		CardTypeID,
		CardTypeWhole,
		Title,
		[Content],
		ParentID
	)
    VALUES (
		@ProjectID,
		@CardTypeID,
		@CardTypeWhole,
		@Title,
		@Content,
		@ParentID
	)
    SELECT @PKID=SCOPE_IDENTITY()
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CardUpdate
(
	@PKID                    INT OUTPUT,
    @CardTypeID		         INT,
	@CardTypeWhole			 IMAGE,
	@Title					 Nvarchar(255),
	@Content     			 TEXT,
    @ParentID		         INT,
    @ProjectID		         INT
)
AS
BEGIN
		UPDATE TCard
        SET
			CardTypeID = @CardTypeID
			,CardTypeWhole=@CardTypeWhole
			,[Title]=@Title 
			,[Content]=@Content
			,ParentID=@ParentID
			,ProjectID = @ProjectID
		WHERE PKID=@PKID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CardDelete
(
	    @PKID    INT     
)
AS
BEGIN
         DELETE FROM TCard  WHERE PKID=@PKID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCardByPKID
(
	    @PKID    INT     
)
AS
BEGIN
        SELECT TCard.*,TCardType.*
		FROM TCard,TCardType
		WHERE TCard.PKID=@PKID and TCardType.PKID = TCard.CardTypeID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCardByCondition
(
	     @ProjectID		INT 
		,@Title			NVARCHAR(255)
		,@CardTypeID	INT
)
AS
BEGIN
        SELECT TCard.PKID AS CardID,ProjectID,Title,[Content],TCardType.PKID AS CardTypeID,
			   TCardType.NAME AS CardTypeName,ParentID
		FROM TCard,TCardType
		WHERE TCardType.PKID = TCard.CardTypeID
		  and (@ProjectID = -1 or TCard.ProjectID=@ProjectID)
		  and (@Title = '' or TCard.Title like '%'+ @Title  +'%' )
		  and (@CardTypeID = -1 or TCardType.PKID=@CardTypeID)
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CountCardByCardTypeID
(
	    @CardTypeID	INT
)
AS
BEGIN
          SELECT counts=count(PKID) 
	      FROM TCard
	      WHERE CardTypeID  = @CardTypeID 

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
create PROCEDURE GetCardByCardTypeID
(
        @CardTypeID INT
)
AS
Begin
        SELECT TCard.*,TCardType.*,TCard.PKID AS CardID
		FROM TCard,TCardType
		WHERE TCard.CardTypeID=@CardTypeID and TCardType.PKID = TCard.CardTypeID
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
CREATE PROCEDURE CountCardByCardPropertyEnumValueID
(
	    @CardPropertyEnumValueID	INT
)
AS
BEGIN
          SELECT counts=count(TCardPropertyEnumValue.PKID) 
	      FROM TCard,TCardType,TCardField,TCardPropertyPara,TCardPropertyEnumValue
	      WHERE TCardPropertyEnumValue.PKID  = @CardPropertyEnumValueID 
			and TCard.CardTypeID = TCardType.PKID 
			and TCardField.CardTypeID = TCardType.PKID 
			and TCardField.CardPropertyParaID = TCardPropertyPara.PKID
			and TCardPropertyEnumValue.CardPropertyParaID = TCardPropertyPara.PKID

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CountCardByCardPropertyParaID
(
	    @CardPropertyParaID	INT
)
AS
BEGIN
          SELECT counts=count(TCardPropertyPara.PKID) 
	      FROM TCard,TCardType,TCardField,TCardPropertyPara
	      WHERE TCardPropertyPara.PKID  = @CardPropertyParaID 
			and TCard.CardTypeID = TCardType.PKID 
			and TCardField.CardTypeID = TCardType.PKID 
			and TCardField.CardPropertyParaID = TCardPropertyPara.PKID

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE GetCardByCardPropertyParaID
(
	    @CardPropertyParaID	INT
)
AS
BEGIN
          SELECT TCard.*,TCard.PKID as CardID,TCardType.* 
	      FROM TCard,TCardType,TCardField,TCardPropertyPara
	      WHERE TCardPropertyPara.PKID  = @CardPropertyParaID 
			and TCard.CardTypeID = TCardType.PKID 
			and TCardField.CardTypeID = TCardType.PKID 
			and TCardField.CardPropertyParaID = TCardPropertyPara.PKID

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE CountCardByParentCardID
(
	    @ParentCardID	INT
)
AS
BEGIN
          SELECT counts=count(TCard.PKID) 
	      FROM TCard
	      WHERE TCard.ParentID = @ParentCardID
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--End            卡片      -------------

--Begin             卡片类型         ------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertCardType
(
	@PKID INT out,
        @Name Nvarchar(255),
        @Color Nvarchar(50),
        @Description     Text
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TCardType([Name] , Color ,Description)
          values(@Name  ,@Color     ,@Description)
          select @PKID=SCOPE_IDENTITY()
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
CREATE PROCEDURE UpdateCardType
(
	@PKID INT ,
        @Name Nvarchar(255),
        @Color Nvarchar(50),
        @Description     Text
)
AS
Begin
          SET NOCOUNT OFF
          update TCardType
          set [Name] = @Name , 
              Color=@Color,
              Description=@Description     
          where PKID=@PKID
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
CREATE PROCEDURE CountCardTypeByNameDiffPKID
(
	    @PKID INT,
	    @Name Nvarchar(255)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TCardType
	      WHERE [Name] = @Name  and PKID <> @PKID
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
CREATE PROCEDURE CountCardFieldByCardPropertyParaID
(
	    @CardPropertyParaID INT
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TCardField
	      WHERE CardPropertyParaID = @CardPropertyParaID
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
CREATE PROCEDURE DeleteCardTypeByPKID
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TCardType
	  WHERE  PKID = @PKID 
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
create PROCEDURE GetCardTypeByPKID
(
        @PKID INT
)
AS
Begin
          SELECT * FROM TCardType
	      WHERE PKID = @PKID
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
create PROCEDURE GetCardTypeByName
(
        @Name Nvarchar(255)
)
AS
Begin
          SELECT * FROM TCardType
	      WHERE [Name] = @Name
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
create PROCEDURE GetCardTypeByCondition
(
        @Name Nvarchar(255)
)
AS
Begin
          SELECT * FROM TCardType
	     WHERE [Name] like '%'+ @Name  +'%' 
             ORDER BY [Name] 
   End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--End               卡片类型         ------------


--Begin             卡片类型中的字段         ------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertCardField
(
	@PKID INT out,        
        @CardPropertyParaID INT ,
        @CardTypeID    INT,
        @FieldFormula  Nvarchar(255) ,
        @Order       INT
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TCardField(CardPropertyParaID , CardTypeID ,
        FieldFormula  ,  [Order])
          values(@CardPropertyParaID , @CardTypeID ,
        @FieldFormula  ,  @Order)
          select @PKID=SCOPE_IDENTITY()
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
CREATE PROCEDURE UpdateCardField
(
	    @PKID INT ,        
        @FieldFormula  Nvarchar(255) ,
        @Order       INT
)
AS
Begin
          SET NOCOUNT OFF
          update TCardField
          set FieldFormula = @FieldFormula , 
              [Order]=@Order
          where PKID=@PKID
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
CREATE PROCEDURE DeleteCardFieldByCardTypeID
(
	    @CardTypeID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TCardField
	  WHERE  CardTypeID= @CardTypeID 
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
CREATE PROCEDURE DeleteCardFieldExceptKeyByCardTypeID
(
	    @CardTypeID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TCardField
	  WHERE  CardTypeID= @CardTypeID and
             PKID NOT IN (SELECT RowID FROM TKEY WHERE TableName='TCardField')
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
create PROCEDURE GetCardFieldByCardPropertyParaID
(
        @CardPropertyParaID INT
)
AS
Begin
          SELECT * FROM TCardField
	      WHERE CardPropertyParaID= @CardPropertyParaID or @CardPropertyParaID =-1
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
create PROCEDURE GetCardFieldByCardTypeID
(
         @CardTypeID INT
)
AS
Begin
          SELECT * FROM TCardField
	     WHERE CardTypeID= @CardTypeID or @CardTypeID=-1
             ORDER BY [Order] 
   End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--End               卡片类型中的字段         ------------


--Begin             卡片属性         ------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertCardPropertyPara
(
	@PKID INT out,
        @Name Nvarchar(255),
        @Description     Text,
        @EnumCardPropertyDataType  int
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TCardPropertyPara([Name] ,Description,EnumCardPropertyDataType)
          values(@Name  ,@Description,@EnumCardPropertyDataType  )
          select @PKID=SCOPE_IDENTITY()
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
CREATE PROCEDURE UpdateCardPropertyPara
(
	@PKID INT ,
        @Name Nvarchar(255),
        @Description     Text,
        @EnumCardPropertyDataType  int
)
AS
Begin
          SET NOCOUNT OFF
          update TCardPropertyPara
          set [Name] = @Name ,
              Description=@Description , 
              EnumCardPropertyDataType=@EnumCardPropertyDataType    
          where PKID=@PKID
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
CREATE PROCEDURE CountCardPropertyParaByNameDiffPKID
(
	    @PKID INT,
	    @Name Nvarchar(255)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TCardPropertyPara
	      WHERE [Name] = @Name  and PKID <> @PKID
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
CREATE PROCEDURE DeleteCardPropertyParaByPKID
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TCardPropertyPara
	  WHERE  PKID = @PKID 
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
create PROCEDURE GetCardPropertyParaByPKID
(
        @PKID INT
)
AS
Begin
          SELECT * FROM TCardPropertyPara
	      WHERE PKID = @PKID
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
create PROCEDURE GetCardPropertyParaByName
(
        @Name Nvarchar(255)
)
AS
Begin
          SELECT * FROM TCardPropertyPara
	      WHERE [Name] = @Name
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
create PROCEDURE GetCardPropertyParaByCondition
(
        @Name Nvarchar(255),
        @EnumCardPropertyDataType  int
)
AS
Begin
          SELECT * FROM TCardPropertyPara
	     WHERE [Name] like '%'+ @Name  +'%' and 
             (EnumCardPropertyDataType=@EnumCardPropertyDataType or @EnumCardPropertyDataType=-1)
             ORDER BY [Name] 
   End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


--End               卡片属性         ------------

--Begin             卡片属性里的枚举集         ------------

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE InsertCardPropertyEnumValue
(
	@PKID INT out,
        @Name Nvarchar(255),
        @Order     Int,
        @Color    Nvarchar(50) ,
        @CardPropertyParaID int
)
AS
Begin
          SET NOCOUNT OFF
          Insert into TCardPropertyEnumValue(Name , [Order] , Color , CardPropertyParaID)
          values(@Name , @Order , @Color , @CardPropertyParaID )
          select @PKID=SCOPE_IDENTITY()
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
CREATE PROCEDURE UpdateCardPropertyEnumValue
(
	@PKID INT ,
        @Order     Int,
        @Color    Nvarchar(50) 
)
AS
Begin
          SET NOCOUNT OFF
          update TCardPropertyEnumValue
          set [Order]     =@Order     , 
          Color=@Color
          where PKID=@PKID
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
CREATE PROCEDURE CountCardPropertyEnumValueByNameDiffPKID
(
	    @PKID INT,
	    @Name Nvarchar(255)
)
AS
Begin
          SELECT counts=count(PKID) 
	      FROM TCardPropertyEnumValue
	      WHERE [Name] = @Name  and PKID <> @PKID
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
CREATE PROCEDURE DeleteCardPropertyEnumValueByPKID
(
	    @PKID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TCardPropertyEnumValue
	  WHERE  PKID = @PKID 
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
CREATE PROCEDURE DeleteCardPropertyEnumValueByCardPropertyParaID
(
	    @CardPropertyParaID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TCardPropertyEnumValue
	  WHERE  CardPropertyParaID= @CardPropertyParaID 
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
CREATE PROCEDURE DeleteCardPropertyEnumValueExceptKeyByCardPropertyParaID
(
	    @CardPropertyParaID INT
)
AS
Begin
          SET NOCOUNT OFF
          Delete from TCardPropertyEnumValue
	  WHERE  CardPropertyParaID= @CardPropertyParaID and
             PKID NOT IN (SELECT ROWID FROM TKEY WHERE TableName='TCardPropertyEnumValue')
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
create PROCEDURE GetCardPropertyEnumValueByCardPropertyParaID
(
        @CardPropertyParaID     Int
)
AS
Begin
          SELECT * FROM TCardPropertyEnumValue
	     WHERE CardPropertyParaID=@CardPropertyParaID or @CardPropertyParaID =-1
             ORDER BY [Order] 
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
create PROCEDURE GetCardPropertyEnumValueByPKID
(
        @PKID INT
)
AS
Begin
          SELECT * FROM TCardPropertyEnumValue
	      WHERE PKID = @PKID
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--End               卡片属性里的枚举集         ------------
