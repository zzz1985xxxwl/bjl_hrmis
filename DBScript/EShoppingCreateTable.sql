--begin            权限			  -------------
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAuth' AND type = 'U')
	DROP TABLE TAuth
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TAccountAuth' AND type = 'U')
	DROP TABLE TAccountAuth
GO
--end            权限	          -------------

/***********************************************************************************/
/************         Begin   销售模块(倪豪)		****************************/
/***********************************************************************************/
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TCustomerAccount' AND type = 'U')
	DROP TABLE TCustomerAccount
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TCustomerAccountLevel' AND type = 'U')
	DROP TABLE TCustomerAccountLevel
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TCustomerShippingAddress]') AND type in (N'U'))
DROP TABLE [dbo].[TCustomerShippingAddress]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TCustomerInvoiceConfig]') AND type in (N'U'))
DROP TABLE [dbo].[TCustomerInvoiceConfig]

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TSalesOrder' AND type = 'U')
	DROP TABLE TSalesOrder
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TSalesOrderItem' AND type = 'U')
	DROP TABLE TSalesOrderItem
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TSalesOrderNote' AND type = 'U')
	DROP TABLE TSalesOrderNote
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TCustomerAccountMappingPriceCode' AND type = 'U')
	DROP TABLE TCustomerAccountMappingPriceCode
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TPriceCode' AND type = 'U')
	DROP TABLE TPriceCode
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TProductPrice' AND type = 'U')
	DROP TABLE TProductPrice
GO

/***********************************************************************************/
/************         End   销售模块			****************************/
/***********************************************************************************/


/***********************************************************************************/
/************         Begin  会计科目	(施益宇)	        ****************************/
/***********************************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TAccountCode]') AND type in (N'U'))
DROP TABLE [dbo].[TAccountCode]
/***********************************************************************************/
/************         End     会计科目 									****************************/
/***********************************************************************************/

/***********************************************************************************/
/************         Begin   商品（ZZ）		****************************/
/***********************************************************************************/
IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TCategory' AND type = 'U')
	DROP TABLE TCategory
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TProduct' AND type = 'U')
	DROP TABLE TProduct
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TProductPicture' AND type = 'U')
	DROP TABLE TProductPicture
GO

IF EXISTS (SELECT name FROM sysobjects  WHERE name = 'TProduct_Category_Mapping' AND type = 'U')
	DROP TABLE TProduct_Category_Mapping
GO

/***********************************************************************************/
/************         End   商品（ZZ）		****************************/
/***********************************************************************************/

/***********************************************************************************/
/************       Begin      库存模块    chenzhongchao          ******************/
/***********************************************************************************/
/****** 对象:  Table [TWarehouse]: 仓库    脚本日期: 07/01/2009 10:54:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[TWarehouse]') AND type in (N'U'))
DROP TABLE [TWarehouse]
GO
/****** 对象:  Table [TProductStock]：商品库存    脚本日期: 07/01/2009 13:26:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[TProductStock]') AND type in (N'U'))
DROP TABLE [TProductStock]
GO
/****** 对象:  Table [TBatchStock]：商品仓库批次库存    脚本日期: 07/01/2009 13:26:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[TBatchStock]') AND type in (N'U'))
DROP TABLE [TBatchStock]
GO
/****** 对象:  Table [TStockTrans]：商品库存交易    脚本日期: 07/01/2009 13:26:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[TStockTrans]') AND type in (N'U'))
DROP TABLE [TStockTrans]
GO
/****** 对象:  Table [TDistribution]: 销售订单配货    脚本日期: 07/08/2009 15:27:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[TDistribution]') AND type in (N'U'))
DROP TABLE [TDistribution]
GO
/****** 对象:  Table [TDistributionItem]：配货明细    脚本日期: 07/08/2009 15:27:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[TDistributionItem]') AND type in (N'U'))
DROP TABLE [TDistributionItem]
GO
/***********************************************************************************/
/************       End        库存模块    chenzhongchao          ******************/
/***********************************************************************************/

