using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizLive.DataAccess.Abstract;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.BussinesLayer.Services
{
   public class UserAnswerManager : IUserAnswerService
    {
        private readonly IUserAnswerDal _UserAnswerDal;
        public UserAnswerManager(IUserAnswerDal UserAnswerDal)
        {
            _UserAnswerDal = UserAnswerDal;
            
        }

        public Task<List<UserAnswer>> GetUserAnswersWithQuestionAndSelectedOptionAsync(int examResultId)
        {
            return _UserAnswerDal.GetUserAnswersWithQuestionAndSelectedOptionAsync(examResultId);
        }

        public async Task TAddAsync(UserAnswer entity)
        {
           await _UserAnswerDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _UserAnswerDal.DeleteAsync(id);
        }

        public async Task<List<UserAnswer>> TGetAllAsync()
        {
            return await _UserAnswerDal.GetAllAsync();
        }

        public async Task<UserAnswer> TGetByIdAsync(int id)
        {
            return await _UserAnswerDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(UserAnswer entity)
        {
            await _UserAnswerDal.UpdateAsync(entity);
        }
    }
}