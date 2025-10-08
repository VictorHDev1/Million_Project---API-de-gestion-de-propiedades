using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;
using static System.Net.WebRequestMethods;

namespace WebAPI.Tests
{
    public class PropertyControllerTests
    {
        private readonly Mock<IPropertyService> _mockService;
        private readonly PropertyController _controller;

        public PropertyControllerTests()
        {
            _mockService = new Mock<IPropertyService>();
            _controller = new PropertyController(_mockService.Object);
        }

        #region Test Create Property post 
        [Fact]
        public async Task Test_Create_Property_Building_WhenPropertyIsValid()
        {
            // declara variable propertyDto, un objeto con datos de prueba.
            var propertyDto = new PropertyDto { IdProperty = 1, Name = "House" };
            _mockService.Setup(s => s.CreateAsync(propertyDto))
                        .ReturnsAsync(propertyDto);

            //Llamado a controlador como cliente enviando metodo POST
            var result = await _controller.Create(propertyDto);

            // Verifica que la respuesta del controlador fue una creación exitosa (HTTP 201)
            var createdResult = Xunit.Assert.IsType<CreatedAtActionResult>(result);
            Xunit.Assert.Equal(propertyDto, createdResult.Value);
        }

        [Fact] 
        public async Task Test_Create_Property_Building_WhenPropertyIsNull()
        {
            // Caso de uso representa un escenario cuando el objeto propertyDto es null
            var result = await _controller.Create(null);

            //Verificacion que el resultado devuelto por el método Create es de tipo BadRequestObjectResult
            // lo que corresponde al código HTTP 400 – Bad Request.
            Xunit.Assert.IsType<BadRequestObjectResult>(result);
        }
        #endregion

        #region Add_Image_From_Property
        [Fact]
        public async Task Test_Add_Image_From_Property_WhenImageIsValid()
        {
             // declara variable propertyDto, un objeto con datos de prueba.
            var imageDto = new PropertyImageDto { IdPropertyImage = 1, File = "image.jpg" };
            _mockService.Setup(s => s.AddImageAsync(1, imageDto))
                        .ReturnsAsync(imageDto);

            //Llamado a controlador como cliente enviando metodo POST
            var result = await _controller.AddImage(1, imageDto);

            // Verifica que la respuesta del controlador fue una creación exitosa (HTTP 201)
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            Xunit.Assert.Equal(imageDto, okResult.Value);
        }

        [Fact]
        public async Task Test_Add_Image_From_Property_WhenImageIsNull()
        {

            // Caso de uso representa un escenario cuando el objeto es null
            var result = await _controller.AddImage(1, null);

            //Verificacion que el resultado devuelto por el método Create es de tipo BadRequestObjectResult
            // lo que corresponde al código HTTP 400 – Bad Request.
            Xunit.Assert.IsType<BadRequestResult>(result);
        }
        #endregion

        #region Change_Price
        [Fact]
        public async Task Test_Change_Price_WhenPropertyExists()
        {
            // cuando se llame al método ChangePriceAsync con los parámetros (1, 200000), devuelve true
            _mockService.Setup(s => s.ChangePriceAsync(1, 200000)).ReturnsAsync(true);

            // Aquí se llama al método  del controlador
            var result = await _controller.ChangePrice(1, 200000);

            // verifica que el resultado sea de tipo OkObjectResult,
            //es decir, que la API respondió con un código HTTP 200 OK.
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            Xunit.Assert.Contains("Price updated successfully", okResult.Value.ToString());
        }

        [Fact]
        public async Task Test_Change_Price_WhenPropertyDoesNotExist()
        {
            // Simula que el servicio no pudo cambiar el precio, porque la propiedad con ID 1 
            _mockService.Setup(s => s.ChangePriceAsync(1, 200000)).ReturnsAsync(false);

            // Llamado  al método del controlador:
            var result = await _controller.ChangePrice(1, 200000);

            // VAlidcion  que la respuesta del método sea del tipo NotFoundObjectResult,
            //lo cual representa un HTTP 404 Not Found en ASP.NET Core
            Xunit.Assert.IsType<NotFoundObjectResult>(result);
        }
        #endregion

        #region Update_Property
        [Fact]
        public async Task Test_Update_Property_WhenPropertyIsValid()
        {
             // declara variable propertyDto, un objeto con datos de prueba.
            var dto = new PropertyDto { IdProperty = 1, Name = "House Updated" };
            _mockService.Setup(s => s.UpdateAsync(dto)).ReturnsAsync(dto);

            //Llamado a controlador como cliente enviando metodo POST
            var result = await _controller.Update(dto);

            // Verifica que la respuesta del controlador fue una creación exitosa (HTTP 201)
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            Xunit.Assert.Equal(dto, okResult.Value);
        }

        [Fact]
        public async Task Test_Update_Property_WhenPropertyIsNull()
        {
            
            var result = await _controller.Update(null);

            
            Xunit.Assert.IsType<BadRequestResult>(result);
        }
        #endregion

        #region List_Property_With_filters
        [Fact]
        public async Task Test_List_Property_With_filters_WithProperties()
        {
            // Probar el endpoint List_Property_With_filters cuando sí existen propiedades
            var list = new List<PropertyDto>
            {
                new PropertyDto { IdProperty = 1, Name = "House 1" },
                new PropertyDto { IdProperty = 2, Name = "House 2" }
            };
            _mockService.Setup(s => s.ListAsync(null, null, null)).ReturnsAsync(list);

            // Llamso al método del controlador:
            var result = await _controller.GetAll(null, null, null);

            // El valor (okResult.Value) es exactamente la lista esperada (list).HTTP 200 OK.
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            Xunit.Assert.Equal(list, okResult.Value);
        }
        #endregion

        #region GetById Obtener una propiedad por ID
        [Fact]
        public async Task Test_List_Property_With__WhenPropertyExists()
        {
            //Debería devolver un Ok cuando la propiedad existe
            var list = new List<PropertyDto>
            {
                new PropertyDto { IdProperty = 1, Name = "House 1" }
            };

            _mockService.Setup(s => s.ListAsync(
                 It.IsAny<string>(),     // name
                 It.IsAny<decimal?>(),  // minPrice
                 It.IsAny<decimal?>()   // maxPrice
             )).ReturnsAsync(new List<PropertyDto>
             {
                new PropertyDto { IdProperty = 1, Name = "Casa 1", Price = 100000 },
                new PropertyDto { IdProperty = 2, Name = "Casa 2", Price = 200000 }
             });
                        
            var result = await _controller.GetById(1);

            
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            Xunit.Assert.Equal(list[0], okResult.Value);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenPropertyDoesNotExist()
        {
            
            _mockService.Setup(s => s.ListAsync(
                 It.IsAny<string>(),     // name
                 It.IsAny<decimal?>(),  // minPrice
                 It.IsAny<decimal?>()   // maxPrice
             )).ReturnsAsync(new List<PropertyDto>
             {
                new PropertyDto { IdProperty = 1, Name = "Casa 1", Price = 100000 },
                new PropertyDto { IdProperty = 2, Name = "Casa 2", Price = 200000 }
            });

            
            var result = await _controller.GetById(1);

            
            Xunit.Assert.IsType<NotFoundResult>(result);
        }
        #endregion
    }
}
