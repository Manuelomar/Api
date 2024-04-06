using AutoMapper;
using AutoMapper.QueryableExtensions;
using PermitPequests.Application.Common.Extensions;
using PermitPequests.Application.Common.PaginationQuery;
using PermitPequests.Application.Common.PaginationResponse;
using PermitPequests.Application.Features.PermissionType.Requests;
using PermitPequests.Application.Features.PermissionType.Responses;
using PermitPequests.Application.Interfaces;
using PermitPequests.Application.Interfaces.Services;
using Entity = PermitPequests.Domain.Entities.PermissionType;

namespace PermitPequests.Application.Features.PermissionType.Services
{
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IBaseRepository<Entity> _permissionRepository;
        private readonly IMapper _mapper;

        public PermissionTypeService(IBaseRepository<Entity> permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }
        public Task<Paged<PermissionTypeResponseDto>> GetPagedPermissionType(PaginationQuery paginationQuery, CancellationToken cancellationToken)
        {
            var query = _permissionRepository.Query().OrderByDescending(c => c.CreatedDate);

            var queryMapped = query
             .ProjectTo<PermissionTypeResponseDto>(_mapper.ConfigurationProvider);

            var paginatedResult = queryMapped
            .Paginate(paginationQuery.PageNumber, paginationQuery.PageSize, cancellationToken);

            return paginatedResult;
        }

        public async Task<PermissionTypeResponseDto> GetPermissionTypeById(Guid id)
        {
            var permission = await _permissionRepository.GetById(id);
            var dto = _mapper.Map<PermissionTypeResponseDto>(permission);
            return dto;
        }

        public async Task<PermissionTypeResponseDto> CreatePermissionType(CreatePermissionTypeRequestDto request, CancellationToken cancellationToken = default)
        {

            var permissionEntity = _mapper.Map<Entity>(request);
            var user = await _permissionRepository.AddAsync(permissionEntity, cancellationToken);
            var dto = _mapper.Map<PermissionTypeResponseDto>(user);

            return dto;
        }



        public async Task<PermissionTypeResponseDto> DeletePermissionTypById(Guid id)
        {
            var result = await _permissionRepository.Delete(id);

            var dto = _mapper.Map<PermissionTypeResponseDto>(result);

            return dto;
        }

        public async Task<PermissionTypeResponseDto> UpdatePermissionType(UpdatePermissionTypeRequestDto request, CancellationToken cancellationToken = default)
        {
            var permission = _mapper.Map<Entity>(request);
            var result = await _permissionRepository.UpdateAsync(permission);

            var dto = _mapper.Map<PermissionTypeResponseDto>(result);
            return dto;
        }
    }
}
