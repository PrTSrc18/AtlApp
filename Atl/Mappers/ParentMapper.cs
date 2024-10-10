using Atl.Domain;
using Atl.DTOs;
using Atl.DTOs.Parent;

namespace Atl.Mappers
{
    public static class ParentMapper
    {
        public static ParentDto ToParentDto(this Parent parentModel)
        {
            return new ParentDto
            {
                Id = parentModel.Id,
                NameMother = parentModel.NameMother,
                PhoneNumberMother = parentModel.PhoneNumberMother,
                AddressMother = parentModel.AddressMother,
                PostalCodeMother = parentModel.PostalCodeMother,
                JobMother = parentModel.JobMother,
                WorkPlaceMother = parentModel.WorkPlaceMother,
                NameFather = parentModel.NameFather,
                PhoneNumberFather = parentModel.PhoneNumberFather,
                AddressFather = parentModel.AddressFather,
                PostalCodeFather = parentModel.PostalCodeFather,
                JobFather = parentModel.JobFather,
                WorkPlaceFather = parentModel.WorkPlaceFather,
                
                
            };
        }
        public static Parent ToParentFromCreateDto(this CreateParentDto parentDto, int childId)
        {
            return new Parent
            {
                NameMother = parentDto.NameMother,
                PhoneNumberMother = parentDto.PhoneNumberMother,
                AddressMother = parentDto.AddressMother,
                PostalCodeMother = parentDto.PostalCodeMother,
                JobMother = parentDto.JobMother,
                WorkPlaceMother = parentDto.WorkPlaceMother,
                NameFather = parentDto.NameFather,
                PhoneNumberFather = parentDto.PhoneNumberFather,
                AddressFather = parentDto.AddressFather,
                PostalCodeFather = parentDto.PostalCodeFather,
                JobFather = parentDto.JobFather,
                WorkPlaceFather = parentDto.WorkPlaceFather,
                
            };
        }
        public static Parent ToParentFromUpdateDto(this UpdateParentRequestDto parentDto, int childId)
        {
            return new Parent
            {
                NameMother = parentDto.NameMother,
                PhoneNumberMother = parentDto.PhoneNumberMother,
                AddressMother = parentDto.AddressMother,
                PostalCodeMother = parentDto.PostalCodeMother,
                JobMother = parentDto.JobMother,
                WorkPlaceMother = parentDto.WorkPlaceMother,
                NameFather = parentDto.NameFather,
                PhoneNumberFather = parentDto.PhoneNumberFather,
                AddressFather = parentDto.AddressFather,
                PostalCodeFather = parentDto.PostalCodeFather,
                JobFather = parentDto.JobFather,
                WorkPlaceFather = parentDto.WorkPlaceFather,
                
            };
        }
    }
}
