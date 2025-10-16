using DataLayer.Contracts;
using DataLayer.DTOs;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Service.IBusineses;
using System.Net.Mime;

namespace Estate.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/")]
    [Produces(MediaTypeNames.Application.Json)]
    public class EstatesController(IEstateBusiness estateBusiness, IQueryRepository queryRepository)
        : ControllerBase
    {
        /// <summary>
        /// افزودن ملک جدید
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] InsertEstateDto model)
        {
            //ToDo( این رو باید توی  پوشه وی ام مپ شون کنیم)
            var estate = new DataLayer.Models.Estate
            {
                UserId = 1, // در آینده از JWT میاد
                Title = model.Title,
                Description = model.Description,
                Province = model.Province,
                City = model.City,
                Address = model.Address,
                FloorNumber = model.FloorNumber,
                UnitNumber = model.UnitNumber,
                HasStorage = model.HasStorage,
                DocumentType = model.DocumentType,
                EstateType = model.EstateType,
                TransactionType = model.TransactionType,
                Prices = model.Prices.Select(p => new EstatePrice
                {
                    Amount = p.Amount,
                    PriceType = p.PriceType
                }).ToList()
            };

            await estateBusiness.Insert(estate);
            return NoContent();
        }

        /// <summary>
        /// بروزرسانی اطلاعات ملک
        /// </summary>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateEstateDto dto)
        {
            await queryRepository.GetById(id);

            dto.Id = id;

            await estateBusiness.Update(dto);
            return NoContent();
        }

        /// <summary>
        /// حذف ملک بر اساس Id
        /// </summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            //ToDO
            await queryRepository.GetById(id);
            await estateBusiness.Delete(id);
            return NoContent();
        }
    }
}
