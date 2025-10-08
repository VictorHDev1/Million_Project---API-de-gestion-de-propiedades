USE [PortafolioST]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Description:	TRIGGER UPDATE Tabla dbo.Owner 
-- =============================================
Create TRIGGER [dbo].[Tr_Owner_UPDATE]
   ON  [dbo].[Owner]
  FOR  UPDATE 
	NOT FOR REPLICATION 
AS 
BEGIN
	SET NOCOUNT ON;
	
	BEGIN TRY
		DECLARE @program_name varchar(255)
		SELECT @program_name = program_name FROM MASTER..sysprocesses
		WHERE spid = @@spid 	
		
			
	    INSERT INTO dbo.Owner_Audit
           (	IdOwner ,
				[Name] ,
				[Address] ,
				Photo ,
				Birthday ,
				UserName ,
				ITAudMachine ,
				ITAudApp ,		
				ActionDate ,
				ActionType 
				)
        SELECT 
				IdOwner ,
				[Name] ,
				[Address] ,
				Photo ,
				Birthday,
				SUSER_NAME(),
				HOST_NAME(),
				@program_name,
				GETDATE(),
				'UPD'           
        FROM inserted
		
	END TRY 
	BEGIN CATCH 

	  RAISERROR('[dbo].[Tr_Owner_UPDATE]', 16, 1 ) WITH LOG
	
	END CATCH

    

END