/***********************************************************************************/
/************       Begin      采购模块    chenzhongchao          ******************/
/***********************************************************************************/
/****** 对象:  Table [dbo].[TProvider]：供应商    脚本日期: 07/01/2009 13:18:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TProvider]') AND type in (N'U'))
DROP TABLE [dbo].[TProvider]
GO
/****** 对象:  Table [dbo].[TPurchaseOrder]：采购订单    脚本日期: 07/01/2009 13:18:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPurchaseOrder]') AND type in (N'U'))
DROP TABLE [dbo].[TPurchaseOrder]
GO
/****** 对象:  Table [dbo].[TPurchaseOrderItem]：采购订单明细    脚本日期: 07/01/2009 13:18:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TPurchaseOrderItem]') AND type in (N'U'))
DROP TABLE [dbo].[TPurchaseOrderItem]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TProviderProduct]') AND type in (N'U'))
DROP TABLE [dbo].[TProviderProduct]
GO
/***********************************************************************************/
/************       End       采购模块    chenzhongchao           ******************/
/***********************************************************************************/

--Begin          权限       -------------

CREATE TABLE TAuth	(	   
PKID			INT	IDENTITY    NOT NULL,	   
AuthName		Nvarchar(50)	NOT NULL,
AuthParentId	INT	            NOT NULL,
NavigateUrl		Nvarchar(255)	NOT NULL,
IfHasDepartment	INT	            NOT NULL,
    CONSTRAINT PK_TAuth PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TAuth UNIQUE NONCLUSTERED (PKID)
)			
GO	

CREATE TABLE TAccountAuth	(	   
PKID			INT	IDENTITY    NOT NULL,	   
AccountId		INT				NOT NULL,
AuthId			INT	            NOT NULL,
DepartmentID	INT	            NOT NULL,
    CONSTRAINT PK_TAccountAuth PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TAccountAuth UNIQUE NONCLUSTERED (PKID)
)			
GO	

--End            权限       -------------

/***********************************************************************************/
/************         Begin   销售模块(倪豪)		****************************/
/***********************************************************************************/

/*帐户*/
CREATE TABLE TCustomerAccount (
	/*主键ID*/
	PKID				INT IDENTITY	 	NOT NULL,
	/*邮件*/
	Email				NVARCHAR(50)		NOT NULL,
	/*密码*/
	Password			NVARCHAR(2000)		NOT NULL,
	/*账户等级ID*/
	CustomerLevelID			INT			NOT NULL DEFAULT (-1),
	/*注册时间*/
	RegistrationDate		DATETIME		NOT NULL,
	/*默认使用的地址*/
	FavorShippingAddressID		INT,
	/*默认使用的发票配置*/
	FavorInvoiceConfigID		INT,
	/*是否显示价格*/
	IsDisplayPrice			int			NOT NULL DEFAULT (0),
	/*账户是否有效*/
	valid				int			NOT NULL DEFAULT (1),
	/*客户ID*/
	CustomerID			UNIQUEIDENTIFIER	NOT NULL DEFAULT ('00000000-0000-0000-0000-000000000000'),	
	/*账户消费总额*/
	TotalPrice			Decimal		NOT NULL DEFAULT (0),	

    CONSTRAINT PK_TCustomerAccount PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TCustomerAccount UNIQUE NONCLUSTERED (PKID)
) 
GO

/*账户等级*/
CREATE TABLE TCustomerAccountLevel (
	/*账户等级ID*/
	PKID				INT IDENTITY		NOT NULL,
	/*账户等级名称*/
	CustomerAccountLevelName	NVARCHAR(50)		NOT NULL,
	/*账户等级最低消费金额*/
	MinimumAmount			Decimal(25,2)		NOT NULL default (0)

    CONSTRAINT PK_TCustomerAccountLevel PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TCustomerAccountLevel UNIQUE NONCLUSTERED (PKID)
) 
GO

/*送货地址*/
CREATE TABLE TCustomerShippingAddress (
	/*主键ID*/
	PKID INT IDENTITY NOT NULL,
	/*账户ID*/
	CustomerAccountID INT	NOT NULL,
	/*联系人姓名*/
	ContactName	Nvarchar(50)	NOT NULL,		
	/*联系电话*/
	ContactPhone	Nvarchar(50)	NOT NULL,		
	/*送货地址*/
	ShippingAddress	Nvarchar(255)	NOT NULL,
)

