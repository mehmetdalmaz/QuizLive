using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizLive.DTO.ExamResultDto
{
    public class CreateExamResultDto
    {
        public int AppUserId { get; set; }
        public int ExamId { get; set; }
        public DateTime StartTime { get; set; } = DateTime.UtcNow;

    }
}