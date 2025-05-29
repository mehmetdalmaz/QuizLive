
using Microsoft.EntityFrameworkCore;
using QuizLive.DataAccess.Abstract;
using QuizLive.DataAccess.Context;
using QuizLive.DataAccess.Repository;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.DataAccess.EntitiyFramework
{
    public class EfExamDal : GenericRepository<Exam>, IExamDal
    {
        private readonly QuizLiveContext _context;
        public EfExamDal(QuizLiveContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<Exam>> GetAllWithCourseAsync()
        {
            return _context.Exams
                .Include(e => e.Course)
                .ToListAsync();
        }

        public Task<Exam?> GetByIdWithCourseAsync(int id)
        {
            return _context.Exams
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ExamResult?> GetExamResultAsync(int examId, int AppUserId)
        {
            return await _context.ExamResults
                .FirstOrDefaultAsync(er => er.ExamId == examId && er.AppUserId== AppUserId);
        }

        public Task<List<Exam>> GetExamsByCourseIdAsync(int courseId)
        {
            return _context.Exams
                .Where(e => e.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<List<Question>> GetQuestionsByExamIdAsync(int examId)
        {
            return await _context.Questions
                .Where(q => q.ExamId == examId)
                .Include(q => q.Options)
                .ToListAsync();
        }
    }
}