/*发票配置*/
CREATE TABLE TCustomerInvoiceConfig (
	/*主键ID*/
	PKID INT IDENTITY NOT NULL,
	/*账户ID*/
	CustomerAccountID INT	NOT NULL,
	/*是否需要发票：0、不需要1、商业发票 2、增值税发票*/
	NeedInvoice	Int	NOT NULL,	
	/*发票抬头*/
	InvoiceTitle	Nvarchar(255)	NULL,	
	/*增值税代号*/
	VATCode		Nvarchar(50),
)

/*销售订单*/
CREATE TABLE TSalesOrder (
	/*主键ID*/
	PKID INT IDENTITY NOT NULL,
	/*唯一标识*/
	OrderGUID	UNIQUEIDENTIFIER	NOT NULL,
	/*客户帐号ID*/
	CustomerAccountID	INT	NOT NULL,
	/*销售员 员工ID*/
	SalesID INT NOT NULL,
	/*销售员姓名*/
	SalesName NVARCHAR(50) NOT NULL,
	/*订单中商品金额（不包括服务费）*/
	GoodsValue MONEY NOT NULL,
	/*加收服务费*/
	ServiceFee MONEY NOT NULL,
	/*订单总金额（发票金额）= GoodsValue + ServiceFee*/
	TotalValue MONEY NOT NULL,
	/*流程状态1、未确认2、已确认3、正在配货4、已出库 5、已送出 6、已送达*/
	FlowStatusId	INT 	NOT NULL,		
	/*订单状态：1、进行中2、完成3、退单*/
	OrderStatusId	INT	NOT NULL,		
	/*支付状态：1、未付款2、已付款*/
	PaymentStatusId	INT	NOT NULL,		
	/*出库日期*/
	OutStockDate DATETIME NULL,
	/*开发票日期*/
	InvoiceDate DATETIME NULL,
	/*送出日期*/
	DeliveryDate DATETIME NULL,
	/*订货公司*/
	OrderCompany	NVARCHAR(50)	NOT NULL,
	/*联系人姓名*/
	ContactName	NVARCHAR(50)	NOT NULL,
	/*联系电话*/
	ContactPhone	NVARCHAR(50)	NOT NULL,		
	/*送货地址*/
	ShippingAddress	NVARCHAR(200)	NOT NULL,
	/*是否需要发票：0、不需要1、商业发票 2、增值税发票*/
	NeedInvoiceId	INT	NOT NULL,
	/*是否已打印发票：0、否1、是 */
	HasInvoiceId INT NOT NULL,	
	/*发票抬头*/
	InvoiceTitle Nvarchar(200)	NOT NULL,
	/*增值税代号*/
	VATCode		NVARCHAR(50) NOT NULL,
	/*订单来源 0、员工输入1、网站订购*/
	OrderResourceId INT NOT NULL,
	/*订单备注*/
	OrderRemark	Nvarchar(2000)	NOT NULL,		
	/*创建时间*/
	CreateOn	DateTime	NULL,
	CONSTRAINT PK_TSalesOrder PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TSalesOrder UNIQUE NONCLUSTERED (PKID)
	)
GO

/*销售订单明细*/
CREATE TABLE TSalesOrderItem (
	/*主键ID*/
	PKID INT IDENTITY NOT NULL,
	/*销售订单ID*/
	SalesOrderID INT NOT NULL,		
	/*货物ID*/
	ProductID INT NOT NULL,		
	/*商品编码*/
	ProductManufacturerPartNumber NVARCHAR(50) NOT NULL,
	/*商品名称*/
	ProductFullName NVARCHAR(100) NOT NULL,
	/*平均采购价格(交货时系统取平均值)用于成本统计、结算*/
	AveragePurchasePrice MONEY NOT NULL,
	/*平均进货成本(平均)=采购价格+其它成本*/
	AverageLandedCost MONEY NOT NULL,
	/*默认售价*/
	DefaultPrice MONEY NOT NULL,		
	/*销售单价*/
	SalePrice MONEY NOT NULL,		
	/*数量*/
	Quantity DECIMAL(20,8) NOT NULL,		
	/*分配数量(准备配货数量)*/
	LocatedQty DECIMAL(20,8) NOT NULL,
	/*出库数量*/
	OutQty DECIMAL(20,8) NOT NULL,
	CONSTRAINT PK_TSalesOrderItem PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TSalesOrderItem UNIQUE NONCLUSTERED (PKID)
	)
