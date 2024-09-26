using Volo.Abp.BlobStoring;
using Volo.Abp.Modularity;

namespace PSHAPPS.Abp.BlobStoring.ArvanCloudProviderProvider
{
    [DependsOn(typeof(AbpBlobStoringModule))]
    public class ArvanCloudBlobStoringProviderModule : AbpModule
    {

    }
}
