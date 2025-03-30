using MotelManagement.Data.Models;

namespace MotelManagement.Business.IService
{
    public interface IImageService
    {
        Task addnewImage(List<Image> data);
    }
}
