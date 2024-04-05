using AutoMapper;
using AutoMapper.QueryableExtensions;
using PermitPequests.Application.Common.Extensions;
using PermitPequests.Application.Common.PaginationQuery;
using PermitPequests.Application.Common.PaginationResponse;
using PermitPequests.Application.Features.Permissions.Requests;
using PermitPequests.Application.Features.Permissions.Responses;
using PermitPequests.Application.Interfaces;
using PermitPequests.Application.Interfaces.Services;
using PermitPequests.Domain.Entities;

namespace PermitPequests.Application.Features.Permissions.Services
{
    public class PermissionsService : IPermissionsService
    {
        private readonly IBaseRepository<Permission> _permissionRepository;
        private readonly IMapper _mapper;

        public PermissionsService(IBaseRepository<Permission> permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }
        public Task<Paged<PermissionsResponseDto>> GetPagedPermissions(PaginationQuery paginationQuery, CancellationToken cancellationToken)
        {
            var query = _permissionRepository.Query().OrderByDescending(c => c.CreatedDate);

            var queryMapped = query
             .ProjectTo<PermissionsResponseDto>(_mapper.ConfigurationProvider);

            var paginatedResult = queryMapped
            .Paginate(paginationQuery.PageNumber, paginationQuery.PageSize, cancellationToken);

            return paginatedResult;
        }

        public async Task<PermissionsResponseDto> GetPermissionsById(Guid id)
        {
            var permission = await _permissionRepository.GetById(id);
            var dto = _mapper.Map<PermissionsResponseDto>(permission);
            return dto;
        }

        public async Task<PermissionsResponseDto> CreatePermissions(CreatePermissionsRequestDto request, CancellationToken cancellationToken = default)
        {

            var permissionEntity = _mapper.Map<Permission>(request);
            var user = await _permissionRepository.AddAsync(permissionEntity, cancellationToken);
            var dto = _mapper.Map<PermissionsResponseDto>(user);

            return dto;
        }

        public async Task<PermissionsResponseDto> UpdatePermissions(UpdatePermissionsRequestDto request, CancellationToken cancellationToken = default)
        {
            
            var permission = _mapper.Map<Permission>(request);
            var result = await _permissionRepository.UpdateAsync(permission);

            var dto = _mapper.Map<PermissionsResponseDto>(result);
            return dto;
        }

        public async Task<PermissionsResponseDto> DeletePermissionsById(Guid id)
        {
            var result = await _permissionRepository.Delete(id);

            var dto = _mapper.Map<PermissionsResponseDto>(result);

            return dto;
        }
    }
}
