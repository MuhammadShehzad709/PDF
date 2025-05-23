namespace pdf.Sevices.FileUploadservices
{
    public interface IFileUploadService
    {
        Task<string> UploadPdfAsync(IFormFile File);
    }
}
