using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BlazorShared.Enums;
using BlazorShared.Models;
using CleanArchitecture.Blazor.Application.Common.Interfaces;
using CleanArchitecture.Blazor.Domain.Entities;
using EasyCaching.Core;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace BlazorShared.Services;
[ScopedRegistration]
public class SupplierService : ISupplierService
{

    private readonly IEasyCachingProviderFactory _factory;
    private readonly IEasyCachingProvider _provider;
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IQuestionaireService _questionaireService;
    private readonly IEmailService _emailService;
   




    public SupplierService(IEasyCachingProviderFactory factory, IApplicationDbContext context, IMapper mapper, IQuestionaireService questionaireService, IEmailService emailService)
    {
        _factory = factory;
        _provider = _factory.GetCachingProvider("default");
        _context = context;
        _mapper = mapper;
        _questionaireService = questionaireService;
        _emailService = emailService;
    }



    public async Task<SupplierDto> Create(SupplierCreateRequest request)
    {

        string cacheKey = $"supplier:{request.Id}";
        var supplier = new SupplierDto()
        {
            Id = request.Id,
            Name = request.Name,
            Attachments = request.Attachments,
            Comments = request.Comments,
            PhoneNumber = request.PhoneNumber,
            Contacts = request.Contacts,
            TaxReferenceNumber = request.TaxReferenceNumber

        };
        try
        {
            var entity = _mapper.Map<CleanArchitecture.Blazor.Domain.Entities.Supplier>(supplier);
            _context.Suppliers.Add(entity);
            await _context.SaveChangesAsync(new CancellationToken());
        }
        catch (Exception ex)
        {
            
            throw;
        }
   
     
        _provider.Set<Models.SupplierDto>(cacheKey, supplier, new TimeSpan(1, 0, 0));
        return supplier;
    }

    public async Task<SupplierDto> Create(SupplierDto request)
    {

        string cacheKey = $"supplier:{request.Id}";

        try
        {
            var entity = _mapper.Map<CleanArchitecture.Blazor.Domain.Entities.Supplier>(request);
            _context.Suppliers.Add(entity);

            var questionaires = await _questionaireService.Search(new QuestionaireSearchRequest() { QuestionaireType= QuestionaireType.GeneralSupplierQuestionaire });

            foreach (var questionaire in questionaires)
            {
                var questionair = new SupplierQuestionaireDto(request.Id, questionaire);
                questionair.Questionaire.Id = Guid.Parse("1e701372-40db-4c3f-91b0-17b389052407");
                var supplierQuestionaire = _mapper.Map<CleanArchitecture.Blazor.Domain.Entities.SupplierQuestionaire>(questionair);
                _context.SupplierQuestionaires.Add(supplierQuestionaire);
            }

            // Get Questionaire
            // Create Supplier Questionaire from Questionaire

            await _context.SaveChangesAsync(new CancellationToken());
        }
        catch (Exception ex)
        {

            throw;
        }


        _provider.Set<Models.SupplierDto>(cacheKey, request, new TimeSpan(1, 0, 0));
        return request;
    }

    public void Participate(Guid supplierQuestionaireId)
    {
        var supplierQuestionaire = _context.SupplierQuestionaires.FirstOrDefault(x=>x.Id == supplierQuestionaireId);
        if(supplierQuestionaire!=null)
        {
            supplierQuestionaire.InvitationStatus = CleanArchitecture.Blazor.Domain.Enums.InvitationStatusEnum.Accepted;
            _context.SaveChangesAsync(new CancellationToken());
        }
    }

    public async Task<SupplierDto> Retrieve(Guid id)
    {
        SupplierDto supplier;
        var suppliers = _context.Suppliers
            .Include(x=>x.PhysicalAddress)
            .Include(x=>x.Contacts)
            .Include(x=>x.SupplierQuestionaires)
                .ThenInclude(x=>x.Questionaire)
                .ThenInclude(x=>x.Sections)
                .ThenInclude(x=>x.Questions)
            .Include(x => x.SupplierQuestionaires)
                .ThenInclude(x => x.QuestionResponses)

                .FirstOrDefault(x=>x.Id == id);
        if (suppliers != null)
        {
            supplier = _mapper.Map<SupplierDto>(suppliers);

        }
        else
        {
            supplier = new SupplierDto();
        }

        return supplier;
    }

