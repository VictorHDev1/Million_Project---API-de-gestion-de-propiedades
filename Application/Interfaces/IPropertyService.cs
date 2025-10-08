using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyDto> CreateAsync(PropertyDto dto);
        Task<PropertyImageDto> AddImageAsync(int propertyId, PropertyImageDto imageDto); // int
        Task<bool> ChangePriceAsync(int propertyId, decimal newPrice); // int
        Task<PropertyDto> UpdateAsync(PropertyDto dto);
        Task<IEnumerable<PropertyDto>> ListAsync(string? name = null, decimal? minPrice = null, decimal? maxPrice = null);
        Task<PropertyDto?> GetByIdAsync(int id); // 

    }
}
