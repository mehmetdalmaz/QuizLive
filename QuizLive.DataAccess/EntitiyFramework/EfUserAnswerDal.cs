using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizLive.DataAccess.Abstract;
using QuizLive.DataAccess.Context;
using QuizLive.DataAccess.Repository;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.DataAccess.EntitiyFramework
{
    public class EfUserAnswerDal : GenericRepository<UserAnswer>, IUserAnswerDal
    {
        private readonly QuizLiveContext _context;
        public EfUserAnswerDal(QuizLiveContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<UserAnswer>> GetAnswersByExamResultIdAsync(int examResultId)
        {
            return await _context.UserAnswers
    .Where(x => x.ExamResultId == examResultId)
    .ToListAsync();

        }

        public Task<List<UserAnswer>> GetUserAnswersWithQuestionAndSelectedOptionAsync(int examResultId)
        {
            return _context.UserAnswers
    .Include(x => x.Question)
    .Include(x => x.SelectedOption) // Eğer Option ayrı entity ise
    .Where(x => x.ExamResultId == examResultId)
    .ToListAsync();

        }
    }
}