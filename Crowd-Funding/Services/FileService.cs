namespace Crowd_Funding.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public bool DeleteFiles(List<string> filePaths)
        {
            bool allDeleted = true;
            foreach (var filePath in filePaths)
            {
                try
                {
                    var path = Path.Combine(webHostEnvironment.WebRootPath, filePath);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                catch (Exception ex)
                {
                    allDeleted = false;
                    Console.WriteLine($"Error deleting file {filePath}: {ex.Message}");
                }
            }
            return allDeleted;
        }
        public async Task<List<string>> UploadFiles(List<IFormFile> files)
        {
            var path = Path.Combine(webHostEnvironment.WebRootPath, "images");
            var returnedFiles = new List<string>();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (var file in files)
            {
                var extension = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid().ToString().Replace("-", string.Empty) + extension;
                using (FileStream fileStream = File.Create(Path.Combine(path, fileName)))
                {
                    await file.CopyToAsync(fileStream);
                    returnedFiles.Add($"images/{fileName}");
                }
            }
            return returnedFiles;
        }
    }
}
