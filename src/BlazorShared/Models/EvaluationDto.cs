using AutoMapper;
using CleanArchitecture.Blazor.Application.Common.Mappings;
using CleanArchitecture.Blazor.Domain.Entities;

namespace BlazorShared.Models;

public class EvaluationDto : AnswerFormatDto, IMapFrom<Evaluation>
{

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Evaluation, EvaluationDto>(MemberList.None);
        profile.CreateMap<EvaluationDto, Evaluation>(MemberList.None);

    }

    public Priority Priority { get; set; }
    public Assessment SelfAssessment { get; set; }
    public Assessment InternalAssessment { get; set; }

    public EvaluationDto()
    {
        base.AnswerTypeEnum = AnswerTypeEnum.Evaluation;
    }

}
