using ECommerceNetCore.AdminUI.Models;

namespace ECommerceNetCore.AdminUI.Helpers
{
    public interface IFileHelper
    {
        Task<JsonModel> ImageUpload(byte[] imageBytes, string fileName);
        Task<JsonModel> CheckFileExist(string fileName);
    }
}
