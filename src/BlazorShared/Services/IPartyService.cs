using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Services;
public interface IPartyService
{

    Task<Models.PersonIdentification> Retrieve(Models.PersonIdentificationRequest request);

    Task<Models.PersonVerification> Verify(Models.PersonVerificationRequest request);

    Task<List<Models.PersonIdentification>> GetIdentifications();

    void ReadFile(string fileName, byte[] data);
}
