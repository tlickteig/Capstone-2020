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


drop table if exists [dbo].[AnimalSpecies]

print '' print '*** Creating table AnimalSpecies'
GO

/*
Created by: Chuck Baxter
Date: 2/8/2020
Comment: Place Holder for animal species
*/
CREATE TABLE [dbo].[AnimalSpecies](
	[AnimalSpeciesID]	[nvarchar](100)				NOT NULL,
	CONSTRAINT [pk_AnimalSpeciesID] PRIMARY KEY([AnimalSpeciesID] ASC)
)
GO

print '' print '*** Creating sample AnimalSpecies records'
GO

/*
Created by: Chuck Baxter
Date: 2/8/2020
Comment: Sample Data
*/
INSERT INTO [dbo].[AnimalSpecies]
	([AnimalSpeciesID])
	VALUES
	('A'),
	('B'),
	('C'),
	('D')
GO

print '' print '*** Creating table Status'
GO

/*
Created by: Chuck Baxter
Date: 2/8/2020
Comment: PlaceHolder Status table
*/
CREATE TABLE [dbo].[Status](
	[StatusID]			[nvarchar](100)				NOT NULL,
	CONSTRAINT [pk_StatusID] PRIMARY KEY([StatusID] ASC)
)
GO

print '' print '*** Creating sample Status records'
GO

/*
Created by: Chuck Baxter
Date: 2/8/2020
Comment: Sample Data
*/
INSERT INTO [dbo].[Status]
	([StatusID])
	VALUES
	('A'),
	('B'),
	('C'),
	('D')
GO

print '' print '*** Creating table Animal'
GO

/*
Created by: Chuck Baxter
Date: 2/8/2020
Comment: Actual Animal Table
*/
CREATE TABLE [dbo].[Animal](
	[AnimalID]			[int]IDENTITY(1000000,1)	NOT NULL,
	[AnimalName]		[nvarchar](100)				NOT NULL,
	[Dob]				[date]						NULL,
	[AnimalBreed]		[nvarchar](100)				NOT NULL,
	[ArrivalDate]		[date]						NOT NULL,
	[ImageLocation]		[nvarchar](100)				NULL,
	[CurrentlyHoused]	[bit]						NOT NULL 	DEFAULT 0,
	[Adoptable]			[bit]						NOT NULL	DEFAULT 0,
	[Active]			[bit]						NOT NULL	DEFAULT 1,
	[AnimalSpeciesID]	[nvarchar](100)				NOT NULL,
	[StatusID]			[nvarchar](100)				NOT NULL,
	CONSTRAINT [pk_AnimalID] PRIMARY KEY([AnimalID] ASC),
	CONSTRAINT [fk_Animal_AnimalSpeciesID] FOREIGN KEY([AnimalSpeciesID])
		REFERENCES [AnimalSpecies]([AnimalSpeciesID]),
	CONSTRAINT [fk_Animal_StatusID] FOREIGN KEY([StatusID])
		REFERENCES [Status]([StatusID])
)
GO

--Chuck Baxter
print '' print '*** Creating sample Animal records'
GO

/*
Created by: Chuck Baxter
Date: 2/8/2020
Comment: Sample Animal Data
*/

INSERT INTO [dbo].[Animal]
	([AnimalName],[Dob],[AnimalBreed],[ArrivalDate],[ImageLocation],[CurrentlyHoused],[Adoptable],[Active],[AnimalSpeciesID],[StatusID])
	VALUES
	('Paul','12-01-2015','Pit Bull','01-20-2020','ImageLocation1',1,1,1,'A','A'),
	('Snowball II','10-05-2011','Tabby','11-24-2019','ImageLocation2',0,0,1,'B','C'),
	('Lassie','04-23-2018','Collie','01-12-2020','ImageLocation3',1,1,1,'C','A'),
	('Spot','08-14-2014','French Bulldog','05-10-2019','ImageLocation4',1,1,1,'D','A'),
	('fluffs','06-21-2012','Siamese','04-11-2019','ImageLocation5',0,1,1,'C','B'),
	('Doggo','03-06-2015','Shih Tzu','02-22-2019','ImageLocation6',1,1,0,'D','A')
GO


