using Volo.Abp.BlobStoring;

namespace PSHAPPS.Abp.BlobStoring.ArvanCloudProviderProvider
{
    public class ArvanCloudBlobProviderConfiguration
    {
        private readonly BlobContainerConfiguration _containerConfiguration;

        public ArvanCloudBlobProviderConfiguration(BlobContainerConfiguration containerConfiguration)
        {
            _containerConfiguration = containerConfiguration;
        }

        public string AccessKey
        {
            get => _containerConfiguration.GetConfiguration<string>(ArvanCloudBlobProviderConfigurationNames.AccessKey);
            set => _containerConfiguration.SetConfiguration(ArvanCloudBlobProviderConfigurationNames.AccessKey, value);
        }

        public string SecretKey
        {
            get => _containerConfiguration.GetConfiguration<string>(ArvanCloudBlobProviderConfigurationNames.SecretKey);
            set => _containerConfiguration.SetConfiguration(ArvanCloudBlobProviderConfigurationNames.SecretKey, value);
        }

        public string BucketName
        {
            get => _containerConfiguration.GetConfiguration<string>(ArvanCloudBlobProviderConfigurationNames.BucketName);
            set => _containerConfiguration.SetConfiguration(ArvanCloudBlobProviderConfigurationNames.BucketName, value);
        }

        public string ServiceUrl
        {
            get => _containerConfiguration.GetConfiguration<string>(ArvanCloudBlobProviderConfigurationNames.ServiceUrl);
            set => _containerConfiguration.SetConfiguration(ArvanCloudBlobProviderConfigurationNames.ServiceUrl, value);
        }
    }

}
