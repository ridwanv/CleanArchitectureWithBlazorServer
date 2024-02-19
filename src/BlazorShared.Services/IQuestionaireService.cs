using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Models;
using CleanArchitecture.Blazor.Domain.Entities;

namespace BlazorShared.Services;
public interface IQuestionaireService
{
    Task<List<QuestionaireDto>> Search(QuestionaireSearchRequest questionaireSearchRequest);

    Task<QuestionaireDto> Get(Guid questionaireId);


    Task<QuestionaireDto> Create(QuestionaireDto questionaire);

    Task<QuestionaireDto> AddQuestion(Guid questionaireId, QuestionDto question);
}
