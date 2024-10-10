using Atl.Domain;
using Atl.DTOs;
using Atl.DTOs.Child;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Atl.Mappers
{
    public static class ChildMappers
    {
        public static ChildDto ToChildDto(this Child childModel)
        {
            return new ChildDto
            {
                
                Id = childModel.Id,
                Modality = childModel.Modality,
                MemberNumber = childModel.MemberNumber,
                FirstName = childModel.FirstName,
                LastName = childModel.LastName,
                Address = childModel.Address,
                Locality = childModel.Locality,
                PostalCode = childModel.PostalCode,
                DateOfBirth = childModel.DateOfBirth,
                NIF = childModel.NIF,
                NUS = childModel.NUS,
                SchoolYear = childModel.SchoolYear,
                Class = childModel.Class,
                Apolice = childModel.Class
                
            };
        }

        public static Child ToChildFromCreateDto(this CreateChildDto childDto)
        {
            return new Child
            {             
                Modality = childDto.Modality,
                MemberNumber = childDto.MemberNumber,
                FirstName = childDto.FirstName,
                LastName = childDto.LastName,
                Address = childDto.Address,
                Locality = childDto.Locality,
                PostalCode = childDto.PostalCode,
                DateOfBirth = childDto.DateOfBirth,
                NIF = childDto.NIF,
                NUS = childDto.NUS,
                SchoolYear = childDto.SchoolYear,
                Class = childDto.Class,
                Apolice = childDto.Class,
            };
        }
    }
}
