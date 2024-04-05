using PermitPequests.Domain.Entities;


namespace PermitPequests.Application.Features.Permissions.Requests
{
    public class CreatePermissionsRequestDto
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public Guid PermissionTypeId1 { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
