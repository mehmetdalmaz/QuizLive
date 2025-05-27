using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizLive.DataAccess.Abstract;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.BussinesLayer.Services
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
            
        }
        public async Task TAddAsync(Course entity)
        {
           await _courseDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _courseDal.DeleteAsync(id);
        }

        public async Task<List<Course>> TGetAllAsync()
        {
            return await _courseDal.GetAllAsync();
        }

        public async Task<Course> TGetByIdAsync(int id)
        {
            return await _courseDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Course entity)
        {
            await _courseDal.UpdateAsync(entity);
        }
    }
}