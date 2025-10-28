using DataLayer.Contracts;
using DataLayer.DTOs;
using DataLayer.Querys;
using Estate.Api.Routes.V1;
using Estate.Api.VMs.Query;
using Microsoft.AspNetCore.Mvc;

namespace Estate.Api.Controllers;

[ApiController]
[Route("api/v1/")]
public class QueryController(IQueryRepository repository) : ControllerBase
{
    [HttpGet(QueryRoutes.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] GetEstatesQueryVm param)
    {
        var estates = await repository.GetAll(new GetEstatesQuery()
        {
            Search = param.Search,
            DocumentType = param.DocumentType,
            EstateType = param.EstateType,
        });
        return estates.Count == 0 ? NoContent() : new OkObjectResult(estates);
    }

    [HttpGet(QueryRoutes.GetById)]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        GetEstateByIdDto? estate = await repository.GetById(id);

        return estate is null? NotFound() : new OkObjectResult(estate);
    }
}

