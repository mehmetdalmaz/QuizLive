using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizLive.DataAccess.Abstract;
using QuizLive.DataAccess.Context;
using QuizLive.DataAccess.Repository;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.DataAccess.EntitiyFramework
{
    public class EfExamResultDal : GenericRepository<ExamResult>, IExamResultDal
    {
        private readonly QuizLiveContext _context;

        public EfExamResultDal(QuizLiveContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<ExamResult>> GetExamResultsWithExamAndUserAsync(Expression<Func<ExamResult, bool>> filter)
        {
            return _context.ExamResults
                .Where(filter)
                .Include(er => er.Exam)
                .Include(er => er.AppUser)
                .ToListAsync();
        }
    }
}