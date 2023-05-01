using System.ComponentModel;

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

        public bool CheckFileExist(string fileName)
        {
            string[] files = Directory.GetFiles(CurrentDirectory, fileName, SearchOption.AllDirectories);
            return files.Count() > 0 ? true : false;
        }

        public string Upload(IFormFile file, string directory = "")
        {
            if (file != null)
            {
                string endPoint = CurrentDirectory + directory;

                string imageExtension = Path.GetExtension(file.FileName);
                string imageName = file.FileName;

                var typeResult = CheckFileTypeValid(imageExtension);
                if (!typeResult)
                {
                    return "Wrong File Type";
                }

                CheckDirectoryExists(endPoint);
                CreateFile(endPoint + imageName, file);
                return (directory + imageName).Replace("\\", "/");
            }
            return "Empty File";
        }
    }
}
