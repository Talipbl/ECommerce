using ECommerceNetCore.AdminUI.Models;
using ECommerceNetCore.Application.Aspects;
using ECommerceNetCore.Application.Results;
using Microsoft.AspNetCore.Mvc;
using IResult = ECommerceNetCore.Application.Results.IResult;

namespace ECommerceNetCore.AdminUI.Helpers
{
    public class FileHelper : IFileHelper
    {
        IConfiguration _configuration;
        private string ImageApiUrl { get; set; }

        public FileHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            ImageApiUrl = _configuration.GetValue<string>("ConnectionUrls:ImageApi");
        }

        [LogAspect]
        public async Task<JsonModel> ImageUpload(byte[] imageBytes, string fileName)
        {
            var uploadUrl = $"{ImageApiUrl}upload";
            return await ApiHelper.PostMultipartFormApiResponse(uploadUrl, imageBytes, fileName);
        }

        [LogAspect]
        public async Task<JsonModel> CheckFileExist(string fileName)
        {
            var checkUrl = $"{ImageApiUrl}check/{fileName}";
            return await ApiHelper.GetApiResponse(checkUrl);
        }

        [LogAspect]
        public async Task<JsonModel> RemoveFile(string fileName)
        {
            var removeUrl = $"{ImageApiUrl}remove/{fileName}";
            return await ApiHelper.GetApiResponse(removeUrl);
        }
    }
}
