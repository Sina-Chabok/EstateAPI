using DataLayer.Contracts;
using DataLayer.DTOs;
using Estate.Api.Routes.V1;
using Microsoft.AspNetCore.Mvc;

namespace Estate.Api.Controllers;

[ApiController]
[Route("api/v1/")]
public class QueryController(IQueryRepository repository) : ControllerBase
{
    [HttpGet(QueryRoutes.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var estates = await repository.GetAll();
        return new OkObjectResult(estates);
    }

    [HttpGet(QueryRoutes.GetById)]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        GetEstateByIdDto? estate = await repository.GetById(id);

        return estate is null? NotFound() : new OkObjectResult(estate);
    }
}

