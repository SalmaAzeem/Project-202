USE [Project 2.0]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[category_id] [int] NOT NULL,
	[category_name] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact_Cooker_Employee]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact_Cooker_Employee](
	[Cooker_id] [int] NOT NULL,
	[Employee_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Cooker_id] ASC,
	[Employee_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact_Delivery_Employee]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact_Delivery_Employee](
	[delivery_id] [int] NOT NULL,
	[Employee_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[delivery_id] ASC,
	[Employee_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cooker]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cooker](
	[Cooker_id] [int] NOT NULL,
	[city] [varchar](255) NOT NULL,
	[street] [varchar](255) NOT NULL,
	[Apartment_Number] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Cooker_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cooks_Meal]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cooks_Meal](
	[Cooker_id] [int] NULL,
	[meal_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customer_id] [int] NOT NULL,
	[city] [varchar](50) NOT NULL,
	[street] [varchar](50) NOT NULL,
	[apartment_number] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[Vehicle_number] [int] NULL,
	[delivery_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[delivery_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Employee_ID] [int] NOT NULL,
	[Employee_role] [varchar](255) NULL,
	[Phone_number] [bigint] NULL,
	[Employee_Name] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Employee_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[Invoice_id] [int] NOT NULL,
	[order_id] [int] NULL,
	[total_price] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Invoice_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meals]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meals](
	[meal_id] [int] NOT NULL,
	[price] [decimal](10, 2) NULL,
	[calories] [int] NULL,
	[Meal_Name] [varchar](255) NULL,
	[counts_of_orders] [int] NULL,
	[Ingredients] [varchar](255) NULL,
	[special_offer_id] [int] NULL,
	[category_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[meal_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MiniShop]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MiniShop](
	[minishop_id] [int] NOT NULL,
	[Cooker_id] [int] NULL,
	[Food_cans] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[minishop_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[order_id] [int] NOT NULL,
	[payment_type] [varchar](50) NULL,
	[order_status] [varchar](50) NULL,
	[customer_id] [int] NULL,
	[delivery_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participate_In_Meals]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participate_In_Meals](
	[meal_id] [int] NULL,
	[order_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participate_In_Minishop]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participate_In_Minishop](
	[minishop_id] [int] NULL,
	[order_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating_Cooker]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating_Cooker](
	[rate_id] [int] NOT NULL,
	[Cooker_id] [int] NULL,
	[rate] [int] NULL,
	[comment] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[rate_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating_Delivery]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating_Delivery](
	[rate_id] [int] NOT NULL,
	[delivery_id] [int] NULL,
	[rate] [int] NULL,
	[comment] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[rate_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating_Meals]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating_Meals](
	[rate_id] [int] NOT NULL,
	[meal_id] [int] NULL,
	[rate] [int] NULL,
	[comment] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[rate_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Special_Offers]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Special_Offers](
	[special_offer_id] [int] NOT NULL,
	[offer_description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[special_offer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Userr]    Script Date: 12/13/2023 3:01:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userr](
	[ID] [int] NOT NULL,
	[UserName] [varchar](100) NULL,
	[Phone_Number] [bigint] NULL,
	[User_Type] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[User_Password] [varchar](100) NULL,
	[Birthdate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (3, N'Dessert')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (4, N'Breakfast')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (5, N'Appetizers')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (6, N'Main Courses')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (7, N'Salads')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (8, N'Snacks')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (9, N'Beverages')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (10, N'Vegetarian')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (11, N'Vegan')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (12, N'Seafood')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (13, N'Poultry')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (14, N'Grilled')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (15, N'Soups')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (16, N'Sandwiches')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (17, N'Pizza')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (18, N'Pasta')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (19, N'Asian')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (20, N'Mexican')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (21, N'Italian')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (22, N'Mediterranean')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (23, N'Dairy-Free')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (24, N'Gluten-Free')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (25, N'Low-Carb')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (26, N'Keto')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (27, N'Low-Fat')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (28, N'Low-Sodium')
INSERT [dbo].[Category] ([category_id], [category_name]) VALUES (29, N'Grain-Free')
GO
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (4, 5)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (4, 17)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (4, 20)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (6, 22)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (6, 26)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (9, 5)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (9, 6)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (9, 18)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (12, 1)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (12, 24)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (15, 14)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (15, 19)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (18, 2)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (18, 28)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (21, 7)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (21, 9)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (21, 28)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (27, 4)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (27, 11)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (30, 13)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (30, 23)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (30, 30)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (33, 3)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (33, 25)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (33, 30)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (36, 10)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (36, 15)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (36, 29)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (39, 21)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (39, 27)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (42, 8)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (42, 12)
INSERT [dbo].[Contact_Cooker_Employee] ([Cooker_id], [Employee_ID]) VALUES (42, 16)
GO
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (5, 18)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (5, 23)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (5, 27)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (7, 30)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (10, 3)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (10, 5)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (10, 10)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (10, 23)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (13, 4)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (13, 6)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (16, 15)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (16, 20)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (16, 30)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (19, 11)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (19, 12)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (22, 1)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (22, 9)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (22, 17)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (25, 16)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (25, 29)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (28, 22)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (28, 24)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (28, 28)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (31, 8)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (31, 18)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (31, 26)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (34, 12)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (34, 13)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (34, 21)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (37, 7)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (37, 25)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (37, 30)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (40, 2)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (40, 14)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (40, 17)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (43, 3)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (43, 10)
INSERT [dbo].[Contact_Delivery_Employee] ([delivery_id], [Employee_ID]) VALUES (43, 19)
GO
INSERT [dbo].[Cooker] ([Cooker_id], [city], [street], [Apartment_Number]) VALUES (4, N'6th of October', N'10', 4)
INSERT [dbo].[Cooker] ([Cooker_id], [city], [street], [Apartment_Number]) VALUES (6, N'6th of October', N'22', 7)
INSERT [dbo].[Cooker] ([Cooker_id], [city], [street], [Apartment_Number]) VALUES (9, N'Helwan', N'15', 3)
INSERT [dbo].[Cooker] ([Cooker_id], [city], [street], [Apartment_Number]) VALUES (12, N'Suez', N'14', 8)
INSERT [dbo].[Cooker] ([Cooker_id], [city], [street], [Apartment_Number]) VALUES (15, N'Marsa Matrouh', N'16', 4)
INSERT [dbo].[Cooker] ([Cooker_id], [city], [street], [Apartment_Number]) VALUES (18, N'Qena', N'21', 13)
INSERT [dbo].[Cooker] ([Cooker_id], [city], [street], [Apartment_Number]) VALUES (21, N'Zagazig', N'3', 19)
INSERT [dbo].[Cooker] ([Cooker_id], [city], [street], [Apartment_Number]) VALUES (27, N'Alexandria', N'5', 12)
INSERT [dbo].[Cooker] ([Cooker_id], [city], [street], [Apartment_Number]) VALUES (30, N'Madinet Nasr', N'8', 2)
INSERT [dbo].[Cooker] ([Cooker_id], [city], [street], [Apartment_Number]) VALUES (33, N'5th Settlement', N'11', 6)
INSERT [dbo].[Cooker] ([Cooker_id], [city], [street], [Apartment_Number]) VALUES (36, N'Helwan', N'18', 1)
INSERT [dbo].[Cooker] ([Cooker_id], [city], [street], [Apartment_Number]) VALUES (39, N'Sharm El Sheikh', N'25', 9)
INSERT [dbo].[Cooker] ([Cooker_id], [city], [street], [Apartment_Number]) VALUES (42, N'Alexandria', N'7', 5)
GO
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (9, 2)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (18, 7)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (36, 1)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (30, 30)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (9, 10)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (42, 20)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (4, 14)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (21, 22)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (39, 19)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (12, 16)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (27, 25)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (15, 4)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (33, 3)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (6, 12)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (18, 27)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (36, 5)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (30, 29)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (9, 8)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (42, 15)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (4, 26)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (21, 18)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (39, 2)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (12, 21)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (27, 11)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (15, 23)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (33, 17)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (6, 13)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (18, 28)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (36, 6)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (30, 24)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (9, 9)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (42, 7)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (4, 16)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (21, 1)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (39, 30)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (12, 19)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (27, 14)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (15, 26)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (33, 22)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (6, 28)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (18, 3)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (36, 25)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (30, 15)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (9, 11)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (42, 4)
INSERT [dbo].[Cooks_Meal] ([Cooker_id], [meal_id]) VALUES (4, 9)
GO
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (1, N'6th of October', N'46', 3)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (2, N'Cairo', N'Maadi', 5)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (3, N'Giza', N'Dokki', 12)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (8, N'Alexandria', N'Stanley', 8)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (11, N'Luxor', N'Karnak', 15)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (14, N'Aswan', N'Elephantine', 22)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (17, N'Hurghada', N'Sheraton', 7)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (20, N'Sharm El Sheikh', N'Naama Bay', 14)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (23, N'Dahab', N'Lighthouse', 21)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (26, N'Marsa Alam', N'Port Ghalib', 6)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (29, N'Port Said', N'Al Manakh', 13)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (32, N'Suez', N'El Arbaeen', 20)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (35, N'Tanta', N'El Gharb', 5)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (38, N'Zagazig', N'Sharkia Square', 12)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (41, N'Ismailia', N'Suez Canal City', 19)
INSERT [dbo].[Customer] ([customer_id], [city], [street], [apartment_number]) VALUES (44, N'Damietta', N'New Damietta', 26)
GO
INSERT [dbo].[Delivery] ([Vehicle_number], [delivery_id]) VALUES (1234, 5)
INSERT [dbo].[Delivery] ([Vehicle_number], [delivery_id]) VALUES (5678, 7)
INSERT [dbo].[Delivery] ([Vehicle_number], [delivery_id]) VALUES (91011, 10)
INSERT [dbo].[Delivery] ([Vehicle_number], [delivery_id]) VALUES (1213, 13)
INSERT [dbo].[Delivery] ([Vehicle_number], [delivery_id]) VALUES (1415, 16)
INSERT [dbo].[Delivery] ([Vehicle_number], [delivery_id]) VALUES (1617, 19)
INSERT [dbo].[Delivery] ([Vehicle_number], [delivery_id]) VALUES (1819, 22)
INSERT [dbo].[Delivery] ([Vehicle_number], [delivery_id]) VALUES (2021, 25)
INSERT [dbo].[Delivery] ([Vehicle_number], [delivery_id]) VALUES (2223, 28)
INSERT [dbo].[Delivery] ([Vehicle_number], [delivery_id]) VALUES (2425, 31)
INSERT [dbo].[Delivery] ([Vehicle_number], [delivery_id]) VALUES (2627, 34)
INSERT [dbo].[Delivery] ([Vehicle_number], [delivery_id]) VALUES (2829, 37)
INSERT [dbo].[Delivery] ([Vehicle_number], [delivery_id]) VALUES (3031, 40)
INSERT [dbo].[Delivery] ([Vehicle_number], [delivery_id]) VALUES (3233, 43)
GO
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (1, N'Administrator', 1115689354, N'Mark')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (2, N'Support', 1235682345, N'Emily')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (3, N'Administrator', 1515681235, N'John')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (4, N'Support', 1015787655, N'Sophia')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (5, N'Administrator', 1210084568, N'Daniel')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (6, N'Support', 1115683457, N'Olivia')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (7, N'Administrator', 1115686544, N'James')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (8, N'Support', 1115685433, N'Ava')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (9, N'Administrator', 1115688977, N'Liam')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (10, N'Support', 1115687866, N'Emma')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (11, N'Administrator', 1115686755, N'Noah')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (12, N'Support', 1115685644, N'Isabella')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (13, N'Administrator', 1115688766, N'Ethan')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (14, N'Support', 1115687655, N'Sophia')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (15, N'Administrator', 1115689544, N'Mia')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (16, N'Support', 1115683457, N'Oliver')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (17, N'Administrator', 1115681235, N'Ava')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (18, N'Support', 1115688977, N'Lucas')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (19, N'Administrator', 1115686755, N'Isabella')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (20, N'Support', 1117605433, N'Liam')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (21, N'Administrator', 1115689544, N'Emma')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (22, N'Support', 1115687866, N'Noah')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (23, N'Administrator', 1115685644, N'Olivia')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (24, N'Support', 1115653457, N'Sophia')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (25, N'Administrator', 1115688977, N'Ethan')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (26, N'Support', 1215686544, N'Ava')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (27, N'Administrator', 1215686755, N'Liam')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (28, N'Support', 1015685433, N'Emma')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (29, N'Administrator', 1115685644, N'Oliver')
INSERT [dbo].[Employee] ([Employee_ID], [Employee_role], [Phone_number], [Employee_Name]) VALUES (30, N'Support', 1115689544, N'Sophia')
GO
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (1, 2, CAST(345.99 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (2, 3, CAST(245.50 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (3, 5, CAST(132.75 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (4, 7, CAST(189.99 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (5, 9, CAST(78.25 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (6, 11, CAST(215.00 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (7, 13, CAST(97.50 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (8, 15, CAST(123.00 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (9, 17, CAST(332.75 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (10, 19, CAST(189.50 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (11, 21, CAST(74.99 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (12, 23, CAST(215.00 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (13, 25, CAST(112.75 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (14, 27, CAST(177.25 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (15, 29, CAST(298.50 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (16, 30, CAST(89.99 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (17, 4, CAST(165.00 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (18, 6, CAST(120.75 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (19, 8, CAST(249.50 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (20, 10, CAST(97.25 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (21, 12, CAST(183.00 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (22, 14, CAST(98.75 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (23, 16, CAST(210.25 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (24, 18, CAST(145.50 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (25, 20, CAST(189.99 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (26, 22, CAST(67.75 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (27, 24, CAST(145.00 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (28, 26, CAST(224.75 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (29, 28, CAST(178.50 AS Decimal(10, 2)))
INSERT [dbo].[Invoices] ([Invoice_id], [order_id], [total_price]) VALUES (30, 1, CAST(103.99 AS Decimal(10, 2)))
GO
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (1, CAST(56.99 AS Decimal(10, 2)), 300, N'Stuffed Grape Leaves', 2, N'Grape Leaves, Rice, Tomato, Parlsey, Onion, Salt, Spices, Pepper', NULL, 5)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (2, CAST(45.99 AS Decimal(10, 2)), 250, N'Hawawshi', 3, N'Ground Beef, Bread, Onion, Parsley, Garlic, Salt, Pepper', NULL, 6)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (3, CAST(34.99 AS Decimal(10, 2)), 180, N'Ful Medames', 4, N'Fava Beans, Olive Oil, Garlic, Lemon, Cumin, Salt', NULL, 4)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (4, CAST(62.50 AS Decimal(10, 2)), 320, N'Mansaf', 6, N'Lamb, Yogurt, Rice, Almonds, Pine Nuts, Jameed', NULL, 6)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (5, CAST(28.75 AS Decimal(10, 2)), 150, N'Koshary', 8, N'Lentils, Rice, Pasta, Chickpeas, Tomato Sauce, Garlic Vinegar', NULL, 6)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (6, CAST(40.99 AS Decimal(10, 2)), 200, N'Mulukhiyah', 10, N'Mulukhiyah Leaves, Chicken, Garlic, Coriander, Lemon', NULL, 6)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (7, CAST(18.50 AS Decimal(10, 2)), 90, N'Taameya (Falafel)', 12, N'Fava Beans, Chickpeas, Onion, Garlic, Coriander, Cumin', NULL, 5)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (8, CAST(52.00 AS Decimal(10, 2)), 280, N'Molokhia with Rabbit', 14, N'Molokhia Leaves, Rabbit, Garlic, Coriander, Lemon', NULL, 6)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (9, CAST(38.25 AS Decimal(10, 2)), 220, N'Shawarma', 16, N'Chicken, Yogurt, Garlic, Lemon, Olive Oil, Spices', NULL, 6)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (10, CAST(29.99 AS Decimal(10, 2)), 160, N'Bamia', 18, N'Okra, Beef, Tomato, Garlic, Coriander, Lemon', NULL, 6)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (11, CAST(43.75 AS Decimal(10, 2)), 260, N'Roz Bel Laban', 20, N'Rice, Milk, Sugar, Vanilla, Cinnamon', NULL, 3)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (12, CAST(22.00 AS Decimal(10, 2)), 110, N'Fattoush', 22, N'Lettuce, Tomato, Cucumber, Radish, Mint, Sumac, Pita Bread', NULL, 5)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (13, CAST(36.50 AS Decimal(10, 2)), 190, N'Kebab', 24, N'Beef, Onion, Bell Pepper, Tomato, Garlic, Spices', NULL, 6)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (14, CAST(27.99 AS Decimal(10, 2)), 140, N'Dolma', 26, N'Grape Leaves, Rice, Tomato, Parsley, Onion, Salt, Spices, Pepper', NULL, 5)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (15, CAST(48.75 AS Decimal(10, 2)), 240, N'Egyptian Moussaka', 28, N'Eggplant, Ground Beef, Onion, Garlic, Tomato, Bechamel Sauce', NULL, 6)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (16, CAST(32.00 AS Decimal(10, 2)), 170, N'Baba Ganoush', 30, N'Eggplant, Tahini, Garlic, Lemon, Olive Oil', NULL, 5)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (17, CAST(57.25 AS Decimal(10, 2)), 310, N'Hummus with Meat', 32, N'Chickpeas, Ground Beef, Tahini, Garlic, Lemon', NULL, 6)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (18, CAST(41.50 AS Decimal(10, 2)), 210, N'Kunafa', 34, N'Kunafa Dough, Cheese, Sugar Syrup, Rosewater', NULL, 3)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (19, CAST(23.99 AS Decimal(10, 2)), 120, N'Egyptian Falafel Sandwich', 36, N'Tameya, Pita Bread, Lettuce, Tomato, Tahini Sauce', NULL, 4)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (20, CAST(53.75 AS Decimal(10, 2)), 280, N'Kabab Kofta', 38, N'Ground Beef, Onion, Garlic, Parsley, Spices', NULL, 6)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (21, CAST(35.00 AS Decimal(10, 2)), 180, N'Samak Meshwi', 40, N'Grilled Fish, Olive Oil, Lemon, Garlic, Spices', NULL, 12)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (22, CAST(19.50 AS Decimal(10, 2)), 100, N'Basbousa', 42, N'Semolina, Coconut, Yogurt, Sugar, Baking Powder', NULL, 3)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (23, CAST(46.99 AS Decimal(10, 2)), 250, N'Mushabbak', 44, N'Fried Dough, Sugar Syrup, Sesame Seeds', NULL, 3)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (24, CAST(30.25 AS Decimal(10, 2)), 160, N'Sambousek', 46, N'Dough, Ground Meat, Onion, Pine Nuts, Spices', NULL, 5)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (25, CAST(55.50 AS Decimal(10, 2)), 300, N'Fried Pigeon', 48, N'Pigeon, Rice, Onion, Garlic, Spices', NULL, 6)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (26, CAST(40.99 AS Decimal(10, 2)), 220, N'Sheer Khurma', 50, N'Vermicelli, Milk, Sugar, Dates, Nuts', NULL, 3)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (27, CAST(22.75 AS Decimal(10, 2)), 120, N'Egyptian Omelette', 52, N'Eggs, Onion, Tomato, Bell Pepper, Spices', NULL, 4)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (28, CAST(48.00 AS Decimal(10, 2)), 260, N'Zalabia', 54, N'Flour, Yogurt, Sugar Syrup, Rosewater', NULL, 3)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (29, CAST(33.50 AS Decimal(10, 2)), 180, N'Shorbat Adas', 56, N'Lentils, Onion, Garlic, Cumin, Lemon', NULL, 5)
INSERT [dbo].[Meals] ([meal_id], [price], [calories], [Meal_Name], [counts_of_orders], [Ingredients], [special_offer_id], [category_id]) VALUES (30, CAST(26.99 AS Decimal(10, 2)), 140, N'Mahshi', 58, N'Cabbage, Rice, Tomato Sauce, Spices', NULL, 6)
GO
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (1, 4, N'Pickled Onions')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (2, 6, N'Homemade Jam')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (3, 9, N'Pickled Vegetables Mix')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (4, 12, N'Cut Vegetables Pack')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (5, 15, N'Artisanal Cheese')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (6, 18, N'Homemade Ghee')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (7, 21, N'Spicy Pickles')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (8, 27, N'Preserved Fruits')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (9, 30, N'Homemade Salsa')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (10, 33, N'Infused Olive Oil')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (11, 36, N'Homemade Granola')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (12, 39, N'Fermented Sauerkraut')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (13, 42, N'Flavored Butter')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (14, 4, N'Homemade Chutney')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (15, 6, N'Candied Nuts Mix')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (16, 9, N'Dried Herbs Sampler')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (17, 12, N'Homemade Pasta Sauce')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (18, 15, N'Marinated Olives')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (19, 18, N'Homemade Pesto')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (20, 21, N'Pickled Garlic Cloves')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (21, 27, N'Homemade Spice Blend')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (22, 30, N'Flavored Honey Jar')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (23, 33, N'Homemade BBQ Sauce')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (24, 36, N'Fruit Preserves')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (25, 39, N'Homemade Nut Butter')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (26, 42, N'Canned Soup Mix')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (27, 4, N'Homemade Tomato Ketchup')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (28, 6, N'Dried Fruit Medley')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (29, 9, N'Homemade Sausage')
INSERT [dbo].[MiniShop] ([minishop_id], [Cooker_id], [Food_cans]) VALUES (30, 12, N'Pickled Beetroot Slices')
GO
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (1, N'Cash', N'Delivered', 1, 5)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (2, N'Credit Card', N'Not Delivered', 2, 7)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (3, N'Cash', N'Delivered', 3, 10)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (4, N'Credit Card', N'Delivered', 8, 13)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (5, N'Cash', N'Delivered', 11, 16)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (6, N'Credit Card', N'Delivered', 14, 19)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (7, N'Cash', N'Not Delivered', 17, 22)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (8, N'Credit Card', N'Delivered', 20, 25)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (9, N'Cash', N'Delivered', 23, 28)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (10, N'Credit Card', N'Delivered', 26, 31)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (11, N'Cash', N'Delivered', 29, 34)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (12, N'Credit Card', N'Delivered', 32, 37)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (13, N'Cash', N'Delivered', 35, 40)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (14, N'Credit Card', N'Delivered', 38, 43)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (15, N'Cash', N'Delivered', 41, 5)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (16, N'Credit Card', N'Not Delivered', 44, 7)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (17, N'Cash', N'Delivered', 2, 10)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (18, N'Credit Card', N'Delivered', 3, 13)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (19, N'Cash', N'Delivered', 8, 16)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (20, N'Credit Card', N'Delivered', 11, 19)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (21, N'Cash', N'Delivered', 14, 22)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (22, N'Credit Card', N'Delivered', 17, 25)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (23, N'Cash', N'Not Delivered', 20, 28)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (24, N'Credit Card', N'Delivered', 23, 31)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (25, N'Cash', N'Not Delivered', 26, 34)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (26, N'Credit Card', N'Delivered', 29, 37)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (27, N'Cash', N'Delivered', 32, 40)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (28, N'Credit Card', N'Not Delivered', 35, 43)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (29, N'Cash', N'Delivered', 38, 5)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (30, N'Credit Card', N'Delivered', 41, 7)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (31, N'Credit Card', N'Delivered', 1, 22)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (32, N'Cash', N'Delivered', 2, 43)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (33, N'Credit Card', N'Delivered', 3, 31)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (34, N'Cash', N'Delivered', 3, 10)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (35, N'Credit Card', N'Not Delivered', 8, 19)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (36, N'Cash', N'Delivered', 11, 19)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (37, N'Credit Card', N'Delivered', 1, 22)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (38, N'Cash', N'Delivered', 20, 25)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (39, N'Credit Card', N'Delivered', 17, 28)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (40, N'Cash', N'Delivered', 14, 19)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (41, N'Credit Card', N'Delivered', 2, 37)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (42, N'Cash', N'Delivered', 44, 28)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (43, N'Credit Card', N'Delivered', 38, 19)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (44, N'Cash', N'Not Delivered', 32, 40)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (45, N'Credit Card', N'Delivered', 29, 5)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (46, N'Cash', N'Delivered', 20, 31)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (47, N'Credit Card', N'Delivered', 14, 22)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (49, N'Credit Card', N'Delivered', 8, 40)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (51, N'Credit Card', N'Delivered', 3, 13)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (52, N'Cash', N'Delivered', 29, 28)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (53, N'Credit Card', N'Not Delivered', 29, 19)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (54, N'Cash', N'Delivered', 11, 43)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (55, N'Credit Card', N'Delivered', 8, 19)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (56, N'Cash', N'Delivered', 26, 10)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (57, N'Credit Card', N'Delivered', 11, 31)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (58, N'Cash', N'Delivered', 44, 40)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (59, N'Credit Card', N'Delivered', 41, 13)
INSERT [dbo].[Orders] ([order_id], [payment_type], [order_status], [customer_id], [delivery_id]) VALUES (60, N'Cash', N'Delivered', 8, 25)
GO
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (2, 11)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (10, 45)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (5, 34)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (17, 3)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (25, 27)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (21, 24)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (28, 14)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (1, 56)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (22, 36)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (8, 58)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (29, 31)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (18, 52)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (14, 11)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (9, 19)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (23, 44)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (11, 15)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (2, 47)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (26, 41)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (20, 28)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (4, 53)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (30, 37)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (16, 23)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (7, 35)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (19, 30)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (3, 12)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (27, 26)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (12, 59)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (15, 21)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (6, 55)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (10, 46)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (5, 33)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (17, 4)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (25, 28)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (21, 25)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (28, 13)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (1, 57)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (22, 35)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (13, 49)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (8, 57)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (29, 32)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (18, 51)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (14, 10)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (9, 18)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (23, 45)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (11, 16)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (26, 42)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (20, 29)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (4, 54)
INSERT [dbo].[Participate_In_Meals] ([meal_id], [order_id]) VALUES (30, 38)
GO
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (20, 5)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (7, 34)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (19, 30)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (9, 58)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (25, 27)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (21, 24)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (28, 13)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (6, 55)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (22, 15)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (13, 49)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (8, 18)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (29, 32)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (18, 52)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (14, 10)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (9, 19)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (23, 45)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (11, 16)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (26, 42)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (20, 29)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (4, 54)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (30, 38)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (16, 23)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (7, 35)
INSERT [dbo].[Participate_In_Minishop] ([minishop_id], [order_id]) VALUES (29, 15)
GO
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (1, 4, 3, N'Amazing')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (2, 6, 4, N'Excellent')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (3, 9, 5, N'Outstanding')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (4, 12, 2, N'Needs Improvement')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (5, 15, 4, N'Great Job!')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (6, 18, 3, N'Good')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (7, 21, 5, N'ye5rebet gamal el akl da')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (8, 27, 4, N'Very Satisfactory')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (9, 30, 3, N'Nice Cooking Skills')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (10, 33, 5, N'Absolutely Delicious')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (11, 36, 4, N'Impressive')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (12, 39, 2, N'Could be Better')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (13, 42, 5, N'Superb')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (14, 4, 3, N'Satisfying')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (15, 6, 4, N'Well Done')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (16, 9, 5, N'Amazing Cooking')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (17, 12, 3, N'Delicious')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (18, 15, 4, N'Perfectly Cooked')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (19, 18, 5, N'Fantastic')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (20, 21, 3, N'Tasty')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (21, 27, 4, N'Wonderful')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (22, 30, 5, N'Mouthwatering')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (23, 33, 3, N'Yummy')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (24, 36, 4, N'Impressive Skills')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (25, 39, 5, N'Top Chef')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (26, 42, 3, N'Teslam edek ya fanana')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (27, 4, 4, N'Highly Recommend')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (28, 6, 5, N'Akalt sawab3y waraha')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (29, 9, 3, N'Flavorful')
INSERT [dbo].[Rating_Cooker] ([rate_id], [Cooker_id], [rate], [comment]) VALUES (30, 12, 4, N'Savory Delights')
GO
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (1, 5, 2, N'Slow Delivery')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (2, 7, 3, N'Timely Delivery')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (3, 10, 4, N'Efficient Service')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (4, 13, 2, N'Late Delivery')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (5, 16, 5, N'Prompt Delivery')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (6, 19, 3, N'Satisfactory')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (7, 22, 4, N'Quick Response')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (8, 25, 2, N'Delayed Arrival')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (9, 28, 5, N'Fast and Reliable')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (10, 31, 3, N'On-Time')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (11, 34, 4, N'Excellent Delivery')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (12, 37, 2, N'Delivery Time Needs Improvement')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (13, 40, 5, N'Super Speedy')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (14, 43, 3, N'Average Delivery')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (15, 5, 4, N'Delivery Service')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (16, 7, 2, N'Late Arrival')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (17, 10, 5, N'Impressive Delivery')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (18, 13, 3, N'Delivered on Time')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (19, 16, 4, N'Efficient Delivery')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (20, 19, 2, N'Delayed')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (21, 22, 5, N'Quick and Accurate')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (22, 25, 3, N'Reliable Delivery')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (23, 28, 4, N'Swift Service')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (24, 31, 2, N'Needs Improvement')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (25, 34, 5, N'Speedy Delivery')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (26, 37, 3, N'Timely Arrival')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (27, 40, 4, N'On Schedule')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (28, 43, 2, N'Not Punctual')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (29, 5, 5, N'Excellent Timing')
INSERT [dbo].[Rating_Delivery] ([rate_id], [delivery_id], [rate], [comment]) VALUES (30, 7, 3, N'Delivered as Promised')
GO
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (1, 20, 5, N'Delicious')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (2, 17, 4, N'Tasty and Filling')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (3, 5, 3, N'Average Meal')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (4, 29, 5, N'Exceptional Flavor')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (5, 12, 2, N'Disappointing')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (6, 3, 4, N'Well-Crafted Dish')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (7, 25, 5, N'Absolutely Delicious')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (8, 8, 3, N'Satisfying Meal')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (9, 13, 4, N'Flavorful')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (10, 21, 5, N'Perfectly Cooked')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (11, 2, 3, N'Good Portion Size')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (12, 30, 4, N'Mouthwatering')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (13, 16, 5, N'Highly Recommend')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (14, 4, 3, N'Balanced Meal')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (15, 27, 4, N'Savory Delights')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (16, 1, 5, N'Gourmet Experience')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (17, 7, 3, N'Decent Dish')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (18, 18, 4, N'Impressive Presentation')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (19, 23, 5, N'Superb Taste')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (20, 9, 3, N'Tasty Combination')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (21, 14, 4, N'Well-Seasoned')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (22, 19, 5, N'Exquisite Cuisine')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (23, 11, 3, N'Enjoyable Meal')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (24, 22, 4, N'Rich Flavor')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (25, 28, 5, N'Divine Culinary Experience')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (26, 6, 3, N'Satisfying Portion')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (27, 15, 4, N'Fantastic Dish')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (28, 26, 5, N'Incredible Taste')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (29, 20, 3, N'Pleasing Meal')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (30, 10, 4, N'Delightful Flavor')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (31, 24, 5, N'Delicious and Nutritious')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (32, 30, 3, N'Average Taste')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (33, 2, 4, N'Tantalizing')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (34, 16, 5, N'Outstanding Dish')
INSERT [dbo].[Rating_Meals] ([rate_id], [meal_id], [rate], [comment]) VALUES (35, 8, 3, N'Fairly Good Meal')
GO
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (1, N'50% Off')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (2, N'20% Off')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (3, N'Buy One Get One Free')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (4, N'30% Off')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (5, N'Free Shipping')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (6, N'BOGO 50% Off')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (7, N'15% Off on Next Purchase')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (8, N'Clearance Sale')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (9, N'Limited Time Offer')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (10, N'Gift with Purchase')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (11, N'Flash Sale')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (12, N'Special Weekend Deals')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (13, N'Exclusive Online Offer')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (14, N'Extra 10% Off for Members')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (15, N'Holiday Season Discount')
INSERT [dbo].[Special_Offers] ([special_offer_id], [offer_description]) VALUES (16, N'Free Gift Wrapping with Purchase')
GO
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (1, N'Salma', 1117034999, N'Customer', N'salmaAyman@gmail.com', N'salma1234', CAST(N'2004-07-11' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (2, N'Salma', 222222222, N'Customer', N'salmasherif@gmail.com', N'soso1234', CAST(N'2004-05-17' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (3, N'Doha', 222222222, N'Customer', N'doha@gmail.com', N'doha1234', CAST(N'2004-07-01' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (4, N'Mariam', 222222222, N'Cooker', N'mariam@gmail.com', N'mari234', CAST(N'2005-01-30' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (5, N'Farah', 222222222, N'Driver', N'farah@gmail.com', N'farah1234', CAST(N'2004-07-10' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (6, N'Chris', 222222222, N'Cooker', N'Chris@gmail.com', N'Chris1234', CAST(N'1988-05-15' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (7, N'David', 333333333, N'Driver', N'David@gmail.com', N'David1234', CAST(N'1975-12-20' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (8, N'Emma', 444444444, N'Customer', N'Emma@gmail.com', N'Emma1234', CAST(N'1990-07-10' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (9, N'Fiona', 555555555, N'Cooker', N'Fiona@gmail.com', N'Fiona1234', CAST(N'1995-02-28' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (10, N'George', 666666666, N'Driver', N'George@gmail.com', N'George1234', CAST(N'1982-09-05' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (11, N'Hannah', 777777777, N'Customer', N'Hannah@gmail.com', N'Hannah1234', CAST(N'1993-11-15' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (12, N'Isaac', 888888888, N'Cooker', N'Isaac@gmail.com', N'Isaac1234', CAST(N'1980-04-20' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (13, N'Jessica', 999999999, N'Driver', N'Jessica@gmail.com', N'Jessica1234', CAST(N'1987-08-25' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (14, N'Kevin', 101010101, N'Customer', N'Kevin@gmail.com', N'Kevin1234', CAST(N'1999-03-10' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (15, N'Lily', 111111111, N'Cooker', N'Lily@gmail.com', N'Lily1234', CAST(N'1985-06-05' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (16, N'Megan', 222222222, N'Driver', N'Megan@gmail.com', N'Megan1234', CAST(N'1992-04-15' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (17, N'Noah', 333333333, N'Customer', N'Noah@gmail.com', N'Noah1234', CAST(N'1989-11-20' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (18, N'Olivia', 444444444, N'Cooker', N'Olivia@gmail.com', N'Olivia1234', CAST(N'1997-07-10' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (19, N'Peter', 555555555, N'Driver', N'Peter@gmail.com', N'Peter1234', CAST(N'1994-02-28' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (20, N'Quinn', 666666666, N'Customer', N'Quinn@gmail.com', N'Quinn1234', CAST(N'1981-09-05' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (21, N'Rachel', 777777777, N'Cooker', N'Rachel@gmail.com', N'Rachel1234', CAST(N'1996-11-15' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (22, N'Samuel', 888888888, N'Driver', N'Samuel@gmail.com', N'Samuel1234', CAST(N'1983-04-20' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (23, N'Taylor', 999999999, N'Customer', N'Taylor@gmail.com', N'Taylor1234', CAST(N'1988-08-25' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (24, N'Ulysses', 101010101, N'Cooker', N'Ulysses@gmail.com', N'Ulysses1234', CAST(N'1991-03-10' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (25, N'Victoria', 111111111, N'Driver', N'Victoria@gmail.com', N'Victoria1234', CAST(N'1986-06-05' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (26, N'William', 222222222, N'Customer', N'William@gmail.com', N'William1234', CAST(N'1995-04-15' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (27, N'Xena', 333333333, N'Cooker', N'Xena@gmail.com', N'Xena1234', CAST(N'1990-11-20' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (28, N'Yusuf', 444444444, N'Driver', N'Yusuf@gmail.com', N'Yusuf1234', CAST(N'1987-07-10' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (29, N'Zara', 555555555, N'Customer', N'Zara@gmail.com', N'Zara1234', CAST(N'1992-02-28' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (30, N'Aaron', 666666666, N'Cooker', N'Aaron@gmail.com', N'Aaron1234', CAST(N'1989-09-05' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (31, N'Bella', 777777777, N'Driver', N'Bella@gmail.com', N'Bella1234', CAST(N'1996-11-15' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (32, N'Caleb', 888888888, N'Customer', N'Caleb@gmail.com', N'Caleb1234', CAST(N'1983-04-20' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (33, N'Diana', 999999999, N'Cooker', N'Diana@gmail.com', N'Diana1234', CAST(N'1988-08-25' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (34, N'Evan', 101010101, N'Driver', N'Evan@gmail.com', N'Evan1234', CAST(N'1991-03-10' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (35, N'Felicity', 111111111, N'Customer', N'Felicity@gmail.com', N'Felicity1234', CAST(N'1986-06-05' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (36, N'Gabriel', 222222222, N'Cooker', N'Gabriel@gmail.com', N'Gabriel1234', CAST(N'1995-04-15' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (37, N'Holly', 333333333, N'Driver', N'Holly@gmail.com', N'Holly1234', CAST(N'1990-11-20' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (38, N'Ian', 444444444, N'Customer', N'Ian@gmail.com', N'Ian1234', CAST(N'1987-07-10' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (39, N'Jasmine', 555555555, N'Cooker', N'Jasmine@gmail.com', N'Jasmine1234', CAST(N'1992-02-28' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (40, N'Katherine', 666666666, N'Driver', N'Katherine@gmail.com', N'Katherine1234', CAST(N'1989-09-05' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (41, N'Liam', 777777777, N'Customer', N'Liam@gmail.com', N'Liam1234', CAST(N'1996-11-15' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (42, N'Mia', 888888888, N'Cooker', N'Mia@gmail.com', N'Mia1234', CAST(N'1983-04-20' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (43, N'Nathan', 999999999, N'Driver', N'Nathan@gmail.com', N'Nathan1234', CAST(N'1988-08-25' AS Date))
INSERT [dbo].[Userr] ([ID], [UserName], [Phone_Number], [User_Type], [Email], [User_Password], [Birthdate]) VALUES (44, N'Olivia', 101010101, N'Customer', N'Olivia@gmail.com', N'Olivia1234', CAST(N'1991-03-10' AS Date))
GO
ALTER TABLE [dbo].[Contact_Cooker_Employee]  WITH CHECK ADD FOREIGN KEY([Cooker_id])
REFERENCES [dbo].[Cooker] ([Cooker_id])
GO
ALTER TABLE [dbo].[Contact_Cooker_Employee]  WITH CHECK ADD FOREIGN KEY([Employee_ID])
REFERENCES [dbo].[Employee] ([Employee_ID])
GO
ALTER TABLE [dbo].[Contact_Delivery_Employee]  WITH CHECK ADD FOREIGN KEY([delivery_id])
REFERENCES [dbo].[Delivery] ([delivery_id])
GO
ALTER TABLE [dbo].[Contact_Delivery_Employee]  WITH CHECK ADD FOREIGN KEY([Employee_ID])
REFERENCES [dbo].[Employee] ([Employee_ID])
GO
ALTER TABLE [dbo].[Cooker]  WITH CHECK ADD FOREIGN KEY([Cooker_id])
REFERENCES [dbo].[Userr] ([ID])
GO
ALTER TABLE [dbo].[Cooks_Meal]  WITH CHECK ADD FOREIGN KEY([Cooker_id])
REFERENCES [dbo].[Cooker] ([Cooker_id])
GO
ALTER TABLE [dbo].[Cooks_Meal]  WITH CHECK ADD FOREIGN KEY([meal_id])
REFERENCES [dbo].[Meals] ([meal_id])
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[Userr] ([ID])
GO
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD FOREIGN KEY([delivery_id])
REFERENCES [dbo].[Userr] ([ID])
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO
ALTER TABLE [dbo].[Meals]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([category_id])
GO
ALTER TABLE [dbo].[Meals]  WITH CHECK ADD FOREIGN KEY([special_offer_id])
REFERENCES [dbo].[Special_Offers] ([special_offer_id])
GO
ALTER TABLE [dbo].[MiniShop]  WITH CHECK ADD FOREIGN KEY([Cooker_id])
REFERENCES [dbo].[Cooker] ([Cooker_id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customer_id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([delivery_id])
REFERENCES [dbo].[Delivery] ([delivery_id])
GO
ALTER TABLE [dbo].[Participate_In_Meals]  WITH CHECK ADD FOREIGN KEY([meal_id])
REFERENCES [dbo].[Meals] ([meal_id])
GO
ALTER TABLE [dbo].[Participate_In_Meals]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO
ALTER TABLE [dbo].[Participate_In_Minishop]  WITH CHECK ADD FOREIGN KEY([minishop_id])
REFERENCES [dbo].[MiniShop] ([minishop_id])
GO
ALTER TABLE [dbo].[Participate_In_Minishop]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO
ALTER TABLE [dbo].[Rating_Cooker]  WITH CHECK ADD FOREIGN KEY([Cooker_id])
REFERENCES [dbo].[Cooker] ([Cooker_id])
GO
ALTER TABLE [dbo].[Rating_Delivery]  WITH CHECK ADD FOREIGN KEY([delivery_id])
REFERENCES [dbo].[Delivery] ([delivery_id])
GO
ALTER TABLE [dbo].[Rating_Meals]  WITH CHECK ADD FOREIGN KEY([meal_id])
REFERENCES [dbo].[Meals] ([meal_id])
GO
