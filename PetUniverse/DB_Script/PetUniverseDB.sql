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
[addressLineOne] [nvarchar](250),
[addressLineTwo] [nvarchar](250),
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
[Zipcode],
[addressLineOne],
[addressLineTwo]
)
VALUES

('Zach', 'Behrensmeyer', '1234567890', 'zbehrens@PetUniverse.com', 1,'Cedar Rapids','IA','52433','J street NE','APT3'),
('Steven', 'Cardona', '2234567890', 'scardona@PetUniverse.com', 1,'Cedar Rapids','IA','52433','J street NE','APT3'), 
('Thomas', 'Dupuy', '3234567890', 'tdupuy@PetUniverse.com', 1,'Cedar Rapids','IA','52433','J street NE','APT3'),
('Mohamed','Elamin' ,'3198376522','moals@PetUniverse.com',1,'Cedar Rapids','IA','52433','J street NE','APT3')
GO
print '' print '*** Insert users into User Table ***'
GO
/*
Created by: Austin Gee
Date: 2/21/2020
Comment: This adds some ample user records to the database.
*/
print '' print '*** Creating Sample User Records'
GO
INSERT INTO [dbo].[User]
	([FirstName],[LastName],[PhoneNumber],[Email],[City],[State],[Zipcode])
	VALUES
	('Austin','Gee','1234567890','Austin@email.com','Cedar Rapids','IA','52404'),
	('Bill','Buffalo','1234567890','Bill@email.com','Cedar Rapids','IA','52404'),
	('Brad','Bean','1234567890','Brad@email.com','Iowa City','IA','52404'),
	('Barb','Brinoll','1234567890','Barb@email.com','Cedar Rapids','IA','52404'),	
	('Awaab','Elamin','3192104964','Awaab@Awaaab.com','Cedar Rapids','IA','52404')
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

Updated by: Austin Gee
Date: 2/21/2020
Comment: Added Description Field.
*/
CREATE TABLE [dbo].[AnimalSpecies](
	[AnimalSpeciesID]	[nvarchar](100)				NOT NULL,
	[Description]		[nvarchar](1000)					,
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

/*
Created by: Awaab Elamin
Date: 2/6/2020
Comment: Sproc retrieve animal record by its ID.
*/
GO
GO
print '' print '*** Creating sp_get_Animal_by_id'
GO	
Create PROCEDURE [dbo].[sp_get_animal_by_id]
(
	@animalId int
)
AS
BEGIN
	SELECT 	[AnimalID] ,
			[AnimalName],
			[Dob] ,
			[AnimalBreed] ,
			[ArrivalDate] ,
			[ImageLocation] ,
			[CurrentlyHoused] ,
			[Adoptable],
			[Active] ,
			[AnimalSpeciesID] ,			
			[StatusID] 
	FROM 	[dbo].[Animal]
	WHERE	[AnimalID] = @animalId;	
END
GO

print '' print '*** Creating AnimalKennel Table'
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
	[TemperamentWarning]	[nvarchar](1000)		  NOT NULL,
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
Created by: Ben Hanna
Date: 2/18/2020
Comment: Sample animal handling notes record
*/                
print '' print '*** Creating Sample Animal Handling Records'
GO
INSERT INTO [dbo].[AnimalHandlingNotes]
	([AnimalID], [AnimalHandlingNotes], [TemperamentWarning], [UpdateDate], [UserID] 
    )
	VALUES
	(1000000,
     'test test test', 'hubba hubba', '2020-01-22', 
     100000)
GO
                
/*
Created by: Ben Hanna
Date: 2/18/2020
Comment: Sets an animal's adoptable state to false
*/ 
print '' print '*** Creating sp_select_handling_notes_by_animal_id'
GO
CREATE PROCEDURE [sp_select_handling_notes_by_animal_id]
(
    @AnimalID      [int]
)
AS
BEGIN
   SELECT [AnimalHandlingNotesID],[AnimalHandlingNotes], [TemperamentWarning], [UpdateDate], [UserID] 
                
   FROM [dbo].[AnimalHandlingNotes]
   WHERE [AnimalID] = @AnimalID
   ORDER BY [UpdateDate]
END
GO
                
/*
Created by: Ben Hanna
Date: 2/9/2020
Comment: Insert a kennel record
*/                
print '' print '*** Creating sp_insert_kennel_record'
GO
CREATE PROCEDURE [sp_insert_kennel_record]
(
    @AnimalID           [int],
    @AnimalKennelInfo   [nvarchar](4000), 
    @AnimalKennelDateIn	[date],
    @UserID           [int]
        
)
AS
BEGIN
   INSERT INTO [dbo].[AnimalKennel] 
        ([AnimalID], 
         [AnimalKennelInfo], 
         [AnimalKennelDateIn],
         [UserID]
        )
   VALUES 
        (@AnimalID,
         @AnimalKennelInfo,
         @AnimalKennelDateIn
         ,@UserID
        )
   SELECT SCOPE_IDENTITY()
END
GO

/*
Created by: Ben Hanna
Date: 2/18/2020
Comment: Sets an animal's adoptable state to false
*/                
print '' print '*** Creating sp_select_handling_notes_by_id'
GO
CREATE PROCEDURE [sp_select_handling_notes_by_id]
(
    @AnimalHandlingNotesID      [int]
)
AS
BEGIN
   SELECT [AnimalID], [AnimalHandlingNotes], [TemperamentWarning], [UpdateDate], [UserID] 
   FROM [dbo].[AnimalHandlingNotes]
   WHERE [AnimalHandlingNotesID] = @AnimalHandlingNotesID
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
	,[Active]				[bit]
	DEFAULT 1
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
CREATE PROCEDURE [sp_select_all_active_departments]
AS
BEGIN
	SELECT [DepartmentID],[Description]
	FROM [Department]
	WHERE [Active] = 1
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
('Fake1','14:00:00','22:00:00'),
('Fake2','08:45:00','17:45:00'),
('Fake3','14:00:00','22:00:00'),
('Fake4','08:45:00','17:45:00')
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
Created by: Austin Gee
Date: 2/21/2020
Comment: This adds some sample customer records to the Customer table.
*/
print '' print '*** Creating Sample Customer Records'
GO
INSERT INTO [dbo].[Customer]
	([UserID])
	VALUES
	(100000),
	(100001),
	(100002),
	(100003),
	((SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))
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
	(100000,1000000,'InHomeInspection','2019-10-9')
GO
/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Adds adoption appliacation records to the AdoptionApplication table.
*/
print '' print '*** Creating Sample AdoptionApplication Records'
GO
INSERT INTO [dbo].[AdoptionApplication]
	([CustomerID],[AnimalID],[Status],[RecievedDate])
	VALUES
	(100000,1000000,'Interview Stage','2019-10-9'),
	(100001,1000001,'Reviewing Application','2019-10-9'),
	(100002,1000002,'Waitng for Pickup','2019-10-9'),
	(
		((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))),
		(SELECT [AnimalID]FROM[dbo].[Animal]WHERE [Animal].[AnimalName] = 'Paul'),
		'Reviewer',
		'2020-01-01'
		
	)
