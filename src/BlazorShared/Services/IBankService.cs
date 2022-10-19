using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Services;
public interface IBankService
{

    Task<BankVerification> VerifyBankAccount(BankVerificationRequest request);

    Task<BankVerification> RetrieveBankVerification(string Id);

    Task<List<BankVerification>> Search(BankVerificationSearch bankVerificationSearch);

    Task<byte[]> GeneratePdf(string Id);
}
