using AutoMapper;
using DataLayer.DTOs;
using DataLayer.Models;
using Estate.Api.Routes.V1;
using Estate.Api.VMs.Command;
using Microsoft.AspNetCore.Mvc;
using Service.IBusineses;
using System.Diagnostics.Contracts;
using System.Numerics;

namespace Estate.Api.Controllers;

[ApiController]
[Route("api/v1/")]
public class EstatesController(IEstateBusiness estateBusiness, IMapper mapper)
        : ControllerBase
{
    [HttpPost(EstateRoutes.Create)]
    public async Task<IActionResult> Create([FromBody] CreateEstateVm command)
    {
        var dto = mapper.Map<CreatetEstateDto>(command,x=>x.AfterMap((src, dst) => { dst.UserId = 1;}));

        await estateBusiness.Insert(dto);
        return Created();
    }

    [HttpPut(EstateRoutes.Update)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEstateVm command)
    {
        var dto = mapper.Map<UpdateEstateDto>(command, x => x.AfterMap((src, dst) => { dst.Id = id; }));

        await estateBusiness.Update(dto);
        return Ok();
    }


    [HttpDelete(EstateRoutes.Delete)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await estateBusiness.Delete(id);
        return Ok();
    }
}

