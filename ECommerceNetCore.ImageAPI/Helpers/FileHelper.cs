using ECommerceNetCore.Application.Results;
using IResult = ECommerceNetCore.Application.Results.IResult;

namespace ECommerceNetCore.ImageAPI.Helpers
{
    public class FileHelper : IFileHelper
    {
        private static string CurrentDirectory = Environment.CurrentDirectory + "\\source";
        public static string GetCurrentDirectory { get { return CurrentDirectory; } private set { } }

        public void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public bool CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return false;
            }
            return true;
        }

        public async void CreateFile(string directory, IFormFile file)
        {
            using (FileStream stream = File.Create(directory))
            {
                await file.CopyToAsync(stream);
                stream.Flush();
            }
        }

        public IResult CheckFileExist(string fileName)
        {
            string[] files = Directory.GetFiles(CurrentDirectory, fileName, SearchOption.AllDirectories);
            if (files.Count() > 0)
                return new SuccessResult(files[0]);
            return new ErrorResult();
        }

        public string Upload(IFormFile file, string directory = "")
        {
            if (file != null)
            {
                string endPoint = CurrentDirectory + directory;

                string imageExtension = Path.GetExtension(file.FileName);
                string imageName = file.FileName.Replace(" ", "").Replace("/", "");//Özel ve Türkçe karakter kontrolü yaptırmalıyız. Bunun için bir yardımcı metot oluşturacağız.

                if (!CheckFileTypeValid(imageExtension))
                    return "Wrong File Type";

                CheckDirectoryExists(endPoint);
                if (CheckFileExist(imageName).Success)
                    imageName += new Random(111);

                CreateFile(endPoint + imageName, file);
                return (directory + imageName).Replace("\\", "/");
            }
            return "Empty File";
        }

        public bool RemoveFile(string fileName)
        {
            string[] files = Directory.GetFiles(CurrentDirectory, fileName, SearchOption.AllDirectories);
            if (files.Count() > 0)
            {
                File.Delete(files[0]);
                return true;
            }

            return false;
        }
    }
}
