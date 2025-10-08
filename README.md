# Million_Project Prueba Técnica .NET 8

Este proyecto fue desarrollado como parte de una prueba técnica, utilizando una arquitectura por capas y aplicando buenas prácticas de desarrollo con **.NET 8**, **Entity Framework Core**, y **JWT Authentication**.


## Arquitectura del Proyecto

El proyecto está dividido en las siguientes capas:

<img width="382" height="538" alt="image" src="https://github.com/user-attachments/assets/a9056651-ead1-4beb-bf83-2f4988f77469" />

Tecnologías Utilizadas

- **.NET 8 Web API**
- **Entity Framework Core**
- **SQL Server**
- **JWT Authentication**
- **xUnit** + **Moq** (para pruebas unitarias)
- **Swagger** (para documentación de endpoints)
- **C# 12**
- **Dependency Injection**
- **Asynchronous Programming (async/await)**


# Ejecución del Proyecto

### 1. Clonar el repositorio

```bash
git clone https://github.com/VictorHDev1/Million_Project---API-de-gestion-de-propiedades

2. Configurar la base de datos

En SQL Server, ejecutar los scripts que están en la carpeta:

/Database/Scripts

en el siguiente orden:

Restarurar BackUp base de datos

Temp_Developer.bak

Se relacionan scripts que ys estan en el bakcup por si se crean en otra base de datos 


Create_Table.sql
Create_Index.sql
Stored_Procedure_[dbo].[Lis_Property].sql
Stored_procedure_[dbo].[Update_Property].sql
Stored_Procedure_INS_Property.sql

Actualiza la cadena de conexión en:

La conexion se realiza con usuario SQL "PropertyID" que tiene los permisos, no se asigna admin por seguridad  

db_datereadeer
db_datawriter
Ejecutar_SP

WebAPI/appsettings.json

Ejemplo:

"ConnectionStrings": {
  "DefaultConnection": "Server=MyServer;Database=Temp_Developer;User Id=PropertyID;Password=4f1L14xi0n3$1;TrustServerCertificate=True;MultipleActiveResultSets=True;"
}

 3. Ejecutar la API

Desde Visual Studio:

Selecciona el proyecto de inicio: WebAPI

Presiona Ctrl + F5 para ejecutar sin depurar

Swagger se abrirá automáticamente en el navegador:

https://localhost:5001/swagger


Pruebas Unitarias

Las pruebas unitarias se encuentran en el proyecto Tests y fueron desarrolladas con xUnit y Moq.

Para ejecutarlas desde Visual Studio:

Abre el panel Test Explorer

Haz clic en Run All Tests

Cada prueba valida el comportamiento de los controladores principales:

Create_Property_Building

Change_Price

List_Property_With_filters

GetById

Update_Property

Ejemplo de Endpoints - Desarrollados
Método	Endpoint	Descripción
POS  /api/Aut/Login  Genera el token para autenticarse  user "Admin" Password "1234"
POST /api/property/Create_Property_Building	Crea una nueva propiedad
Ejemplo Json
        {
     
      "name": "Miami_Beach",
      "address": "5 av ",
      "price": 256000,
      "codeInternal": "PRO0012",
      "year": 2025,
      "idOwner": 1
    }
POST /api/property/Add_Image_From_Property	Crea una nueva imagen para la  propiedad
    {
    
      "file": "https://example.com/images/property3-main.jpg",
      "enabled": true
    }
PUT	/api/property/{id}/Change_Price?newPrice=200000	Cambia el precio de una propiedad
GET	/api/property/List_Property_With_filters	Lista propiedades con filtros
GET	/api/property/{id}	Obtiene una propiedad por ID
PUT	/api/property/Update_Property	Actualiza la información de una propiedad
Example Json 
  {
    "idProperty": 3,
    "name": "UpdateProperti",
    "address": "calle 17 - 15 20",
    "price": 650000,
    "codeInternal": "pro0002",
    "year": 1990,
    "idOwner": 2
  
  }


Nombre: Victor Leaño
Correo: victor.hl.ardila@gmail.com
GitHub: https://github.com/VictorHDev1

