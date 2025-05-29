using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizLive.DataAccess.Abstract;
using QuizLive.DTO.QuestionDto;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        // GET: api/question
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _questionService.GetQuestionsWithOptionsAsync();
            var result = _mapper.Map<List<ResultQuestionDto>>(questions);
            return Ok(result);
        }

        // GET: api/question/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var question = await _questionService.GetQuestionsWithOptionsByQuizIdAsync(id);
            if (question == null)
                return NotFound();

            var result = _mapper.Map<ResultQuestionDto>(question);
            return Ok(result);
        }

        // POST: api/question
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var question = _mapper.Map<Question>(dto);
            await _questionService.TAddAsync(question);

            var result = _mapper.Map<ResultQuestionDto>(question);

            // CreatedAtAction içinde GetQuestionById metodunu referans gösteriyoruz
            return CreatedAtAction(nameof(GetQuestionById), new { id = question.Id }, result);
        }

        // PUT: api/question/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] UpdateQuestionDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID uyuşmuyor.");

            var existing = await _questionService.TGetByIdAsync(id);
            if (existing == null)
                return NotFound();

            _mapper.Map(dto, existing);
            await _questionService.TUpdateAsync(existing);

            return NoContent();
        }

        // DELETE: api/question/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _questionService.TGetByIdAsync(id);
            if (question == null)
                return NotFound();

            await _questionService.TDeleteAsync(id);
            return NoContent();
        }

      
    }

}
