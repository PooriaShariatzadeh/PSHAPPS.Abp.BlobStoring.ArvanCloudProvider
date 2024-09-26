using System;
using Volo.Abp.BlobStoring;

namespace PSHAPPS.Abp.BlobStoring.ArvanCloudProviderProvider
{
    public static class ArvanCloudBlobContainerConfigurationExtensions
    {
        public static BlobContainerConfiguration UseArvanCloud(
            this BlobContainerConfiguration container,
            Action<ArvanCloudBlobProviderConfiguration> configureAction)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            container.ProviderType = typeof(ArvanCloudBlobProvider);
            configureAction(new ArvanCloudBlobProviderConfiguration(container));

            return container;
        }
    }
}
