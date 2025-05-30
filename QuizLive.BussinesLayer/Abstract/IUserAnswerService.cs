using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.DataAccess.Abstract
{
    public interface IUserAnswerService : IGenericService<UserAnswer>
    {
        Task<List<UserAnswer>> GetUserAnswersWithQuestionAndSelectedOptionAsync(int examResultId);

    }
}