print '' print '*** Creating AnimalKennel Table'
GO
/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses location number and access dates
*/
CREATE TABLE [dbo].[AnimalKennel] (

	[AnimalKennelID]		[int] IDENTITY(1000000,1) NOT NULL,
	[AnimalID]				[int]					  NOT NULL,
	[UserID]				[int]                     NOT NULL,
	[AnimalKennelInfo]		[nvarchar](4000)                  ,
	[AnimalKennelDateIn]	[date]                    NOT NULL,
	[AnimalKennelDateOut]	[date]                    

	CONSTRAINT [pk_AnimalKennelID] PRIMARY KEY([AnimalKennelID] ASC),

	CONSTRAINT [fk_Animal_AnimalID] FOREIGN KEY([AnimalID])
		REFERENCES [Animal]([AnimalID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_AnimalKennel_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_AnimalKennelID] UNIQUE([AnimalKennelID] ASC)
)

print '' print '*** Creating AnimalVetAppointment Table'

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Vet appointments
*/
GO
CREATE TABLE [dbo].[AnimalVetAppointment] (

	[AnimalVetAppointmentID]	[int] IDENTITY(1000000,1)			NOT NULL,
	[AnimalID]					[int]								NOT NULL,
	[UserID]					[int]								NOT NULL,
	[AppointmentDate]			[date]								NOT NULL,
	[AppointmentTime]			[time],	
	[AppointmentDescription]	[nvarchar](4000),
	[ClinicAddress]				[nvarchar](200),
	[VetName]					[nvarchar](200),
	[FollowUpDate]				[date],
	[FollowUptime]				[time]	

	CONSTRAINT [pk_AnimalVetAppointmentID] PRIMARY KEY([AnimalVetAppointmentID] ASC),

	CONSTRAINT [fk_Animal_AnimalID__] FOREIGN KEY([AnimalID])
		REFERENCES [Animal]([AnimalID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_AnimalVetAppointment_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_AnimalVetAppointmentID] UNIQUE([AnimalVetAppointmentID] ASC)
)

print '' print '*** Creating AnimalHandlingNotes Table'

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Handling notes for animals
*/
GO
CREATE TABLE [dbo].[AnimalHandlingNotes] (

	[AnimalHandlingNotesID]	[int] IDENTITY(1000000,1) NOT NULL,
	[AnimalID]				[int]					  NOT NULL,
	[UserID]				[int]					  NOT NULL,
	[AnimalHandlingNotes]	[nvarchar](4000)		  NOT NULL,
	[TempermantWarning]		[nvarchar](1000)		  NOT NULL,
	[UpdateDate]			[date]					  NOT NULL

	CONSTRAINT [pk_AnimalHandlingNotesID] PRIMARY KEY([AnimalHandlingNotesID] ASC),

	CONSTRAINT [fk_Animal_AnimalID_] FOREIGN KEY([AnimalID])
		REFERENCES [Animal]([AnimalID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_AnimalHandlingNotes_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_AnimalHandlingNotesID] UNIQUE([AnimalHandlingNotesID] ASC)
)

print '' print '*** Creating AnimalMedicalInfo Table'

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Animal Medical Information
*/
GO
CREATE TABLE [dbo].[AnimalMedicalInfo] (

	[AnimalMedicalInfoID]		[int] IDENTITY(1000000,1)  NOT NULL,
	[AnimalID]					[int]					   NOT NULL,
	[UserID]					[int]					   NOT NULL,
	[Spayed/Neutered]			[bit]					   NOT NULL,
	[Vaccinations]				[nvarchar](250)			   NOT NULL,
	[MostRecentVaccinationDate]	[Date]					   NOT NULL,
	[AdditionalNotes]			[nvarchar](500)

	CONSTRAINT [pk_AnimalMedicalInfoID] PRIMARY KEY([AnimalMedicalInfoID] ASC),

	CONSTRAINT [fk_Animal_AnimalID#] FOREIGN KEY([AnimalID])
		REFERENCES [Animal]([AnimalID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_AnimalMedicalInfo_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_AnimalMedicalInfoID] UNIQUE([AnimalMedicalInfoID] ASC)
)

print '' print '*** Creating AnimalPrescriptions Table'

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Animal Prescription Information
*/
GO
CREATE TABLE [dbo].[AnimalPrescriptions] (

	[AnimalPrescriptionsID]   	[int] IDENTITY(1000000,1)	NOT NULL,
	[AnimalVetAppointmentID] 	[int]						NOT NULL,
	[PrescriptionName]			[nvarchar](50)				NOT NULL,
	[Dosage]					[decimal]					NOT NULL,
	[Interval]					[nvarchar](250)				NOT NULL,
	[AdministrationMethod]		[nvarchar](100)				NOT NULL,
	[StartDate]					[Date]						NOT NULL,
	[EndDate]					[Date]						NOT NULL,
	[Description]				[nvarchar](500)				

	CONSTRAINT [pk_AnimalPrescriptionsID] PRIMARY KEY([AnimalPrescriptionsID] ASC),

	CONSTRAINT [fk_AnimalVetAppointment_AnimalVetAppointmentID] FOREIGN KEY([AnimalVetAppointmentID])
		REFERENCES [Animal]([AnimalID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_AnimalPrescriptionsID] UNIQUE([AnimalPrescriptionsID] ASC)


)

print '' print '*** Creating FacilityMaintenance Table'

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Facility Maintenance Information
*/
GO
CREATE TABLE [dbo].[FacilityMaintenance] (

	[FacilityMaintenanceID]		[int] IDENTITY(1000000,1)	NOT NULL,
	[UserID]					[int]						NOT NULL,
	[MaintenanceName]			[nvarchar](50)				NOT NULL,
	[MaintenanceInterval]		[nvarchar](20)				NOT NULL,
	[MaintenanceDescription]	[nvarchar](250)				NOT NULL

	CONSTRAINT [pk_FacilityMaintenanceID] PRIMARY KEY([FacilityMaintenanceID] ASC),

	CONSTRAINT [fk_User_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_FacilityMaintenanceID] UNIQUE([FacilityMaintenanceID] ASC)


)

print '' print '*** Creating FacilityWork Table'

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Facility Work Information
*/
GO
CREATE TABLE [dbo].[FacilityWork] (

	[FacilityWorkID]		[int] IDENTITY(1000000,1) NOT NULL,
	[UserID]				[int]					  NOT NULL,
	[WorkerUserID]	    	[int]				      NOT NULL,
	[FacilityMaintenanceID]	[int]					  NOT NULL,
	[AssignmentDate]		[date]					  NOT NULL,
	[CompletionDate]		[date]					  NOT NULL,
	[CompletionTime]		[date]					  NOT NULL,
	[CompletionNotes]		[nvarchar](250)			  NOT NULL

	CONSTRAINT [pk_FacilityWorkID] PRIMARY KEY([FacilityWorkID] ASC),

	CONSTRAINT [fk_FacilityWork_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_FacilityWork_FacilityMaintenanceID] FOREIGN KEY([FacilityMaintenanceID])
		REFERENCES [FacilityMaintenance]([FacilityMaintenanceID]),

	CONSTRAINT [ak_FacilityWorkID] UNIQUE([FacilityWorkID] ASC)


)

print '' print '*** Creating FacilityKennelCleaning Table'

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Kennel Cleaning Information
*/
GO
CREATE TABLE [dbo].[FacilityKennelCleaning] (

	[FacilityKennelCleaningID]	[int] IDENTITY(1000000,1)	NOT NULL,
	[UserID]					[int]						NOT NULL,
	[AnimalKennelID]			[int]						NOT NULL,
	[Date]						[date]						NOT NULL,
	[Notes]						[nvarchar](250)

	CONSTRAINT [pk_FacilityKennelCleaningID] PRIMARY KEY([FacilityKennelCleaningID] ASC),

	CONSTRAINT [fk_FacilityKennelCleaning_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_FacilityKennelCleaning_AnimalKennelID] FOREIGN KEY([AnimalKennelID])
		REFERENCES [AnimalKennel]([AnimalKennelID])


)

print '' print '*** Creating AnimalActivityType Table'

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Animal Activity
*/
GO
CREATE TABLE [dbo].[AnimalActivityType] (
	[AnimalActivityTypeID]	[nvarchar](100)				 	NOT NULL,
	[ActivityNotes]			[nvarchar](MAX) 			
	
	CONSTRAINT [pk_AnimalActivityTypeID] PRIMARY KEY([AnimalActivityTypeID] ASC),
	
	CONSTRAINT [ak_AnimalActivityTypeID] UNIQUE([AnimalActivityTypeID] ASC)
)

print '' print '*** Creating AnimalActivity Table'

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Animal Activity
*/
GO
CREATE TABLE [dbo].[AnimalActivity] (

[AnimalActivityID] 	    [int] IDENTITY(1000000,1)	NOT NULL,
[AnimalID]		        [int]						NOT NULL,
[UserID]			    [int]						NOT NULL,
[AnimalActivityTypeID]  [nvarchar](100)				NOT NULL,
[ActivityDateTime]      [DateTime]   				NOT NULL,
				
	
	CONSTRAINT [pk_AnimalActivityID] PRIMARY KEY([AnimalActivityID] ASC),
	
	CONSTRAINT [fk_AnimalActivity_AnimalID] FOREIGN KEY([AnimalID])
		REFERENCES [Animal]([AnimalID]) ON UPDATE CASCADE,
		
	CONSTRAINT [fk_AnimalActivity_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,
		
	CONSTRAINT [fk_AnimalActivityType_AnimalActivityTypeID] FOREIGN KEY([AnimalActivityTypeID])
		REFERENCES [AnimalActivityType]([AnimalActivityTypeID]) ON UPDATE CASCADE,
		
	CONSTRAINT [ak_AnimalActivityID] UNIQUE([AnimalActivityTypeID] ASC)	
)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Sample Data for AnimalActivityType
*/
print '' print '*** Creating sample AnimalActivityType records'
GO

INSERT INTO [dbo].[AnimalActivityType]
	  ([AnimalActivityTypeID],[ActivityNotes])
VALUES
	
	('Feeding','Feed the Animals')

	SET IDENTITY_INSERT AnimalActivity ON
GO


/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Sample Data for AnimalActivity Records
*/
print '' print '*** Creating sample AnimalActivity records'
GO

INSERT INTO [dbo].[AnimalActivity]
	 ([AnimalActivityID],[AnimalID],[AnimalActivityTypeID],[ActivityDateTime],[UserID])
VALUES
	
(1, 1000000,'Feeding', 2020-2-2, 100000)
	SET IDENTITY_INSERT AnimalActivity OFF
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

/*
Created by: Daulton Schilling
Date: 2/11/2020
Comment: Sproc to pull list of animal feeding records
*/
print '' print '*** sp_Select_Animal_Feeding_Records'
GO
CREATE PROCEDURE [sp_Select_Animal_Feeding_Records]
AS
BEGIN
SELECT 
[AnimalActivityID],
[AnimalID],
[UserID],
[AnimalActivityTypeID],
[ActivityDateTime]

From [AnimalActivity]
END;

/*
Created by: Daulton Schilling
Date: 2/11/2020
Comment: Sproc to select specific animal by ud
*/
print '' print '*** sp_Select_Animal_By_AnimalID'
GO
CREATE PROCEDURE [sp_Select_Animal_By_AnimalID]
(
  @AnimalID [int]
)
AS
BEGIN
SELECT 
[AnimalID]

From [Animal] 
WHERE[AnimalID] = @AnimalID
END;

SET IDENTITY_INSERT AnimalActivity ON

/*
Created by: Daulton Schilling
Date: 2/11/2020
Comment: Sproc to insert Animal Activity
*/
print '' print '*** sp_insert_AnimalActivity'
GO
CREATE PROCEDURE [sp_insert_AnimalActivity]
(
	@AnimalActivityID	    [int]			   ,
	@AnimalID	        	[int]			   ,
	@UserID		    		[int]			   ,
	@AnimalActivityTypeID  	[nvarchar](100)	   ,
	@ActivityDateTime   	[DateTime]   	   
				
)
AS
BEGIN
	INSERT INTO [dbo].[AnimalActivity]
		([AnimalActivityID],[AnimalID],[AnimalActivityTypeID],[ActivityDateTime])
	VALUES
		(@AnimalActivityID,@AnimalID,@AnimalActivityTypeID,@ActivityDateTime)
	RETURN SCOPE_IDENTITY()
END;
SET IDENTITY_INSERT AnimalActivity OFF

/*
Created by: Daulton Schilling
Date: 2/11/2020
Comment: Sproc to insert Animal Activity type
*/
print '' print '*** sp_insert_AnimalActivityType'
GO
CREATE PROCEDURE [sp_insert_AnimalActivityType]
(
	@AnimalActivityTypeID			[nvarchar](200),
	@ActivityNotes			        [nvarchar](MAX)
				
)
AS
BEGIN
	INSERT INTO [dbo].[AnimalActivityType]
		([AnimalActivityTypeID],[ActivityNotes])
	VALUES
		(@AnimalActivityTypeID ,@ActivityNotes)
	RETURN SCOPE_IDENTITY()
END;
GO


/*
Created by: Chuck Baxter
Date: 2/11/2020
Comment: Sproc to insert Animal
*/
print '' print'*** Creating sp_insert_animal'
GO

CREATE PROCEDURE [sp_insert_animal]
(
	@AnimalName			[nvarchar](100),
	@Dob				[nvarchar](100),
	@AnimalBreed		[nvarchar](100),
	@ArrivalDate		[nvarchar](100),
	@ImageLocation		[nvarchar](100),
	@AnimalSpeciesID	[nvarchar](100),
	@StatusID			[nvarchar](100)
)
AS
BEGIN
	INSERT INTO [dbo].[Animal]
		([AnimalName],[Dob],[AnimalBreed],[ArrivalDate],[ImageLocation],[AnimalSpeciesID],[StatusID])
	VALUES
		(@AnimalName, @Dob, @AnimalBreed, @ArrivalDate, @ImageLocation, @AnimalSpeciesID, @StatusID)
	RETURN SCOPE_IDENTITY()
END
GO

/*
Created by: Chuck Baxter
Date: 2/11/2020
Comment: Sproc to select active animals
*/
print '' print '*** Creating sp_select_active_animals'
GO
CREATE PROCEDURE [sp_select_active_animals]
(
	@Active		[bit]
)
AS
BEGIN
	SELECT [AnimalID],[AnimalName],[Dob],[AnimalBreed],[ArrivalDate],[ImageLocation],
	[CurrentlyHoused],[Adoptable],[Active],[AnimalSpeciesID],[StatusID]
	FROM [dbo].[Animal]
	WHERE [Active] = @Active
	ORDER BY [AnimalID]
END
GO

/*
Created by: Carl Davis
Date: 2/11/2020
Comment: Sproc to insert facility maintenance
*/
print '' print '*** Creating sp_insert_facility_maintenance'
GO
CREATE PROCEDURE [sp_insert_facility_maintenance]
(
    @UserID                        	[int],
    @MaintenanceName            	[nvarchar](50),
    @MaintenanceInterval         	[nvarchar](20),
    @MaintenanceDescription     	[nvarchar](250)
)
AS
BEGIN
    INSERT INTO [dbo].[FacilityMaintenance]
        ([UserID], [MaintenanceName], [MaintenanceInterval], [MaintenanceDescription])
    VALUES
        (@UserID, @MaintenanceName, @MaintenanceInterval, @MaintenanceDescription)
    RETURN SCOPE_IDENTITY()

END
GO

/*
Created by: Ethan Murphy
Date: 2/11/2020
Comment: Sproc to Select all vet appointments
*/
print '' print '*** Creating sp_select_all_vet_appointments'
GO
CREATE PROCEDURE [sp_select_all_vet_appointments]
AS
BEGIN
    SELECT [AnimalVetAppointmentID], [Animal].[AnimalID], [AnimalName],
            [AppointmentDate], [AppointmentDescription],
            [ClinicAddress], [VetName], [FollowUpDate]
    FROM [AnimalVetAppointment] INNER JOIN [Animal]
    ON [AnimalVetAppointment].[AnimalID] = [Animal].[AnimalID]
    ORDER BY [AppointmentDate]
END
GO

/*
Created by: Ben Hanna
Date: 2/11/2020
Comment: Sproc to deactivate an animal
*/
print '' print '*** Creating sp_deactivate_animal'
GO
CREATE PROCEDURE [sp_deactivate_animal]
(
    @AnimalID			 [int]
)
AS
BEGIN
	UPDATE [dbo].[Animal]
    SET [Active] = 0
    WHERE [AnimalID] = @AnimalID
    
    RETURN @@ROWCOUNT
END 
GO

/*
Created by: Ben Hanna
Date: 2/11/2020
Comment: Sproc to reactivate an animal
*/
print '' print '*** Creating sp_reactivate_animal'
GO
CREATE PROCEDURE [sp_reactivate_animal]
(
    @AnimalID			 [int]
)
AS
BEGIN
	UPDATE [dbo].[Animal]
    SET [Active] = 1
    WHERE [AnimalID] = @AnimalID
    
    RETURN @@ROWCOUNT
END 
GO

/*
Created by: Ben Hanna
Date: 2/11/2020
Comment: Sproc to deahouse animal
*/
print '' print '*** Creating sp_dehouse_animal'
GO
CREATE PROCEDURE [sp_dehouse_animal]
(
    @AnimalID			 [int]
)
AS
BEGIN
	UPDATE [dbo].[Animal]
    SET [CurrentlyHoused] = 0
    WHERE [AnimalID] = @AnimalID
    
    RETURN @@ROWCOUNT
END 
GO

/*
Created by: Ben Hanna
Date: 2/11/2020
Comment: Sproc to house an animal
*/
print '' print '*** Creating sp_house_animal'
GO
CREATE PROCEDURE [sp_house_animal]
(
    @AnimalID			 [int]
)
AS
BEGIN
	UPDATE [dbo].[Animal]
    SET [CurrentlyHoused] = 1
    WHERE [AnimalID] = @AnimalID
    
    RETURN @@ROWCOUNT
END 
GO

/*
Created by: Ben Hanna
Date: 2/11/2020
Comment: Sproc to deset an active animal
*/
print '' print '*** Creating sp_deset_animal_adoptable'
GO
CREATE PROCEDURE [sp_deset_animal_adoptable]
(
    @AnimalID			 [int]
)
AS
BEGIN
	UPDATE [dbo].[Animal]
    SET [Adoptable] = 0
    WHERE [AnimalID] = @AnimalID
    
    RETURN @@ROWCOUNT
END 
GO

/*
Created by: Ben Hanna
Date: 2/11/2020
Comment: Sproc to set an deset animal
*/
print '' print '*** Creating sp_set_animal_adoptable'
GO
CREATE PROCEDURE [sp_set_animal_adoptable]
(
    @AnimalID			 [int]
)
AS
BEGIN
	UPDATE [dbo].[Animal]
    SET [Adoptable] = 1
    WHERE [AnimalID] = @AnimalID
    
    RETURN @@ROWCOUNT
END 
GO

/*
 * Created by: Jordan Lindo
 * Date: 2/5/2020
 * Comment: This is the table for department information.
 */
print '' print '*** Creating Table Department'
GO

CREATE TABLE [dbo].[department]
(
	 [DepartmentID]			[nvarchar](50)		NOT NULL
	,[Description]			[nvarchar](200)		NULL
	DEFAULT NULL
	,CONSTRAINT 			[pk_departmentID]	PRIMARY KEY ([DepartmentID]ASC)

)
GO

print '' print '*** Creating sample Department records'
GO

/*
 * Created by: Jordan Lindo
 * Date: 2/5/2020
 * Comment: This is Sample data for the department table.
 */

INSERT INTO [dbo].[department]
([DepartmentID],[Description])
VALUES
 ('Fake1','A Description')
,('Fake2','Another Description')
,('Fake3','Yet Another Description')
,('Fake4',NULL)


print '' print '*** Create procedure sp_insert_department'
GO

/*
 * Created by: Jordan Lindo
 * Date: 2/5/2020
 * Comment: This is a stored procedure for inserting new departments into the 
 * department table.
 */
CREATE PROCEDURE [sp_insert_department]
(
	 @DepartmentID			[nvarchar](50)
	,@Description			[nvarchar](200)
)
AS
BEGIN
	INSERT INTO [dbo].[department]
	([DepartmentID],[Description])
	VALUES
	(@DepartmentID,@Description)
END
GO

print '' print '*** Create procedure sp_select_all_departments'
GO

/*
 * Created by: Jordan Lindo
 * Date: 2/5/2020
 * Comment: This is a stored procedure for selecting all department records.
 */
CREATE PROCEDURE [sp_select_all_departments]
AS
BEGIN
	SELECT [DepartmentID],[Description]
	FROM [Department]
END
GO

print '' print '*** Create procedure sp_select_department_by_id'
GO

/*
 * Created by: Jordan Lindo
 * Date: 2/5/2020
 * Comment: This is a stored procedure for selecting all records with a departmentID
 * matching the input.
 */
CREATE PROCEDURE [sp_select_department_by_id]
(
	 @DepartmentID			[nvarchar](50)
)
AS
BEGIN
	SELECT [DepartmentID],[Description]
	FROM [Department]
	WHERE [DepartmentID] = @DepartmentID
END
GO


print '' print '*** Create procedure sp_update_department'
GO


/*
 * Created by: Jordan Lindo
 * Date: 2/15/2020
 * Comment: This is a stored procedure for updating a department record.
 */
CREATE PROCEDURE [sp_update_department]
(
	 @DepartmentID			[nvarchar](50)
	,@NewDescription		[nvarchar](200)
)
AS
BEGIN
	UPDATE [dbo].[department]
	SET [Description] = @NewDescription
	WHERE [DepartmentID] = @DepartmentID
	RETURN @@ROWCOUNT
END
GO
	





/*
ShiftTime table shows timeframe and which dept.

Author: Lane Sandburg 
2/5/2020

*/
print '' print '*** creating table ShiftTime'
GO
CREATE TABLE [dbo].[ShiftTime](
	[ShiftTimeID]	[int]IDENTITY(1000000,1)	NOT NULL,
	[DepartmentID]  [NVARCHAR](50)				NOT NULL,
	[StartTime]		[NVARCHAR](20) 					NOT NULL,
	[EndTime]		[NVARCHAR](20) 					NOT NULL,
	
	
	CONSTRAINT [pk_ShiftTime_ShiftTimeID] 
		PRIMARY KEY([ShiftTimeID] ASC),
	CONSTRAINT [fk_ShiftTime_DepartmentID] FOREIGN KEY([DepartmentID])
		REFERENCES [Department]([DepartmentID]) ON UPDATE CASCADE
)
GO

/*
Sample ShiftTime Data

Author: Lane Sandburg 
2/5/2020

*/
print '' print '*** creating sample ShiftTime records'
GO
INSERT INTO [dbo].[ShiftTime]
([DepartmentID],[StartTime],[EndTime])
VALUES
("Fake1","14:00:00","22:00:00"),
("Fake2","08:45:00","17:45:00"),
("Fake3","14:00:00","22:00:00"),
("Fake4","08:45:00","17:45:00")
GO

/*
Sproc for inserting a shift time

Author: Lane Sandburg 
2/5/2020

*/
print '' print '*** creating sp_insert_ShiftTime'
GO
CREATE PROCEDURE [sp_insert_ShiftTime](
	@DepartmentID [NVARCHAR](50),
	@StartTime[TIME](0),
	@EndTime[TIME](0)	
)
AS
BEGIN
	INSERT INTO [dbo].[ShiftTime]
		([DepartmentID],[StartTime],[EndTime])
		VALUES
		(@DepartmentID,@StartTime,@EndTime)
		RETURN SCOPE_IDENTITY()
	
END
GO

/*
Sproc for Retreiveing Departments

Author: Lane Sandburg 
2/5/2020

*/
print '' print '*** creating sp_select_all_ShiftTimes'
GO
CREATE PROCEDURE [sp_select_all_ShiftTimes]
AS
BEGIN
	SELECT [ShiftTimeID],[DepartmentID],[StartTime],[EndTime]
	FROM [dbo].[ShiftTime]
	ORDER BY [DepartmentID]
END
GO


/*
Sproc for Retreiveing Departments

Author: Lane Sandburg 
2/13/2020

*/
print '' print '*** creating sp_update_shiftTime'
GO
CREATE PROCEDURE [sp_update_shiftTime](
	@ShiftTimeID [int],
	
	@NewDepartmentID  	[nvarchar](50),
	@NewStartTime		[TIME](0),
	@NewEndTime			[TIME](0),
	
	    
	@OldDepartmentID  	[nvarchar](50),
	@OldStartTime		[TIME](0),
	@OldEndTime			[TIME](0)
)
AS
BEGIN
	UPDATE [dbo].[ShiftTime]
		SET [DepartmentID] = @NewDepartmentID,
			[StartTime] = @NewStartTime,
			[EndTime] = @NewEndTime
			
		WHERE [ShiftTimeID] = @ShiftTimeID
		AND	[DepartmentID] = @OldDepartmentID
		AND [StartTime] = @OldStartTime
		AND[EndTime] = @OldEndTime
				
		RETURN @@ROWCOUNT
END
GO


/*
Created by: Mohamed Elamin
Date: 2/3/2020
Comment: Customer table.
*/
drop table if exists [dbo].[Customer]
print '' print '*** Creating Customer Table'
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID]					[int]	IDENTITY(100000,1)		NOT NULL,
	[UserID]						[int]							NOT NULL,
	CONSTRAINT [pk_CustomerID] PRIMARY KEY([CustomerID]),
	CONSTRAINT [fk_Customer_User_UserID] FOREIGN KEY ([UserID])
		REFERENCES [User]([UserID])
)
GO

/*
Created by: Mohamed Elamin
Date: 02/19/2020
Comment: This is used to insert Sample Customer into the database 
*/
print '' print '*** Creating Sample Customer Records'
GO
INSERT INTO [dbo].[Customer]
	([UserID])
	VALUES
	(100000)	
GO

/*
Created by: Mohamed Elamin
Date: 2/3/2020
Comment: AdoptionApplication table.
*/
drop table if exists [dbo].[AdoptionApplication]
print '' print '*** Creating AdoptionApplication Table'
GO
CREATE TABLE [dbo].[AdoptionApplication](
	[AdoptionApplicationID]		[int]	IDENTITY(100000,1)		NOT NULL,
	[CustomerID]				[int]							NOT NULL,
	[AnimalID]					[int]									,
	[Status]					[nvarchar]	(1000)						,
	[RecievedDate]				[datetime]						NOT NULL,
	CONSTRAINT [pk_AdoptionApplicationID] PRIMARY KEY ([AdoptionApplicationID]),
	CONSTRAINT [fk_AdoptionApplication_Customer_CustomerID] FOREIGN KEY ([CustomerID])
		REFERENCES [Customer]([CustomerID]),
	CONSTRAINT [fk_AdoptionApplication_Animal_AnimalID] FOREIGN KEY ([AnimalID])
		REFERENCES [Animal]([AnimalID])
)
GO

/*
Created by: Mohamed Elamin
Date: 02/19/2020
Comment: This is used to insert Sample AdoptionApplication into the database 
*/
print '' print '*** Creating Sample AdoptionApplication Records'
GO
INSERT INTO [dbo].[AdoptionApplication]
	([CustomerID],[AnimalID],[Status],[RecievedDate])
	VALUES
	(100000,1000000,"InHomeInspection","2019-10-9")
GO

/*
Created by: Mohamed Elamin
Date: 2/2/2020
Comment: Sproc to pull list of Adoption Applications which their status
is inHomeInspection.
*/
print '' print '*** Creating sp_select_AdoptionApplication_by_Status'
GO
CREATE PROCEDURE [sp_select_AdoptionApplication_by_Status]	
AS
BEGIN
	SELECT 	AdoptionApplicationID,AnimalID,CustomerID,Status,RecievedDate
	FROM 	[dbo].[AdoptionApplication]
	WHERE	[Status] = "InHomeInspection"
END
GO

/*
Created by: Mohamed Elamin
Date: 2/2/2020
Comment: Sproc to find animal name from Animal table
by animal ID.
*/
print '' print '*** Creating sp_select_AnimalName_by_AnimalID'
GO
CREATE PROCEDURE [sp_select_AnimalName_by_AnimalID]
(
	@AnimalID 		[int]
)
AS
BEGIN
	SELECT 	[AnimalName]
	FROM 	[dbo].[Animal]
	WHERE	[AnimalID] = @AnimalID 
END
GO


/*
Created by: Mohamed Elamin
Date: 2/2/2020
Comment: Sproc to find Customer name by Customer ID from the User Table.
*/
print '' print '*** Creating sp_select_CustomerName_by_CustomerID'
GO
CREATE PROCEDURE [sp_select_CustomerName_by_CustomerID]
(
	@CustomerID 		[int]	
)
AS
BEGIN
	SELECT 	firstName,lastName
	FROM 	[dbo].[User]
	JOIN [Customer] ON [Customer].[UserID] = [User].[USERID]
	WHERE	[Customer].[CustomerID] = @CustomerID 
END
GO



/*
Created by: Thomas Dupuy
Date: 2/6/2020
Comment: Creats AppointmentType Table
*/
print '' print '*** Creating AppointmentType Table'
GO
CREATE TABLE [dbo].[AppointmentType](
	[AppointmentTypeID] 	[nvarchar](150) 				NOT NULL,
	[Description]			[nvarchar](250) 					NULL,
	CONSTRAINT [pk_AppointmentTypeID] PRIMARY KEY([AppointmentTypeID] ASC)
)
GO


/*
Created by: Thomas Dupuy
Date: 2/6/2020
Comment: Creats Appointment Table
*/
print '' print '*** Creating Appointment Table'
GO
CREATE TABLE [dbo].[Appointment](
	[AppointmentID] 		[int] IDENTITY(1000,1)			NOT NULL,
	[AdoptionApplicationID]	[int]							NOT NULL,
	[AppointmentTypeID] 	[nvarchar](150) 				NOT NULL,
	[DateTime] 				[smalldatetime]					NOT NULL,
	[Notes] 				[nvarchar](1000) 					NULL,
	[Decicion] 				[nvarchar](50) 						NULL,
	[Location] 				[nvarchar](100) 				NOT NULL,
	CONSTRAINT [pk_AppointmentID] PRIMARY KEY([AppointmentID] ASC)
)
GO


/*
Created by: Thomas Dupuy
Date: 2/6/2020
Comment: Creats Sample Appointment Records
*/
print '' print '*** Creating Sample Appointment Records'
GO
INSERT INTO [dbo].[Appointment]
	([AdoptionApplicationID], [AppointmentTypeID], [DateTime], [Notes], [Decicion], [Location])
	VALUES
	('1000000', 'InHomeInspection', '2020-04-02 12:30:00', '', 'Undesided', '123 Real Ave, Marion IA'),
	('1000001', 'InHomeInspection', '1984-03-06 16:15:00', '', 'Undesided', '654 Notreal Blvd, Marion IA')
GO


/*
Created by: Thomas Dupuy
Date: 2/20/2020
Comment: Sproc to pull list of all appointments
*/
print '' print '*** sp_get_all_appointments'
GO
CREATE PROCEDURE [sp_get_all_appointments]
AS
BEGIN
	SELECT 	[AdoptionApplicationID], [AppointmentTypeID], [DateTime], [Notes], [Decicion], [Location]            
	FROM Appointment
END
GO


/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Create ItemCategory Table
*/
print '' print '*** Creating ItemCategory Table'
GO
CREATE TABLE [dbo].[ItemCategory](
	[ItemCategoryID] [nvarchar](50) NOT NULL PRIMARY KEY,
	[Description] [nvarchar](250) NOT NULL
)
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Create Item Table
*/

print '' print '*** Creating Item Table'
GO
CREATE TABLE [dbo].[Item](
	[ItemID] [int] NOT NULL IDENTITY(100000, 1) PRIMARY KEY,
	[ItemName] [nvarchar](50) NOT NULL,
	[ItemCategoryID] [nvarchar](50) NOT NULL,
	[ItemDescription] [nvarchar](250) NOT NULL,
	[ItemQuantity] [int] NOT NULL,
	CONSTRAINT [fk_Item_ItemCategoryID] FOREIGN KEY ([ItemCategoryID])
		REFERENCES [dbo].[ItemCategory]([ItemCategoryID])
)
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Create ProductCategory Table
*/

print '' print '*** Creating ProductCategory Table'
GO
CREATE TABLE [dbo].[ProductCategory](
	[ProductCategoryID] [nvarchar](20) NOT NULL PRIMARY KEY,
	[Description] [nvarchar](500) NOT NULL
)
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Create ProductType Table
*/

print '' print '*** Creating ProductType Table'
GO
CREATE TABLE [dbo].[ProductType](
	[ProductTypeID] [nvarchar](20) NOT NULL PRIMARY KEY,
	[Description] [nvarchar](500) NOT NULL
)
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Create Product Table
*/

print '' print '*** Creating Product Table'
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [nvarchar](13) NOT NULL PRIMARY KEY,
	[ItemID] [int] NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductCategoryID] [nvarchar](20) NOT NULL,
	[ProductTypeID] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[Price] [decimal](10,2) NOT NULL,
	[Brand] [nvarchar](20) NOT NULL,
	[Taxable] [bit] NOT NULL DEFAULT 1,
	CONSTRAINT [fk_Product_ItemID] FOREIGN KEY ([ItemID])
		REFERENCES [dbo].[Item]([ItemID]),
	CONSTRAINT [fk_Product_ProductCatagoryID] FOREIGN KEY ([ProductCategoryID])
		REFERENCES [dbo].[ProductCategory]([ProductCategoryID]),
	CONSTRAINT [fk_Product_ProductTypeID] FOREIGN KEY ([ProductTypeID])
		REFERENCES [dbo].[ProductType]([ProductTypeID])
)
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Insert Sample Data into ItemCategory Table
*/

print '' print '*** Insert Into ItemCategory Table ***'
GO
INSERT INTO [dbo].[ItemCategory](
	[ItemCategoryID],
	[Description]
)
VALUES
('Food','Pet food'),
('Medical','Medical supplies')
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Insert Sample Data into Item Table
*/

print '' print '*** Insert Into Item Table ***'
GO
INSERT INTO [dbo].[Item](
	[ItemName],
	[ItemCategoryID],
	[ItemDescription],
	[ItemQuantity]
)
VALUES
('LoCatMein','Food','Name Brand Cat Food', 42),
('Scratch Be Gone','Medical','Animal Scratch Wound Healant', 35)
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Insert Sample Data into ProductCategory Table
*/

print '' print '*** Insert Into ProductCategory Table ***'
GO
INSERT INTO [dbo].[ProductCategory](
	[ProductCategoryID],
	[Description]
)
VALUES
('Food','Pet food'),
('Medical','Medical supplies')
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Insert Sample Data into ProductType Table
*/


print '' print '*** Insert Into ProductType Table ***'
GO
INSERT INTO [dbo].[ProductType](
	[ProductTypeID],
	[Description]
)
VALUES
('Cat','Cat supplies'),
('General','General supplies')
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Insert Sample Data into Product Table
*/

print '' print '*** Insert Into Product Table ***'
GO
INSERT INTO [dbo].[Product](
	[ProductID],
	[ItemID],
	[ProductName],
	[ProductCategoryID],
	[ProductTypeID],
	[Description],
	[Price],
	[Brand]
)
VALUES
('7084781116',100000,'LoCatMein', 'Food', 'Cat', 'Name brand Cat Food', 50.00, 'OnlyForCats'),
('2500006153',100001,'Scratch Be Gone','Medical', 'General', 'Medical Supplies to Heal Scratch Wounds', 100.00, 'AlsoForHumans')
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Creating Stored Procedure sp_select_all_products_items
*/

print '' print '*** Creating sp_select_all_products_items ***'
GO
CREATE PROCEDURE [sp_select_all_products_items]
AS
BEGIN
	SELECT
		[Product].[ProductID],
		[Product].[ProductName],
		[Product].[Brand],
		[Product].[ProductCategoryID],
		[Product].[ProductTypeID],
		[Product].[Price],
		[Item].[ItemQuantity]
		FROM [Product]
		JOIN [Item] ON [Item].[ItemID] = [Product].[ItemID]
END
GO

/*
Created by: Derek Taylor
Date 2/4/2020
Comment: Stores data about applicants
*/
print '' print '*** Creating Applicant Table'
GO
CREATE TABLE [dbo].[Applicant](
	[ApplicantID]			[int]IDENTITY(100000, 1)	NOT NULL,
	[FirstName]				[nvarchar](50)				NOT NULL,
	[LastName]				[nvarchar](50)				NOT NULL,
	[MiddleName]			[nvarchar](50)				NOT NULL,
	[Email]					[nvarchar](250)				NOT NULL,
	[PhoneNumber]			[nvarchar](11)				NOT NULL,
	[AddressLine1]			[nvarchar](100)				NOT NULL,
	[AddressLine2]			[nvarchar](100)				NULL,
	[City]					[nvarchar](100)				NOT NULL,
	[State]					[char](2)					NOT NULL,
	[ZipCode]				[nvarchar](12)				NOT NULL,
	CONSTRAINT [pk_ApplicantID] PRIMARY KEY([ApplicantID] ASC),
	CONSTRAINT [ak_Applicant_Email] UNIQUE([Email] ASC)
)
GO

/*
Created by: Derek Taylor
Date 2/4/2020
Comment: Inserts sample data for the application
*/
print '' print '*** Creating Sample Applicants'
GO
INSERT INTO [dbo].[Applicant]
	([FirstName], [LastName], [MiddleName], [Email], [PhoneNumber], [AddressLine1], 
		[AddressLine2], [City], [State], [ZipCode])
	VALUES
	('Derek', 'Taylor', 'Joel','derek@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Ryan', 'Morganti', 'Donald Albert','ryan@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Steve', 'Coonrod', 'Marcus','steve@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Matt', 'Deaton', 'Franklin','matt@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Hassan', 'Karar', 'MiddleName','hassan@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Gabrielle', 'Legrande', 'Sue','gabrielle@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Michael', 'Thompson', 'Michael','michael@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Zach', 'Behrensmeyer', 'Zachariah','zach@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Josh', 'Jackson', 'Barry','josh@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Ethan', 'Murphy', 'Clover','ethan@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Brandyn', 'Cloverdill', 'David','brandyn@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Dalton', 'Reierson', '','dalton@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Jesse', 'Tomash', '','jesse@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Rasha', 'Mohammed', '','rasha@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Zoey', 'McDonald', 'Elizabeth','zoey@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Alex', 'Biers', '','alex@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Ben', 'Hanna', '','ben@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Cash', 'Carlson', '','cash@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555'),
	('Rob', 'Holmes', '','rob@company.com', '15555555555', '123 Fake Street', '', 'Faketown', 'IA', '55555')
GO

/*
Created by: Derek Taylor
Date 2/21/2020
Comment: Stored Procedure to select all of the applicants
*/
print '' print '*** Creating sp_select_all_applicants'
GO
CREATE PROCEDURE [sp_select_all_applicants]
AS
BEGIN
	SELECT [ApplicantID], [FirstName], [LastName], [MiddleName], [Email], [PhoneNumber]
	FROM [dbo].[Applicant]
	ORDER BY [ApplicantID]


/*
Created by: Chase Schulte
Date: 02/05/2020
Comment: Test dummy for department  
*/
drop table if exists [dbo].[EDepartment]

print '' print '*** Create Department Table ***'
GO
Create Table [dbo].[EDepartment](
	[EDepartmentID]	[nvarchar](50) 							not Null,
	Constraint	[pk_EDepartmentID] 	PRIMARY KEY([EDepartmentID] ASC)
)
GO

/*
Created by: Chase Schulte
Date: 02/05/2020
Comment: Inserts test data for the EDepartment Table
*/
print ''  print '*** Insert EDepartment into EDepartment Table'
GO

Insert INTO [dbo].[EDepartment]
	([EDepartmentID])
	Values
	('a'),
	('b')
Go


/*
Created by: Chase Schulte
Date: 02/05/2020
Comment: Inserts test data for the ERole Table
*/
drop table if exists [dbo].[ERole]

print ''  print '*** Creating Table "ERole Table"'
GO
Create Table [dbo].[ERole](
	[ERoleID]	[nvarchar](50) 							not Null,
	[EDepartmentID] nvarchar(50)							Not Null,
	[Description] [nvarchar](250)						Null,
	[Active]		[bit]			Not Null Default 1,
	Constraint	[pk_ERoleID] 	PRIMARY KEY([ERoleID] ASC),
	Constraint	[fk_ERole_EDepartmentID] Foreign Key([EDepartmentID])
		REFERENCES [EDepartment]([EDepartmentID] ) On UPDATE CASCADE
)
GO


/*
Created by: Chase Schulte
Date: 02/05/2020
Comment: Inserts test data for the ERole Table
*/
print ''  print '*** Insert eRoles into ERole Table'
GO

Insert INTO [dbo].[ERole]
	([ERoleID],[EDepartmentID],[Description])
	Values
	('Cashier','a','Handles customer'),
	('Manager','b','Handles internal operations like employee records and payment info')
Go



/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: pull up a list of eRoles 
*/
print '' print '*** Creating sp_select_all_eRoles'
GO
CREATE PROCEDURE sp_select_all_eRoles
	
AS
	BEGIN
		SELECT 	[ERoleID],[EDepartmentID],[Description],[Active]
		FROM 	[ERole]
	
	END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: deactivate a eRoleID by ID
*/
print ''  print '*** Creating sp_deactivate_eRole '
GO
CREATE PROCEDURE [sp_deactivate_eRole]
(
	
	@ERoleID	[nvarchar](50)	
)
AS
BEGIN
	Update [dbo].[ERole]
	Set
	[Active]=0
	Where [ERoleID] = @ERoleID
	
	Return @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: activate a eRoleID by ID
*/
print ''  print '*** Creating sp_activate_eRole '
GO
CREATE PROCEDURE [sp_activate_eRole]
(
	
	@ERoleID	[nvarchar](50)	
)
AS
BEGIN
	Update [dbo].[ERole]
	Set
	[Active]=1
	Where [ERoleID] = @ERoleID
	
	Return @@ROWCOUNT
END
GO
/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: update an oldERole with a new eRole
*/
print ''  print '*** Creating sp_update_eRole_by_id'
GO
CREATE PROCEDURE [sp_update_eRole]
(
	@OldERoleID	[nvarchar](50),
	@OldEDepartmentID nvarchar(50),
	@OldDescription [nvarchar](250),
	
	
	--New rows
	@NewEDepartmentID nvarchar(50),
	@NewDescription [nvarchar](250)
	
	
)
AS
BEGIN
	Update [dbo].[ERole]
	Set
	[EDepartmentID]=@NewEDepartmentID,
	[Description]=@NewDescription
	Where [ERoleID] = @OldERoleID
	And [EDepartmentID] = @OldEDepartmentID
	And [Description] = @OldDescription
	Return @@ROWCOUNT
END
GO


/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: insert a new eRole
*/
print ''  print '*** Creating sp_insert_eRole'
GO
CREATE PROCEDURE [sp_insert_eRole]
(
	@ERoleID[nvarchar](50),
	@EDepartmentID[nvarchar](50),
	@Description[nvarchar](250)
)
AS
BEGIN
	Insert Into [dbo].[ERole]
		([ERoleID],[EDepartmentID],[Description])
	VALUES
		(@ERoleID,@EDepartmentID,@Description)
		
END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: delete an eRole
*/
print '' print '*** Creating sp_delete_eRole '
GO
CREATE PROCEDURE [sp_delete_eRole] 
	(
		@ERoleID				[nvarchar](50)
	)
AS
	BEGIN
		DELETE  
		FROM 	[ERole]
		WHERE 	[ERoleId] = @ERoleId
		
	  
		RETURN @@ROWCOUNT
	END
GO

/*
Created by: Chase Schulte
Date: 02/16/2020
Comment: Select eRoles by active state
*/
print '' print '*** Creating sp_select_all_active_eRoles'
GO

CREATE PROCEDURE [sp_select_all_active_eRoles]
	(
		@Active				[bit]
	)
AS
BEGIN
	select [ERoleID],[EDepartmentID],[Description],[Active]
	FROM [dbo].[ERole]
	WHERE [Active] = @Active
END
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Employee table
*/
print '' print '*** Creating employee table'
GO
CREATE TABLE [dbo].[employee] (
	[EmployeeID]	[int]IDENTITY(1000000,1)	NOT NULL,
	[FirstName]		[nvarchar](50)				NOT NULL
	CONSTRAINT [pk_EmployeeID] PRIMARY KEY ([EmployeeID] ASC)
)
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Table that holds different types of requests
*/
print '' print '*** Creating requestType table'
GO
CREATE TABLE [dbo].[requestType] (
	[RequestTypeID]		[nvarchar](50)		NOT NULL,
	[Description]		[nvarchar](250)			NULL,
	CONSTRAINT [pk_RequestTypeID] PRIMARY KEY ([RequestTypeID] ASC)
)
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Table that holds each submitted request
*/
print '' print '*** Creating request table'
GO
CREATE TABLE [dbo].[request] (
	[RequestID]				[int]IDENTITY(1000000,1)	NOT NULL,
	[RequestTypeID]			[nvarchar](50)				NOT NULL,
	[EffectiveStart]		[datetime]					NOT NULL,
	[EffectiveEnd]			[datetime]						NULL,
	[ApprovalDate]			[datetime]						NULL,
	[RequestingEmployeeID]	[int]						NOT NULL,
	[ApprovingUserID]		[int]							NULL,
	[Open]					[bit]			  NOT NULL DEFAULT 1,
	CONSTRAINT [pk_RequestID] PRIMARY KEY ([RequestID] ASC),
	CONSTRAINT [fk_request_requestTypeID] FOREIGN KEY([RequestTypeID])
		REFERENCES [requestType]([RequestTypeID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_request_requestingEmployeeID] FOREIGN KEY ([RequestingEmployeeID])
		REFERENCES [employee]([EmployeeID]),
	CONSTRAINT [fk_request_approvingUserID] FOREIGN KEY ([ApprovingUserID])
		REFERENCES [user]([UserID])
)
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Method to retrieve all submitted requests
*/
print '' print '*** Creating sp_select_all_requests'
GO
CREATE PROCEDURE [sp_select_all_requests]
AS
BEGIN
	SELECT [RequestID], [RequestTypeID], [EffectiveStart], [EffectiveEnd], 
		   [ApprovalDate], [RequestingEmployeeID], [ApprovingUserID]
	FROM [dbo].[request]
END
GO

/*
Created by: Kaleb Bachert
Date: 2/19/2020
Comment: Method to approve a specified request
*/
print '' print '*** Creating sp_approve_request'
GO
CREATE PROCEDURE [sp_approve_request]
	@RequestID		[int],
	@UserID			[int]
AS
BEGIN
	UPDATE [dbo].[request]
	SET [ApprovingUserID] = @UserID,
		[ApprovalDate] = GETDATE()
	WHERE [RequestID] = @RequestID
	AND [ApprovingUserID] IS NULL
	AND [Open] = 1
	SELECT @@ROWCOUNT
END
GO

/*
SAMPLE DATA
*/

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Inserting Sample Data for RequestType
*/
INSERT INTO [dbo].[requestType]
	([RequestTypeID])
	VALUES
	('Time Off'), ('Availability Change')
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Inserting Sample Data for Employee
*/
INSERT INTO [dbo].[employee]
	([FirstName])
	VALUES
	('John'), ('Son')
	
/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Inserting Sample Data for Request with nulls
*/
INSERT INTO [dbo].[request]
	([RequestTypeID], [EffectiveStart], [EffectiveEnd], [RequestingEmployeeID])
	VALUES
	('Time Off', '2020-2-22 12:12:12', '2020-2-26 12:12:12', 1000001)
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Inserting Sample Data for Request without nulls
*/
INSERT INTO [dbo].[request]
	([RequestTypeID], [EffectiveStart], 
	[ApprovalDate], [RequestingEmployeeID], [ApprovingUserID])
	VALUES
	('Availability Change', '2020-6-1 12:00:00', '2020-2-11 11:31:15', 1000001, 100000)
GO
