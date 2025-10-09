using Application.DTOs;
using DataLayer.Contracts.Contracts;
using DataLayer.Errors;
using DataLayer.Models;
using Service.IBusineses;

namespace Service.Busineses
{
    public class EstateBusiness : IEstateBusiness
    {
        private const int MinLenghtTitle = 2;
        private const int MaxLenghtTitle = 300;
        private const int MaxLenghtDescription = 2000;
        private const int MaxLenghtAddress = 500;

        private readonly IEstateRepository _estateRepository;

        public EstateBusiness(IEstateRepository estateRepository)
        {
            _estateRepository = estateRepository;
        }

        public async Task Insert(Estate estate)
        {
            ValidateEstate(estate);
            await _estateRepository.Insert(estate);
        }

        public async Task Update(UpdateEstateDto dto)
        {
            var existingEstate = await _estateRepository.GetById(dto.Id);
            if (existingEstate == null)
                throw new Exception("Estate not found");

            existingEstate.Title = dto.Title;
            existingEstate.Description = dto.Description;
            existingEstate.Address = dto.Address;
            existingEstate.City = dto.City;
            existingEstate.Province = dto.Province;
            existingEstate.DocumentType = dto.DocumentType;
            existingEstate.TransactionType = dto.TransactionType;
            existingEstate.EstateType = dto.EstateType;
            existingEstate.UnitNumber = dto.UnitNumber;
            existingEstate.FloorNumber = dto.FloorNumber;
            existingEstate.HasStorage = dto.HasStorage;

            foreach (var priceDto in dto.Prices)
            {
                var existingPrice = existingEstate.Prices
                    .FirstOrDefault(p => p.PriceType == priceDto.PriceType);

                if (existingPrice != null)
                    existingPrice.Amount = priceDto.Amount;
                else
                    existingEstate.Prices.Add(new EstatePrice
                    {
                        EstateId = existingEstate.Id,
                        PriceType = priceDto.PriceType,
                        Amount = priceDto.Amount
                    });
            }

            var removed = existingEstate.Prices
                .Where(p => !dto.Prices.Any(np => np.PriceType == p.PriceType))
                .ToList();

            foreach (var r in removed)
                existingEstate.Prices.Remove(r);

            await _estateRepository.Update(existingEstate);
        }

        public async Task Delete(int id)
        {
            var estate = await _estateRepository.GetById(id);
            if (estate is null)
                throw new ArgumentNullException(EstateError.EstateNotFound);

            await _estateRepository.Delete(estate);

        }
        private void ValidateEstate(Estate estate)
        {
            if (TitleIsNull(estate.Title))
                throw new ArgumentException(EstateError.TitleIsNull);

            if (estate.Province is null)
                throw new ArgumentException(EstateError.ProvinceIsNull);

            if (estate.City is null)
                throw new ArgumentException(EstateError.CityIsNull);

            if (estate.Title.Length < MinLenghtTitle || estate.Title.Length > MaxLenghtTitle)
                throw new ArgumentOutOfRangeException(nameof(estate.Title), EstateError.TitleLenghtIsOutOfRange);

            if (estate.Description != null && estate.Description.Length > MaxLenghtDescription)
                throw new ArgumentOutOfRangeException(nameof(estate.Description), EstateError.DescriptionLenghtIsOutOfRange);

            if (estate.Address != null && estate.Address.Length > MaxLenghtAddress)
                throw new ArgumentOutOfRangeException(nameof(estate.Address), EstateError.AddressLenghtIsOutOfRange);

        }

        private bool TitleIsNull(string? title)
        {
            return title is null;
        }
    }

}
