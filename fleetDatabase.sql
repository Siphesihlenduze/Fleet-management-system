USE [master]
GO

/****** Object:  Database [fleetDatabase]    Script Date: 2021/11/12 10:11:56 ******/
DROP DATABASE [fleetDatabase]
GO

/****** Object:  Database [fleetDatabase]    Script Date: 2021/11/12 10:11:56 ******/
CREATE DATABASE [fleetDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'fleetDatabase_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\fleetDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'fleetDatabase_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\fleetDatabase.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [fleetDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [fleetDatabase] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [fleetDatabase] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [fleetDatabase] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [fleetDatabase] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [fleetDatabase] SET ARITHABORT OFF 
GO

ALTER DATABASE [fleetDatabase] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [fleetDatabase] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [fleetDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [fleetDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [fleetDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [fleetDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [fleetDatabase] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [fleetDatabase] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [fleetDatabase] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [fleetDatabase] SET  DISABLE_BROKER 
GO

ALTER DATABASE [fleetDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [fleetDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [fleetDatabase] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [fleetDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [fleetDatabase] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [fleetDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [fleetDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [fleetDatabase] SET RECOVERY FULL 
GO

ALTER DATABASE [fleetDatabase] SET  MULTI_USER 
GO

ALTER DATABASE [fleetDatabase] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [fleetDatabase] SET DB_CHAINING OFF 
GO

ALTER DATABASE [fleetDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [fleetDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [fleetDatabase] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [fleetDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [fleetDatabase] SET QUERY_STORE = OFF
GO

ALTER DATABASE [fleetDatabase] SET  READ_WRITE 
GO