GO
/*
Created by: Awaab Elamin
Date: 2/5/2020
Comment: Spoc to retrieve all Adoption Applications
*/
GO
print '' print '*** Creating sp_get_Adoption_Application'
GO
Create PROCEDURE [dbo].[sp_get_Adoption_Application]
AS
BEGIN
	SELECT 	[AdoptionApplicationID],
			[CustomerID],
			[AnimalID],
			[Status],
			[RecievedDate]
	From 	[dbo].[AdoptionApplication]
END
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
	WHERE	[Status] = 'InHomeInspection'
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
Created by: Mohamed Elamin
Date: 02/18/2020
Comment: Sproc to find Customer by Customer name from the User Table.
*/
print '' print '*** Creating sp_select_Customer_by_Customer_Name'
GO
CREATE PROCEDURE [sp_select_Customer_by_Customer_Name]
(
	@CustomerName 		[nvarchar](50)
)
AS
BEGIN


	SELECT[userID],[FirstName],[lastName],[phoneNumber],[email],[active],[addressLineOne],
			[addressLineTwo],[city],[state],[zipCode]
	
			
	FROM 	[User]
	WHERE	[User].[lastName] = @CustomerName  
	
END
GO


/*
Created by: Mohamed Elamin
Date: 02/18/2020
Comment: Sproc to updates Adoption appliction's decision and notes.
*/
print '' print '*** Creating sp_update_AdoptionApliction'
GO

CREATE PROCEDURE [sp_update_AdoptionApliction]
(

    @AppointmentID			[int],

	@NewNotes		      [nvarchar](1000),
	@NewDecision		  [nvarchar](50),
	
	
	@OldNotes    		[nvarchar](1000),
	@OldDecision		[nvarchar](50)
	
)
AS
BEGIN
	UPDATE [dbo].[Appointment]
		SET [Notes] = 	  @NewNotes,
			[Decision] = 	@NewDecision
			
	WHERE 	[AppointmentID] =	@AppointmentID  
	  AND	[Notes] = 	@OldNotes
	  AND	[Decision] = 	@OldDecision	 
	RETURN  @@ROWCOUNT
END
GO
/*
Created by: Thomas Dupuy
Date: 2/6/2020
Comment: Creats AppointmentType Table
*/
/*
print '' print '*** Creating AppointmentType Table'
GO
CREATE TABLE [dbo].[AppointmentType](
	[AppointmentTypeID] 	[nvarchar](150) 				NOT NULL,
	[Description]			[nvarchar](250) 					NULL,
	CONSTRAINT [pk_AppointmentTypeID] PRIMARY KEY([AppointmentTypeID] ASC)
)
GO
*/

/*
Created by: Thomas Dupuy
Date: 2/6/2020
Comment: Creats Appointment Table
*/
/*
print '' print '*** Creating Appointment Table'
GO
CREATE TABLE [dbo].[Appointment](
	[AppointmentID] 			[int] IDENTITY(1000,1)			NOT NULL,
	[AdoptionApplicationID]		[int]							NOT NULL,
	[AppointmentTypeID] 		[nvarchar](150) 				NOT NULL,
	[DateTime] 					[smalldatetime]					NOT NULL,
	[Notes] 					[nvarchar](1000) 					NULL,
	[Decicion] 					[nvarchar](50) 						NULL,
	[Location] 					[nvarchar](100) 				NOT NULL,
	CONSTRAINT [pk_AppointmentID] PRIMARY KEY([AppointmentID] ASC)
)
GO
*/


/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Table that holds the various appointment types for adoption appointments
*/
print '' print '*** Creating AppointmentType Table'
GO
CREATE TABLE [dbo].[AppointmentType](
	[AppointmentTypeID]		[nvarchar]	(100)	NOT NULL,
	[Description]			[nvarchar]	(1000)			,
	CONSTRAINT [pk_AppointmentTypeID] PRIMARY KEY ([AppointmentTypeID])
)

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: This Table holds locations in general. It is used by Adoptions to
	track locations of various appointments.
