using Atl.Data;
using Atl.Domain;
using Atl.DTOs.Child;
using Microsoft.AspNetCore.Mvc;

namespace Atl.Services
{
    public interface IChildService
    {
        Task<List<ChildDto>> GetAll(QueryObject query);
        Task<ChildDto> GetById(int id);
        Task<ChildDto> GetByName(string name);
        Task<ChildDto> CreateAsync(CreateChildDto childDto);
        Task<ChildDto> UpdateAsync(int id, UpdateChildRequestDto updateDto);
        Task<Child?> Delete(int id);
    }
}
