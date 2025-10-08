using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IRepository<Property> _propertyRepo;
        private readonly IRepository<PropertyImage> _imageRepo;

        public PropertyService(IRepository<Property> propertyRepo, IRepository<PropertyImage> imageRepo)
        {
            _propertyRepo = propertyRepo;
            _imageRepo = imageRepo;
        }

        // Crear una nueva propiedad
        public async Task<PropertyDto> CreateAsync(PropertyDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var property = new Property
            {
                Name = dto.Name,
                Address = dto.Address,
                Price = dto.Price,
                CodeInternal = dto.CodeInternal,
                Year = dto.Year,
                IdOwner = dto.IdOwner
            };

            await _propertyRepo.AddAsync(property);
            await _propertyRepo.SaveChangesAsync();

            dto.IdProperty = property.IdProperty;
            return dto;
        }

        // Agregar una imagen a una propiedad existente
        public async Task<PropertyImageDto> AddImageAsync(int propertyId, PropertyImageDto imageDto)
        {
            if (imageDto == null)
                throw new ArgumentNullException(nameof(imageDto));

            var property = await _propertyRepo.GetByIdAsync(propertyId);
            if (property == null)
                throw new Exception($"Property with ID {propertyId} not found");

            var image = new PropertyImage
            {
                IdPropertyImage = imageDto.IdPropertyImage,
                IdProperty = propertyId,
                File = imageDto.File,
                Enabled = imageDto.Enabled
            };

            await _imageRepo.AddAsync(image);
            await _imageRepo.SaveChangesAsync();

            imageDto.IdPropertyImage = image.IdPropertyImage;
            return imageDto;
        }

        // Cambiar el precio de una propiedad
        public async Task<bool> ChangePriceAsync(int propertyId, decimal newPrice)
        {
            var property = await _propertyRepo.GetByIdAsync(propertyId);
            if (property == null)
                return false;

            property.Price = newPrice;

            await _propertyRepo.UpdateAsync(property);
            await _propertyRepo.SaveChangesAsync();
            return true;
        }

        // Actualizar información general de la propiedad
        public async Task<PropertyDto> UpdateAsync(PropertyDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var property = await _propertyRepo.GetByIdAsync(dto.IdProperty);
            if (property == null)
                throw new Exception("Property not found");

            property.Name = dto.Name;
            property.Address = dto.Address;
            property.CodeInternal = dto.CodeInternal;
            property.Year = dto.Year;
            property.Price = dto.Price;
            property.IdOwner = dto.IdOwner;

            await _propertyRepo.UpdateAsync(property);
            await _propertyRepo.SaveChangesAsync();

            return dto;
        }

        // Listar propiedades con filtros (nombre o rango de precio)
        public async Task<IEnumerable<PropertyDto>> ListAsync(string? name = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var properties = await _propertyRepo.GetAllAsync();

            var filtered = properties.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                filtered = filtered.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            if (minPrice.HasValue)
                filtered = filtered.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                filtered = filtered.Where(p => p.Price <= maxPrice.Value);

            return filtered.Select(p => new PropertyDto
            {
                IdProperty = p.IdProperty,
                Name = p.Name,
                Address = p.Address,
                Price = p.Price,
                CodeInternal = p.CodeInternal,
                Year = p.Year,
                IdOwner = p.IdOwner
            }).ToList();
        }

        public async Task<PropertyDto?> GetByIdAsync(int id)
        {
            var property = await _propertyRepo.GetByIdAsync(id);
            if (property == null)
                return null;

            return new PropertyDto
            {
                IdProperty = property.IdProperty,
                Name = property.Name,
                Address = property.Address,
                Price = property.Price,
                CodeInternal = property.CodeInternal,
                Year = property.Year,
                IdOwner = property.IdOwner
            };
        }
    }
}