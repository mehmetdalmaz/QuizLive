using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizLive.DataAccess.Abstract;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.BussinesLayer.Services
{
   public class ExamManager : IExamService
    {
        private readonly IExamDal _ExamDal;
        public ExamManager(IExamDal ExamDal)
        {
            _ExamDal = ExamDal;
            
        }

        public Task<List<Exam>> GetAllWithCourseAsync()
        {
            return _ExamDal.GetAllWithCourseAsync();
        }

        public Task<Exam?> GetByIdWithCourseAsync(int id)
        {
            return _ExamDal.GetByIdWithCourseAsync(id);
        }

        public Task<ExamResult?> GetExamResultAsync(int examId, int AppUserId)
        {
           return _ExamDal.GetExamResultAsync(examId, AppUserId);
        }

        public Task<List<Exam>> GetExamsByCourseIdAsync(int courseId)
        {
            return _ExamDal.GetExamsByCourseIdAsync(courseId);
        }

        public Task<List<Question>> GetQuestionsByExamIdAsync(int examId)
        {
            return _ExamDal.GetQuestionsByExamIdAsync(examId);
        }

        public async Task TAddAsync(Exam entity)
        {
           await _ExamDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _ExamDal.DeleteAsync(id);
        }

        public async Task<List<Exam>> TGetAllAsync()
        {
            return await _ExamDal.GetAllAsync();
        }

        public async Task<Exam> TGetByIdAsync(int id)
        {
            return await _ExamDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Exam entity)
        {
            await _ExamDal.UpdateAsync(entity);
        }
    }
}