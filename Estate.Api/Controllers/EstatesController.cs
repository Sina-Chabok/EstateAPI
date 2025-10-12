using Application.DTOs;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Service.IBusineses;
using DataLayer.Contracts;
using System.Net.Mime;

namespace Estate.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class EstatesController(IEstateBusiness estateBusiness, IQueryRepository queryRepository)
        : ControllerBase
    {
        /// <summary>
        /// دریافت همه املاک
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DataLayer.Models.Estate>>> GetAll()
        {
            var estates = await queryRepository.GetAll();
            return Ok(estates);
        }

        /// <summary>
        /// دریافت جزئیات ملک بر اساس Id
        /// </summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DataLayer.Models.Estate>> GetById(int id)
        {
            var estate = await queryRepository.GetById(id);
            if (estate == null)
                return NotFound(new { message = $"Estate with id {id} not found." });

            return Ok(estate);
        }

        /// <summary>
        /// افزودن ملک جدید
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] InsertEstateDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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

            return CreatedAtAction(nameof(GetById), new { id = estate.Id }, estate);
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // چک کنیم ملک وجود داره
            var existing = await queryRepository.GetById(id);
            if (existing == null)
                return NotFound(new { message = $"Estate with id {id} not found." });

            dto.Id = id; // مطمئن شو DTO با route هماهنگه

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
            var existing = await queryRepository.GetById(id);
            if (existing == null)
                return NotFound(new { message = $"Estate with id {id} not found." });

            await estateBusiness.Delete(id);
            return NoContent();
        }
    }
}
