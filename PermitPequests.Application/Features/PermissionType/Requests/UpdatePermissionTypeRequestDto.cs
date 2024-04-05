using PermitPequests.Domain.Entities;
using System.Text.Json.Serialization;

namespace PermitPequests.Application.Features.PermissionType.Requests
{
    public class UpdatePermissionTypeRequestDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Description { get; set; }

        public ICollection<Permission> Permissions { get; set; }
    }
}
