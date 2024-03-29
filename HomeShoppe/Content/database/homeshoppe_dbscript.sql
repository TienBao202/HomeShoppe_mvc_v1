
CREATE TABLE [dbo].[About](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Image] [nvarchar](250) NULL,
	[Detail] [ntext] NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_About_CreatedDate]  DEFAULT (getdate()),
	[Status] [bit] NULL CONSTRAINT [DF_About_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[ParentID] [int] NULL,
	[DisplayOrder] [int] NULL CONSTRAINT [DF_Category_DisplayOrder]  DEFAULT ((0)),
	[SeoTitle] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_Category_CreatedDate]  DEFAULT (getdate()),
	[Status] [bit] NULL CONSTRAINT [DF_Category_Status]  DEFAULT ((1)),
	[ShowOnHome] [bit] NULL CONSTRAINT [DF_Category_ShowOnHome]  DEFAULT ((0)),
	[Language] [varchar](2) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ID] [nvarchar](50) NOT NULL,
	[Content] [ntext] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Content]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Content](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Image] [nvarchar](250) NULL,
	[CategoryID] [int] NULL,
	[Detail] [ntext] NULL,
	[Warranty] [int] NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_Content_CreatedDate]  DEFAULT (getdate()),
	[Status] [bit] NOT NULL CONSTRAINT [DF_Content_Status]  DEFAULT ((1)),
	[TopHot] [datetime] NULL,
	[ViewCount] [int] NULL CONSTRAINT [DF_Content_ViewCount]  DEFAULT ((0)),
	[Tags] [nvarchar](500) NULL,
	[Language] [varchar](2) NULL,
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Credential]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Credential](
	[UserGroupID] [varchar](20) NOT NULL,
	[RoleID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Credential] PRIMARY KEY CLUSTERED 
(
	[UserGroupID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Content] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Footer]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Footer](
	[ID] [varchar](50) NOT NULL,
	[Content] [ntext] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Footer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Language]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Language](
	[ID] [varchar](2) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsDefault] [bit] NOT NULL CONSTRAINT [DF_Language_IsDefault]  DEFAULT ((0)),
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[Link] [nvarchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[Target] [nvarchar](50) NULL,
	[Status] [bit] NULL,
	[TypeID] [int] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MenuType]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_MenuType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CustomerID] [int] NULL,
	[ShipName] [nvarchar](50) NULL,
	[ShipMobile] [varchar](50) NULL,
	[ShipAddress] [nvarchar](50) NULL,
	[ShipEmail] [nvarchar](50) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ProductID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Quantity] [int] NULL CONSTRAINT [DF_OrderDetail_Quantity]  DEFAULT ((1)),
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Code] [varchar](10) NULL,
	[MetaTitle] [varchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Image] [nvarchar](250) NULL,
	[MoreImages] [xml] NULL,
	[Price] [decimal](18, 0) NULL CONSTRAINT [DF_Product_Price]  DEFAULT ((0)),
	[PromotionPrice] [decimal](18, 0) NULL,
	[Quantity] [int] NOT NULL CONSTRAINT [DF_Product_Quantity]  DEFAULT ((0)),
	[CategoryID] [int] NULL,
	[Detail] [ntext] NULL,
	[Warranty] [int] NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_Product_CreatedDate]  DEFAULT (getdate()),
	[Status] [bit] NULL CONSTRAINT [DF_Product_Status]  DEFAULT ((1)),
	[TopHot] [datetime] NULL,
	[ViewCount] [int] NULL CONSTRAINT [DF_Product_ViewCount]  DEFAULT ((0)),
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[ParentID] [int] NULL,
	[DisplayOrder] [int] NULL CONSTRAINT [DF_ProductCategory_DisplayOrder]  DEFAULT ((0)),
	[Status] [bit] NULL CONSTRAINT [DF_ProductCategory_Status]  DEFAULT ((1)),
	[ShowOnHome] [bit] NULL CONSTRAINT [DF_ProductCategory_ShowOnHome]  DEFAULT ((0)),
	[image] [nvarchar](100) NULL,
	[icon] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Slide](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Image] [nvarchar](250) NULL,
	[MoreImages] [xml] NULL,
	[DisplayOrder] [int] NULL CONSTRAINT [DF_Slide_DisplayOrder]  DEFAULT ((1)),
	[Link] [nvarchar](250) NULL,
	[Description] [text] NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_Slide_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [varchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Slide] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SystemConfig]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SystemConfig](
	[ID] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Type] [varchar](50) NULL,
	[Value] [nvarchar](250) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_SystemConfig] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](32) NULL,
	[GroupID] [varchar](20) NULL CONSTRAINT [DF_User_GroupID]  DEFAULT ('MEMBER'),
	[Name] [nvarchar](50) NULL,
	[Birthday] [date] NULL,
	[Gender] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()),
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 11/4/2019 4:00:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserGroup](
	[ID] [varchar](20) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[About] ON 

INSERT [dbo].[About] ([ID], [Name], [MetaTitle], [Description], [Image], [Detail], [CreatedDate], [Status]) VALUES (1, N'Trang giới thiệu kiểu 1', N'trang-gioi-thieu-kieu-1', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[About] ([ID], [Name], [MetaTitle], [Description], [Image], [Detail], [CreatedDate], [Status]) VALUES (3, N'Trang giới thiệu kiểu 2', N'trang-gioi-thieu-kieu-2', NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[About] ([ID], [Name], [MetaTitle], [Description], [Image], [Detail], [CreatedDate], [Status]) VALUES (4, N'Trang giới thiệu kiểu 3', N'trang-gioi-thieu-kieu-3', NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[About] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [Status], [ShowOnHome], [Language]) VALUES (1, N'Tin thế giới', N'tin-the-gioi', NULL, 1, NULL, CAST(N'2015-08-15 07:49:20.183' AS DateTime), 1, 0, NULL)
INSERT [dbo].[Category] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [Status], [ShowOnHome], [Language]) VALUES (2, N'Tin trong nước', N'tin-trong-nuoc', NULL, 2, NULL, CAST(N'2015-08-15 07:49:33.087' AS DateTime), 1, 0, NULL)
INSERT [dbo].[Category] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [Status], [ShowOnHome], [Language]) VALUES (3, N'34234', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'vi')
SET IDENTITY_INSERT [dbo].[Category] OFF
INSERT [dbo].[Contact] ([ID], [Content], [Status]) VALUES (N'1', N'<p>C&ocirc;ng ty CP Online Shop</p>

<p>Địa chỉ: Số 1 Quang Trung H&agrave; Đ&ocirc;ng</p>

<p>Điện thoại: 04 6523 5342</p>
', 1)
INSERT [dbo].[Contact] ([ID], [Content], [Status]) VALUES (N'LienHe2', NULL, 0)
INSERT [dbo].[Contact] ([ID], [Content], [Status]) VALUES (N'Trang liên hệ số 3', NULL, 0)
SET IDENTITY_INSERT [dbo].[Content] ON 

INSERT [dbo].[Content] ([ID], [Name], [MetaTitle], [Description], [Image], [CategoryID], [Detail], [Warranty], [CreatedDate], [Status], [TopHot], [ViewCount], [Tags], [Language]) VALUES (1, N'tin tức demo', N'tin-tuc-demo', N'424', N'/Data/images/14.PNG', 1, N'42342342', 12, CAST(N'2015-09-20 08:01:57.590' AS DateTime), 1, NULL, 0, N'tin tức,thời sự', NULL)
SET IDENTITY_INSERT [dbo].[Content] OFF
INSERT [dbo].[Footer] ([ID], [Content], [Status]) VALUES (N'Footer-kieu-1', N'<!-- container -->
<div class="container"><!-- row -->
<div class="row"><!-- footer widget -->
<div class="col-md-3 col-sm-6 col-xs-6">
<div class="footer"><!-- footer logo -->
<div class="footer-logo"><a class="logo" href="#"><img alt="" src="/img/images/Logo/logo.png" style="height:48px; width:200px" /></a></div>
<!-- /footer logo -->

<p>Hệ thống b&aacute;n h&agrave;ng trực tuyến HomeShoppe.</p>
<!-- footer social -->

<ul>
	<li>&nbsp;</li>
	<li>&nbsp;</li>
	<li>&nbsp;</li>
	<li>&nbsp;</li>
	<li>&nbsp;</li>
</ul>
<!-- /footer social --></div>
</div>
<!-- /footer widget --><!-- footer widget -->

<div class="col-md-3 col-sm-6 col-xs-6">
<div class="footer">
<h3>DỊCH VỤ&nbsp;</h3>

<ul>
	<li><a href="#">Ch&iacute;nh s&aacute;ch bảo h&agrave;nh</a></li>
	<li><a href="#">Ch&iacute;nh s&aacute;ch đổi trả</a></li>
	<li><a href="#">Hỏi Đ&aacute;p Mua H&agrave;ng Online</a></li>
	<li><a href="#">Phương Thức Thanh To&aacute;n</a></li>
</ul>
</div>
</div>
<!-- /footer widget -->

<div class="clearfix visible-sm visible-xs">&nbsp;</div>
<!-- footer widget -->

<div class="col-md-3 col-sm-6 col-xs-6">
<div class="footer">
<h3>GIỚI THIỆU&nbsp;</h3>

<ul>
	<li><a href="#">Giới thiệu c&ocirc;ng ty</a></li>
	<li><a href="#">Hệ thống cửa h&agrave;ng</a></li>
	<li><a href="#">Tuyển dụng</a></li>
	<li><a href="#">FAQ</a></li>
</ul>
</div>
</div>
<!-- /footer widget --><!-- footer subscribe -->

<div class="col-md-3 col-sm-6 col-xs-6">
<div class="footer">
<h3>LI&Ecirc;N HỆ</h3>

<ul>
	<li><a href="#">Gọi mua h&agrave;ng: 1800.1530 (7h30 - 22h)</a></li>
	<li><a href="#">Gọi khiếu nại: 1800.1530 (7h30 - 22h)</a></li>
	<li><a href="#">Gọi bảo h&agrave;nh: 1800.1530 (7h30 - 22h)</a></li>
	<li><a href="#">Hỗ trợ kỹ thuật: 1800.1530 (7h30 - 22h)</a></li>
</ul>
</div>
</div>
<!-- /footer subscribe --></div>
<!-- /row -->

<hr /><!-- row -->
<div class="row">
<div class="col-md-8 col-md-offset-2 text-center"><!-- footer copyright -->
<div class="footer-copyright"><!-- Link back to Colorlib can''t be removed. Template is licensed under CC BY 3.0. -->&copy; 2018&nbsp;- C&ocirc;ng ty Cổ Phần viễn th&ocirc;ng HomeShoppe&nbsp;- Th&agrave;nh phố H&agrave; Nội, Việt Nam <!-- Link back to Colorlib can''t be removed. Template is licensed under CC BY 3.0. --></div>
<!-- /footer copyright --></div>
</div>
<!-- /row --></div>
<!-- /container -->', 1)
INSERT [dbo].[Footer] ([ID], [Content], [Status]) VALUES (N'footer1', N'<div class="wrap">
<div class="group section">
<div class="col_1_of_4 span_1_of_4">
<h4>Information</h4>

<ul>
	<li><a href="about.html">About Us</a></li>
	<li><a href="contact.html">Customer Service</a></li>
	<li><a href="#">Advanced Search</a></li>
	<li><a href="delivery.html">Orders and Returns</a></li>
	<li><a href="contact.html">Contact Us</a></li>
</ul>
</div>

<div class="col_1_of_4 span_1_of_4">
<h4>Why buy from us</h4>

<ul>
	<li><a href="about.html">About Us</a></li>
	<li><a href="contact.html">Customer Service</a></li>
	<li><a href="#">Privacy Policy</a></li>
	<li><a href="contact.html">Site Map</a></li>
	<li><a href="#">Search Terms</a></li>
</ul>
</div>

<div class="col_1_of_4 span_1_of_4">
<h4>My account</h4>

<ul>
	<li><a href="contact.html">Sign In</a></li>
	<li><a href="index.html">View Cart</a></li>
	<li><a href="#">My Wishlist</a></li>
	<li><a href="#">Track My Order</a></li>
	<li><a href="contact.html">Help</a></li>
</ul>
</div>

<div class="col_1_of_4 span_1_of_4">
<h4>Contact</h4>

<ul>
	<li>+91-123-456789</li>
	<li>+00-123-000000</li>
</ul>

<div class="social-icons">
<h4>Follow Us</h4>

<div class="clear">&nbsp;</div>

<ul>
	<li><a href="#" target="_blank"><img alt="" src="images/facebook.png" /></a></li>
	<li><a href="#" target="_blank"><img alt="" src="images/twitter.png" /></a></li>
	<li><a href="#" target="_blank"><img alt="" src="images/skype.png" /> </a></li>
	<li><a href="#" target="_blank"><img alt="" src="images/dribbble.png" /></a></li>
	<li><a href="#" target="_blank"><img alt="" src="images/linkedin.png" /></a></li>
</ul>
</div>
</div>
</div>
</div>

<div class="copy_right">
<p>Company Name &copy; All rights Reseverd | Design by <a href="http://w3layouts.com">W3Layouts</a></p>
</div>
', 0)
INSERT [dbo].[Footer] ([ID], [Content], [Status]) VALUES (N'footer1223', NULL, 0)
INSERT [dbo].[Language] ([ID], [Name], [IsDefault]) VALUES (N'en', N'Tiếng Anh', 0)
INSERT [dbo].[Language] ([ID], [Name], [IsDefault]) VALUES (N'vi', N'Tiếng Việt', 1)
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (1, N'Trang chủ', N'/', 1, N'_blank', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (2, N'Giới thiệu', N'/gioi-thieu', 2, N'_self', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (3, N'Tin tức', N'/tin-tuc', 3, N'_self', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (4, N'Sản phẩm', N'/san-pham', 4, N'_self', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (5, N'Liên hệ', N'/lien-he', 5, N'_self', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (6, N'Đăng nhập', N'/dang-nhap', 1, N'_self', 1, 2)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (7, N'Đăng ký', N'/dang-ky', 2, N'_self', 1, 2)
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[MenuType] ON 

INSERT [dbo].[MenuType] ([ID], [Name]) VALUES (1, N'Menu chính')
INSERT [dbo].[MenuType] ([ID], [Name]) VALUES (2, N'Menu top')
SET IDENTITY_INSERT [dbo].[MenuType] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (20, CAST(N'2019-01-09 22:12:17.543' AS DateTime), NULL, N'Nguyễn Tiến Bảo', N'0329191490', NULL, N'tienbao@gmail.com', NULL)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (21, CAST(N'2019-01-10 02:42:01.670' AS DateTime), NULL, N'Nguyễn Tiến Bảo', N'0329191490', NULL, N'tienbao@gmail.com', NULL)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (22, CAST(N'2019-01-10 10:52:10.197' AS DateTime), NULL, N'Nguyễn Tiến Bảo', N'0329191490', NULL, N'tienbao@gmail.com', NULL)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (23, CAST(N'2019-01-10 10:53:37.570' AS DateTime), NULL, N'Kiều Việt Anh', N'0329191490', NULL, N'kieuvietanh@gmail.com', NULL)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (24, CAST(N'2019-01-10 11:03:10.543' AS DateTime), NULL, N'Kiều Việt Anh', N'0329191490', NULL, N'kieuvietanh@gmail.com', NULL)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (25, CAST(N'2019-01-11 00:14:52.027' AS DateTime), NULL, N'Nguyễn Tiến Bảo', N'0329191490 ', NULL, N'tienbao@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (26, CAST(N'2019-01-12 01:08:52.990' AS DateTime), 20, N'Nguyễn Tiến Bảo', N'0329191490', NULL, N'tienbao202@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (27, CAST(N'2019-01-12 01:56:53.750' AS DateTime), 20, N'Nguyễn Tiến Bảo', N'0329191490', NULL, N'tienbao202@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (28, CAST(N'2019-01-12 02:00:53.410' AS DateTime), 20, N'Nguyễn Tiến Bảo', N'0329191490', NULL, N'tienbao0297@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (29, CAST(N'2019-01-12 02:10:43.213' AS DateTime), 20, N'Nguyễn Tiến Bảo', N'0329191490', NULL, N'tienbao0297@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (30, CAST(N'2019-01-12 02:26:01.217' AS DateTime), 20, N'Nguyễn Tiến Bảo', N'0329191490', NULL, N'tienbao202@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (31, CAST(N'2019-01-12 12:06:30.827' AS DateTime), 20, N'Nguyễn Tiến Bảo', N'0329191490', N'Ha Noi', N'tienbao202@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (32, CAST(N'2019-01-12 12:07:12.967' AS DateTime), 20, N'Nguyễn Tiến Bảo', N'0329191490', N'Ha Noi', N'tienbao202@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (33, CAST(N'2019-11-04 14:24:44.550' AS DateTime), 2, N'Tiến Bảo', N'0329191490', N'Hà Nội', N'tienbao202@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (34, CAST(N'2019-11-04 14:25:58.727' AS DateTime), 2, N'Tiến Bảo', N'0329191490', N'Hà Nội', N'tienbao202@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (35, CAST(N'2019-11-04 14:26:20.417' AS DateTime), 2, N'Tiến Bảo', N'0329191490', N'Hà Nội', N'tienbao202@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (36, CAST(N'2019-11-04 14:28:10.397' AS DateTime), 2, N'Tiến Bảo', N'0329191490', N'Hà Nội', N'tienbao202@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (37, CAST(N'2019-11-04 14:33:57.030' AS DateTime), 2, N'Tiến Bảo', N'0329191490', N'Hà Nội', N'tienbao202@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (38, CAST(N'2019-11-04 14:34:10.827' AS DateTime), 2, N'Tiến Bảo', N'0329191490', N'Hà Nội', N'tienbao202@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (39, CAST(N'2019-11-04 14:46:00.587' AS DateTime), 2, N'Tiến Bảo', N'0329191490', N'Hà Nội', N'tienbao202@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (40, CAST(N'2019-11-04 14:46:15.110' AS DateTime), 2, N'Tiến Bảo', N'0329191490', N'Hà Nội', N'tienbao202@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (41, CAST(N'2019-11-04 14:54:37.140' AS DateTime), 2, N'Tiến Bảo', N'0329191490', N'Hà Nội', N'tienbao0297@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (42, CAST(N'2019-11-04 15:04:52.183' AS DateTime), 2, N'Tiến Bảo', N'0329191490', N'Hà Nội', N'tienbao0297@gmail.com', 1)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (43, CAST(N'2019-11-04 15:09:56.460' AS DateTime), 2, N'Tiến Bảo', N'0329191490', N'Hà Nội', N'tienbao0297@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (2, 25, 1, CAST(31990000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (3, 23, 3, CAST(20000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (3, 27, 1, CAST(20000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (3, 28, 1, CAST(20000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (3, 37, 1, CAST(20000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (3, 38, 1, CAST(20000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 20, 4, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 21, 2, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 22, 3, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 25, 3, CAST(45000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 26, 1, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 27, 1, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 28, 1, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 29, 1, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 30, 1, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 31, 4, CAST(60000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 32, 4, CAST(60000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 33, 2, CAST(30000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 34, 2, CAST(30000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 35, 2, CAST(30000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 36, 2, CAST(30000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 37, 1, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 38, 1, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 39, 1, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 40, 1, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 41, 1, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 42, 1, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (5, 43, 1, CAST(15000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (6, 24, 4, CAST(20000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (6, 25, 4, CAST(80000000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (7, 21, 3, CAST(35990000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (7, 27, 1, CAST(35990000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (7, 31, 1, CAST(35990000 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (7, 32, 1, CAST(35990000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [MoreImages], [Price], [PromotionPrice], [Quantity], [CategoryID], [Detail], [Warranty], [CreatedDate], [Status], [TopHot], [ViewCount]) VALUES (2, N'IPhone X', N'MS002', N'iphone-x', N'<p><img alt="" src="/img/images/Product/iPhone%20X%20256GB/-1-thietke.jpg" style="height:333px; width:600px" /></p>
', N'/img/images/Product/iPhone%20X%20256GB/iphone-x-256gb-270.310.png', NULL, CAST(15000000 AS Decimal(18, 0)), NULL, 100, 5, N'<table border="1" cellpadding="1" cellspacing="1" style="width:500px">
	<tbody>
		<tr>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
	</tbody>
</table>

<p>&nbsp;</p>
', 12, CAST(N'2018-12-03 21:41:25.230' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Product] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [MoreImages], [Price], [PromotionPrice], [Quantity], [CategoryID], [Detail], [Warranty], [CreatedDate], [Status], [TopHot], [ViewCount]) VALUES (3, N'Samsung Galaxy Note 9', N'MS003', N'samsung-galaxy-note-9', NULL, N'/img/images/Product/Samsung%20Note%209%20512GB/samsung-galaxy-note-9-512gb-blue270.310.png', NULL, CAST(28990000 AS Decimal(18, 0)), CAST(20000000 AS Decimal(18, 0)), 150, 6, NULL, 12, CAST(N'2018-12-03 21:51:10.780' AS DateTime), 1, NULL, 120)
INSERT [dbo].[Product] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [MoreImages], [Price], [PromotionPrice], [Quantity], [CategoryID], [Detail], [Warranty], [CreatedDate], [Status], [TopHot], [ViewCount]) VALUES (4, N'Samsung Galaxy Note 8', N'MS004', N'samsung-galaxy-note-8', NULL, N'/img/images/Product/Samsung%20Note%209%20512GB/samsung-galaxy-note-9-512gb-blue270.310.png', NULL, CAST(19990000 AS Decimal(18, 0)), NULL, 100, 6, NULL, 12, CAST(N'2018-12-03 21:52:05.157' AS DateTime), 1, NULL, 0)
INSERT [dbo].[Product] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [MoreImages], [Price], [PromotionPrice], [Quantity], [CategoryID], [Detail], [Warranty], [CreatedDate], [Status], [TopHot], [ViewCount]) VALUES (5, N'Huawei Mate 20 Pro', N'MS005', N'huawei-mate-20-pro', N'<p><img alt="" src="/img/images/Product/Huawei%20Mate%2020%20Pro/-huawei-mate-20-pro-thietke.jpg" style="height:330px; width:594px" /></p>
', N'/img/images/Product/Huawei%20Mate%2020%20Pro/huawei-mate-20-pro-270.310.png', NULL, CAST(19990000 AS Decimal(18, 0)), CAST(15000000 AS Decimal(18, 0)), 50, 7, N'<table align="left" border="1" cellpadding="1" cellspacing="0" style="width:500px">
	<tbody>
		<tr>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
	</tbody>
</table>

<p>&nbsp;</p>
', 12, CAST(N'2018-12-03 21:54:01.887' AS DateTime), 1, NULL, 200)
INSERT [dbo].[Product] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [MoreImages], [Price], [PromotionPrice], [Quantity], [CategoryID], [Detail], [Warranty], [CreatedDate], [Status], [TopHot], [ViewCount]) VALUES (6, N'IPhone XR', N'MS006XR', N'iphone-xr', NULL, N'/img/images/Product/iPhone%20Xr%20128GB/iphone-xr-128gb-270.310.png', NULL, CAST(25000000 AS Decimal(18, 0)), CAST(20000000 AS Decimal(18, 0)), 150, 5, NULL, 12, NULL, 1, NULL, 85)
INSERT [dbo].[Product] ([ID], [Name], [Code], [MetaTitle], [Description], [Image], [MoreImages], [Price], [PromotionPrice], [Quantity], [CategoryID], [Detail], [Warranty], [CreatedDate], [Status], [TopHot], [ViewCount]) VALUES (7, N'IPhone XS Max', N'MS001XS', N'iphone-xs-max', NULL, N'/img/images/Product/iPhone%20Xs%20Max%20256GB/iphone-xs-max-270.310.png', NULL, CAST(39000000 AS Decimal(18, 0)), CAST(35990000 AS Decimal(18, 0)), 0, 5, NULL, 12, NULL, 1, NULL, 250)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (1, N'Điện thoại - Máy tính bảng', N'dien-thoai-may-tinh-bang', NULL, 1, 1, 0, N'/img/images/category/dien-thoai-may-tinh-bang.png', N'fa fa-tablet')
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (2, N'Tivi - Thiết bị nghe nhìn', N'tivi-thiet-bi-nghe-nhin', NULL, 2, 1, 0, N'/img/images/category/tivi-thiet-bi-nghe-nhin.png', N'fa fa-desktop')
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (3, N'Phụ kiện - Thiết bị số', N'phu-kien-thiet-bi-so', NULL, 4, 1, 0, N'/img/images/category/thiet-bi-so-phu-kien-so.png', N'fa fa-headphones')
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (4, N'Laptop - Thiết bị IT', N'lap-top-thiet-bi-it', NULL, 3, 1, 0, N'/img/images/category/Lap-top-may-vi-tinh.png', N'fa fa-laptop')
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (5, N'Apple', N'apple', 1, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (6, N'Samsung', N'samsung', 1, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (7, N'Huawei', N'huawei', 1, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (8, N'Xiaomi', N'xiaomi', 1, NULL, 1, 0, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (18, N'Dell', N'dell', 4, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (19, N'MacBook', N'macbook', 4, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (20, N'Thể Thao - Dã Ngoại', N'the-thao-da-ngoai', NULL, 5, 1, 1, N'/img/images/category/The-thao-da-ngoai.png', N'fa fa-dribbble')
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (21, N'Sách, VPP & Quà Tặng', N'sach-vpp-qua-tang', NULL, 6, 1, 1, N'/img/images/category/Nha-sach.png', N'fa fa-book')
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (22, N'HP', N'hp', 4, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (23, N'Lenovo', N'lenovo', 4, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (24, N'LG', N'lg', 2, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (25, N'Sony', N'sony', 2, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (26, N'Panasonic', N'panasonic', 2, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (27, N'Tai nghe Bluetooth', N'tai-nghe-bluetooth', 3, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (28, N'Loa Bluetooth', N'loa-bluetooth', 3, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (29, N'Sách văn học', N'sach-van-hoc', 21, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (30, N'Sách Kinh Tế', N'sach-kinh-te', 21, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (31, N'Sách Thiếu Nhi', N'sach-thieu-nhi', 21, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (32, N'Biti''s Hunter', N'biti-hunter', 20, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (33, N'Nike', N'nike', 20, NULL, 1, 1, NULL, NULL)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [Status], [ShowOnHome], [image], [icon]) VALUES (34, N'VsMart', N'vsmart', 1, 7, 1, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'ADD_CONTENT', N'Thêm tin tức')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'ADD_USER', N'Thêm user')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'DELETE_USER', N'Xoá user')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'EDIT_CONTENT', N'Sửa tin tức')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'EDIT_USER', N'Sửa user')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'VIEW_USER', N'Xem danh sách user')
SET IDENTITY_INSERT [dbo].[Slide] ON 

INSERT [dbo].[Slide] ([ID], [Name], [Image], [MoreImages], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [Status]) VALUES (1, N'Slide-1', N'/img/images/Slide/1200-x-628-sstv.jpg', NULL, 1, N'/', NULL, CAST(N'2018-12-10 23:23:42.150' AS DateTime), NULL, 1)
INSERT [dbo].[Slide] ([ID], [Name], [Image], [MoreImages], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [Status]) VALUES (2, N'Slide-2', N'/img/images/Slide/slide2.jpg', NULL, 2, N'/', NULL, NULL, NULL, 1)
INSERT [dbo].[Slide] ([ID], [Name], [Image], [MoreImages], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [Status]) VALUES (3, N'Slide-3', N'/img/images/Slide/khuyen-mai-clip-tv-1200-x-628.jpg', NULL, 3, N'/', NULL, NULL, NULL, 1)
INSERT [dbo].[Slide] ([ID], [Name], [Image], [MoreImages], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [Status]) VALUES (5, N'Slide-5', N'/img/images/Slide/100000_trainghiem-1200x628.jpg', NULL, 5, N'/', NULL, NULL, NULL, 1)
INSERT [dbo].[Slide] ([ID], [Name], [Image], [MoreImages], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [Status]) VALUES (6, N'Slide-6', N'/img/images/Slide/banner01.jpg', NULL, 6, N'/', NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Slide] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Birthday], [Gender], [Address], [Email], [Phone], [CreatedDate], [Status]) VALUES (2, N'admin', N'e10adc3949ba59abbe56e057f20f883e', N'ADMIN', N'Tiến Bảo', CAST(N'1997-02-02' AS Date), N'Nam', N'Hà Nội', N'tienbao202@gmail.com', N'0329191490', NULL, 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Birthday], [Gender], [Address], [Email], [Phone], [CreatedDate], [Status]) VALUES (6, N'VietAnh', N'1cc39ffd758234422e1f75beadfc5fb2', N'MEMBER', N'Kiều Việt anh', CAST(N'1997-12-02' AS Date), N'Nam', N'Hà Nội', N'Vietanh1202@gmail.com', N'11111111', NULL, 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Birthday], [Gender], [Address], [Email], [Phone], [CreatedDate], [Status]) VALUES (7, N'VanBinh', N'd9b1d7db4cd6e70935368a1efb10e377', N'MEMBER', N'Đặng Văn Bình', CAST(N'1997-12-02' AS Date), N'Nam', N'Hà Nội ', N'VanBinh102@gmail.com', N'11616161616', NULL, 0)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Birthday], [Gender], [Address], [Email], [Phone], [CreatedDate], [Status]) VALUES (8, N'HongBich', N'202cb962ac59075b964b07152d234b70', N'MEMBER', N'Đỗ Thị Hồng Bích', CAST(N'1997-12-12' AS Date), N'Nữ', N'Hà Nội', N'HongBich@gmail.com', N'016161616661', CAST(N'2018-11-22 15:34:36.863' AS DateTime), 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Birthday], [Gender], [Address], [Email], [Phone], [CreatedDate], [Status]) VALUES (9, N'VanAnh', N'202cb962ac59075b964b07152d234b70', N'MEMBER', N'Đỗ Thị Vân Anh', CAST(N'1997-12-02' AS Date), N'Nữ', N'Hà Nội', N'abc@gmail.com', N'01233361161', NULL, 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Birthday], [Gender], [Address], [Email], [Phone], [CreatedDate], [Status]) VALUES (10, N'DoThiVanAnh', N'202cb962ac59075b964b07152d234b70', N'MEMBER', N'Đỗ Thị Vân Anh', CAST(N'1997-12-02' AS Date), N'Nữ', N'Hà Nội', N'abc@gmail.com', N'01233361161', NULL, 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Birthday], [Gender], [Address], [Email], [Phone], [CreatedDate], [Status]) VALUES (11, N'HoangAnh_1202', N'202cb962ac59075b964b07152d234b70', N'MEMBER', N'Đinh Hoàng Anh', CAST(N'1997-12-02' AS Date), N'Nam', N'Hà Nội', N'abc@gmail.com', N'01233361161', NULL, 0)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Birthday], [Gender], [Address], [Email], [Phone], [CreatedDate], [Status]) VALUES (12, N'VuHoangSon', N'202cb962ac59075b964b07152d234b70', N'MEMBER', N'Vũ Hoàng Sơn', CAST(N'1997-02-05' AS Date), N'Nam', N'Hà Nội', N'abc@gmail.com', N'01233361161', NULL, 0)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Birthday], [Gender], [Address], [Email], [Phone], [CreatedDate], [Status]) VALUES (13, N'ÐinhHoàngAnh', N'202cb962ac59075b964b07152d234b70', N'MEMBER', N'Đinh Hoàng Anh', CAST(N'1998-12-02' AS Date), N'Nam', N'Hà Nội', N'abc@gmail.com', N'01233361161', NULL, 0)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Birthday], [Gender], [Address], [Email], [Phone], [CreatedDate], [Status]) VALUES (15, N'PhamNgocChung', N'202cb962ac59075b964b07152d234b70', N'MEMBER', N'Phạm Ngọc Chung', CAST(N'1997-02-05' AS Date), N'Nam', N'Hà Nội', N'abc@gmail.com', N'01233361161', NULL, 0)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Birthday], [Gender], [Address], [Email], [Phone], [CreatedDate], [Status]) VALUES (17, N'VuXuanDai', N'202cb962ac59075b964b07152d234b70', N'MEMBER', N'Vũ Xuân Đại', CAST(N'1997-10-20' AS Date), N'Nam', N'Hà Nội', N'XuanDai@gmail.com', N'0166616449', NULL, 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Birthday], [Gender], [Address], [Email], [Phone], [CreatedDate], [Status]) VALUES (18, N'NguyenDucAnh', N'202cb962ac59075b964b07152d234b70', N'MEMBER', N'Nguyễn Đức Anh', CAST(N'1998-12-05' AS Date), N'Nam', N'Hà Nội', N'DucAnh102@gmail.com', N'0166616449', NULL, 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Birthday], [Gender], [Address], [Email], [Phone], [CreatedDate], [Status]) VALUES (20, N'TienBao', N'e10adc3949ba59abbe56e057f20f883e', N'MEMBER', N'Nguyễn Tiến Bảo', NULL, N'Nam', N'Hà Nội', N'tienbao202@gmail.com', N'0329191490', NULL, 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [GroupID], [Name], [Birthday], [Gender], [Address], [Email], [Phone], [CreatedDate], [Status]) VALUES (21, N'AnhVietKieu', N'202cb962ac59075b964b07152d234b70', N'MEMBER', N'Kiều Việt Anh', NULL, N'Nam', N'Hà Nội', N'abc12345@gmail.com', N'0329191490', NULL, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
INSERT [dbo].[UserGroup] ([ID], [Name]) VALUES (N'ADMIN', N'Quản trị')
INSERT [dbo].[UserGroup] ([ID], [Name]) VALUES (N'Employee', N'Nhân Viên')
INSERT [dbo].[UserGroup] ([ID], [Name]) VALUES (N'MEMBER', N'Thành viên')
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Feedback_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Content]  WITH CHECK ADD  CONSTRAINT [FK_Content_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Content] CHECK CONSTRAINT [FK_Content_Category]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_MenuType] FOREIGN KEY([TypeID])
REFERENCES [dbo].[MenuType] ([ID])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_MenuType]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[ProductCategory] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductCategory]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserGroup] FOREIGN KEY([GroupID])
REFERENCES [dbo].[UserGroup] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserGroup]
GO
