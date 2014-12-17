/*******************************************************************************
****
****
****              Begin Create DataBase
****
****
********************************************************************************/
USE [master]
GO

/****** 对象:  Database [ContactService]    脚本日期: 12/22/2008 09:25:21 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'ContactService')
DROP DATABASE [ContactService]

USE [master]
GO
/****** 对象:  Database [ContactService]    脚本日期: 12/22/2008 09:20:46 ******/
CREATE DATABASE [ContactService] ON  PRIMARY 
( NAME = N'ContactService', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\ContactService.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ContactService_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\ContactService_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
EXEC dbo.sp_dbcmptlevel @dbname=N'ContactService', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContactService].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [ContactService] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ContactService] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ContactService] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ContactService] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ContactService] SET ARITHABORT OFF 
GO
ALTER DATABASE [ContactService] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ContactService] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ContactService] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ContactService] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ContactService] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ContactService] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ContactService] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ContactService] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ContactService] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ContactService] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ContactService] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ContactService] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ContactService] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ContactService] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ContactService] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ContactService] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ContactService] SET  READ_WRITE 
GO
ALTER DATABASE [ContactService] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ContactService] SET  MULTI_USER 
GO
ALTER DATABASE [ContactService] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ContactService] SET DB_CHAINING OFF 