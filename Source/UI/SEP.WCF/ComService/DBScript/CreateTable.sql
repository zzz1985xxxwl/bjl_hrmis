/*******************************************************************************
****
****
****              Begin Drop Table
****
****
********************************************************************************/

/****** 对象:  Table [dbo].[TLinkman]    脚本日期: 12/01/2008 16:59:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TLinkman]') AND type in (N'U'))
DROP TABLE [dbo].[TLinkman]
Go


/****** 对象:  Table [dbo].[TLinkmanDetail]    脚本日期: 12/01/2008 16:59:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TLinkmanDetail]') AND type in (N'U'))
DROP TABLE [dbo].[TLinkmanDetail]
GO

/*******************************************************************************
****
****
****              Begin Create Table
****
****
********************************************************************************/


/****** 对象:  Table [dbo].[TLinkman]    脚本日期: 12/01/2008 12:56:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TLinkman](
	[LinkmanId] [uniqueidentifier] NOT NULL,
	[SysNo] [nvarchar](255) NOT NULL,
	[UserId] [int] NOT NULL,
    [ComapnyId] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[IndexKey] [char](1) NULL,
 CONSTRAINT [PK_TLinkman] PRIMARY KEY CLUSTERED 
(
	[LinkmanId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** 对象:  Table [dbo].[TLinkmanDetail]    脚本日期: 12/01/2008 12:56:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TLinkmanDetail](
	[DetailId] [uniqueidentifier] NOT NULL,
	[LinkmanId] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[Value] [nvarchar](255) NULL,
	[IsDefault] [bit] NOT NULL CONSTRAINT [DF_TLinkmanDetail_IsDefault]  DEFAULT ((0)),
 CONSTRAINT [PK_TLinkmanDetail] PRIMARY KEY CLUSTERED 
(
	[DetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
