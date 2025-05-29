using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.DataAccess.Abstract
{
    public interface IExamDal : IGenericDal<Exam>
    {
        Task<List<Question>> GetQuestionsByExamIdAsync(int examId);
        Task<ExamResult?> GetExamResultAsync(int examId, int AppUserId);
        Task<List<Exam>> GetExamsByCourseIdAsync(int courseId);
        Task<List<Exam>> GetAllWithCourseAsync();
        Task<Exam?> GetByIdWithCourseAsync(int id);


    }
}