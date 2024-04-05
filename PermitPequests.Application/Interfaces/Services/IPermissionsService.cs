using PermitPequests.Application.Common.PaginationQuery;
using PermitPequests.Application.Common.PaginationResponse;
using PermitPequests.Application.Features.Permissions.Requests;
using PermitPequests.Application.Features.Permissions.Responses;


namespace PermitPequests.Application.Interfaces.Services
{
    public interface IPermissionsService
    {
        Task<Paged<PermissionsResponseDto>> GetPagedPermissions(PaginationQuery paginationQuery, CancellationToken cancellationToken);
        Task<PermissionsResponseDto> GetPermissionsById(Guid id);
        Task<PermissionsResponseDto> CreatePermissions(CreatePermissionsRequestDto request, CancellationToken cancellationToken = default);
        Task<PermissionsResponseDto> UpdatePermissions(UpdatePermissionsRequestDto request, CancellationToken cancellationToken = default);
        Task<PermissionsResponseDto> DeletePermissionsById(Guid id);
    }
}
