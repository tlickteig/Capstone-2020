/* Check whether the database already exists */
IF EXISTS (SELECT 1 FROM master.dbo.sysdatabases WHERE name= 'PetUniverseDB')
BEGIN
	DROP DATABASE [PetUniverseDB]
	print '' print '*** Dropping PetUniverseDB'
END
GO
print '' print '*** Creating Database'
GO

CREATE DATABASE [PetUniverseDB]
GO

print '' print '*** Using Database'
GO

USE PetUniverseDB
GO

/*
Created by: Zach Behrensmeyer
Date: 2/3/2020
Comment: General user table, this is used for logging in and finding information about that user.
*/
drop table if exists [dbo].[User]

print '' print '*** Create User Table ***'
GO
CREATE TABLE [dbo].[User](
[UserID] [int] NOT NULL Identity(100000, 1) PRIMARY KEY,
[FirstName] [nvarchar](50) NOT NULL,
[LastName] [nvarchar](50) NOT NULL,
[PhoneNumber] [nvarchar](11) NOT NULL,
[Email] [nvarchar](250) NOT NULL,
[PasswordHash] [nvarchar](100) NOT NULL DEFAULT 
'9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E',
[Active] [bit] NOT NULL Default 1,
[City] [nvarchar] (20) NOT NULL,
[State] [nvarchar] (2) NOT NULL,
[Zipcode] [nvarchar] (15) NOT NULL
)
GO

/*
Created by: Zach Behrensmeyer
Date: 2/3/2020
Comment: Inserts some test users
*/
print '' print '*** Insert Into User Table ***'
GO
INSERT INTO [dbo].[User]
([FirstName], 		    
[LastName],
[PhoneNumber],
[Email],
[Active],
[City],
[State],
[Zipcode]
)
VALUES
('Zach', 'Behrensmeyer', '1234567890', 'zbehrens@PetUniverse.com', 1, 'Cedar Rapids', 'IA', '52404'),
('Steven', 'Cardona', '2234567890', 'scardona@PetUniverse.com', 1, 'Cedar Rapids', 'IA', '52404'), 
('Thomas', 'Dupuy', '3234567890', 'tdupuy@PetUniverse.com', 1, 'Cedar Rapids', 'IA', '52404')
GO
print '' print '*** Insert users into User Table ***'
GO


/*
Created by: Steven Cardona
Date: 02/11/2020
Comment: This is used to select all users fron the Users table
*/
print '' print '*** Creating sp_select_all_active_users ***'
GO

CREATE PROCEDURE [sp_select_all_active_users]
AS
BEGIN
	select 
		[UserID],
		[FirstName],
		[LastName],
		[PhoneNumber],
		[Email],
		[City],
		[State],
		[Zipcode]
	FROM [dbo].[User]
	WHERE [Active] = 1
END
GO



/*
Created by: Steven Cardona
Date: 02/06/2020
Comment: This is used to insert a new user into the database 
with all default values used. 
*/
print '' print '*** Create sp_insert_user ***'
GO

CREATE PROCEDURE [sp_insert_user]
(
	@FirstName [nvarchar](50), 		    
	@LastName [nvarchar](50),
	@PhoneNumber [nvarchar](11),
	@Email [nvarchar](250),
	@City [nvarchar](20),
	@State [nvarchar](2),
	@Zipcode [nvarchar](15)
)
AS
Begin
	INSERT INTO [dbo].[User]
		([FirstName], [LastName], [PhoneNumber],[Email],[City],[State],[Zipcode])
	VALUES
		(@FirstName, @LastName, @PhoneNumber, @Email, @City, @State, @Zipcode)
END
GO


/*
Created by: Zach Behrensmeyer
Date: 2/3/2020
Comment: This is used to store the roles of the different users 
such as admin, manager, customer etc.
*/
drop table if exists [dbo].[Role]

print '' print '*** Create Role Table ***'
GO
CREATE TABLE [dbo].[Role](
[RoleID] [nvarchar](50) PRIMARY KEY,
[Description] [nvarchar](250) NOT NULL,
)
GO

/*
Created by: Zach Behrensmeyer
Date: 2/6/2020
Comment: This is used to pair a user with their roles
*/
print '' print '*** Insert Into Role Table ***'
GO
INSERT INTO [dbo].[Role]
([RoleID],  
[Description]
)
VALUES
('Admin', 'User that has elevated privelages'),
('Customer', 'Person who can buys stuff'), 
('Volunteer', 'Person who does volunteer work')
GO
print '' print '*** Insert inactive user into User Table ***'
GO


