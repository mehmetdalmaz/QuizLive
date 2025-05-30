using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.DataAccess.Abstract
{
    public interface IExamResultDal: IGenericDal<ExamResult>
    {
            Task<List<ExamResult>> GetExamResultsWithExamAndUserAsync(Expression<Func<ExamResult, bool>> filter);

    }
}