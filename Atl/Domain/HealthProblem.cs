﻿namespace Atl.Domain
{
    public class HealthProblem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Child> Children { get; set; }
    }
}
