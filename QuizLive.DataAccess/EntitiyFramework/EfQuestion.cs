using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizLive.DataAccess.Abstract;
using QuizLive.DataAccess.Context;
using QuizLive.DataAccess.Repository;

namespace QuizLive.DataAccess.EntitiyFramework
{
    public class EfQuestion : GenericRepository<Entitiy.Concrete.Question>, IQuestionDal
    {
        public EfQuestion(QuizLiveContext context) : base(context)
        {
        }
    }
}