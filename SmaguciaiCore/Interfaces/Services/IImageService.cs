namespace SmaguciaiCore.Interfaces.Services;

public interface IImageService
{
    Stream ConvertBase64ToStream(string imageFromRequest);
    Task<string> UploadImage(Stream stream, string imageName);
}