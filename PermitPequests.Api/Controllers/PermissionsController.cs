using Microsoft.AspNetCore.Mvc;
using PermitPequests.Application.Common;
using PermitPequests.Application.Common.PaginationQuery;
using PermitPequests.Application.Features.Permissions.Requests;
using PermitPequests.Application.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PermitPequests.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionsService _permissionsService;

        public PermissionsController(IPermissionsService permissionsService)
        {
            _permissionsService = permissionsService;
        }

        [HttpGet]
        [SwaggerOperation(
          Summary = "Gets Permissions in the database")]
        public async Task<IActionResult> GetPagedPermissions([FromQuery] PaginationQuery paginationQuery, CancellationToken cancellationToken = default)
        {
            var result = await _permissionsService.GetPagedPermissions(paginationQuery, cancellationToken);
            return Ok(BaseResponse.Ok(result));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
          Summary = "Gets Permissions in the database by id")]
        public async Task<IActionResult> GetPermissionsById([FromRoute] Guid id)
        {
            var result = await _permissionsService.GetPermissionsById(id);
            return Ok(BaseResponse.Ok(result));
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Creates a new Permissions")]
        public async Task<IActionResult> Post([FromBody] CreatePermissionsRequestDto request, CancellationToken cancellationToken = default)
        {
            var result = await _permissionsService.CreatePermissions(request, cancellationToken);
            return CreatedAtRoute(new { id = result.Id }, BaseResponse.Created(result));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
       Summary = "Updates existing Permissions")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdatePermissionsRequestDto request, CancellationToken cancellationToken = default)
        {
            request.Id = id;
            var result = await _permissionsService.UpdatePermissions(request, cancellationToken);
            return Ok(BaseResponse.Updated(result));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
           Summary = "Deletes Permissions")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _permissionsService.DeletePermissionsById(id);
            return Ok(BaseResponse.Ok(result));
        }

    }
}
