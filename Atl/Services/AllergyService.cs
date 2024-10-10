using Atl.DTOs.Allergy;
using Atl.DTOs;
using Atl.Infrastructure;
using Atl.Mappers;
using Atl.Services;

namespace Atl.Services
{
    public class AllergyService : IAllergyService
    {
        private readonly IAllergyRepository _allergyRepo;
        private readonly IChildRepository _childRepo;

        public AllergyService(IAllergyRepository allergyRepo, IChildRepository childRepo)
        {
            _allergyRepo = allergyRepo;
            _childRepo = childRepo;
        }

        public async Task<IEnumerable<AllergyDto>> GetAllAsync()
        {
            var allergies = await _allergyRepo.GetAllAsync();
            return allergies.Select(s => s.ToAllergyDto());
        }

        public async Task<AllergyDto> GetByIdAsync(int id)
        {
            var alergy = await _allergyRepo.GetByIdAsync(id);
            return alergy?.ToAllergyDto();
        }

        public async Task<AllergyDto> CreateAsync(int childId, CreateAllergyDto alergyDto)
        {
            if (!await _childRepo.ChildExists(childId))
                throw new ArgumentException("Child does not exist");

            var alergyModel = alergyDto.ToAllergyFromCreateDto(childId);
            await _allergyRepo.CreateAsync(alergyModel);
            return alergyModel.ToAllergyDto();
        }

        public async Task<AllergyDto> UpdateAsync(int id, UpdateAllergyRequestDto updateDto)
        {
            var alergy = await _allergyRepo.UpdateAsync(id, updateDto.ToAllergyFromUpdateDto(id));
            return alergy?.ToAllergyDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var alergyModel = await _allergyRepo.DeleteAsync(id);
            return alergyModel != null;
        }
    }
}
