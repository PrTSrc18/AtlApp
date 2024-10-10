namespace Atl.Domain
{
    public class Parent
    {
        public int Id { get; set; }
        public string NameMother { get; set; } = string.Empty;
        public string PhoneNumberMother { get; set; } = string.Empty;
        public string AddressMother { get; set; } = string.Empty;
        public string PostalCodeMother { get; set; } = string.Empty;
        public string JobMother { get; set; } = string.Empty;
        public string WorkPlaceMother { get; set; } = string.Empty;
        public string NameFather { get; set; } = string.Empty;
        public string PhoneNumberFather { get; set; } = string.Empty;
        public string AddressFather { get; set; } = string.Empty;
        public string PostalCodeFather { get; set; } = string.Empty;
        public string JobFather { get; set; } = string.Empty;
        public string WorkPlaceFather { get; set; } = string.Empty;
        public ICollection<Child> Children { get; set; }
    }
}