*/
print '' print '*** Creating Location Table'
GO
CREATE TABLE [dbo].[Location](
	[LocationID]	[int]	IDENTITY(1000000,1)		NOT NULL,
	[Name]			[nvarchar]	(100)						,
	[Address1]		[nvarchar]	(100)				NOT NULL,
	[Address2]		[nvarchar]	(100)						,
	[City]			[nvarchar]	(100)				NOT NULL,
	[State]			[nvarchar]	(2)					NOT NULL,
	[Zip]			[nvarchar]	(20)				NOT NULL,
	CONSTRAINT [pk_LocationID] PRIMARY KEY	([LocationID])
)
GO

print '' print '*** Creating Sample Location Records'
GO
INSERT INTO [dbo].[Location]
	([Name],[Address1],[Address2],[City],[State],[Zip])
	VALUES
	('Shelter','123 here we go lane',null,'Good Town','ST','12345'),
	(null,'123 2nd St',null,'Bad City','ST','12345'),
	(null,'555 Oak St.',null,'Far Away Town','ST','12345'),
	(null,'9090 Ninety Rd.','Apt # 4','Good Town','ST','12345')
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: This table holds data regarding various adoption related appointments.
*/
print '' print '*** Creating Appointment Table'
GO
CREATE TABLE [dbo].[Appointment](
	[AppointmentID]			[int]	IDENTITY(1000000,1)		NOT NULL,
	[AdoptionApplicationID]	[int]							NOT NULL,
	[AppointmentTypeID]		[nvarchar]	(100)				NOT NULL,
	[DateTime]				[datetime]						NOT NULL,
	[Notes]					[nvarchar]	(1000)						,
	[Decision]				[nvarchar]	(50)						,
	[LocationID]			[int]							NOT NULL,
	[Active]				[bit]	DEFAULT 1				NOT NULL,			
	CONSTRAINT [pk_AppointmentID] PRIMARY KEY ([AppointmentID]),
	CONSTRAINT [fk_Appointment_AdoptionApplication_AdoptionApplicationID] FOREIGN KEY ([AdoptionApplicationID])
		REFERENCES [AdoptionApplication] ([AdoptionApplicationID]),
	CONSTRAINT [fk_Appointment_AppointmentType_AppointmentTypeID] FOREIGN KEY ([AppointmentTypeID])
		REFERENCES [AppointmentType] ([AppointmentTypeID]),
	CONSTRAINT [fk_Appointment_Location_LocationID] FOREIGN KEY ([LocationID])
		REFERENCES [Location] ([LocationID])
)
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
END

/*
Created by: Chase Schulte
Date: 02/05/2020
Comment: Test dummy for department  
*/
drop table if exists [dbo].[EDepartment]

print '' print '*** Create Department Table'
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

print ''  print '*** Creating Table ERole Table'
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
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Create volunteer task table
*/
print '' print '*** Creating VolunteerTask Table'
GO
CREATE TABLE [dbo].[VolunteerTask](
	[VolunteerTaskID] 		[int] IDENTITY(1000000,1) 	NOT NULL,
	[TaskName]				[NVARCHAR](100)				NOT NULL,
	[TaskType]				[NVARCHAR](100)				NOT NULL,
	[AssignmentGroup]		[NVARCHAR](100)				NOT NULL,
	[TaskDescription] 		[NVARCHAR](1080) 			    NULL,
	[DueDate] 				[DATE]						NOT NULL,
	
	CONSTRAINT [pk_VolunteerTaskID] PRIMARY KEY([VolunteerTaskID] ASC),
)
GO

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Insert a volunteer task record
*/
print '' print '*** Creating sp_insert_volunteer_task'
GO
CREATE PROCEDURE [sp_insert_volunteer_task]
(
	@TaskName 					[NVARCHAR](100),
	@TaskType					[NVARCHAR](100),
	@AssignmentGroup			[NVARCHAR](100),
	@TaskDescription  			[NVARCHAR](1080),
	@DueDate					[DATE]

)
AS
BEGIN
	INSERT INTO [dbo].[VolunteerTask]
		([TaskName],[TaskType],[AssignmentGroup],[TaskDescription], [DueDate])
	VALUES
		(@TaskName, @TaskType, @AssignmentGroup, @TaskDescription, @DueDate)
	SELECT SCOPE_IDENTITY()
END 
GO

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Insert fake data into VolunteerTask table
*/
print ''  print '*** Insert fake Volunteer Tasks'
GO

Insert INTO [dbo].[VolunteerTask]
	([TaskName],[TaskType],[AssignmentGroup],[DueDate],[TaskDescription])
	Values
	('Fake Task 1','TaskType1','Group1','02/01/2021','Fake Description 1'),
	('Fake Task 2','TaskType2','Group2','02/01/2022','Fake Description 2')
GO

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Selects volunteer task by name
*/
print '' print '*** Creating sp_select_volunteer_task_by_name'
GO
CREATE PROCEDURE [sp_select_volunteer_task_by_name]
(
	@taskName [NVARCHAR](100)
)
AS
BEGIN
	SELECT [VolunteerTaskID], [TaskName], [TaskType], [AssignmentGroup], [DueDate], [TaskDescription]
	FROM [dbo].[VolunteerTask]
	WHERE [TaskName] = @taskName
