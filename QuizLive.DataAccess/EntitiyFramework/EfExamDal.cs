
using QuizLive.DataAccess.Abstract;
using QuizLive.DataAccess.Context;
using QuizLive.DataAccess.Repository;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.DataAccess.EntitiyFramework
{
    public class EfExamDal : GenericRepository<Exam>, IExamDal
    {
        public EfExamDal(QuizLiveContext context) : base(context)
        {
        }
    }
}