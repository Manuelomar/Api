using AutoMapper;
using Moq;
using PermitPequests.Application.Features.Permissions.Requests;
using PermitPequests.Application.Features.Permissions.Responses;
using PermitPequests.Application.Features.Permissions.Services;
using PermitPequests.Application.Interfaces;
using PermitPequests.Domain.Entities;

namespace PermitPequests.Test
{
    public class PermissionsServiceTests
    {
        private readonly Mock<IBaseRepository<Permission>> _mockPermissionRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly PermissionsService _permissionsService;

        public PermissionsServiceTests()
        {
            _mockPermissionRepository = new Mock<IBaseRepository<Permission>>();
            _mockMapper = new Mock<IMapper>();
            _permissionsService = new PermissionsService(_mockPermissionRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetPermissionsById_ShouldReturnPermission_WhenPermissionExists()
        {
            var permissionId = Guid.NewGuid();
            var permission = new Permission
            {
                Id = permissionId,
                EmployeeName = "John",
                EmployeeLastName = "Doe",
                PermissionType = new PermissionType { Id = Guid.NewGuid(), Description = "Sick Leave" },
                PermissionDate = DateTime.UtcNow
            };
            var permissionDto = new PermissionsResponseDto
            {
                Id = permissionId,
                EmployeeName = "John",
                EmployeeLastName = "Doe",
                PermissionTypeId = permission.PermissionType.Id.ToString(),
                PermissionType = permission.PermissionType,
                PermissionDate = DateTime.UtcNow
            };

            _mockPermissionRepository.Setup(repo => repo.GetById(permissionId))
                .ReturnsAsync(permission);

            _mockMapper.Setup(mapper => mapper.Map<PermissionsResponseDto>(permission))
                .Returns(permissionDto);

            var result = await _permissionsService.GetPermissionsById(permissionId);

            Assert.NotNull(result);
            Assert.Equal(permissionDto, result);
        }


        [Fact]
        public async Task CreatePermissions_ShouldReturnNewPermission_WhenCreated()
        {
            var createPermissionsRequestDto = new CreatePermissionsRequestDto
            {
                EmployeeName = "John",
                EmployeeLastName = "Doe",
                PermissionTypeId1 = Guid.NewGuid(),
                PermissionDate = DateTime.UtcNow
            };
            var permission = new Permission
            {
                EmployeeName = "John",
                EmployeeLastName = "Doe",
                PermissionTypeId = createPermissionsRequestDto.PermissionTypeId1,
                PermissionDate = DateTime.UtcNow
            };
            var permissionsResponseDto = new PermissionsResponseDto
            {
                EmployeeName = "John",
                EmployeeLastName = "Doe",
                PermissionTypeId = createPermissionsRequestDto.PermissionTypeId1.ToString(),
                PermissionDate = DateTime.UtcNow
            };
            var cancellationToken = new CancellationToken();

            _mockPermissionRepository.Setup(repo => repo.AddAsync(It.IsAny<Permission>(), cancellationToken))
                .ReturnsAsync(permission);

            _mockMapper.Setup(mapper => mapper.Map<Permission>(createPermissionsRequestDto))
                .Returns(permission);

            _mockMapper.Setup(mapper => mapper.Map<PermissionsResponseDto>(permission))
                .Returns(permissionsResponseDto);

            var result = await _permissionsService.CreatePermissions(createPermissionsRequestDto, cancellationToken);

            Assert.NotNull(result);
            Assert.Equal(permissionsResponseDto, result);
        }

        [Fact]
        public async Task UpdatePermissions_ShouldReturnUpdatedPermission_WhenUpdated()
        {
            var updatePermissionsRequestDto = new UpdatePermissionsRequestDto
            {
                Id = Guid.NewGuid(),
                EmployeeName = "John",
                EmployeeLastName = "Doe",
                PermissionTypeId = Guid.NewGuid().ToString(),
                PermissionDate = DateTime.UtcNow
            };
            var updatedPermission = new Permission
            {
                Id = updatePermissionsRequestDto.Id,
                EmployeeName = "John Updated",
                EmployeeLastName = "Doe Updated",
                PermissionTypeId = Guid.Parse(updatePermissionsRequestDto.PermissionTypeId),
                PermissionDate = DateTime.UtcNow.AddDays(1)
            };
            var permissionsResponseDto = new PermissionsResponseDto
            {
                Id = updatedPermission.Id,
                EmployeeName = updatedPermission.EmployeeName,
                EmployeeLastName = updatedPermission.EmployeeLastName,
                PermissionTypeId = updatedPermission.PermissionTypeId.ToString(),
                PermissionDate = updatedPermission.PermissionDate
            };

            _mockPermissionRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Permission>()))
                .ReturnsAsync(updatedPermission);

            _mockMapper.Setup(mapper => mapper.Map<Permission>(updatePermissionsRequestDto))
                .Returns(updatedPermission);

            _mockMapper.Setup(mapper => mapper.Map<PermissionsResponseDto>(updatedPermission))
                .Returns(permissionsResponseDto);

            var result = await _permissionsService.UpdatePermissions(updatePermissionsRequestDto);

            Assert.NotNull(result);
            Assert.Equal(permissionsResponseDto, result);
        }

        [Fact]
        public async Task DeletePermissionsById_ShouldReturnDeletedPermission_WhenDeleted()
        {
            var permissionId = Guid.NewGuid();
            var deletedPermission = new Permission
            {
                Id = permissionId,
                EmployeeName = "John",
                EmployeeLastName = "Doe",
                PermissionTypeId = Guid.NewGuid(),
                PermissionDate = DateTime.UtcNow
            };
            var permissionsResponseDto = new PermissionsResponseDto
            {
                Id = deletedPermission.Id,
                EmployeeName = deletedPermission.EmployeeName,
                EmployeeLastName = deletedPermission.EmployeeLastName,
                PermissionTypeId = deletedPermission.PermissionTypeId.ToString(),
                PermissionDate = deletedPermission.PermissionDate
            };

            _mockPermissionRepository.Setup(repo => repo.Delete(permissionId))
                .ReturnsAsync(deletedPermission);

            _mockMapper.Setup(mapper => mapper.Map<PermissionsResponseDto>(deletedPermission))
                .Returns(permissionsResponseDto);

            var result = await _permissionsService.DeletePermissionsById(permissionId);

            Assert.NotNull(result);
            Assert.Equal(permissionsResponseDto, result);
        }
    }
}
