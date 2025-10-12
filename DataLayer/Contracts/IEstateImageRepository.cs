    using DataLayer.Models;

    namespace DataLayer.Contracts.Contracts
    {
        public interface IEstateImageRepository
        {
            Task<EstateImage?> GetById(int id);
            Task<EstateImage?> GetImageByEstateId(int id);
            Task Insert(EstateImage image);
            Task Update(EstateImage image);
            Task Delete(EstateImage image);
            Task DeleteByEstateId(int id);
            Task DeleteByImageId(int id);
        }
    }
