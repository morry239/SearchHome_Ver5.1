-- MySQL dump 10.13  Distrib 5.7.24, for osx10.9 (x86_64)
--
-- Host: localhost    Database: SearchHome
-- ------------------------------------------------------
-- Server version	11.6.2-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `AspNetRoleClaims`
--

DROP TABLE IF EXISTS `AspNetRoleClaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetRoleClaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci DEFAULT NULL,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetRoleClaims`
--

LOCK TABLES `AspNetRoleClaims` WRITE;
/*!40000 ALTER TABLE `AspNetRoleClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetRoleClaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetRoles`
--

DROP TABLE IF EXISTS `AspNetRoles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetRoles` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetRoles`
--

LOCK TABLES `AspNetRoles` WRITE;
/*!40000 ALTER TABLE `AspNetRoles` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetRoles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserClaims`
--

DROP TABLE IF EXISTS `AspNetUserClaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserClaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci DEFAULT NULL,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserClaims`
--

LOCK TABLES `AspNetUserClaims` WRITE;
/*!40000 ALTER TABLE `AspNetUserClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserClaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserLogins`
--

DROP TABLE IF EXISTS `AspNetUserLogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserLogins` (
  `LoginProvider` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci NOT NULL,
  `ProviderKey` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci DEFAULT NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserLogins`
--

LOCK TABLES `AspNetUserLogins` WRITE;
/*!40000 ALTER TABLE `AspNetUserLogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserLogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserRoles`
--

DROP TABLE IF EXISTS `AspNetUserRoles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserRoles` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserRoles`
--

LOCK TABLES `AspNetUserRoles` WRITE;
/*!40000 ALTER TABLE `AspNetUserRoles` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserRoles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUserTokens`
--

DROP TABLE IF EXISTS `AspNetUserTokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUserTokens` (
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci NOT NULL,
  `Age` varchar(30) NOT NULL,
  `Location` varchar(30) NOT NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci NOT NULL,
  `LoginProvider` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci DEFAULT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUserTokens`
--

LOCK TABLES `AspNetUserTokens` WRITE;
/*!40000 ALTER TABLE `AspNetUserTokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserTokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `AspNetUsers`
--

DROP TABLE IF EXISTS `AspNetUsers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AspNetUsers` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) DEFAULT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) DEFAULT NULL,
  `TwoFactorEnabled` tinyint(1) DEFAULT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) DEFAULT NULL,
  `AccessFailedCount` int(11) DEFAULT NULL,
  `CreatedOnUtc` datetime DEFAULT NULL,
  `UpdatedOnUtc` datetime DEFAULT NULL,
  `Age` int(11) DEFAULT NULL,
  `Location` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci DEFAULT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_uca1400_ai_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AspNetUsers`
--

LOCK TABLES `AspNetUsers` WRITE;
/*!40000 ALTER TABLE `AspNetUsers` DISABLE KEYS */;
INSERT INTO `AspNetUsers` VALUES ('9d938670-140d-4e61-b13d-3b99d7d331eb','katedrala.sv.vitafvltava4512@gmail.com','KATEDRALA.SV.VITAFVLTAVA4512@GMAIL.COM','katedrala.sv.vitafvltava4512@gmail.com','KATEDRALA.SV.VITAFVLTAVA4512@GMAIL.COM',1,'AQAAAAIAAYagAAAAEBX7tCVXbleWjwFql27WVZXuATwuYvpxv0a80KdHzcck3ce0HsTnjyw94aSpkYxR6Q==','2IMUKERXXETTOSGT4WMM37NX4H5DB2V6','7ff50554-4583-4d27-a695-2b1b104852af',NULL,0,0,NULL,1,0,NULL,NULL,NULL,NULL,NULL),('c311aae6-92d8-4c6f-9fb3-fbfa42fa27ae','kawamura20225@hs-ansbach.de','KAWAMURA20225@HS-ANSBACH.DE','kawamura20225@hs-ansbach.de','KAWAMURA20225@HS-ANSBACH.DE',0,'AQAAAAIAAYagAAAAED33JzE/jC7NxgXzDJ1RIPe2zH6txPjjjlQGM94BlVpjmNwYenCyYkOti9Gxhpznyw==','EYHI75AEISQ7DQINASRJNSXBRBG6FSAZ','d68402c1-45c1-46d7-8258-942a8924d93a',NULL,0,0,NULL,1,0,NULL,NULL,NULL,NULL,NULL),('user_id','username','USERNAME','user@email.com','USER@EMAIL.COM',NULL,'hashed_password','security_stamp','concurrency_stamp','phone_number',0,0,NULL,0,0,'2024-09-20 21:03:29','2024-09-20 21:03:29',30,'Nuremberg, Germany','John Doe');
/*!40000 ALTER TABLE `AspNetUsers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `CategoriesDBTable`
--

DROP TABLE IF EXISTS `CategoriesDBTable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `CategoriesDBTable` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `propertyName` longtext NOT NULL,
  `propertyType` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `CategoriesDBTable`
--

LOCK TABLES `CategoriesDBTable` WRITE;
/*!40000 ALTER TABLE `CategoriesDBTable` DISABLE KEYS */;
INSERT INTO `CategoriesDBTable` VALUES (1,'rooftop1','bars');
/*!40000 ALTER TABLE `CategoriesDBTable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ListingDBTable`
--

DROP TABLE IF EXISTS `ListingDBTable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ListingDBTable` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ListingName` longtext NOT NULL,
  `ImageUrl` longtext DEFAULT NULL,
  `CategoryId` int(11) NOT NULL DEFAULT 0,
  `LocationId` int(11) NOT NULL DEFAULT 0,
  `ListingProjectsDTOId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ListingDBTable_CategoryId` (`CategoryId`),
  KEY `IX_ListingDBTable_LocationId` (`LocationId`)
) ENGINE=InnoDB AUTO_INCREMENT=88 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ListingDBTable`
--

LOCK TABLES `ListingDBTable` WRITE;
/*!40000 ALTER TABLE `ListingDBTable` DISABLE KEYS */;
INSERT INTO `ListingDBTable` VALUES (5,'Beachfront Villa','http://example.com/villa.jpg',1,1,NULL),(6,'hidden moon building','hiddenmoon',1,1,NULL),(74,'New Listing','http://example.com/new_image.jpg',1,1,NULL);
/*!40000 ALTER TABLE `ListingDBTable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ListingDTO_DBTable`
--

DROP TABLE IF EXISTS `ListingDTO_DBTable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ListingDTO_DBTable` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ListingName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=68 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ListingDTO_DBTable`
--

LOCK TABLES `ListingDTO_DBTable` WRITE;
/*!40000 ALTER TABLE `ListingDTO_DBTable` DISABLE KEYS */;
INSERT INTO `ListingDTO_DBTable` VALUES (3,'palace of hormisdas77777777'),(65,'87878'),(66,'8989ß09'),(67,'john of cappadocia_iamtheAugust');
/*!40000 ALTER TABLE `ListingDTO_DBTable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ListingDtoEdit_DBTable`
--

DROP TABLE IF EXISTS `ListingDtoEdit_DBTable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ListingDtoEdit_DBTable` (
  `ListingIdToBeEdited` int(11) NOT NULL AUTO_INCREMENT,
  `ListingNameToBeEdited` longtext NOT NULL,
  PRIMARY KEY (`ListingIdToBeEdited`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ListingDtoEdit_DBTable`
--

LOCK TABLES `ListingDtoEdit_DBTable` WRITE;
/*!40000 ALTER TABLE `ListingDtoEdit_DBTable` DISABLE KEYS */;
/*!40000 ALTER TABLE `ListingDtoEdit_DBTable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ListingVer2_DBTable`
--

DROP TABLE IF EXISTS `ListingVer2_DBTable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ListingVer2_DBTable` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ListingName` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ListingVer2_DBTable`
--

LOCK TABLES `ListingVer2_DBTable` WRITE;
/*!40000 ALTER TABLE `ListingVer2_DBTable` DISABLE KEYS */;
INSERT INTO `ListingVer2_DBTable` VALUES (2,'Underground Kaymakli'),(3,'Underground Derinkuyu'),(4,'Hieron Estate'),(5,'Daphne Wings');
/*!40000 ALTER TABLE `ListingVer2_DBTable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `LocationDBTable`
--

DROP TABLE IF EXISTS `LocationDBTable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `LocationDBTable` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `City` longtext NOT NULL,
  `State` longtext NOT NULL,
  `PLZ` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `LocationDBTable`
--

LOCK TABLES `LocationDBTable` WRITE;
/*!40000 ALTER TABLE `LocationDBTable` DISABLE KEYS */;
INSERT INTO `LocationDBTable` VALUES (1,'Singapore','Singapore','1293890');
/*!40000 ALTER TABLE `LocationDBTable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PortalUsers`
--

DROP TABLE IF EXISTS `PortalUsers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `PortalUsers` (
  `Name` varchar(256) DEFAULT NULL,
  `Age` varchar(10) DEFAULT NULL,
  `Location` varchar(256) DEFAULT NULL,
  `DisplayInfo` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PortalUsers`
--

LOCK TABLES `PortalUsers` WRITE;
/*!40000 ALTER TABLE `PortalUsers` DISABLE KEYS */;
INSERT INTO `PortalUsers` VALUES ('Alice Smith','30','New York','Name: Alice Smith Age: 30 Location: New York'),('Bob Johnson','25','Los Angeles','Name: Bob Johnson Age: 25 Location: Los Angeles'),('Charlie Brown','35','Chicago','Name: Charlie Brown Age: 35 Location: Chicago');
/*!40000 ALTER TABLE `PortalUsers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('00000000000000_CreateIdentitySchema','7.0.2'),('20240905212650_InitialCreate','7.0.2'),('20240913183405_SecondCreate','7.0.2'),('20240913184741_IdentityTables','7.0.2'),('20240915172209_third','7.0.2'),('20240915173327_fourth','7.0.2'),('20240915174130_fifth','7.0.2'),('20240918195712_MigrationName','7.0.2'),('20240929055616_SeedDataMigration','7.0.2'),('20240929061023_SeedDataMigration2','7.0.2'),('20241013230920_listingMigration','7.0.2'),('20241026234733_hiddenMoonExperiment','7.0.2'),('20241113223440_DTOCreateSecond','7.0.2'),('20241114162841_AddForeignKeyToListingProjectsDTO','7.0.2'),('20241127214311_FixListingProjectsRelationship','7.0.2'),('20241129213822_Normalisierung1','7.0.2'),('20241216212234_CodesFromBook','7.0.2'),('20250109012742_ListingIdIsNotListingIdAnymore','7.0.2'),('20250109020924_InitialCreate','7.0.2'),('20250109021240_InitialCreate2','7.0.2'),('20250118013458_removedRowsOfDbTable','7.0.2'),('20250118013738_removedRowsOfDbTable2','7.0.2'),('20250118014144_initCreate','7.0.2'),('20250131160905_editClass','7.0.2'),('20250131161616_editClassAgain','7.0.2'),('20250131162416_freshInitCreate','7.0.2'),('20250131164249_freshInitCreate7','7.0.2'),('20250206101545_AddShadowPropertyInModel','7.0.2'),('20250315162802_RebumpDBToday1','7.0.2');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-16  9:06:59
