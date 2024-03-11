using Microsoft.AspNetCore.Mvc;

namespace PersonnelManagementSystem.API.Models
{
    public sealed class EmployeeFilter
    {
        [FromQuery(Name = "partial_name")]
        public string? PartialName { get; set; }

        [FromQuery(Name = "department_id")]
        public Guid? DepartmentId { get; set;}

        [FromQuery(Name = "hired_from")]
        public DateTime? HireDateFrom { get; set; }

        [FromQuery(Name = "hired_to")]
        public Guid? HireDateTo { get; set; }

        [FromQuery(Name = "fired_from")]
        public DateTime? FireDateFrom { get; set; }

        [FromQuery(Name = "fired_to")]
        public DateTime? FireDateTo { get; set; }
    }
}
