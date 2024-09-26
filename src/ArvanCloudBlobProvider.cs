using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Volo.Abp.BlobStoring;
using Volo.Abp.DependencyInjection;

namespace PSHAPPS.Abp.BlobStoring.ArvanCloudProviderProvider.src
{
    public class ArvanCloudBlobProvider : BlobProviderBase, ITransientDependency
    {
        public override async Task SaveAsync(BlobProviderSaveArgs args)
        {
            try
            {
                var client = CreateClient(args);

                var putRequest = new PutObjectRequest
                {
                    BucketName = args.Configuration.GetConfiguration<string>(ArvanCloudBlobProviderConfigurationNames.BucketName), // Use args.Configuration
                    Key = GetBlobKey(args),
                    InputStream = args.BlobStream,
                    AutoCloseStream = false
                };

                await client.PutObjectAsync(putRequest, args.CancellationToken);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public override async Task<bool> DeleteAsync(BlobProviderDeleteArgs args)
        {
            var client = CreateClient(args);

            var deleteRequest = new DeleteObjectRequest
            {
                BucketName = args.Configuration.GetConfiguration<string>(ArvanCloudBlobProviderConfigurationNames.BucketName), // Use args.Configuration
                Key = GetBlobKey(args)
            };

            try
            {
                await client.DeleteObjectAsync(deleteRequest, args.CancellationToken);
                return true;
            }
            catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
        }

        public override async Task<bool> ExistsAsync(BlobProviderExistsArgs args)
        {
            var client = CreateClient(args);

            var request = new GetObjectMetadataRequest
            {
                BucketName = args.Configuration.GetConfiguration<string>(ArvanCloudBlobProviderConfigurationNames.BucketName), // Use args.Configuration
                Key = GetBlobKey(args)
            };

            try
            {
                await client.GetObjectMetadataAsync(request, args.CancellationToken);
                return true;
            }
            catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
        }

        public override async Task<Stream> GetOrNullAsync(BlobProviderGetArgs args)
        {
            var client = CreateClient(args);

            var getRequest = new GetObjectRequest
            {
                BucketName = args.Configuration.GetConfiguration<string>(ArvanCloudBlobProviderConfigurationNames.BucketName), // Use args.Configuration
                Key = GetBlobKey(args)
            };

            try
            {
                var response = await client.GetObjectAsync(getRequest, args.CancellationToken);
                var memoryStream = new MemoryStream();
                await response.ResponseStream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                return memoryStream;
            }
            catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        private AmazonS3Client CreateClient(BlobProviderArgs args)
        {
            var accessKey = args.Configuration.GetConfiguration<string>(ArvanCloudBlobProviderConfigurationNames.AccessKey); // Use args.Configuration
            var secretKey = args.Configuration.GetConfiguration<string>(ArvanCloudBlobProviderConfigurationNames.SecretKey); ; // Use args.Configuration
            var serviceUrl = args.Configuration.GetConfiguration<string>(ArvanCloudBlobProviderConfigurationNames.ServiceUrl); // Use args.Configuration

            var config = new AmazonS3Config
            {
                ServiceURL = serviceUrl,
                ForcePathStyle = true // Important for S3-compatible services
            };

            return new AmazonS3Client(accessKey, secretKey, config);
        }

        private string GetBlobKey(BlobProviderArgs args)
        {
            return args.BlobName;
        }
    }
}
