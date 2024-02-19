using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Blazor.Domain.Entities;

[Table("AnswerFormatShortTexts")]
public class ShortText : AnswerFormat
{
    public string Answer { get; set; }
}
