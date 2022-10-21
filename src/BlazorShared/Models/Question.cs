using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class Question
{
    public Guid QuestionId { get; set; } = Guid.NewGuid();

    public string Category { get; set; } = "Default";
    public string QuestionLabel { get; set; }
    public bool IsMandatory { get; set; }

    public AnswerTypeEnum AnswerTypeEnum { get; set; }
    public AnswerFormat AnswerType { get; set; } = new();

    public static Question Create(AnswerTypeEnum answerTypeEnum)
    {
        var question = new Question();
        switch (answerTypeEnum)
        {
            case AnswerTypeEnum.ShortText:
                question.AnswerType = new ShortText();
                break;
            case AnswerTypeEnum.LongText:
                question.AnswerType = new LongText();
                break;
            case AnswerTypeEnum.YesNo:
                break;
            case AnswerTypeEnum.MulipleChoice:
                break;
            case AnswerTypeEnum.Criterios:
                break;
            default:
                break;
        }
        return question;
    }



}

public class AssessmentQuestion: Question
{
    public Priority Priority { get; set; }
    public Assessment InternalAssessment { get; set; }
    public string InternalNote { get; set; }
    public int Score { get { return (5 - (int)Priority) * (int)InternalAssessment; } }
    public int MaximumScore { get { return (5 - (int)Priority) * 3; } }

}


public class QuestionaireSearchRequest
{

}

public class QuestionaireRequest
{
    public Guid QuestionaireId { get; set; } = Guid.NewGuid();
}


public class Section
{

    public string SectionName { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();
    public List<SubSection> SubSections { get; set; } = new List<SubSection>();
}

public class SubSection:Section
{

}


public class Questionaire
{
    public Guid QuestionaireId { get; set; } = Guid.NewGuid();
    public List<Section> Sections { get; set; } = new List<Section>();
    public List<Question> Questions { get; set; } = new List<Question>();



    public void AddQuestion(Question question)
    {
        Questions.Add(question);

        var section = Sections.FirstOrDefault(x => x.SectionName == question.Category);
        if(section!=null)
        {
            section.Questions.Add(question);
        }
        else
        {
            var newSection = new Section() { SectionName = question.Category };
            newSection.Questions.Add(question);
            Sections.Add(newSection);

        }
    }

}


public class AnswerFormat
{

    public Guid AnswerId { get; set; } = Guid.NewGuid();
    public DateTime? AnswerDate { get; set; } = null;
    public string AnswerMotivation { get; set; }

    public void AnswerChanged()
    {
        AnswerDate = DateTime.Now;
    }
}

public class ShortText : AnswerFormat
{
    private string _answer;

    public string Answer { get => _answer; set { _answer = value; AnswerChanged(); } }
}

public class LongText : AnswerFormat
{
    private string _answer;

    public string Answer { get => _answer; set { _answer = value; AnswerChanged(); } }
}

public class YesNoAnswer : AnswerFormat
{
    private YesNoEnum _answer;

    public YesNoEnum Answer { get => _answer; set { _answer = value; AnswerChanged(); } }

}

public class MultipleChoice : AnswerFormat
{
    private string _answer;

    public Dictionary<string, string> Choices { get; set; } = new Dictionary<string, string>();
    public string Answer { get => _answer; set {  _answer = value; AnswerChanged(); } }

}

public class SingleChoice : AnswerFormat
{
    private string _answer;

    public List<string> Choices { get; set; }
    public string Answer { get => _answer; set { _answer = value; AnswerChanged(); } }

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
    Criterios
}
