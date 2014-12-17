/*******************************************************************************
****
****
****              Begin Drop Procedure
****
****
********************************************************************************/

/****** Object:  StoredProcedure [dbo].[InsertLinkman]    Script Date: 12/01/2008 21:13:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertLinkman]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertLinkman]
GO

/****** Object:  StoredProcedure [dbo].[InsertLinkmanDetail]    Script Date: 12/01/2008 21:27:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertLinkmanDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertLinkmanDetail]
GO

/****** Object:  StoredProcedure [dbo].[GetLinkman]    Script Date: 12/02/2008 00:27:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetLinkman]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetLinkman]
GO

/****** 对象:  StoredProcedure [dbo].[UpdateLinkman]    脚本日期: 12/02/2008 09:47:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateLinkman]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateLinkman]
GO

/****** 对象:  StoredProcedure [dbo].[UpdateLinkmanDetail]    脚本日期: 12/02/2008 10:13:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateLinkmanDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateLinkmanDetail]
GO

/****** 对象:  StoredProcedure [dbo].[DeleteLinkmanDetail]    脚本日期: 12/02/2008 10:19:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteLinkmanDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteLinkmanDetail]
GO

/****** 对象:  StoredProcedure [dbo].[DeleteLinkman]    脚本日期: 12/02/2008 10:20:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteLinkman]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteLinkman]
GO

/****** 对象:  StoredProcedure [dbo].[DeleteLinkman]    脚本日期: 12/05/2008 10:20:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteContact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteContact]
GO

/****** 对象:  StoredProcedure [dbo].[GetLinkmansByCondition]    脚本日期: 12/03/2008 16:32:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetLinkmansByCondition]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetLinkmansByCondition]

/*******************************************************************************
****
****
****              Begin Create Procedure
****
****
********************************************************************************/

/****** Object:  StoredProcedure [dbo].[InsertLinkman]    Script Date: 12/01/2008 21:13:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertLinkman]
(
	@LinkmanId uniqueidentifier,
	@SysNo nvarchar(255),
	@UserId int,
    @ComapnyId int,
	@Name nvarchar(255),
	@IndexKey char(1)
)
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO TLinkman
			   ([LinkmanId]
			   ,[SysNo]
			   ,[UserId]
               ,[ComapnyId]
			   ,[Name]
			   ,[IndexKey])
		 VALUES
			   (@LinkmanId
			   ,@SysNo
			   ,@UserId
	           ,@ComapnyId
			   ,@Name
			   ,@IndexKey
			   )
    RETURN @@Rowcount
END
GO

/****** Object:  StoredProcedure [dbo].[InsertLinkmanDetail]    Script Date: 12/01/2008 21:27:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertLinkmanDetail]
(
	@DetailId uniqueidentifier,
	@LinkmanId uniqueidentifier,
	@Type int,
	@Value nvarchar(255),
	@IsDefault bit
)
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [TLinkmanDetail]
			   ([DetailId]
			   ,[LinkmanId]
			   ,[Type]
			   ,[Value]
			   ,[IsDefault])
		 VALUES
			   (@DetailId
			   ,@LinkmanId
			   ,@Type
			   ,@Value
			   ,@IsDefault)
    RETURN @@Rowcount
	
END
GO

/****** Object:  StoredProcedure [dbo].[GetLinkman]    Script Date: 12/02/2008 00:27:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetLinkman]
(
	@LinkmanId uniqueidentifier
)
AS
BEGIN
	SELECT A.*, B.DetailId, B.Type, B.Value, B.IsDefault 
	FROM 
		(SELECT * FROM TLinkman WHERE LinkmanId = @LinkmanId) A  
		LEFT JOIN (SELECT * FROM TLinkmanDetail WHERE LinkmanId = @LinkmanId) B 
		ON A.LinkmanId = B.LinkmanId
	ORDER BY A.IndexKey
END
GO

/****** 对象:  StoredProcedure [dbo].[UpdateLinkman]    脚本日期: 12/02/2008 09:47:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateLinkman]
(
	@LinkmanId uniqueidentifier,
	@Name nvarchar(255),
	@IndexKey char(1)
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [dbo].[TLinkman]
	   SET [Name] = @Name, [IndexKey] = @IndexKey
	WHERE [LinkmanId] = @LinkmanId
    RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [dbo].[UpdateLinkmanDetail]    脚本日期: 12/02/2008 10:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateLinkmanDetail]
(
	@DetailId uniqueidentifier,
	@Type int,
	@Value nvarchar(255),
	@IsDefault bit
)
AS
BEGIN
    SET NOCOUNT ON;
	UPDATE [dbo].[TLinkmanDetail]
	   SET [Value] = @Value, [IsDefault] = @IsDefault,[Type] = @Type
	 WHERE DetailId = @DetailId
	RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [dbo].[DeleteLinkmanDetail]    脚本日期: 12/02/2008 10:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteLinkmanDetail]
(
	@DetailId uniqueidentifier
)
AS
BEGIN
    SET NOCOUNT ON;
	DELETE FROM [dbo].[TLinkmanDetail]
		  WHERE DetailId = @DetailId
	RETURN @@Rowcount
END
Go

/****** 对象:  StoredProcedure [dbo].[DeleteLinkman]    脚本日期: 12/02/2008 10:21:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteLinkman]
(
	@LinkmanId uniqueidentifier
)
AS
BEGIN
    SET NOCOUNT ON;
	DELETE FROM [dbo].[TLinkmanDetail]
		  WHERE LinkmanId = @LinkmanId
	DELETE FROM [dbo].[TLinkman]
		  WHERE LinkmanId = @LinkmanId
    RETURN @@Rowcount
END
GO



/****** 对象:  StoredProcedure [dbo].[DeleteContact]    脚本日期: 12/05/2008 10:21:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteContact]
(
	@SysNo nvarchar(255),
	@UserId int
)
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE B 
	FROM TLinkman A LEFT JOIN TLinkmanDetail B 
				ON A.LinkmanId = B.LinkmanId
	WHERE (SysNo=@SysNo) AND (UserId=@UserId)

	DELETE FROM TLinkman WHERE (SysNo=@SysNo) AND (UserId=@UserId)
    RETURN @@Rowcount
END
GO

/****** 对象:  StoredProcedure [dbo].[GetLinkmansByCondition]    脚本日期: 12/03/2008 16:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLinkmansByCondition]
(
	@SysNo nvarchar(255),
	@UserId int,
    @ComapnyId  int,
	@Name nvarchar(255),
	@IndexKey char(1),
	@IsExternal bit
)
AS
BEGIN
	IF(@IsExternal=1)
		BEGIN
			SELECT A.*, B.DetailId, B.Type, B.Value, B.IsDefault 
			FROM 
				(SELECT * FROM TLinkman 
				 WHERE (SysNo=@SysNo) AND (UserId=@UserId) AND (ComapnyId=@ComapnyId)
					AND (@Name IS NULL OR [Name] LIKE '%'+@Name+'%') AND (@IndexKey IS NULL OR [IndexKey]=@IndexKey)) A  
				LEFT JOIN (SELECT * FROM TLinkmanDetail) B 
				ON A.LinkmanId = B.LinkmanId
			ORDER BY A.IndexKey
		END
	ELSE
		BEGIN
			SELECT * FROM TLinkman 
			WHERE (SysNo=@SysNo) AND (UserId=@UserId) AND (ComapnyId=@ComapnyId)
				AND (@Name IS NULL OR [Name] LIKE '%'+@Name+'%') 
				AND (@IndexKey IS NULL OR [IndexKey]=@IndexKey)
			ORDER BY IndexKey
		END
END
GO
