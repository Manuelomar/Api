namespace PermitPequests.Domain.Entities;

public class PermissionType : BaseEntity
{
    public string Description { get; set; }

    public ICollection<Permission> Permissions { get; set; }
}
