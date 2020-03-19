/* Check whether the database already exists */
IF EXISTS (SELECT 1 FROM master.dbo.sysdatabases WHERE name= 'PetUniverseDB')
BEGIN
	DROP DATABASE [PetUniverseDB]
	PRINT '' PRINT '*** Dropping PetUniverseDB'
END
GO
PRINT '' PRINT '*** Creating Database'
GO

CREATE DATABASE [PetUniverseDB]
GO

PRINT '' PRINT '*** Using Database'
GO

USE PetUniverseDB
GO

/*
 ******************************* CREATE TABLEs *****************************
*/
PRINT '' PRINT '******************* CREATE TABLEs *********************'
GO

/*
Created by: Zach Behrensmeyer
Date: 2/3/2020
Comment: General user table, this is used for logging in and finding information about that user.
*/
DROP TABLE IF EXISTS [dbo].[User]
GO
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
[Zipcode] [nvarchar] (15) NOT NULL,
[Locked] [bit] NOT NULL Default 0,
[LockDate] [DateTime] NULL,
[UnlockDate] [DateTime] NULL
)
GO

/*
Created by: Steven Cardona
Date: 2/3/2020
Comment: General user table, this is used for logging in and finding information about that user.
*/
DROP TABLE IF EXISTS [dbo].[Customer]
GO
PRINT '' PRINT '*** Create Customer Table ***'
GO
CREATE TABLE [dbo].[Customer](
    [Email] [nvarchar](250) NOT NULL PRIMARY KEY,
    [FirstName] [nvarchar](50) NOT NULL,
    [LastName] [nvarchar](50) NOT NULL,
    [PhoneNumber] [nvarchar](11) NOT NULL,
    [PasswordHash] [nvarchar](100) NOT NULL DEFAULT
    '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E',
    [addressLineOne] [nvarchar](250) NOT NULL,
    [addressLineTwo] [nvarchar](250) NULL,
    [City] [nvarchar] (20) NOT NULL,
    [State] [nvarchar] (2) NOT NULL,
    [Zipcode] [nvarchar] (15) NOT NULL,
    [Active] [bit] NOT NULL Default 1
)
GO

/*
Created by: Zach Behrensmeyer
Date: 2/3/2020
Comment: This is used to store the roles of the different users
such as admin, manager, etc.
*/
DROP TABLE IF EXISTS [dbo].[Role]
GO
PRINT '' PRINT '*** Create Role Table ***'
GO
CREATE TABLE [dbo].[Role](
    [RoleID] [nvarchar](50) PRIMARY KEY,
    [Description] [nvarchar](250) NOT NULL,
)
GO

/*
Created by: Zach Behrensmeyer
Date: 2/3/2020
Comment: This is used to pair a user with their roles
*/
DROP TABLE IF EXISTS [dbo].[UserRole]
GO
PRINT '' PRINT '*** Create User Role Table ***'
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

/*
Created by: Zach Behrensmeyer
Date: 2/8/2020
Comment: This is used to store logs from the program
*/
DROP TABLE IF EXISTS [dbo].[Logging]
GO
PRINT '' PRINT '*** Creating logging table'
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
Created by: Chuck Baxter
Date: 2/8/2020
Comment: Place Holder for animal species

Updated by: Austin Gee
Date: 2/21/2020
Comment: Added Description Field.
*/
DROP TABLE IF EXISTS [dbo].[AnimalSpecies]
GO
PRINT '' PRINT '*** Creating table AnimalSpecies'
GO
CREATE TABLE [dbo].[AnimalSpecies](
	[AnimalSpeciesID]	[nvarchar](100)				NOT NULL,
	[Description]		[nvarchar](1000)					,
	CONSTRAINT [pk_AnimalSpeciesID] PRIMARY KEY([AnimalSpeciesID] ASC)
)
GO

/*
Created by: Chuck Baxter
Date: 2/8/2020
Comment: PlaceHolder Status table
*/
DROP TABLE IF EXISTS [dbo].[Status]
GO
PRINT '' PRINT '*** Creating Placeholder Status Table'
GO
CREATE TABLE [dbo].[Status](
	[StatusID]			[nvarchar](100)				NOT NULL,
	CONSTRAINT [pk_StatusID] PRIMARY KEY([StatusID] ASC)
)
GO

/*
Created by: Chuck Baxter
Date: 2/8/2020
Comment: Actual Animal Table
*/
DROP TABLE IF EXISTS [dbo].[Animal]
GO
PRINT '' PRINT '*** Creating table Animal'
GO
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
	/*Create By: Michael Thompson
	Date 2/7/2020
	Comment: Adding ProfilePhoto and Description
	*/
	[ProfilePhoto]			[nvarchar](50)  DEFAULT "No image found",
	[ProfileDescription]	[nvarchar](500) DEFAULT "NO description found",
	CONSTRAINT [pk_AnimalID] PRIMARY KEY([AnimalID] ASC),
	CONSTRAINT [fk_Animal_AnimalSpeciesID] FOREIGN KEY([AnimalSpeciesID])
		REFERENCES [AnimalSpecies]([AnimalSpeciesID]) ON UPDATE CASCADE
)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses location number and access dates
*/
DROP TABLE IF EXISTS [dbo].[AnimalKennel]
GO
print '' print '*** Creating AnimalKennel Table'
GO
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
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Handling notes for animals
*/
DROP TABLE IF EXISTS [dbo].[AnimalHandlingNotes]
GO
PRINT '' PRINT '*** Creating AnimalHandlingNotes Table'
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
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Vet appointments
*/
DROP TABLE IF EXISTS [dbo].[AnimalVetAppointment]
GO
PRINT '' PRINT '*** Creating AnimalVetAppointment Table'
GO
CREATE TABLE [dbo].[AnimalVetAppointment] (

	[AnimalVetAppointmentID]	[int] IDENTITY(1000000,1)			NOT NULL,
	[AnimalID]					[int]								NOT NULL,
	[UserID]					[int]								NOT NULL,
	[AppointmentDate]			[datetime]							NOT NULL,
	[AppointmentDescription]	[nvarchar](4000),
	[ClinicAddress]				[nvarchar](200),
	[VetName]					[nvarchar](200),
	[FollowUpDate]				[datetime],

	CONSTRAINT [pk_AnimalVetAppointmentID] PRIMARY KEY([AnimalVetAppointmentID] ASC),

	CONSTRAINT [fk_Animal_AnimalID__] FOREIGN KEY([AnimalID])
		REFERENCES [Animal]([AnimalID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_AnimalVetAppointment_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_AnimalVetAppointmentID] UNIQUE([AnimalVetAppointmentID] ASC)
)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Animal Medical Information
*/
DROP TABLE IF EXISTS [dbo].[AnimalMedicalInfo]
GO
PRINT '' PRINT '*** Creating AnimalMedicalInfo Table'
GO
CREATE TABLE [dbo].[AnimalMedicalInfo] (

	[AnimalMedicalInfoID]		[int] IDENTITY(1000000,1)  NOT NULL,
	[AnimalID]					[int]					   NOT NULL,
	[UserID]					[int]					   NOT NULL,
	[SpayedNeutered]			[bit]					   NOT NULL,
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
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Animal Prescription Information
*/
DROP TABLE IF EXISTS [dbo].[AnimalPrescriptions]
GO
PRINT '' PRINT '*** Creating AnimalPrescriptions Table'
GO
CREATE TABLE [dbo].[AnimalPrescriptions] (

	[AnimalPrescriptionsID]   	[int] IDENTITY(1000000,1)	NOT NULL,
	[AnimalID]					[int]						NOT NULL,
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
		REFERENCES [AnimalVetAppointment]([AnimalVetAppointmentID]) ON UPDATE CASCADE,

	CONSTRAINT [fk_Animal_AnimalID___] FOREIGN KEY ([AnimalID])
		REFERENCES [Animal]([AnimalID]),

	CONSTRAINT [ak_AnimalPrescriptionsID] UNIQUE([AnimalPrescriptionsID] ASC)

)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Facility Maintenance Information
*/
DROP TABLE IF EXISTS [dbo].[FacilityMaintenance]
GO
PRINT '' PRINT '*** Creating FacilityMaintenance Table'
GO
CREATE TABLE [dbo].[FacilityMaintenance] (

	[FacilityMaintenanceID]		[int] IDENTITY(1000000,1)	NOT NULL,
	[UserID]					[int]						NOT NULL,
	[MaintenanceName]			[nvarchar](50)				NOT NULL,
	[MaintenanceInterval]		[nvarchar](20)				NOT NULL,
	[MaintenanceDescription]	[nvarchar](250)				NOT NULL,
	[Active]					[bit]	   					NOT NULL DEFAULT 1

	CONSTRAINT [pk_FacilityMaintenanceID] PRIMARY KEY([FacilityMaintenanceID] ASC),

	CONSTRAINT [fk_User_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_FacilityMaintenanceID] UNIQUE([FacilityMaintenanceID] ASC)
)
GO

/*
Created by: Carl Davis
Date: 2/28/2020
Comment: Table that has the Facility Inspection Information
*/
DROP TABLE IF EXISTS [dbo].[FacilityInspection]
GO
PRINT '' PRINT '*** Creating FacilityInspection Table'
GO
CREATE TABLE [dbo].[FacilityInspection] (

	[FacilityInspectionID]		[int] IDENTITY(1000000,1)	NOT NULL,
	[UserID]					[int]						NOT NULL,
	[InspectorName]				[nvarchar](50)				NOT NULL,
	[InspectionDate]			[date]						NOT NULL,
	[InspectionDescription]		[nvarchar](500)				NOT NULL,
	[InspectionCompleted]		[bit]						NOT NULL DEFAULT 0

	CONSTRAINT [pk_FacilityInspectionID] PRIMARY KEY([FacilityInspectionID] ASC),

	CONSTRAINT [fk_FacilityInspection_UserID] FOREIGN KEY([UserID])
		REFERENCES [User]([UserID]) ON UPDATE CASCADE,

	CONSTRAINT [ak_FacilityInspectionID] UNIQUE([FacilityInspectionID] ASC)
)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Facility Work Information
*/
DROP TABLE IF EXISTS [dbo].[FacilityWork]
GO
PRINT '' PRINT '*** Creating FacilityWork Table'
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
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Kennel Cleaning Information
*/
DROP TABLE IF EXISTS [dbo].[FacilityKennelCleaning]
GO
PRINT '' PRINT '*** Creating FacilityKennelCleaning Table'
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
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Animal Activity
*/
DROP TABLE IF EXISTS [dbo].[AnimalActivityType]
GO
PRINT '' PRINT '*** Creating AnimalActivityType Table'
GO
CREATE TABLE [dbo].[AnimalActivityType] (
	[AnimalActivityTypeID]	[nvarchar](100)				 	NOT NULL,
	[ActivityNotes]			[nvarchar](MAX)

	CONSTRAINT [pk_AnimalActivityTypeID] PRIMARY KEY([AnimalActivityTypeID] ASC),

	CONSTRAINT [ak_AnimalActivityTypeID] UNIQUE([AnimalActivityTypeID] ASC)
)
GO

/*
Created by: Daulton Schilling
Date: 2/8/2020
Comment: Table that houses Animal Activity
*/
DROP TABLE IF EXISTS [dbo].[AnimalActivity]
GO
PRINT '' PRINT '*** Creating AnimalActivity Table'
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
 * Created by: Jordan Lindo
 * Date: 2/5/2020
 * Comment: This is the table for department information.
 */
DROP TABLE IF EXISTS [dbo].[Department]
GO
PRINT '' PRINT '*** Creating Table Department'
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

/*
ShiftTime table shows timeframe and which dept.

Author: Lane Sandburg
2/5/2020

*/
DROP TABLE IF EXISTS [dbo].[ShiftTime]
GO
PRINT '' PRINT '*** creating table ShiftTime'
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
Created by: Mohamed Elamin
Date: 2/3/2020
Comment: AdoptionApplication table.
*/
DROP TABLE IF EXISTS [dbo].[AdoptionApplication]
GO
PRINT '' PRINT '*** Creating AdoptionApplication Table'
GO
CREATE TABLE [dbo].[AdoptionApplication](
	[AdoptionApplicationID]		[int]	IDENTITY(100000,1)		NOT NULL,
	[CustomerEmail]				[nvarchar](250)					NOT NULL,
	[AnimalID]					[int]									,
	[Status]					[nvarchar]	(1000)						,
	[RecievedDate]				[datetime]						NOT NULL,
	CONSTRAINT [pk_AdoptionApplicationID] PRIMARY KEY ([AdoptionApplicationID]),
	CONSTRAINT [fk_AdoptionApplication_Customer_CustomerEmail] FOREIGN KEY ([CustomerEmail])
		REFERENCES [Customer]([Email]),
	CONSTRAINT [fk_AdoptionApplication_Animal_AnimalID] FOREIGN KEY ([AnimalID])
		REFERENCES [Animal]([AnimalID])
)
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Table that holds the various appointment types for adoption appointments
*/
DROP TABLE IF EXISTS [dbo].[AppointmentType]
GO
PRINT '' PRINT '*** Creating AppointmentType Table'
GO
CREATE TABLE [dbo].[AppointmentType](
	[AppointmentTypeID]		[nvarchar]	(100)	NOT NULL,
	[Description]			[nvarchar]	(1000)			,
	CONSTRAINT [pk_AppointmentTypeID] PRIMARY KEY ([AppointmentTypeID])
)
GO

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: This Table holds locations in general. It is used by Adoptions to
	track locations of various appointments.
*/
DROP TABLE IF EXISTS [dbo].[Location]
GO
PRINT '' PRINT '*** Creating Location Table'
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

/*
Created by: Austin Gee
Date: 2/21/2020
Comment: This table holds data regarding various adoption related appointments.
*/
DROP TABLE IF EXISTS [dbo].[Appointment]
GO
PRINT '' PRINT '*** Creating Appointment Table'
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
Comment: Create ItemCateGOry Table
*/
DROP TABLE IF EXISTS [dbo].[ItemCateGOry]
GO
PRINT '' PRINT '*** Creating ItemCateGOry Table'
GO
CREATE TABLE [dbo].[ItemCateGOry](
	[ItemCateGOryID] [nvarchar](50) NOT NULL PRIMARY KEY,
	[Description] [nvarchar](250) NOT NULL
)
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Create Item Table
*/
DROP TABLE IF EXISTS [dbo].[Item]
GO
PRINT '' PRINT '*** Creating Item Table'
GO
CREATE TABLE [dbo].[Item](
	[ItemID] [int] NOT NULL IDENTITY(100000, 1) PRIMARY KEY,
	[ItemName] [nvarchar](50) NOT NULL,
	[ItemCateGOryID] [nvarchar](50) NOT NULL,
	[ItemDescription] [nvarchar](250) NOT NULL,
	[ItemQuantity] [int] NOT NULL,
	[Active]       [bit] DEFAULT 1 NOT NULL,
	CONSTRAINT [fk_Item_ItemCateGOryID] FOREIGN KEY ([ItemCateGOryID])
		REFERENCES [dbo].[ItemCateGOry]([ItemCateGOryID])
)
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Create ProductCateGOry Table
*/
DROP TABLE IF EXISTS [dbo].[ProductCateGOry]
GO
PRINT '' PRINT '*** Creating ProductCateGOry Table'
GO
CREATE TABLE [dbo].[ProductCateGOry](
	[ProductCateGOryID] [nvarchar](20) NOT NULL PRIMARY KEY,
	[Description] [nvarchar](500) NOT NULL
)
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Create ProductType Table
*/
DROP TABLE IF EXISTS [dbo].[ProductType]
GO
PRINT '' PRINT '*** Creating ProductType Table'
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
DROP TABLE IF EXISTS [dbo].[Product]
GO
PRINT '' PRINT '*** Creating Product Table'
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [nvarchar](13) NOT NULL PRIMARY KEY,
	[ItemID] [int] NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductCateGOryID] [nvarchar](20) NOT NULL,
	[ProductTypeID] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[Price] [decimal](10,2) NOT NULL,
	[Brand] [nvarchar](20) NOT NULL,
	[Taxable] [bit] NOT NULL DEFAULT 1,
	CONSTRAINT [fk_Product_ItemID] FOREIGN KEY ([ItemID])
		REFERENCES [dbo].[Item]([ItemID]),
	CONSTRAINT [fk_Product_ProductCataGOryID] FOREIGN KEY ([ProductCateGOryID])
		REFERENCES [dbo].[ProductCateGOry]([ProductCateGOryID]),
	CONSTRAINT [fk_Product_ProductTypeID] FOREIGN KEY ([ProductTypeID])
		REFERENCES [dbo].[ProductType]([ProductTypeID])
)
GO

/*
Created by: Derek Taylor
Date 2/4/2020
Comment: Stores data about applicants
*/
DROP TABLE IF EXISTS [dbo].[Applicant]
GO
PRINT '' PRINT '*** Creating Applicant Table'
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
Created by: Chase Schulte
Date: 02/05/2020
Comment: Inserts table for the ERole Table
*/
DROP TABLE IF EXISTS [dbo].[ERole]
GO
PRINT ''  PRINT '*** Creating Table ERole Table'
GO
CREATE TABLE [dbo].[ERole](
	[ERoleID]	[nvarchar](50) 							not Null,
	[DepartmentID] nvarchar(50)							Not Null,
	[Description] [nvarchar](200)						Null,
	[Active]		[bit]			Not Null Default 1,
	Constraint	[pk_ERoleID] 	PRIMARY KEY([ERoleID] ASC),
	Constraint	[fk_ERole_DepartmentID] Foreign Key([DepartmentID])
		REFERENCES [department]([DepartmentID] ) On UPDATE CASCADE
)
GO

