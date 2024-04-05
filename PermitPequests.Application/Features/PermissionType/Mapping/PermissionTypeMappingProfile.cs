using AutoMapper;
using PermitPequests.Application.Features.PermissionType.Requests;
using PermitPequests.Application.Features.PermissionType.Responses;
using PermitPequests.Domain.Entities;
using TypeEntity = PermitPequests.Domain.Entities.PermissionType;
namespace PermitPequests.Application.Features.PermissionType.Mapping
{
    public class PermissionTypeMappingProfile : Profile
    {
        public PermissionTypeMappingProfile()
        {
            CreateMap<TypeEntity, PermissionTypeResponseDto>();
            CreateMap<UpdatePermissionTypeRequestDto, TypeEntity>();
            CreateMap<CreatePermissionTypeRequestDto, TypeEntity>();
        }
    }
}
