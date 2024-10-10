using Atl.Domain;
using Atl.DTOs;
using Atl.DTOs.Allergy;
using Atl.DTOs.Child;
using System.Runtime.CompilerServices;

namespace Atl.Mappers
{
    public static class AllergyMapper
    {
        public static AllergyDto ToAllergyDto(this Allergy alergyModel)
        {
            return new AllergyDto
            {
                Id = alergyModel.Id,
                Name = alergyModel.Name,
                
            };
        }
        public static Allergy ToAllergyFromCreateDto(this CreateAllergyDto alergyDto, int childId)
        {
            return new Allergy
            {               
                Name = alergyDto.Name,
                
            };
        }
        public static Allergy ToAllergyFromUpdateDto(this UpdateAllergyRequestDto alergyDto, int childId)
        {
            return new Allergy
            {
                Name = alergyDto.Name,
                
            };
        }


    }
}
