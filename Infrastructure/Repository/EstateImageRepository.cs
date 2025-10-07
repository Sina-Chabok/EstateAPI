using DataLayer.Contracts.Contracts;
using DataLayer.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EstateImageRepository : IEstateImageRepository
    {
        private readonly DefaultDbContext _context;

        public EstateImageRepository(DefaultDbContext context)
        {
            _context = context;
        }

        public async Task<EstateImage?> GetById(int id)
        {
            return await _context.EstateImages.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<EstateImage?> GetImageByEstateId(int id)
        {
            return await _context.EstateImages.Where(i => i.Estate.Id == id).FirstOrDefaultAsync();
        }

        public async Task Insert(EstateImage image)
        {
            await _context.EstateImages.AddAsync(image);
            await _context.SaveChangesAsync();
        }

        public async Task Update(EstateImage image)
        {
            _context.EstateImages.Update(image);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(EstateImage image)
        {
            _context.EstateImages.Remove(image);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteByEstateId(int id)
        {
            var images = await _context.EstateImages.
                Where(i => i.Estate.Id == id).ToListAsync();
            if (images.Any())
            {
                _context.EstateImages.RemoveRange(images);
            }
        }

        public async Task DeleteByImageId(int id)
        {
           var image = GetById(id);
           _context.EstateImages.Remove(image.Result);
           await _context.SaveChangesAsync();

        }
    }
}
