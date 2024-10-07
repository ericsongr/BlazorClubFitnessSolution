
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](50) NULL,
	[Timezone] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[Street] [nvarchar](500) NULL,
	[SubUrb] [nvarchar](500) NULL,
	[State] [nvarchar](500) NULL,
	[PostalCode] [nvarchar](500) NULL,
	[Email] [nvarchar](500) NULL,
	[PhoneNumber] [nvarchar](100) NULL,
	[WebsiteUrl] [varchar](500) NULL,
	[FacebookUrl] [varchar](500) NULL,
	[AddressLine1] [varchar](200) NULL,
	[City] [varchar](200) NULL,
	[DialingCode] [nvarchar](5) NOT NULL,
	[BusinessOwnerName] [varchar](100) NULL,
	[BusinessOwnerPhoneNumber] [varchar](100) NULL,
	[BusinessOwnerEmail] [varchar](100) NULL,
	[GeoCoordinates] [varchar](75) NULL,
	[ClubfitFeeFailedPaymentCount] [int] NOT NULL,
	[PaymentIssueSuspensionDate] [datetime] NULL,
	[AdvancedEmailEditorUid] [uniqueidentifier] NOT NULL,
	[CompanyLegalName] [varchar](200) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Accounts] ADD  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[Accounts] ADD  DEFAULT ((61)) FOR [DialingCode]
GO

ALTER TABLE [dbo].[Accounts] ADD  DEFAULT ((0)) FOR [ClubfitFeeFailedPaymentCount]
GO

