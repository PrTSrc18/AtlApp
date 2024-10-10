using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Atl.Domain
{
    [Table("ChildMedicines")]
    public class ChildMedicine
    {
        public int ChildId { get; set; }
        public int MedicineId { get; set; }
        public Child Child { get; set; }
        public Medicine Medicine { get; set; }
    }
}