GO

/*销售订单日志记录*/
CREATE TABLE TSalesOrderNote (
	/*主键ID*/
	PKID INT IDENTITY NOT NULL,
	/*销售订单ID*/
	SalesOrderID	INT	NOT NULL,		
	/*记录内容*/
	Note	NVARCHAR(200)	NOT NULL,		
	/*创建时间*/
	CreateOn	DATETIME	NOT NULL,		
	CONSTRAINT PK_TSalesOrderNote PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TSalesOrderNote UNIQUE NONCLUSTERED (PKID)
	)
GO

/*价套*/
CREATE TABLE dbo.TPriceCode(
	PKID INT IDENTITY NOT NULL,
	/*价套名称*/
	[Name] NVARCHAR(200) NOT NULL,
	/*开始日期*/
	DateFrom DATETIME NULL,
	/*结束日期*/
	DateTo DATETIME NULL,
	/*价格调整类型(
		0:相对折扣N：价格=N/100*默认价格;
		1:立减N：价格=默认价格-N(价格必须大于等于0);
		2:绝对N：价格=N)*/
	PriceAdjustmentTypeId INT NOT NULL,
	/*备注*/
	Remark NVARCHAR(200) NOT NULL,
	/*是否有效，0为无效，1为有效*/
	IsVaild INT NOT NULL,
	CONSTRAINT PK_TPriceCode PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TPriceCode UNIQUE NONCLUSTERED (PKID)
)
GO

/*商品定价*/
CREATE TABLE dbo.TProductPrice(
	PKID INT IDENTITY NOT NULL,
	/*价套Id*/
	PriceCodeId int NOT NULL,
	/*商品Id*/
	ProductId INT NOT NULL,
	/*售价阀值(和对应价套的价格调整类型共同计算售价)*/
	[Value] DECIMAL(20,8) NOT NULL,
	/*单位*/
	Unit nvarchar(50) NOT NULL,
	/*备注*/
	Remark Nvarchar(200) NOT NULL,
	CONSTRAINT PK_TProductPrice PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TProductPrice UNIQUE NONCLUSTERED (PKID)
)
GO

/*账户与价套绑定*/
CREATE TABLE TCustomerAccountMappingPriceCode (
	/*PKID*/
	PKID INT IDENTITY NOT NULL,
	/*账户ID*/
	CustomerAccountId INT NOT NULL,
	/*帐套ID*/
	PriceCodeId	INT NOT NULL,
    CONSTRAINT PK_TCustomerAccountMappingPriceCode PRIMARY KEY NONCLUSTERED (PKID),
    CONSTRAINT TC_TCustomerAccountMappingPriceCode UNIQUE NONCLUSTERED (PKID)
) 
GO

/***********************************************************************************/
/************         End   销售模块			****************************/
/***********************************************************************************/

/***********************************************************************************/
/************         Begin  会计科目	(施益宇)	        ****************************/
/***********************************************************************************/
CREATE TABLE TAccountCode (
	/*PKID*/
	PKID				INT			NOT NULL,
	/*科目编号*/
	Code				NVARCHAR ( 50 )		NOT NULL,
	/*会计科目名称*/
	FullName			NVARCHAR ( 50 )		NOT NULL,
	/*类型  B资产负债科目 P损益科目 Z统计科目*/
	Type				NCHAR ( 1 )		NOT NULL,
	/*上级会计科目*/
	ParentID			INT			NOT NULL,
	/*是否有效(0:无效；1：有效);默认为有效*/
	Valid				INT			NOT NULL DEFAULT((1)),
	/*最后更新者*/
	LastModifier			NVARCHAR ( 50 )		DEFAULT '',
	/*最后更新时间*/
	LastModifyTime			DATETIME

	CONSTRAINT PK_TAccountCode PRIMARY KEY NONCLUSTERED (PKID),
	CONSTRAINT TC_TAccountCode UNIQUE NONCLUSTERED (PKID)
)
/***********************************************************************************/
/************         End     会计科目 			****************************/
/***********************************************************************************/

