using Atl.Domain;
using Atl.DTOs;
using Atl.DTOs.Child;
using Atl.DTOs.HealthProblem;
using System.Runtime.CompilerServices;

namespace Atl.Mappers
{
    public static class HealthProblemMapper
    {
        public static HealthProblemDto ToHealthProblemDto(this HealthProblem healthProblemModel)
        {
            return new HealthProblemDto
            {
                Id = healthProblemModel.Id,
                Name = healthProblemModel.Name,
                
            };
        }
        public static HealthProblem ToHealthProblemFromCreateDto(this CreateHealthProblemDto healthProblemDto, int childId)
        {
            return new HealthProblem
            {
                Name = healthProblemDto.Name,
                
            };
        }
        public static HealthProblem ToHealthProblemFromUpdateDto(this UpdateHealthProblemRequestDto healthProblemDto, int childId)
        {
            return new HealthProblem
            {
                Name = healthProblemDto.Name,
                
            };
        }


    }
}
