# Million_Project Prueba Técnica .NET 8

Este proyecto fue desarrollado como parte de una prueba técnica para la empresa **Million Luxury**, utilizando una arquitectura por capas y aplicando buenas prácticas de desarrollo con **.NET 8**, **Entity Framework Core**, y **JWT Authentication**.


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

CreateTables.sql

Triggers.sql

SeedData.sql

Actualiza la cadena de conexión en:

WebAPI/appsettings.json


Ejemplo:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MillionDB;Trusted_Connection=True;TrustServerCertificate=True;"
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
POS  /api/Aut/Login  Genera el token para autenticarse 
POST /api/property/Create_Property_Building	Crea una nueva propiedad
PUT	/api/property/{id}/Change_Price?newPrice=200000	Cambia el precio de una propiedad
GET	/api/property/List_Property_With_filters	Lista propiedades con filtros
GET	/api/property/{id}	Obtiene una propiedad por ID
PUT	/api/property/Update_Property	Actualiza la información de una propiedad

Nombre: Victor Leaño
Correo: victor.hl.ardila@gmail.com
GitHub: https://github.com/VictorHDev1

