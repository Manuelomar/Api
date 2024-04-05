namespace PermitPequests.Domain.Entities
{
    public class Permission:BaseEntity
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public Guid PermissionTypeId { get; set; }
        public DateTime PermissionDate { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}
