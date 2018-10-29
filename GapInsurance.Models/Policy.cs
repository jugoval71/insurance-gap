using System;
using System.Collections.Generic;

namespace GapInsurance.Models
{
    public class Policy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationMonths { get; set; }
        public decimal Price { get; set; }
        public RiskType Risk { get; set; }
        public string User { get; set; }
        public decimal Coverage { get; set; }
        public List<Type> Types { get; set; }
    }
}
