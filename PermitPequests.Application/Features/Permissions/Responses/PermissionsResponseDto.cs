using Entity = PermitPequests.Domain.Entities.PermissionType;
namespace PermitPequests.Application.Features.Permissions.Responses
{
    public class PermissionsResponseDto
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeLastName { get; set; } = string.Empty;
        public string PermissionTypeId { get; set; }
        public Entity PermissionType { get; set; }

        public DateTime PermissionDate { get; set; }
    }
}
