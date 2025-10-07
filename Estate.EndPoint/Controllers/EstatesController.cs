using DataLayer.Contracts;
using DataLayer.Models;
using Estate.EndPoint.ViewModels;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.IBusineses;

namespace Estate.EndPoint.Controllers
{
    public class EstatesController : Controller
    {
        private readonly IEstateBusiness _estateBusiness;
        private readonly IQueryRepository _queryRepository;

        public EstatesController(IEstateBusiness estateBusiness, IQueryRepository queryRepository)
        {
            _estateBusiness = estateBusiness;
            _queryRepository = queryRepository;
        }

        // GET: Estates
        public async Task<IActionResult> Index()
        {
            var estates = await _queryRepository.GetAll();

            var model = estates.Select(e => new GetEstatesViewModel
            {
                Id = e.Id,
                Title = e.Title,
                Province = e.Province,
                City = e.City,
                FloorNumber = e.FloorNumber,
                Type = e.DocumentType
            }).ToList();

            return View(model);
        }

        // GET: Estates/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var estate = await _queryRepository.GetById(id);
            if (estate == null) return NotFound();
            return View(estate);
        }

        // GET: Estates/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEstateViewModel model)
        {

            var estate = new DataLayer.Models.Estate
            {
                UserId = 1,
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

            await _estateBusiness.Insert(estate);
            return RedirectToAction(nameof(Index));
        }

        // GET: Estates/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var estate = await _queryRepository.GetById(id);
            if (estate == null) return NotFound();
            return View(estate);
        }

        // POST: Estates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DataLayer.Models.Estate estate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _estateBusiness.Update(estate);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = await _estateBusiness.Update(estate.Id);
                    if (exists == null) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estate);
        }

        // GET: Estates/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           await _estateBusiness.Delete(id);
           return RedirectToAction(nameof(Index));
        }

    }
}
