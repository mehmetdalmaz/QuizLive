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
    public class EfQuestion : GenericRepository<Entitiy.Concrete.Question>, IQuestionDal
    {
        private readonly QuizLiveContext _context;
        public EfQuestion(QuizLiveContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetQuestionsWithOptionsAsync()
        {
            return await _context.Questions
                .Include(q => q.Options)
                .ToListAsync();
        }

        public Task<List<Question>> GetQuestionsWithOptionsByQuizIdAsync(int Id)
        {
            return _context.Questions
                .Include(q => q.Options)
                .Where(q => q.Id == Id)
                .ToListAsync();
        }
    }
}