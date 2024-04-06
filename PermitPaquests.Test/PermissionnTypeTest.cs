using AutoMapper;
using Moq;
using PermitPequests.Application.Features.PermissionType.Requests;
using PermitPequests.Application.Features.PermissionType.Responses;
using PermitPequests.Application.Features.PermissionType.Services;
using PermitPequests.Application.Interfaces;
using PermitPequests.Domain.Entities;
using Entity = PermitPequests.Domain.Entities.PermissionType;
namespace PermitPaquests.Test
{
    public class PermissionTypeTests
    {
        private readonly Mock<IBaseRepository<Entity>> _mockPermissionTypeRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly PermissionTypeService _permissionTypeService;

        public PermissionTypeTests()
        {
            _mockPermissionTypeRepository = new Mock<IBaseRepository<Entity>>();
            _mockMapper = new Mock<IMapper>();
            _permissionTypeService = new PermissionTypeService(_mockPermissionTypeRepository.Object, _mockMapper.Object);
        }


        [Fact]
        public async Task GetPermissionTypeById_ShouldReturnPermissionType_WhenExists()
        {
            var permissionTypeId = Guid.NewGuid();
            var permissionType = new Entity
            {
                Id = permissionTypeId,
                Description = "Test Description",
                Permissions = new List<Permission>()
            };
            var permissionTypeDto = new PermissionTypeResponseDto
            {
                Id = permissionTypeId,
                Description = "Test Description",
                Permissions = new List<Permission>()
            };

            _mockPermissionTypeRepository.Setup(repo => repo.GetById(permissionTypeId))
                .ReturnsAsync(permissionType);

            _mockMapper.Setup(mapper => mapper.Map<PermissionTypeResponseDto>(permissionType))
                .Returns(permissionTypeDto);

            var result = await _permissionTypeService.GetPermissionTypeById(permissionTypeId);

            Assert.NotNull(result);
            Assert.Equal(permissionTypeDto, result);
        }

        [Fact]
        public async Task CreatePermissionType_ShouldReturnCreatedPermissionType_WhenSuccessful()
        {
            var createRequest = new CreatePermissionTypeRequestDto
            {
                Description = "New Type"
            };
            var createdEntity = new Entity
            {
                Id = Guid.NewGuid(),
                Description = createRequest.Description,
                Permissions = new List<Permission>()
            };
            var createdDto = new PermissionTypeResponseDto
            {
                Id = createdEntity.Id,
                Description = createdEntity.Description,
                Permissions = createdEntity.Permissions
            };
            var cancellationToken = new CancellationToken();

            _mockPermissionTypeRepository.Setup(repo => repo.AddAsync(It.IsAny<Entity>(), cancellationToken))
                .ReturnsAsync(createdEntity);

            _mockMapper.Setup(mapper => mapper.Map<Entity>(createRequest))
                .Returns(createdEntity);

            _mockMapper.Setup(mapper => mapper.Map<PermissionTypeResponseDto>(createdEntity))
                .Returns(createdDto);

            var result = await _permissionTypeService.CreatePermissionType(createRequest, cancellationToken);

            Assert.NotNull(result);
            Assert.Equal(createdDto, result);
        }

        [Fact]
        public async Task UpdatePermissionType_ShouldReturnUpdatedPermissionType_WhenSuccessful()
        {
            var updateRequest = new UpdatePermissionTypeRequestDto
            {
                Id = Guid.NewGuid(),
                Description = "Updated Type",
                Permissions = new List<Permission>()
            };
            var updatedEntity = new Entity
            {
                Id = updateRequest.Id,
                Description = updateRequest.Description,
                Permissions = updateRequest.Permissions
            };
            var updatedDto = new PermissionTypeResponseDto
            {
                Id = updatedEntity.Id,
                Description = updatedEntity.Description,
                Permissions = updatedEntity.Permissions
            };

            _mockPermissionTypeRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Entity>()))
                .ReturnsAsync(updatedEntity);

            _mockMapper.Setup(mapper => mapper.Map<Entity>(updateRequest))
                .Returns(updatedEntity);

            _mockMapper.Setup(mapper => mapper.Map<PermissionTypeResponseDto>(updatedEntity))
                .Returns(updatedDto);

            var result = await _permissionTypeService.UpdatePermissionType(updateRequest);

            Assert.NotNull(result);
            Assert.Equal(updatedDto, result);
        }

        [Fact]
        public async Task DeletePermissionTypeById_ShouldReturnDeletedPermissionType_WhenSuccessful()
        {
            var permissionTypeId = Guid.NewGuid();
            var deletedEntity = new Entity
            {
                Id = permissionTypeId,
                Description = "Deleted Type",
                Permissions = new List<Permission>()
            };
            var deletedDto = new PermissionTypeResponseDto
            {
                Id = deletedEntity.Id,
                Description = deletedEntity.Description,
                Permissions = deletedEntity.Permissions
            };

            _mockPermissionTypeRepository.Setup(repo => repo.Delete(permissionTypeId))
                .ReturnsAsync(deletedEntity);

            _mockMapper.Setup(mapper => mapper.Map<PermissionTypeResponseDto>(deletedEntity))
                .Returns(deletedDto);

            var result = await _permissionTypeService.DeletePermissionTypById(permissionTypeId);

            Assert.NotNull(result);
            Assert.Equal(deletedDto, result);
        }
    }
}
