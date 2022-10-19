using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Blazor.Application.Common.Interfaces;
using EasyCaching.Core;

namespace BlazorShared.Services;
[TransientRegistration]
public class PartyService:IPartyService
{

    Party_API_V1_0_openapiClient _apiClient;
    private readonly IEasyCachingProviderFactory _factory;
    private readonly IEasyCachingProvider _provider;
    private IExcelService _excelService;

    public PartyService(IEasyCachingProviderFactory factory, IExcelService excelService)
    {
        _excelService = excelService;
        this._factory = factory;
        _provider = _factory.GetCachingProvider("default");
        var httpclient = new HttpClient() { BaseAddress = new Uri(@"https://apim-hl-life-test-za.azure-api.net/Party/uat") };
        httpclient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "d05d946b0e9b480ea9c2d751549bd5ef");
        _apiClient = new Party_API_V1_0_openapiClient(httpclient);


    }

    public async void ReadFile(string fileName, byte[] data)
    {
        var s = await _excelService.ImportAsync<Models.PersonIdentificationRequest>(data, mappers: new Dictionary<string, Func<DataRow, Models.PersonIdentificationRequest, object>>
            {
                { "IdentityNumber", (row,item) => item.IdentityNumber = row["IdentityNumber"]?.ToString() }
            });
        foreach (var item in s.Data)
        {
            await Retrieve(item);
        }


    }

    public async Task<Models.PersonIdentification> Retrieve(Models.PersonIdentificationRequest request)
    {
        string cacheKey = $"identification:{request.IdentityNumber}";
        Models.PersonIdentification response = null;

        var personIdentificationCache = _provider.Get<Models.PersonIdentification>(cacheKey);


        if (personIdentificationCache.HasValue)
            response = personIdentificationCache.Value;
        else
        {
            var idendity = await _apiClient.RetrievePersonForIdentificationAsync(request.IdentityNumber, new PersonIdentificationRequest() { IdentityType = IdentityType.NationalIdentityNumber, IdentificationType = IdentificationType.Basic, ExternalReference = "Test", BillingReference = "Test", BusinessUnit = BusinessUnit.Life, IdentificationReason = Reason.Other, Channel = ChannelType.Digital, MaxCacheAge = "0" });
            response = new BlazorShared.Models.PersonIdentification()
            {
                FirstName = idendity.PersonIdentification.Person.FirstNames,
                LastName = idendity.PersonIdentification.Person.Surname,
                IdentityNumber = idendity.PersonIdentification.Person.Identities.FirstOrDefault().IdentityNumber,
                Photo = $"data:image/jpeg;base64,{idendity.PersonIdentification.Person.Photo}"
            };           
            _provider.Set<Models.PersonIdentification>(cacheKey, response, new TimeSpan(1, 0, 0));
        }




        return response;
    }

    public async Task<Models.PersonVerification> Verify(Models.PersonVerificationRequest request)
    {

        var personVerification = new Models.PersonVerification();
        var verificationResult = await _apiClient.VerifyPersonAsync(request.Person.IdentityNumber, new PersonVerificationRequest()
        {
            FirstNames = request.Person.FirstName,
            Surname = request.Person.LastName,
            IdentityType = IdentityType.NationalIdentityNumber,
            MaxCacheAge = "0",
            VerificationReason = Reason.Administration,
            PremiumCollectionMethod = (PremiumCollectionMethod)request.PrimaryCollectionMethod,
            AnnualisedPremium = request.AnnualAmount.ToString(),
            VerifyRequirements = true,
            SourceOfIncome = SourceOfIncome.Salary,
            ProductType = ProductType.DirectLife,
            ExternalReference = "test",
            BirthDate =  new DateTime(1985,04,10),
            SourceOfWealth= SourceOfWealth.Savings,
            BillingReference = "test",
            BusinessUnit = BusinessUnit.Life,
            Channel = ChannelType.Digital
        }
        );


        personVerification.RiskResult = new Models.RiskResult() { RiskRating = (Models.RiskRating)verificationResult.RiskRatingResult.RiskRating, RiskRatingReason = verificationResult.RiskRatingResult.RiskRatingReason };

        foreach (var item in verificationResult.Verifications)
        {
            if(item is IdentityVerification)
            {
                var id = (IdentityVerification)item;
                personVerification.VerifiedPerson = new Models.Person() { FirstName = id.VerifiedPerson.FirstNames, Photo = id.VerifiedPerson.Photo };

            }

            if (item is AddressVerification)
            {
                var id = (AddressVerification)item;
                personVerification.VerifiedAddress = new Models.Address() { Line1 = id.VerifiedAddress.AddressLine1, City = id.VerifiedAddress.AddressLine3 };

                foreach (var address in id.Addresses)
                {
                    personVerification.OtherAddresses.Add(new Models.Address() { Line1 = address.AddressLine1, City = address.AddressLine3 });
                }
            }
        }

        return new Models.PersonVerification() {


        };


    }

    public async Task<List<Models.PersonIdentification>> GetIdentifications()
    {
        var responses = new List<Models.PersonIdentification>();
        var results = _provider.GetByPrefix<Models.PersonIdentification>("identification");

        foreach (var item in results)
        {
            responses.Add(item.Value.Value);
        }
        return responses;
    }
}
