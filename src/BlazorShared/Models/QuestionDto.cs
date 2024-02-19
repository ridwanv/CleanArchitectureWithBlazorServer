using AutoMapper;
using CleanArchitecture.Blazor.Application.Common.Mappings;
using CleanArchitecture.Blazor.Domain.Entities;
using JsonSubTypes;
using Newtonsoft.Json;

namespace BlazorShared.Models;

[JsonConverter(typeof(JsonSubtypes), "AnswerTypeEnum")]
[JsonSubtypes.KnownSubType(typeof(AssessmentQuestionDto), AnswerTypeEnum.Evaluation)]
public class QuestionDto:IMapFrom<Question>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Question, QuestionDto>(MemberList.None).ForMember(x=>x.AnswerType,opt=>opt.AllowNull());
        profile.CreateMap<QuestionDto, Question>(MemberList.None).ForMember(x => x.AnswerType, opt => opt.AllowNull());
        profile.CreateMap<AnswerFormatDto, AnswerFormat>().ConstructUsing(src => MapVehicle(src));
        profile.CreateMap<AnswerFormat, AnswerFormatDto>().ConstructUsing(src => MapAnswerFormatToAnswerFormatDto(src));

    }

    private AnswerFormatDto MapAnswerFormatToAnswerFormatDto(AnswerFormat src)
    {
        if (src.AnswerTypeEnum == CleanArchitecture.Blazor.Domain.Enums.AnswerTypeEnum.ShortText)
            return new ShortTextDto();


        return new ShortTextDto();
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public AnswerTypeEnum AnswerTypeEnum { get; set; }
    public string Category { get; set; } = "Default";
    public string QuestionLabel { get; set; }
    public string HelperText { get; set; }
    public bool IsMandatory { get; set; }
    public AnswerFormatDto AnswerType { get; set; }


    public QuestionDto()
    {
            
    }

    public AnswerFormat MapVehicle(AnswerFormatDto answerFormatDto)
    {
        if (answerFormatDto.AnswerTypeEnum == AnswerTypeEnum.ShortText)
            return new ShortText();


        return new ShortText(); ;
    }

    public static QuestionDto Create(AnswerTypeEnum answerTypeEnum)
    {
        var question = new QuestionDto();
        switch (answerTypeEnum)
        {
            case AnswerTypeEnum.ShortText:
                question.AnswerType = new ShortTextDto();
                break;
            case AnswerTypeEnum.LongText:
                question.AnswerType = new LongTextDto();
                break;
            case AnswerTypeEnum.YesNo:
                break;
            case AnswerTypeEnum.MulipleChoice:
                break;
            case AnswerTypeEnum.Evaluation:
                break;
            default:
                break;
        }
        return question;
    }



}
