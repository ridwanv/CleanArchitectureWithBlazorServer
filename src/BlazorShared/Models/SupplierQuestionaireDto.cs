using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using CleanArchitecture.Blazor.Application.Common.Mappings;
using CleanArchitecture.Blazor.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace BlazorShared.Models;
public class SupplierQuestionaireDto: IMapFrom<SupplierQuestionaire>
{

    public void Mapping(AutoMapper.Profile profile)
    {
        profile.CreateMap<SupplierQuestionaire, SupplierQuestionaireDto>();
        profile.CreateMap<SupplierQuestionaireDto, SupplierQuestionaire>().ForMember(x=>x.Questionaire,opt=>opt.Ignore());
        profile.CreateMap<QuestionResponseDto, QuestionResponse>().ConstructUsing(src => MapQuestionResponse(src));

    }

    private QuestionResponse MapQuestionResponse(QuestionResponseDto src)
    {

        switch (src)
        {
            //case QuestionResponseShortTextDto:
            //    return new QuestionResponseShortText();
            //case QuestionResponseMultipleChoiceDto:
            //    return new QuestionResponseMultipleChoice();
            //case QuestionResponseLongTextDto:
            //    return new QuestionResponseLongText();
            //case QuestionResponseDateTimeDto:
            //    return new QuestionResponseDateTime();

            //default: return new QuestionResponseShortText();

        };
        return new QuestionResponse();
    }

    public Guid Id { get; set; }
    public Guid SupplierId { get; set; }

    public Guid? EventId { get; set; }

    public string? EventName { get; set; }
    public string? EventDescription { get; set; }
    public DateTime? EventEnddate { get; set; } = DateTime.Now.AddDays(1);
    public SupplierDto? Supplier { get; set; } = new();
    public QuestionaireDto? Questionaire { get; set; } = new();
    public string Url { get { return $"supplier/questionaire/{Id}"; } }

    public List<QuestionResponseDto> QuestionResponses { get; set; } = new();

    public decimal PercentageComplete 
    { 
        get {

            var totalQuestions = Questionaire.Sections.Sum(x => x.Questions.Count);
            var answeredQuestions = QuestionResponses.Count(x => x.Answer != null);
            if (totalQuestions > 0)
                return (Convert.ToDecimal(answeredQuestions) / Convert.ToDecimal(totalQuestions)) * 100;
            else

                return 0;
        
        
        } 
    }

    public CleanArchitecture.Blazor.Domain.Enums.InvitationStatusEnum InvitationStatus { get; set; } = CleanArchitecture.Blazor.Domain.Enums.InvitationStatusEnum.Draft;



    public SupplierQuestionaireDto(Guid supplierId, QuestionaireDto questionaireDto)
    {
        Questionaire = questionaireDto;
        SupplierId = supplierId;
        //QuestionaireId = questionaireDto.Id;
        //GenerateQuestionaireResponses();
    }


    public SupplierQuestionaireDto()
    {
            
    }

    public static SupplierQuestionaireDto Create(Guid supplierId, QuestionaireDto questionaireDto)
    {
        var supplierQuestionaire =  new SupplierQuestionaireDto(supplierId, questionaireDto);
   return supplierQuestionaire;
    }

    public void AnswerQuestion(QuestionDto question, string answer)
    {
        //var quesion = QuestionResponses.FirstOrDefault(x => x.QuestionId == question.Id);
        //if(quesion==null)
        //{
     
        //    QuestionResponses.Add(quesion = new QuestionResponseDto() { SupplierQuestionaireId = Id, QuestionId = question.Id, Answer = answer });
        //}
        //else
        //{
        //    quesion.Answer = answer;

        //}


        //if (Questionaire.Sections.Any(section => section.Questions.Contains(question)))
        //{
        //    QuestionResponses[question].Answer = answer;
        //}
        //else
        //{
        //    throw new ArgumentException("Question not found in the questionnaire.");
        //}
    }



    public void GenerateQuestionaireResponses()
    {
        //var responses = new Dictionary<QuestionDto, QuestionResponseDto>();
        //foreach (var item in Questionaire.Questions)
        //{
        //    responses.Add(item, new QuestionResponseDto() { SupplierQuestionaireId = Id, QuestionId = item.QuestionId });
        //}
        //QuestionResponses = responses;

        var responses = new List<QuestionResponseDto>();
        foreach (var section in Questionaire.Sections)
        {
            foreach (var question in section.Questions)
            {
                responses.Add(QuestionResponseDto.Create(Id, question, section.Id));
            }
        }
        QuestionResponses = responses;
    }







}

public enum InvitationStatus
{
    Draft,
    InvitationSent,
    InvitationAccepted,
    InvitationWithdrawn,
    InProgress,
    ResponseCompleted

}
