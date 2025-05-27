using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizLive.DataAccess.Abstract;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.BussinesLayer.Services
{
   public class ExamResultManager : IExamResultService
    {
        private readonly IExamResultDal _ExamResultDal;
        public ExamResultManager(IExamResultDal ExamResultDal)
        {
            _ExamResultDal = ExamResultDal;
            
        }
        public async Task TAddAsync(ExamResult entity)
        {
           await _ExamResultDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _ExamResultDal.DeleteAsync(id);
        }

        public async Task<List<ExamResult>> TGetAllAsync()
        {
            return await _ExamResultDal.GetAllAsync();
        }

        public async Task<ExamResult> TGetByIdAsync(int id)
        {
            return await _ExamResultDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(ExamResult entity)
        {
            await _ExamResultDal.UpdateAsync(entity);
        }
    }
}