/*
Created by: Chase Schulte
Date: 02/28/2020
Comment: Create UserERole Table
*/
DROP TABLE IF EXISTS [dbo].[UserERole]
GO
PRINT '' PRINT '*** Creating table UserERole'
GO
CREATE TABLE [dbo].[UserERole](
	[UserID]	[int] 									NOT NULL,
	[ERoleID]	[nvarchar](50) 							Not Null,

	Constraint	[pk_UserERole_UserID_RoleID] 	PRIMARY KEY([UserID] ASC, [ERoleID] Asc),
	Constraint	[fk_UserERole_UserID] Foreign Key([UserID])
		REFERENCES [User]([UserID]),
	Constraint	[fk_UserERole_RoleID] 	Foreign KEY([ERoleID])
		REFERENCES [ERole]([ERoleID]) On UPDATE CASCADE

)
Go

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Create volunteer task table
*/
DROP TABLE IF EXISTS [dbo].[VolunteerTask]
GO
PRINT '' PRINT '*** Creating VolunteerTask Table'
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
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Table that holds different types of requests
*/
DROP TABLE IF EXISTS [dbo].[requestType]
GO
PRINT '' PRINT '*** Creating requestType table'
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
DROP TABLE IF EXISTS [dbo].[request]
GO
PRINT '' PRINT '*** Creating request table'
GO
CREATE TABLE [dbo].[request] (
	[RequestID]				[int]IDENTITY(1000000,1)	NOT NULL,
	[RequestTypeID]			[nvarchar](50)				NOT NULL,
	[DateCreated]			[datetime]					NOT NULL,
	[RequestingUserID]		[int]						NOT NULL,
	[Open]					[bit]			  NOT NULL DEFAULT 1,
	CONSTRAINT [pk_RequestID] PRIMARY KEY ([RequestID] ASC),
	CONSTRAINT [fk_request_requestTypeID] FOREIGN KEY([RequestTypeID])
		REFERENCES [requestType]([RequestTypeID]) ON UPDATE CASCADE,
	CONSTRAINT [fk_request_requestingUserD] FOREIGN KEY ([RequestingUserID])
		REFERENCES [user]([UserID])
)
GO

/*
Created by: Kaleb Bachert
Date: 3/6/2020
Comment: Table that holds each submitted time off request
*/
DROP TABLE IF EXISTS [dbo].[timeOffRequest]
GO
PRINT '' PRINT '*** Creating timeOffRequest table'
GO
CREATE TABLE [dbo].[timeOffRequest] (
	[TimeOffRequestID]		[int]IDENTITY(1000000,1)	NOT NULL,
	[EffectiveStart]		[datetime]					NOT NULL,
	[EffectiveEnd]			[datetime]						NULL,
	[ApprovalDate]			[datetime]						NULL,
	[ApprovingUserID]		[int]							NULL,
	[RequestID]				[int]						NOT NULL,
	CONSTRAINT [pk_TimeOffRequestID] PRIMARY KEY ([TimeOffRequestID] ASC),
	CONSTRAINT [fk_timeOffRequest_RequestID] FOREIGN KEY ([RequestID])
		REFERENCES [request]([RequestID]),
	CONSTRAINT [fk_timeOffRequest_ApprovingUserID] FOREIGN KEY ([ApprovingUserID])
		REFERENCES [user]([UserID])
)

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
/*
Created by: Awaab Elamin
Date: 2/10/2020
Comment: Create Customer Answers table that contains the customer answers of the questionnair
*/
print '' print '*** Creating the CustomerAnswer table'
GO
CREATE TABLE [dbo].[CustomerAnswers](
	[QuestionDescription] [nvarchar](100)  NOT NULL,
	[CustomerEmail] [NVARCHAR](250)  NOT NULL,
	[AdoptionApplicationID] [int]  NOT NULL,
	[Answer] [nvarchar](500) NOT NULL,

	CONSTRAINT [pk_QuestionID_CustomerID_AdoptionApplicationID] PRIMARY KEY ([QuestionDescription] ASC,[CustomerEmail] ASC,[AdoptionApplicationID] ASC),	
	CONSTRAINT [CustomerEmail]	FOREIGN KEY ([CustomerEmail])
		REFERENCES [dbo].[Customer]([Email]),
	CONSTRAINT [AdoptionApplicationID]	FOREIGN KEY ([AdoptionApplicationID])
		REFERENCES [dbo].[AdoptionApplication]([AdoptionApplicationID])
)
GO

/*
Created by: Jaeho Kim
Date: 2/26/2020
Comment: Create TransactionStatus Table
*/
DROP TABLE IF EXISTS [dbo].[TransactionStatus]
GO
PRINT '' PRINT '*** Creating TransactionStatus Table'
GO
CREATE TABLE [dbo].[TransactionStatus](
	[TransactionStatusID] 	[nvarchar](20) NOT NULL,
	[Description] 			[nvarchar](500) NOT NULL,

	CONSTRAINT [pk_TransactionStatus_TransactionStatusID] PRIMARY KEY ([TransactionStatusID] ASC)
)
GO

/*
Created by: Jaeho Kim
Date: 2/26/2020
Comment: Create TransactionType Table
*/
DROP TABLE IF EXISTS [dbo].[TransactionType]
GO
PRINT '' PRINT '*** Creating TransactionType Table'
GO
CREATE TABLE [dbo].[TransactionType](
	[TransactionTypeID] 	[nvarchar](20) 		NOT NULL,
	[Description] 			[nvarchar](500) 	NOT NULL,

	CONSTRAINT [pk_TransactionType_TransactionTypeID] PRIMARY KEY ([TransactionTypeID] ASC)
)
GO

/*
Created by: Jaeho Kim
Date: 2/26/2020
Comment: Create Transaction Table
*/
DROP TABLE IF EXISTS [dbo].[Transaction]
GO
PRINT '' PRINT '*** Creating Transaction Table'
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
Date: 2/27/2020
Comment: Create TransactionLine Table
*/
DROP TABLE IF EXISTS [dbo].[TransactionLine]
GO
PRINT '' PRINT '*** Creating TransactionLine Table'
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
Created by: Alex Diers
Date: 2/28/2020
Comment: Creates the table for Training Videos
*/
DROP TABLE IF EXISTS [dbo].[TrainingVideo]
GO
PRINT '' PRINT '*** Creating TrainingVideo Table'
GO
CREATE TABLE [dbo].[TrainingVideo](
	[TrainingVideoID] 		[nvarchar](150)				NOT NULL,
	[RunTimeMinutes] 		[int] 						NOT NULL,
	[RunTimeSeconds] 		[int] 						NOT NULL,
	[Description] 			[nvarchar] (1000) 			NOT NULL,
	[Active] 				[bit] 						NOT NULL Default 1,
	CONSTRAINT [pk_TrainingVideoID] 			PRIMARY KEY ([TrainingVideoID] ASC)
)
GO

/*
Created by: Tener Karar
Date: 02/27/2020
Comment: INSERTing Item Location table data
*/
DROP TABLE IF EXISTS [dbo].[ItemLocation]
GO
PRINT '' PRINT '*** creating ItemLocation table'
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
Comment: creating Item Location Line table'
*/
DROP TABLE IF EXISTS [dbo].[ItemLocationLine]
GO
PRINT '' PRINT '*** creating ItemLocationLine table'
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
Created By: Timothy Lickteig
Date: 2/07/2020
Comment: Table for volunteer shifts
*/
DROP TABLE IF EXISTS [dbo].[VolunteerShift]
GO
PRINT '' PRINT '*** Creating VolunteerShift Table'
GO
CREATE TABLE [dbo].[VolunteerShift](
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
GO

/*
Created By: Steve Coonrod
Date: 		2/9/2020
Comment:	Table for storing Event Types
*/
DROP TABLE IF EXISTS [dbo].[EventType]
GO
PRINT '' PRINT '*** Creating EventType Table'
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
DROP TABLE IF EXISTS [dbo].[Event]
GO
PRINT '' PRINT '*** Creating Event Table'
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
PRINT '' PRINT '  > Adding indexes to Event table'
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
DROP TABLE IF EXISTS [dbo].[EventRequest]
GO
PRINT '' PRINT '*** Creating EventRequest Table'
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

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: General request response table, used to track request comments and respones ************************************************DOUBLE CHECK WITH DEREK
made by various users
*/
DROP TABLE IF EXISTS [dbo].[RequestResponse]
GO
PRINT '' PRINT '*** creating request response table'
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
DROP TABLE IF EXISTS [dbo].[DepartmentRequest]
GO
PRINT '' PRINT '*** creating department request table'
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
DROP TABLE IF EXISTS [dbo].[EmployeeDepartment]
GO
PRINT '' PRINT '*** creating EmployeeDepartment table'
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
Created by: Josh Jackson
Date: 2/8/2020
Comment: Table that houses Volunteer Information
*/
DROP TABLE IF EXISTS [dbo].[Volunteer]
GO
PRINT '' PRINT '*** Creating Volunteer Table'
GO
CREATE TABLE [dbo].[Volunteer](
	[VolunteerID] 	[int] identity(1000000,1) 	not null,
	[FirstName]  	[nvarchar](500)           	not null,
	[LastName]    	[nvarchar](500)         	not null,
	[Email]    	  	[nvarchar](100)				not null,
	[PhoneNumber] 	[nvarchar](12) 				not null,
	[OtherNotes]  	[nvarchar](2000)			null,
	[PasswordHash]	[nvarchar](100)				not null
		default '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E',
	[Active]      	[bit]         				not null default 1,
	constraint [pk_VolunteerID] primary key([VolunteerID] asc),
	constraint [ak_Volunteer_Email] unique([Email] asc)
)
GO


/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Table that houses different skills a volunteer could have
*/
DROP TABLE IF EXISTS [dbo].[VolunteerSkills]
GO
PRINT '' PRINT '*** Creating VolunteerSkills Table'
GO
CREATE TABLE [dbo].[VolunteerSkills](
	[SkillID]     			[nvarchar](50)  	not null,
	[SkillDescription] 		[nvarchar](500) 	not null,
	constraint [pk_SkillID] primary key([SkillID] asc)
)
GO


/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Table that ties Volunteers to their skills
*/
DROP TABLE IF EXISTS [dbo].[VolunteerSkill]
GO
PRINT '' PRINT '*** Creating VolunteerSkill Table'
GO
CREATE TABLE [dbo].[VolunteerSkill](
	[VolunteerID] 	[int]          	not null,
	[SkillID] 	  	[nvarchar](50) 	not null,
	constraint [pk_VolunteerID_SkillID] primary key([VolunteerID] asc, [SkillID] asc),
	constraint [fk_Volunteer_VolunteerID] foreign key([VolunteerID])
		references [Volunteer]([VolunteerID])on delete cascade,
    constraint [fk_VolunteerSkills_SkillID] foreign key([SkillID])
		references [VolunteerSkills]([SkillID]) on update cascade
)
GO

/*
Created by: Zoey McDonald
Date: 2/20/2020
Comment: Creates VolunteerEvents Table.
*/
DROP TABLE IF EXISTS [dbo].[VolunteerEvents]
GO
PRINT '' PRINT '*** Creating VolunteerEvents Table'
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
Created by: Austin Gee
Date: 3/5/2020
Comment: lookup table to match a certain animal with any number of statuses
*/
DROP TABLE IF EXISTS [dbo].[AnimalStatus]
GO
PRINT '' PRINT '*** Creating AnimalStatus Table'
GO
CREATE TABLE [dbo].[AnimalStatus](
	[AnimalID]	[int]				NOT NULL,
	[StatusID] 	[nvarchar](100)		NOT NULL,
	CONSTRAINT [pk_AnimalID_StatusID] PRIMARY KEY ([AnimalID] ASC, [StatusID] ASC),
	CONSTRAINT [fk_animal_status_animal_animalID] FOREIGN KEY ([AnimalID])
		REFERENCES [Animal]([AnimalID]),
	CONSTRAINT [fk_animal_status_status_statusID] FOREIGN KEY ([StatusID])
		REFERENCES [Status]([StatusID])
)
GO

/*
Created by: Robert Holmes
Date: 2020/03/06
Comment: A table for holding a promotion types
*/
DROP TABLE IF EXISTS [dbo].[PromotionType]
GO
PRINT '' PRINT '*** Creating PromotionType table'
GO
CREATE TABLE [dbo].[PromotionType](
		[PromotionTypeID]	NVARCHAR(20)	NOT NULL	PRIMARY KEY
	,	[Description]		NVARCHAR(500)	NOT NULL
)
GO

/*
Created by: Robert Holmes
Date: 2020/03/06
Comment: A table for holding info about a promotion
*/
DROP TABLE IF EXISTS [dbo].[Promotion]
GO
PRINT '' PRINT '*** Creating Promotion table'
GO
CREATE TABLE [dbo].[Promotion](
		[PromotionID]		NVARCHAR(20)	NOT NULL	PRIMARY KEY
	,	[PromotionTypeID]	NVARCHAR(20)	NOT NULL
	,	[StartDate]			DATETIME		NOT NULL
	,	[EndDate]			DATETIME		NOT NULL
	,	[Discount]			DECIMAL(10, 2)	NOT NULL
	,	[Description]		NVARCHAR(500)	NOT NULL
	,	CONSTRAINT [fk_Promotion_PromotionType]	FOREIGN KEY([PromotionTypeID])
			REFERENCES [dbo].[PromotionType]([PromotionTypeID])
)
GO

/*
Created by: Robert Holmes
Date: 2020/03/06
Comment: A table to relate promotions to products
*/
DROP TABLE IF EXISTS [dbo].[PromoProductLine]
GO
PRINT '' PRINT '*** Creating PromoProductLine table'
GO
CREATE TABLE [dbo].[PromoProductLine](
		[PromotionID]	NVARCHAR(20)	NOT NULL
	,	[ProductID]		NVARCHAR(13)	NOT NULL
	,	CONSTRAINT 	[pk_PromoProductLine_PromotionID_ProductID]	PRIMARY KEY([PromotionID], [ProductID])
	,	CONSTRAINT	[fk_PromoProductLine_Promotion] 			FOREIGN KEY([PromotionID])
			REFERENCES	[dbo].[Promotion]([PromotionID])
	,	CONSTRAINT	[fk_PromoProductLine_Product]				FOREIGN KEY([ProductID])
			REFERENCES	[dbo].[Product]([ProductID])
)
GO

/*
Created By: Timothy Lickteig
Date: 3/01/2020
Comment: Table for storing instances of people signed up for shifts
*/
print '' print '*** Creating ShiftRecord Table'
go
create table [dbo].[ShiftRecord](
	
	VolunteerID [int] not null,
	VolunteerShiftID [int] not null,
	constraint [pk_ShiftRecord_VolunteerID_VolunteerShiftID] 
		primary key([VolunteerID], [VolunteerShiftID]),
	constraint [fk_VolunteerShift_VolunteerShiftID] foreign key([VolunteerShiftID])
		references [VolunteerShift]([VolunteerShiftID]),
	constraint [fk_ShiftRecord_VolunteerID] foreign key([VolunteerID])
		references [Volunteer]([VolunteerID])
)
go

/*
Author: Timothy Lickteig
Date: 2020/03/09
Comment: Creating table for Medicine
*/
print '' print '*** Creating Medicine table'
GO
CREATE TABLE [dbo].[Medicine] (

	[MedicineID] [int] identity(1000000, 1) not null,
	[MedicineName] [nvarchar](300) not null,
	[MedicineDosage] [nvarchar](300) not null,
	[MedicineDescription] [nvarchar](500),
	constraint [pk_Medicine_MedicineID] primary key([MedicineID] asc)
)
GO

/*
 ******************************* Create Procedures *****************************
*/
PRINT '' PRINT '******************* Create Procedures *********************'
GO

/*
Created by: Steven Cardona
Date: 02/06/2020
Comment: This is used to INSERT a new user into the database
with all default values used.
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_user]
GO
PRINT '' PRINT '*** Create sp_INSERT_user ***'
GO
CREATE PROCEDURE [sp_INSERT_user]
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
Date: 2/6/2020
Comment: Sproc to authenticate user
*/
DROP PROCEDURE IF EXISTS [sp_authenticate_user]
GO
PRINT '' PRINT '*** Creating sp_authenticate_user'
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

/*
Created by: Zach Behrensmeyer
Date: 2/6/2020
Comment: Sproc to find user by email
*/
DROP PROCEDURE IF EXISTS [sp_select_user_by_email]
GO
PRINT '' PRINT '*** Creating sp_select_user_by_email'
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
DROP PROCEDURE IF EXISTS [sp_select_roles_by_userID]
GO
PRINT '' PRINT '*** Creating sp_select_roles_by_userID'
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
DROP PROCEDURE IF EXISTS [sp_get_login_loGOut_logs]
GO
PRINT '' PRINT '*** sp_get_login_loGOut_logs'
GO
CREATE PROCEDURE [sp_get_login_loGOut_logs]
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
Comment: Sproc to INSERT Animal Activity
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_AnimalActivity]
GO
PRINT '' PRINT '*** sp_INSERT_AnimalActivity'
GO
CREATE PROCEDURE [sp_INSERT_AnimalActivity]
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
END


/*
Created by: Daulton Schilling
Date: 2/11/2020
Comment: Sproc to INSERT Animal Activity type
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_AnimalActivityType]
GO
PRINT '' PRINT '*** sp_INSERT_AnimalActivityType'
GO
CREATE PROCEDURE [sp_INSERT_AnimalActivityType]
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
END
GO


/*
Created by: Chuck Baxter
Date: 2/11/2020
Comment: Sproc to INSERT Animal
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_animal]
GO
PRINT '' PRINT'*** Creating sp_INSERT_animal'
GO

CREATE PROCEDURE [sp_INSERT_animal]
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
DROP PROCEDURE IF EXISTS [sp_select_active_animals]
GO
PRINT '' PRINT '*** Creating sp_select_active_animals'
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
Comment: Sproc to INSERT facility maintenance
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_facility_maintenance]
GO
PRINT '' PRINT '*** Creating sp_INSERT_facility_maintenance'
GO
CREATE PROCEDURE [sp_INSERT_facility_maintenance]
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
Created by: Carl Davis
Date: 2/14/2020
Comment: Sproc to select facility maintenance by id
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_maintenance_by_id]
GO
PRINT '' PRINT '*** Creating sp_select_facility_maintenance_by_id'
GO
CREATE PROCEDURE [sp_select_facility_maintenance_by_id]
(
    @FacilityMaintenanceID                        	[int],
	@Active 										[bit]

)
AS
BEGIN
    SELECT [FacilityMaintenanceID], [UserID], [MaintenanceName],
            [MaintenanceInterval], [MaintenanceDescription], [Active]
    FROM [dbo].[FacilityMaintenance]
	WHERE [FacilityMaintenanceID] = @FacilityMaintenanceID
	AND [Active] = @Active

END
GO

/*
Created by: Carl Davis
Date: 2/14/2020
Comment: Sproc to select all facility maintenance
*/
DROP PROCEDURE IF EXISTS [sp_select_all_facility_maintenance]
GO
PRINT '' PRINT '*** Creating sp_select_all_facility_maintenance'
GO
CREATE PROCEDURE [sp_select_all_facility_maintenance]
(
	@Active			[bit]
)
AS
BEGIN
    SELECT [FacilityMaintenanceID], [UserID], [MaintenanceName],
            [MaintenanceInterval], [MaintenanceDescription], [Active]
    FROM [dbo].[FacilityMaintenance]
	WHERE [Active] = @Active
