namespace ECommerceNetCore.ImageAPI.Helpers
{
    public interface IFileHelper
    {
        bool CheckFileTypeValid(string type);
        void CreateFile(string directory, IFormFile file);
        string Upload(IFormFile file, string directory = "");
    }
}