/***********************************************************************************/
/************         Begin   商品（ZZ）		****************************/
/***********************************************************************************/
CREATE TABLE TCategory	(	
			/*主键ID*/   
			PKID	           INT IDENTITY NOT NULL,
			/*分类名称*/
			[Name]             Nvarchar(100)    NOT NULL,
			/*分类描述*/
			[Description]      Nvarchar(200)   NOT NULL,
			/*分类的父类ID 默认为空,即是一级分类*/
			ParentCategoryID   INT  DEFAULT (0) NOT NULL,
			/*是否显示在前台标志位,默认显示，1显示,0不显示*/
			Published          int   NOT NULL,
			/*创建日期*/
			CreatedOn          datetime        NOT NULL,
			/*修改日期*/
			UpdatedOn          datetime        NOT NULL
		
CONSTRAINT PK_TCategory PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TCategory UNIQUE NONCLUSTERED (PKID)
)	
GO

/*商品*/
CREATE TABLE TProduct	(
			/*主键ID*/   
			PKID	                INT	   IDENTITY   NOT NULL,
            /*条形码*/
            BarCode                 Nvarchar(50)    NOT NULL,
            /*供应商PartNumber*/
            ManufacturerPartNumber  Nvarchar(50)    NOT NULL,
			/*商品名称*/            
			FullName                Nvarchar(100)    NOT NULL,
            /*商品英文名称*/
	        FullNameE               NVARCHAR ( 100 ) DEFAULT '',
			/*商品简单描述*/
			ShortDescription        Nvarchar(200) DEFAULT '',  
			/*商品详细描述*/
			FullDescription         TEXT  DEFAULT '' ,
			/*是否显示在前台标志位,默认显示，1显示，0不显示*/
			Published               int   NOT NULL,
			/*是否显示在前台首页标志位,默认显示，1显示，0不显示*/
			ShowOnHomePage          int  NOT NULL,
			/*会计科目代号*/
	        AccountCode            NVARCHAR ( 50 ) DEFAULT '' NOT NULL,
			/*库存单位*/
	        StockUnit             NVARCHAR ( 50 ) DEFAULT '' NOT NULL,
			/*采购单位*/
			PurchaseUnit          NVARCHAR ( 50 ) DEFAULT '' NOT NULL,
			/*销售单位*/
			SaleUnit              NVARCHAR ( 50 ) DEFAULT '' NOT NULL,  
			/*平均进货成本*/
			AverageLandedCost     MONEY DEFAULT 0 NOT NULL,
			/*平均采购价格*/
			AveragePurchasePrice   MONEY DEFAULT 0 NOT NULL,      
			/*市场价*/
			MarketPrice            MONEY DEFAULT 0 NOT NULL,
			/*默认售价*/
			SalePrice             MONEY DEFAULT 0 NOT NULL,
            /*重量*/
			Weight                decimal(18, 4)  DEFAULT (0) NOT NULL,	
            /*尺寸,长宽高*/		
            [Size ]                 NVARCHAR ( 50 ) DEFAULT ''NOT NULL,
             /*颜色*/
            Color                 NVARCHAR ( 50 ) DEFAULT '' NOT NULL,
            /*排序标志  数字越大，排序越前*/
	        SortFlag              INT DEFAULT 0    NOT NULL,
			/*创建日期*/
			CreatedOn               datetime        NOT NULL,
			/*修改日期*/
			UpdatedOn               datetime        NOT NULL

CONSTRAINT PK_TProduct PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TProduct UNIQUE NONCLUSTERED (PKID)
)	
GO


/*商品_分类Mapping,一个商品对应多个分类,其中有且只有一个为真实分类*/
CREATE TABLE TProduct_Category_Mapping(
			/*主键ID*/   
			PKID                  INT	   IDENTITY   NOT NULL,
			/*商品主键ID*/
			ProductID             int  NOT NULL,
			/*分类主键ID*/
			CategoryID            int  NOT NULL,
			/*是否是真实分类*/
			IsTrueCategory        int   NOT NULL

CONSTRAINT PK_TProduct_Category_Mapping PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TProduct_Category_Mapping UNIQUE NONCLUSTERED (PKID)
)	
GO

