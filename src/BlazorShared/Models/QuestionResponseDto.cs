using AutoMapper;
using CleanArchitecture.Blazor.Application.Common.Mappings;
using CleanArchitecture.Blazor.Domain.Entities;

namespace BlazorShared.Models;

public class QuestionResponseDto : IMapFrom<QuestionResponse>
{
    public void Mapping(AutoMapper.Profile profile)
    {
        profile.CreateMap<QuestionResponse, QuestionResponseDto>(MemberList.None).ReverseMap();
    }

    public AnswerTypeEnum AnswerTypeEnum { get; set; }
    public Guid SupplierQuestionaireId { get; set; }
    public  Guid QuestionId { get; set; }
    public string Answer { get; set; }
    public DateTime? AnswerDate { get; set; } = null;
    public string AnswerMotivation { get; set; }



    public static QuestionResponseDto Create(Guid supplierQuestionaireId, QuestionDto question, Guid sectionId)
    {
        var response = new QuestionResponseDto();


        //switch (question.AnswerType)
        //{
        //    case ShortTextDto:
        //        response = new QuestionResponseShortTextDto();
        //        break;
        //    case LongTextDto:
        //        response = new QuestionResponseLongTextDto();
        //        break;
        //        //case DatetimeAnswe:
        //        //    response = new QuestionResponseDateTimeDto();
        //        break;
        //        case MultipleChoiceDto:
        //            response = new QuestionResponseMultipleChoiceDto();
        //        break;
        //        case YesNoAnswerDto:
        //            response = new QuestionResponseYesNoDto();
        //        break;
        //        case EvaluationDto:
        //            response = new QuestionResponseEvaluationDto();
        //        break;

        //    default: response = new QuestionResponseShortTextDto();
        //        break;
        //}
     
        response.AnswerTypeEnum = question.AnswerTypeEnum;
        response.SupplierQuestionaireId = supplierQuestionaireId;
        response.QuestionId = question.Id;
       
        return response;
    }

}

public class QuestionResponseShortTextDto : QuestionResponseDto//, IMapFrom<QuestionResponseShortText>
{
    public void Mapping(AutoMapper.Profile profile)
    {
      //  profile.CreateMap<QuestionResponseShortText, QuestionResponseShortTextDto>(MemberList.None).ReverseMap();
    }

    public string Answer { get; set; }
}

public class QuestionResponseDateTimeDto : QuestionResponseDto//, IMapFrom<QuestionResponseShortText>
{
    public void Mapping(AutoMapper.Profile profile)
    {
        //  profile.CreateMap<QuestionResponseShortText, QuestionResponseShortTextDto>(MemberList.None).ReverseMap();
    }

    public DateTime Answer { get; set; }
}

public class QuestionResponseLongTextDto : QuestionResponseDto//, IMapFrom<QuestionResponseShortText>
{
    public void Mapping(AutoMapper.Profile profile)
    {
        //  profile.CreateMap<QuestionResponseShortText, QuestionResponseShortTextDto>(MemberList.None).ReverseMap();
    }

    public string Answer { get; set; }
}

public class QuestionResponseMultipleChoiceDto : QuestionResponseDto//, IMapFrom<QuestionResponseShortText>
{

    public string Answers { get; set; }

    public IEnumerable<string> SelectedAnswers { get; set; }
    public void Mapping(AutoMapper.Profile profile)
    {
        //  profile.CreateMap<QuestionResponseShortText, QuestionResponseShortTextDto>(MemberList.None).ReverseMap();
    }

  
}

public class QuestionResponseYesNoDto : QuestionResponseDto//, IMapFrom<QuestionResponseShortText>
{

    public YesNoEnum Answer { get; set; }
    public void Mapping(AutoMapper.Profile profile)
    {
        //  profile.CreateMap<QuestionResponseShortText, QuestionResponseShortTextDto>(MemberList.None).ReverseMap();
    }


}

public class QuestionResponseEvaluationDto : QuestionResponseDto//, IMapFrom<QuestionResponseShortText>
{
    public void Mapping(AutoMapper.Profile profile)
    {
        //  profile.CreateMap<QuestionResponseShortText, QuestionResponseShortTextDto>(MemberList.None).ReverseMap();
    }
    public Priority Priority { get; set; }
    public Assessment SelfAssessment { get; set; }
    public Assessment InternalAssessment { get; set; }
}