END
GO

/*
Created by: Carl Davis
Date: 2/14/2020
Comment: Sproc to select facility maintenance by user id
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_maintenance_by_user_id]
GO
PRINT '' PRINT '*** Creating sp_select_facility_maintenance_by_user_id'
GO
CREATE PROCEDURE [sp_select_facility_maintenance_by_user_id]
(
    @UserID                        	[int],
	@Active							[bit]
)
AS
BEGIN
    SELECT [FacilityMaintenanceID], [UserID], [MaintenanceName],
            [MaintenanceInterval], [MaintenanceDescription], [Active]
    FROM [dbo].[FacilityMaintenance]
	WHERE [UserID] = @UserID
		AND [Active] = @Active

END
GO

/*
Created by: Carl Davis
Date: 2/14/2020
Comment: Sproc to select facility maintenance by name
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_maintenance_by_name]
GO
PRINT '' PRINT '*** Creating sp_select_facility_maintenance_by_name'
GO
CREATE PROCEDURE [sp_select_facility_maintenance_by_name]
(
    @MaintenanceName                        	[nvarchar](50),
	@Active										[bit]
)
AS
BEGIN
    SELECT [FacilityMaintenanceID], [UserID], [MaintenanceName],
            [MaintenanceInterval], [MaintenanceDescription], [Active]
    FROM [dbo].[FacilityMaintenance]
	WHERE [MaintenanceName] = @MaintenanceName
	AND [Active] = @Active
END
GO

/*
Created by: Carl Davis
Date: 2/14/2020
Comment: Sproc to update facility maintenance
*/
DROP PROCEDURE IF EXISTS [sp_update_facility_maintenance]
GO
PRINT '' PRINT '*** Creating sp_update_facility_maintenance '
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
Created by: Carl Davis
Date: 2/28/2020
Comment: Sproc to deactivate facility maintenance
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_facility_maintenance]
GO
PRINT '' PRINT '*** Creating sp_deactivate_facility_maintenance'
GO
CREATE PROCEDURE [sp_deactivate_facility_maintenance]
(
	@FacilityMaintenanceID					[int]
)
AS
BEGIN
	UPDATE [dbo].[FacilityMaintenance]
	SET		[Active] = 0
	WHERE [FacilityMaintenanceID] = @FacilityMaintenanceID
	RETURN @@ROWCOUNT
END
GO

/*
Created by: Carl Davis
Date: 2/28/2020
Comment: Sproc to INSERT facility inspection
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_facility_inspection]
GO
PRINT '' PRINT '*** Creating sp_INSERT_facility_inspection'
GO
CREATE PROCEDURE [sp_INSERT_facility_inspection]
(
    @UserID                        	[int],
    @InspectorName            		[nvarchar](150),
    @InspectionDate         		[date],
    @InspectionDescription     		[nvarchar](500)
)
AS
BEGIN
    INSERT INTO [dbo].[FacilityInspection]
        ([UserID], [InspectorName], [InspectionDate], [InspectionDescription])
    VALUES
        (@UserID, @InspectorName, @InspectionDate, @InspectionDescription)
    RETURN SCOPE_IDENTITY()

END
GO

/*
Created by: Carl Davis
Date: 3/11/2020
Comment: Sproc to select all facility inspections
*/
DROP PROCEDURE IF EXISTS [sp_select_all_facility_inspection]
GO
PRINT '' PRINT '*** Creating sp_select_all_facility_inspection'
GO
CREATE PROCEDURE [sp_select_all_facility_inspection]
(
	@InspectionCompleted			[bit]
)
AS
BEGIN
    SELECT [FacilityInspectionID], [UserID], [InspectorName],
            [InspectionDate], [InspectionDescription], [InspectionCompleted]
    FROM [dbo].[FacilityInspection]
	WHERE [InspectionCompleted] = @InspectionCompleted
END
GO

/*
Created by: Carl Davis
Date: 3/11/2020
Comment: Sproc to select facility inspection by id
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_inspection_by_id]
GO
PRINT '' PRINT '*** Creating sp_select_facility_inspection_by_id'
GO
CREATE PROCEDURE [sp_select_facility_inspection_by_id]
(
    @FacilityInspectionID                        	[int],
	@InspectionCompleted 							[bit]

)
AS
BEGIN
    SELECT [FacilityInspectionID], [UserID], [InspectorName],
            [InspectionDate], [InspectionDescription], [InspectionCompleted]
    FROM [dbo].[FacilityInspection]
	WHERE [FacilityInspectionID] = @FacilityInspectionID
	AND [InspectionCompleted] = @InspectionCompleted

END
GO

/*
Created by: Carl Davis
Date: 3/11/2020
Comment: Sproc to select facility inspection by user id
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_inspection_by_user_id]
GO
PRINT '' PRINT '*** Creating sp_select_facility_inspection_by_user_id'
GO
CREATE PROCEDURE [sp_select_facility_inspection_by_user_id]
(
    @UserID           								[int],
	@InspectionCompleted							[bit]
)
AS
BEGIN
    SELECT [FacilityInspectionID], [UserID], [InspectorName],
            [InspectionDate], [InspectionDescription], [InspectionCompleted]
    FROM [dbo].[FacilityInspection]
	WHERE [UserID] = @UserID
		AND [InspectionCompleted] = @InspectionCompleted

END
GO

/*
Created by: Carl Davis
Date: 3/11/2020
Comment: Sproc to select facility inspection by inspector name
*/
DROP PROCEDURE IF EXISTS [sp_select_facility_inspection_by_inspector_name]
GO
PRINT '' PRINT '*** Creating sp_select_facility_inspection_by_inspector_name'
GO
CREATE PROCEDURE [sp_select_facility_inspection_by_inspector_name]
(
    @InspectorName                        	[nvarchar](50),
	@InspectionCompleted					[bit]
)
AS
BEGIN
    SELECT [FacilityInspectionID], [UserID], [InspectorName],
            [InspectionDate], [InspectionDescription], [InspectionCompleted]
    FROM [dbo].[FacilityInspection]
	WHERE [InspectorName] = @InspectorName
	AND [InspectionCompleted] = @InspectionCompleted
END
GO

/*
Created by: Carl Davis
Date: 3/13/2020
Comment: Sproc to update facility inspection
*/
DROP PROCEDURE IF EXISTS [sp_update_facility_inspection]
GO
print '' print '*** Creating sp_update_facility_inspection'
GO
CREATE PROCEDURE [sp_update_facility_inspection]
(
	@FacilityInspectionID          		[int],
    @OldUserID                        	[int],
    @OldInspectorName            		[nvarchar](50),
    @OldInspectionDate         			[date],
    @OldInspectionDescription    		[nvarchar](250),
	@OldInspectionComplete				[bit],
	@NewUserID                        	[int],
    @NewInspectorName           		[nvarchar](50),
    @NewInspectionDate         			[date],
    @NewInspectionDescription     		[nvarchar](250),
	@NewInspectionComplete				[bit]

)
AS
BEGIN
    UPDATE 	[dbo].[FacilityInspection]
	SET 	[UserID] = @NewUserID,
			[InspectorName] = @NewInspectorName,
			[InspectionDate] = @NewInspectionDate,
			[InspectionDescription] = @NewInspectionDescription,
			[InspectionCompleted] = @NewInspectionComplete
			
	WHERE   [FacilityInspectionID] = @FacilityInspectionID
		AND	[UserID] = @OldUserID
		AND	[InspectorName] = @OldInspectorName
		AND	[InspectionDate] = @OldInspectionDate
		AND	[InspectionDescription] = @OldInspectionDescription
		AND [InspectionCompleted] = @OldInspectionComplete
	 RETURN @@ROWCOUNT

END
GO

/*
Created by: Ethan Murphy
Date: 2/11/2020
Comment: Sproc to Select all vet appointments
*/
DROP PROCEDURE IF EXISTS [sp_select_all_vet_appointments]
GO
PRINT '' PRINT '*** Creating sp_select_all_vet_appointments'
GO
CREATE PROCEDURE [sp_select_all_vet_appointments]
AS
BEGIN
    SELECT [AnimalVetAppointmentID], [Animal].[AnimalID], [AnimalName],
            [AppointmentDate], [AppointmentDescription],
            [ClinicAddress], [VetName], [FollowUpDate], [UserID]
    FROM [AnimalVetAppointment] INNER JOIN [Animal]
    ON [AnimalVetAppointment].[AnimalID] = [Animal].[AnimalID]
    ORDER BY [AppointmentDate]
END
GO

/*
Create by: Ethan Murphy
Date: 3/9/2020
Comment: Procedure to select all animal prescription records
*/
DROP PROCEDURE IF EXISTS [sp_select_all_animal_prescriptions]
GO
PRINT '' PRINT '*** creating sp_select_all_animal_prescriptions'
GO
CREATE PROCEDURE [sp_select_all_animal_prescriptions]
AS
BEGIN
	SELECT [AnimalPrescriptionsID], [Animal].[AnimalID], [AnimalVetAppointmentID],
			[PrescriptionName], [Dosage], [Interval], [AdministrationMethod],
			[StartDate], [EndDate], [Description], [AnimalName]
	FROM [AnimalPrescriptions] INNER JOIN [Animal]
    ON [AnimalPrescriptions].[AnimalID] = [Animal].[AnimalID]
	ORDER BY [AnimalName]
END
GO

/*
Created by: Ethan Murphy
Date: 2/7/2020
Comment: Stored procedure for INSERTing vet appointments
*/
DROP PROCEDURE IF EXISTS [sp_create_vet_appointment]
GO
PRINT '' PRINT '*** create sp_create_vet_appointment'
GO
CREATE PROCEDURE [sp_create_vet_appointment]
(
	@AnimalID					[int],
	@UserID						[int],
	@AppointmentDate			[datetime],
	@AppointmentDescription		[nvarchar](4000),
	@ClinicAddress				[nvarchar](200),
	@VetName					[nvarchar](200),
	@FollowUpDate				[datetime]
)
AS
BEGIN
    INSERT INTO [AnimalVetAppointment]
        ([AnimalID], [AppointmentDate], [AppointmentDescription],
        [ClinicAddress], [VetName], [FollowUpDate], [UserID])
    VALUES
        (@AnimalID, @AppointmentDate, @AppointmentDescription,
        @ClinicAddress, @VetName, @FollowUpDate, @UserID)
END
GO

/*
Created by: Ethan Murphy
Date: 3/1/2020
Comment: Stored procedure for updating
an existing vet appointment record
*/
DROP PROCEDURE IF EXISTS [sp_update_vet_appointment]
GO
PRINT '' PRINT '*** creating sp_update_vet_appointment'
GO
CREATE PROCEDURE [sp_update_vet_appointment]
(
	@AnimalVetAppointmentID		[int],
	@OldAnimalID				[int],
	@OldUserID					[int],
	@OldAppointmentDate			[datetime],
	@OldAppointmentDescription	[nvarchar](4000),
	@OldClinicAddress			[nvarchar](200),
	@OldVetName					[nvarchar](200),

	@NewAnimalID				[int],
	@NewUserID					[int],
	@NewAppointmentDate			[datetime],
	@NewAppointmentDescription	[nvarchar](4000),
	@NewClinicAddress			[nvarchar](200),
	@NewVetName					[nvarchar](200),
	@NewFollowUpDate			[datetime]
)
AS
BEGIN
	UPDATE [dbo].[AnimalVetAppointment]
	SET	[AnimalID] = @NewAnimalID,
		[UserID] = @NewUserID,
		[AppointmentDate] = @NewAppointmentDate,
		[AppointmentDescription] = @NewAppointmentDescription,
		[ClinicAddress] = @NewClinicAddress,
		[VetName] = @NewVetName,
		[FollowUpDate] = @NewFollowUpDate
	WHERE [AnimalID] = @OldAnimalID
	AND [AnimalVetAppointmentID] = @AnimalVetAppointmentID
	AND [UserID] = @OldUserID
	AND	[AppointmentDate] = @OldAppointmentDate
	AND [AppointmentDescription] = @OldAppointmentDescription
	AND	[ClinicAddress] = @OldClinicAddress
	AND	[VetName] = @OldVetName
	RETURN @@ROWCOUNT
END
GO

/*
Created by: Ethan Murphy
Date: 2/16/2020
Comment: Stored procedure for INSERTing animal prescription records
*/
DROP PROCEDURE IF EXISTS [sp_create_animal_prescription_record]
GO
PRINT '' PRINT 'create sp_create_animal_prescription_record'
GO
CREATE PROCEDURE [sp_create_animal_prescription_record]
(
	@AnimalID					[int],
	@AnimalVetAppointmentID		[int],
	@PrescriptionName			[nvarchar](50),
	@Dosage						[decimal],
	@MedicationInterval			[nvarchar](250),
	@AdministrationMethod		[nvarchar](100),
	@StartDate					[date],
	@EndDate					[date],
	@Description				[nvarchar](500)
)
AS
BEGIN
INSERT INTO [AnimalPrescriptions]
	([AnimalVetAppointmentID], [PrescriptionName], [Dosage],
	[Interval], [AdministrationMethod], [AnimalID],
	[StartDate], [EndDate], [Description])
VALUES
	(@AnimalVetAppointmentID, @PrescriptionName, @Dosage,
	@MedicationInterval, @AdministrationMethod, @AnimalID,
	@StartDate, @EndDate, @Description)
END
GO

/*
Created by: Ben Hanna
Date: 2/11/2020
Comment: Sproc to reactivate an animal
*/
DROP PROCEDURE IF EXISTS [sp_reactivate_animal]
GO
PRINT '' PRINT '*** Creating sp_reactivate_animal'
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
Comment: Sproc to reactivate an animal
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_animal]
GO
PRINT '' PRINT '*** Creating sp_deactivate_animal'
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
Comment: Sproc to deahouse animal
*/
DROP PROCEDURE IF EXISTS [sp_dehouse_animal]
GO
PRINT '' PRINT '*** Creating sp_dehouse_animal'
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
DROP PROCEDURE IF EXISTS [sp_house_animal]
GO
PRINT '' PRINT '*** Creating sp_house_animal'
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
DROP PROCEDURE IF EXISTS [sp_deset_animal_adoptable]
GO
PRINT '' PRINT '*** Creating sp_deset_animal_adoptable'
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
DROP PROCEDURE IF EXISTS [sp_set_animal_adoptable]
GO
PRINT '' PRINT '*** Creating sp_set_animal_adoptable'
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
Comment: Sets an animal's adoptable state to false
*/ 
DROP PROCEDURE IF EXISTS [sp_select_handling_notes_by_animal_id]
GO
PRINT '' PRINT '*** Creating sp_select_handling_notes_by_animal_id'
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
DROP PROCEDURE IF EXISTS [sp_INSERT_kennel_record]
GO                
PRINT '' PRINT '*** Creating sp_INSERT_kennel_record'
GO
CREATE PROCEDURE [sp_INSERT_kennel_record]
(
    @AnimalID           [int],
    @AnimalKennelInfo   [nvarchar](4000), 
    @AnimalKennelDateIn	[date],
    @UserID             [int]
        
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
Date: 03/12/2020
Comment: This is used to select all kennel records fron the animal kennel table
*/
DROP PROCEDURE IF EXISTS [sp_select_all_kennel_records]
GO
PRINT '' PRINT '*** Creating sp_select_all_kennel_records'
GO
CREATE PROCEDURE [sp_select_all_kennel_records]
AS
BEGIN
	SELECT 
    [AnimalKennelID],		
	[AnimalID],				
	[UserID],				
	[AnimalKennelInfo],		
	[AnimalKennelDateIn],	
	[AnimalKennelDateOut]
 	FROM [dbo].[AnimalKennel]
END
GO     

/*
Created by: Ben Hanna
Date: 2/18/2020
Comment: Sets an animal's adoptable state to false
*/          
DROP PROCEDURE IF EXISTS [sp_select_handling_notes_by_id]
GO      
PRINT '' PRINT '*** Creating sp_select_handling_notes_by_id'
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
Created by: Ben Hanna
Date: 2/29/2020
Comment: Insert a handing notes record
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_handling_notes_record]
GO                  
PRINT '' PRINT '*** Creating sp_INSERT_handling_notes_record'
GO
CREATE PROCEDURE [sp_INSERT_handling_notes_record]
(
    
	@AnimalID              [int],			
	@UserID			       [int],
	@AnimalHandlingNotes   [nvarchar](4000),
	@TemperamentWarning    [nvarchar](1000),
	@UpdateDate		       [date]      
        
)
AS
BEGIN
   INSERT INTO [dbo].[AnimalHandlingNotes] 
        ([AnimalID], 
         [UserID], 
         [AnimalHandlingNotes],
         [TemperamentWarning],
         [UpdateDate]
        )
   VALUES 
        (@AnimalID,
         @UserID,
         @AnimalHandlingNotes,
         @TemperamentWarning,
         @UpdateDate
         
        )
   SELECT SCOPE_IDENTITY()
END
GO 
  
/*
Created by: Ben Hanna
Date: 3/4/2020
Comment: Update a handing notes record
*/ 
DROP PROCEDURE IF EXISTS [sp_update_handling_notes_record]
GO     
PRINT '' PRINT '*** Creating sp_update_handling_notes_record'
GO
CREATE PROCEDURE [sp_update_handling_notes_record]
(
    @AnimalHandlingNotesID			   [int],
    
    @NewAnimalID                       [int],
    @NewUserID                         [int], 
    @NewAnimalHandlingNotes	           [nvarchar](4000),
    @NewTemperamentWarning             [nvarchar](1000),
    @NewUpdateDate                     [date],
    
	@OldAnimalID                       [int],
    @OldUserID                         [int], 
    @OldAnimalHandlingNotes	           [nvarchar](4000),
    @OldTemperamentWarning             [nvarchar](1000),
    @OldUpdateDate                     [date]
)
AS
BEGIN
	UPDATE [dbo].[AnimalHandlingNotes]
    SET [AnimalID]                  = @NewAnimalID, 
        [UserID]                    = @NewUserID,  
        [AnimalHandlingNotes]       = @NewAnimalHandlingNotes,
        [TemperamentWarning]        = @NewTemperamentWarning,
        [UpdateDate]                = @NewUpdateDate        
    WHERE   [AnimalHandlingNotesID] = @AnimalHandlingNotesID
    AND     [AnimalID]              = @OldAnimalID 
    AND     [UserID]                = @OldUserID  
    AND     [AnimalHandlingNotes]   = @OldAnimalHandlingNotes
    AND     [TemperamentWarning]    = @OldTemperamentWarning
    AND     [UpdateDate]            = @OldUpdateDate
    RETURN @@ROWCOUNT
