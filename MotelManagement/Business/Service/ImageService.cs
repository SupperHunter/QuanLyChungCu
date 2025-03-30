using MotelManagement.Business.IService;
using MotelManagement.Core.IRepository;
using MotelManagement.Data.Models;

namespace MotelManagement.Business.Service
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task addnewImage(List<Image> data)
        {
            foreach (var item in data)
            {
                await _unitOfWork.imageRepository.AddAsync(item);
            }
            await _unitOfWork.SaveAsync();
        }
    }
}
