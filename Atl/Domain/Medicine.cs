namespace Atl.Domain
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;    
        public ICollection<ChildMedicine> ChildMedicines { get; set; }
    }
}