END
GO

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Select all volunteer tasks
*/
print '' print '*** Creating sp_select_all_volunteer_tasks'
GO
CREATE PROCEDURE [sp_select_all_volunteer_tasks] 
AS
BEGIN
	SELECT [TaskName], [TaskType], [AssignmentGroup], [DueDate], [TaskDescription]
	FROM [dbo].[VolunteerTask]
END
GO

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Updates a volunteer task record
*/
print '' print '*** Creating sp_update_volunteer_task_by_name'
GO
CREATE PROCEDURE [sp_update_volunteer_task_by_name]
(
	@TaskName 					[NVARCHAR](100),
	@TaskType					[NVARCHAR](100),
	@AssignmentGroup			[NVARCHAR](100),
	@TaskDescription  			[NVARCHAR](1080),
	@DueDate					[DATE]

)
AS
BEGIN
	UPDATE [dbo].[VolunteerTask]
	SET [TaskType] = @TaskType,
		[AssignmentGroup] = @AssignmentGroup,
		[DueDate] = @DueDate,
		[TaskDescription] = @TaskDescription
	WHERE [TaskName] = @TaskName
	SELECT SCOPE_IDENTITY()
END 
GO






/*
Created by: Austin Gee
Date: 2/21/2020
Comment: This adds AnimalSpecies records to the AnimalSpecies table.
*/
print '' print '*** Creating Sample AnimalSpecies Records'
GO
INSERT INTO [dbo].[AnimalSpecies]
	([AnimalSpeciesID],[Description])
	VALUES
	('Dog','This is a dog'),
	('Cat','Your commmon house cat'),
	('Rat','The fancy rat')
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Adds Animal records to the Animal table
*/
print '' print '*** Creating Sample Animal Records'
GO
INSERT INTO [dbo].[Animal]
	([AnimalName],[Dob],[AnimalSpeciesID],[AnimalBreed],[ArrivalDate],[StatusID])
	VALUES
	('Spot','07-12-1984','Dog','Blood Hound','10-10-2019','A'),
	('Spit','07-12-1984','Cat','Tabby','10-10-2019','A'),
	('Simon','07-12-1984','Rat','Siamese','10-10-2019','A')
GO



/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Adds AppointmentType Records to the AppointmentType table.
*/
print '' print '*** Creating Sample AppointmentType Records'
GO
INSERT INTO [dbo].[AppointmentType]
	([AppointmentTypeID],[Description])
	VALUES
	('Meet and Greet','This is where the Adoption Customer will meet the animal while the facilitator is present'),
	('inHomeInspection','This is where the Interviewer will interview the Adoption Customer')
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Adds sample Appointment records to the Appointment table.
*/
print '' print '*** Creating Sample Appointment Records'
GO
INSERT INTO [dbo].[Appointment]
	([AdoptionApplicationID],[AppointmentTypeID],[DateTime],[Notes],[Decision],[LocationID])
	VALUES
	(100000,'inHomeInspection','2020-2-22 10am','','',1000000),
	(100001,'Meet and Greet','2020-2-22 9am','','',1000000),
	(100002,'inHomeInspection','2020-2-22 12pm','','',1000000)
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Stored Procedure that selects Adoption Customers by active status
*/
print '' print '*** Creating sp_select_adoption_customers_by_active'
GO
CREATE PROCEDURE [sp_select_adoption_customers_by_active]
(
	@Active			[bit]
)
AS
BEGIN
	SELECT 
	[User].[UserID]
	,[FirstName]
	,[LastName]
	,[PhoneNumber]
	,[Email]
	,[User].[Active]
	,[City],[State]
	,[Zipcode]
	,[Customer].[CustomerID]
	,[Animal].[AnimalID]
	,[Status],[AdoptionApplication].[RecievedDate]
	,[AnimalName]
	,[AnimalBreed]
	,[Animal].[ArrivalDate]
	,[CurrentlyHoused]
	,[Adoptable]
	,[Animal].[Active]
	,[AdoptionApplication].[AdoptionApplicationID]
	,[AnimalSpeciesID]
	FROM [User] JOIN [Customer] ON [User].[UserID] = [Customer].[UserID]
	JOIN [AdoptionApplication] ON [Customer].[CustomerID] = [AdoptionApplication].[CustomerID]
	JOIN [Animal] ON [Animal].[AnimalID] = [AdoptionApplication].[AnimalID]
	WHERE [Customer].[UserID] IS NOT NULL
	AND [User].[Active] = @Active
