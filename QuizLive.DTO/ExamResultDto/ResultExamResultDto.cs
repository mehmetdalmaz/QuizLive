using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizLive.DTO.ExamResultDto
{
    public class ResultExamResultDto
    {
        public int Id { get; set; }

        public string AppUserName { get; set; }
        public int ExamId { get; set; }
        public string ExamTitle { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int Score { get; set; }

    }
}