/*图片*/
CREATE TABLE TProductPicture(
			/*主键ID*/   
			PKID                  INT	   IDENTITY   NOT NULL,
            /*商品ID*/
			ProductID             INT      NOT NULL,
            /*图片数据*/
			PictureBinary         IMAGE    NOT NULL,  
            /*是否是默认显示图*/
            IsDefault             int   NOT NULL   

CONSTRAINT PK_TProductPicture PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TProductPicture UNIQUE NONCLUSTERED (PKID)
)	
GO

/***********************************************************************************/
/************         End   商品（ZZ）		****************************/
/***********************************************************************************/

/***********************************************************************************/
/************       Begin      库存模块    chenzhongchao          ******************/
/***********************************************************************************/
/****** 对象:  Table [TWarehouse]: 仓库    脚本日期: 07/01/2009 10:54:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TWarehouse](
	/*流水号*/
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	/*仓库名称*/
	[Name] [nvarchar](255) NOT NULL,
	/*类型(0:正品库，1:坏品库)*/
	[Type] [int] NOT NULL DEFAULT((0)),
	/*电话*/
	[PhoneNumber] [nvarchar](50) NULL,
	/*Email*/
	[Email] [nvarchar](50) NULL,
	/*传真*/
	[FaxNumber] [nvarchar](50) NULL,
	/*地址*/
	[Address] [nvarchar](255) NULL,
	/*城市*/
	[City] [nvarchar](50) NULL,
	/*省份*/
	[StateProvince] [nvarchar](50) NULL,
	/*邮编*/
	[ZipPostalCode] [nvarchar](50) NULL,
	/*是否有效(0:无效；1：有效);默认为有效*/
	[Valid] [int] NOT NULL DEFAULT((1)),
	/*创建日期*/
	[CreatedOn] [datetime] NOT NULL DEFAULT GETDATE(),
	/*修改日期*/
	[UpdatedOn] [datetime] NOT NULL DEFAULT GETDATE(),
	/*操作者Id*/
	[OperatorID] [int] NOT NULL,
	/*备注*/
	[Remark] [text] NULL,
 CONSTRAINT [PK_TWarehouse] PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** 对象:  Table [TProductStock]：商品库存    脚本日期: 07/01/2009 13:27:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TProductStock](
	/*流水号*/
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	/*商品Id*/
	[ProductID] [int] NOT NULL,
	/*单位*/
	[Unit] [nvarchar](50) NOT NULL,
	/*库存数*/
	[Balance] [decimal](20, 8) NOT NULL DEFAULT ((0)),
	/*订单预订数*/
	[ReservedQty] [decimal](20, 8) NOT NULL DEFAULT ((0)),
	/*已配货数量*/
	[LocatedQty] [decimal](20, 8) NOT NULL DEFAULT ((0)),
	/*平均进货成本*/
	[AverageLandedCost] [money] NOT NULL DEFAULT ((0)),
	/*平均采购价格*/
	[AveragePurchasePrice] [money] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_TProductStock] PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** 对象:  Table [TBatchStock]：商品仓库批次库存    脚本日期: 07/06/2009 13:09:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TBatchStock](
	/*流水号*/
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	/*商品Id*/
	[ProductID] [int] NOT NULL,
	/*仓库Id*/
	[WarehouseID] [int] NOT NULL,
	/*批次号*/
	[Batch] [nvarchar](50) NOT NULL,
	/*单位*/
	[Unit] [nvarchar](50) NOT NULL,
	/*库存数量*/
	[Balance] [decimal](20, 8) NOT NULL DEFAULT ((0)),
	/*已分配数量*/
	[LocatedQty] [decimal](20, 8) NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_TBatchStock] PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** 对象:  Table [TStockTrans]：商品库存交易    脚本日期: 07/06/2009 13:10:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TStockTrans](
	/*流水号*/
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	/*商品Id*/
	[ProductID] [int] NOT NULL,
	/*仓库Id*/
	[WarehouseID] [int] NOT NULL,
	/*批次号*/
	[Batch] [nvarchar](50) NOT NULL,
	/*订单类型：(0:销售订单，1:采购订单，2:调拨单)*/
	[OrderType] [int] NOT NULL,
	/*订单号*/
	[OrderID] [int] NOT NULL,
	/*交易类型：(0：采购入库，1：销售退货入库，2：销售出库，3：采购退货出库，4：调拨出库，5：调拨入库，6：盘点)*/
	[TransType] [int] NOT NULL,
	/*数量*/
	[Quantity] [decimal](20, 8) NOT NULL,
	/*单位*/
	[Unit] [nvarchar](50) NOT NULL,
	/*交易日期*/
	[TransDate] [datetime] NOT NULL DEFAULT GETDATE(),
	/*交易价格*/
	[SalePrice] [money] NOT NULL DEFAULT ((0)),
	/*会计号码*/
	[AccountCode] [nvarchar](50) NOT NULL DEFAULT '',
	/*平均进货成本*/
	[AverageLandedCost] [money] NOT NULL DEFAULT ((0)),
	/*平均采购价格*/
	[AveragePurchasePrice] [money] NOT NULL DEFAULT ((0)),
	/*操作者Id*/
	[OperatorID] [int] NOT NULL,
	/*备注*/
	[Remark] [text] NULL,
 CONSTRAINT [PK_TStockTrans] PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 对象:  Table [TDistribution]: 销售订单配货    脚本日期: 07/08/2009 15:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TDistribution](
	/*流水号*/
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	/*销售订单Id*/
	[SalesOrderID] [int] NOT NULL,
	/*配货员Id*/
	[DistributionManID] [int] NOT NULL,
	/*创建日期*/
	[CreatedOn] [datetime] NOT NULL DEFAULT (GETDATE()),
	/*修改日期*/
	[UpdatedOn] [datetime] NOT NULL DEFAULT (GETDATE()),
	/*操作者Id*/
	[OperatorID] [int] NOT NULL,
	/*是否出库*/
	[OutStockStatus] [int] NOT NULL,
	/*是否有效(0:无效；1：有效);默认为有效*/
	[Valid] [int] NOT NULL DEFAULT ((1)),
 CONSTRAINT [PK_TDistribution] PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 对象:  Table [TDistributionItem]：配货明细    脚本日期: 07/08/2009 15:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TDistributionItem](
	/*流水号*/
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	/*配货Id*/
	[DistributionID] [int] NOT NULL,
	/*产品Id*/
	[ProductID] [int] NOT NULL,
	/*仓库Id*/
	[WarehouseID] [int] NOT NULL,
	/*批次号*/
	[Batch] [nvarchar](50) NOT NULL,
	/*数量*/
	[Quantity] [decimal](20, 8) NOT NULL,
	/*单位*/
	[Unit] [nvarchar](50) NOT NULL,
	/*售价*/
	[SalePrice] [money] NOT NULL,
 CONSTRAINT [PK_TDistributionItem] PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/***********************************************************************************/
/************       End      库存模块    chenzhongchao            ******************/
/***********************************************************************************/


/***********************************************************************************/
/************       Begin     采购模块    chenzhongchao           ******************/
/***********************************************************************************/
/****** 对象:  Table [dbo].[TProvider]：供应商    脚本日期: 07/01/2009 13:18:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TProvider](
	/*流水号*/
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	/*供应商名称*/
	[Name] [nvarchar](255) NOT NULL,
	/*地址*/
	[Address] [nvarchar](255) NULL,
	/*邮编*/
	[ZipPostalCode] [nvarchar](50) NULL,
	/*公司邮箱*/
	[Email] [nvarchar](50) NULL,
	/*联系人*/
	[Linkman] [nvarchar](50) NULL,
	/*电话*/
	[PhoneNumber] [nvarchar](50) NULL,
	/*手机号*/
	[MobileNumber] [nvarchar](50) NULL,
	/*预付会计科目 Pay In Advance*/
	[PIAAccountCode] NVARCHAR ( 50 ) DEFAULT '' NOT NULL,
	/*（应付）会计科目*/
	[AccountCode] NVARCHAR ( 50 ) DEFAULT '' NOT NULL,
	/*增值税登记号*/
	[VATRegNumber] NVARCHAR ( 50 ) DEFAULT '',
	/*增值税代号*/
	[VATCode] NVARCHAR ( 50 ) DEFAULT '' NOT NULL,
	/*备注*/
	[Remark] [text] NULL
 CONSTRAINT [PK_TProvider] PRIMARY KEY CLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE TProviderProduct(
    /*主键ID*/
	PKID int IDENTITY  NOT NULL,
	ProviderID int  NOT  NULL,
	ProductID int  NOT NULL,
	Price  MONEY DEFAULT (0) NOT NULL,
	Valid  INT  NOT NULL

CONSTRAINT PK_TProviderProduct PRIMARY KEY NONCLUSTERED (PKID),
CONSTRAINT TC_TProviderProduct UNIQUE NONCLUSTERED (PKID)
)	
GO
/****** 对象:  Table [dbo].[TPurchaseOrder]:采购订单    脚本日期: 07/06/2009 11:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TPurchaseOrder](
	/*流水号*/
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	/*供应商ID*/
	[ProviderID] [int] NOT NULL,
	/*供应商名称*/
	[ProviderName] [nvarchar](255) NOT NULL,
	/*订单状态：1、进行中2、完成3、放弃*/
	[OrderStatus] [int] NOT NULL,
	/*其他费用*/
	[OtherCost] [money] NOT NULL,
	/*订单总金额*/
	[TotalValue] [money] NOT NULL,
	/*下订单日期*/
	[OrderDate] [datetime] NOT NULL,
	/*要求送货时间*/
	[RequiredDate] [datetime] NOT NULL,
	/*交货日期*/
	[DeliveryDate] [datetime] NULL DEFAULT ('0'),
	/*采购员流水号*/
	[PurchaserID] [int] NOT NULL,
	/*采购员姓名*/
	[PurchaserName] [nvarchar](50) NOT NULL,
	/*收货员流水号*/
	[AcceptProductManID] [int] NOT NULL,
	/*收货员姓名*/
	[AcceptProductManName] [nvarchar](50) NOT NULL,
	/*收货货地址*/
	[DeliveryAddress] [nvarchar](200) NOT NULL,
	/*发票类型 0商业发票；1暂不开票；2增值税发票*/
	[InvoiceType] INT DEFAULT 0,
	/*发票主键ID*/
	[InvoiceID] INT,
	/*增值税代号*/
	[VATCode] NVARCHAR ( 50 ) DEFAULT '',
	/*增值税率*/
	[VATRate] DECIMAL ( 20, 8 ) DEFAULT 0,
	/*会计科目代码*/
	[AccountCode] NVARCHAR ( 50 ) DEFAULT '',
	/*备注*/
	[Remark] [nvarchar](2000) NOT NULL,
	/*创建时间*/
	[CreateOn] [datetime] NOT NULL	
 CONSTRAINT [PK_TPurchaseOrder] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TPurchaseOrder] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** 对象:  Table [dbo].[TPurchaseOrderItem]: 采购订单明细    脚本日期: 07/06/2009 11:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TPurchaseOrderItem](
	/*流水号*/
	[PKID] [int] IDENTITY(1,1) NOT NULL,
	/*采购订单ID*/
	[PurchaseOrderID] [int] NOT NULL,
	/*商品ID*/
	[ProductID] [int] NOT NULL,
	/*货物PartNumber*/
	[ManufacturerPartNumber] [nvarchar](50) NOT NULL,
	/*货物名称*/
	[ProductFullName] [nvarchar](100) NOT NULL,
	/*采购单价*/
	[PurchasePrice] [money] NOT NULL,
	/*订购商品数量*/
	[Quantity] [int] NOT NULL,
	/*到库数量*/
	[InStockQty] [int] NOT NULL,
	/*单位*/
	[Unit] [nvarchar](50) NOT NULL
	
 CONSTRAINT [PK_TPurchaseOrderItem] PRIMARY KEY NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [TC_TPurchaseOrderItem] UNIQUE NONCLUSTERED 
(
	[PKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/***********************************************************************************/
/************       End       采购模块    chenzhongchao           ******************/
/***********************************************************************************/
