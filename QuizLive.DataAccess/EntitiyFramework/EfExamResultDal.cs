using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizLive.DataAccess.Abstract;
using QuizLive.DataAccess.Context;
using QuizLive.DataAccess.Repository;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.DataAccess.EntitiyFramework
{
    public class EfExamResultDal : GenericRepository<ExamResult>, IExamResultDal
    {
        public EfExamResultDal(QuizLiveContext context) : base(context)
        {
        }
    }
}