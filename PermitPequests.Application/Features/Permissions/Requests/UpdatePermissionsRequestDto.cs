using PermitPequests.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PermitPequests.Application.Features.Permissions.Requests
{
    public class UpdatePermissionsRequestDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeLastName { get; set; } = string.Empty;
        public string PermissionTypeId { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