END 
GO 

/*
  Created by: Jordan Lindo
  Date: 2/5/2020
  Comment: This is a stored procedure for INSERTing new departments into the
  department table.
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_department]
GO    
PRINT '' PRINT '*** Create procedure sp_INSERT_department'
GO
CREATE PROCEDURE [sp_INSERT_department]
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

/*
  Created by: Jordan Lindo
  Date: 2/5/2020
  Comment: This is a stored procedure for selecting all department records.
*/
DROP PROCEDURE IF EXISTS [sp_select_all_departments]
GO   
PRINT '' PRINT '*** Create procedure sp_select_all_departments'
GO
CREATE PROCEDURE [sp_select_all_active_departments]
AS
BEGIN
	SELECT [DepartmentID],[Description]
	FROM [Department]
	WHERE [Active] = 1
END
GO

/*
  Created by: Jordan Lindo
  Date: 2/5/2020
  Comment: This is a stored procedure for selecting all records with a departmentID
  matching the input.
*/
DROP PROCEDURE IF EXISTS [sp_select_all_departments]
GO   
PRINT '' PRINT '*** Create procedure sp_select_department_by_id'
GO
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

/*
 Created by: Jordan Lindo
 Date: 2/15/2020
 Comment: This is a stored procedure for updating a department record.
*/
DROP PROCEDURE IF EXISTS [sp_update_department]
GO   
PRINT '' PRINT '*** Create procedure sp_update_department'
GO
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
Sproc for INSERTing a shift time

Author: Lane Sandburg
2/5/2020

*/
DROP PROCEDURE IF EXISTS [sp_INSERT_ShiftTime]
GO
PRINT '' PRINT '*** creating sp_INSERT_ShiftTime'
GO
CREATE PROCEDURE [sp_INSERT_ShiftTime](
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
DROP PROCEDURE IF EXISTS [sp_select_all_ShiftTimes]
GO
PRINT '' PRINT '*** creating sp_select_all_ShiftTimes'
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
DROP PROCEDURE IF EXISTS [sp_update_shiftTime]
GO
PRINT '' PRINT '*** creating sp_update_shiftTime'
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
Sproc for Retreiveing Departments

Author: Lane Sandburg
03/05/2020
*/
DROP PROCEDURE IF EXISTS [sp_delete_shiftTime]
GO
PRINT '' PRINT '*** creating sp_delete_shiftTime'
GO
CREATE PROCEDURE [sp_delete_shiftTime](
		@ShiftTimeID [int]
)
AS
BEGIN
	DELETE FROM [dbo].[ShiftTime]
	WHERE [ShiftTimeID] = @ShiftTimeID
	RETURN @@ROWCOUNT

END
GO

/*
Created by: Mohamed Elamin
Date: 2/2/2020
Comment: Sproc to pull list of Adoption Applications which their status
is inHomeInspection.
*/
DROP PROCEDURE IF EXISTS [sp_select_AdoptionApplication_by_Status]
GO
PRINT '' PRINT '*** Creating sp_select_AdoptionApplication_by_Status'
GO
CREATE PROCEDURE [sp_select_AdoptionApplication_by_Status]
AS
BEGIN
	SELECT 	AdoptionApplicationID,AnimalID,CustomerEmail,Status,RecievedDate
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
DROP PROCEDURE IF EXISTS [sp_select_AnimalName_by_AnimalID]
GO
PRINT '' PRINT '*** Creating sp_select_AnimalName_by_AnimalID'
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
DROP PROCEDURE IF EXISTS [sp_select_CustomerName_by_CustomerEmail]
GO
PRINT '' PRINT '*** Creating sp_select_CustomerName_by_CustomerEmail'
GO
CREATE PROCEDURE [sp_select_CustomerName_by_CustomerEmail]
(
	@CustomerEmail 		[int]
)
AS
BEGIN
	SELECT 	
            FirstName,
            LastName
	FROM 	[dbo].[Customer]
	WHERE	[Email] = @CustomerEmail
END
GO

/*
Created by: Mohamed Elamin
Date: 02/18/2020
Comment: Sproc to find Customer by Customer name from the User Table.
*/
DROP PROCEDURE IF EXISTS [sp_select_Customer_by_Customer_Name]
GO
PRINT '' PRINT '*** Creating sp_select_Customer_by_Customer_Name'
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
DROP PROCEDURE IF EXISTS [sp_update_AdoptionApliction]
GO
PRINT '' PRINT '*** Creating sp_update_AdoptionApliction'
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
Created by: Mohamed Elamin
Date: 02/18/2020
Comment: Sproc to gets ALL Adoption applications where their  Appointment
status is Interviewer
*/
DROP PROCEDURE IF EXISTS [sp_select_interviewer_Appointments_by_AppointmentType]
GO
PRINT '' PRINT '*** Creating sp_select_interviewer_Appointments_by_AppointmentType'
GO
CREATE PROCEDURE [sp_select_interviewer_Appointments_by_AppointmentType]
AS
BEGIN
	SELECT 	AppointmentID,AdoptionApplicationID,AppointmentTypeID,DateTime,Notes,
			Decision,LocationID
	FROM 	[dbo].[Appointment]
	WHERE	[AppointmentTypeID] = "Interviewer"
END
GO

/*
Created by: Mohamed Elamin
Date: 2/29/2020
Comment: store Procedure to updates Adoption appointment's notes for the
Interviewer which he will be enters these notes during the interview with the Customer.
*/
DROP PROCEDURE IF EXISTS [sp_update_Adoption_appointment_notes]
GO
PRINT '' PRINT '*** Creating sp_update_Adoption_appointment_notes'
GO
CREATE PROCEDURE [sp_update_Adoption_appointment_notes]
(
    @AppointmentID	      [int]             ,
	@NewNotes		      [nvarchar](1000)  ,
	@OldNotes    		  [nvarchar](1000)
)
AS
BEGIN
	UPDATE [dbo].[Appointment]
	SET [Notes] = 	  @NewNotes
	WHERE 	[AppointmentID] =	@AppointmentID
	AND	[Notes] = 	@OldNotes
	RETURN  @@ROWCOUNT
END
GO

/*
Created by: Cash Carlson
Date: 2/21/2020
Comment: Creating Stored Procedure sp_select_all_products_items
*/
DROP PROCEDURE IF EXISTS [sp_select_all_products_items]
GO
PRINT '' PRINT '*** Creating sp_select_all_products_items ***'
GO
CREATE PROCEDURE [sp_select_all_products_items]
AS
BEGIN
	SELECT
		[Product].[ProductID],
		[Product].[ProductName],
		[Product].[Brand],
		[Product].[ProductCateGOryID],
		[Product].[ProductTypeID],
		[Product].[Price],
		[Item].[ItemQuantity]
    FROM [Product]
    JOIN [Item] ON [Item].[ItemID] = [Product].[ItemID]
END
GO

/*
Created by: Derek Taylor
Date 2/21/2020
Comment: Stored Procedure to select all of the applicants
*/
DROP PROCEDURE IF EXISTS [sp_select_all_applicants]
GO
PRINT '' PRINT '*** Creating sp_select_all_applicants'
GO
CREATE PROCEDURE [sp_select_all_applicants]
AS
BEGIN
	SELECT [ApplicantID], [FirstName], [LastName], [MiddleName], [Email], [PhoneNumber]
	FROM [dbo].[Applicant]
	ORDER BY [ApplicantID]
END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: pull up a list of eRoles
*/
DROP PROCEDURE IF EXISTS [sp_select_all_eRoles]
GO
PRINT '' PRINT '*** Creating sp_select_all_eRoles'
GO
CREATE PROCEDURE sp_select_all_eRoles
AS
BEGIN
    SELECT 	[ERoleID],[DepartmentID],[Description],[Active]
    FROM 	[ERole]
END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: deactivate a eRoleID by ID
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_eRole]
GO
PRINT ''  PRINT '*** Creating sp_deactivate_eRole '
GO
CREATE PROCEDURE [sp_deactivate_eRole]
(

	@ERoleID	[nvarchar](50)
)
AS
BEGIN
	Update [dbo].[ERole]
	Set	[Active]=0
	Where [ERoleID] = @ERoleID
	Return @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: activate a eRoleID by ID
*/
DROP PROCEDURE IF EXISTS [sp_activate_eRole]
GO
PRINT ''  PRINT '*** Creating sp_activate_eRole '
GO
CREATE PROCEDURE [sp_activate_eRole]
(

	@ERoleID	[nvarchar](50)
)
AS
BEGIN
	Update [dbo].[ERole]
	Set [Active]=1
	Where [ERoleID] = @ERoleID
	Return @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: update an oldERole with a new eRole
*/
DROP PROCEDURE IF EXISTS [sp_update_eRole_by_id]
GO
PRINT ''  PRINT '*** Creating sp_update_eRole_by_id'
GO
CREATE PROCEDURE [sp_update_eRole]
(
	@OldERoleID	[nvarchar](50),
	@OldDepartmentID nvarchar(50),
	@OldDescription [nvarchar](200),

	--New rows
	@NewDepartmentID nvarchar(50),
	@NewDescription [nvarchar](200)
)
AS
BEGIN
	Update [dbo].[ERole]
	Set
	[DepartmentID]=@NewDepartmentID,
	[Description]=@NewDescription
	Where [ERoleID] = @OldERoleID
	And [DepartmentID] = @OldDepartmentID
	And [Description] = @OldDescription
	Return @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: INSERT a new eRole
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_eRole]
GO
PRINT ''  PRINT '*** Creating sp_INSERT_eRole'
GO
CREATE PROCEDURE [sp_INSERT_eRole]
(
	@ERoleID[nvarchar](50),
	@DepartmentID[nvarchar](50),
	@Description[nvarchar](200)
)
AS
BEGIN
	Insert Into [dbo].[ERole]
		([ERoleID],[DepartmentID],[Description])
	VALUES
		(@ERoleID,@DepartmentID,@Description)
END
GO

/*
Created by: Chase Schulte
Date: 2/05/2020
Comment: delete an eRole
*/
DROP PROCEDURE IF EXISTS [sp_delete_eRole]
GO
PRINT '' PRINT '*** Creating sp_delete_eRole '
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
DROP PROCEDURE IF EXISTS [sp_select_all_active_eRoles]
GO
PRINT '' PRINT '*** Creating sp_select_all_active_eRoles'
GO
CREATE PROCEDURE [sp_select_all_active_eRoles]
(
    @Active				[bit]
)
AS
BEGIN
	select [ERoleID],[DepartmentID],[Description],[Active]
	FROM [dbo].[ERole]
	WHERE [Active] = @Active
END
GO

/*
Created by: Chase Schulte
Date: 02/28/2020
Comment: Select UserERole by userID
*/
DROP PROCEDURE IF EXISTS [sp_select_user_eRole_by_user_id]
GO
PRINT '' PRINT '*** Creating sp_select_user_eRole_by_user_id'
GO
CREATE PROCEDURE sp_select_user_eRole_by_user_id
(
    @UserID		[int]
)
AS
BEGIN
    SELECT [ERoleID]
    FROM 	[UserERole]
    WHERE 	[UserID] = @UserID
END
GO

/*
Created by: Chase Schulte
Date: 02/28/2020
Comment: Add a UserERole
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_user_eRole]
GO
PRINT ''  PRINT '*** Creating sp_INSERT_user_eRole'
GO
CREATE PROCEDURE [sp_INSERT_user_eERole]
(
	@UserID			[int],
	@ERoleID		[nvarchar](50)
)
AS
BEGIN
INSERT INTO [dbo].[UserERole]
	([UserID], [ERoleID])
	VALUES
	(@UserID, @ERoleID)
END
GO

/*
Created by: Chase Schulte
Date: 02/28/2020
Comment: Delete a UserERole
*/
DROP PROCEDURE IF EXISTS [sp_delete_user_eRole]
GO
PRINT '' PRINT '*** Creating sp_delete_user_eRole'
GO
CREATE PROCEDURE sp_delete_user_eRole
(
	@UserID			[int],
	@ERoleID				[nvarchar](50)
)
AS
BEGIN
	DELETE FROM [dbo].[UserERole]
	WHERE [UserID] = @UserID
	AND [ERoleID] = @ERoleID
END
GO

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Insert a volunteer task record
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_volunteer_task]
GO
PRINT '' PRINT '*** Creating sp_INSERT_volunteer_task'
GO
CREATE PROCEDURE [sp_INSERT_volunteer_task]
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
Comment: Selects volunteer task by name
*/
DROP PROCEDURE IF EXISTS [sp_select_volunteer_task_by_name]
GO
PRINT '' PRINT '*** Creating sp_select_volunteer_task_by_name'
GO
CREATE PROCEDURE [sp_select_volunteer_task_by_name]
(
	@taskName [NVARCHAR](100)
)
AS
BEGIN
	SELECT 
        [VolunteerTaskID], 
        [TaskName], 
        [TaskType], 
        [AssignmentGroup], 
        [DueDate], 
        [TaskDescription]
	FROM [dbo].[VolunteerTask]
	WHERE [TaskName] = @taskName
END
GO

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Select all volunteer tasks
*/
DROP PROCEDURE IF EXISTS [sp_select_all_volunteer_tasks]
GO
PRINT '' PRINT '*** Creating sp_select_all_volunteer_tasks'
GO
CREATE PROCEDURE [sp_select_all_volunteer_tasks]
AS
BEGIN
	SELECT 
        [TaskName],
        [TaskType],
        [AssignmentGroup], 
        [DueDate], 
        [TaskDescription]
	FROM [dbo].[VolunteerTask]
END
GO

/*
Created by: Ethan Holmes
Date: 02/16/2020
Comment: Updates a volunteer task record
*/
DROP PROCEDURE IF EXISTS [sp_update_volunteer_task_by_name]
GO
PRINT '' PRINT '*** Creating sp_update_volunteer_task_by_name'
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
Comment: Stored Procedure that selects Adoption Customers by active status
*/
DROP PROCEDURE IF EXISTS [sp_select_adoption_customers_by_active]
GO
PRINT '' PRINT '*** Creating sp_select_adoption_customers_by_active'
GO
CREATE PROCEDURE [sp_select_adoption_customers_by_active]
(
	@Active			[bit]
)
AS
BEGIN
	SELECT
	[FirstName]
	,[LastName]
	,[PhoneNumber]
	,[Email]
	,[Customer].[Active]
	,[City],[State]
	,[Zipcode]
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
	FROM [Customer] 
	JOIN [AdoptionApplication] ON [Customer].[Email] = [AdoptionApplication].[CustomerEmail]
	JOIN [Animal] ON [Animal].[AnimalID] = [AdoptionApplication].[AnimalID]
	WHERE [Customer].[Email] IS NOT NULL
	AND [Customer].[Active] = @Active
END
GO


/*
Created by: Austin Gee
Date: 2/21/2020
Comment: Stored Procedure that selects adoption appointments by active and type.
*/
DROP PROCEDURE IF EXISTS [sp_select_adoption_appointments_by_active_and_type]
GO
PRINT '' PRINT '*** Creating sp_select_adoption_appointments_by_active_and_type'
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
	,[Customer].[Email]
	,[Animal].[AnimalID]
	,[AdoptionApplication].[Status]
	,[AdoptionApplication].[RecievedDate]
	,[Location].[Name]
	,[Location].[Address1]
	,[Location].[Address2]
	,[Location].[City]
	,[Location].[State]
	,[Location].[Zip]
	,[Customer].[FirstName]
	,[Customer].[LastName]
	,[Customer].[PhoneNumber]
	,[Customer].[Email]
	,[Customer].[Active]
	,[Customer].[City]
	,[Customer].[State]
	,[Customer].[Zipcode]
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
	JOIN [Customer] ON [AdoptionApplication].[CustomerEmail] = [Customer].[Email]
	JOIN [Animal] ON [AdoptionApplication].[AnimalID] = [Animal].[AnimalID]
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
DROP PROCEDURE IF EXISTS [sp_select_inHomeInspectionAppointments_by_AppointmentType]
GO
PRINT '' PRINT '*** Creating sp_select_inHomeInspectionAppointments_by_AppointmentType'
GO
CREATE PROCEDURE [sp_select_inHomeInspectionAppointments_by_AppointmentType]
AS
BEGIN
	SELECT 	
        [AppointmentID],
        [AdoptionApplicationID],
        [AppointmentTypeID],
        [DateTime],
        [Notes],
		[Decision],
        [LocationID],
        [Active]
	FROM 	[dbo].[Appointment]
	WHERE	[AppointmentTypeID] = "inHomeInspection"
END
GO

/*
Created by: Kaleb Bachert
Date: 3/3/2020
Comment: Procedure to add a Time Off Request
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_time_off_request]
GO
PRINT '' PRINT '*** Creating sp_INSERT_time_off_request'
GO
CREATE PROCEDURE [sp_INSERT_time_off_request]
(
	@EffectiveStart			[datetime],
	@EffectiveEnd			[datetime],
	@RequestingUserID		[int]
)
AS
BEGIN
	INSERT INTO [dbo].[request]
	([RequestTypeID], [DateCreated], [RequestingUserID])
	VALUES
	('Time Off', GETDATE(), @RequestingUserID)

	INSERT INTO [dbo].[timeOffRequest]
	([EffectiveStart], [EffectiveEnd], [RequestID])
	VALUES
	(@EffectiveStart, @EffectiveEnd, SCOPE_IDENTITY())
END
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Method to retrieve all submitted requests by status
*/
DROP PROCEDURE IF EXISTS [sp_select_requests_by_status]
GO
PRINT '' PRINT '*** Creating sp_select_requests_by_status'
GO
CREATE PROCEDURE [sp_select_requests_by_status]
(
	@OpenStatus			[bit]
)
AS
BEGIN
	SELECT [RequestID], [RequestTypeID], [RequestingUserID], [DateCreated]
	FROM [dbo].[request]
	WHERE [Open] = @OpenStatus
END
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Method to retrieve a TimeOffRequest with a specified RequestID
*/
DROP PROCEDURE IF EXISTS [sp_select_time_off_request_by_requestid]
GO
PRINT '' PRINT '*** Creating sp_select_time_off_request_by_requestid'
GO
CREATE PROCEDURE [sp_select_time_off_request_by_requestid]
(
	@RequestID			[int]
)
AS
BEGIN
	SELECT [TimeOffRequestID], [EffectiveStart], [EffectiveEnd], [ApprovalDate], [ApprovingUserID], [RequestID]
	FROM [dbo].[timeOffRequest]
	WHERE [RequestID] = @RequestID
