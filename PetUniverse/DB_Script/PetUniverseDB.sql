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
[addressLineOne] [nvarchar](250) NOT NULL,
[addressLineTwo] [nvarchar](250) NULL,
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
[City],
[State],
[Zipcode],
[addressLineOne],
[addressLineTwo]
)
VALUES
('Zach', 'Behrensmeyer', '1234567890', 'zbehrens@PetUniverse.com', 'Cedar Rapids','IA','52433','J street NE','APT3'),
('Steven', 'Cardona', '2234567890', 'scardona@PetUniverse.com', 'Cedar Rapids','IA','52433','J street NE','APT3'), 
('Thomas', 'Dupuy', '3234567890', 'tdupuy@PetUniverse.com', 'Cedar Rapids','IA','52433','J street NE','APT3'),
('Mohamed','Elamin' ,'3198376522','moals@PetUniverse.com','Cedar Rapids','IA','52433','J street NE','APT3'),
('Austin','Gee','1234567890','Austin@email.com','Cedar Rapids','IA','52404','J street NE','APT3'),
('Bill','Buffalo','1234567890','Bill@email.com','Cedar Rapids','IA','52404','J street NE', null),
('Brad','Bean','1234567890','Brad@email.com','Iowa City','IA','52404','J street NE','APT3'),
('Barb','Brinoll','1234567890','Barb@email.com','Cedar Rapids','IA','52404','J street NE',null),	
('Awaab','Elamin','3192104964','Awaab@Awaaab.com','Cedar Rapids','IA','52404','J street NE','APT3'),
('Ryan', 'Morganti', '5554443333', 'ryanm@PetUniverse.com', 'Cedar Rapids', 'IA', '52402','J street NE','APT3'),
('Derek', 'Taylor', '9992234343', 'derekt@PetUniverse.com', 'Manchester', 'IA', '524404','J street NE','APT3'),
('Steven', 'Coonrod', '9992555343', 'stevec@PetUniverse.com', 'Hiawatha', 'IA', '524409','J street NE','APT3')
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
		[addressLineOne],
		[addressLineTwo],
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
	@Address1 [nvarchar](250),
	@Address2 [nvarchar](250),
	@City [nvarchar](20),
	@State [nvarchar](2),
	@Zipcode [nvarchar](15)
)
AS
Begin
	INSERT INTO [dbo].[User]
		([FirstName], [LastName],[PhoneNumber],[Email],[addressLineOne],[addressLineTwo],[City],[State],[Zipcode])
	VALUES
		(@FirstName, @LastName, @PhoneNumber, @Email, @Address1, @Address2, @City, @State, @Zipcode)
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
	[CurrentlyHoused]	[bit]						NOT NULL 	DEFAULT 0,
	[Adoptable]			[bit]						NOT NULL	DEFAULT 0,
	[Active]			[bit]						NOT NULL	DEFAULT 1,
	[AnimalSpeciesID]	[nvarchar](100)				NOT NULL,
	CONSTRAINT [pk_AnimalID] PRIMARY KEY([AnimalID] ASC),
	CONSTRAINT [fk_Animal_AnimalSpeciesID] FOREIGN KEY([AnimalSpeciesID])
		REFERENCES [AnimalSpecies]([AnimalSpeciesID])
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
	([AnimalName],[Dob],[AnimalBreed],[ArrivalDate],[CurrentlyHoused],[Adoptable],[Active],[AnimalSpeciesID])
	VALUES
	('Paul','12-01-2015','Pit Bull','01-20-2020',1,1,1,'Cat'),
	('Snowball II','10-05-2011','Tabby','11-24-2019',0,0,1,'Cat'),
	('Lassie','04-23-2018','Collie','01-12-2020',1,1,1,'Dog'),
	('Spot','08-14-2014','French Bulldog','05-10-2019',1,1,1,'Dog'),
	('fluffs','06-21-2012','Siamese','04-11-2019',0,1,1,'Rat'),
	('Doggo','03-06-2015','Shih Tzu','02-22-2019',1,1,0,'Dog')
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
	@AnimalSpeciesID	[nvarchar](100)
)
AS
BEGIN
	INSERT INTO [dbo].[Animal]
		([AnimalName],[Dob],[AnimalBreed],[ArrivalDate],[AnimalSpeciesID])
	VALUES
		(@AnimalName, @Dob, @AnimalBreed, @ArrivalDate, @AnimalSpeciesID)
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
	SELECT [AnimalID],[AnimalName],[Dob],[AnimalBreed],[ArrivalDate],
	[CurrentlyHoused],[Adoptable],[Active],[AnimalSpeciesID]
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
Comment: This adds some ample user records to the database.
*/
-- print '' print '*** Creating Sample User Records'
-- GO
-- INSERT INTO [dbo].[User]
-- 	([FirstName],[LastName],[PhoneNumber],[Email],[City],[State],[Zipcode])
-- 	VALUES
-- 	('Austin','Gee','1234567890','Austin@email.com','Cedar Rapids','IA','52404'),
-- 	('Bill','Buffalo','1234567890','Bill@email.com','Cedar Rapids','IA','52404'),
-- 	('Brad','Bean','1234567890','Brad@email.com','Iowa City','IA','52404'),
-- 	('Barb','Brinoll','1234567890','Barb@email.com','Cedar Rapids','IA','52404')
-- GO

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
	(100003)
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Adds Animal records to the Animal table
*/
print '' print '*** Creating Sample Animal Records'
GO
INSERT INTO [dbo].[Animal]
	([AnimalName],[Dob],[AnimalSpeciesID],[AnimalBreed],[ArrivalDate])
	VALUES
	('Spot','07-12-1984','Dog','Blood Hound','10-10-2019'),
	('Spit','07-12-1984','Cat','Tabby','10-10-2019'),
	('Simon','07-12-1984','Rat','Siamese','10-10-2019')
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
	(100002,1000002,'Waitng for Pickup','2019-10-9')
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
	WHERE	[AppointmentTypeID] = "inHomeInspection"
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
	[DateCreated]			[Datetime]					NOT NUll,
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
		REFERENCES [dbo].[AdoptionApplication]([AdoptionApplicationID])
)
GO
print '' print '*** Inserting CustomerAnswer records'
GO
INSERT INTO [dbo].[CustomerAnswer]
([QuestionID],[CustomerID],[AdoptionApplicationID],[Answer])
VALUES
(
	1000000,100000,100000,'Question 1'
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
			[CurrentlyHoused] ,
			[Adoptable],
			[Active] ,
			[AnimalSpeciesID]			
	FROM 	[dbo].[Animal]
	WHERE	[AnimalID] = @animalId;	
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

/*
Created by: Tener Karar
Date: 02/27/2020
Comment: inserting ItemCategory sample data
*/
print '' print '*** inserting ItemCategory sample data'
GO
INSERT INTO [dbo].[ItemCategory]
([ItemCategoryID],[Description])

VALUES
( 'cat',' Litter-Robot 3 is the highest-rated automatic,
 self-cleaning litter box for cats. 
 Never scoop cat litter again while giving your kitty a clean
 bed of litter for each use. Litter-Robot ')
Go
/*
Created by: Tener Karar
Date: 02/27/2020
Comment: inserting Item sample data
*/
print '' print '*** inserting Item sample data'
GO
INSERT INTO [dbo].[Item] 
	([ItemName], [ItemQuantity], [ItemCategoryID], [ItemDescription] )
VALUES
	('loon', 1, 'cat',' Litter-Robot 3 is the highest-rated automatic,
 self-cleaning litter box for cats. 
 Never scoop cat litter again while giving your kitty a clean
 bed of litter for each use. Litter-Robot ' )
	
go
/*
Created by: Tener Karar
Date: 02/27/2020
Comment: inserting Item Location table data
*/
print '' print '*** creating ItemLocation table'
GO

CREATE TABLE [dbo].[ItemLocation] (
	[LocationID]	    [int] IDENTITY(1000,1) 	    NOT NULL,
	[Description]      [nvarchar]     (50) 			  	NOT NULL,
	
	CONSTRAINT [pk_invLocationID] PRIMARY KEY([LocationID] ASC),
	
)
GO
/*
Created by: Tener Karar
Date: 02/27/2020
Comment: inserting Item Location sample data
*/
print '' print '*** inserting ItemLocation sample data'
GO
INSERT INTO [dbo].[ItemLocation] 
	( [Description]  )
VALUES
	(' in the first floor ' ),
	(' in the first floor ' ),
	(' in the first floor ' ),
	(' in the first floor ' ),
	(' in the first floor ' ),
	(' in the first floor ' )
	
	
Go	
/*
Created by: Tener Karar
Date: 02/27/2020
Comment: creating Item Location Line table'
*/
  print '' print '*** creating ItemLocationLine table'
GO
CREATE TABLE [dbo].[ItemLocationLine] (
    [ItemID]		     [int]                 	    NOT NULL,
	[LocationID]	    [int]             	    NOT NULL,
	
	CONSTRAINT [fk_ItemID] FOREIGN KEY([ItemID]) 
	REFERENCES [Item]([ItemID]),
	CONSTRAINT [fk_LocationID] FOREIGN KEY([LocationID]) 
	REFERENCES [ItemLocation]([LocationID])
	
	
	
)
GO 
/*
Created by: Tener Karar
Date: 02/27/2020
Comment:  inserting Item Location Line table'
*/
print '' print '*** inserting ItemLocationLine sample data'
GO
INSERT INTO [dbo].[ItemLocationLine] 
	([ItemID]	,[LocationID]  )
VALUES
	( 100002, 1000 )
	
Go	
/*
Created by: Tener Karar
Date: 02/16/2020
Comment:retrieve ItemLocations List
*/
print '' print '*** Creating sp_retrieve_ItemLocations_List'
GO
CREATE PROCEDURE sp_retrieve_ItemLocations_List( @ItemID int)
AS
BEGIN
	SELECT  [LocationID]	 
	FROM [dbo].[ItemLocationLine ]
	where ItemID = @ItemID
	  
	 
	
END
GO
/*
Created by: Tener Karar and Brandyn Coverdill
Date: 02/16/2020
Comment:retrieve Item List
*/
print '' print '*** Creating sp_retrieve_item_list'
GO
CREATE PROCEDURE sp_retrieve_item_list
AS
BEGIN
	SELECT [ItemID], [ItemName]	,[ItemQuantity] ,[ItemCategoryID] 
	FROM [dbo].[Item ]
	  
	 
	
END
GO

/*
Created by: Tener Karar
Date: 02/16/2020
Comment:retrieve ItemCategory List
*/
print '' print '*** Creating sp_retrieve_ItemCategory_list'
GO
CREATE PROCEDURE sp_retrieve_ItemCategory_list
AS
BEGIN
	SELECT [ItemCategoryID] ,[Description]
	FROM [dbo].[ItemCategory ]
	  
	 
	
END
GO
/*
Created by: Tener Karar
Date: 02/16/2020
Comment:update Item Location
*/
print '' print '*** Creating sp_update_Item_Location'
GO
CREATE PROCEDURE [sp_update_Item_Location]
(


	@ItemID	         	[int ],
	@NewLocationID		[int],
	
	@OldLocationID		[int]
	

)
AS
BEGIN
	UPDATE [dbo].[ItemLocationLine]
		SET [LocationID] = 	@NewLocationID
			
	WHERE 	[ItemID] =	   @ItemID  
	  AND	[LocationID] = 	@OldLocationID

	 
	RETURN @@ROWCOUNT
END
GO
 
/*
Created By: Timothy Lickteig
Date: 2/07/2020
Comment: Table for volunteer shifts
*/
print '' print '*** Creating VolunteerShift Table'
go

create table [dbo].[VolunteerShift](
	
	[VolunteerShiftID] 	[int] identity(1000000, 1) 	not null,
	[ShiftDescription] 	[nvarchar](1080) 			not null,
	[ShiftTitle] 		[nvarchar](500) 			not null,
	[ShiftDate]			[date]						not null,
	[ShiftStartTime] 	[time] 						not null,
	[ShiftEndTime] 		[time] 						not null,
	[Recurrance] 		[nvarchar](100) 			not null,
	[IsSpecialEvent] 	[bit] 						not null,
	[ShiftNotes] 		[nvarchar](1080) 			null,
	[ScheduleID] 		[int] 						not null,
	constraint [pk_VolunteerShift_VolunteerShiftID] primary key([VolunteerShiftID] asc)
)
go

/*
Created By: Timothy Lickteig
Date: 2/07/2020
Comment: Sample data for volunteer shifts
*/
print '' print '*** Creating Volunteer Shift records'
go

insert into [dbo].[VolunteerShift]
	([ShiftDescription], [ShiftTitle], [ShiftDate],
	[ShiftStartTime], [ShiftEndTime], [Recurrance],
	[IsSpecialEvent], [ShiftNotes] ,[ScheduleID])
	values
	('This is the first shift', 'Its a pretty cool shift', '2020-01-01','13:30:00', '15:00:00', 'None', 0, 'Any notes go here', 0),
	('This is the second shift', 'Its an even cooler shift', '2009-08-07','12:00:00', '13:00:00', 'None', 0, 'Any other notes go here', 0)
go

/*
Created By: Timothy Lickteig
Date: 2/07/2020
Comment: Procedure for inserting volunteer shifts
*/
print '' print '*** Creating procedure sp_insert_volunteer_shift'
go

create procedure [sp_insert_volunteer_shift]
(
	@ShiftDescription 	[nvarchar](1080),
	@ShiftTitle 		[nvarchar](500),
	@ShiftDate 			[date],
	@ShiftStartTime 	[time],
	@ShiftEndTime 		[time],
	@Recurrance 		[nvarchar](100),
	@IsSpecialEvent 	[bit],
	@ShiftNotes 		[nvarchar](1080),
	@ScheduleID 		[int]
)
as
begin
	
	insert into [dbo].[VolunteerShift]
		([ShiftDescription], [ShiftTitle], [ShiftDate],
		[ShiftStartTime], [ShiftEndTime], [Recurrance], 
		[IsSpecialEvent], [ShiftNotes], [ScheduleID])
		values
		(@ShiftDescription, @ShiftTitle, @ShiftDate,
		@ShiftStartTime, @ShiftEndTime, @Recurrance, 
		@IsSpecialEvent, @ShiftNotes, @ScheduleID)
end
go	

/*
Created By: Timothy Lickteig
Date: 2/05/2020
Comment: Procedure for deleting a volunteer shift
*/
print '' print '*** Creating procedure sp_delete_volunteer_shift'
go

create procedure [sp_delete_volunteer_shift]
(
	@ShiftID [int]
)
as
begin
	
	delete from [dbo].[VolunteerShift]
	where [VolunteerShiftID] = @ShiftID
end
go

print '' print '*** Creating procedure sp_edit_volunteer_shift'
go

/*
Created By: Timothy Lickteig
Date: 2/10/2020
Comment: Procedure for updating a volunteer shift
*/
create procedure [sp_update_volunteer_shift]
(
	@VolunteerShiftID [int],
	@ShiftDescription [nvarchar](1080),
	@ShiftDate [date],
	@ShiftTitle [nvarchar](500),
	@ShiftStartTime [time],
	@ShiftEndTime [time],
	@Recurrance [nvarchar](100),
	@IsSpecialEvent [bit],
	@ShiftNotes [nvarchar](1080),
	@ScheduleID [int]	
)
as
begin
	
	update [VolunteerShift]
	set [ShiftDescription] = @ShiftDescription,
	[ShiftDate] = @ShiftDate,
	[ShiftTitle] = @ShiftTitle,
	[ShiftStartTime] = @ShiftStartTime,
	[ShiftEndTime] = @ShiftEndTime,
	[Recurrance] = @Recurrance,
	[IsSpecialEvent] = @IsSpecialEvent,
	[ShiftNotes] = @ShiftNotes,
	[ScheduleID] = @ScheduleID
	where [VolunteerShiftID] = @VolunteerShiftID
	select @@ROWCOUNT
end
go

/*
Created By: Timothy Lickteig
Date: 2/17/2020
Comment: Procedure for selecting all volunteer shifts
*/
print '' print '*** Creating procedure sp_select_all_volunteer_shifts'
go

create procedure [sp_select_all_volunteer_shifts]
as
begin
	select
		[VolunteerShiftID], [ShiftDescription],
		[ShiftTitle], [ShiftStartTime], [ShiftEndTime],
		[Recurrance], [IsSpecialEvent], [ShiftNotes],
		[ShiftDate], [ScheduleID]
	from [dbo].[VolunteerShift]
end
go

/*
Created By: Chuck Baxter
Date: 2/28/2020
Comment: select animal species
*/
print '' print '*** Creating procedure sp_select_animal_species'
GO

CREATE PROCEDURE [sp_select_animal_species]
AS
BEGIN
SELECT 	[AnimalSpeciesID]
FROM	[dbo].[AnimalSpecies]
END
GO

/*
Created By: Steve Coonrod
Date: 		2/9/2020
Comment:	Table for storing Event Types
*/
print '' print '*** Creating EventType Table'
GO
CREATE TABLE[dbo].[EventType](
	[EventTypeID]		[nvarchar](50)							NOT NULL,
	[Description]		[nvarchar](100)							NOT NULL,--Changed from nvarchar 50 to 100
	
	CONSTRAINT [pk_eventTypeID]			PRIMARY KEY([EventTypeID])
)
GO

/*
Created by: Steve Coonrod
Date: 		2/9/2020
Comment: 	This is the Event Table. It holds all the needed data for an Event.
*/
print '' print '*** Creating Event Table'
GO
CREATE TABLE [dbo].[Event](
	[EventID]			[int]			IDENTITY(1000000,1)		NOT NULL,
	[CreatedByID]		[int]									NOT NULL,
	[DateCreated]		[datetime]								NOT NULL,
	[EventName]			[nvarchar](150)							NOT NULL,
	[EventTypeID]		[nvarchar](50)							NOT NULL,
	[EventDateTime]		[datetime]								NOT NULL,
	[EventAddress]		[nvarchar](200)							NOT NULL,
	[EventCity]			[nvarchar](50)							NOT NULL,
	[EventState]		[nvarchar](50)							NOT NULL,
	[EventZipcode]		[nvarchar](15)							NOT NULL,
	[EventPictureFileName]	[nvarchar](250)						NOT NULL,
	[Status]			[nvarchar](50)							NOT NULL,
	[Description]		[nvarchar](500)							NOT NULL,

	CONSTRAINT [pk_eventID]				PRIMARY KEY([EventID]ASC),
	--CONSTRAINT [fk_event_user]			FOREIGN KEY([CreatedByID])
		--REFERENCES [User]([UserID]),
	CONSTRAINT [fk_event_eventType]		FOREIGN KEY([EventTypeID])
		REFERENCES [EventType]([EventTypeID]) ON UPDATE CASCADE
)
GO
--Index to search by the event's datetime
print '' print '  > Adding indexes to Event table'
GO
CREATE NONCLUSTERED INDEX [ix_eventDateTime]
	ON [Event]([EventDateTime]ASC)
GO
--Index to search by the events status
CREATE NONCLUSTERED INDEX [ix_eventStatus]
	ON [Event]([Status]ASC)
GO

/*
	Created by: Steve Coonrod
	Date: 		2/9/2020
	Comment: 	This is the Event Request table. 
				It is a table for joining an Event to a Request
				This will be used mostly by the DC to view requests 
				for events made by other members
*/
print '' print '*** Creating EventRequest Table'
GO
CREATE TABLE[dbo].[EventRequest](
	[EventID]			[int]									NOT NULL,
	[RequestID]			[int]									NOT NULL,
	[ReviewerID]		[int]									NULL,
	[DisapprovalReason]	[nvarchar](500)							NULL,
	[DesiredVolunteers]	[int]									NOT NULL,
	[Active]			[bit]									NOT NULL 	DEFAULT 1,
	
	CONSTRAINT [pk_eventRequest_Event_Request] PRIMARY KEY([EventID],[RequestID]),
	CONSTRAINT [fk_eventRequest_eventID] FOREIGN KEY([EventID])
		REFERENCES [Event]([EventID]) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT [fk_eventRequest_requestID] FOREIGN KEY([RequestID])
		REFERENCES [request]([RequestID]) ON UPDATE CASCADE ON DELETE CASCADE
	--CONSTRAINT [fk_eventRequest_reviewerID] FOREIGN KEY([ReviewerID])
		--REFERENCES [Employee]([EmployeeID]) ON UPDATE CASCADE
)
GO

--Stored Procedures for Event Processes
/*
	Created by: Steve Coonrod
	Date: 		2/9/2020
	Comment: 	Stored Procedure for adding a new event to the DB
*/
print '' print '*** Creating sp_insert_event'
GO
CREATE PROCEDURE [sp_insert_event]
(
	@CreatedByID				[int],
	@DateCreated				[datetime],
	@EventName					[nvarchar](150),
	@EventTypeID				[nvarchar](50),
	@EventDateTime				[datetime],
	@EventAddress				[nvarchar](200),
	@EventCity					[nvarchar](50),
	@EventState					[nvarchar](50),
	@EventZipcode				[nvarchar](15),
	@EventPictureFileName		[nvarchar](250),
	@Status						[nvarchar](50),
	@Description				[nvarchar](500)
)
AS 
BEGIN
	INSERT INTO [dbo].[Event]
		([CreatedByID],[DateCreated],[EventName],[EventTypeID],[EventDateTime],[EventAddress],
		[EventCity],[EventState],[EventZipcode],[EventPictureFileName],[Status],[Description])
	VALUES
		(@CreatedByID,@DateCreated,@EventName,@EventTypeID,@EventDateTime,@EventAddress,
		@EventCity,@EventState,@EventZipcode,@EventPictureFileName,@Status,@Description)
	SELECT SCOPE_IDENTITY()
END
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for editing an event in the DB
*/
print '' print '*** Creating sp_update_event'
GO
CREATE PROCEDURE [sp_update_event]
(
	@EventID					[int],
	@OldCreatedByID				[int],
	@OldDateCreated				[datetime],
	@OldEventName				[nvarchar](150),
	@OldEventTypeID				[nvarchar](50),
	@OldEventDateTime			[datetime],
	@OldEventAddress			[nvarchar](200),
	@OldEventCity				[nvarchar](50),
	@OldEventState				[nvarchar](50),
	@OldEventZipcode			[nvarchar](15),
	@OldEventPictureFileName	[nvarchar](250),
	@OldStatus					[nvarchar](50),
	@OldDescription				[nvarchar](500),
	@NewCreatedByID				[int],
	@NewDateCreated				[datetime],
	@NewEventName				[nvarchar](150),
	@NewEventTypeID				[nvarchar](50),
	@NewEventDateTime			[datetime],
	@NewEventAddress			[nvarchar](200),
	@NewEventCity				[nvarchar](50),
	@NewEventState				[nvarchar](50),
	@NewEventZipcode			[nvarchar](15),
	@NewEventPictureFileName	[nvarchar](250),
	@NewStatus					[nvarchar](50),
	@NewDescription				[nvarchar](500)
)
AS
BEGIN
UPDATE  	[dbo].[Event]
	SET		[CreatedByID] = @NewCreatedByID,
			[DateCreated] = @NewDateCreated,
			[EventName] = @NewEventName,
			[EventTypeID] = @NewEventTypeID,
			[EventDateTime] = @NewEventDateTime,
			[EventAddress] = @NewEventAddress,
			[EventCity] = @NewEventCity,
			[EventState] = @NewEventState,
			[EventZipcode] = @NewEventZipcode,
			[EventPictureFileName] = @NewEventPictureFileName,
			[Status] = @NewStatus,
			[Description] = @OldDescription
			
	WHERE 	[EventID] = @EventID
		AND	[CreatedByID] = @OldCreatedByID
		AND	[DateCreated] = @OldDateCreated
		AND	[EventName] = @OldEventName
		AND	[EventTypeID] = @OldEventTypeID
		AND	[EventDateTime] = @OldEventDateTime
		AND	[EventAddress] = @OldEventAddress
		AND	[EventCity] = @OldEventCity
		AND	[EventState] = @OldEventState
		AND	[EventZipcode] = @OldEventZipcode
		AND	[EventPictureFileName] = @OldEventPictureFileName
		AND	[Status] = @OldStatus
		AND	[Description] = @OldDescription
	RETURN	@@ROWCOUNT
END
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for retrieving an Event from the DB
*/
print '' print '*** Creating sp_select_event_by_ID'
GO
CREATE PROCEDURE [sp_select_event_by_ID]
(
	@EventID			[int]
)
AS
BEGIN
	SELECT [CreatedByID],[DateCreated],[EventName],[EventTypeID],
		   [EventDateTime],[EventAddress],[EventCity],[EventState],[EventZipcode],
		   [EventPictureFileName],[Status],[Description]
	FROM   [dbo].[Event]
	WHERE  [EventID] = @EventID
	RETURN @@ROWCOUNT
END
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for retrieving a List of All Event from the DB
*/
print '' print '*** Creating sp_select_all_events'
GO
CREATE PROCEDURE [sp_select_all_events]
AS
BEGIN
	SELECT [EventID],[CreatedByID],[DateCreated],[EventName],[EventTypeID],
		   [EventDateTime],[EventAddress],[EventCity],[EventState],[EventZipcode],
		   [EventPictureFileName],[Status],[Description]
	FROM   [dbo].[Event]
END
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for deleting an Event from the DB 
		ADMIN ONLY
*/
print '' print '*** Creating sp_delete_event'
GO
CREATE PROCEDURE [sp_delete_event]
(
	@EventID		[int]
)
AS
BEGIN
	DECLARE @requestID [int]
	SET @requestID = (SELECT 	[dbo].[EventRequest].[RequestID]
					  FROM 		[dbo].[EventRequest]
					  WHERE 	[EventID] = @EventID)
	
	DELETE FROM [dbo].[EventRequest] WHERE [EventID] = @EventID
	DELETE FROM [dbo].[Request] WHERE [RequestID] = @requestID
	DELETE FROM [dbo].[Event] WHERE [EventID] = @EventID
	RETURN @@ROWCOUNT
END
GO

--EventType Procedures ADMIN ONLY
/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for adding a new event type to the DB
*/
print '' print '*** Creating sp_insert_event_type'
GO
CREATE PROCEDURE [sp_insert_event_type]
(
	@EventTypeID				[nvarchar](50),
	@Description				[nvarchar](100)
)
AS 
BEGIN
	INSERT INTO [dbo].[EventType]
		([EventTypeID],[Description])
	VALUES
		(@EventTypeID, @Description)
	RETURN @@ROWCOUNT
END 
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for retrieving all event types in the DB
*/
print '' print '*** Creating sp_select_all_event_types'
GO
CREATE PROCEDURE [sp_select_all_event_types]
AS 
BEGIN
	SELECT  [EventTypeID],[Description]
	FROM	[dbo].[EventType]
END
GO

--EventRequest Procedures
/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for adding a new Event Request to the DB
*/
print '' print '*** Creating sp_insert_event_request'
GO
CREATE PROCEDURE [sp_insert_event_request]
(
	@EventID					[int],
	@RequestID					[int],
	@ReviewerID					[int],
	@DisapprovalReason			[nvarchar](500),
	@DesiredVolunteers			[int],
	@Active						[bit]
)
AS
BEGIN
	INSERT INTO [dbo].[EventRequest]
		([EventID],[RequestID],[ReviewerID],[DisapprovalReason],[DesiredVolunteers],[Active])
	VALUES
		(@EventID, @RequestID, @ReviewerID, @DisapprovalReason, @DesiredVolunteers, @Active)
	RETURN @@ROWCOUNT
END
GO

--Request Procedures
/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for adding a new Request to the DB
*/
print '' print '*** Creating sp_insert_request'
GO
CREATE PROCEDURE [sp_insert_request]
(
	@RequestID			[int] OUTPUT,
	@DateCreated		[datetime],
	@RequestTypeID		[nvarchar](50)
)
AS
BEGIN
	INSERT INTO [dbo].[request]
		([DateCreated],[RequestTypeID])
	VALUES
		(@DateCreated, @RequestTypeID)
	SELECT @RequestID = SCOPE_IDENTITY()
END
GO

--Event Sample Data
/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Sample Data for the EventType Table
*/
print '' print '*** Creating Sample Data for the EventType table'
GO
INSERT INTO [dbo].[EventType]
	([EventTypeID],[Description])
	VALUES
	('Fundraiser','An event held to raise funding for a specific cause.'),
	('Awareness','An event held to raise awareness for a specific issue.'),
	('Adoption','An event held to showcase animals who are available for adoption or sponsorship.')
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Sample Data for the Event Table
*/
print '' print '*** Creating Sample Data for the Event table'
GO
INSERT INTO [dbo].[Event]
	([CreatedByID],[DateCreated],[EventName],[EventTypeID],[EventDateTime],[EventAddress],
	[EventCity],[EventState],[EventZipcode],[EventPictureFileName],[Status],[Description])
	VALUES
	(100002, '01/10/18 6:00:00', 'ZappyBs Animal House','Fundraiser','01/23/19 6:30:00.000','123 Doreyme Street',
		'Boulder','CO','80663','ZappyBsAnimalHouse.jpg','Completed',
		'ZappyBs Animal House is an annual event that raises funds to sponsor the ABC Animal Shelter.'),
	(100002, '01/10/18 6:00:00', 'Lets Paws A Minute','Awareness','04/23/19 15:30:00.000','2424 A Street',
		'Cedar Rapids','IA','52402','default.png','PendingApproval',
		'Lets Paws A Minute is an event for raising awareness about canine diabetis.')
GO

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Sample Data for the RequestType Table
*/
print '' print '*** Creating Sample Data for the RequestType table'
GO
INSERT INTO [dbo].[RequestType]
	([RequestTypeID],[Description])
	VALUES
	('Event','A request to host an event sponsored by Pet Universe.')
GO

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: General request response table, used to track request comments and respones ************************************************DOUBLE CHECK WITH DEREK
made by various users
*/
print '' print '*** creating request response table'
GO
CREATE TABLE [dbo].[RequestResponse] (
	[RequestID]				[int]						NOT NULL,
	[UserID]				[int]						NOT NULL,
	[Response]				[nvarchar](4000)			NOT NULL,
	[ResponseTimeStamp]		[datetime]					NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [pk_response_RequestID] PRIMARY KEY([RequestID] ASC),
	CONSTRAINT [fk_response_RequestID] FOREIGN KEY([RequestID]) REFERENCES [request]([RequestID]),
	CONSTRAINT [fk_requestResponse_UserID] FOREIGN KEY ([UserID]) REFERENCES[User]([UserID])
)
GO



/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Department request table, used to track inter-department requests
*/
print '' print '*** creating department request table'
GO
CREATE TABLE [dbo].[DepartmentRequest] (
	[DeptRequestID]			[int]						NOT NULL,
	[RequestingUserID]		[int]						NOT NULL,
	[RequestGroupID]		[nvarchar](50)				NOT NULL,
	[RequestedGroupID]		[nvarchar](50)				NOT NULL,
	[DateAcknowledged]		[datetime]					NULL,
	[AcknowledgingUserID]	[int]						NULL,
	[DateCompleted]			[datetime]					NULL,
	[CompletedUserID]		[int]						NULL,
	[RequestSubject]		[nvarchar](100)				NOT NULL,
	[RequestTopic]			[nvarchar](250)				NOT NULL,
	[RequestBody]			[nvarchar](4000)			NOT NULL,
	CONSTRAINT [pk_DeptRequest_RequestID] PRIMARY KEY([DeptRequestID] ASC),
	CONSTRAINT [fk_DeptartmentRequest_DeptRequestID] FOREIGN KEY([DeptRequestID])
		REFERENCES [request]([RequestID]),	
	CONSTRAINT [fk_RequestingUserID] FOREIGN KEY ([RequestingUserID]) REFERENCES[User]([UserID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_Department_RequestGroupID] FOREIGN KEY([RequestGroupID])
		REFERENCES [Department]([DepartmentID]),
	CONSTRAINT [fk_Department_RequestedGroupID] FOREIGN KEY([RequestedGroupID])
		REFERENCES [Department]([DepartmentID]),
	CONSTRAINT [fk_UserID_AcknowledgingUserID] FOREIGN KEY([AcknowledgingUserID])
		REFERENCES [User]([UserID]),
	CONSTRAINT [fk_UserID_CompletedUserID] FOREIGN KEY([CompletedUserID])
		REFERENCES [User]([UserID])
)
GO

/*
Created by: Ryan Morganti
Date: 2020/02/21
Comment: EmployeeRole table for linking Employees and Departments
*/
print '' print '*** creating EmployeeDepartment table'
GO
CREATE TABLE [dbo].[EmployeeDepartment] (
	[EmployeeID]			[int]						NOT NULL,
	[DepartmentID]			[nvarchar](50)				NOT NULL,
	CONSTRAINT [pk_EmployeeDepartment_EmployeeID_DepartmentID] PRIMARY KEY([EmployeeID], [DepartmentID] ASC),
	CONSTRAINT [fk_EmployeeDepartment_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES[User]([UserID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_EmployeeDepartment_DepartmentID] FOREIGN KEY ([DepartmentID]) REFERENCES[Department]([DepartmentID]) ON UPDATE CASCADE
)
GO


/*
Created by: Ryan Morganti
Date: 2020/02/21
Comment: Sample RoleID 'Employee'
*/
print '' print '*** Inserting Sample Role record Employee'
GO
INSERT INTO [dbo].[Role]
	([RoleID], [Description])
	VALUES
	('Employee', 'A Pet Universe Employee')
GO

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Sample Department Data
*/
print '' print '*** Inserting Sample Department Records'
GO
INSERT INTO [dbo].[Department]
	([DepartmentID], [Description])
	VALUES
	('Management', 'Management Description'),
	('Inventory', 'Inventory Description'),
	('CustomerService', 'CustomerService Description')
GO


/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Sample RequestType Data
*/
print '' print '*** Inserting Sample RequestTpe Records'
GO
INSERT INTO [dbo].[RequestType]
	([RequestTypeID], [Description])
	VALUES
	('General', 'Multi-purpose request format'),
	('TimeOff', 'Schedule time off')
GO


/*
Created by: Steve Coonrod
Date: 2020/02/06
Comment: Sample Employee Data
*/
print '' print '*** Inserting Sample Request Records'
GO
INSERT INTO [dbo].[Employee]
	([FirstName])
	VALUES
	('Billy')
GO



/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Sample Request Data
*/
print '' print '*** Inserting Sample Request Records'
GO
INSERT INTO [dbo].[request]
	([DateCreated], [RequestTypeID], [EffectiveStart],[RequestingEmployeeID])
	VALUES
	('20200206 11:00:00 AM', 'General', GETDATE(), 1000000),
	('20200207 12:55:01 PM', 'General', GETDATE(), 1000000),
	('20200208 01:02:03 PM', 'General', GETDATE(), 1000000),
	('20200207 12:55:01 PM', 'General', GETDATE(), 1000000),
	('20200208 01:02:03 PM', 'General', GETDATE(), 1000000),
	('20200206 03:02:03 PM', 'General', GETDATE(), 1000000)
GO 


/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Stored Procedure for selecting new requests associated with a DepartmentID
*/
print '' print '*** Creating sp_select_new_requests_by_departmentID'
GO
CREATE PROCEDURE [sp_select_new_requests_by_departmentID]
(
	@DepartmentID				[nvarchar](50)
)
AS
BEGIN
	SELECT DISTINCT[RequestID], [DateCreated], [RequestTypeID],
		[RequestingUserID], [RequestGroupID], [RequestedGroupID],
		[RequestSubject], [RequestTopic], [RequestBody]
	FROM [request] JOIN [DepartmentRequest] ON
		[RequestID] = [DeptRequestID]
	WHERE ([RequestGroupID] = @DepartmentID AND [DateAcknowledged] is NULL) OR
		([DateAcknowledged] is NULL AND [RequestedGroupID] = @DepartmentID)
END
GO

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Stored Procedure for selecting active requests associated with a DepartmentID
*/
print '' print '*** Creating sp_select_active_requests_by_departmentID'
GO
CREATE PROCEDURE [sp_select_active_requests_by_departmentID]
(
	@DepartmentID				[nvarchar](50)
)
AS
BEGIN
	SELECT DISTINCT[RequestID], [DateCreated], [RequestTypeID],
		[RequestingUserID], [RequestGroupID], [RequestedGroupID],
		[DateAcknowledged], [AcknowledgingUserID], [RequestSubject],
		[RequestTopic], [RequestBody]
	FROM [request] JOIN [DepartmentRequest] ON
		[RequestID] = [DeptRequestID]
	WHERE ([RequestGroupID] = @DepartmentID OR [RequestedGroupID] = @DepartmentID) AND 
		([DateAcknowledged] is NOT NULL AND [DateCompleted] is NULL)
END
GO

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Stored Procedure for selecting completed requests associated with a DepartmentID
*/
print '' print '*** Creating sp_select_completed_requests_by_departmentID'
GO
CREATE PROCEDURE [sp_select_completed_requests_by_departmentID]
(
	@DepartmentID				[nvarchar](50)
)
AS
BEGIN
	SELECT DISTINCT[RequestID], [DateCreated], [RequestTypeID],
		[RequestingUserID], [RequestGroupID], [RequestedGroupID],
		[DateAcknowledged], [AcknowledgingUserID], [DateCompleted],
		[CompletedUserID], [RequestSubject], [RequestTopic], [RequestBody]
	FROM [request] JOIN [DepartmentRequest] ON
		[RequestID] = [DeptRequestID]
	WHERE ([RequestGroupID] = @DepartmentID OR [RequestedGroupID] = @DepartmentID) AND 
		([DateAcknowledged] is NOT NULL AND [DateCompleted] is NOT NULL)
END
GO

/*
Created by: Ryan Morganti
Date: 2020/02/18
Comment: Stored Procedure for selecting all the Request Types
*/
print '' print '*** Creating sp_select_all_request_types'
GO
CREATE PROCEDURE [sp_select_all_request_types]
AS
BEGIN
	SELECT [RequestTypeID]
	FROM [RequestType]
END
GO

/*
Created by: Ryan Morganti
Date: 2020/02/18
Comment: Stored Procedure for selecting all the DepartmentIDs
*/
print '' print '*** Creating sp_select_all_departmentIDs'
GO
CREATE PROCEDURE [sp_select_all_departmentIDs]
AS
BEGIN
	SELECT [DepartmentID]
	FROM [Department]
END
GO

/*
Created by: Ryan Morganti
Date: 2020/02/18
Comment: Stored Procedure for selecting employee IDs and names to link data in application
*/
print '' print '*** Creating sp_select_all_employee_names'
GO
CREATE PROCEDURE [sp_select_all_employee_names]
AS
BEGIN
	SELECT u.[UserID], u.[FirstName], u.[LastName]
	FROM [User] AS u JOIN [UserRole] AS ur ON 
	u.[UserID] = ur.[UserID]
	WHERE ur.[RoleID] = 'Employee'
END
GO


print '' print '*** Insert users into User Table ***'
GO

/*
Created by: Ryan Morganti
Date: 2020/02/19
Comment: Inserting Employee UserRoles
*/
print '' print '*** Insert Into User Role Table ***'
GO
INSERT INTO [dbo].[UserRole]
([UserID],  
[RoleID]
)
VALUES
(100000, 'Employee'),
(100003, 'Employee'),
(100004, 'Employee'),
(100005, 'Employee')
GO

/*
Created by: Ryan Morganti
Date: 2020/02/21
Comment: Sample EmployeeDepartment Records
*/
print '' print '*** Instering Samlple Role record Employee'
GO
INSERT INTO [dbo].[EmployeeDepartment]
	([EmployeeID], [DepartmentID])
	VALUES
	(100000, 'Management'),
	(100000, 'Inventory'),
	(100000, 'CustomerService'),
	(100003, 'Management'),
	(100003, 'Inventory'),
	(100003, 'CustomerService'),
	(100004, 'Inventory'),
	(100005, 'CustomerService')
GO


/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Sample Request Data
*/
print '' print '*** Inserting DepartmentRequest Records'
GO
INSERT INTO [dbo].[DepartmentRequest]
	([DeptRequestID], [RequestingUserID], [RequestGroupID], [RequestedGroupID],
		[DateAcknowledged], [AcknowledgingUserID], [DateCompleted], [CompletedUserID],
		 [RequestSubject], [RequestTopic], [RequestBody])
	VALUES
	(1000000, 100003, 'Management', 'CustomerService', 
		NULL, NULL, NULL, NULL, 
		'subject filler test', 'topic test', 'This is my body, its so testable'),
	(1000001, 100003, 'Inventory', 'Management', 
		NULL, NULL, NULL, NULL, 
		'subject filler test', 'topic test', 'This is my body, its so testable'),
	(1000002, 100003, 'Inventory', 'Management', 
		NULL, NULL, NULL, NULL, 'subject filler test', 'topic test',
		'This is my body, its so testable'),
	(1000003, 100003, 'Inventory', 'Management', 
		'20200208 01:02:03 PM', 100003, NULL, NULL, 
		'subject filler test', 'topic test', 'This is my body, its so testable'),
	(1000004, 100003, 'Management', 'CustomerService', 
		'20200208 02:02:03 PM', 100003, '20200209 06:04:03 PM', 100003, 
		'subject filler test', 'topic test', 'This is my body, its so testable'),
	(1000005, 100003, 'Management', 'Inventory', 
		'20200208 09:02:03 PM', 100003, '20200209 02:04:03 PM', 100003, 
		
		'subject filler test', 'topic test', 'This is my body, its so testable')			
GO

/*
Created by: Ryan Morganti
Date: 2020/02/22
Comment: Stored Procedure for retrieving the Departments an employee is associated with
*/
print '' print '*** Creating stored procedure select_all_departments_by_userID'
GO
CREATE PROCEDURE [select_all_departments_by_userID](
	@UserID				[int]
)
AS
BEGIN
	SELECT [DepartmentID]
	FROM [EmployeeDepartment]
	WHERE [EmployeeID] = @UserID
END

/*
Created by: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Stored Procedure that adds items to inventory.
*/
print '' print '*** Creating sp_add_items'
GO
CREATE PROCEDURE sp_add_items(
	@ItemName nvarchar(50),
	@ItemQuantity int,
	@ItemCategoryID nvarchar(50),
	@ItemDescription nvarchar(250)
	)
AS
BEGIN
	INSERT INTO Item(
		ItemName,
		ItemCategoryID,
		ItemQuantity,
		ItemDescription
		)
	VALUES(
		@ItemName,
		@ItemCategoryID,
		@ItemQuantity,
		@ItemDescription
	)
END
GO

/*
Created By: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Stored Procedure that adds a new item category
*/
print '' print '*** Creating sp_add_new_category'
GO
CREATE PROCEDURE sp_add_new_category(
	@ItemCategoryID nvarchar(50),
	@Description nvarchar(250)
	)
AS
BEGIN
	INSERT INTO dbo.ItemCategory(
		ItemCategoryID,
		Description
	)
	VALUES(@ItemCategoryID, @Description)
END
GO

/*
Created by: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Stored Procedure that gets a list of categories.
*/
print '' print '*** Creating sp_list_categories'
GO
CREATE PROCEDURE sp_list_categories
AS
BEGIN
	SELECT DISTINCT ItemCategoryID
	FROM dbo.ItemCategory
END
GO

/*
Created by: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Stored Procedure that gets a list of items from inventory.
*/
print '' print '*** Creating sp_retrieve_items'
GO
CREATE PROCEDURE sp_retrieve_items
AS
BEGIN
	SELECT i.ItemID, i.ItemName, i.ItemQuantity, ic.ItemCategoryID
	FROM dbo.Item i
	INNER JOIN dbo.ItemCategory ic
	ON i.ItemCategoryID = ic.ItemCategoryID
END
GO

/*
Created By: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Adding data to ItemCategory
*/
print '' print '*** Adding data to ItemCategory'
GO
	INSERT INTO ItemCategory(
	ItemCategoryID,
	Description
	)
	VALUES
	("Dog Food", "This is the description for the dog food."),
	("Cat Toys", "This is the description for the cat toys.")
GO

/*
Created by: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Adding data to Item
*/
print '' print '*** Adding data to items'
GO
	INSERT INTO Item(
		ItemName,
		ItemCategoryID,
		ItemDescription,
		ItemQuantity
	)
	VALUES
	("Dog Food", "Dog Food", "Dog Food Description", 10),
	("Cat Food", "Dog Food", "Cat Food Description", 20),
	("Lazer Pointer", "Cat Toys", "Lazer Pointer Description", 40)
GO

/*
Created by: Zoey McDonald
Date: 2/20/2020
Comment: Creates VolunteerEvents Table.
*/
print '' print '*** Creating VolunteerEvents Table'
GO
CREATE TABLE [dbo].[VolunteerEvents](
	[VolunteerEventID] 		[int] IDENTITY(1000000,1)	NOT NULL,
	[EventName]   			[nvarchar](500)           	NOT NULL,
	[EventDescription]   	[nvarchar](4000)           	NOT NULL,
	[Active]      			[bit]         				NOT NULL 	DEFAULT 1,
	CONSTRAINT [pk_VolunteerEventID] PRIMARY KEY([VolunteerEventID] ASC)
)
GO

/*
Created by: Zoey McDonald
Date: 2/20/2020
Comment: Creates sample Volunteer Events data.
*/
print '' print '*** Creating Sample Volunteer Event'
GO
INSERT INTO [dbo].[VolunteerEvents]
	([EventName], [EventDescription], [Active])
	VALUES
	('Party For The Dawgs', 'It is just a party for the dogs.', 1),
	('Party For The Cats', 'It is just a party for the cats.', 0)
GO

/*
Created by: Zoey McDonald
Date: 2/20/2020
Comment: Insert a volunteer event.
*/
print '' print '*** Creating sp_insert_volunteer_event'
GO
CREATE PROCEDURE [sp_insert_volunteer_event]
(
	@EventName	 		[nvarchar](500),
	@EventDescription	[nvarchar](4000),
	@Active      		[bit]
)
AS
BEGIN
	INSERT INTO [dbo].[VolunteerEvents]
		([EventName], [EventDescription], [Active])
	VALUES
		(@EventName, @EventDescription, @Active)
	SELECT SCOPE_IDENTITY()
END
GO

/*
Created by: Zoey McDonald
Date: 2/20/2020
Comment: Stored procedure for deleting a volunteer event.
*/
print '' print '*** Creating procedure sp_delete_volunteer_event'
GO
CREATE PROCEDURE [sp_delete_volunteer_event]
(
	@VolunteerEventID [int]
)
AS
BEGIN
	DELETE FROM [dbo].[VolunteerEvents]
	WHERE [VolunteerEventID] = @VolunteerEventID
END
GO

/*
Created by: Zoey McDonald
Date: 2/20/2020
Comment: Stored procedure for updating a volunteer event.
*/
print '' print '*** Creating procedure sp_update_volunteer_event'
GO

CREATE PROCEDURE [sp_update_volunteer_event]
(
	@VolunteerEventID [int],
	@EventName [nvarchar](500),
	@EventDescription [nvarchar](4000)
)
AS
BEGIN
	UPDATE [VolunteerEvents]
	SET [EventName] = @EventName,
	[EventDescription] = @EventDescription
	WHERE [VolunteerEventID] = @VolunteerEventID
	SELECT @@ROWCOUNT
END 
GO

/*
Created by: Zoey McDonald
Date: 2/20/2020
Comment: Stored procedure for selecting all volunteer events.
*/
print '' print '*** Creating procedure sp_select_all_volunteer_events'
GO
CREATE PROCEDURE [sp_select_all_volunteer_events]
AS BEGIN
	SELECT
		[VolunteerEventID], 
		[EventName],
		[EventDescription]
	FROM [dbo].[VolunteerEvents]
END
GO















