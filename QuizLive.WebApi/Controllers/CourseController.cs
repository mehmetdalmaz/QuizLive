using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizLive.DataAccess.Abstract;
using QuizLive.DTO.CourseDto;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.WebApi.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.TGetAllAsync();
            var courseDtos = _mapper.Map<List<ResultCourseDto>>(courses);
            return Ok(courseDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.TGetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            var courseDto = _mapper.Map<ResultCourseDto>(course);
            return Ok(courseDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDto createCourseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var course = _mapper.Map<Course>(createCourseDto);
            await _courseService.TAddAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] UpdateCourseDto updateCourseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var course = await _courseService.TGetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            _mapper.Map(updateCourseDto, course);
            await _courseService.TUpdateAsync(course);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _courseService.TGetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            await _courseService.TDeleteAsync(id);
            return NoContent();
        }

    }
}