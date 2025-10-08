USE Temp_Developer
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************************************************* 
	NOMBRE          :   Update  Property 
	FUNCION         : 	Update informacion en la tabla Property
	APLICACION      :   ApiMillion
	REALIZADO       :   Victor Leaño 	
	VERSION         :   1.0.0  
**************************************************************************************
Caso de uso : Exec [dbo].[Update_Property] 4,'Hose Atlanta','AV 14 # 15-20',352000,'PRO0013',2025,1
**************************************************************************************/
Create PROCEDURE [dbo].[Update_Property]
@IdProperty int,
@Name NVARCHAR(100) ,
@Address NVARCHAR(200),
@Price DECIMAL(18,2) ,
@CodeInternal NVARCHAR(50) ,
@Year INT,
@IdOwner INT 
AS BEGIN
	SET NOCOUNT ON;

	Update dbo.Property
	Set 	Name = @Name ,
			Address = @Address ,
			Price = @Price, 
			CodeInternal = @CodeInternal ,
			Year = @Year ,
			IdOwner = @IdOwner 
	Where  IdProperty = @IdProperty
			   		

END