END
GO

/*
Created by: Kaleb Bachert
Date: 2/19/2020
Comment: Method to approve a specified request
*/
DROP PROCEDURE IF EXISTS [sp_approve_time_off_request]
GO
PRINT '' PRINT '*** Creating sp_approve_time_off_request'
GO
CREATE PROCEDURE [sp_approve_time_off_request]
(
	@RequestID		[int],
	@UserID			[int]
)
AS
BEGIN
	UPDATE [dbo].[timeOffRequest]
	SET [ApprovingUserID] = @UserID,
		[ApprovalDate] = GETDATE()
	WHERE [RequestID] = @RequestID
	AND [ApprovingUserID] IS NULL

	UPDATE [dbo].[request]
	SET [Open] = 0
	WHERE [RequestID] = @RequestID
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
CREATE PROCEDURE [dbo].[sp_update_adoption_application_status]
(@status [nvarchar](100), @AdoptionApplicationID [int])
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
Date: 2/12/2020
Comment: Create SP retrieve Customer Answers from CustomerAnswer Table by using Customer ID
Updated By: Awaab Elamin
Date: 3/15/2020
Comment: Updated CustomerID to CustomerEmail
*/
GO
print '' print '*** sp_get_Customer_Answer_By_CustomrEmail'
GO
Create PROCEDURE [dbo].[sp_get_Customer_Answer_By_CustomrEmail]
(
	@CustomerEmail Nvarchar(250)
)
AS
BEGIN
	SELECT 	[QuestionDescription],[Answer]
	From 	[dbo].[CustomerAnswers]
	WHERE	[CustomerEmail] = @CustomerEmail
END
GO

GO
/*
Created by: Awaab Elamin
Date: 2/12/2020
Comment: Create SP retrieve Customer ID from Customers  Table by using user ID
Updated by Awaab Elamin
Date: 3/15/2020
Comment: Canceled SP because dosn't work after Customer Table Updated

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
*/
/*
Created by: Awaab Elamin
Date: 2/12/2020
Comment: Create SP retrieve question description by question ID
*/
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
/*
Created by: Awaab Elamin
Date: 2/5/2020
Comment: Spoc to retrieve all Adoption Applications
Updated by: Awaab Elamin
Date: 3/15/2020
Comment: Update CustomerID to CustomerEmail
*/
GO
print '' print '*** Creating sp_get_Adoption_Application'
GO
Create PROCEDURE [dbo].[sp_get_Adoption_Application]
AS
BEGIN
	SELECT 	[AdoptionApplicationID],
			[dbo].[AdoptionApplication].[CustomerEmail],
			[dbo].[Animal].[AnimalName],
			[dbo].[AdoptionApplication].[Status],
			[dbo].[AdoptionApplication].[RecievedDate]
	From 	[dbo].[AdoptionApplication]
	Inner Join [dbo].[Animal] 
	on [dbo].[AdoptionApplication].[AnimalID] = [dbo].[Animal].[AnimalID]
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
Updated By: Awaab Elamin
Date: 3/15/2020
Comment: Update Sp to retrieve the Application by Customer Email
*/
GO
print '' print '*** Creating sp_get_Adoption_Application_By_CustomerEmail'
GO
CREATE PROCEDURE [dbo].[sp_get_Adoption_Application_By_CustomerEmail]
(@customerEmail [nvarchar](250))
AS
BEGIN
	SELECT 	[AdoptionApplicationID],
			[AnimalID],
			[Status],
			[RecievedDate]
	From 	[dbo].[AdoptionApplication]
	WHERE	[CustomerEmail] = @customerEmail;
END
GO
/*
Created by: Jaeho Kim
Date: 03/05/2020
Comment: Selects a list of all transactions with join tables for the customer
*/
DROP PROCEDURE IF EXISTS [sp_select_all_transactions]
GO
PRINT '' PRINT '*** Creating sp_select_all_transactions'
GO
CREATE PROCEDURE sp_select_all_transactions
AS
BEGIN
    SELECT
        T.[TransactionID]
        ,T.[TransactionDate]
        ,U.[UserID]
        ,U.[FirstName]
        ,U.[LastName]
        ,T.[TransactionTypeID]
        ,T.[TransactionStatusID]
        ,T.[Notes]
    FROM 	[Transaction] T
    INNER JOIN [User] U
        ON T.[EmployeeID] = U.[UserID]
END
GO

/*
Created by: Alex Diers
Date: 2/28/2020
Comment: Stored procedure to add a training video
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_training_video]
GO
PRINT '' PRINT '*** Creating sp_INSERT_training_video'
GO
CREATE PROCEDURE [sp_INSERT_training_video]
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
DROP PROCEDURE IF EXISTS [sp_select_videos_by_employee]
GO
PRINT '' PRINT '*** Creating sp_select_videos_by_employee'
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
Created by: Chase Schulte
Date: 2/28/2020
Comment: Stored procedure to update a training video
*/
DROP PROCEDURE IF EXISTS [sp_update_trainer_video]
GO
PRINT '' PRINT '*** Creating sp_update_trainer_video'
Go
CREATE PROCEDURE [sp_update_trainer_video]
(
	@OldTrainingVideoID	[nvarchar](150),
	@OldRunTimeMinutes	[int],
	@OldRunTimeSeconds 	[int],
	@OldDescription 	[nvarchar](1000),


	--New rows
	@NewRunTimeMinutes	[int],
	@NewRunTimeSeconds 	[int],
	@NewDescription 	[nvarchar](1000)


)
AS
BEGIN
	Update [dbo].[TrainingVideo]
	Set
	[RunTimeMinutes]=@NewRunTimeMinutes,
	[RunTimeSeconds]=@NewRunTimeSeconds,
	[Description]=@NewDescription
	Where [TrainingVideoID] = @OldTrainingVideoID
	And [RunTimeMinutes] = @OldRunTimeMinutes
	And [RunTimeSeconds] = @OldRunTimeSeconds
	And [Description] = @OldDescription
	Return @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 2/28/2020
Comment: Stored procedure to deactivate a training video
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_training_video]
GO
PRINT '' PRINT '*** Creating sp_deactivate_trainer_video'
GO
CREATE PROCEDURE [sp_deactivate_training_video]
(
	@TrainingVideoID	[nvarchar](150)
)
AS
BEGIN
	Update [dbo].[TrainingVideo]
	Set
	[Active]=0
	Where [TrainingVideoID] = @TrainingVideoID
	Return @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 2/28/2020
Comment: Stored procedure to activate a training video
*/
DROP PROCEDURE IF EXISTS [sp_reactivate_trainer_video]
GO
PRINT '' PRINT '*** Creating sp_reactivate_trainer_video '
GO
CREATE PROCEDURE [sp_reactivate_trainer_video ]
(
	@TrainingVideoID	[nvarchar](150)
)
AS
BEGIN
	Update [dbo].[TrainingVideo]
	Set
	[Active]=1
	Where [TrainingVideoID] = @TrainingVideoID
	Return @@ROWCOUNT
END
GO

/*
Created by: Chase Schulte
Date: 3/03/2020
Comment: Stored procedure to select the videos to watch by their active state
*/
DROP PROCEDURE IF EXISTS [sp_select_videos_by_active]
GO
PRINT '' PRINT '*** Creating sp_select_videos_by_active'
GO
CREATE PROCEDURE [sp_select_videos_by_active]
(
	@Active 	[bit]
)
AS
	BEGIN
	SELECT	[TrainingVideoID], [RunTimeMinutes], [RunTimeSeconds], [Description],[Active]
	FROM		[TrainingVideo]
	Where [Active] = @Active
	ORDER BY [TrainingVideoID]
END
GO

/*
Created by: Tener Karar
Date: 02/16/2020
Comment:retrieve ItemLocations List
*/
DROP PROCEDURE IF EXISTS [sp_retrieve_ItemLocations_List]
GO
PRINT '' PRINT '*** Creating sp_retrieve_ItemLocations_List'
GO
CREATE PROCEDURE sp_retrieve_ItemLocations_List( @ItemID int)
AS
BEGIN
	SELECT  [LocationID]
	FROM [dbo].[ItemLocationLine ]
	where [ItemID] = @ItemID
END
GO

/*
Created by: Tener Karar and Brandyn Coverdill
Date: 02/16/2020
Comment:retrieve Item List
*/
DROP PROCEDURE IF EXISTS [sp_retrieve_item_list]
GO
PRINT '' PRINT '*** Creating sp_retrieve_item_list'
GO
CREATE PROCEDURE sp_retrieve_item_list
AS
BEGIN
	SELECT [ItemID], [ItemName]	,[ItemQuantity] ,[ItemCateGOryID]
	FROM [dbo].[Item]
END
GO

/*
Created by: Tener Karar
Date: 02/16/2020
Comment:retrieve ItemCateGOry List
*/
DROP PROCEDURE IF EXISTS [sp_retrieve_ItemCateGOry_list]
GO
PRINT '' PRINT '*** Creating sp_retrieve_ItemCateGOry_list'
GO
CREATE PROCEDURE sp_retrieve_ItemCateGOry_list
AS
BEGIN
	SELECT [ItemCateGOryID] ,[Description]
	FROM [dbo].[ItemCateGOry ]
END
GO

/*
Created by: Tener Karar
Date: 02/16/2020
Comment:update Item Location
*/
DROP PROCEDURE IF EXISTS [sp_update_Item_Location]
GO
PRINT '' PRINT '*** Creating sp_update_Item_Location'
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
Comment: Procedure for INSERTing volunteer shifts
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_volunteer_shift]
GO
PRINT '' PRINT '*** Creating procedure sp_INSERT_volunteer_shift'
GO
CREATE PROCEDURE [sp_INSERT_volunteer_shift]
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
AS
BEGIN
	INSERT INTO [dbo].[VolunteerShift]
		([ShiftDescription], [ShiftTitle], [ShiftDate],
		[ShiftStartTime], [ShiftEndTime], [Recurrance],
		[IsSpecialEvent], [ShiftNotes], [ScheduleID])
	VALUES
		(@ShiftDescription, @ShiftTitle, @ShiftDate,
		@ShiftStartTime, @ShiftEndTime, @Recurrance,
		@IsSpecialEvent, @ShiftNotes, @ScheduleID)
END
GO

/*
Created By: Timothy Lickteig
Date: 2/05/2020
Comment: Procedure for deleting a volunteer shift
*/
DROP PROCEDURE IF EXISTS [sp_delete_volunteer_shift]
GO
PRINT '' PRINT '*** Creating procedure sp_delete_volunteer_shift'
GO
CREATE PROCEDURE [sp_delete_volunteer_shift]
(
	@ShiftID [int]
)
AS
BEGIN
	DELETE FROM [dbo].[VolunteerShift]
	WHERE [VolunteerShiftID] = @ShiftID
END
GO

/*
Created By: Timothy Lickteig
Date: 2/10/2020
Comment: Procedure for updating a volunteer shift
*/
DROP PROCEDURE IF EXISTS [sp_update_volunteer_shift]
GO
PRINT '' PRINT '*** Creating procedure sp_update_volunteer_shift'
GO
CREATE PROCEDURE [sp_update_volunteer_shift]
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
AS
BEGIN
	UPDATE [VolunteerShift]
	SET [ShiftDescription] = @ShiftDescription,
	    [ShiftDate] = @ShiftDate,
	    [ShiftTitle] = @ShiftTitle,
	    [ShiftStartTime] = @ShiftStartTime,
	    [ShiftEndTime] = @ShiftEndTime,
	    [Recurrance] = @Recurrance,
	    [IsSpecialEvent] = @IsSpecialEvent,
	    [ShiftNotes] = @ShiftNotes,
	    [ScheduleID] = @ScheduleID
	WHERE [VolunteerShiftID] = @VolunteerShiftID
	SELECT @@ROWCOUNT
END
GO

/*
Created By: Timothy Lickteig
Date: 2/17/2020
Comment: Procedure for selecting all volunteer shifts
*/
DROP PROCEDURE IF EXISTS [sp_select_all_volunteer_shifts]
GO
PRINT '' PRINT '*** Creating procedure sp_select_all_volunteer_shifts'
GO

CREATE PROCEDURE [sp_select_all_volunteer_shifts]
AS
BEGIN
	SELECT
		[VolunteerShiftID], [ShiftDescription],
		[ShiftTitle], [ShiftStartTime], [ShiftEndTime],
		[Recurrance], [IsSpecialEvent], [ShiftNotes],
		[ShiftDate], [ScheduleID]
	FROM [dbo].[VolunteerShift]
END
GO

/*
Created By: Chuck Baxter
Date: 2/28/2020
Comment: select animal species
*/
DROP PROCEDURE IF EXISTS [sp_select_animal_species]
GO
PRINT '' PRINT '*** Creating procedure sp_select_animal_species'
GO
CREATE PROCEDURE [sp_select_animal_species]
AS
BEGIN
    SELECT 	[AnimalSpeciesID]
    FROM	[dbo].[AnimalSpecies]
END
GO

--Stored Procedures for Event Processes
/*
	Created by: Steve Coonrod
	Date: 		2/9/2020
	Comment: 	Stored Procedure for adding a new event to the DB
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_event]
GO
PRINT '' PRINT '*** Creating sp_INSERT_event'
GO
CREATE PROCEDURE [sp_INSERT_event]
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
DROP PROCEDURE IF EXISTS [sp_update_event]
GO
PRINT '' PRINT '*** Creating sp_update_event'
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
    UPDATE 	[dbo].[Event]
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
DROP PROCEDURE IF EXISTS [sp_select_event_by_ID]
GO
PRINT '' PRINT '*** Creating sp_select_event_by_ID'
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
DROP PROCEDURE IF EXISTS [sp_select_all_events]
GO
PRINT '' PRINT '*** Creating sp_select_all_events'
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
DROP PROCEDURE IF EXISTS [sp_delete_event]
GO
PRINT '' PRINT '*** Creating sp_delete_event'
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
DROP PROCEDURE IF EXISTS [sp_INSERT_event_type]
GO
PRINT '' PRINT '*** Creating sp_INSERT_event_type'
GO
CREATE PROCEDURE [sp_INSERT_event_type]
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
DROP PROCEDURE IF EXISTS [sp_select_all_event_types]
GO
PRINT '' PRINT '*** Creating sp_select_all_event_types'
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
DROP PROCEDURE IF EXISTS [sp_INSERT_event_request]
GO
PRINT '' PRINT '*** Creating sp_INSERT_event_request'
GO
CREATE PROCEDURE [sp_INSERT_event_request]
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

/*
	Created by: Steve Coonrod
	Date: 2/9/2020
	Comment: Stored Procedure for adding a new Request to the DB
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_request]
GO
PRINT '' PRINT '*** Creating sp_INSERT_request'
GO
CREATE PROCEDURE [sp_INSERT_request]
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

/*
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Stored Procedure for selecting new requests associated with a DepartmentID
*/
DROP PROCEDURE IF EXISTS [sp_select_new_requests_by_departmentID]
GO
PRINT '' PRINT '*** Creating sp_select_new_requests_by_departmentID'
GO
CREATE PROCEDURE [sp_select_new_requests_by_departmentID]
(
	@DepartmentID				[nvarchar](50)
)
AS
BEGIN
	SELECT DISTINCT r.[RequestID], r.[DateCreated], r.[RequestTypeID],
		r.[RequestingUserID], dr.[RequestGroupID], dr.[RequestedGroupID],
		dr.[RequestSubject], dr.[RequestTopic], dr.[RequestBody]
	FROM [request] AS r JOIN [DepartmentRequest] AS dr ON
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
DROP PROCEDURE IF EXISTS [sp_select_active_requests_by_departmentID]
GO
PRINT '' PRINT '*** Creating sp_select_active_requests_by_departmentID'
GO
CREATE PROCEDURE [sp_select_active_requests_by_departmentID]
(
	@DepartmentID				[nvarchar](50)
)
AS
BEGIN
	SELECT DISTINCT r.[RequestID], r.[DateCreated], r.[RequestTypeID],
		r.[RequestingUserID], dr.[RequestGroupID], dr.[RequestedGroupID],
		dr.[DateAcknowledged], dr.[AcknowledgingUserID], dr.[RequestSubject],
		dr.[RequestTopic], dr.[RequestBody]
	FROM [request] AS r JOIN [DepartmentRequest] AS dr ON
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
DROP PROCEDURE IF EXISTS [sp_select_completed_requests_by_departmentID]
GO
PRINT '' PRINT '*** Creating sp_select_completed_requests_by_departmentID'
GO
CREATE PROCEDURE [sp_select_completed_requests_by_departmentID]
(
	@DepartmentID				[nvarchar](50)
)
AS
BEGIN
	SELECT DISTINCT r.[RequestID], r.[DateCreated], r.[RequestTypeID],
		r.[RequestingUserID], dr.[RequestGroupID], dr.[RequestedGroupID],
		dr.[DateAcknowledged], dr.[AcknowledgingUserID], dr.[DateCompleted],
		dr.[CompletedUserID], dr.[RequestSubject], dr.[RequestTopic], dr.[RequestBody]
	FROM [request] AS r JOIN [DepartmentRequest] AS dr ON
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
DROP PROCEDURE IF EXISTS [sp_select_all_request_types]
GO
PRINT '' PRINT '*** Creating sp_select_all_request_types'
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
DROP PROCEDURE IF EXISTS [sp_select_all_departmentIDs]
GO
PRINT '' PRINT '*** Creating sp_select_all_departmentIDs'
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
DROP PROCEDURE IF EXISTS [sp_select_all_employee_names]
GO
PRINT '' PRINT '*** Creating sp_select_all_employee_names'
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

/*
Created by: Ryan Morganti
Date: 2020/02/22
Comment: Stored Procedure for retrieving the Departments an employee is associated with
*/
DROP PROCEDURE IF EXISTS [select_all_departments_by_userID]
GO
PRINT '' PRINT '*** Creating stored procedure select_all_departments_by_userID'
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
DROP PROCEDURE IF EXISTS [sp_add_items]
GO
PRINT '' PRINT '*** Creating sp_add_items'
GO
CREATE PROCEDURE [sp_add_items]
(
	@ItemName nvarchar(50),
	@ItemQuantity int,
	@ItemCateGOryID nvarchar(50),
	@ItemDescription nvarchar(250)
)
AS
BEGIN
	INSERT INTO Item
    (
		[ItemName],
		[ItemCateGOryID],
		[ItemQuantity],
		[ItemDescription]
	)
	VALUES
    (
		@ItemName,
		@ItemCateGOryID,
		@ItemQuantity,
		@ItemDescription
	)
