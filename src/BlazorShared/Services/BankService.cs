using System.Runtime.InteropServices;
using BankServiceReference;
using BlazorShared.Models;
using EasyCaching.Core;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;
using Razor.Templating.Core;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace BlazorShared.Services;

[ScopedRegistration]
public class BankService : IBankService
{

    private readonly IEasyCachingProviderFactory _factory;
    private readonly IEasyCachingProvider _provider;

    public BankService(IEasyCachingProviderFactory factory)
    {
        _factory = factory;
        _provider = _factory.GetCachingProvider("default");
    }

    public async Task<BankVerification> RetrieveBankVerification(string Id)
    {
        BankVerification response = new BankVerification();

        var cacheKey = $"bankverification{Id}";
        var cacheResponse = _provider.Get<BankVerification>(cacheKey);
        if (cacheResponse.HasValue)
        {
            response = cacheResponse.Value;
        }
        else
        {
            response = null;
        }

        return response;
    }

    public async Task<List<BankVerification>> Search(BankVerificationSearch bankVerificationSearch)
    {
        var responses = new List<Models.BankVerification>();
        var results = _provider.GetByPrefix<Models.BankVerification>("bankverification");

        foreach (var item in results)
        {
            responses.Add(item.Value.Value);
        }
        
        return responses;
    }

    public async Task<BankVerification> VerifyBankAccount(BankVerificationRequest request)
    {


         BankVerification response = new BankVerification();

        var cacheKey = $"bankverification{request.BankAccount.AccountNumber}";
        var cacheResponse = _provider.Get<BankVerification>(cacheKey);
        if (cacheResponse.HasValue)
        {
            response = cacheResponse.Value;
        }
        else
        {

            BankServiceClient bankServiceClient = new BankServiceClient(new BankServiceClient.EndpointConfiguration() {  });
            bankServiceClient.Endpoint.Address = new System.ServiceModel.EndpointAddress("https://svc.hollard.co.za/BankService/BankService.svc");
            bankServiceClient.ClientCredentials.UserName.UserName = "HSSSVCPROD001\\PurpleConnectUSR";
            bankServiceClient.ClientCredentials.UserName.Password = "BTyc@MPZ!Q";

            request.IdentityNumber = "8504105216082";
            request.BankAccount.BranchCode = "250955";
            request.CellphoneNumber = "0724751515";
            request.Reference = "Test";
            var bankAccountVerification = bankServiceClient.VerifyBankAccount(new VerifyBankAccountCriteria()
            {
                AccountNumber = request.BankAccount.AccountNumber,
                BankAccountType = BankServiceReference.BankAccountType.ChequeAccount,
                BranchCode = request.BankAccount.BranchCode,
                Reference = request.Reference,
                VerificationId = Guid.NewGuid(),
                AccountHolder = new BankServiceReference.Person()
                {
                    Initials = request.Initials,
                    Identity = new BankServiceReference.PersonIdentity() { IdentityNumber = request.IdentityNumber, IdentityType = BankServiceReference.PersonIdentityType.NationalIdentity },
                    EmailAddress = request.EmaillAddress,
                    MobilePhoneNumber = request.CellphoneNumber,
                    Surname = request.LastName,
                    TaxReference = ""
                }
            });


            response = new BankVerification()
            {
                BankAccount = request.BankAccount,
                Initials = request.Initials,
                LastName = request.LastName,
                BankAccountVerificationResult = new BankAccountVerificationResult() { AccountAcceptsCredit = MapResult(bankAccountVerification.AccountAcceptsCredit.Result),
                                                                                      AccountOpen = (Models.Result)bankAccountVerification.AccountOpen.Result,
                                                                                        AccountAcceptsDebit = (Models.Result)bankAccountVerification.AccountAcceptsDebit.Result,
                                                                                        AccountDormant = (Models.Result)bankAccountVerification.AccountDormant.Result,
                    IdentityNumberMatch = (Models.Result)((PersonVerificationResult)bankAccountVerification.AccountHolderMatch).IdentityMatch.Result,
                    InitialsMatch = (Models.Result)((PersonVerificationResult)bankAccountVerification.AccountHolderMatch).SurnameMatch.Result,
                    SurnameMatch = (Models.Result)((PersonVerificationResult)bankAccountVerification.AccountHolderMatch).InitialsMatch.Result,

                    AccountNumberMatch = (Models.Result)bankAccountVerification.AccountNumberMatch.Result,
                                                                                        AccountOpenForMoreThanThreeMonths = (Models.Result)bankAccountVerification.AccountOpenForMoreThanThreeMonths.Result,
                                                                                        BankAccountTypeMatch = (Models.Result)bankAccountVerification.BankAccountTypeMatch.Result,
                                                                                        BranchCodeMatch = (Models.Result)bankAccountVerification.BranchCodeMatch.Result
                }
            };
            _provider.Set<BankVerification>(cacheKey,response,new TimeSpan(1,0,0));
        }

        return response;
    }

    public async Task<byte[]> GeneratePdf(string Id)
    {
        var bankVerification = RetrieveBankVerification(Id);
        var html = await RazorTemplateEngine.RenderAsync("~/Views/BankAccountVerification.cshtml", bankVerification);

        StringReader sr = new StringReader(html.ToString());
        byte[] bytes = null;
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        using (MemoryStream memoryStream = new MemoryStream())
        {
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
            pdfDoc.Open();

            htmlparser.Parse(sr);
            pdfDoc.Close();

            bytes = memoryStream.ToArray();
            memoryStream.Close();
        }
        //var file = PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
        //byte[] fileContents = null;
        //using (MemoryStream stream = new MemoryStream())
        //{
        //    file.Save(stream, true);
        //    fileContents = stream.ToArray();
            
        //}
        //var rs = new LocalReporting()
        //            .KillRunningJsReportProcesses()
        //            .UseBinary(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? JsReportBinary.GetBinary() : jsreport.Binary.Linux.JsReportBinary.GetBinary())
        //            .Configure(cfg => cfg.AllowedLocalFilesAccess().FileSystemStore().BaseUrlAsWorkingDirectory())
        //            .AsUtility()
        //            .Create();
        //var generatedPdf = await rs.RenderAsync(new RenderRequest
        //{
        //    Template = new Template
        //    {
        //        Recipe = Recipe.ChromePdf,
        //        Engine = Engine.None,
        //        Content = html,
        //        Chrome = new Chrome
        //        {
        //            MarginTop = "10",
        //            MarginBottom = "10",
        //            MarginLeft = "50",
        //            MarginRight = "50"
        //        }
        //    }
        //});
        //MemoryStream ms = new MemoryStream();
        //generatedPdf.Content.CopyTo(ms);
        return bytes;
    }

    private Models.Result MapResult(BankServiceReference.VerificationResultType verificationResult)
    {
        switch (verificationResult)
        {
            case VerificationResultType.Yes: return Models.Result.Yes ;
            case VerificationResultType.No: return Models.Result.No;
            case VerificationResultType.NoInformationAvailable: return Models.Result.NoInformationAvailable;
            case VerificationResultType.FailedPreValidation: return Models.Result.FailedPreValidation;
            default: return Models.Result.NoInformationAvailable;
        }
    }
}
