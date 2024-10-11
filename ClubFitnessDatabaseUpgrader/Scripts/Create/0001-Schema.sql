
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
	[DeletedDateTimeUtc] [datetime] NULL,
	[DeletedBy] [INT] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT(0),
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
	[AccountSupplierId] [int] IDENTITY(1,1) NOT NULL,
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
	[IsDeleted] [bit] NOT NULL DEFAULT(0),
	[DeletedDateTimeUtc] [datetime] NULL,
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
	[AccountProductCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NULL,
	[ProductCategoryName] [nvarchar](40) NOT NULL,
	[ShortDescription] [nvarchar](255) NULL,
	[CreatedUtcDateTime] [datetime] NOT NULL,
	[CreatedUserName] [nvarchar](50) NOT NULL,
	[UpdatedUtcDateTime] [datetime] NOT NULL,
	[UpdatedUserName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DisplayImagePath] [nvarchar](255) NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT(0),
	[DeletedDateTimeUtc] [datetime] NULL,
	[DeletedBy] int NULL,
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
	[AccountProductSubCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[AccountProductCategoryId] [int] NOT NULL,
	[ProductSubCategoryName] [nvarchar](40) NOT NULL,
	[ShortDescription] [nvarchar](255) NULL,
	[CreatedUtcDateTime] [datetime] NOT NULL,
	[CreatedUserName] [nvarchar](50) NOT NULL,
	[UpdatedUtcDateTime] [datetime] NOT NULL,
	[UpdatedUserName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DisplayImagePath] [nvarchar](255) NULL,
	[GlCode] [varchar](15) NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT(0),
	[DeletedDateTimeUtc] [datetime] NULL,
	[DeletedBy] int NULL,
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

/****** Object:  Table [dbo].[Staff]    Script Date: 10/9/2024 11:25:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Staff](
	[StaffId] [int] IDENTITY(90000,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[Barcode] [varchar](10) NULL,
	[LastModifiedUTCDateTime] [datetime] NOT NULL,
	[MobilePhone] [nvarchar](20) NOT NULL,
	[HomePhone] [nvarchar](20) NULL,
	[PhotoLocation] [nvarchar](300) NULL,
	[Email] [nvarchar](255) NULL,
	[ProviderUserKey] [uniqueidentifier] NULL,
	[AccessControlUserId] [int] NULL,
	[Role] [nvarchar](20) NULL,
	[IsRegister] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[PosAccessPin] [nvarchar](4) NULL,
	[CanModify] [bit] NOT NULL,
	[IsSubscribeReminder] [bit] NOT NULL,
	[PreferredClub] [int] NULL,
	[EnablePreferredClubPrompt] [bit] NOT NULL,
	[HourlyRate] [money] NOT NULL,
	[RestrictAccessByIp] [bit] NOT NULL,
	[RestrictedIp] [varchar](50) NULL,
	[EnableMfa] [bit] NOT NULL,
	[MfaProvider] [int] NOT NULL,
	[IsSaleStaff] [bit] NOT NULL,
	[DeletedDateTimeUtc] [datetime] NULL,
	[DeletedBy] [INT] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT(0),
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Staff] ADD  CONSTRAINT [DF_Staff_LastModifiedUTCDateTime]  DEFAULT (getutcdate()) FOR [LastModifiedUTCDateTime]
GO

ALTER TABLE [dbo].[Staff] ADD  DEFAULT (NULL) FOR [ProviderUserKey]
GO

ALTER TABLE [dbo].[Staff] ADD  DEFAULT ((0)) FOR [IsRegister]
GO

ALTER TABLE [dbo].[Staff] ADD  DEFAULT ((1)) FOR [CanModify]
GO

ALTER TABLE [dbo].[Staff] ADD  DEFAULT ((1)) FOR [IsSubscribeReminder]
GO

ALTER TABLE [dbo].[Staff] ADD  DEFAULT ((0)) FOR [PreferredClub]
GO

ALTER TABLE [dbo].[Staff] ADD  DEFAULT ((0)) FOR [EnablePreferredClubPrompt]
GO

ALTER TABLE [dbo].[Staff] ADD  DEFAULT ((0)) FOR [HourlyRate]
GO

ALTER TABLE [dbo].[Staff] ADD  DEFAULT ((0)) FOR [RestrictAccessByIp]
GO

ALTER TABLE [dbo].[Staff] ADD  DEFAULT ((0)) FOR [EnableMfa]
GO

ALTER TABLE [dbo].[Staff] ADD  DEFAULT ((0)) FOR [MfaProvider]
GO

ALTER TABLE [dbo].[Staff] ADD  DEFAULT ((1)) FOR [IsSaleStaff]
GO

ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_PreferredClubAccount] FOREIGN KEY([PreferredClub])
REFERENCES [dbo].[Accounts] ([AccountId])
GO

ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_PreferredClubAccount]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DiscountCoupons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[CouponCode] [nvarchar](100) NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[DiscountType] [smallint] NOT NULL,
	[MinimumAmount] [decimal](18, 0) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedUtcDateTime] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedUtcDateTime] [datetime] NULL,
	[ExpiryDate] [datetime] NULL,
	[AccountId] [int] NOT NULL,
	[ChargeType] [varchar](50) NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT(0),
	[DeletedDateTimeUtc] [datetime] NULL,
	[DeletedBy] int NULL,
	[DiscountFor] [smallint] NOT NULL,
	[IsCombineFees] [bit] NOT NULL,
	[AllocatedValueJson] [varchar](max) NULL,
 CONSTRAINT [PK_DiscountCoupons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[DiscountCoupons] ADD  DEFAULT ((0)) FOR [AccountId]
GO

ALTER TABLE [dbo].[DiscountCoupons] ADD  DEFAULT ((1)) FOR [DiscountFor]
GO

ALTER TABLE [dbo].[DiscountCoupons] ADD  DEFAULT ((0)) FOR [IsCombineFees]
GO

ALTER TABLE [dbo].[DiscountCoupons]  WITH CHECK ADD  CONSTRAINT [FK_DiscountCoupons_Staff] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[DiscountCoupons] CHECK CONSTRAINT [FK_DiscountCoupons_Staff]
GO

ALTER TABLE [dbo].[DiscountCoupons]  WITH CHECK ADD  CONSTRAINT [FK_DiscountCoupons_Staff1] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[DiscountCoupons] CHECK CONSTRAINT [FK_DiscountCoupons_Staff1]
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AccountProduct](
	[AccountProductId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[AccountSupplierId] [int] NOT NULL,
	[AccountProductCategoryId] [int] NOT NULL,
	[AccountProductSubCategoryId] [int] NOT NULL,
	[ManufacturerProductNumber] [varchar](40) NULL,
	[MinimumLevelQuantity] [decimal](16, 3) NULL,
	[WarnLevelQuantity] [decimal](16, 3) NULL,
	[MaximumLevelQuantity] [decimal](16, 3) NULL,
	[OnHandQuantity] [decimal](16, 3) NOT NULL,
	[OnHandValue] [money] NULL,
	[OnHandAverageValue] [decimal](19, 6) NULL,
	[CannotOrderAfterDate] [date] NULL,
	[StoreUnitOfMeasureCode] [int] NULL,
	[DefaultPurchaseUnitOfMeasureCode] [int] NULL,
	[DefaultPurchaseToStoreConversionQuantity] [decimal](19, 6) NULL,
	[DefaultSupplierNumber] [int] NULL,
	[DisplayImagePath] [nvarchar](255) NULL,
	[ProductStockLevel] [int] NULL,
	[ProductDiscount] [decimal](19, 6) NULL,
	[ProductStockLowLevel] [int] NULL,
	[ProductName] [varchar](200) NULL,
	[SellExTaxPrice] [money] NULL,
	[SellIncTaxPrice] [money] NULL,
	[SellOnlineEnabled] [bit] NOT NULL,
	[DepartmentType] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsCasualEntry] [bit] NOT NULL,
	[IsPosItem] [bit] NOT NULL,
	[IsStockTakeRequired] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT(0),
	[DeletedDateTimeUtc] [datetime] NULL,
	[DeletedBy] int NULL,
	[GstRequired] [bit] NOT NULL,
	[ExpiryDate] [date] NULL,
	[IsCommissionable] [bit] NOT NULL,
	[CommissionAmount] [decimal](19, 6) NULL,
	[DiscountCouponId] [int] NULL,
 CONSTRAINT [PK_AccountProduct] PRIMARY KEY CLUSTERED 
(
	[AccountProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  CONSTRAINT [DF_AccountProduct_OnHandQuantity]  DEFAULT ((0)) FOR [OnHandQuantity]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  CONSTRAINT [DF_AccountProduct_OnHandValue]  DEFAULT ((0)) FOR [OnHandValue]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  CONSTRAINT [DF_AccountProduct_OnHandAverageValue]  DEFAULT ((0)) FOR [OnHandAverageValue]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  CONSTRAINT [DF_AccountProduct_StoreUnitOfMeasureCode]  DEFAULT ((0)) FOR [StoreUnitOfMeasureCode]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  CONSTRAINT [DF_AccountProduct_DefaultPurchaseUnitOfMeasureCode]  DEFAULT ((0)) FOR [DefaultPurchaseUnitOfMeasureCode]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  CONSTRAINT [DF_AccountProduct_DefaultPurchaseToStoreConversionQuantity]  DEFAULT ((1)) FOR [DefaultPurchaseToStoreConversionQuantity]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  CONSTRAINT [DF_AccountProduct_DefaultSupplierNumber]  DEFAULT ((0)) FOR [DefaultSupplierNumber]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  CONSTRAINT [DF_AccountProduct_SellOnlineEnabled]  DEFAULT ((0)) FOR [SellOnlineEnabled]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  DEFAULT ((0)) FOR [DepartmentType]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  CONSTRAINT [DF__AccountPr__IsAct__4FF1D159]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  DEFAULT ((0)) FOR [IsCasualEntry]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  DEFAULT ((0)) FOR [IsPosItem]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  DEFAULT ((1)) FOR [IsStockTakeRequired]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  CONSTRAINT [DF_AccountProduct_GstRequired]  DEFAULT ((1)) FOR [GstRequired]
GO

ALTER TABLE [dbo].[AccountProduct] ADD  CONSTRAINT [DF_AccountProduct_IsCommissionable]  DEFAULT ((0)) FOR [IsCommissionable]
GO

ALTER TABLE [dbo].[AccountProduct]  WITH CHECK ADD  CONSTRAINT [FK_AccountProduct_AccountProductCategory] FOREIGN KEY([AccountProductCategoryId])
REFERENCES [dbo].[AccountProductCategory] ([AccountProductCategoryId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AccountProduct] CHECK CONSTRAINT [FK_AccountProduct_AccountProductCategory]
GO

ALTER TABLE [dbo].[AccountProduct]  WITH CHECK ADD  CONSTRAINT [FK_AccountProduct_AccountProductSubCategory] FOREIGN KEY([AccountProductSubCategoryId])
REFERENCES [dbo].[AccountProductSubCategory] ([AccountProductSubCategoryId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AccountProduct] CHECK CONSTRAINT [FK_AccountProduct_AccountProductSubCategory]
GO

ALTER TABLE [dbo].[AccountProduct]  WITH CHECK ADD  CONSTRAINT [FK_AccountProduct_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AccountProduct] CHECK CONSTRAINT [FK_AccountProduct_Accounts]
GO

ALTER TABLE [dbo].[AccountProduct]  WITH CHECK ADD  CONSTRAINT [FK_AccountProduct_AccountSupplier] FOREIGN KEY([AccountSupplierId])
REFERENCES [dbo].[AccountSupplier] ([AccountSupplierId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AccountProduct] CHECK CONSTRAINT [FK_AccountProduct_AccountSupplier]
GO

ALTER TABLE [dbo].[AccountProduct]  WITH CHECK ADD  CONSTRAINT [FK_AccountProduct_DiscountCoupon_DiscountCouponId] FOREIGN KEY([DiscountCouponId])
REFERENCES [dbo].[DiscountCoupons] ([Id])
GO

ALTER TABLE [dbo].[AccountProduct] CHECK CONSTRAINT [FK_AccountProduct_DiscountCoupon_DiscountCouponId]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Account product internal identifier (primary key)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'AccountProductId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the preferred supplier for the product.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'AccountSupplierId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the product category to which the product belongs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'AccountProductCategoryId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the product sub-category to which the product belongs (optional)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'AccountProductSubCategoryId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The manufacturer''s item number (or part number) for this product.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'ManufacturerProductNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Minimum on-hand quantity, below which the product will be triggered for reorder.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'MinimumLevelQuantity'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Minimum on-hand quantity below which the system will visually alert the operator.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'WarnLevelQuantity'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The on-hand level up to which the reordering system will order additional stock.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'MaximumLevelQuantity'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The quantity of stock physically held at this Account.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'OnHandQuantity'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The monetary value of stock on hand at this Account.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'OnHandValue'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The monetary value of each item of the product that is currently on hand.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'OnHandAverageValue'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the product can no longer be replenished from the supplier after this date.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'CannotOrderAfterDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'As defined by system code type ''UnitOfMeasure'': 0 - Each, 1 - Pack, 2 - Carton, 3 - Pallet, 4 - Millilitre, 5 - Litre, 4 - Kilogram, 5 - Tonne' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'StoreUnitOfMeasureCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'As defined by system code type ''UnitOfMeasure'': 0 - Each, 1 - Pack, 2 - Carton, 3 - Pallet, 4 - Millilitre, 5 - Litre, 4 - Kilogram, 5 - Tonne' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'DefaultPurchaseUnitOfMeasureCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number of stored units created when a single purchase unit is received. This can differ by supplier.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProduct', @level2type=N'COLUMN',@level2name=N'DefaultPurchaseToStoreConversionQuantity'
GO


