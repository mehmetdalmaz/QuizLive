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
    public class EfUserAnswerDal : GenericRepository<UserAnswer>,IUserAnswerDal
    {
        public EfUserAnswerDal(QuizLiveContext context) : base(context)
        {
        }
    }
}