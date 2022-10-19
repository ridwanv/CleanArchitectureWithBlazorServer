using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Services;
public interface IBatchService
{
    Task<List<Batch>> Search(BatchSearchModel batchSearchModel);
    Task<Batch> UploadIdentifications(string fileName, byte[] data);

    Task<Batch> Get(Guid batchId);

    Task<byte[]> Export(BatchSearchModel batchSearchModel);
}
