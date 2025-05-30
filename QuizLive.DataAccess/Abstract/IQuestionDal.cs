using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.DataAccess.Abstract
{
    public interface IQuestionDal : IGenericDal<Question>
    {
        Task<List<Question>> GetQuestionsWithOptionsAsync();
        Task<List<Question>> GetQuestionsWithOptionsByQuizIdAsync(int Id);
        
    }
}