namespace ClubFitnessSolution.Services
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Components.Forms;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Processing;
    using System.IO;
    using System;
    using System.Threading.Tasks;

    public class ImageService
    {
        private readonly IWebHostEnvironment _env;

        public ImageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> UploadImageAsync(IBrowserFile file)
        {
            try
            {
                // Define the upload folder path
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");

                // Ensure the directory exists
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Create a unique file name
                var fileName = $"{Guid.NewGuid()}_{file.Name}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Read the file into a memory stream
                using (var memoryStream = new MemoryStream())
                {
                    await file.OpenReadStream().CopyToAsync(memoryStream);
                    memoryStream.Position = 0; // Reset the position to the beginning of the stream

                    // Load the image from the memory stream using ImageSharp
                    using (var image = SixLabors.ImageSharp.Image.Load(memoryStream))
                    {
                        // Resize the image to a thumbnail size (e.g., 150x150)
                        image.Mutate(x => x.Resize(new ResizeOptions
                        {
                            Size = new SixLabors.ImageSharp.Size(150, 150),
                            Mode = ResizeMode.Crop // Use crop to maintain aspect ratio
                        }));

                        // Save the resized image
                        await using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.SaveAsJpegAsync(fileStream); // Save as JPEG
                        }
                    }
                }

                // Return the uploaded image path (relative path)
                return fileName;
            }
            catch (Exception ex)
            {
                throw new Exception($"Image upload failed: {ex.Message}");
            }
        }
    }

}
