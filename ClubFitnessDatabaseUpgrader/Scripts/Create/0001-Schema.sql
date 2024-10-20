CREATE TABLE AspNetRoles (
    Id NVARCHAR(450) NOT NULL,
    Name NVARCHAR(256) NULL,
    NormalizedName NVARCHAR(256) NULL,
    ConcurrencyStamp NVARCHAR(MAX) NULL,
    CONSTRAINT PK_AspNetRoles PRIMARY KEY (Id)
);
GO

CREATE TABLE AspNetUsers (
    Id NVARCHAR(450) NOT NULL,
    UserName NVARCHAR(256) NULL,
    NormalizedUserName NVARCHAR(256) NULL,
    Email NVARCHAR(256) NULL,
    NormalizedEmail NVARCHAR(256) NULL,
    EmailConfirmed BIT NOT NULL,
    PasswordHash NVARCHAR(MAX) NULL,
    SecurityStamp NVARCHAR(MAX) NULL,
    ConcurrencyStamp NVARCHAR(MAX) NULL,
    PhoneNumber NVARCHAR(MAX) NULL,
    PhoneNumberConfirmed BIT NOT NULL,
    TwoFactorEnabled BIT NOT NULL,
    LockoutEnd DATETIMEOFFSET NULL,
    LockoutEnabled BIT NOT NULL,
    AccessFailedCount INT NOT NULL,
	StaffId int not null default(90000),
    CONSTRAINT PK_AspNetUsers PRIMARY KEY (Id)
);
GO

CREATE TABLE AspNetRoleClaims (
    Id INT IDENTITY(1,1) NOT NULL,
    RoleId NVARCHAR(450) NOT NULL,
    ClaimType NVARCHAR(MAX) NULL,
    ClaimValue NVARCHAR(MAX) NULL,
    CONSTRAINT PK_AspNetRoleClaims PRIMARY KEY (Id),
    CONSTRAINT FK_AspNetRoleClaims_AspNetRoles_RoleId FOREIGN KEY (RoleId)
    REFERENCES AspNetRoles (Id) ON DELETE CASCADE
);
GO

CREATE TABLE AspNetUserClaims (
    Id INT IDENTITY(1,1) NOT NULL,
    UserId NVARCHAR(450) NOT NULL,
    ClaimType NVARCHAR(MAX) NULL,
    ClaimValue NVARCHAR(MAX) NULL,
    CONSTRAINT PK_AspNetUserClaims PRIMARY KEY (Id),
    CONSTRAINT FK_AspNetUserClaims_AspNetUsers_UserId FOREIGN KEY (UserId)
    REFERENCES AspNetUsers (Id) ON DELETE CASCADE
);
GO

CREATE TABLE AspNetUserLogins (
    LoginProvider NVARCHAR(450) NOT NULL,
    ProviderKey NVARCHAR(450) NOT NULL,
    ProviderDisplayName NVARCHAR(MAX) NULL,
    UserId NVARCHAR(450) NOT NULL,
    CONSTRAINT PK_AspNetUserLogins PRIMARY KEY (LoginProvider, ProviderKey),
    CONSTRAINT FK_AspNetUserLogins_AspNetUsers_UserId FOREIGN KEY (UserId)
    REFERENCES AspNetUsers (Id) ON DELETE CASCADE
);
GO

CREATE TABLE AspNetUserRoles (
    UserId NVARCHAR(450) NOT NULL,
    RoleId NVARCHAR(450) NOT NULL,
    CONSTRAINT PK_AspNetUserRoles PRIMARY KEY (UserId, RoleId),
    CONSTRAINT FK_AspNetUserRoles_AspNetRoles_RoleId FOREIGN KEY (RoleId)
    REFERENCES AspNetRoles (Id) ON DELETE CASCADE,
    CONSTRAINT FK_AspNetUserRoles_AspNetUsers_UserId FOREIGN KEY (UserId)
    REFERENCES AspNetUsers (Id) ON DELETE CASCADE
);
GO

