using Atl.DTOs.Allergy;
using Atl.DTOs.FoodRestriction;
using Atl.DTOs.HealthProblem;
using Atl.DTOs.Medicine;
using Atl.DTOs.Parent;
using Atl.DTOs.SpecialEd;

namespace Atl.DTOs.Child
{
    public class ChildDto
    {
        public int Id { get; set; }
        public string Modality { get; set; } = string.Empty;
        public string MemberNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Locality { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string NIF { get; set; } = string.Empty;
        public string NUS { get; set; } = string.Empty;
        public string SchoolYear { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Apolice { get; set; } = string.Empty;
        public List<AllergyDto> Alergies { get; set; }
        public List<MedicineDto> Medicines { get; set; }
        public List<FoodRestrictionDto> FoodRestrictions { get; set; }
        public List<SpecialEdDto> SpecialEds { get; set; }
        public List<HealthProblemDto> HealthProblems { get; set; }
        public List<ParentDto> Parents { get; set; }
    }
}
