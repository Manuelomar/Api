using Microsoft.AspNetCore.Mvc;
using PermitPequests.Application.Common;
using PermitPequests.Application.Common.PaginationQuery;
using PermitPequests.Application.Features.PermissionType.Requests;
using PermitPequests.Application.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PermitPequests.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeControllers : ControllerBase
    {
        private readonly IPermissionTypeService _permissionsService;

        public PermissionTypeControllers(IPermissionTypeService permissionsService)
        {
            _permissionsService = permissionsService;
        }

        [HttpGet]
        [SwaggerOperation(
          Summary = "Gets Permissions in the database")]
        public async Task<IActionResult> GetPagedPermissions([FromQuery] PaginationQuery paginationQuery, CancellationToken cancellationToken = default)
        {
            var result = await _permissionsService.GetPagedPermissionType(paginationQuery, cancellationToken);
            return Ok(BaseResponse.Ok(result));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
          Summary = "Gets Permissions type in the database by id")]
        public async Task<IActionResult> GetPermissionsById([FromRoute] Guid id)
        {
            var result = await _permissionsService.GetPermissionTypeById(id);
            return Ok(BaseResponse.Ok(result));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Creates a new Permissions type")]
        public async Task<IActionResult> Post([FromBody] CreatePermissionTypeRequestDto request, CancellationToken cancellationToken = default)
        {
            var result = await _permissionsService.CreatePermissionType(request, cancellationToken);
            return CreatedAtRoute(new { id = result.Id }, BaseResponse.Created(result));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
       Summary = "Updates existing Permission type")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdatePermissionTypeRequestDto request, CancellationToken cancellationToken = default)
        {
            request.Id = id;
            var result = await _permissionsService.UpdatePermissionType(request, cancellationToken);
            return Ok(BaseResponse.Updated(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
           Summary = "Deletes Permission type")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _permissionsService.DeletePermissionTypById(id);
            return Ok(BaseResponse.Ok(result));
        }

    }
}