    public async Task<SupplierQuestionaireDto> RetrtrieveSupplierQuestionaire(Guid id)
    {
        
        var supplierq = new SupplierQuestionaireDto();
        var supplierQuestionare = _context.SupplierQuestionaires.Include(x=>x.Supplier).Include(x=>x.Questionaire).ThenInclude(x=>x.Sections).ThenInclude(x=>x.Questions).ThenInclude(x=>x.AnswerType).FirstOrDefault(x=>x.Id == id); 
      //  supplierQuestionare.Questionaire = await _questionaireService.Get(Guid.NewGuid());
        if (supplierQuestionare != null) { 
        
             supplierq=  _mapper.Map<SupplierQuestionaireDto>(supplierQuestionare);

            foreach (var section in supplierq.Questionaire.Sections)
            {
                foreach (var item in section.Questions)
                {
                    var questionResponse = supplierq.QuestionResponses.FirstOrDefault(x => x.QuestionId == item.Id);
                    if(questionResponse==null)
                    {
                        supplierq.QuestionResponses.Add(QuestionResponseDto.Create(supplierq.Id,item,section.Id));
                    }

                }
            }

            //supplierq =  await  _questionaireService.Get(supplierq.Id);
        }
        return supplierq;
    }

    public void SaveSupplierQuestioinResponses(SupplierQuestionaireDto supplierQuestionaireDto)
    {
        var entitySupplierQuestionaire = _context.SupplierQuestionaires.Include(x => x.QuestionResponses).FirstOrDefault(x => x.Id == supplierQuestionaireDto.Id);

        foreach (var qr in supplierQuestionaireDto.QuestionResponses)
        {

            if (!String.IsNullOrWhiteSpace(qr.Answer))
            {
                var entityQuestionResponse = _mapper.Map<QuestionResponse>(qr);
                if (entitySupplierQuestionaire != null && entitySupplierQuestionaire.QuestionResponses != null)
                {
                    var entityQuestionResponses = entitySupplierQuestionaire.QuestionResponses.FirstOrDefault(x => x.QuestionId == qr.QuestionId);

                    if (entityQuestionResponses == null)
                    {

                        entitySupplierQuestionaire.QuestionResponses.Add(entityQuestionResponse);
                    }
                    else
                    {
                        entityQuestionResponses.Answer = qr.Answer;
                    }

                }
            }


        }

        _context.SaveChangesAsync(new CancellationToken());
    }

    public async Task<List<SupplierDto>> SearchSuppliers(SupplierSearchRequest supplierSearchRequest)
    {
        var suppliers = new List<SupplierDto>(); ;// { new SupplierDto() { Id = new Guid("e14172fd-da80-47ef-8adc-fd2bf0f72664"), Name =" PBSA",TaxReferenceNumber = "JHGHKGASD", Contacts = new List<ContactDto>() { new ContactDto() { Id = new Guid("3e2fd844-1295-44a1-80ce-e9f3b48075e1"), FullName = "Ridwan",EmailAddress = "Ridz01@gmail.com"} } } };
        suppliers.Add(new SupplierDto() { Id = Guid.NewGuid(), Name = "ABC Company", Category = Enums.CategoryEnum.Furniture, Status = StatusEnum.Active });
        // var results = _provider.GetByPrefix<Models.SupplierDto>("supplier");

        var results = _context.Suppliers.AsEnumerable();
        foreach (var item in results)
        {
            var supplier = _mapper.Map<SupplierDto>(item);
            suppliers.Add(supplier);
        }

        return suppliers;
    }

    public void SendScorecards(Guid id)
    {
        var supplier = _context.Suppliers.Include(x=>x.SupplierQuestionaires).FirstOrDefault(x=>x.Id == id);
        foreach (var scorecard in supplier.SupplierQuestionaires)
        {
            // Generate link to scorecard questionaire 
            

            // send email to supplier to complete 

        }
    }

    public void WithdrawParticipate(Guid supplierQuestionaireId)
    {
        var supplierQuestionaire = _context.SupplierQuestionaires.FirstOrDefault(x => x.Id == supplierQuestionaireId);
        if (supplierQuestionaire != null)
        {
            supplierQuestionaire.InvitationStatus = CleanArchitecture.Blazor.Domain.Enums.InvitationStatusEnum.Withdrawn;
            _context.SaveChangesAsync(new CancellationToken());
        }
    }
}