END
GO

/*
Created By: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Stored Procedure that adds a new item cateGOry
*/
DROP PROCEDURE IF EXISTS [sp_add_new_cateGOry]
GO
PRINT '' PRINT '*** Creating [sp_add_new_cateGOry]'
GO
CREATE PROCEDURE [sp_add_new_cateGOry]
(
	@ItemCateGOryID nvarchar(50),
    @Description nvarchar(250)
)
AS
BEGIN
	INSERT INTO [dbo].[ItemCateGOry](
		[ItemCateGOryID],
		[Description]
	)
	VALUES(@ItemCateGOryID, @Description)
END
GO

/*
Created by: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Stored Procedure that gets a list of cateGOries.
*/
DROP PROCEDURE IF EXISTS [sp_list_cateGOries]
GO
PRINT '' PRINT '*** Creating sp_list_cateGOries'
GO
CREATE PROCEDURE [sp_list_cateGOries]
AS
BEGIN
	SELECT DISTINCT [ItemCateGOryID]
	FROM [dbo].[ItemCateGOry]
END
GO

/*
Created by: Brandyn T. Coverdill
Date: 2/22/2020
Comment: Stored Procedure that gets a list of items from inventory.
*/
DROP PROCEDURE IF EXISTS [sp_retrieve_items]
GO
PRINT '' PRINT '*** Creating sp_retrieve_items'
GO
CREATE PROCEDURE [sp_retrieve_items]
AS
BEGIN
	SELECT 
        [i].[ItemID], 
        [i].[ItemName], 
        [i].[ItemQuantity], 
        [ic].[ItemCateGOryID], 
        [i].[ItemDescription]
	FROM [dbo].[Item] i
	INNER JOIN [dbo].[ItemCateGOry] ic
	ON [i].[ItemCateGOryID] = [ic].[ItemCateGOryID]
END
GO

DROP PROCEDURE IF EXISTS [sp_INSERT_volunteer]
GO
PRINT '' PRINT '*** Creating sp_INSERT_volunteer'
GO
CREATE PROCEDURE [sp_INSERT_volunteer]
(
	@FirstName	 [nvarchar](500),
	@LastName	 [nvarchar](500),
	@Email       [nvarchar](100),
	@PhoneNumber [nvarchar](12),
	@OtherNotes  [nvarchar](2000)
)
AS
BEGIN
	INSERT INTO [dbo].[Volunteer]
		([FirstName], [LastName], [Email], [PhoneNumber], [OtherNotes])
	VALUES
		(@FirstName, @LastName, @Email, @PhoneNumber, @OtherNotes)
	SELECT SCOPE_IDENTITY()
END
GO

/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Gets Volunteers by first and last name
*/
DROP PROCEDURE IF EXISTS [sp_get_volunteer_by_name]
GO
PRINT '' PRINT '*** Creating sp_get_volunteer_by_name'
GO
CREATE PROCEDURE [sp_get_volunteer_by_name]
(
	@FirstName [nvarchar](500),
	@LastName [nvarchar](500)
)
AS
BEGIN
    SELECT
        VolunteerID, FirstName, LastName, Email, PhoneNumber, OtherNotes, Active
    FROM Volunteer
    WHERE FirstName = @FirstName
    AND LastName = @LastName
END
GO

/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Gets a list of all skills
*/
DROP PROCEDURE IF EXISTS [sp_select_all_skills]
GO
PRINT '' PRINT '*** Creating sp_select_all_skills'
GO
CREATE PROCEDURE [sp_select_all_skills]
AS
BEGIN
	SELECT [SkillID]
	FROM [dbo].[VolunteerSkills]
	ORDER BY [SkillID]
END
GO

/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Give a volunteer new skill
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_volunteer_skill]
GO
PRINT '' PRINT '*** Creating sp_INSERT_volunteer_skill'
GO
CREATE PROCEDURE [sp_INSERT_volunteer_skill]
(
	@VolunteerID 			[int],
	@SkillID	 			[nvarchar](50)
)
AS
BEGIN
INSERT INTO [dbo].[VolunteerSkill]
	([VolunteerID], [SkillID])
	VALUES
	(@VolunteerID, @SkillID)
END
GO

/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Removes a volunteer's skill
*/
DROP PROCEDURE IF EXISTS [sp_delete_volunteer_skill]
GO
PRINT '' PRINT '*** Creating sp_delete_volunteer_skill'
GO
CREATE PROCEDURE [sp_delete_volunteer_skill]
(
	@VolunteerID			[int],
	@SkillID				[nvarchar](50)
)
AS
BEGIN
	DELETE FROM [dbo].[VolunteerSkill]
	WHERE [VolunteerID] =	@VolunteerID
	  AND [SkillID] = 		@SkillID
END
GO

/*
Created by: Gabi Legrand
Date: 2/8/2020
Comment: Gets a list of all active volunteers
*/
DROP PROCEDURE IF EXISTS [sp_select_volunteers_by_active]
GO
PRINT '' PRINT '*** Creating sp_select_volunteers_by_active'
GO
CREATE PROCEDURE [sp_select_volunteers_by_active]
(

    @Active        [bit]

)
AS
BEGIN
    SELECT [VolunteerID], [FirstName], [LastName], [Email], [PhoneNumber], [OtherNotes], [Active]
    FROM  [dbo].[Volunteer]
    WHERE active = 1
    ORDER BY [LastName]
END
GO

/*
Created by: Zoey McDonald
Date: 2/20/2020
Comment: Insert a volunteer event.
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_volunteer_event]
GO
PRINT '' PRINT '*** Creating sp_INSERT_volunteer_event'
GO
CREATE PROCEDURE [sp_INSERT_volunteer_event]
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
DROP PROCEDURE IF EXISTS [sp_delete_volunteer_event]
GO
PRINT '' PRINT '*** Creating procedure sp_delete_volunteer_event'
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
DROP PROCEDURE IF EXISTS [sp_update_volunteer_event]
GO
PRINT '' PRINT '*** Creating procedure sp_update_volunteer_event'
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
DROP PROCEDURE IF EXISTS [sp_select_all_volunteer_events]
GO
PRINT '' PRINT '*** Creating procedure sp_select_all_volunteer_events'
GO
CREATE PROCEDURE [sp_select_all_volunteer_events]
AS 
BEGIN
	SELECT
		[VolunteerEventID],
		[EventName],
		[EventDescription]
	FROM [dbo].[VolunteerEvents]
END
GO

/*
Created by: Robert Holmes
Date: 2/18/2020
Comment: Stored procedure for selecting all products of a particular type.
*/
DROP PROCEDURE IF EXISTS [sp_select_products_by_type]
GO
PRINT '' PRINT '*** Creating stored procedure sp_select_products_by_type'
GO
CREATE PROCEDURE [sp_select_products_by_type]
(
	@ProductTypeID	[NVARCHAR](20)
)
AS
BEGIN
	SELECT		[ProductID]
			,	[ItemID]
			,	[ProductName]
			,	[ProductCateGOryID]
			,	[ProductTypeID]
			,	[Description]
			,	[Price]
			,	[Brand]
			,	[Taxable]
	FROM	[dbo].[Product]
	WHERE	[ProductTypeID] LIKE @ProductTypeID
END
GO

/*
Created by: Robert Holmes
Date: 2/18/2020
Comment: Stored procedure for selecting all products.
*/
DROP PROCEDURE IF EXISTS [sp_select_all_products]
GO
PRINT '' PRINT'*** Creating stored procedure sp_select_all_products'
GO
CREATE PROCEDURE [sp_select_all_products]
AS
BEGIN
	SELECT		[ProductID]
			,	[ItemID]
			,	[ProductName]
			,	[ProductCateGOryID]
			,	[ProductTypeID]
			,	[Description]
			,	[Price]
			,	[Brand]
			,	[Taxable]
	FROM	[dbo].[Product]
END
GO



/*
Created By: Michael Thompson
Date: 2/20/2020
Comment: Stored Procedure to update the animal profiles with forward facing description and photo path
*/
DROP PROCEDURE IF EXISTS [sp_update_animal_profile]
GO
PRINT '' PRINT '*** Creating sp_update_animal_profile'
GO
CREATE PROCEDURE [sp_update_animal_profile]
(
	@AnimalID			[int],
	@ProfilePhoto		[nvarchar](50),
	@ProfileDescription	[nvarchar](500)
)
AS
BEGIN
	UPDATE [dbo].[Animal]
		SET [ProfilePhoto] = @ProfilePhoto,
			[ProfileDescription] = @ProfileDescription
	WHERE	[AnimalID] = @AnimalID
	RETURN @@ROWCOUNT
END
GO

/*
Created By: Michael Thompson
Date 2/20/2020
Comment: Stored Procedure to get the animal, profile photo path and description
*/
DROP PROCEDURE IF EXISTS [sp_select_all_animal_profiles]
GO
PRINT '' PRINT '*** Creating sp_select_all_animal_profiles'
GO
CREATE PROCEDURE [sp_select_all_animal_profiles]
AS
BEGIN
	SELECT [AnimalID],[AnimalName],[ProfilePhoto],[ProfileDescription]
	FROM [dbo].[Animal]
	ORDER BY [AnimalID]
END
GO

/*
Created by: Jaeho Kim
Date: 03/05/2020
Comment: Selects a single transaction with an TransactionID and displays all
of the product details.
*/
DROP PROCEDURE IF EXISTS [sp_select_all_products_by_transaction_id]
GO
PRINT '' PRINT '*** Creating sp_select_all_products_by_transaction_id'
GO
CREATE PROCEDURE [sp_select_all_products_by_transaction_id]
(
	@TransactionID		[int]
)
AS
BEGIN
    SELECT
        TL.[Quantity]
        , P.[ProductID]
        , P.[ProductName]
        , P.[ProductCateGOryID]
        , P.[ProductTypeID]
        , P.[Description]
        , P.[Brand]
        , P.[Price]

    FROM 	[TransactionLine] TL
    INNER JOIN [Product] P
        ON TL.[ProductID] = P.[ProductID]
    INNER JOIN [Transaction] T
        ON TL.[TransactionID] = T.[TransactionID]
    INNER JOIN [User] U
        ON T.[EmployeeID] = U.[UserID]
    INNER JOIN [TransactionType] TT
        ON TT.[TransactionTypeID] = T.[TransactionTypeID]
    WHERE @TransactionID = TL.[TransactionID]
END
GO

/*
Created by: Jaeho Kim
Date: 03/05/2020
Comment: Selects a list of all transactions with a specific datetime.
*/
DROP PROCEDURE IF EXISTS [sp_select_transactions_by_datetime]
GO
PRINT '' PRINT '*** Creating sp_select_transactions_by_datetime'
GO
CREATE PROCEDURE sp_select_transactions_by_datetime
(
	@TransactionDate	[datetime]
)
AS
BEGIN
    SELECT
        T.[TransactionID]
        ,T.[TransactionDate]
        ,U.[UserID]
        ,U.[FirstName]
        ,U.[LastName]
        ,T.[TransactionTypeID]
        ,T.[TransactionStatusID]
        ,T.[Notes]
    FROM 	[Transaction] T
    INNER JOIN [User] U
        ON T.[EmployeeID] = U.[UserID]
    WHERE T.[TransactionDate] = @TransactionDate
END
GO

/*
Created by: Brandyn T. Coverdill
Date: 3/4/2020
Comment: Stored Procedure that updates the item name, item count, and item description.
*/
DROP PROCEDURE IF EXISTS [sp_update_specific_item]
GO
PRINT '' PRINT '*** Creating procedure sp_update_specific_item'
GO
CREATE PROCEDURE [sp_update_specific_item](
	@OldItemName nvarchar(50),
	@OldItemDescription nvarchar(250),
	@OldItemQuantity int,
	@NewItemName nvarchar(50),
	@NewItemDescription nvarchar(250),
	@NewItemQuantity int
)
AS
BEGIN
	UPDATE dbo.Item
	SET ItemName = @NewItemName,
		ItemDescription = @NewItemDescription,
		ItemQuantity = @NewItemQuantity
	WHERE ItemName = @OldItemName
	AND	  ItemDescription = @OldItemDescription
	AND	  ItemQuantity = @OldItemQuantity
	SELECT @@ROWCOUNT
END
GO

/*
Created by: Rasha Mohammed
Date: 2/10/2020
Comment: Sproc to delete item from transactionLine
*/
DROP PROCEDURE IF EXISTS [sp_delete_Item_from_Transaction]
GO
PRINT '' PRINT '*** creating sp_delete_item_from_transaction'
GO
CREATE PROCEDURE [sp_delete_Item_from_Transaction]
(
	@ProductID	[nvarchar](13)
)
AS
BEGIN
	DELETE FROM [dbo].[TransactionLine]
	WHERE	[ProductID] = @ProductID
	select @@rowcount
END
GO

/*
Created by: Austin Gee
Date: 3/5/2020
Comment: Stored Procedure that selects all AnimalVMs by active
*/
DROP PROCEDURE IF EXISTS [sp_select_adoption_animals_by_active]
GO
PRINT '' PRINT '*** Creating sp_select_adoption_animals_by_active'
GO
CREATE PROCEDURE [sp_select_adoption_animals_by_active]
(
	@Active [bit]
)
AS
BEGIN
	SELECT
		[Animal].[AnimalID]
		,[AnimalName]
		,[Dob]
		,[AnimalBreed]
		,[ArrivalDate]
		,[CurrentlyHoused]
		,[Adoptable]
		,[Animal].[Active]
		,[AnimalSpeciesID]
		,[AnimalKennelID]
		,[AnimalKennelInfo]
		,[AnimalMedicalInfoID]
		,[SpayedNeutered]
		,[AdoptionApplicationID]
		,[Customer].[Email]
		,[Customer].[FirstName]
		,[Customer].[LastName]
		,[AnimalHandlingNotesID]
		,[AnimalHandlingNotes]
		,[TemperamentWarning]
	FROM [Animal]
	LEFT JOIN [AnimalKennel] ON [Animal].[AnimalID] = [AnimalKennel].[AnimalID]
	LEFT JOIN [AnimalHandlingNotes] ON [Animal].[AnimalID] = [AnimalHandlingNotes].[AnimalID]
	LEFT JOIN [AnimalMedicalInfo] ON [Animal].[AnimalID] = [AnimalMedicalInfo].[AnimalID]
	LEFT JOIN [AdoptionApplication] ON [Animal].[AnimalID] = [AdoptionApplication].[AnimalID]
	LEFT JOIN [Customer] ON [AdoptionApplication].[CustomerEmail] = [Customer].[Email]
	WHERE [Animal].[Active] = @Active
END
GO

/*
Created by: Jordan Lindo
Date: 2/29/2020
Comment: set the active field
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_department_by_id]
GO
PRINT '' PRINT '*** Creating sp_set_department_active_by_id'
GO
CREATE PROCEDURE [sp_deactivate_department_by_id]
(
	 @DepartmentID		[nvarchar](50)
	,@Active			[bit]
)
AS
BEGIN
	UPDATE [dbo].[Department]
	SET [Active] = @Active
	WHERE [DepartmentID] = @DepartmentID
END
GO

/*
Created by: Jordan Lindo
Date: 2/29/2020
Comment: selects departments that are deactivated
*/
DROP PROCEDURE IF EXISTS [sp_select_deactivated_departments]
GO
PRINT '' PRINT '*** Creating sp_select_deactivated_departments'
GO
CREATE PROCEDURE [sp_select_deactivated_departments]
AS
BEGIN
	SELECT [DepartmentID]
	FROM [dbo].[Department]
	WHERE [Active] = 0
END
GO

/*
Created by: Chuck Baxter
Date: 3/12/2020
Comment: Stored Procedure that updates an animal
*/
DROP PROCEDURE IF EXISTS [sp_update_animal]
GO
PRINT '' PRINT '*** Creating sp_update_animal'
Go
CREATE PROCEDURE [sp_update_animal]
(
	@AnimalID				[int],
	@OldAnimalName			[nvarchar](100),
	@OldDob					[DateTime],
	@OldAnimalBreed			[nvarchar](100),
	@OldArrivalDate			[DateTime],
	@OldAnimalSpeciesID		[nvarchar](100),
	@NewAnimalName			[nvarchar](100),
	@NewDob					[DateTime],
	@NewAnimalBreed			[nvarchar](100),
	@NewArrivalDate			[DateTime],
	@NewAnimalSpeciesID		[nvarchar](100)
)
AS
BEGIN
	UPDATE	[dbo].[Animal]
	SET 	[AnimalName] 		= 	@NewAnimalName,
			[Dob]				=	@NewDob,
			[AnimalBreed]		=	@NewAnimalBreed,
			[ArrivalDate]		=	@NewArrivalDate,
			[AnimalSpeciesID]	=	@NewAnimalSpeciesID
	WHERE	[AnimalID]			=	@AnimalID
	  AND	[AnimalName]		=	@OldAnimalName
	  AND	[Dob]				=	@OldDob
	  AND	[AnimalBreed]		=	@OldAnimalBreed
 	  AND	[ArrivalDate]		=	@OldArrivalDate
	  AND	[AnimalSpeciesID]	=	@OldAnimalSpeciesID
	  RETURN @@ROWCOUNT
END
GO

/*
Created by: Dalton Reierson
Date: 03/09/2020
Comment: Select all item in inventory by active field
*/
DROP PROCEDURE IF EXISTS [sp_select_items_by_active]
GO
PRINT '' PRINT '*** Creating sp_select_items_by_active ***'
GO
CREATE PROCEDURE [sp_select_items_by_active]
(
		@Active [bit]
)
AS
BEGIN
	SELECT [ItemID],
		   [ItemName],
		   [ItemQuantity],
		   [ItemCateGOryID],
		   [ItemDescription]
	FROM [dbo].[Item]
	WHERE [Active] = @Active
END
GO

/*
Created by: Dalton Reierson
Date: 03/10/2020
Comment: Select all items in inventory by active field
*/
DROP PROCEDURE IF EXISTS [sp_deactivate_item]
GO
PRINT '' PRINT '*** Creating sp_deactivate_item ***'
GO
CREATE PROCEDURE [sp_deactivate_item]
(
		@ItemID          [int],
		@ItemName        [nvarchar] (50),
		@ItemCateGOryID  [nvarchar] (50),
		@ItemDescription [nvarchar] (50),
		@ItemQuantity    [int]
)
AS
BEGIN
	UPDATE [Item]
	SET    [Active] = 0
	WHERE  [ItemID] = @ItemID
	AND    [ItemName] = @ItemName
	AND	   [ItemCateGOryID] = @ItemCateGOryID
	AND    [ItemDescription] = @ItemDescription
	AND    [ItemQuantity] = @ItemQuantity
	SELECT @@ROWCOUNT
