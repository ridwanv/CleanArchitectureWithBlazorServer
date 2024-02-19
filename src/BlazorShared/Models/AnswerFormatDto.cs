using AutoMapper;
using CleanArchitecture.Blazor.Application.Common.Mappings;
using CleanArchitecture.Blazor.Domain.Entities;
using DocumentFormat.OpenXml.Drawing;
using JsonSubTypes;
using Newtonsoft.Json;

namespace BlazorShared.Models;

[JsonConverter(typeof(JsonSubtypes), "AnswerTypeEnum")]
[JsonSubtypes.KnownSubType(typeof(ShortTextDto), AnswerTypeEnum.ShortText)]
[JsonSubtypes.KnownSubType(typeof(MultipleChoiceDto), AnswerTypeEnum.MulipleChoice)]
[JsonSubtypes.KnownSubType(typeof(EvaluationDto), AnswerTypeEnum.Evaluation)]
public abstract class AnswerFormatDto//:IMapFrom<AnswerFormat>
{

    public void Mapping(Profile profile)
    {

    }

    public AnswerTypeEnum AnswerTypeEnum { get; set; }

    public bool AllowAttachment { get; set; }

    public byte[] Attachments { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
    //public DateTime? AnswerDate { get; set; } = null;
    //public string AnswerMotivation { get; set; }

    //public string AnswerText { get; set; }
    public void AnswerChanged()
    {
        //AnswerDate = DateTime.Now;
    }

    public override string ToString()
    {
        //if (this is ShortTextDto shortText)
        //{
        //    return shortText.Answer;
        //}
        //if (this is LongTextDto longText)
        //{
        //    return longText.Answer;
        //}

        //if (this is Criteria criteria)
        //{
        //    return criteria.SelfAssessment.ToString();
        //}
        return base.ToString();
    }


}