/*
Created by: Zach Behrensmeyer
Date: 2/3/2020
Comment: This is used to pair a user with their roles
*/
drop table if exists [dbo].[UserRole]

print '' print '*** Create User Role Table ***'
GO
CREATE TABLE [dbo].[UserRole](
[UserID] 		    [int]					 	NOT NULL,
[RoleID] 			[nvarchar] (50) 			NOT NULL,
            	
CONSTRAINT [pk_UserID_RoleID] PRIMARY KEY ([UserID] ASC, [RoleID] ASC),
CONSTRAINT [fk_UserRole_UserID] FOREIGN KEY ([UserID])
REFERENCES [dbo].[User] (UserID),
CONSTRAINT [fk_Role_RoleID] FOREIGN KEY(RoleID) 
REFERENCES Role (RoleID) ON UPDATE CASCADE
)
GO

--Create test user roles
/*
Created by: Zach Behrensmeyer
Date: 2/6/2020
Comment: This is used to pair a user with their roles
*/
print '' print '*** Insert Into User Role Table ***'
GO
INSERT INTO [dbo].[UserRole]
([UserID],  
[RoleID]
)
VALUES
(100000, 'Admin'),
(100001, 'Customer'), 
(100002, 'Volunteer')
GO

/*
Created by: Zach Behrensmeyer
Date: 2/5/2020
Comment: This is used to store the roles of the different users 
such as admin, manager, customer etc.
*/
drop table if exists [dbo].[Department]

print '' print '*** Create Department Table ***'
GO
CREATE TABLE [dbo].[Department](
DepartmentID 				[int] 		PRIMARY KEY,
DepartmentRoleDescription	[nvarchar](250) NULL	
)
GO

/*
Created by: Zach Behrensmeyer
Date: 2/8/2020
Comment: This is used to store logs from the program
*/
drop table if exists [dbo].[Logging]

print '' print '*** Creating logging table'
CREATE TABLE [dbo].[Logging](  
    [Id] [int] IDENTITY(1,1) NOT NULL,  
    [Date] [datetime] NOT NULL,  
    [Thread] [varchar](255) NOT NULL,  
    [Level] [varchar](50) NOT NULL,  
    [Logger] [varchar](255) NOT NULL,  
    [Message] [varchar](4000) NOT NULL,  
    [Exception] [varchar](2000) NULL,  
)
GO



/*
Created by: Zach Behrensmeyer
Date: 2/6/2020
Comment: Sproc to authenticate user
*/
print '' print '*** Creating sp_authenticate_user'
GO
CREATE PROCEDURE [sp_authenticate_user]
(
@Email 			[nvarchar](250),
@PasswordHash	[nvarchar](100)				
)
AS
BEGIN
SELECT COUNT([UserID])
FROM 	[dbo].[User]
WHERE 	[Email] = @Email
AND 	[PasswordHash] = @PasswordHash
AND 	[Active] = 1
END
GO
;

/*
Created by: Zach Behrensmeyer
Date: 2/6/2020
Comment: Sproc to find user by email
*/
print '' print '*** Creating sp_select_user_by_email'
GO
CREATE PROCEDURE [sp_select_user_by_email]
(
	@Email 			[nvarchar](250)
)
AS
BEGIN
	SELECT 	[UserID], [FirstName], [LastName], [PhoneNumber]
	FROM 	[dbo].[User]
	WHERE 	[Email] = @Email
END
GO

/*
Created by: Zach Behrensmeyer
Date: 2/6/2020
Comment: Sproc to select roles of employee
*/
print '' print '*** Creating sp_select_roles_by_userID'
GO
CREATE PROCEDURE [sp_select_roles_by_userID]
(
	@UserID 			[int]
)
AS
BEGIN
	SELECT 	[RoleID]
	FROM 	[dbo].[UserRole]
	WHERE 	[UserID] = @UserID
END
GO


/*
Created by: Zach Behrensmeyer
Date: 2/11/2020
Comment: Sproc to pull list of login logs
*/
print '' print '*** sp_get_login_logout_logs'
GO
CREATE PROCEDURE [sp_get_login_logout_logs]
AS
BEGIN
	SELECT 	[Id], [Date], [Level], [Message]            
	FROM Logging
	where message like '%Successfully logged in%' or message like '%Someone failed to login using email%' or message like '%has logged out%'
END
GO

