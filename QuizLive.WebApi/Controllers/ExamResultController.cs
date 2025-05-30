
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizLive.DataAccess.Abstract;
using QuizLive.DTO.ExamResultDto;

namespace QuizLive.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultService _examResultService;
        public ExamResultController(IExamResultService examResultService)
        {
            _examResultService = examResultService;
        }
        [Authorize]
        [HttpPost("start")]
        public async Task<ActionResult<int>> StartExam([FromBody] CreateExamResultDto dto)
        {
            var userIdString = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (string.IsNullOrEmpty(userIdString))
                return Unauthorized("Kullanıcı doğrulanamadı.");

            if (!int.TryParse(userIdString, out int userId))
                return BadRequest("Kullanıcı ID'si geçersiz.");

            dto.AppUserId = userId;

            var examResultId = await _examResultService.StartExamAsync(dto);
            return Ok(examResultId);
        }

        [HttpGet("byExam/{examId}")]
        public async Task<ActionResult<List<ResultExamResultDto>>> GetResultsByExam(int examId)
        {
            var results = await _examResultService.GetExamResultsByExamIdAsync(examId);
            return Ok(results);
        }

        [HttpPost("finish")]
        public async Task<ActionResult<bool>> FinishExam([FromBody] UpdateExamResultDto dto)
        {
            var calculatedScore = await _examResultService.CalculateScoreAsync(dto.Id);

            dto.Score = calculatedScore;
            dto.EndTime = DateTime.UtcNow;

            var result = await _examResultService.FinishExamAsync(dto);
            if (!result)
                return NotFound("Exam result not found.");

            return Ok(new { dto.Score });
        }
        [HttpGet("my-results")]
        public async Task<IActionResult> GetMyResults()
        {
            var userIdString = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (string.IsNullOrEmpty(userIdString))
                return Unauthorized("Kullanıcı doğrulanamadı.");

            if (!int.TryParse(userIdString, out int userId))
                return BadRequest("Kullanıcı ID'si geçersiz.");
            var results = await _examResultService.GetExamResultsByUserAsync(userId);
            return Ok(results);
        }
       










    }
}