using ECommerceNetCore.Application.Results;
using IResult = ECommerceNetCore.Application.Results.IResult;

namespace ECommerceNetCore.ImageAPI.Helpers
{
    public interface IFileHelper
    {
        bool CheckFileTypeValid(string type);
        IResult CheckFileExist(string fileName);
        void CreateFile(string directory, IFormFile file);
        string Upload(IFormFile file, string directory = "");
        bool RemoveFile(string fileName);
    }
}
