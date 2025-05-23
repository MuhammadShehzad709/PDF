using Microsoft.Extensions.FileProviders;
using pdf.Sevices.FileUploadservices;

var builder = WebApplication.CreateBuilder(args);

// 👇 Railway ke liye port binding
builder.WebHost.UseUrls("http://0.0.0.0:8080");

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();

var app = builder.Build();

// Swagger enable in all environments
app.UseSwagger();
app.UseSwaggerUI();

// 👇 Static file serve karne ke liye UploadedFiles folder
var folderPath = Path.Combine(builder.Environment.ContentRootPath, "UploadedFiles");
if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(folderPath),
    RequestPath = "/files"
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
