﻿namespace Atl.DTOs.Child
{
    public class CreateChildDto
    {
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
    }
}
