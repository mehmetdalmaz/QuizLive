using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuizLive.DataAccess.Abstract;
using QuizLive.DTO.ExamDto;
using QuizLive.DTO.ExamResultDto;
using QuizLive.DTO.QuestionDto;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;
        public ExamController(IExamService examService, IMapper mapper, ICourseService courseService)
        {
            _examService = examService;
            _mapper = mapper;
            _courseService = courseService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllExams()
        {
            var exams = await _examService.GetAllWithCourseAsync();
            var result = _mapper.Map<List<ResultExamDto>>(exams);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamById(int id)
        {
            var exam = await _examService.GetByIdWithCourseAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<ResultExamDto>(exam);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateExam([FromBody] CreateExamDto createExamDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exam = _mapper.Map<Exam>(createExamDto);
            await _examService.TAddAsync(exam);
            var ResultExamDto = _mapper.Map<ResultExamDto>(exam);
            return CreatedAtAction(nameof(GetExamById), new { id = exam.Id }, ResultExamDto);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(int id, [FromBody] UpdateExamDto updateExamDto)
        {
            if (id != updateExamDto.Id)
                return BadRequest("ID uyuşmuyor.");

            var exam = _mapper.Map<Exam>(updateExamDto);
            await _examService.TUpdateAsync(exam);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var exam = await _examService.TGetByIdAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            await _examService.TDeleteAsync(id);
            return NoContent();
        }
        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetExamsByCourseId(int courseId)
        {
            var course = await _courseService.TGetByIdAsync(courseId);
            if (course == null)
            {
                return NotFound();
            }
            var exams = await _examService.GetExamsByCourseIdAsync(courseId);
            var result = _mapper.Map<List<ResultExamDto>>(exams);
            return Ok(result);
        }
        [HttpGet("{examId}/questions")]
        public async Task<IActionResult> GetQuestionsByExamId(int examId)
        {
            var questions = await _examService.GetQuestionsByExamIdAsync(examId);
            if (questions == null )
            {
                return NotFound();
            }
            var result = _mapper.Map<List<ResultQuestionDto>>(questions);

            return Ok(result); 
        }
        [HttpGet("{examId}/result/{userId}")]
        public async Task<IActionResult> GetExamResult(int examId, int userId)
        {
            var result = await _examService.GetExamResultAsync(examId, userId);
            if (result == null)
                return NotFound();

            var resultDto = _mapper.Map<ResultExamResultDto>(result);
            return Ok(resultDto);
        }






    }
}