END
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Stored Procedure that selects adoption appointments by active and type.
*/
print '' print '*** Creating sp_select_adoption_appointments_by_active_and_type'
GO
CREATE PROCEDURE [sp_select_adoption_appointments_by_active_and_type]
(
	@Active				[int] 			,
	@AppointmentTypeID	[nvarchar] (100)
)
AS
BEGIN
	SELECT 
	[AppointmentID]
	,[AdoptionApplication].[AdoptionApplicationID]
	,[Appointment].[AppointmentTypeID]
	,[Appointment].[DateTime]
	,[Appointment].[Notes]
	,[Appointment].[Decision]
	,[Location].[LocationID]
	,[Appointment].[Active]
	,[Customer].[CustomerID]
	,[Animal].[AnimalID]
	,[AdoptionApplication].[Status]
	,[AdoptionApplication].[RecievedDate]
	,[Location].[Name]
	,[Location].[Address1]
	,[Location].[Address2]
	,[Location].[City]
	,[Location].[State]
	,[Location].[Zip]
	,[Customer].[UserID]
	,[User].[FirstName]
	,[User].[LastName]
	,[User].[PhoneNumber]
	,[User].[Email]
	,[User].[Active]
	,[User].[City]
	,[User].[State]
	,[User].[Zipcode]
	,[Animal].[AnimalName]
	,[Animal].[Dob]
	,[Animal].[AnimalSpeciesID]
	,[Animal].[AnimalBreed]
	,[Animal].[ArrivalDate]
	,[Animal].[CurrentlyHoused]
	,[Animal].[Adoptable]
	,[Animal].[Active]
	FROM [Appointment] JOIN [AdoptionApplication] ON [AdoptionApplication].[AdoptionApplicationID] = [Appointment].[AdoptionApplicationID]
	JOIN [Location] ON [Appointment].[LocationID] = [Location].[LocationID]
	JOIN [Customer] ON [AdoptionApplication].[CustomerID] = [Customer].[CustomerID]
	JOIN [Animal] ON [AdoptionApplication].[AnimalID] = [Animal].[AnimalID]
	JOIN [User] ON [Customer].[UserID] = [User].[UserID]
	WHERE [Appointment].[Active] = @Active
	AND	[Appointment].[AppointmentTypeID] = @AppointmentTypeID
	ORDER BY [Appointment].[DateTime] DESC
END
GO

/*
Created by: Mohamed Elamin
Date: 02/18/2020
Comment: Sproc to gets ALL Adoption applictions where thier status is inHomeInspection
*/
print '' print '*** Creating sp_select_inHomeInspectionAppointments_by_AppointmentType'
GO
CREATE PROCEDURE [sp_select_inHomeInspectionAppointments_by_AppointmentType]	
AS
BEGIN
	SELECT 	AppointmentID,AdoptionApplicationID,AppointmentTypeID,DateTime,Notes,
			Decision,LocationID,Active
	FROM 	[dbo].[Appointment]
	WHERE	[AppointmentTypeID] = 'inHomeInspection'
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
Created by: Awaab Elamin
Date: 2/18/2020
Comment: Sproc to update the status of adoption Application.
*/
GO
print '' print '*** Creating sp_update_adoption_application_status'
GO
CREATE PROCEDURE [dbo].[sp_update_adoption_application_status](@status [nvarchar](100), @AdoptionApplicationID [int])
AS
BEGIN
	UPDATE [dbo].[AdoptionApplication]
	SET [Status] = @Status
	WHERE [AdoptionApplicationID] = @AdoptionApplicationID
	RETURN @@ROWCOUNT
END
GO


/*
Created by: Awaab Elamin
Date: 2/10/2020
Comment: Create General Questions table that contains the Questionnair qusetions.
*/
GO
/*
Created by: Awaab Elamin
Date: 2/18/2020
Comment: Create a general questiones table that contain the questions of the questionnair.
*/
GO
print '' print '*** Creating the GeneralQusetions table'
GO
CREATE TABLE [dbo].[GeneralQusetions](
	[QuestionID] [int] IDENTITY (1000000, 1) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	
	CONSTRAINT [pk_QuestionID] PRIMARY KEY ([QuestionID] ASC)
)
GO

GO

print '' print '*** Inserting GeneralQusetions records'
GO
INSERT INTO [dbo].[GeneralQusetions]
(Description)
VALUES
('Question 1'),('Question 2'),('Question 3'),('Question 4'),('Question 5'),('Question 6'),('Question 7')