END
GO

/*
Created by: Robert Holmes
Date: 2020/03/10
Comment: Stored procedure to INSERT a new promotion
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_promotion]
GO
PRINT '' PRINT '*** Creating stored procedure sp_INSERT_promotion'
GO
CREATE PROCEDURE [sp_INSERT_promotion]
(
		@PromotionID		NVARCHAR(20)
	,	@PromotionTypeID	NVARCHAR(20)
	,	@StartDate			DATETIME
	,	@EndDate			DATETIME
	,	@Discount			DECIMAL(10, 2)
	,	@Description		NVARCHAR(500)
)
AS
BEGIN
    INSERT INTO [dbo].[Promotion]
    ([PromotionID], [PromotionTypeID], [StartDate], [EndDate], [Discount], [Description])
    VALUES
    (@PromotionID, @PromotionTypeID, @StartDate, @EndDate, @Discount, @Description)
END
GO

/*
Created by: Robert Holmes
Date: 2020/03/10
Comment: Stored procedure to return all PromotionTypes
*/
DROP PROCEDURE IF EXISTS [sp_retrieve_promotiontypes]
GO
PRINT '' PRINT '*** Creating stored procedure sp_retrieve_promotiontypes'
GO
CREATE PROCEDURE [sp_retrieve_promotiontypes]
AS
BEGIN
    SELECT 	[PromotionTypeID]
    FROM 	[dbo].[PromotionType]
END
GO

/*
Created by: Robert Holmes
Date: 2020/03/12
Comment: Relates products to a promotion.
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_promo_product]
GO
PRINT '' PRINT '*** Creating stored procedure sp_INSERT_promo_product'
GO
CREATE PROCEDURE [sp_INSERT_promo_product]
(
		@PromotionID	NVARCHAR(20)
	,	@ProductID		NVARCHAR(13)
)
AS
BEGIN
    INSERT INTO [dbo].[PromoProductLine]
    ([PromotionID], [ProductID])
    VALUES
    (@PromotionID, @ProductID)
END
GO

/*
Created by: Austin Gee
Date: 3/4/2020
Comment: Stored Procedure that selects adoption appointment by appointment id.
*/
DROP PROCEDURE IF EXISTS [sp_select_adoption_appointment_by_appointment_id]
GO
PRINT '' PRINT '*** Creating sp_select_adoption_appointment_by_appointment_id'
GO
CREATE PROCEDURE [sp_select_adoption_appointment_by_appointment_id]
(
	@AppointmentID [int]
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
	,[Animal].[AnimalID]
	,[AdoptionApplication].[Status]
	,[AdoptionApplication].[RecievedDate]
	,[Location].[Name]
	,[Location].[Address1]
	,[Location].[Address2]
	,[Location].[City]
	,[Location].[State]
	,[Location].[Zip]
	,[Customer].[Email]
	,[Customer].[FirstName]
	,[Customer].[LastName]
	,[Customer].[PhoneNumber]
	,[Customer].[Active]
	,[Customer].[City]
	,[Customer].[State]
	,[Customer].[Zipcode]
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
	JOIN [Customer] ON [AdoptionApplication].[CustomerEmail] = [Customer].[Email]
	JOIN [Animal] ON [AdoptionApplication].[AnimalID] = [Animal].[AnimalID]
	WHERE [Appointment].[AppointmentID] = @AppointmentID
	ORDER BY [Appointment].[DateTime] DESC
END
GO

/*
Created by: Austin Gee
Date: 3/11/2020
Comment: Sproc to create a status
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_status]
GO
PRINT '' PRINT '*** creating sp_INSERT_status'
GO
CREATE PROCEDURE [sp_INSERT_status]
(
	@StatusID	[nvarchar](100)
)
AS
BEGIN
	INSERT INTO [dbo].[Status]
		([StatusID])
	VALUES
		(@StatusID)
	RETURN @@ROWCOUNT
END
GO	

/*
Created by: Austin Gee
Date: 3/11/2020
Comment: Sproc to select all statuses
*/
DROP PROCEDURE IF EXISTS [sp_select_all_statuses]
GO
PRINT '' PRINT '*** creating sp_select_all_statuses'
GO
CREATE PROCEDURE [sp_select_all_statuses]
AS
BEGIN
	SELECT
		[StatusID]
	FROM
		[dbo].[Status]
	ORDER BY [StatusID] ASC
END
GO	

/*
Created by: Austin Gee
Date: 3/11/2020
Comment: Sproc to INSERT an Animal status
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_animal_status]
GO
PRINT '' PRINT '*** creating sp_INSERT_animal_status'
GO
CREATE PROCEDURE [sp_INSERT_animal_status]
(
	@StatusID	[nvarchar](100),
	@AnimalID	[int]
)
AS
BEGIN
	INSERT INTO [dbo].[AnimalStatus]
		([AnimalID], [StatusID])
	VALUES
		(@AnimalID, @StatusID)
	RETURN @@ROWCOUNT
END
GO	

/*
Created by: Austin Gee
Date: 3/11/2020
Comment: Sproc to select an animal status by animal ID
*/
DROP PROCEDURE IF EXISTS [sp_select_animal_status_ids_by_animal_id]
GO
PRINT '' PRINT '*** creating sp_select_animal_status_by_animal_id'
GO
CREATE PROCEDURE [sp_select_animal_status_ids_by_animal_id]
(
	@AnimalID	[int]
)
AS
BEGIN
	SELECT [StatusID]
	FROM [dbo].[AnimalStatus]
	WHERE [AnimalID] = @AnimalID
	ORDER BY [StatusID] ASC
END
GO	

/*
Created by: Austin Gee
Date: 3/11/2020
Comment: Sproc to delete an Animal status
*/
DROP PROCEDURE IF EXISTS [sp_delete_animal_status]
GO
PRINT '' PRINT '*** creating sp_delete_animal_status'
GO
CREATE PROCEDURE [sp_delete_animal_status]
(
	@StatusID	[nvarchar](100),
	@AnimalID	[int]
)
AS
BEGIN
	DELETE FROM [dbo].[AnimalStatus]
	WHERE [AnimalID] = @AnimalID
	AND [StatusID] = @StatusID
	RETURN @@ROWCOUNT
END
GO	

/*
Created by: Austin Gee
Date: 3/11/2020
Comment: Sproc to INSERT an appointment
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_appointment]
GO
PRINT '' PRINT '*** creating sp_INSERT_appointment'
GO
CREATE PROCEDURE [sp_INSERT_appointment]
(
	@AdoptionApplicationID	[int],
	@AppointmentTypeID		[nvarchar](100),
	@DateTime				[datetime],
	@LocationID				[int]
)
AS
BEGIN
	INSERT INTO [dbo].[Appointment]
		([AdoptionApplicationID], [AppointmentTypeID], [DateTime], [LocationID])
	VALUES
		(@AdoptionApplicationID, @AppointmentTypeID, @DateTime, @LocationID)
	RETURN @@ROWCOUNT
END
GO	

/*
Created by: Austin Gee
Date: 3/12/2020
Comment: Sproc to INSERT a location
*/
DROP PROCEDURE IF EXISTS [sp_INSERT_location]
GO
PRINT '' PRINT '*** creating sp_INSERT_location'
GO
CREATE PROCEDURE [sp_INSERT_location]
(
	@Name			[nvarchar](100),
	@Address1		[nvarchar](100),
	@Address2		[nvarchar](100),
	@City			[nvarchar](100),
	@State			[nvarchar](2),
	@Zip			[nvarchar](20)
)
AS
BEGIN
	INSERT INTO [dbo].[Location]
		([Name], [Address1], [Address2], [City], [State], [Zip])
	VALUES
		(@Name, @Address1, @Address2, @City, @State, @Zip)
	RETURN @@ROWCOUNT
END
GO	

/*
Created by: Austin Gee
Date: 3/12/2020
Comment: Sproc to select all location
*/
DROP PROCEDURE IF EXISTS [sp_select_all_locations]
GO
PRINT '' PRINT '*** creating sp_select_all_locations'
GO
CREATE PROCEDURE [sp_select_all_locations]
AS
BEGIN
	SELECT
		[LocationID]
		,[Name]
		,[Address1]
		,[Address2]
		,[City]
		,[State]
		,[Zip]
	FROM [dbo].[Location]
	ORDER BY [Name] ASC
END
GO	

/*
Created by: Austin Gee
Date: 3/12/2020
Comment: Sproc to select location by location ID
*/
DROP PROCEDURE IF EXISTS [sp_select_location_by_location_id]
GO
PRINT '' PRINT '*** creating sp_select_location_by_location_id'
GO
CREATE PROCEDURE [sp_select_location_by_location_id]
(
	@LocationID [int]
)
AS
BEGIN
	SELECT
		[LocationID]
		,[Name]
		,[Address1]
		,[Address2]
		,[City]
		,[State]
		,[Zip]
	FROM [dbo].[Location]
	WHERE [LocationID] = @LocationID
END
GO	

/*
Created by: Austin Gee
Date: 3/12/2020
Comment: Sproc to update location
*/
DROP PROCEDURE IF EXISTS [sp_update_location]
GO
PRINT '' PRINT '*** creating sp_update_location'
GO
CREATE PROCEDURE [sp_update_location]
(
	@LocationID			[int],
	
	@OldName			[nvarchar](100),
	@OldAddress1		[nvarchar](100),
	@OldAddress2		[nvarchar](100),
	@OldCity			[nvarchar](100),
	@OldState			[nvarchar](2),
	@OldZip				[nvarchar](20),
	
	@NewName			[nvarchar](100),
	@NewAddress1		[nvarchar](100),
	@NewAddress2		[nvarchar](100),
	@NewCity			[nvarchar](100),
	@NewState			[nvarchar](2),
	@NewZip				[nvarchar](20)
)
AS
BEGIN
	UPDATE [dbo].[Location]
	SET 	[Name]		 = @NewName,
			[Address1]	 = @NewAddress1,
			[Address2]	 = @NewAddress2,
			[City]		 = @NewCity,
			[State]		 = @NewState,
			[Zip]		 = @NewZip
			
	WHERE	[LocationID] = @LocationID	
	AND 	[Name]		 = @OldName
	AND		[Address1]	 = @OldAddress1
	AND		[Address2]	 = @OldAddress2
	AND		[City]		 = @OldCity
	AND		[State]		 = @OldState
	AND		[Zip]		 = @OldZip
	RETURN @@ROWCOUNT
END
GO	

/*
Created by: Austin Gee
Date: 3/12/2020
Comment: Sproc to delete location
*/
DROP PROCEDURE IF EXISTS [sp_delete_location]
GO
PRINT '' PRINT '*** creating sp_delete_location'
GO
CREATE PROCEDURE [sp_delete_location]
(
	@LocationID			[int],
	
	@Name			[nvarchar](100),
	@Address1		[nvarchar](100),
	@Address2		[nvarchar](100),
	@City			[nvarchar](100),
	@State			[nvarchar](2),
	@Zip			[nvarchar](20)
)
AS
BEGIN
	DELETE FROM [dbo].[Location]
	WHERE	[LocationID] = @LocationID
	AND 	[Name]		 = @Name
	AND		[Address1]	 = @Address1
	AND		[Address2]	 = @Address2
	AND		[City]		 = @City
	AND		[State]		 = @State
	AND		[Zip]		 = @Zip
	RETURN @@ROWCOUNT
END
GO

DROP PROCEDURE IF EXISTS [sp_Select_NewAnimalCheckList_By_AnimalID]
GO
PRINT '' PRINT '*** creating sp_Select_NewAnimalCheckList_By_AnimalID'
GO
CREATE PROCEDURE [sp_Select_NewAnimalCheckList_By_AnimalID]
(
  @AnimalID [int]
)
AS
BEGIN
    SELECT 
        Animal.AnimalID,
        Animal.AnimalName,  	
        Animal.Dob,				
        Animal.AnimalSpeciesID,		
        Animal.AnimalBreed,			
        Animal.ArrivalDate,			
        Animal.CurrentlyHoused,		
        Animal.Adoptable,
        AnimalHandlingNotes.AnimalHandlingNotes,	
        AnimalHandlingNotes.TemperamentWarning,
        AnimalMedicalInfo.SpayedNeutered,				
        AnimalMedicalInfo.Vaccinations,				
        AnimalMedicalInfo.MostRecentVaccinationDate,	
        AnimalMedicalInfo.AdditionalNotes	
    FROM [dbo].[Animal] 
    INNER JOIN [dbo].[AnimalHandlingNotes]
    ON AnimalHandlingNotes.AnimalID = Animal.AnimalID
    INNER JOIN 
    AnimalMedicalInfo
    ON
    AnimalMedicalInfo.AnimalID = Animal.AnimalID

    WHERE Animal.AnimalID = @AnimalID
    AND AnimalHandlingNotes.AnimalID = @AnimalID
    AND AnimalMedicalInfo.AnimalID = @AnimalID
END
GO

DROP PROCEDURE IF EXISTS [SP_Select_Medication_By_Low_Qauntity]
GO
PRINT '' PRINT '*** creating SP_Select_Medication_By_Low_Qauntity'
GO
CREATE PROCEDURE [SP_Select_Medication_By_Low_Qauntity]
AS
BEGIN
    SELECT 
        [ItemID],
        [ItemQuantity],				
        [ItemName]			
			
    FROM [dbo].[Item] 
    WHERE[ItemCateGOryID] = 'Medication'
    AND [ItemQuantity] < 5
END
GO

DROP PROCEDURE IF EXISTS [SP_Select_Medication_By_Empty_Qauntity]
GO
PRINT '' PRINT '*** creating SP_Select_Medication_By_Empty_Qauntity'
GO
CREATE PROCEDURE [SP_Select_Medication_By_Empty_Qauntity]
AS
BEGIN
    SELECT 
        [ItemID],
        [ItemQuantity],				
        [ItemName]			                
    FROM [dbo].[Item] 
    WHERE [ItemCateGOryID] = 'Medication'
    AND [ItemQuantity] = 0
END
GO

DROP PROCEDURE IF EXISTS [sp_Select_Animal_Feeding_Records]
GO
PRINT '' PRINT '*** sp_Select_Animal_Feeding_Records'
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
    FROM [dbo].[AnimalActivity]
END
GO

DROP PROCEDURE IF EXISTS [SP_Create_SpecialOrder]
GO
PRINT '' PRINT '*** SP_Create_SpecialOrder'
GO
CREATE PROCEDURE [SP_Create_SpecialOrder]
AS
BEGIN
    SELECT 
        [ItemID],
        [ItemName],
        [ItemQuantity],
        [ItemCateGOryID]
    FROM [Item]
END
GO

DROP PROCEDURE IF EXISTS [sp_Select_Animal_By_AnimalID]
GO
PRINT '' PRINT '*** sp_Select_Animal_By_AnimalID'
GO
CREATE PROCEDURE [sp_Select_Animal_By_AnimalID]
(
  @AnimalID [int]
)
AS
BEGIN
    SELECT 
        [AnimalID],
        [AnimalName],  	
        [Dob],				
        [AnimalSpeciesID],		
        [AnimalBreed],			
        [ArrivalDate],			
        [CurrentlyHoused],		
        [Adoptable]		

    FROM [Animal] 
    WHERE[AnimalID] = @AnimalID
END
GO

DROP PROCEDURE IF EXISTS [SP_Select_Items_By_ItemCateGOryID]
GO
PRINT '' PRINT '*** SP_Select_Items_By_ItemCateGOryID'
GO
CREATE PROCEDURE [SP_Select_Items_By_ItemCateGOryID]
AS
BEGIN
    SELECT 
        [ItemID],
        [ItemQuantity],				
        [ItemName]						
    FROM [dbo].[Item] 
    WHERE[ItemCateGOryID] = 'Medication'
END
GO

DROP PROCEDURE IF EXISTS [sp_Select_AnimalMedicalHistory_By_AnimalID]
GO
PRINT '' PRINT '*** sp_Select_AnimalMedicalHistory_By_AnimalID'
GO
CREATE PROCEDURE [sp_Select_AnimalMedicalHistory_By_AnimalID]
(
  @AnimalID [int]
)
AS
BEGIN
    SELECT 
        Animal.AnimalID,
        Animal.AnimalName, 
        Animal.AnimalSpeciesID,	 			
        AnimalMedicalInfo.Vaccinations,
        AnimalMedicalInfo.SpayedNeutered,	
        AnimalMedicalInfo.MostRecentVaccinationDate,	
        AnimalMedicalInfo.AdditionalNotes	
    FROM
    [Animal] 
    INNER JOIN 
    AnimalHandlingNotes
    ON AnimalHandlingNotes.AnimalID = Animal.AnimalID
    INNER JOIN 
    AnimalMedicalInfo
    ON
    AnimalMedicalInfo.AnimalID = Animal.AnimalID

    WHERE Animal.AnimalID = @AnimalID
    AND 
    AnimalHandlingNotes.AnimalID = @AnimalID
    AND 
    AnimalMedicalInfo.AnimalID = @AnimalID
END
GO

/*
Created by: Zach Behrensmeyer
Date: 03/02/2020
Comment: This is used to check that the email exists
*/
DROP PROCEDURE IF EXISTS [sp_check_email_exists]
GO
print '' print '*** Creating sp_check_email_exists ***'
GO
CREATE PROCEDURE [sp_check_email_exists]
(
@Email [NVARCHAR](250)
)  
AS     
BEGIN     
SELECT COUNT(*) 
FROM [dbo].[User] 
WHERE Email = @Email
END    
GO

/*
Created by: Zach Behrensmeyer
Date: 03/02/2020
Comment: This is used to check that the email exists
*/
DROP PROCEDURE IF EXISTS [sp_get_unlock_date]
GO
print '' print '*** Creating sp_get_unlock_date ***'
GO
CREATE PROCEDURE [sp_get_unlock_date]
(
@Email [NVARCHAR](250)
)  
AS     
BEGIN     
SELECT UnlockDate
FROM [dbo].[User] 
WHERE Email = @Email
END    
GO

/*
Created by: Zach Behrensmeyer
Date: 03/02/2020
Comment: This is used to check that the user is locked
*/
DROP PROCEDURE IF EXISTS [sp_check_user_is_locked]
GO
print '' print '*** Creating sp_check_user_is_locked ***'
GO
CREATE PROCEDURE [sp_check_user_is_locked]
(
@Email [NVARCHAR](250)
)  
AS     
BEGIN     
SELECT COUNT(*) 
FROM [dbo].[User] 
WHERE Email = @Email
AND Locked = 1
END    
GO

/*
Created by: Zach Behrensmeyer
Date: 03/02/2020
Comment: This is used to unlock a user if the date and time they were locked out at is ahead of that time
*/
DROP PROCEDURE IF EXISTS [sp_unlock_user_by_date]
GO
print '' print '*** Creating sp_unlock_user_by_date ***'
GO
CREATE PROCEDURE [sp_unlock_user_by_date]
(
@Email [NVARCHAR](250)
)  
AS     
BEGIN     
UPDATE [dbo].[User]
SET Locked = 0, UnlockDate = null
WHERE Email = @Email 
AND UnlockDate < GETDATE()
RETURN @@ROWCOUNT
END    
GO

/*
Created by: Zach Behrensmeyer
Date: 03/02/2020
Comment: This is used to check that the email exists
*/
DROP PROCEDURE IF EXISTS [sp_lockout_user]
GO
print '' print '*** Creating sp_lockout_user ***'
GO
Create Procedure [sp_lockout_user]
(
@Email [NVARCHAR](250),
@UnlockDate [DateTime],
@LockDate [DateTime]
)  
AS     
BEGIN     
UPDATE [dbo].[User]
	SET Locked = 1, UnlockDate = @UnlockDate, LockDate = @LockDate
	WHERE Email = @Email
	RETURN @@ROWCOUNT
END    
GO

/*
Author: Timothy Lickteig
Date: 2020/03/01
Comment: Stored Procedure for selecting all signed up shifts for a volunteer
*/
DROP PROCEDURE IF EXISTS [sp_select_shifts_for_a_volunteer]
GO
print '' print '*** Creating stored procedure sp_select_shifts_for_a_volunteer'
GO
CREATE PROCEDURE [sp_select_shifts_for_a_volunteer](
	@VolunteerID [int]
)
AS
BEGIN
	SELECT [VolunteerShift].[VolunteerShiftID], [ShiftDescription], 
		[ShiftTitle], [ShiftDate], [ShiftStartTime],
		[ShiftEndTime], [Recurrance], [IsSpecialEvent],
		[ShiftNotes], [ScheduleID]
	FROM [ShiftRecord] 
	JOIN [VolunteerShift] ON 
		([VolunteerShift].[VolunteerShiftID] = [ShiftRecord].[VolunteerShiftID])
	WHERE [ShiftRecord].[VolunteerID] = @VolunteerID
END
GO

/*
Author: Timothy Lickteig
Date: 2020/03/09
Comment: Creating procedure for checking Medicine in
*/
print '' print '*** Creating sp_select_all_medicine'
GO
CREATE PROCEDURE [sp_select_all_medicine]
AS
BEGIN
	select
		[MedicineID], [MedicineName], 
		[MedicineDosage], [MedicineDescription]
	from [dbo].[Medicine]
END
GO

/*
Author: Timothy Lickteig
Date: 2020/03/09
Comment: Creating procedure for checking Medicine in
*/
print '' print '*** Creating sp_insert_medicine'
GO
CREATE PROCEDURE [sp_insert_medicine] (

	@MedicineName [nvarchar](300),
	@MedicineDosage [nvarchar](300),
	@MedicineDescription [nvarchar](500)
)
AS
BEGIN

	insert into [dbo].[Medicine]
	([MedicineName], [MedicineDosage], [MedicineDescription])
	values
	(@MedicineName, @MedicineDosage, @MedicineDescription)
END
GO

/*
Author: Timothy Lickteig
Date: 2020/03/09
Comment: Creating procedure for checking Medicine out
*/
print '' print '*** Creating sp_delete_medicine'
GO
CREATE PROCEDURE [sp_delete_medicine] (

	@MedicineID [int]
)
AS
BEGIN

	delete from [dbo].[Medicine]
	where [MedicineID] = @MedicineID
	return @@ROWCOUNT
END
GO

/*
Created by: Chuck Baxter
Date: 3/13/2020
Comment: Sproc to insert Animal species
*/
print '' print'*** Creating sp_insert_animal_species'
GO

DROP PROCEDURE IF EXISTS [sp_insert_animal_species]
GO

CREATE PROCEDURE [sp_insert_animal_species]
(
	@AnimalSpeciesID	[nvarchar](100),
	@Description		[nvarchar](1000)
)
AS
BEGIN
	INSERT INTO [dbo].[AnimalSpecies]
		([AnimalSpeciesID],[Description])
	VALUES
		(@AnimalSpeciesID, @Description)
	RETURN SCOPE_IDENTITY()
END
GO

/*
Created by: Chuck Baxter
Date: 3/18/2020
Comment: Sproc to delete animal species
*/
DROP PROCEDURE IF EXISTS [sp_delete_animal_species]
GO
PRINT '' PRINT '*** creating sp_delete_animal_species'
GO
CREATE PROCEDURE [sp_delete_animal_species](
		@AnimalSpeciesID [nvarchar](100)
)
AS
BEGIN
	DELETE FROM [dbo].[AnimalSpecies]
	WHERE [AnimalSpeciesID] = @AnimalSpeciesID
	RETURN @@ROWCOUNT
END
GO

/*
Created by: Chuck Baxter
Date: 3/18/2020
Comment: Sproc to update animal species
*/
print '' print'*** Creating sp_update_animal_species'
GO

DROP PROCEDURE IF EXISTS [sp_update_animal_species]
GO

CREATE PROCEDURE [sp_update_animal_species]
(
	@OldAnimalSpeciesID	[nvarchar](100),
	@NewAnimalSpeciesID	[nvarchar](100),
	@NewDescription		[nvarchar](1000)
)
AS
BEGIN
	UPDATE	[dbo].[AnimalSpecies]
	SET 	[AnimalSpeciesID]	= 	@NewAnimalSpeciesID,
			[Description]		=	@NewDescription
	WHERE	[AnimalSpeciesID]	=	@OldAnimalSpeciesID
	RETURN  @@ROWCOUNT
END
GO

/*
 ******************************* Inserting Sample Data *****************************
*/
PRINT '' PRINT '******************* Inserting Sample Data *********************'
GO

/*
Created by: Zach Behrensmeyer
Date: 2/3/2020
Comment: Inserts some test users
*/
PRINT '' PRINT '*** Insert Into User Table ***'
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
Created by: Zach Behrensmeyer
Date: 2/3/2020
Comment: Inserts some test users
*/
PRINT '' PRINT '*** Insert Into User Table ***'
GO
INSERT INTO [dbo].[Customer]
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
('Volunteer', 'Person who does volunteer work')
GO

/*
Created by: Zach Behrensmeyer
Date: 2/6/2020
Comment: This is used to pair a user with their roles
*/
PRINT '' PRINT '*** Insert Into User Role Table ***'
GO
INSERT INTO [dbo].[UserRole]
	([UserID], [RoleID])
VALUES
	(100000, 'Admin'),
	(100002, 'Volunteer')
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

/*
Created by: Chuck Baxter
Date: 2/8/2020
Comment: Sample Animal Data
*/
print '' print '*** Creating sample Animal records'
GO
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

/*
Created by: Ethan Murphy
Date: 2/7/2020
Comment: Inserts sample animal vet appointment records
*/
print '' print '*** creating sample vet appointment records'
GO
INSERT INTO [dbo].[AnimalVetAppointment]
	([AnimalID], [AppointmentDate], [AppointmentDescription],
	[ClinicAddress], [VetName], [FollowUpDate], [UserID])
	VALUES
	(1000000, "2020-02-02 2:00PM", "test", "1234 Test", "test", "2020-02-02 4:00PM", 100000),
	(1000001, "2020-02-10 4:00PM", "test2", "4321 Test2", "test2", null, 100000),
	(1000002, "2020-02-15 1:00PM", "test3", "1234 Test3", "test3", "2020-02-20 1:00PM", 100000)
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
Date: 3/12/2020
Comment: Sample animal kennel records
*/                
print '' print '*** Creating Sample Animal Kennel Records'
GO
INSERT INTO [dbo].[AnimalKennel]
	([AnimalID],				
	[UserID],				
	[AnimalKennelInfo],		
	[AnimalKennelDateIn],	
	[AnimalKennelDateOut]
    )
	VALUES
	(1000000, 100000, 'test test test', '2020-01-22', '2020-02-22'),
    (1000001, 100000, 'test test test 2', '2020-01-22', '2020-02-22')
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
Created by: Awaab Elamin
Date: 3/5/2020
Comment: Adds adoption appliacation records to the AdoptionApplication table.
Note: "Awaab" is only one who filled the questionnair!
Updated by Awaab Elamin
Date: 3/16/2020
Comment: Close sample data that conflict with customer Email
Note: update happend after customerId changed to CUstomerEmail
*/
GO
print '' print '*** Creating Sample AdoptionApplication Records'
GO
INSERT INTO [dbo].[AdoptionApplication]
	([CustomerEmail],[AnimalID],[Status],[RecievedDate])
	VALUES	
	('Awaab@Awaaab.com',(SELECT [AnimalID]FROM[dbo].[Animal]WHERE [Animal].[AnimalName] = 'Paul'),'Reviewer','2020-01-01')
	/*,(100001,1000001,'Reviewing Application','2019-10-9'),
	(100002,1000002,'Waitng for Pickup','2019-10-9'),
	(100003,1000003,'InHomeInspection','2019-10-9')
	*/
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
Created by: Chase Schulte
Date: 02/05/2020
Comment: Inserts test data for the ERole Table
*/
print ''  print '*** Insert eRoles into ERole Table'
GO

Insert INTO [dbo].[ERole]
	([ERoleID],[DepartmentID],[Description])
	Values
	('Cashier','Fake1','Handles customer'),
	('Manager','Fake2','Handles internal operations like employee records and payment info')
Go

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
Comment: Adds AppointmentType Records to the AppointmentType table.
*/
print '' print '*** Creating Sample AppointmentType Records'
GO
INSERT INTO [dbo].[AppointmentType]
	([AppointmentTypeID],[Description])
	VALUES
	('Meet and Greet','This is where the Adoption Customer will meet the animal while the facilitator is present'),
	('inHomeInspection','This is where the Interviewer will interview the Adoption Customer'),
	('Interviewer','This is where the Interviewer will interview the Adoption Customer')
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
	(100002,'Interviewer','2020-2-22 12pm','','',1000000)
GO
/*
Created by: Awaab Elamin
Date: 2/18/2020
Comment: Insert samples data in general questiones table 
*/
GO
print '' print '*** Inserting GeneralQusetions records'
GO
INSERT INTO [dbo].[GeneralQusetions]
(Description)
VALUES
('Question 1'),('Question 2'),('Question 3'),('Question 4'),('Question 5'),('Question 6'),('Question 7')
GO

GO
/*
Created by: Awaab Elamin
Date: 2/18/2020
Comment: Insert samples of CustomerAnswers table .
*/
GO
print '' print '*** Inserting CustomerAnswer records'
GO
INSERT INTO [dbo].[CustomerAnswers]
([QuestionDescription],[Answer],[CustomerEmail],[AdoptionApplicationID])
VALUES
('Question 1','Answer1','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 2','Answer2','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 3','Answer3','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 4','Answer4','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 5','Answer5','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 6','Answer6','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com')),
('Question 7','Answer7','Awaab@Awaaab.com',(SELECT [AdoptionApplicationID]FROM [dbo].[AdoptionApplication]WHERE [dbo].[AdoptionApplication].[CustomerEmail] = 'Awaab@Awaaab.com'))
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
	(1001, '7084781116', 2),
	(1002, '2500006153', 9)
