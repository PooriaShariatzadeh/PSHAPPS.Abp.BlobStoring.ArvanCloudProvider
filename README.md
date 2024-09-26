# PSHAPPS.Abp.BlobStoring.ArvanCloudProvider

An ABP Framework Blob Storing Provider for [ArvanCloud Object Storage](https://www.arvancloud.com/en/products/cloud-storage).

## Introduction

`PSHAPPS.Abp.BlobStoring.ArvanCloudProvider` provides an implementation of the ABP Framework's Blob Storing system using ArvanCloud's Object Storage service. It allows you to seamlessly integrate ArvanCloud storage into your ABP applications for storing and retrieving blobs (binary large objects).

## Features

- **Easy Integration**: Plug-and-play with the ABP Framework's BlobStoring module.
- **Configuration Options**: Customize storage settings to fit your needs.
- **Efficient Storage**: Utilize ArvanCloud's scalable and reliable object storage.

## Installation

You can install the package via NuGet:

```bash
Install-Package PSHAPPS.Abp.BlobStoring.ArvanCloudProvider
```

Or via .NET CLI:

```bash
dotnet add package PSHAPPS.Abp.BlobStoring.ArvanCloudProvider
```

## Prerequisites

- **.NET 8.0** or higher.
- **ABP Framework v8.3.x** or higher.
- An **ArvanCloud** account with access to Object Storage.

## Getting Started

### 1. Install the Package

Install the `PSHAPPS.Abp.BlobStoring.ArvanCloudProvider` NuGet package into your project.

### 2. Configure Module And Blob Provider

Add Module Dependency

```csharp

[DependsOn(typeof(ArvanCloudBlobStoringProviderModule))]

```


In your module's `ConfigureServices` method, configure the BlobStoring options:

```csharp
Configure<AbpBlobStoringOptions>(options =>
{
    options.Containers.ConfigureDefault(container =>
    {
        container.UseArvanCloud(arvanCloud =>
        {
            arvanCloud.AccessKey = "YOUR_ACCESS_KEY";
            arvanCloud.SecretKey = "YOUR_SECRET_KEY";
            arvanCloud.Endpoint = "YOUR_ARVAN_ENDPOINT";
            arvanCloud.BucketName = "YOUR_BUCKETNAME";
        });
    });
});
```

**Note**: Replace the placeholders with your actual ArvanCloud credentials and settings.

### 3. Use the Blob Storage in Your Services

Inject `IBlobContainer` or `IBlobContainer<TContainer>` into your services:

```csharp
public class MyService : ITransientDependency
{
    private readonly IBlobContainer _blobContainer;

    public MyService(IBlobContainer blobContainer)
    {
        _blobContainer = blobContainer;
    }

    public async Task SaveFileAsync(string name, byte[] content)
    {
        await _blobContainer.SaveAsync(name, content);
    }

    public async Task<byte[]> GetFileAsync(string name)
    {
        return await _blobContainer.GetAllBytesAsync(name);
    }
}
```

## Configuration Options

- **AccessKey**: Your ArvanCloud access key.
- **SecretKey**: Your ArvanCloud secret key.
- **Endpoint**: The endpoint URL for ArvanCloud Object Storage.
- **BucketName**: The name of the bucket where blobs will be stored.

## Examples

### Saving a File

```csharp
await _blobContainer.SaveAsync("files/myfile.txt", fileBytes);
```

### Retrieving a File

```csharp
byte[] fileBytes = await _blobContainer.GetAllBytesAsync("files/myfile.txt");
```

### Deleting a File

```csharp
await _blobContainer.DeleteAsync("files/myfile.txt");
```

## Support

If you encounter any issues or have questions, please open an issue on the [GitHub repository](https://github.com/PooriaShariatzadeh/PSHAPPS.Abp.BlobStoring.ArvanCloudProvider/issues).

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request for any enhancements or bug fixes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgements

- [ABP Framework](https://abp.io/)
- [ArvanCloud Object Storage](https://www.arvancloud.com/en/products/cloud-storage)
- [PSHAPPS](https://www.pshapps.ir/)

## Contact

- **Author**: Pooria Shariatzadeh
- **Email**: pooria.shariatzadeh@gmail.com
- **Website**: pooriashariatzadeh.ir

---

**Disclaimer**: This project is not affiliated with or endorsed by ArvanCloud.
