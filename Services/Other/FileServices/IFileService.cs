using APMApi.Models.Database;

namespace APMApi.Services.Other.FileServices;

public interface IFileService
{
    public Task<string> AddDocument(IFormFile file, bool create = true);
    public Task<IEnumerable<Picture>> AddMultipleDocuments(IEnumerable<IFormFile> files);
    public Task<string> UpdateDocument(IFormFile file, string previous);
    public void DeleteDocument(string previous);
    public string GetDocumentByLink(string fileName);
    public string GetContentType(string fileName);

    public string GetRightUrl(HttpRequest request, string fileName)
    {
        var url = $"{request.Scheme}://{request.Host}";
        return $"{url}/{fileName}";
    }
}