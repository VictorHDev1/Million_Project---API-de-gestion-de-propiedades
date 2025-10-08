using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   // [Authorize]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        // Inyección de dependencias del servicio
        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        // ============================================================
        // Crear una nueva propiedad
        // POST: api/property
        // ============================================================
        [HttpPost("Create_Property_Building")]
        public async Task<IActionResult> Create([FromBody] PropertyDto propertyDto)
        {
            if (propertyDto == null)
                return BadRequest("Invalid property data.");
            try
            {
                var result = await _propertyService.CreateAsync(propertyDto);
                return CreatedAtAction(nameof(GetById), new { id = result.IdProperty }, result);
            }
            catch (Exception ex )
            {

                return StatusCode(500, $"Internal error Create_Property_Building: {ex.Message} - {ex.StackTrace}");
            }
            
        }

        // ============================================================
        // Agregar imagen a una propiedad
        // POST: api/property/{propertyId}/image
        // ============================================================        
        [HttpPost("Add_Image_From_Property")]
        public async Task<IActionResult> AddImage(int propertyId, [FromBody] PropertyImageDto imageDto)
        {
            if (imageDto == null)
                return BadRequest();
            try
            {
                var result = await _propertyService.AddImageAsync(propertyId, imageDto);
                return Ok(result);
            }
            catch (Exception ex )
            {

                return StatusCode(500, $"Internal error Add_Image_From_Property: {ex.Message} - {ex.StackTrace}");
            }
            
        }

        // ============================================================
        // Cambiar precio de una propiedad
        // PUT: api/property/{id}/price?newPrice=200000
        // ============================================================
        [HttpPut("{id:int}/Change_Price")]        
        public async Task<IActionResult> ChangePrice(int id, [FromQuery] decimal newPrice)
        {
            try
            {
                var success = await _propertyService.ChangePriceAsync(id, newPrice);
                if (!success)
                    return NotFound($"Property with ID {id} not found.");

                return Ok($"Price updated successfully for property {id}");
            }
            catch (Exception ex )
            {

                return StatusCode(500, $"Internal error Change_Price: {ex.Message} - {ex.StackTrace}");
            }
            
        }
        // ============================================================
        // Actualizar información de la propiedad
        // PUT: api/property
        // ============================================================
        [HttpPut("Update_Property")]
        public async Task<IActionResult> Update([FromBody] PropertyDto dto)
        {
            if (dto == null)
                return BadRequest();
            try
            {
                var result = await _propertyService.UpdateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal error Update_Property: {ex.Message} - {ex.StackTrace}");
            }
            
        }


        // ============================================================
        // Listar propiedades (con filtros opcionales)
        // GET: api/property?name=House&minPrice=100000&maxPrice=500000
        // ============================================================
        [HttpGet("List_Property_With_filters")]
        public async Task<IActionResult> GetAll([FromQuery] string? name, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            try
            {
                var result = await _propertyService.ListAsync(name, minPrice, maxPrice);
                return Ok(result);
            }
            catch (Exception ex )
            {

                return StatusCode(500, $"Internal error List_Property_With_filters: {ex.Message} - {ex.StackTrace}");
            }
            
        }



        // ============================================================
        // Obtener una propiedad por ID
        // GET: api/property/{id}
        // ============================================================
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var properties = await _propertyService.ListAsync();
            var property = properties.FirstOrDefault(p => p.IdProperty == id);

            if (property == null)
                return NotFound();

            return Ok(property);
        }

    
    

      
    }
}
