using AutoMapper;
using PermitPequests.Application.Features.Permissions.Requests;
using PermitPequests.Application.Features.Permissions.Responses;
using PermitPequests.Domain.Entities;

namespace PermitPequests.Application.Features.Permissions.Mapping
{
    public class PermissionsMappingProfile : Profile
    {
        public PermissionsMappingProfile()
        {
            CreateMap<Permission, PermissionsResponseDto>();
            CreateMap<UpdatePermissionsRequestDto, Permission>();
            // Assuming PermissionTypeId1 in DTO maps to PermissionTypeId in Permission entity
            CreateMap<CreatePermissionsRequestDto, Permission>()
                .ForMember(dest => dest.PermissionTypeId, opt => opt.MapFrom(src => src.PermissionTypeId1));

        }
    }
}
