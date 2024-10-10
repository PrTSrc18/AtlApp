using Atl.DTOs;
using Atl.DTOs.SpecialEd;
using Atl.Infrastructure;
using Atl.Mappers;

namespace Atl.Services
{
    public class SpecialEdService : ISpecialEdService
    {
        private readonly ISpecialEdRepository _specialEdRepo;
        private readonly IChildRepository _childRepo;

        public SpecialEdService(ISpecialEdRepository specialEdRepo, IChildRepository childRepo)
        {
            _specialEdRepo = specialEdRepo;
            _childRepo = childRepo;
        }

        public async Task<IEnumerable<SpecialEdDto>> GetAllAsync()
        {
            var specialEds = await _specialEdRepo.GetAllAsync();
            return specialEds.Select(s => s.ToSpecialEdDto());
        }

        public async Task<SpecialEdDto> GetByIdAsync(int id)
        {
            var specialEd = await _specialEdRepo.GetByIdAsync(id);
            return specialEd?.ToSpecialEdDto();
        }

        public async Task<SpecialEdDto> CreateAsync(int childId, CreateSpecialEdDto specialEdDto)
        {
            if (!await _childRepo.ChildExists(childId))
                throw new ArgumentException("Child does not exist");

            var specialEdModel = specialEdDto.ToSpecialEdFromCreateDto(childId);
            await _specialEdRepo.CreateAsync(specialEdModel);
            return specialEdModel.ToSpecialEdDto();
        }

        public async Task<SpecialEdDto> UpdateAsync(int id, UpdateSpecialEdRequestDto updateDto)
        {
            var specialEd = await _specialEdRepo.UpdateAsync(id, updateDto.ToSpecialEdFromUpdateDto(id));
            return specialEd?.ToSpecialEdDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var specialEdModel = await _specialEdRepo.DeleteAsync(id);
            return specialEdModel != null;
        }
    }
}