Go

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
Created by: Ryan Morganti
Date: 2020/02/06
Comment: Sample Request Data
*/
print '' print '*** Inserting Sample Request Records'
GO
INSERT INTO [dbo].[request]
	([DateCreated], [RequestTypeID], [RequestingUserID])
	VALUES
	('20200206 11:00:00 AM', 'General',  100000),
	('20200207 12:55:01 PM', 'General',  100000),
	('20200208 01:02:03 PM', 'General',  100000),
	('20200207 12:55:01 PM', 'General',  100000),
	('20200208 01:02:03 PM', 'General',  100000),
	('20200206 03:02:03 PM', 'General',  100000)
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

print '' print '*** Creating Sample Volunteer Records'
/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Sample Active Volunteer records
*/
go

insert into [dbo].[Volunteer]
	([FirstName], [LastName], [Email], [PhoneNumber], [OtherNotes])
	values
	('System', 'Admin', 'admin@petuniverse.com', '00000000000', 'Admin Volunteer'),
	('Ned', 'Flanders', 'diddlydoo@gmail.com', '13192522443', 'Volunteer Notes')
go

/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Sample Deactived Volunteer records
*/
print '' print '*** Creating Sample Deactivated Volunteer'
go
insert into [dbo].[Volunteer]
	([FirstName], [LastName], [Email], [PhoneNumber], [OtherNotes], [Active])
values
	('Homer', 'Simpson', 'doofus@gmail.com', '13194568896', 'Terrible worker', 0)
GO

/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Sample skills and description
*/
print '' print '*** Creating Sample VolunteerSkills Records'
go
insert into [dbo].[VolunteerSkills]
	([SkillID], [SkillDescription])
	values
	('Basic Volunteer', 'Standard Volunteer - no particular proficiency'),
	('Dogwalker', 'Suited to walk dogs'),
	('Groomer', 'Suited to groom animals'),
	('Trainer', 'Suited to train animals'),
	('Transporter', 'Able to transport animals to vet appointments, etc'),
	('Pet Photographer', 'Takes pictures of animals for websites, fliers, etc'),
	('Housing Management', 'Suited for managing animal housing, makes sure bedding is clean, housing has adequete food/water'),
	('Campaigner', 'Suited for promoting marketing campaigns'),
	('Greeter', 'Guide potential adopters throughout the shelter')
go


/*
Created by: Josh Jackson
Date: 2/8/2020
Comment: Sample ties between Volunteers and their skills
*/
print '' print '*** Creating Sample VolunteerSkill Records'
go
insert into [dbo].[VolunteerSkill]
	([VolunteerID], [SkillID])
	values
	(1000001, 'Greeter'),
	(1000001, 'Campaigner')
go

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
Comment: Inserting Sample Data for Request
*/
INSERT INTO [dbo].[request]
	([RequestTypeID], [RequestingUserID], [DateCreated], [Open])
	VALUES
	('Time Off', 100001, '2020-3-1 10:12:21', 1),
	('Time Off', 100000, '2020-2-11 12:33:25', 1),
	('Availability Change', 100001, GETDATE(), 0),
	('Availability Change', 100002, GETDATE(), 1)
GO

/*
Created by: Kaleb Bachert
Date: 2/13/2020
Comment: Inserting Sample Data for Request
*/
INSERT INTO [dbo].[timeOffRequest]
	([EffectiveStart], [EffectiveEnd], RequestID)
	VALUES
	('2020-3-25 12:11:10', '2020-4-10 11:31:15', 1000006),
	('2020-4-6 11:10:9', '2020-4-12 11:13:51', 1000007)
GO

/*
Created by: Robert Holmes
Date: 2020/03/10
Comment: Inserting promotion types 
*/
print '' print '*** Inserting promotion types'
GO
INSERT INTO [dbo].[PromotionType]
	([PromotionTypeID], [Description])
	VALUES
		('Percent', 'Percent discount')
	,	('Flat Amount', 'Dollar amount to discount')
GO

print '' print '*** Creating sample AnimalActivity records'
GO
INSERT INTO [dbo].[AnimalActivity]
	([AnimalID], [UserID], [AnimalActivityTypeID], [ActivityDateTime])
	VALUES
	(1000000, 100000, 'Feeding', '09-08-2016')
	
GO	

INSERT INTO [dbo].[Item]
([ItemQuantity], [ItemName], [ItemCategoryID], [ItemDescription])
	VALUES
	(4,' Medication1', 'Medical', ''),
	(4,' Medication2', 'Medical', '')	
GO

INSERT INTO [dbo].[AnimalMedicalInfo]
([AnimalID], [UserID],[SpayedNeutered], [Vaccinations], [MostRecentVaccinationDate], [AdditionalNotes])
VALUES
	(1000000,100000,1, 'Ebola', '09-08-2016', 'None'),
	(1000001,100000,0, 'None', '10-01-2012', 'None'),
	(1000002,100000,1, 'Corona', '04-15-1998', 'None'),
	(1000003,100000,1, 'Ebola', '09-08-2016', 'None'),
	(1000004,100000,0, 'None', '10-01-2012', 'None'),
	(1000005,100000,1, 'Corona', '04-15-1998', 'None'),
	(1000006,100000,1, 'Corona', '04-15-1998', 'None'),
	(1000007,100000,1, 'Corona', '04-15-1998', 'None'),
	(1000008,100000,1, 'Corona', '04-15-1998', 'None')
	
GO	

/*
Created by: Ben Hanna
Date: 2/18/2020
Comment: Sample animal handling notes record
*/                
print '' print '*** Creating Sample Animal Handling Records'
GO
INSERT INTO [dbo].[AnimalHandlingNotes]
	([AnimalID], [UserID], [AnimalHandlingNotes], [TemperamentWarning], [UpdateDate])
    
	VALUES
	(1000000,100000,'Notes', 'Warning', '2020-01-22'),
	(1000001,100000,'Notes', 'Warning', '2020-01-22'),
	(1000002,100000,'Notes', 'Warning', '2020-01-22'),
	(1000003,100000,'Notes', 'Warning', '2020-01-22'),
	(1000004,100000,'Notes', 'Warning', '2020-01-22'),
	(1000005,100000,'Notes', 'Warning', '2020-01-22'),
	(1000006,100000,'Notes', 'Warning', '2020-01-22'),
	(1000007,100000,'Notes', 'Warning', '2020-01-22'),
	(1000008,100000,'Notes', 'Warning', '2020-01-22') 
GO

/*
Created By: Timothy Lickteig
Date: 3/01/2020
Comment: Sample data for volunteer shift records
*/
print '' print '*** Creating Shift Record records'
go
insert into [dbo].[ShiftRecord]
	(VolunteerID, VolunteerShiftID)
	values
		(1000000, 1000000),
		(1000000, 1000001)
go

/*
Author: Timothy Lickteig
Date: 2020/03/09
Comment: Creating sample data for the medicine table
*/
print '' print '*** Creating Medicine table data'
GO
INSERT INTO [dbo].[Medicine]
([MedicineName], [MedicineDosage], [MedicineDescription])
VALUES
("This is the first one", "This is the first dosage", "This is the first description"),
("This is the second one", "This is the second dosage", "This is the third description")
GO