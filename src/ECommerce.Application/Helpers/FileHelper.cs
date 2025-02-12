using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Helpers
{
    public static class FileHelper
    {
        public static FormFile ConvertFileFromBase64(string base64String, string fileName, string contentType)
        {
            byte[] bytes = Convert.FromBase64String(base64String);

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return new FormFile(ms, 0, ms.Length, fileName, contentType);
            }
        }
    }
}
