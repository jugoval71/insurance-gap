using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GapInsurance.Models
{
    public abstract class Policy<T> where T : class
    {
        public Guid EntityId { get; set; }
        public T Entity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationMonths { get; set; }
        public decimal Price { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public RiskType Risk { get; set; }
        public string User { get; set; }
        public abstract decimal Coverage { get; set; }
        public abstract string Type { get; }
    }
}