GO
/*
Created by: Awaab Elamin
Date: 2/10/2020
Comment: Create Customer Answers table that contains the customer answers of the questionnair
*/
print '' print '*** Creating the CustomerAnswer table'
GO
CREATE TABLE [dbo].[CustomerAnswer](
	[QuestionID] [int]  NOT NULL,
	[CustomerID] [int]  NOT NULL,
	[AdoptionApplicationID] [int]  NOT NULL,
	[Answer] [nvarchar](500) NOT NULL,
	
	CONSTRAINT [pk_QuestionID_CustomerID_AdoptionApplicationID] PRIMARY KEY ([QuestionID] ASC,[CustomerID] ASC,[AdoptionApplicationID] ASC),
	CONSTRAINT [fk_QuestionID]	FOREIGN KEY ([QuestionID])
		REFERENCES [dbo].[GeneralQusetions]([QuestionID]),
	CONSTRAINT [CustomerID]	FOREIGN KEY ([CustomerID])
		REFERENCES [dbo].[Customer]([CustomerID]),
	CONSTRAINT [AdoptionApplicationID]	FOREIGN KEY ([AdoptionApplicationID])
		REFERENCES [dbo].[AdoptionApplication]([AdoptionApplicationID]),
)
GO
print '' print '*** Inserting CustomerAnswer records'
GO
INSERT INTO [dbo].[CustomerAnswer]
([QuestionID],[CustomerID],[AdoptionApplicationID],[Answer])
VALUES
(
	(SELECT [QuestionID]FROM[dbo].[GeneralQusetions]WHERE [GeneralQusetions].[Description] = 'Question 1'),
	((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))),
	((SELECT [AdoptionApplicationID] FROM [dbo].[AdoptionApplication] WHERE [dbo].[AdoptionApplication].[CustomerID] =
	 ((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))))),
	'Answer1'

),
(
	(SELECT [QuestionID]FROM[dbo].[GeneralQusetions]WHERE [GeneralQusetions].[Description] = 'Question 2'),
	((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))),
	((SELECT [AdoptionApplicationID] FROM [dbo].[AdoptionApplication] WHERE [dbo].[AdoptionApplication].[CustomerID] =
	 ((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))))),
	'Answer2'
),
(
	(SELECT [QuestionID]FROM[dbo].[GeneralQusetions]WHERE [GeneralQusetions].[Description] = 'Question 3'),
	((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))),
	((SELECT [AdoptionApplicationID] FROM [dbo].[AdoptionApplication] WHERE [dbo].[AdoptionApplication].[CustomerID] =
	 ((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))))),
	'Answer3'
),
(
	(SELECT [QuestionID]FROM[dbo].[GeneralQusetions]WHERE [GeneralQusetions].[Description] = 'Question 4'),
	((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))),
	((SELECT [AdoptionApplicationID] FROM [dbo].[AdoptionApplication] WHERE [dbo].[AdoptionApplication].[CustomerID] =
	 ((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))))),
	'Answer4'
),
(
	(SELECT [QuestionID]FROM[dbo].[GeneralQusetions]WHERE [GeneralQusetions].[Description] = 'Question 5'),
	((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))),
	((SELECT [AdoptionApplicationID] FROM [dbo].[AdoptionApplication] WHERE [dbo].[AdoptionApplication].[CustomerID] =
	 ((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))))),
	'Answer5'
),
(
	(SELECT [QuestionID]FROM[dbo].[GeneralQusetions]WHERE [GeneralQusetions].[Description] = 'Question 6'),
	((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))),
	((SELECT [AdoptionApplicationID] FROM [dbo].[AdoptionApplication] WHERE [dbo].[AdoptionApplication].[CustomerID] =
	 ((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))))),
	'Answer6'
),
(
	(SELECT [QuestionID]FROM[dbo].[GeneralQusetions]WHERE [GeneralQusetions].[Description] = 'Question 7'),
	((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))),
	((SELECT [AdoptionApplicationID] FROM [dbo].[AdoptionApplication] WHERE [dbo].[AdoptionApplication].[CustomerID] =
	 ((SELECT [CustomerID]FROM[dbo].[Customer]WHERE [Customer].[UserID] = 
		(SELECT userID FROM [dbo].[User] WHERE [dbo].[User].[FirstName] = 'Awaab' ))))),
	'Answer7'
)
GO
/*
Created by: Awaab Elamin
Date: 2/12/2020
Comment: Create SP retrieve Customer Answers from CustomerAnswer Table by using Customer ID
*/
GO
print '' print '*** sp_get_Customer_Answer_By_CustomrID'
GO
Create PROCEDURE [dbo].[sp_get_Customer_Answer_By_CustomrID]
(
	@CustomerID int
)
AS
BEGIN
	SELECT 	[AdoptionApplicationID],[QuestionID],[Answer]
	From 	[dbo].[CustomerAnswer]
	WHERE	[CustomerID] = @CustomerID;	
END
GO
/*
Created by: Awaab Elamin
Date: 2/12/2020
Comment: Create SP retrieve Customer ID from Customers  Table by using user ID
*/
GO
print '' print '*** sp_get_CustomerID_By_User_ID'
GO
Create PROCEDURE [dbo].[sp_get_CustomerID_By_User_ID]
(
	@UserID int
)
AS
BEGIN
	SELECT 	[CustomerID]
	From 	[dbo].[Customer]
	WHERE	[UserID] = @UserID;	
END
GO
/*
Created by: Awaab Elamin
Date: 2/12/2020
Comment: Create SP retrieve question description by question ID
*/
GO
print '' print '*** Creating sp_get_question_description_by_questionId'
GO
CREATE PROCEDURE [dbo].[sp_get_question_description_by_questionId]
(
	@QuestionID int
)
AS
BEGIN
	SELECT 	[Description] 
	From 	[dbo].[GeneralQusetions]
	WHERE	[QuestionID] = @QuestionID;	
END
GO
/*
Created by: Awaab Elamin
Date: 2/15/2020
Comment: Create SP retrieve Adoption Application by Customer ID
*/
GO
print '' print '*** Creating sp_get_Adoption_Application_By_CustomerID'
GO
CREATE PROCEDURE [dbo].[sp_get_Adoption_Application_By_CustomerID](@customerID [int])
AS
BEGIN
	SELECT 	[AdoptionApplicationID],
			[AnimalID],
			[Status],
			[RecievedDate]
	From 	[dbo].[AdoptionApplication]
	WHERE	[CustomerID] = @CustomerID;	
END
GO

/*
Created by: Jaeho Kim
Date: 2/26/2020
Comment: Create TransactionStatus Table
*/

print '' print '*** Creating TransactionStatus Table'
GO
CREATE TABLE [dbo].[TransactionStatus](
	[TransactionStatusID] 	[nvarchar](20) NOT NULL,
	[Description] 			[nvarchar](500) NOT NULL,
	
	CONSTRAINT [pk_TransactionStatus_TransactionStatusID] PRIMARY KEY ([TransactionStatusID] ASC)
)
GO

/*
Created by: Jaeho Kim
Date: 02/27/2020
Comment: Inserts test data for the TransactionStatus Table
*/
print ''  print '*** Inserting sample data into TransactionStatus Table'
GO

Insert INTO [dbo].[TransactionStatus]
	([TransactionStatusID], [Description])
	Values
	('tranStatus100', 'description 100'),
	('tranStatus200', 'description 200'),
	('tranStatus500', 'description 500'),
	('tranStatus800', 'description 800')
GO

/*
Created by: Jaeho Kim
Date: 2/26/2020
Comment: Create TransactionType Table
*/

