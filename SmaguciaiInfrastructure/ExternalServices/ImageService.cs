using SmaguciaiCore.Interfaces;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.Extensions.Configuration;
using SmaguciaiCore.Interfaces.Services;


namespace SmaguciaiInfrastructure.ExternalServices;

public class ImageService : IImageService
{

    public Stream ConvertBase64ToStream(string imageFromRequest)
    {
        byte[] imageStringToBase64 = Convert.FromBase64String(imageFromRequest);
        StreamContent streamContent = new(new MemoryStream(imageStringToBase64));
        return streamContent.ReadAsStream();
    }
    
    public async Task<string> UploadImage(Stream stream, string imageName)
    {
        string _firebaseStorageApiKey = "AIzaSyDA_zFqAgTsB46UI5j2POsA8y6Rzd0__qw";
        string _firebaseStorageAuthEmail = "admin@goatrip.com";
        string _firebaseStorageAuthPassword = "Pa$$w0rd";
        string _firebaseStorageBucket = "goatrip-a93b5.appspot.com";
        
        FirebaseAuthProvider firebaseConfiguration = new(new FirebaseConfig(_firebaseStorageApiKey));

        FirebaseAuthLink authConfiguration = await firebaseConfiguration
            .SignInWithEmailAndPasswordAsync(_firebaseStorageAuthEmail, _firebaseStorageAuthPassword);

        CancellationTokenSource cancellationToken = new CancellationTokenSource();
        
        FirebaseStorageTask storageManager = new FirebaseStorage(
                _firebaseStorageBucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(authConfiguration.FirebaseToken),
                    ThrowOnCancel = true
                })
            .Child(imageName)
            .PutAsync(stream, cancellationToken.Token);
        
        string imageFromFirebaseStorage = await storageManager;
        
        return imageFromFirebaseStorage;
    }
}