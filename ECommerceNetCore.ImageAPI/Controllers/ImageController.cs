using ECommerceNetCore.Application.Results;
using ECommerceNetCore.ImageAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceNetCore.ImageAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : Controller
    {
        IFileHelper _fileHelper;

        public ImageController(IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
        }

        [HttpPost("upload")]
        public JsonResult Upload(IFormFile file)
        {
            try
            {
                var directory = $"\\{DateTime.Now.Date.ToShortDateString().Replace(".","")}\\";
                var result = _fileHelper.Upload(file, directory);

                return Json(new SuccessResult(result));
            }
            catch (Exception ex)
            {
                return Json(new ErrorResult(ex.Message));
            }

        }

        [HttpGet("check/{fileName}")]
        public JsonResult CheckFile(string fileName)
        {
            try
            {
                return Json(new Result(_fileHelper.CheckFileExist(fileName)));
            }
            catch (Exception ex)
            {
                return Json(new ErrorResult(ex.Message));
            }

        }
    }
}
