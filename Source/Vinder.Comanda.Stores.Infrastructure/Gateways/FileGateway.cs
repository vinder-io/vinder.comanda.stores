namespace Vinder.Comanda.Stores.Infrastructure.Gateways;

public sealed class FileGateway(string rootPath) : IFileGateway
{
    public async Task<Image> UploadFileAsync(
        Stream stream, CancellationToken cancellation = default)
    {
        Directory.CreateDirectory(rootPath);

        var fileName = $"{Guid.NewGuid()}.jpg";
        var filePath = Path.Combine(rootPath, fileName);

        using var fileStream = new FileStream(
            path: filePath,
            mode: FileMode.Create,
            access: FileAccess.Write,
            share: FileShare.None
        );

        await stream.CopyToAsync(fileStream, cancellation);

        return new Image(Path: $"uploads/{fileName}");
    }

    public async Task<bool> DeleteFileAsync(
        Image image, CancellationToken cancellation = default)
    {
        if (image is null || string.IsNullOrWhiteSpace(image.Path))
        {
            return false;
        }

        var filePath = Path.Combine(rootPath, Path.GetFileName(image.Path));
        if (!File.Exists(filePath))
        {
            return false;
        }

        await Task.Run(() => File.Delete(filePath), cancellation);

        return true;
    }
}