ALTER TABLE [dbo].[Accounts] ADD  DEFAULT (newsequentialid()) FOR [AdvancedEmailEditorUid]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AccountSupplier](
	[AccountSupplierId] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NULL,
	[SupplierNumber] [int] NOT NULL,
	[SupplierName] [nvarchar](50) NOT NULL,
	[SupplierReference] [nvarchar](40) NULL,
	[ContactFirstName] [nvarchar](50) NULL,
	[ContactLastName] [nvarchar](50) NULL,
	[ContactEmail] [nvarchar](255) NULL,
	[ContactPhone] [nvarchar](30) NULL,
	[ContactMobile] [nvarchar](30) NULL,
	[ContactFax] [nvarchar](30) NULL,
	[BusinessNumber] [nvarchar](100) NULL,
	[AccountNumber] [nvarchar](40) NULL,
	[WebAccountURL] [nvarchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[LeadTimeDays] [int] NULL,
	[ShippingReference] [nvarchar](64) NULL,
	[CreatedUtcDateTime] [datetime] NOT NULL,
	[UpdatedUtcDateTime] [datetime] NOT NULL,
	[DisplayImagePath] [nvarchar](255) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedDateUtc] [datetime] NULL,
	[DeletedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_AccountSupplier] PRIMARY KEY CLUSTERED 
(
	[AccountSupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AccountSupplier] ADD  CONSTRAINT [DF_AccountSupplier_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[AccountSupplier] ADD  CONSTRAINT [DF_AccountSupplier_CreatedUtcDateTime]  DEFAULT (getutcdate()) FOR [CreatedUtcDateTime]
GO

ALTER TABLE [dbo].[AccountSupplier] ADD  CONSTRAINT [DF_AccountSupplier_UpdatedUtcDateTime]  DEFAULT (getutcdate()) FOR [UpdatedUtcDateTime]
GO

ALTER TABLE [dbo].[AccountSupplier] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[AccountSupplier]  WITH CHECK ADD  CONSTRAINT [FK_AccountSupplier_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO

ALTER TABLE [dbo].[AccountSupplier] CHECK CONSTRAINT [FK_AccountSupplier_Accounts]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The expected number of days between placing an order and the order being received at the Account.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountSupplier', @level2type=N'COLUMN',@level2name=N'LeadTimeDays'
GO


/****** Object:  Table [dbo].[AccountProductCategory]    Script Date: 10/6/2024 6:54:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AccountProductCategory](
	[AccountProductCategoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NULL,
	[ProductCategoryName] [nvarchar](40) NOT NULL,
	[ShortDescription] [nvarchar](255) NULL,
	[CreatedUtcDateTime] [datetime] NOT NULL,
	[CreatedUserName] [nvarchar](50) NOT NULL,
	[UpdatedUtcDateTime] [datetime] NOT NULL,
	[UpdatedUserName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DisplayImagePath] [nvarchar](255) NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsPosCategory] [bit] NOT NULL,
 CONSTRAINT [PK_AccountProductCategory] PRIMARY KEY CLUSTERED 
(
	[AccountProductCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AccountProductCategory] ADD  CONSTRAINT [DF_AccountProductCategory_CreatedUtcDateTime]  DEFAULT (getutcdate()) FOR [CreatedUtcDateTime]
GO

ALTER TABLE [dbo].[AccountProductCategory] ADD  CONSTRAINT [DF_AccountProductCategory_UpdatedUtcDateTime]  DEFAULT (getutcdate()) FOR [UpdatedUtcDateTime]
GO

ALTER TABLE [dbo].[AccountProductCategory] ADD  CONSTRAINT [DF_AccountProductCategory_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[AccountProductCategory] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[AccountProductCategory] ADD  DEFAULT ((1)) FOR [IsPosCategory]
GO

ALTER TABLE [dbo].[AccountProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_AccountProductCategory_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO

ALTER TABLE [dbo].[AccountProductCategory] CHECK CONSTRAINT [FK_AccountProductCategory_Accounts]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AccountProductSubCategory](
	[AccountProductSubCategoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NULL,
	[AccountProductCategoryId] [bigint] NOT NULL,
	[ProductSubCategoryName] [nvarchar](40) NOT NULL,
	[ShortDescription] [nvarchar](255) NULL,
	[CreatedUtcDateTime] [datetime] NOT NULL,
	[CreatedUserName] [nvarchar](50) NOT NULL,
	[UpdatedUtcDateTime] [datetime] NOT NULL,
	[UpdatedUserName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DisplayImagePath] [nvarchar](255) NULL,
	[DeletedDateUtc] [datetime] NULL,
	[DeletedBy] [nvarchar](50) NULL,
	[GlCode] [varchar](15) NULL,
 CONSTRAINT [PK_AccountProductSubCategory] PRIMARY KEY CLUSTERED 
(
	[AccountProductSubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AccountProductSubCategory] ADD  CONSTRAINT [DF_AccountProductSubCategory_CreatedUtcDateTime]  DEFAULT (getutcdate()) FOR [CreatedUtcDateTime]
GO

ALTER TABLE [dbo].[AccountProductSubCategory] ADD  CONSTRAINT [DF_AccountProductSubCategory_UpdatedUtcDateTime]  DEFAULT (getutcdate()) FOR [UpdatedUtcDateTime]
GO

ALTER TABLE [dbo].[AccountProductSubCategory] ADD  CONSTRAINT [DF_AccountProductSubCategory_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[AccountProductSubCategory] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[AccountProductSubCategory]  WITH CHECK ADD  CONSTRAINT [FK_AccountProductSubCategory_AccountProductCategory] FOREIGN KEY([AccountProductCategoryId])
REFERENCES [dbo].[AccountProductCategory] ([AccountProductCategoryId])
GO

ALTER TABLE [dbo].[AccountProductSubCategory] CHECK CONSTRAINT [FK_AccountProductSubCategory_AccountProductCategory]
GO

ALTER TABLE [dbo].[AccountProductSubCategory]  WITH CHECK ADD  CONSTRAINT [FK_AccountProductSubCategory_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO

ALTER TABLE [dbo].[AccountProductSubCategory] CHECK CONSTRAINT [FK_AccountProductSubCategory_Accounts]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Product sub-category internal identifier (primary key)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProductSubCategory', @level2type=N'COLUMN',@level2name=N'AccountProductSubCategoryId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Product category to which the sub-category belongs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProductSubCategory', @level2type=N'COLUMN',@level2name=N'AccountProductCategoryId'
GO




