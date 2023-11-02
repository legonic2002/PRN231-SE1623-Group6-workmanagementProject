using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helpers
{
    public static class HandleFile
    {
        //save a file to cvfiles folder
        public static async Task<string> WriteFile(IFormFile file)
        {
            string fileName = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "CvFiles");
                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "ImagesFiles");
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "cvfiles", fileName);
                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    exactPath = Path.Combine(Directory.GetCurrentDirectory(), "imagesfiles", fileName);
                }
                using (var stream = new FileStream(exactPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch
            {
                return "";
            }
            return fileName;
        }

        //delete a file from cvfiles folder
        public static void DeleteFile(string fileName)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "CvFiles", fileName);
                if (fileName.Contains(".jpg") || fileName.Contains(".png") || fileName.Contains(".jpeg"))
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "ImagesFiles", fileName);
                }
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
