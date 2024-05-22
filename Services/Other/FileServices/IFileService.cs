namespace APMApi.Services.Other.FileServices;

public interface IFileService
{
    public Task<string> AddDocument(IFormFile file);
    public Task<string> UpdateDocument(IFormFile file, string previous);
    public void DeleteDocument(string previous);
    public string GetDocumentByLink(string fileName);
    public string GetContentType(string fileName);
}