using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring;

namespace PSHAPPS.Abp.BlobStoring.ArvanCloudProvider.src
{
    public interface IArvanCloudBlobNameCalculator
    {
        string Calculate(BlobProviderArgs args);
    }
}
