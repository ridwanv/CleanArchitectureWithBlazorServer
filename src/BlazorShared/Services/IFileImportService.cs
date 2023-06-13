using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Services;
public  interface IFileImportService
{
    Task<List<Models.PersonIdentificationRequest>> ReadFile(string fileName, byte[] data);
}