CREATE TABLE AspNetUserTokens (
    UserId NVARCHAR(450) NOT NULL,
    LoginProvider NVARCHAR(450) NOT NULL,
    Name NVARCHAR(450) NOT NULL,
    Value NVARCHAR(MAX) NULL,
    CONSTRAINT PK_AspNetUserTokens PRIMARY KEY (UserId, LoginProvider, Name),
    CONSTRAINT FK_AspNetUserTokens_AspNetUsers_UserId FOREIGN KEY (UserId)
    REFERENCES AspNetUsers (Id) ON DELETE CASCADE
);
GO

-- Indexes for AspNetRoleClaims
CREATE INDEX IX_AspNetRoleClaims_RoleId ON AspNetRoleClaims (RoleId);
GO

-- Indexes for AspNetRoles
CREATE UNIQUE INDEX RoleNameIndex ON AspNetRoles (NormalizedName)
WHERE NormalizedName IS NOT NULL;
GO

-- Indexes for AspNetUserClaims
CREATE INDEX IX_AspNetUserClaims_UserId ON AspNetUserClaims (UserId);
GO

-- Indexes for AspNetUserLogins
CREATE INDEX IX_AspNetUserLogins_UserId ON AspNetUserLogins (UserId);
GO

-- Indexes for AspNetUserRoles
CREATE INDEX IX_AspNetUserRoles_RoleId ON AspNetUserRoles (RoleId);
GO

-- Indexes for AspNetUsers
CREATE INDEX EmailIndex ON AspNetUsers (NormalizedEmail);
GO

CREATE UNIQUE INDEX UserNameIndex ON AspNetUsers (NormalizedUserName)
WHERE NormalizedUserName IS NOT NULL;
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
	[CreatedBy] [int] NOT NULL,
	[CreatedDateTimeUtc] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedBy] [int] NULL,
	[UpdatedDateTimeUtc] [datetime] NULL,
	[DeletedDateTimeUtc] [datetime] NULL,
	[DeletedBy] [INT] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT(0),
	[UserName] nvarchar(256) NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

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
	[CreatedBy] [int] NOT NULL,
	[CreatedDateTimeUtc] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedBy] [int] NULL,
	[UpdatedDateTimeUtc] [datetime] NULL,
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

ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_CreatedBy_Staff_StaffId] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_CreatedBy_Staff_StaffId]
GO

ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_UpdatedBy_Staff_StaffId] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_UpdatedBy_Staff_StaffId]
GO

ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_DeletedBy_Staff_StaffId] FOREIGN KEY([DeletedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_DeletedBy_Staff_StaffId]
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
	[DisplayImagePath] [nvarchar](255) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDateTimeUtc] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedBy] [int] NULL,
	[UpdatedDateTimeUtc] [datetime] NULL,
	[DeletedDateTimeUtc] [datetime] NULL,
	[DeletedBy] [INT] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT(0),
 CONSTRAINT [PK_AccountSupplier] PRIMARY KEY CLUSTERED 
