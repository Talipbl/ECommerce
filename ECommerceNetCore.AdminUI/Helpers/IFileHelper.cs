using ECommerce.AdminUI.Models;

namespace ECommerce.AdminUI.Helpers
{
    public interface IFileHelper
    {
        Task<JsonModel> ImageUpload(byte[] imageBytes, string fileName);
        Task<JsonModel> CheckFileExist(string fileName);
        Task<JsonModel> RemoveFile(string fileName);
    }
}
