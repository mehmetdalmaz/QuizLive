using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.DataAccess.Abstract
{
    public interface IUserAnswerDal : IGenericDal<UserAnswer>
    {
        Task<List<UserAnswer>> GetAnswersByExamResultIdAsync(int examResultId);
        Task<List<UserAnswer>> GetUserAnswersWithQuestionAndSelectedOptionAsync(int examResultId);


    }
}