/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : SQL Server
 Source Server Version : 14001000
 Source Host           : localhost:1433
 Source Catalog        : UserInfo
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 14001000
 File Encoding         : 65001

 Date: 29/03/2020 17:37:57
*/


-- ----------------------------
-- Table structure for UserRankInfo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRankInfo]') AND type IN ('U'))
	DROP TABLE [dbo].[UserRankInfo]
GO

CREATE TABLE [dbo].[UserRankInfo] (
  [ID] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Name] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Gender] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Age] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Email] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Address] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Password] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[UserRankInfo] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of UserRankInfo
-- ----------------------------
INSERT INTO [dbo].[UserRankInfo]  VALUES (N'John', N'John Marston', N'男', N'31', N'mail@mail.com', N'BeecherSHope', N'123')
GO

INSERT INTO [dbo].[UserRankInfo]  VALUES (N'Arthur', N'Arthur Morgan', N'男', N'36', N'mail@mail.com', N'BlackWater', N'123')
GO

INSERT INTO [dbo].[UserRankInfo]  VALUES (N'Sadie', N'Sadie Adler', N'女', N'27', N'mail@mail.com', N'Strawberry', N'123')
GO

INSERT INTO [dbo].[UserRankInfo]  VALUES (N'Abigail', N'Abigail Roberts', N'女', N'29', N'mail@mail.com', N'BeecherSHope', N'123')
GO

INSERT INTO [dbo].[UserRankInfo]  VALUES (N'Dutch', N'Dutch Van Der Linde', N'男', N'43', N'mail@mail.com', N'Strawberry', N'123')
GO

INSERT INTO [dbo].[UserRankInfo]  VALUES (N'Hosea', N'Hosea Matthews', N'男', N'53', N'mail@mail.com', N'Strawberry', N'123')
GO

INSERT INTO [dbo].[UserRankInfo]  VALUES (N'Charles', N'Charles Smith', N'男', N'25', N'mail@mail.com', N'BlackWater', N'123')
GO

INSERT INTO [dbo].[UserRankInfo]  VALUES (N'Jack', N'Jack Marston', N'男', N'7', N'mail@mail.com', N'BlackWater', N'123')
GO

INSERT INTO [dbo].[UserRankInfo]  VALUES (N'Mary', N'Mary-Beth Gaskill', N'女', N'24', N'mail@mail.com', N'BlackWater', N'123')
GO

INSERT INTO [dbo].[UserRankInfo]  VALUES (N'Sean', N'Sean Macguire', N'男', N'23', N'mail@mail.com', N'BlackWater', N'123')
GO

