using DataLayer.Contracts;
using DataLayer.DTOs;
using DataLayer.Querys;
using Estate.Api.Routes.V1;
using Estate.Api.VMs.Query;
using Estate.Public.Routes.V1;
using Estate.Public.VMs.Query;
using Microsoft.AspNetCore.Mvc;

namespace Estate.Public.Controllers;

[ApiController]
[Route("api/v1/")]
public class QueryController(IQueryRepository repository) : ControllerBase
{
    [HttpGet(QueryRoutes.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] GetEstatesQueryVm param)
    {
        IList<GetEstatesDto> estates = await repository.GetAllEstates(new GetEstatesQuery()
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
        GetEstateByIdDto? estate = await repository.GetEstateById(id);

        return estate is null? NotFound() : new OkObjectResult(estate);
    }

    [HttpGet(UserRoutes.GetAllUsers)]
    public async Task<IActionResult> GetAll([FromQuery] GetUserQueryVm param)
    {
        IList<GetUserDto> users = await repository.GetAllUsers(new GetUserQuery()
        {
            Page = param.Page,
            Search = param.Search
        });

        return new OkObjectResult(users);

    }




}

