using MotelManagement.Core.IRepository;
using MotelManagement.Data.Models;

namespace MotelManagement.Core.Repository
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(MotelManagementContext context) : base(context)
        {
        }
    }
}
