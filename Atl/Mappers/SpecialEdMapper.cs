using Atl.Domain;
using Atl.DTOs;
using Atl.DTOs.Child;
using Atl.DTOs.SpecialEd;
using System.Runtime.CompilerServices;

namespace Atl.Mappers
{
    public static class SpecialEdMapper
    {
        public static SpecialEdDto ToSpecialEdDto(this SpecialEd specialEdModel)
        {
            return new SpecialEdDto
            {
                Id = specialEdModel.Id,
                Name = specialEdModel.Name,
                
            };
        }
        public static SpecialEd ToSpecialEdFromCreateDto(this CreateSpecialEdDto specialEdDto, int childId)
        {
            return new SpecialEd
            {
                Name = specialEdDto.Name,
                
            };
        }
        public static SpecialEd ToSpecialEdFromUpdateDto(this UpdateSpecialEdRequestDto specialEdDto, int childId)
        {
            return new SpecialEd
            {
                Name = specialEdDto.Name,
                
            };
        }


    }
}