(
	[AccountSupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AccountSupplier] ADD  CONSTRAINT [DF_AccountSupplier_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[AccountSupplier]  WITH CHECK ADD  CONSTRAINT [FK_AccountSupplier_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO

ALTER TABLE [dbo].[AccountSupplier] CHECK CONSTRAINT [FK_AccountSupplier_Accounts]
GO

ALTER TABLE [dbo].[AccountSupplier]  WITH CHECK ADD  CONSTRAINT [FK_AccountSupplier_CreatedBy_Staff_StaffId] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[AccountSupplier] CHECK CONSTRAINT [FK_AccountSupplier_CreatedBy_Staff_StaffId]
GO

ALTER TABLE [dbo].[AccountSupplier]  WITH CHECK ADD  CONSTRAINT [FK_AccountSupplier_UpdatedBy_Staff_StaffId] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[AccountSupplier] CHECK CONSTRAINT [FK_AccountSupplier_UpdatedBy_Staff_StaffId]
GO

ALTER TABLE [dbo].[AccountSupplier]  WITH CHECK ADD  CONSTRAINT [FK_AccountSupplier_DeletedBy_Staff_StaffId] FOREIGN KEY([DeletedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[AccountSupplier] CHECK CONSTRAINT [FK_AccountSupplier_DeletedBy_Staff_StaffId]
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
	[IsActive] [bit] NOT NULL,
	[DisplayImagePath] [nvarchar](255) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDateTimeUtc] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedBy] [int] NULL,
	[UpdatedDateTimeUtc] [datetime] NULL,
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

ALTER TABLE [dbo].[AccountProductCategory] ADD  CONSTRAINT [DF_AccountProductCategory_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[AccountProductCategory] ADD  DEFAULT ((1)) FOR [IsPosCategory]
GO

ALTER TABLE [dbo].[AccountProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_AccountProductCategory_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO

ALTER TABLE [dbo].[AccountProductCategory] CHECK CONSTRAINT [FK_AccountProductCategory_Accounts]
GO

ALTER TABLE [dbo].[AccountProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_AccountProductCategory_CreatedBy_Staff_StaffId] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[AccountProductCategory] CHECK CONSTRAINT [FK_AccountProductCategory_CreatedBy_Staff_StaffId]
GO

ALTER TABLE [dbo].[AccountProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_AccountProductCategory_UpdatedBy_Staff_StaffId] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[AccountProductCategory] CHECK CONSTRAINT [FK_AccountProductCategory_UpdatedBy_Staff_StaffId]
GO

ALTER TABLE [dbo].[AccountProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_AccountProductCategory_DeletedBy_Staff_StaffId] FOREIGN KEY([DeletedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[AccountProductCategory] CHECK CONSTRAINT [FK_AccountProductCategory_DeletedBy_Staff_StaffId]
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
	[CreatedBy] [int] NOT NULL,
	[CreatedDateTimeUtc] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedBy] [int] NULL,
	[UpdatedDateTimeUtc] [datetime] NULL,
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


ALTER TABLE [dbo].[AccountProductSubCategory]  WITH CHECK ADD  CONSTRAINT [FK_AccountProductSubCategory_CreatedBy_Staff_StaffId] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[AccountProductSubCategory] CHECK CONSTRAINT [FK_AccountProductSubCategory_CreatedBy_Staff_StaffId]
GO

ALTER TABLE [dbo].[AccountProductSubCategory]  WITH CHECK ADD  CONSTRAINT [FK_AccountProductSubCategory_UpdatedBy_Staff_StaffId] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[AccountProductSubCategory] CHECK CONSTRAINT [FK_AccountProductSubCategory_UpdatedBy_Staff_StaffId]
GO

ALTER TABLE [dbo].[AccountProductSubCategory]  WITH CHECK ADD  CONSTRAINT [FK_AccountProductSubCategory_DeletedBy_Staff_StaffId] FOREIGN KEY([DeletedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[AccountProductSubCategory] CHECK CONSTRAINT [FK_AccountProductSubCategory_DeletedBy_Staff_StaffId]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Product sub-category internal identifier (primary key)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProductSubCategory', @level2type=N'COLUMN',@level2name=N'AccountProductSubCategoryId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Product category to which the sub-category belongs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AccountProductSubCategory', @level2type=N'COLUMN',@level2name=N'AccountProductCategoryId'
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
	[ExpiryDate] [datetime] NULL,
	[AccountId] [int] NOT NULL,
	[ChargeType] [varchar](50) NULL,
	[DiscountFor] [smallint] NOT NULL,
	[IsCombineFees] [bit] NOT NULL,
	[AllocatedValueJson] [varchar](max) NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDateTimeUtc] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedBy] [int] NULL,
	[UpdatedDateTimeUtc] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT(0),
	[DeletedDateTimeUtc] [datetime] NULL,
	[DeletedBy] int NULL,
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

ALTER TABLE [dbo].[DiscountCoupons]  WITH CHECK ADD  CONSTRAINT [FK_DiscountCoupon_DeletedBy_Staff_StaffId] FOREIGN KEY([DeletedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[DiscountCoupons] CHECK CONSTRAINT [FK_DiscountCoupon_DeletedBy_Staff_StaffId]
GO

ALTER TABLE [dbo].[DiscountCoupons]
ADD CONSTRAINT [UQ_DiscountCoupons_CouponCode] UNIQUE ([CouponCode]);
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
	[GstRequired] [bit] NOT NULL,
	[ExpiryDate] [date] NULL,
	[IsCommissionable] [bit] NOT NULL,
	[CommissionAmount] [decimal](19, 6) NULL,
	[DiscountCouponId] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDateTimeUtc] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedBy] [int] NULL,
	[UpdatedDateTimeUtc] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT(0),
	[DeletedDateTimeUtc] [datetime] NULL,
	[DeletedBy] int NULL,
 CONSTRAINT [PK_AccountProduct] PRIMARY KEY CLUSTERED 
(
	[AccountProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




--END OF TABLE
--NEXT MUST BE FOREIGN KEY AND CONTRAINTS
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

ALTER TABLE [dbo].[AccountProduct]  WITH CHECK ADD  CONSTRAINT [FK_AccountProduct_Staff_StaffId] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[AccountProduct] CHECK CONSTRAINT [FK_AccountProduct_Staff_StaffId]
GO

ALTER TABLE [dbo].[AccountProduct]  WITH CHECK ADD  CONSTRAINT [FK_AccountProduct_UpdatedBy_Staff_StaffId] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[AccountProduct]  WITH CHECK ADD  CONSTRAINT [FK_AccountProduct_DeletedBy_Staff_StaffId] FOREIGN KEY([DeletedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[AccountProduct] CHECK CONSTRAINT [FK_AccountProduct_DeletedBy_Staff_StaffId]
GO


ALTER TABLE [dbo].[AccountProduct] CHECK CONSTRAINT [FK_AccountProduct_UpdatedBy_Staff_StaffId]
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



--PosTransaction
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PosTransaction](
	[PosTransactionId] [bigint] IDENTITY(1,1) NOT NULL,
	[PosTransactionUtcDateTime] [datetime] NOT NULL,
	[PosTransactionLocalDateTime] [datetime] NOT NULL,
	[MemberNumber] [varchar](20) NULL,
	[PosTransactionTotalIncTax] [decimal](18, 2) NOT NULL,
	[PosTransactionTotalExTax] [decimal](18, 2) NOT NULL,
	[PosTransactionTotalTax] [decimal](18, 2) NOT NULL,
	[PosTotalDiscount] [decimal](18, 2) NOT NULL DEFAULT(0),
	[PrintFlag] [int] NULL,
	[Till] [nvarchar](max) NULL,
	[PosTransactionRefId] [bigint] NULL,
	[TransactionType] [nvarchar](50) NULL,
	[RefundType] [varchar](10) NULL,
	[OutstandingBalance] [decimal](18, 2) NOT NULL,
	[AccountId] [int] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDateTimeUtc] [datetime] NOT NULL DEFAULT (getutcdate()),
	[UpdatedBy] [int] NULL,
	[UpdatedDateTimeUtc] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT(0),
	[DeletedDateTimeUtc] [datetime] NULL,
	[DeletedBy] int NULL,
 CONSTRAINT [PK_PosTransaction] PRIMARY KEY CLUSTERED 
(
	[PosTransactionId] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[PosTransaction] ADD  CONSTRAINT [DF__PosTransa__Trans__1B7E091A]  DEFAULT ('Sale') FOR [TransactionType]
GO

ALTER TABLE [dbo].[PosTransaction] ADD  CONSTRAINT [DF__PosTransa__Outst__0F6D37F0]  DEFAULT ((0)) FOR [OutstandingBalance]
GO

ALTER TABLE [dbo].[PosTransaction]  WITH CHECK ADD  CONSTRAINT [FK_PosTransaction_Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO

ALTER TABLE [dbo].[PosTransaction] CHECK CONSTRAINT [FK_PosTransaction_Accounts_AccountId]
GO

ALTER TABLE [dbo].[PosTransaction]  WITH CHECK ADD  CONSTRAINT [FK_PosTransaction_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[PosTransaction] CHECK CONSTRAINT [FK_PosTransaction_CreatedBy]
GO

ALTER TABLE [dbo].[PosTransaction]  WITH CHECK ADD  CONSTRAINT [FK_PosTransaction_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[PosTransaction] CHECK CONSTRAINT [FK_PosTransaction_UpdatedBy]
GO

ALTER TABLE [dbo].[PosTransaction]  WITH CHECK ADD  CONSTRAINT [FK_PosTransaction_DeletedBy] FOREIGN KEY([DeletedBy])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[PosTransaction] CHECK CONSTRAINT [FK_PosTransaction_DeletedBy]
GO

--ALTER TABLE [dbo].[PosTransaction]  WITH CHECK ADD  CONSTRAINT [FK_PosTransaction_Members] FOREIGN KEY([MemberNumber])
--REFERENCES [dbo].[Members] ([member_number])
--GO

--ALTER TABLE [dbo].[PosTransaction] CHECK CONSTRAINT [FK_PosTransaction_Members]
--GO

--PosTransactionItem
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PosTransactionItem](
	[PosTransactionItemId] [bigint] IDENTITY(1,1) NOT NULL,
	[PosTransactionId] [bigint] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ItemQuantity] [int] NOT NULL,
	[ItemTaxAmount] [decimal](18, 2) NOT NULL,
	[ItemPriceExTax] [decimal](18, 2) NOT NULL,
	[ItemPriceIncTax] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[IsRefunded] [bit] NOT NULL,
	[PosTransactionRefItemId] [bigint] NULL,
	[IsVoided] [bit] NOT NULL,
	[DiscountPercentage] [decimal](18, 2) NOT NULL DEFAULT(0),
	[DiscountByLookupItemId] INT NULL,
	[CouponCode] [nvarchar](100) NULL
 CONSTRAINT [PK_PosTransactionItem] PRIMARY KEY CLUSTERED 
(
	[PosTransactionItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PosTransactionItem] ADD  DEFAULT ((0)) FOR [Discount]
GO

ALTER TABLE [dbo].[PosTransactionItem] ADD  DEFAULT ((0)) FOR [IsRefunded]
GO

ALTER TABLE [dbo].[PosTransactionItem] ADD  DEFAULT ((0)) FOR [IsVoided]
GO

ALTER TABLE [dbo].[PosTransactionItem]  WITH CHECK ADD  CONSTRAINT [FK_PosTransactionItem_AccountProduct] FOREIGN KEY([ProductId])
REFERENCES [dbo].[AccountProduct] ([AccountProductId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[PosTransactionItem] CHECK CONSTRAINT [FK_PosTransactionItem_AccountProduct]
GO

ALTER TABLE [dbo].[PosTransactionItem]  WITH CHECK ADD  CONSTRAINT [FK_PosTransactionItem_PosTransaction] FOREIGN KEY([PosTransactionId])
REFERENCES [dbo].[PosTransaction] ([PosTransactionId])
GO

ALTER TABLE [dbo].[PosTransactionItem] CHECK CONSTRAINT [FK_PosTransactionItem_PosTransaction]
GO




--PosTransactionPayment
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PosTransactionPayment](
	[PosTransactionPaymentId] [bigint] IDENTITY(1,1) NOT NULL,
	[PosTransactionId] [bigint] NOT NULL,
	[PaymentTypeId] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[CCNumber] [varchar](25) NULL,
	[TransactionDateUtc] [datetime] NULL,
 CONSTRAINT [PK_PosTransactionPayment] PRIMARY KEY CLUSTERED 
(
	[PosTransactionPaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PosTransactionPayment]  WITH CHECK ADD  CONSTRAINT [FK_PosTransactionPayment_PosTransaction] FOREIGN KEY([PosTransactionId])
REFERENCES [dbo].[PosTransaction] ([PosTransactionId])
GO

ALTER TABLE [dbo].[PosTransactionPayment] CHECK CONSTRAINT [FK_PosTransactionPayment_PosTransaction]
GO


--PosTransactionAudit
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PosTransactionAudit](
	[PosTransactionAuditId] [bigint] IDENTITY(1,1) NOT NULL,
	[PosTransactionId] [bigint] NOT NULL,
	[PosTransactionUtcDateTime] [datetime] NOT NULL,
	[PosTransactionLocalDateTime] [datetime] NOT NULL,
	[MemberNumber] [varchar](20) NULL,
	[PosTransactionTotalIncTax] [decimal](18, 2) NOT NULL,
	[PosTransactionTotalExTax] [decimal](18, 2) NOT NULL,
	[PosTransactionTotalTax] [decimal](18, 2) NOT NULL,
	[StaffMemberId] [int] NOT NULL,
	[PrintFlag] [int] NULL,
	[ProductId] [int] NOT NULL,
	[ItemQuantity] [int] NOT NULL,
	[ItemTaxAmount] [decimal](18, 2) NOT NULL,
	[ItemPriceExTax] [decimal](18, 2) NOT NULL,
	[ItemPriceIncTax] [decimal](18, 2) NOT NULL,
	[PaymentType] [varchar](100) NULL,
	[CCNumber] [varchar](25) NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[ReasonForDiscount] [nvarchar](1000) NULL,
	[ItemType] [int] NOT NULL,
	[PosTransactionItemId] [bigint] NOT NULL,
	[AuditPosType] [int] NOT NULL,
	[SalesPersonStaffId] [int] NULL,
 CONSTRAINT [PK_PosTransactionAudit] PRIMARY KEY CLUSTERED 
(
	[PosTransactionAuditId] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PosTransactionAudit] ADD  DEFAULT ((0)) FOR [Discount]
GO

ALTER TABLE [dbo].[PosTransactionAudit] ADD  CONSTRAINT [DF_PosTransactionAudit_ItemType]  DEFAULT ((0)) FOR [ItemType]
GO

ALTER TABLE [dbo].[PosTransactionAudit] ADD  DEFAULT ((0)) FOR [PosTransactionItemId]
GO

ALTER TABLE [dbo].[PosTransactionAudit] ADD  DEFAULT ((0)) FOR [AuditPosType]
GO

--ALTER TABLE [dbo].[PosTransactionAudit]  WITH CHECK ADD  CONSTRAINT [FK_PosTransactionAudit_Members] FOREIGN KEY([MemberNumber])
--REFERENCES [dbo].[Members] ([member_number])
--GO

--ALTER TABLE [dbo].[PosTransactionAudit] CHECK CONSTRAINT [FK_PosTransactionAudit_Members]
--GO

ALTER TABLE [dbo].[PosTransactionAudit]  WITH CHECK ADD  CONSTRAINT [FK_PosTransactionAudit_POSTransactionId] FOREIGN KEY([PosTransactionId])
REFERENCES [dbo].[PosTransaction] ([PosTransactionId])
GO

ALTER TABLE [dbo].[PosTransactionAudit] CHECK CONSTRAINT [FK_PosTransactionAudit_POSTransactionId]
GO

ALTER TABLE [dbo].[PosTransactionAudit]  WITH CHECK ADD  CONSTRAINT [FK_PosTransactionAudit_Staff] FOREIGN KEY([StaffMemberId])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[PosTransactionAudit] CHECK CONSTRAINT [FK_PosTransactionAudit_Staff]
GO

ALTER TABLE [dbo].[PosTransactionAudit]  WITH CHECK ADD  CONSTRAINT [FK_SalesPersonStaff_PosTransactionAudits_SalesPersonStaffId] FOREIGN KEY([SalesPersonStaffId])
REFERENCES [dbo].[Staff] ([StaffId])
GO

ALTER TABLE [dbo].[PosTransactionAudit] CHECK CONSTRAINT [FK_SalesPersonStaff_PosTransactionAudits_SalesPersonStaffId]
GO


--PosTransactionGenericItem
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PosTransactionGenericItem](
	[PosTransactionId] [bigint] NOT NULL,
	[ItemDescription] [nvarchar](500) NOT NULL,
	[ItemAmount] [decimal](18, 2) NOT NULL,
	[ItemQuantity] [int] NOT NULL,
	[MembershipTypeId] [int] NULL,
	[PosTransactionGenericItemId] [int] IDENTITY(1,1) NOT NULL,
	[MemberNumber] [varchar](20) NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[DiscountType] [smallint] NOT NULL,
 CONSTRAINT [PK_PosTransactionGenericItem] PRIMARY KEY CLUSTERED 
(
	[PosTransactionGenericItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PosTransactionGenericItem] ADD  DEFAULT ((0)) FOR [Discount]
GO

ALTER TABLE [dbo].[PosTransactionGenericItem] ADD  DEFAULT ((2)) FOR [DiscountType]
GO

--ALTER TABLE [dbo].[PosTransactionGenericItem]  WITH CHECK ADD  CONSTRAINT [FK_PosTransactionGenericItem_MembershipTypes] FOREIGN KEY([MembershipTypeId])
--REFERENCES [dbo].[MembershipTypes] ([contract_id])
--GO

--ALTER TABLE [dbo].[PosTransactionGenericItem] CHECK CONSTRAINT [FK_PosTransactionGenericItem_MembershipTypes]
--GO

ALTER TABLE [dbo].[PosTransactionGenericItem]  WITH CHECK ADD  CONSTRAINT [FK_PosTransactionGenericItem_PosTransaction] FOREIGN KEY([PosTransactionId])
REFERENCES [dbo].[PosTransaction] ([PosTransactionId])
GO

ALTER TABLE [dbo].[PosTransactionGenericItem] CHECK CONSTRAINT [FK_PosTransactionGenericItem_PosTransaction]
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LookupTypes](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_Lookup_Types] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LookupTypeItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NULL,
	[Description] [nvarchar](100) NULL,
	[IsActive] [bit] NOT NULL DEFAULT ((1)),
	[IsSystem] [bit] NOT NULL DEFAULT ((0)),
	[IsShowOnline] [bit] NOT NULL DEFAULT ((1)),
 CONSTRAINT [PK_Lookup_Type_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LookupTypeItems]  WITH CHECK ADD  CONSTRAINT [FK_LookupTypeItems_TypeId_LookupTypes_TypeId] FOREIGN KEY([TypeId])
REFERENCES [dbo].[LookupTypes] ([TypeId])
GO

ALTER TABLE [dbo].[LookupTypeItems] CHECK CONSTRAINT [FK_LookupTypeItems_TypeId_LookupTypes_TypeId]
GO


ALTER TABLE [dbo].[PosTransactionItem]  WITH CHECK ADD  CONSTRAINT [FK_PosTransactionItem_DiscountByLookupItemId_AccountProduct_LookupTypeItem_Id] FOREIGN KEY([DiscountByLookupItemId])
REFERENCES [dbo].[LookupTypeItems] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[PosTransactionItem] CHECK CONSTRAINT [FK_PosTransactionItem_DiscountByLookupItemId_AccountProduct_LookupTypeItem_Id]
GO

ALTER TABLE [dbo].[PosTransactionItem]  WITH CHECK ADD  CONSTRAINT [FK_PosTransactionItem_CouponCode_AccountProduct_DiscountCoupon_CouponCode] FOREIGN KEY([CouponCode])
REFERENCES [dbo].[DiscountCoupons] ([CouponCode])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[PosTransactionItem] CHECK CONSTRAINT [FK_PosTransactionItem_CouponCode_AccountProduct_DiscountCoupon_CouponCode]
GO