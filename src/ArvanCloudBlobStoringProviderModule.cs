using Volo.Abp.BlobStoring;
using Volo.Abp.Modularity;

namespace PSHAPPS.Abp.BlobStoring.ArvanCloudProviderProvider.src
{
    [DependsOn(typeof(AbpBlobStoringModule))]
    public class ArvanCloudBlobStoringProviderModule : AbpModule
    {

    }
}
