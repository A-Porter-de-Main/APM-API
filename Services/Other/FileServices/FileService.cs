using APMApi.Models;
using APMApi.Models.Database;
using Microsoft.IdentityModel.Tokens;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace APMApi.Services.Other.FileServices;

public class FileService : IFileService
{
    #region Fields

    private readonly DataContext _context;

    #endregion

    #region Constructor

    public FileService(DataContext context)
    {
        _context = context;
    }

    #endregion

    #region Methods
    
    // Add a document
    public async Task<string> AddDocument(IFormFile file, bool create = true)
    {
        if (file.ContentType.Contains("image")) file = ReduceImageWeight(file);

        var uniqueFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "files", uniqueFileName);

        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

        if (create)
        {
            var picture = new Picture
            {
                Name = file.FileName,
                Path = filePath
            };
            
            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();
        }
        
        var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        return $"files?fileName={uniqueFileName}";
    }

    public async Task<IEnumerable<Picture>> AddMultipleDocuments(IEnumerable<IFormFile> files)
    {
        var paths = new List<Picture>();
        foreach (var file in files)
        {
            var path = await AddDocument(file, false);
            paths.Add(new Picture
            {
                Name = file.FileName,
                Path = path
            });
        }

        return paths;
    }

    // Update a document
    public async Task<string> UpdateDocument(IFormFile file, string previous)
    {
        DeleteDocument(previous);
        return await AddDocument(file);
    }

    // Delete a document
    public void DeleteDocument(string previous)
    {
        if (previous.StartsWith("http") || previous.IsNullOrEmpty()) return;
        var picture = _context.Pictures.FirstOrDefault(x => x.Path == previous);
        if (picture != null)
        {
            _context.Pictures.Remove(picture);
            _context.SaveChanges();
        }
        var basePath = GetDocumentByLink(previous);
        var path = Path.Combine(Directory.GetCurrentDirectory(), basePath);
        File.Delete(path);
        if (Directory.GetFiles(Path.GetDirectoryName(path)!).Length == 0)
            Directory.Delete(Path.GetDirectoryName(path)!);
    }

    public string GetDocumentByLink(string fileName)
    {
        var name = fileName.Split("?fileName=").Last();
        return Path.Combine("files", name);
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

    private IFormFile ReduceImageWeight(IFormFile file)
    {
        using var image = Image.Load(file.OpenReadStream());
        var height = (int)(100 * image.Height / (double)image.Width);
        image.Mutate(x => x.Resize(100, height));
        var memoryStream = new MemoryStream();
        image.Save(memoryStream, new PngEncoder());
        memoryStream.Position = 0;
        return new FormFile(memoryStream, 0, memoryStream.Length, file.Name, file.FileName.Split('.').First() + ".png");
    }

    #endregion
}