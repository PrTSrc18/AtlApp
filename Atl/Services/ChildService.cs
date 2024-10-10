using Atl.Data;
using Atl.Domain;
using Atl.DTOs.Child;
using Atl.Infrastructure;
using Atl.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Atl.Services
{

    public class ChildService : IChildService
    {
        private readonly IChildRepository _childRepo;

        private readonly DataBaseContext _context;

        public ChildService(DataBaseContext context, IChildRepository childRepo)
        {

            _context = context;
            _childRepo = childRepo;
        }

        public async Task<ChildDto> CreateAsync(CreateChildDto childDto)
        {           
                var childModel = childDto.ToChildFromCreateDto();
                await _childRepo.CreateAsync(childModel);
                return childModel.ToChildDto();
            
        }

        public async Task<Child?> Delete(int id)
        {
            var childModel = await _childRepo.DeleteAsync(id);

            if (childModel == null)
                return null;

            return childModel;
        }

        public async Task<List<ChildDto>> GetAll([FromQuery] QueryObject query)
        {
            var children = await _childRepo.GetAllAsync(query);

            var childrenDto = children.Select(s => s.ToChildDto()).ToList();

            return childrenDto;
        }

        public async Task<ChildDto> GetById(int id)
        {
            var child = await _childRepo.GetByIdAsync(id);

            if (child == null)
                return null;


            return child.ToChildDto();
        }

        public async Task<ChildDto> GetByName(string name)
        {
            var chlidren =  await _childRepo.GetByNameAsync(name);
            
            return chlidren.ToChildDto();

        }

        public async Task<ChildDto> UpdateAsync(int id, UpdateChildRequestDto updateDto)
        {
            var childModel = await _childRepo.UpdateAsync(id, updateDto);

            if (childModel == null)
                return null; // Retorna null se não encontrado

            childModel.FirstName = updateDto.FirstName;
            childModel.LastName = updateDto.LastName;

            await _context.SaveChangesAsync();

            return childModel.ToChildDto();
        }

      
    }
}
