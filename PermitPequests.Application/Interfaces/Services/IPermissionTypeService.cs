using PermitPequests.Application.Common.PaginationQuery;
using PermitPequests.Application.Common.PaginationResponse;
using PermitPequests.Application.Features.PermissionType.Requests;
using PermitPequests.Application.Features.PermissionType.Responses;

namespace PermitPequests.Application.Interfaces.Services
{
    public interface IPermissionTypeService
    {
        Task<Paged<PermissionTypeResponseDto>> GetPagedPermissionType(PaginationQuery paginationQuery, CancellationToken cancellationToken);
        Task<PermissionTypeResponseDto> GetPermissionTypeById(Guid id);
        Task<PermissionTypeResponseDto> CreatePermissionType(CreatePermissionTypeRequestDto request, CancellationToken cancellationToken = default);
        Task<PermissionTypeResponseDto> UpdatePermissionType(UpdatePermissionTypeRequestDto request, CancellationToken cancellationToken = default);
        Task<PermissionTypeResponseDto> DeletePermissionTypById(Guid id);
    }
}
