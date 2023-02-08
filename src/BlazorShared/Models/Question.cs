using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BlazorShared.Models;


public class QuestionaireSearchRequest
{

}

public class QuestionaireRequest
{
    public Guid QuestionaireId { get; set; } = Guid.NewGuid();
}

public class Criteria : AnswerFormatDto
{
    public Priority Priority { get; set; }
    public Assessment SelfAssessment { get; set; }
    public Assessment InternalAssessment { get; set; }
    //public int Score { get { return 5 - (int)Priority * 3; } }
    //public int MaximumScore { get { return 5 - (int)Priority * 3; } }
}

public enum YesNoEnum
{
    Yes,
    No

}

public enum AnswerTypeEnum
{
    ShortText,
    LongText,
    YesNo,
    SingleChoice,
    MulipleChoice,
    Evaluation
}
