USE [PortafolioST]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Description:	TRIGGER UPDATE Tabla dbo.PropertyImage
-- =============================================
Create TRIGGER [dbo].[Tr_PropertyImage_UPDATE]
   ON  [dbo].[PropertyImage]
  FOR  UPDATE  
	NOT FOR REPLICATION 
AS 
BEGIN
	SET NOCOUNT ON;
	
	BEGIN TRY
		DECLARE @program_name varchar(255)
		SELECT @program_name = program_name FROM MASTER..sysprocesses
		WHERE spid = @@spid 	
		
			
	    INSERT INTO dbo.PropertyImage_Audit
           (	IdPropertyImage ,
				IdProperty ,
				[File] ,
				Enabled ,  
				UserName ,
				ITAudMachine ,
				ITAudApp  ,		
				ActionDate ,
				ActionType 
				)
        SELECT 
				IdPropertyImage ,
				IdProperty ,
				[File] ,
				Enabled ,  				
				SUSER_NAME(),
				HOST_NAME(),
				@program_name,
				GETDATE(),
				'UPDATE'           
        FROM inserted
		
	END TRY 
	BEGIN CATCH 

	  RAISERROR('[dbo].[Tr_PropertyImage_UPDATE]', 16, 1 ) WITH LOG
	
	END CATCH

    

END