using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;
public class Question
{
    public Guid QuestionId { get; set; } = Guid.NewGuid();
    public string QuestionLabel { get; set; }
    public bool IsMandatory { get; set; }
    public AnswerFormat AnswerType { get; set; } = new();

    public Question()
    {

    }

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
    public List<Question> Questions { get; set; }
    public List<SubSection> SubSections { get; set; }
}

public class SubSection:Section
{

}


public class Questionaire
{
    public Guid QuestionaireId { get; set; } = Guid.NewGuid();
    public List<Section> Sections { get; set; } = new();
    public List<Question> Questions { get; set; } = new List<Question>();

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

public class SingleAnswer : AnswerFormat
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

    public List<string> Choices { get; set; }
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
    SingleLine,
    MultiLine,
    YesNo,
    MulipleChoice
}
