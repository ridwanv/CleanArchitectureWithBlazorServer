using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Services;
public interface IQuestionaireService
{
    Task<List<QuestionaireDto>> Search(QuestionaireSearchRequest questionaireSearchRequest);

    Task<QuestionaireDto> Get(Guid questionaireId);
}
