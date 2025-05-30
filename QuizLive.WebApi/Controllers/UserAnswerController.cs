using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizLive.DataAccess.Abstract;
using QuizLive.DTO.UserAnswerDto;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAnswerController : ControllerBase
    {
        private readonly IUserAnswerService _userAnswerService;
        private readonly IMapper _mapper;
        public UserAnswerController(IUserAnswerService userAnswerService, IMapper mapper)
        {
            _userAnswerService = userAnswerService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAnswerById(int id)
        {
            var answer = await _userAnswerService.GetUserAnswersWithQuestionAndSelectedOptionAsync(id);
            if (answer == null)
                return NotFound();

            var resultDto = _mapper.Map<ResultUserAnswerDto>(answer);
            return Ok(resultDto);
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateUserAnswer([FromBody] CreateUserAnswerDto createUserAnswerDto)
        {
            if (createUserAnswerDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userAnswer = _mapper.Map<UserAnswer>(createUserAnswerDto);
            await _userAnswerService.TAddAsync(userAnswer);

            return CreatedAtAction(nameof(GetUserAnswerById), new { id = userAnswer.Id }, userAnswer);
        }

    }
}