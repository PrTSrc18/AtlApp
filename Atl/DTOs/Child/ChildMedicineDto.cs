namespace Atl.DTOs.Child
{
    public class ChildMedicineDto
    {
        public int ChildId { get; set; }
        public int MedicineId { get; set; }

        public ChildMedicineDto(int childId, int medicineId)
        {
            ChildId = childId;
            MedicineId = medicineId;
        }
    }
}