print '' print '*** Creating TransactionType Table'
GO
CREATE TABLE [dbo].[TransactionType](
	[TransactionTypeID] 	[nvarchar](20) 		NOT NULL,
	[Description] 			[nvarchar](500) 	NOT NULL,
	
	CONSTRAINT [pk_TransactionType_TransactionTypeID] PRIMARY KEY ([TransactionTypeID] ASC)
)
GO

/*
Created by: Jaeho Kim
Date: 02/27/2020
Comment: Inserts test data for the TransactionType Table
*/
print ''  print '*** Inserting sample data into TransactionType Table'
GO

Insert INTO [dbo].[TransactionType]
	([TransactionTypeID], [Description])
	Values
	('tranTYPE100', 'TYPEdescription 100'),
	('tranTYPE200', 'TYPEdescription 200'),
	('tranTYPE500', 'TYPEdescription 500'),
	('tranTYPE800', 'TYPEdescription 800')
GO

/*
Created by: Jaeho Kim
Date: 2/26/2020
Comment: Create Transaction Table
*/

print '' print '*** Creating Transaction Table'
GO
CREATE TABLE [dbo].[Transaction](
	[TransactionID] 		[int]IDENTITY(1000,1)	NOT NULL,
	[EmployeeID] 			[int] 				 	NOT NULL,
	[TransactionStatusID] 	[nvarchar](20) 				NOT NULL,
	[TransactionTypeID] 	[nvarchar](20) 				NOT NULL,
	[TransactionDate] 		[datetime]				NOT NULL,
	[Notes] 				[nvarchar](500)		    NOT NULL,
	
	CONSTRAINT [pk_Transaction_TransactionID] PRIMARY KEY ([TransactionID] ASC),
	CONSTRAINT [fk_Transaction_EmployeeID] FOREIGN KEY ([EmployeeID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_Transaction_TransactionStatusID] FOREIGN KEY ([TransactionStatusID])
		REFERENCES [TransactionStatus]([TransactionStatusID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_Transaction_TransactionTypeID] FOREIGN KEY ([TransactionTypeID])
		REFERENCES [TransactionType]([TransactionTypeID])  ON UPDATE CASCADE
)
GO

/*
Created by: Jaeho Kim
Date: 02/27/2020
Comment: Inserts test data for the Transaction Table
*/
print ''  print '*** Inserting sample data into Transaction Table'
GO

Insert INTO [dbo].[Transaction]
	([EmployeeID], [TransactionStatusID], [TransactionTypeID], [TransactionDate], [Notes])
	Values
	(100000, 'tranStatus100','tranTYPE100', '2018-02-10', 'TRAN_NOTES100'),
	(100001, 'tranStatus200','tranTYPE200', '2017-02-06', 'TRAN_NOTES200'),
	(100002, 'tranStatus800','tranTYPE800', '2012-04-03', 'TRAN_NOTES800')
Go

/*
Created by: Jaeho Kim
Date: 2/27/2020
Comment: Create TransactionLine Table
*/

print '' print '*** Creating TransactionLine Table'
GO
CREATE TABLE [dbo].[TransactionLine](
	[TransactionID] 		[int] 		NOT NULL,
	[ProductID] 			[nvarchar](13) 	NOT NULL,
	[Quantity]				[int]			NOT NULL,
	
	CONSTRAINT [fk_TransactionLine_TransactionID] FOREIGN KEY ([TransactionID])
		REFERENCES [Transaction]([TransactionID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_TransactionLine_ProductID] FOREIGN KEY ([ProductID])
		REFERENCES [Product]([ProductID]) ON UPDATE CASCADE
)
GO

/*
Created by: Jaeho Kim
Date: 02/27/2020
Comment: Inserts test data for the TransactionLine Table
*/
print ''  print '*** Inserting sample data into TransactionLine Table'
GO

Insert INTO [dbo].[TransactionLine]
	([TransactionID], [ProductID], [Quantity])
	Values
	(1000, '7084781116', 5),
	(1000, '2500006153', 3),
	(1002, '2500006153', 9)
Go

/*
Created by: Jaeho Kim
Date: 2/27/2020
Comment: Selects a list of all transactions with join tables for the customer
*/
print '' print '*** Creating sp_select_all_transactions'
GO
CREATE PROCEDURE sp_select_all_transactions
AS
	BEGIN
		SELECT 	
		TL.[TransactionID]
		, TL.[Quantity]
		, P.[ProductName]
		, P.[Brand]
		, P.[Price]
		, T.[TransactionDate]
		, T.[TransactionTypeID]
		, T.[Notes]
		
		FROM 	[TransactionLine] TL
		INNER JOIN [Product] P
			ON TL.[ProductID] = P.[ProductID]
		INNER JOIN [Transaction] T
			ON TL.[TransactionID] = T.[TransactionID]
		INNER JOIN [TransactionType] TT
			ON TT.[TransactionTypeID] = T.[TransactionTypeID]
	END
GO

/*
Created by: Alex Diers
Date: 2/28/2020
Comment: Creates the table for Training Videos
*/
print '' print '*** Creating TrainingVideo Table'
GO

CREATE TABLE [dbo].[TrainingVideo](
	[TrainingVideoID] 		[nvarchar](150)				NOT NULL,
	[RunTimeMinutes] 		[int] 						NOT NULL,
	[RunTimeSeconds] 		[int] 						NOT NULL,
	[Description] 			[nvarchar] (1000) 			NOT NULL,
	CONSTRAINT [pk_TrainingVideoID] 			PRIMARY KEY ([TrainingVideoID] ASC)
)
GO

/*
Created by: Alex Diers
Date: 2/28/2020
Comment: Creates sample training video information
*/
print '' print '*** Creating Sample Training Video Records'
GO
INSERT INTO [dbo].[TrainingVideo]
	([TrainingVideoID], [RunTimeMinutes], [RunTimeSeconds], [Description])
	VALUES
    ('Link', 1, 25, 'Description'),
    ('AnotherLink', 2, 5, 'Another description')
GO

/*
Created by: Alex Diers
Date: 2/28/2020
Comment: Stored procedure to add a training video
*/
print '' print '*** Creating sp_insert_training_video'
GO
CREATE PROCEDURE [sp_insert_training_video]
(
	@TrainingVideoID	[nvarchar](150),
	@RunTimeMinutes		[int],
	@RunTimeSeconds 	[int],
	@Description 		[nvarchar](1000)
)
AS
BEGIN
	INSERT INTO [dbo].[TrainingVideo]
		([TrainingVideoID], [RunTimeMinutes], [RunTimeSeconds], [Description])
	VALUES
		(@TrainingVideoID, @RunTimeMinutes, @RunTimeSeconds, @Description)
	SELECT SCOPE_IDENTITY()
END
GO

/*
Created by: Alex Diers
Date: 2/28/2020
Comment: Stored procedure to select the videos to watch
*/
print '' print '*** Creating sp_select_videos_by_employee'
GO
CREATE PROCEDURE [sp_select_videos_by_employee]
AS
	BEGIN
	SELECT	[TrainingVideoID], [RunTimeMinutes], [RunTimeSeconds], [Description]
	FROM		[TrainingVideo]
	ORDER BY [TrainingVideoID]
END
GO

/*
Created by: Carl Davis
Date: 2/14/2020
Comment: Sproc to select facility maintenance by id
*/

print '' print '*** Creating sp_select_facility_maintenance_by_id'
GO
CREATE PROCEDURE [sp_select_facility_maintenance_by_id]
(
    @FacilityMaintenanceID                        	[int]

)
AS
BEGIN
    SELECT [FacilityMaintenanceID], [UserID], [MaintenanceName],
            [MaintenanceInterval], [MaintenanceDescription]
    FROM [dbo].[FacilityMaintenance] 
	WHERE [FacilityMaintenanceID] = @FacilityMaintenanceID

END
GO

/*
Created by: Carl Davis
Date: 2/14/2020
Comment: Sproc to select all facility maintenance
*/
print '' print '*** Creating sp_select_all_facility_maintenance'
GO
CREATE PROCEDURE [sp_select_all_facility_maintenance]
AS
BEGIN
    SELECT [FacilityMaintenanceID], [UserID], [MaintenanceName],
            [MaintenanceInterval], [MaintenanceDescription]
    FROM [dbo].[FacilityMaintenance] 
END
GO

/*
Created by: Carl Davis
Date: 2/14/2020
Comment: Sproc to select facility maintenance by user id
*/
print '' print '*** Creating sp_select_facility_maintenance_by_user_id'
GO
CREATE PROCEDURE [sp_select_facility_maintenance_by_user_id]
(
    @UserID                        	[int]

)
AS
BEGIN
    SELECT [FacilityMaintenanceID], [UserID], [MaintenanceName],
            [MaintenanceInterval], [MaintenanceDescription]
    FROM [dbo].[FacilityMaintenance] 
	WHERE [UserID] = @UserID

END
GO

/*
Created by: Carl Davis
Date: 2/14/2020
Comment: Sproc to select facility maintenance by name
*/
print '' print '*** Creating sp_select_facility_maintenance_by_name'
GO
CREATE PROCEDURE [sp_select_facility_maintenance_by_name]
(
    @MaintenanceName                        	[nvarchar](50)

)
AS
BEGIN
    SELECT [FacilityMaintenanceID], [UserID], [MaintenanceName],
            [MaintenanceInterval], [MaintenanceDescription]
    FROM [dbo].[FacilityMaintenance] 
	WHERE [MaintenanceName] = @MaintenanceName

END
GO

/*
Created by: Carl Davis
Date: 2/14/2020
Comment: Sproc to update facility maintenance
*/
print '' print '*** Creating sp_update_facility_maintenance '
GO
CREATE PROCEDURE [sp_update_facility_maintenance]
(
	@FacilityMaintenanceID          	[int],
    @OldUserID                        	[int],
    @OldMaintenanceName            		[nvarchar](50),
    @OldMaintenanceInterval         	[nvarchar](20),
    @OldMaintenanceDescription     		[nvarchar](250),
	@NewUserID                        	[int],
    @NewMaintenanceName            		[nvarchar](50),
    @NewMaintenanceInterval         	[nvarchar](20),
    @NewMaintenanceDescription     		[nvarchar](250)

)
AS
BEGIN
    UPDATE 	[dbo].[FacilityMaintenance]
	SET 	[UserID] = @NewUserID,
			[MaintenanceName] = @NewMaintenanceName,
			[MaintenanceInterval] = @NewMaintenanceInterval,
			[MaintenanceDescription] = @NewMaintenanceDescription
			
	WHERE   [FacilityMaintenanceID] = @FacilityMaintenanceID
		AND	[UserID] = @OldUserID
		AND	[MaintenanceName] = @OldMaintenanceName
		AND	[MaintenanceInterval] = @OldMaintenanceInterval
		AND	[MaintenanceDescription] = @OldMaintenanceDescription
	 RETURN @@ROWCOUNT

END
GO