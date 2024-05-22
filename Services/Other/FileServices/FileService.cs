using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace APMApi.Services.Other.FileServices;

public class FileService : IFileService
{
    // Add a document
    public async Task<string> AddDocument(IFormFile file)
    {
        if (file.ContentType.Contains("image")) file = ReduceImageWeight(file);
        
        var uniqueFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "files" , uniqueFileName);

        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

        var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);
        
        return $"files?fileName={uniqueFileName}";
    }
    
    // Update a document
    public async Task<string> UpdateDocument(IFormFile file, string previous)
    {
        if (!previous.StartsWith("http")) DeleteDocument(previous);
        return await AddDocument(file);
    }
    
    // Delete a document
    public void DeleteDocument(string previous)
    {
        if (previous.StartsWith("http")) return;
        var basePath = GetDocumentByLink(previous);
        var path = Path.Combine(Directory.GetCurrentDirectory(), basePath);
        File.Delete(path);
        if (Directory.GetFiles(Path.GetDirectoryName(path)!).Length == 0)
        {
            Directory.Delete(Path.GetDirectoryName(path)!);
        }
    }

    public string GetDocumentByLink(string fileName)
    {
        var name = fileName.Split("?fileName=").Last();
        return Path.Combine("files", name);
    }
    
    private IFormFile ReduceImageWeight(IFormFile file)
    {
        using var image = SixLabors.ImageSharp.Image.Load(file.OpenReadStream());
        var height = (int) (100 * image.Height / (double) image.Width);
        image.Mutate(x => x.Resize(100, height));
        var memoryStream = new MemoryStream();
        image.Save(memoryStream, new PngEncoder());
        memoryStream.Position = 0;
        return new FormFile(memoryStream, 0, memoryStream.Length, file.Name, file.FileName.Split('.').First() + ".png");
    }
    
    
    public string GetContentType(string fileName)
    {
        var extension = fileName.Split('.').Last();
        return extension switch
        {
            "png" => "image/png",
            "pdf" => "application/pdf",
            _ => throw new Exception("Not supported file type")
        };
    }
}