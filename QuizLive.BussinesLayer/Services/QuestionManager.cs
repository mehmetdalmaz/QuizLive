using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizLive.DataAccess.Abstract;
using QuizLive.DTO.QuestionDto;
using QuizLive.Entitiy.Concrete;
using QuizLive.Entitiy.Enums;

namespace QuizLive.BussinesLayer.Services
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _QuestionDal;
        public QuestionManager(IQuestionDal QuestionDal)
        {
            _QuestionDal = QuestionDal;

        }

       

        public Task<List<Question>> GetQuestionsWithOptionsAsync()
        {
            return _QuestionDal.GetQuestionsWithOptionsAsync();
        }

        public Task<List<Question>> GetQuestionsWithOptionsByQuizIdAsync(int Id)
        {
            return _QuestionDal.GetQuestionsWithOptionsByQuizIdAsync(Id);
        }

        public async Task TAddAsync(Question entity)
        {
            await _QuestionDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _QuestionDal.DeleteAsync(id);
        }

        public async Task<List<Question>> TGetAllAsync()
        {
            return await _QuestionDal.GetAllAsync();
        }

        public async Task<Question> TGetByIdAsync(int id)
        {
            return await _QuestionDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Question entity)
        {
            await _QuestionDal.UpdateAsync(entity);
        }

       
    }
}